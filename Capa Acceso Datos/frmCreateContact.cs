using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Acceso_Datos
{
    public partial class frmCreateContact : Form
    {
        public frmCreateContact()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string name = txbName.Text.Trim().ToString();
            string lastName = txbLastName.Text.Trim().ToString();
            string dateBirth = dateTimePicker1.Value.Date.ToString();
            string address = txbAddress.Text.Trim().ToString();
            string gender = this.cbGender.GetItemText(this.cbGender.SelectedItem);
            string civilState = this.cbCivilState.GetItemText(this.cbCivilState.SelectedItem);
            string mobile = txbMobile.Text.Trim().ToString();
            string phone = txbPhone.Text.Trim().ToString();
            string email = txbEmail.Text.Trim().ToString();

            Querys.CreateContact(Querys.connectionString, name, lastName, dateBirth, address, gender, civilState, mobile, phone, email);

            txbName.Clear();
            txbLastName.Clear();
            txbAddress.Clear();
            this.cbGender.Text = null;
            this.cbCivilState.Text = null;
            txbMobile.Clear();
            txbPhone.Clear();
            txbEmail.Clear();
        }
    }
}
