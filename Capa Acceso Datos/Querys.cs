using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Capa_Acceso_Datos
{
    internal static class Querys
    {

        public static string connectionString = "Server=CHRISTOPHER-DEV;Database=dbContacts;Trusted_Connection=True;";

        public static DataTable GetAllContacs(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                string query = "SELECT * FROM dbo.vwGetAllContacts";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                connection.Close();
                return dt;
            }
        }

        public static void CreateContact(string connectionString, string name, string? lastName = null, string? dateBirth = null, string? address = null, string? gender = null,
            string? civilState = null, string? mobile = null, string? phone = null, string? email = null)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("spCreateContact", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = name;
                cmd.Parameters.AddWithValue("@LastName", SqlDbType.VarChar).Value = lastName;
                cmd.Parameters.AddWithValue("@DateBirth", SqlDbType.Date).Value = dateBirth;
                cmd.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = address;
                cmd.Parameters.AddWithValue("@Gender", SqlDbType.VarChar).Value = gender;
                cmd.Parameters.AddWithValue("@CivilState", SqlDbType.VarChar).Value = civilState;
                cmd.Parameters.AddWithValue("@MobileNum", SqlDbType.VarChar).Value = mobile;
                cmd.Parameters.AddWithValue("@PhoneNum", SqlDbType.VarChar).Value = phone;
                cmd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = email;
                cmd.ExecuteNonQuery();
                connection.Close();

                
            }

            MessageBox.Show("Contact Created");
        }

        public static void UpdateContact(string connectionString,int id, string name, string? lastName = null, string? dateBirth = null, string? address = null, string? gender = null,
            string? civilState = null, string? mobile = null, string? phone = null, string? email = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("spUpdateContact", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                cmd.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = name;
                cmd.Parameters.AddWithValue("@LastName", SqlDbType.VarChar).Value = lastName;
                cmd.Parameters.AddWithValue("@DateBirth", SqlDbType.Date).Value = dateBirth;
                cmd.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = address;
                cmd.Parameters.AddWithValue("@Gender", SqlDbType.VarChar).Value = gender;
                cmd.Parameters.AddWithValue("@CivilState", SqlDbType.VarChar).Value = civilState;
                cmd.Parameters.AddWithValue("@MobileNum", SqlDbType.VarChar).Value = mobile;
                cmd.Parameters.AddWithValue("@PhoneNum", SqlDbType.VarChar).Value = phone;
                cmd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = email;
                cmd.ExecuteNonQuery();
                connection.Close();
            }

            MessageBox.Show("Contact Updated");
        }

        public static void DeleteContact(string connectionString, int id)
        {
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("spDeleteContact", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                cmd.ExecuteNonQuery();
                connection.Close();
            }

            MessageBox.Show("Contact Deleted");
        }

        public static DataTable Populate(string connectionString, string text)
        {
            string query = "SELECT * FROM dbo.Contacts";
            query += " WHERE Name LIKE '%' + @ContactName + '%' OR LastName LIKE '%' + @ContactName + '%' OR DateBirth LIKE '%' + @ContactName + '%' OR Address LIKE '%' + @ContactName + '%' OR Gender LIKE '%' + @ContactName + '%'";
            query += "OR CivilState LIKE '%' + @ContactName + '%' OR MobileNum LIKE '%' + @ContactName + '%' OR PhoneNum LIKE '%' + @ContactName + '%' OR Email LIKE '%' + @ContactName + '%' OR @ContactName = ''";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ContactName", text);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }

}
