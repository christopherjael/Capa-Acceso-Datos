using System.Data.SqlClient;

namespace Capa_Acceso_Datos
{
    public partial class Menu : Form
    {

        DataGridViewRow selectedRow;
        public Menu()
        {
            InitializeComponent();
        }

        private void RefreshDataGribView()
        {
            dataGridView1.DataSource = Querys.GetAllContacs(Querys.connectionString);
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            RefreshDataGribView();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            new frmCreateContact().ShowDialog();
            RefreshDataGribView();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            const string message = "Are you sure that you want deleted this row?";
            const string caption = "Delete row";
            DialogResult result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.Yes)
            {
                int id = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
                Querys.DeleteContact(Querys.connectionString, id);
                RefreshDataGribView();
            }
            else if (result == DialogResult.No)
            {
                return;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            selectedRow = dataGridView1.Rows[idx];
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
            string name = selectedRow.Cells[1].Value.ToString();
            string lastName = selectedRow.Cells[2].Value.ToString();
            string dateBirth = selectedRow.Cells[3].Value.ToString();
            string address = selectedRow.Cells[4].Value.ToString();
            string gender = selectedRow.Cells[5].Value.ToString();
            string civilState = selectedRow.Cells[6].Value.ToString();
            string mobile = selectedRow.Cells[7].Value.ToString();
            string phone = selectedRow.Cells[8].Value.ToString();
            string email = selectedRow.Cells[9].Value.ToString();

            new frmUpdateContact(id, name, lastName, dateBirth, address, gender, civilState, mobile, phone, email).ShowDialog();
            RefreshDataGribView();
        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Querys.Populate(Querys.connectionString, txbSearch.Text.Trim());
        }
    }
}