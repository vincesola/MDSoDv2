using System;
using System.Windows.Forms;

namespace MDSoDv2
{
    public partial class PaymentForm : BaseForm
    {
        private int studentId = 0;
        private int paymentId = 0;
        private DatabaseHelper dbHelper;

        public PaymentForm(Form parent)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new System.Drawing.Point(parent.Location.X + 20, parent.Location.Y + 20); // Offset slightly from the parent form
            //this.studentId = studentId;
            //this.paymentId = paymentId;
            dbHelper = new DatabaseHelper();

            if (paymentId > 0)
            {
                LoadPaymentDetails(paymentId);
            }
        }

        private void LoadPaymentDetails(int paymentId)
        {
            var payment = dbHelper.GetPaymentById(paymentId);
            if (payment != null)
            {
                dtpPaymentDate.Value = payment.PaymentDate;
                txtAmount.Text = payment.Amount.ToString();
                cmbPaymentMethod.SelectedItem = payment.PaymentMethod;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var payment = new Payment
            {
                PaymentID = paymentId,
                StudentID = studentId,
                PaymentDate = dtpPaymentDate.Value,
                Amount = decimal.Parse(txtAmount.Text),
                PaymentMethod = cmbPaymentMethod.SelectedItem.ToString()
            };

            if (paymentId > 0)
            {
                dbHelper.UpdatePayment(payment);
            }
            else
            {
                dbHelper.AddPayment(payment);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
