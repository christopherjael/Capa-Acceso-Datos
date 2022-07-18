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
    public partial class frmUpdateContact : Form
    {
        int Id;
        string Name;
        string LastName;
        string DateBirth;
        string Address;
        string Gender;
        string CivilState;
        string Mobile;
        string Phone;
        string Email;
        public frmUpdateContact(int id, string name, string? lastName = null, string? dateBirth = null, string? address = null, string? gender = null,
            string? civilState = null, string? mobile = null, string? phone = null, string? email = null)
        {
            InitializeComponent();

            Id = id;
            Name = name;
            LastName = lastName;
            DateBirth = dateBirth;
            Address = address;
            Gender = gender;
            CivilState = civilState;
            Mobile = mobile;
            Phone = phone;
            Email = email;
        }

        private void frmUpdateContact_Load(object sender, EventArgs e)
        {
            txbName.Text = Name;
            txbLastName.Text = LastName;
            
            txbAddress.Text = Address;
            this.cbGender.Text = Gender;
            this.cbCivilState.Text = CivilState;
            txbMobile.Text = Mobile;
            txbPhone.Text = Phone;
            txbEmail.Text = Email;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if(txbName.Text == "" || this.cbGender.GetItemText(this.cbGender.SelectedItem) == "")
            {
                MessageBox.Show("Name and gender is requierd");
                return;
            }else
            {

                Querys.UpdateContact(Querys.connectionString, Id, txbName.Text, txbLastName.Text, dateTimePicker1.Value.Date.ToString(), txbAddress.Text, this.cbGender.GetItemText(this.cbGender.SelectedItem),
                    this.cbCivilState.GetItemText(this.cbCivilState.SelectedItem), txbMobile.Text, txbPhone.Text, txbEmail.Text);
            } 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
