﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace MDSoDv2
{
    #region DB Creation

    public class DatabaseHelper
    {
        private readonly string dbPath = "Data Source=MDSoDv2.db;Version=3;";

        public DatabaseHelper()
        {
            if (!System.IO.File.Exists("MDSoDv2.db"))
            {
                SQLiteConnection.CreateFile("MDSoDv2.db");
            }
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();

                string createConfigurationTable = @"
                    CREATE TABLE IF NOT EXISTS Configuration (
                        Key TEXT PRIMARY KEY,
                        Value TEXT NOT NULL
                    );";

                string createStudentsTable = @"
                    CREATE TABLE IF NOT EXISTS Students (
                        StudentID INTEGER PRIMARY KEY AUTOINCREMENT,
                        FirstName TEXT,
                        LastName TEXT,
                        DateOfBirth TEXT,
                        StreetAddress TEXT,
                        City TEXT,
                        State TEXT,
                        ZipCode TEXT,
                        PhoneNumber TEXT,
                        FamilyEmail TEXT,
                        Active BOOLEAN DEFAULT 1
                    );";

                string createParentsTable = @"
                    CREATE TABLE IF NOT EXISTS Parents (
                        ParentID INTEGER PRIMARY KEY AUTOINCREMENT,
                        StudentID INTEGER,
                        FirstName TEXT,
                        LastName TEXT,
                        PhoneNumber TEXT,
                        Email TEXT,
                        Relationship TEXT,
                        FOREIGN KEY(StudentID) REFERENCES Students(StudentID)
                    );";

                string createSessionsTable = @"
                    CREATE TABLE IF NOT EXISTS Sessions (
                        SessionID INTEGER PRIMARY KEY AUTOINCREMENT,
                        SessionName TEXT,
                        StartDate TEXT,
                        EndDate TEXT
                    );";

                string createClassesTable = @"
                    CREATE TABLE IF NOT EXISTS Classes (
                        ClassID INTEGER PRIMARY KEY AUTOINCREMENT,
                        SessionID INTEGER,
                        ClassName TEXT,
                        ClassLocation TEXT,
                        DayOfWeek TEXT,
                        Time TEXT,
                        Teachers TEXT,
                        FOREIGN KEY(SessionID) REFERENCES Sessions(SessionID)
                    );";

                string createTeachersTable = @"
                    CREATE TABLE IF NOT EXISTS Teachers (
                        TeacherID INTEGER PRIMARY KEY AUTOINCREMENT,
                        TeacherName TEXT UNIQUE
                    );";

                string createPaymentsTable = @"
                    CREATE TABLE IF NOT EXISTS Payments (
                        PaymentID INTEGER PRIMARY KEY AUTOINCREMENT,
                        StudentID INTEGER,
                        PaymentDate DATE,
                        Amount DECIMAL(10, 2),
                        PaymentMethod TEXT,
                        FOREIGN KEY(StudentID) REFERENCES Students(StudentID)
                    );";

                string createStudentClassesTable = @"
                    CREATE TABLE IF NOT EXISTS StudentClasses (
                        StudentClassID INTEGER PRIMARY KEY AUTOINCREMENT,
                        StudentID INTEGER,
                        ClassID INTEGER,
                        FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
                        FOREIGN KEY(ClassID) REFERENCES Classes(ClassID)
                    );";
                string createStudentPaymentTable = @"
                    CREATE TABLE IF NOT EXISTS StudentPayments (
                        PaymentID INTEGER PRIMARY KEY AUTOINCREMENT,
                        StudentClassID INTEGER,
                        StudentID INTEGER,
                        ClassID INTEGER,
                        PaymentDueDate TEXT,
                        PaymentReceived BOOLEAN DEFAULT 0,
                        FOREIGN KEY(StudentClassID) REFERENCES StudentClasses(StudentClassID),
                        FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
                        FOREIGN KEY(ClassID) REFERENCES Classes(ClassID)
                    );";

                ExecuteNonQuery(connection, createStudentsTable);
                ExecuteNonQuery(connection, createParentsTable);
                ExecuteNonQuery(connection, createSessionsTable);
                ExecuteNonQuery(connection, createClassesTable);
                ExecuteNonQuery(connection, createTeachersTable);
                ExecuteNonQuery(connection, createPaymentsTable);
                ExecuteNonQuery(connection, createStudentClassesTable);
                ExecuteNonQuery(connection, createConfigurationTable);
                ExecuteNonQuery(connection, createStudentPaymentTable);
            }
        }

        private void ExecuteNonQuery(SQLiteConnection connection, string query)
        {
            using (var command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        #endregion DB Creation

        #region ConfigurationTable

        public void SetConfigurationValue(string key, string value)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                string query = @"INSERT OR REPLACE INTO Configuration (Key, Value) VALUES (@Key, @Value)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Key", key);
                    command.Parameters.AddWithValue("@Value", value);
                    command.ExecuteNonQuery();
                }
            }
        }

        public string GetConfigurationValue(string key)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                string query = "SELECT Value FROM Configuration WHERE Key = @Key";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Key", key);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetString(0);
                        }
                    }
                }
            }
            return null;
        }

        public static string EncryptString(string plainText, string passphrase)
        {
            var key = new Rfc2898DeriveBytes(passphrase, Encoding.UTF8.GetBytes("your-salt-here"), 10000);
            byte[] keyBytes = key.GetBytes(32);

            byte[] iv = new byte[16];
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = keyBytes;
                aesAlg.IV = iv;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
        }

        public static string DecryptString(string cipherText, string passphrase)
        {
            var key = new Rfc2898DeriveBytes(passphrase, Encoding.UTF8.GetBytes("your-salt-here"), 10000);
            byte[] keyBytes = key.GetBytes(32);

            byte[] iv = new byte[16];
            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = keyBytes;
                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        #endregion ConfigurationTable

        #region Student Methods

        public int AddStudent(Student student)
        {
            int newStudentID = 0;
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();

                var checkQuery = "SELECT COUNT(*) FROM Students WHERE FirstName = @FirstName AND LastName = @LastName AND DateOfBirth = @DateOfBirth";
                using (var checkCommand = new SQLiteCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@FirstName", student.FirstName);
                    checkCommand.Parameters.AddWithValue("@LastName", student.LastName);
                    checkCommand.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);

                    var count = Convert.ToInt32(checkCommand.ExecuteScalar());
                    if (count > 0)
                    {
                        throw new Exception("Student with the same First Name, Last Name, and Date of Birth already exists.");
                    }
                }

                var query = "INSERT INTO Students (FirstName, LastName, DateOfBirth, StreetAddress, City, State, ZipCode, PhoneNumber, FamilyEmail, Active) " +
                            "VALUES (@FirstName, @LastName, @DateOfBirth, @StreetAddress, @City, @State, @ZipCode, @PhoneNumber, @FamilyEmail, @Active); " +
                            "SELECT last_insert_rowid();";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", student.FirstName);
                    command.Parameters.AddWithValue("@LastName", student.LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                    command.Parameters.AddWithValue("@StreetAddress", student.StreetAddress);
                    command.Parameters.AddWithValue("@City", student.City);
                    command.Parameters.AddWithValue("@State", student.State);
                    command.Parameters.AddWithValue("@ZipCode", student.ZipCode);
                    command.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);
                    command.Parameters.AddWithValue("@FamilyEmail", student.FamilyEmail);
                    command.Parameters.AddWithValue("@Active", student.Active);

                    newStudentID = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            return newStudentID;
        }

        public void UpdateStudent(Student student)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var query = "UPDATE Students SET FirstName = @FirstName, LastName = @LastName, DateOfBirth = @DateOfBirth, StreetAddress = @StreetAddress, City = @City, State = @State, ZipCode = @ZipCode, PhoneNumber = @PhoneNumber, FamilyEmail = @FamilyEmail, Active = @Active WHERE StudentID = @StudentID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", student.FirstName);
                    command.Parameters.AddWithValue("@LastName", student.LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                    command.Parameters.AddWithValue("@StreetAddress", student.StreetAddress);
                    command.Parameters.AddWithValue("@City", student.City);
                    command.Parameters.AddWithValue("@State", student.State);
                    command.Parameters.AddWithValue("@ZipCode", student.ZipCode);
                    command.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);
                    command.Parameters.AddWithValue("@FamilyEmail", student.FamilyEmail);
                    command.Parameters.AddWithValue("@StudentID", student.StudentID);
                    command.Parameters.AddWithValue("@Active", student.Active);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Student GetStudentById(int studentId)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var query = "SELECT * FROM Students WHERE StudentID = @StudentID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", studentId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DateTime dob;
                            DateTime.TryParseExact(reader["DateOfBirth"].ToString(), "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out dob);

                            bool isActive = false;
                            if (reader["Active"] is long longValue)
                            {
                                isActive = longValue != 0;
                            }
                            else if (reader["Active"] is bool boolValue)
                            {
                                isActive = boolValue;
                            }

                            return new Student
                            {
                                StudentID = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                DateOfBirth = dob.ToString("MM/dd/yyyy"),
                                StreetAddress = reader.GetString(4),
                                City = reader.GetString(5),
                                State = reader.GetString(6),
                                ZipCode = reader.GetString(7),
                                PhoneNumber = reader.GetString(8),
                                FamilyEmail = reader.GetString(9),
                                Active = isActive
                            };
                        }
                    }
                }
            }
            return null;
        }

        public void AddStudentClass(int studentID, int classID)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();

                string query = "INSERT INTO StudentClasses (StudentID, ClassID) VALUES (@StudentID, @ClassID); SELECT last_insert_rowid();";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", studentID);
                    command.Parameters.AddWithValue("@ClassID", classID);

                    int studentClassID = Convert.ToInt32(command.ExecuteScalar());

                    GenerateExpectedPayments(studentClassID);
                }
            }
        }

        public void RemoveStudentClass(int studentID, int classID)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string getStudentClassIdQuery = "SELECT StudentClassID FROM StudentClasses WHERE StudentID = @StudentID AND ClassID = @ClassID";
                        int studentClassID = 0;

                        using (var getIdCommand = new SQLiteCommand(getStudentClassIdQuery, connection))
                        {
                            getIdCommand.Parameters.AddWithValue("@StudentID", studentID);
                            getIdCommand.Parameters.AddWithValue("@ClassID", classID);

                            var result = getIdCommand.ExecuteScalar();
                            if (result != null)
                            {
                                studentClassID = Convert.ToInt32(result);
                            }
                        }

                        if (studentClassID > 0)
                        {
                            string deletePaymentsQuery = "DELETE FROM StudentPayments WHERE StudentClassID = @StudentClassID AND PaymentReceived = 0";
                            using (var deletePaymentsCommand = new SQLiteCommand(deletePaymentsQuery, connection))
                            {
                                deletePaymentsCommand.Parameters.AddWithValue("@StudentClassID", studentClassID);
                                deletePaymentsCommand.ExecuteNonQuery();
                            }

                            string deleteStudentClassQuery = "DELETE FROM StudentClasses WHERE StudentClassID = @StudentClassID";
                            using (var deleteStudentClassCommand = new SQLiteCommand(deleteStudentClassQuery, connection))
                            {
                                deleteStudentClassCommand.Parameters.AddWithValue("@StudentClassID", studentClassID);
                                deleteStudentClassCommand.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public DataTable GetAllStudentsDataTable()
        {
            var dataTable = new DataTable();
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var query = "SELECT StudentID, FirstName, LastName FROM Students";
                using (var adapter = new SQLiteDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        public DataTable GetActiveStudentsDataTable()
        {
            var dataTable = new DataTable();
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var query = "SELECT StudentID, FirstName, LastName FROM Students WHERE Active = 1";
                using (var adapter = new SQLiteDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        public DataTable GetStudentsDataTable()
        {
            var dataTable = new DataTable();
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var query = "SELECT * FROM Students";
                using (var adapter = new SQLiteDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        public Student GetStudentByName(string firstName, string lastName)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var query = "SELECT * FROM Students WHERE FirstName = @FirstName AND LastName = @LastName";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Student
                            {
                                StudentID = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                DateOfBirth = reader.GetString(3),
                                StreetAddress = reader.GetString(4),
                                City = reader.GetString(5),
                                State = reader.GetString(6),
                                ZipCode = reader.GetString(7),
                                PhoneNumber = reader.GetString(8),
                                FamilyEmail = reader.GetString(9),
                                Active = reader.GetBoolean(10)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public void DeleteStudent(int studentId)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var query = "DELETE FROM Students WHERE StudentID = @StudentID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", studentId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Class> GetClassesByStudentId(int studentId)
        {
            var classes = new List<Class>();
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                string query = @"
            SELECT sc.StudentClassID, c.ClassID, c.ClassName, c.ClassLocation, c.DayOfWeek, c.Time, c.Teachers, s.SessionName
            FROM StudentClasses sc
            INNER JOIN Classes c ON sc.ClassID = c.ClassID
            INNER JOIN Sessions s ON c.SessionID = s.SessionID
            WHERE sc.StudentID = @StudentID";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", studentId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            classes.Add(new Class
                            {
                                // Modify the Class model to include StudentClassID
                                StudentClassID = reader.GetInt32(0),
                                ClassID = reader.GetInt32(1),
                                ClassName = reader.GetString(2),
                                ClassLocation = reader.GetString(3),
                                DayOfWeek = reader.GetString(4),
                                Time = reader.GetString(5),
                                Teachers = reader.GetString(6),
                                SessionName = reader.GetString(7)
                            });
                        }
                    }
                }
            }
            return classes;
        }

        #endregion Student Methods

        #region Class Methods

        public DataTable GetClassesWithSessionNames()
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                string query = @"
            SELECT
                s.SessionName,
                c.ClassID,
                c.ClassName,
                c.ClassLocation,
                c.DayOfWeek,
                c.Time,
                c.Teachers
            FROM Classes c
            JOIN Sessions s ON c.SessionID = s.SessionID";

                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable classesTable = new DataTable();
                        adapter.Fill(classesTable);
                        return classesTable;
                    }
                }
            }
        }

        public void DeleteClassesByStudentId(int studentId)
        {
            using (var conn = new SQLiteConnection(dbPath))
            {
                conn.Open();
                string query = "DELETE FROM StudentClasses WHERE StudentID = @StudentID";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Class GetClassById(int classId)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var query = @"
            SELECT c.ClassID, s.SessionName, c.ClassName, c.ClassLocation,
                   c.DayOfWeek, c.Time, c.Teachers
            FROM Classes c
            JOIN Sessions s ON c.SessionID = s.SessionID
            WHERE c.ClassID = @ClassID";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClassID", classId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Class
                            {
                                ClassID = reader.GetInt32(0),
                                SessionName = reader.GetString(1),
                                ClassName = reader.GetString(2),
                                ClassLocation = reader.GetString(3),
                                DayOfWeek = reader.GetString(4),
                                Time = reader.GetString(5),
                                Teachers = reader.GetString(6)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public void AddClass(Class classDetails)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var query = "INSERT INTO Classes (SessionID, ClassName, ClassLocation, DayOfWeek, Time, Teachers) VALUES (@SessionID, @ClassName, @ClassLocation, @DayOfWeek, @Time, @Teachers)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SessionID", classDetails.SessionID);
                    command.Parameters.AddWithValue("@ClassName", classDetails.ClassName);
                    command.Parameters.AddWithValue("@ClassLocation", classDetails.ClassLocation);
                    command.Parameters.AddWithValue("@DayOfWeek", classDetails.DayOfWeek);
                    command.Parameters.AddWithValue("@Time", classDetails.Time);
                    command.Parameters.AddWithValue("@Teachers", classDetails.Teachers);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateClass(Class classDetails)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var query = "UPDATE Classes SET SessionID = @SessionID, ClassName = @ClassName, ClassLocation = @ClassLocation, DayOfWeek = @DayOfWeek, Time = @Time, Teachers = @Teachers WHERE ClassID = @ClassID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SessionID", classDetails.SessionID);
                    command.Parameters.AddWithValue("@ClassName", classDetails.ClassName);
                    command.Parameters.AddWithValue("@ClassLocation", classDetails.ClassLocation);
                    command.Parameters.AddWithValue("@DayOfWeek", classDetails.DayOfWeek);
                    command.Parameters.AddWithValue("@Time", classDetails.Time);
                    command.Parameters.AddWithValue("@Teachers", classDetails.Teachers);
                    command.Parameters.AddWithValue("@ClassID", classDetails.ClassID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetClassesDataTable()
        {
            var dataTable = new DataTable();
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var query = @"
            SELECT c.DayOfWeek, c.Time, c.ClassName, c.ClassLocation, s.SessionName,
                   c.Teachers, c.ClassID
            FROM Classes c
            JOIN Sessions s ON c.SessionID = s.SessionID
            ORDER BY
                CASE c.DayOfWeek
                    WHEN 'Monday' THEN 1
                    WHEN 'Tuesday' THEN 2
                    WHEN 'Wednesday' THEN 3
                    WHEN 'Thursday' THEN 4
                    WHEN 'Friday' THEN 5
                    WHEN 'Saturday' THEN 6
                    WHEN 'Sunday' THEN 7
                END,
                TIME(c.Time)";

                using (var adapter = new SQLiteDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        public List<Class> GetClassesBySessionId(int sessionId)
        {
            var classes = new List<Class>();

            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                string query = @"
                SELECT ClassID, ClassName
                FROM Classes
                WHERE SessionID = @SessionID";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SessionID", sessionId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            classes.Add(new Class
                            {
                                ClassID = reader.GetInt32(0),
                                ClassName = reader.GetString(1)
                            });
                        }
                    }
                }
            }

            return classes;
        }

        public List<Class> GetClassesBySessionIdWithStudents(int sessionId)
        {
            var classes = new List<Class>();

            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();

                var query = @"
        SELECT c.ClassID, c.ClassName, c.ClassLocation, c.DayOfWeek, c.Time
        FROM Classes c
        JOIN StudentClasses sc ON sc.ClassID = c.ClassID
        WHERE c.SessionID = @SessionID
        GROUP BY c.ClassID, c.ClassName, c.ClassLocation, c.DayOfWeek, c.Time
        HAVING COUNT(sc.StudentID) > 0";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SessionID", sessionId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var classObj = new Class
                            {
                                ClassID = reader.GetInt32(0),
                                ClassName = reader.GetString(1),
                                ClassLocation = reader.GetString(2),
                                DayOfWeek = reader.GetString(3),
                                Time = reader.GetString(4)
                            };
                            classes.Add(classObj);
                        }
                    }
                }
            }

            return classes;
        }

        public void DeleteClass(int classId)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var query = "DELETE FROM Classes WHERE ClassID = @ClassID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClassID", classId);
                    command.ExecuteNonQuery();
                }
            }
        }

        #endregion Class Methods

        #region Session Methods

        public List<Session> GetAllSessions()
        {
            var sessions = new List<Session>();
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var query = "SELECT * FROM Sessions";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sessions.Add(new Session
                            {
                                SessionID = reader.GetInt32(0),
                                SessionName = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            return sessions;
        }

        public DataTable GetSessionsDataTable()
        {
            var dataTable = new DataTable();
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var query = "SELECT * FROM Sessions";
                using (var adapter = new SQLiteDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        public void DeleteSession(int sessionId)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var query = "DELETE FROM Sessions WHERE SessionID = @SessionID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SessionID", sessionId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ImportSessionsFromDataTable(DataTable dataTable)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                foreach (DataRow row in dataTable.Rows)
                {
                    var query = "INSERT INTO Sessions (SessionName) VALUES (@SessionName)";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SessionName", row["SessionName"]);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void AddSession(Session session)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var query = "INSERT INTO Sessions (SessionName) VALUES (@SessionName)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SessionName", session.SessionName);
                    command.ExecuteNonQuery();
                }
            }
        }

        #endregion Session Methods

        #region Teacher Methods

        public List<Teacher> GetAllTeachers()
        {
            var teachers = new List<Teacher>();
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var query = "SELECT * FROM Teachers";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            teachers.Add(new Teacher
                            {
                                TeacherID = reader.GetInt32(0),
                                TeacherName = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            return teachers;
        }

        public void AddTeacher(Teacher teacher)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();

                var checkQuery = "SELECT COUNT(*) FROM Teachers WHERE TeacherName = @TeacherName";
                using (var checkCommand = new SQLiteCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@TeacherName", teacher.TeacherName);
                    var count = Convert.ToInt32(checkCommand.ExecuteScalar());
                    if (count > 0)
                    {
                        throw new Exception("Teacher already exists.");
                    }
                }

                var query = "INSERT INTO Teachers (TeacherName) VALUES (@TeacherName)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TeacherName", teacher.TeacherName);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteTeacher(int teacherId)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var query = "DELETE FROM Teachers WHERE TeacherID = @TeacherID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TeacherID", teacherId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetTeachersDataTable()
        {
            var dataTable = new DataTable();
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var query = "SELECT * FROM Teachers";
                using (var adapter = new SQLiteDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        #endregion Teacher Methods

        #region Payment Methods

        public void AddPayment(Payment payment)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var query = "INSERT INTO Payments (StudentID, PaymentDate, Amount, PaymentMethod) VALUES (@StudentID, @PaymentDate, @Amount, @PaymentMethod)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", payment.StudentID);
                    command.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                    command.Parameters.AddWithValue("@Amount", payment.Amount);
                    command.Parameters.AddWithValue("@PaymentMethod", payment.PaymentMethod);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdatePayment(Payment payment)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var query = "UPDATE Payments SET PaymentDate = @PaymentDate, Amount = @Amount, PaymentMethod = @PaymentMethod WHERE PaymentID = @PaymentID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                    command.Parameters.AddWithValue("@Amount", payment.Amount);
                    command.Parameters.AddWithValue("@PaymentMethod", payment.PaymentMethod);
                    command.Parameters.AddWithValue("@PaymentID", payment.PaymentID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeletePayment(int paymentId)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var query = "DELETE FROM Payments WHERE PaymentID = @PaymentID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PaymentID", paymentId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Payment> GetPaymentsByStudentId(int studentId)
        {
            var payments = new List<Payment>();
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var query = "SELECT * FROM Payments WHERE StudentID = @StudentID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", studentId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            payments.Add(new Payment
                            {
                                PaymentID = reader.GetInt32(0),
                                StudentID = reader.GetInt32(1),
                                PaymentDate = reader.GetDateTime(2),
                                Amount = reader.GetDecimal(3),
                                PaymentMethod = reader.GetString(4)
                            });
                        }
                    }
                }
            }
            return payments;
        }

        public Payment GetPaymentById(int paymentId)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var query = "SELECT * FROM Payments WHERE PaymentID = @PaymentID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PaymentID", paymentId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Payment
                            {
                                PaymentID = reader.GetInt32(0),
                                StudentID = reader.GetInt32(1),
                                PaymentDate = reader.GetDateTime(2),
                                Amount = reader.GetDecimal(3),
                                PaymentMethod = reader.GetString(4)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public DataTable GetPaymentsDataTable()
        {
            var dataTable = new DataTable();
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var query = "SELECT * FROM Payments";
                using (var adapter = new SQLiteDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        public void GenerateExpectedPayments(int studentClassId)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();

                // Updated query to include StudentID and ClassID
                string query = @"
            SELECT sc.StudentClassID, sc.StudentID, c.ClassID, s.SessionID, s.SessionName, c.ClassName, s.StartDate, s.EndDate
            FROM StudentClasses sc
            JOIN Classes c ON sc.ClassID = c.ClassID
            JOIN Sessions s ON c.SessionID = s.SessionID
            WHERE sc.StudentClassID = @StudentClassID";  // Add a WHERE clause to filter by the given studentClassId

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentClassID", studentClassId); // Use the provided studentClassId to filter
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int studentClassID = reader.GetInt32(0);
                            int studentID = reader.GetInt32(1); // Retrieve StudentID
                            int classID = reader.GetInt32(2);   // Retrieve ClassID
                            DateTime startDate = DateTime.Parse(reader["StartDate"].ToString());
                            DateTime endDate = DateTime.Parse(reader["EndDate"].ToString());

                            List<DateTime> paymentDueDates = new List<DateTime>();

                            paymentDueDates.Add(startDate);

                            DateTime paymentDueDate = new DateTime(startDate.Year, startDate.Month, 1).AddMonths(1);
                            while (paymentDueDate <= endDate)
                            {
                                paymentDueDates.Add(paymentDueDate);
                                paymentDueDate = paymentDueDate.AddMonths(1);
                            }

                            foreach (var date in paymentDueDates)
                            {
                                // Check if the payment record already exists
                                if (!PaymentExists(studentClassID, date))
                                {
                                    // Updated insert query to include StudentID and ClassID
                                    string insertQuery = "INSERT INTO StudentPayments (StudentClassID, StudentID, ClassID, PaymentDueDate, PaymentReceived) VALUES (@StudentClassID, @StudentID, @ClassID, @PaymentDueDate, 0)";
                                    using (var insertCommand = new SQLiteCommand(insertQuery, connection))
                                    {
                                        insertCommand.Parameters.AddWithValue("@StudentClassID", studentClassID);
                                        insertCommand.Parameters.AddWithValue("@StudentID", studentID);  // Add StudentID
                                        insertCommand.Parameters.AddWithValue("@ClassID", classID);      // Add ClassID
                                        insertCommand.Parameters.AddWithValue("@PaymentDueDate", date);
                                        insertCommand.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        // Helper method to check if a payment record exists
        public bool PaymentExists(int studentClassID, DateTime paymentDueDate)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var query = "SELECT COUNT(*) FROM StudentPayments WHERE StudentClassID = @StudentClassID AND PaymentDueDate = @PaymentDueDate";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentClassID", studentClassID);
                    command.Parameters.AddWithValue("@PaymentDueDate", paymentDueDate);
                    var count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public void MarkPaymentAsReceived(int paymentId)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                string query = "UPDATE StudentPayments SET PaymentReceived = 1 WHERE PaymentID = @PaymentID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PaymentID", paymentId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<PaymentRecord> GetPaymentsForStudentClass(int studentClassId)
        {
            var paymentRecords = new List<PaymentRecord>();

            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                string query = @"
            SELECT PaymentID, StudentClassID, StudentID, ClassID, PaymentDueDate, PaymentReceived
            FROM StudentPayments
            WHERE StudentClassID = @StudentClassID
            ORDER BY PaymentDueDate";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentClassID", studentClassId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            paymentRecords.Add(new PaymentRecord
                            {
                                PaymentID = reader.GetInt32(0),
                                StudentClassID = reader.GetInt32(1),
                                StudentID = reader.GetInt32(2), // New column
                                ClassID = reader.GetInt32(3),   // New column
                                PaymentDueDate = DateTime.Parse(reader["PaymentDueDate"].ToString()),
                                PaymentReceived = reader.GetBoolean(5)
                            });
                        }
                    }
                }
            }

            return paymentRecords;
        }

        #endregion Payment Methods

        #region Parent Methods

        public void AddParent(Parent parent)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var query = @"INSERT INTO Parents (StudentID, FirstName, LastName, PhoneNumber, Email, Relationship)
                              VALUES (@StudentID, @FirstName, @LastName, @PhoneNumber, @Email, @Relationship)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", parent.StudentID);
                    command.Parameters.AddWithValue("@FirstName", parent.FirstName);
                    command.Parameters.AddWithValue("@LastName", parent.LastName);
                    command.Parameters.AddWithValue("@PhoneNumber", parent.PhoneNumber);
                    command.Parameters.AddWithValue("@Email", parent.Email);
                    command.Parameters.AddWithValue("@Relationship", parent.Relationship);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteParent(int parentId)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var query = "DELETE FROM Parents WHERE ParentID = @ParentID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ParentID", parentId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateParent(Parent parent)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var query = @"UPDATE Parents
                              SET FirstName = @FirstName, LastName = @LastName,
                                  PhoneNumber = @PhoneNumber, Email = @Email,
                                  Relationship = @Relationship
                              WHERE ParentID = @ParentID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", parent.FirstName);
                    command.Parameters.AddWithValue("@LastName", parent.LastName);
                    command.Parameters.AddWithValue("@PhoneNumber", parent.PhoneNumber);
                    command.Parameters.AddWithValue("@Email", parent.Email);
                    command.Parameters.AddWithValue("@Relationship", parent.Relationship);
                    command.Parameters.AddWithValue("@ParentID", parent.ParentID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Parent> GetParentsByStudentId(int studentId)
        {
            var parents = new List<Parent>();
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                var query = "SELECT * FROM Parents WHERE StudentID = @StudentID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", studentId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            parents.Add(new Parent
                            {
                                ParentID = reader.GetInt32(0),
                                StudentID = reader.GetInt32(1),
                                FirstName = reader.GetString(2),
                                LastName = reader.GetString(3),
                                PhoneNumber = reader.GetString(4),
                                Email = reader.GetString(5),
                                Relationship = reader.GetString(6)
                            });
                        }
                    }
                }
            }
            return parents;
        }

        #endregion Parent Methods

        #region Import Methods

        public void ImportStudentsFromDataTable(DataTable dataTable)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        int studentId = 0; // Initialize studentId with a default value.
                        int studentIdIndex = 0;
                        int firstNameIndex = 1;
                        int lastNameIndex = 2;
                        int dateOfBirthIndex = 3;
                        int streetAddressIndex = 4;
                        int cityIndex = 5;
                        int stateIndex = 6;
                        int zipCodeIndex = 7;
                        int phoneNumberIndex = 8;
                        int familyEmailIndex = 9;
                        int activeIndex = 10;

                        string studentIdValue = row[studentIdIndex].ToString();
                        bool studentIdExists = !string.IsNullOrEmpty(studentIdValue) && int.TryParse(studentIdValue, out studentId);

                        if (!studentIdExists)
                        {
                            studentIdIndex = -1;
                            firstNameIndex -= 1;
                            lastNameIndex -= 1;
                            dateOfBirthIndex -= 1;
                            streetAddressIndex -= 1;
                            cityIndex -= 1;
                            stateIndex -= 1;
                            zipCodeIndex -= 1;
                            phoneNumberIndex -= 1;
                            familyEmailIndex -= 1;
                            activeIndex -= 1;
                        }

                        bool isActive = !string.IsNullOrEmpty(row[activeIndex].ToString()) && row[activeIndex].ToString().ToUpper() == "TRUE";
                        int activeValue = isActive ? 1 : 0;

                        if (!studentIdExists)
                        {
                            var insertQuery = "INSERT INTO Students (FirstName, LastName, DateOfBirth, StreetAddress, City, State, ZipCode, PhoneNumber, FamilyEmail, Active) VALUES (@FirstName, @LastName, @DateOfBirth, @StreetAddress, @City, @State, @ZipCode, @PhoneNumber, @FamilyEmail, @Active)";
                            using (var insertCommand = new SQLiteCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@FirstName", row[firstNameIndex] ?? DBNull.Value);
                                insertCommand.Parameters.AddWithValue("@LastName", row[lastNameIndex] ?? DBNull.Value);
                                insertCommand.Parameters.AddWithValue("@DateOfBirth", row[dateOfBirthIndex] ?? DBNull.Value);
                                insertCommand.Parameters.AddWithValue("@StreetAddress", row[streetAddressIndex] ?? DBNull.Value);
                                insertCommand.Parameters.AddWithValue("@City", row[cityIndex] ?? DBNull.Value);
                                insertCommand.Parameters.AddWithValue("@State", row[stateIndex] ?? DBNull.Value);
                                insertCommand.Parameters.AddWithValue("@ZipCode", row[zipCodeIndex] ?? DBNull.Value);
                                insertCommand.Parameters.AddWithValue("@PhoneNumber", row[phoneNumberIndex] ?? DBNull.Value);
                                insertCommand.Parameters.AddWithValue("@FamilyEmail", row[familyEmailIndex] ?? DBNull.Value);
                                insertCommand.Parameters.AddWithValue("@Active", activeValue);
                                insertCommand.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            var updateQuery = "UPDATE Students SET FirstName = @FirstName, LastName = @LastName, DateOfBirth = @DateOfBirth, StreetAddress = @StreetAddress, City = @City, State = @State, ZipCode = @ZipCode, PhoneNumber = @PhoneNumber, FamilyEmail = @FamilyEmail, Active = @Active WHERE StudentID = @StudentID";
                            using (var updateCommand = new SQLiteCommand(updateQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@StudentID", studentId); // studentId is now guaranteed to be assigned.
                                updateCommand.Parameters.AddWithValue("@FirstName", row[firstNameIndex] ?? DBNull.Value);
                                updateCommand.Parameters.AddWithValue("@LastName", row[lastNameIndex] ?? DBNull.Value);
                                updateCommand.Parameters.AddWithValue("@DateOfBirth", row[dateOfBirthIndex] ?? DBNull.Value);
                                updateCommand.Parameters.AddWithValue("@StreetAddress", row[streetAddressIndex] ?? DBNull.Value);
                                updateCommand.Parameters.AddWithValue("@City", row[cityIndex] ?? DBNull.Value);
                                updateCommand.Parameters.AddWithValue("@State", row[stateIndex] ?? DBNull.Value);
                                updateCommand.Parameters.AddWithValue("@ZipCode", row[zipCodeIndex] ?? DBNull.Value);
                                updateCommand.Parameters.AddWithValue("@PhoneNumber", row[phoneNumberIndex] ?? DBNull.Value);
                                updateCommand.Parameters.AddWithValue("@FamilyEmail", row[familyEmailIndex] ?? DBNull.Value);
                                updateCommand.Parameters.AddWithValue("@Active", activeValue);
                                updateCommand.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error importing row: {ex.Message}\n\nRow data:\n{string.Join(", ", row.ItemArray)}");
                        MessageBox.Show($"Error importing row: {ex.Message}\n\nRow data:\n{string.Join(", ", row.ItemArray)}",
                                        "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void ImportClassesFromDataTable(DataTable dataTable)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                foreach (DataRow row in dataTable.Rows)
                {
                    var query = "INSERT INTO Classes (SessionID, ClassName, DayOfWeek, Time, Teachers) VALUES (@SessionID, @ClassName, @DayOfWeek, @Time, @Teachers)";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SessionID", row["SessionID"]);
                        command.Parameters.AddWithValue("@ClassName", row["ClassName"]);
                        command.Parameters.AddWithValue("@DayOfWeek", row["DayOfWeek"]);
                        command.Parameters.AddWithValue("@Time", row["Time"]);
                        command.Parameters.AddWithValue("@Teachers", row["Teachers"]);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void ImportTeachersFromDataTable(DataTable dataTable)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                foreach (DataRow row in dataTable.Rows)
                {
                    var query = "INSERT INTO Teachers (TeacherName) VALUES (@TeacherName)";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TeacherName", row["TeacherName"]);
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (SQLiteException ex) when (ex.ResultCode == SQLiteErrorCode.Constraint)
                        {
                            Console.WriteLine($"Duplicate teacher name found: {row["TeacherName"]}");
                        }
                    }
                }
            }
        }

        public void ImportPaymentsFromDataTable(DataTable dataTable)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                foreach (DataRow row in dataTable.Rows)
                {
                    var query = "INSERT INTO Payments (StudentID, PaymentDate, Amount, PaymentMethod) VALUES (@StudentID, @PaymentDate, @Amount, @PaymentMethod)";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StudentID", row["StudentID"]);
                        command.Parameters.AddWithValue("@PaymentDate", row["PaymentDate"]);
                        command.Parameters.AddWithValue("@Amount", row["Amount"]);
                        command.Parameters.AddWithValue("@PaymentMethod", row["PaymentMethod"]);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        #endregion Import Methods

        #region Reporting - Unknown

        public List<UnknownEntry> GetUnknowns()
        {
            var unknownEntries = new List<UnknownEntry>();

            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();

                var studentQuery = "SELECT * FROM Students";
                using (var studentCommand = new SQLiteCommand(studentQuery, connection))
                {
                    using (var reader = studentCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                var fieldValue = reader.GetValue(i).ToString();
                                if (fieldValue.IndexOf("Unknown", StringComparison.OrdinalIgnoreCase) >= 0)
                                {
                                    unknownEntries.Add(new UnknownEntry
                                    {
                                        EntityType = "Student",
                                        FirstName = reader["FirstName"].ToString(),
                                        LastName = reader["LastName"].ToString(),
                                        FieldWithUnknown = $"{reader.GetName(i)}: {fieldValue}"
                                    });
                                }
                            }
                        }
                    }
                }

                var parentQuery = "SELECT * FROM Parents";
                using (var parentCommand = new SQLiteCommand(parentQuery, connection))
                {
                    using (var reader = parentCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                var fieldValue = reader.GetValue(i).ToString();
                                if (fieldValue.IndexOf("Unknown", StringComparison.OrdinalIgnoreCase) >= 0)
                                {
                                    unknownEntries.Add(new UnknownEntry
                                    {
                                        EntityType = "Parent",
                                        FirstName = reader["FirstName"].ToString(),
                                        LastName = reader["LastName"].ToString(),
                                        FieldWithUnknown = $"{reader.GetName(i)}: {fieldValue}"
                                    });
                                }
                            }
                        }
                    }
                }
            }

            return unknownEntries;
        }

        #endregion Reporting - Unknown

        #region Reporting - ClassSheets

        public List<Class> GetClassesWithStudents()
        {
            var classes = new List<Class>();

            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                string query = @"
                    SELECT DISTINCT c.ClassID, c.ClassName
                    FROM Classes c
                    INNER JOIN StudentClasses sc ON c.ClassID = sc.ClassID
                    INNER JOIN Students s ON sc.StudentID = s.StudentID";

                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var classObj = new Class
                            {
                                ClassID = reader.GetInt32(0),
                                ClassName = reader.GetString(1)
                            };
                            classes.Add(classObj);
                        }
                    }
                }
            }

            return classes;
        }

        public List<Student> GetStudentsByClassId(int classId)
        {
            var students = new List<Student>();

            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                string query = @"
                    SELECT s.StudentID, s.FirstName, s.LastName
                    FROM Students s
                    INNER JOIN StudentClasses sc ON s.StudentID = sc.StudentID
                    WHERE sc.ClassID = @ClassID";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClassID", classId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var student = new Student
                            {
                                StudentID = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2)
                            };
                            students.Add(student);
                        }
                    }
                }
            }

            return students;
        }

        #endregion Reporting - ClassSheets

        #region StudentClasses

        public List<StudentClass> GetAllStudentClasses()
        {
            var studentClasses = new List<StudentClass>();
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                string query = "SELECT * FROM StudentClasses";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            studentClasses.Add(new StudentClass
                            {
                                StudentClassID = reader.GetInt32(0),
                                StudentID = reader.GetInt32(1),
                                ClassID = reader.GetInt32(2)
                            });
                        }
                    }
                }
            }
            return studentClasses;
        }

        public List<PaymentRecord> GetPaymentsForStudent(int studentId)
        {
            var paymentRecords = new List<PaymentRecord>();

            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                string query = @"
            SELECT sp.*
            FROM StudentPayments sp
            JOIN StudentClasses sc ON sp.StudentClassID = sc.StudentClassID
            WHERE sc.StudentID = @StudentID
            ORDER BY sp.PaymentDueDate";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", studentId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            paymentRecords.Add(new PaymentRecord
                            {
                                PaymentID = reader.GetInt32(0),
                                StudentClassID = reader.GetInt32(1),
                                PaymentDueDate = DateTime.Parse(reader["PaymentDueDate"].ToString()),
                                PaymentReceived = reader.GetBoolean(3)
                            });
                        }
                    }
                }
            }

            return paymentRecords;
        }

        #endregion StudentClasses
    }
}