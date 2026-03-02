using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace linQ_labs
{
    public partial class ConnectedForm : Form
    {
        string connectionString = "Data Source=YOUSSEF\\SQLEXPRESS;Initial Catalog=CompanyDB;Integrated Security=True;TrustServerCertificate=True;";

        public ConnectedForm()
        {
            InitializeComponent();

            btnDisplay.Click += BtnDisplay_Click;
            btnInsert.Click += BtnInsert_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnSearch.Click += BtnSearch_Click;
        }

        private void BtnDisplay_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Employee";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                Employees.DataSource = dt;

                reader.Close();
                con.Close();
            }
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Employee (ID, Name, Department) VALUES (@id, @name, @dept)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = int.Parse(txtID.Text) });
                cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar) { Value = txtName.Text });
                cmd.Parameters.Add(new SqlParameter("@dept", SqlDbType.NVarChar) { Value = txtDept.Text });

                con.Open();

                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Employee Added successfully!");
                    BtnDisplay_Click(null, null);
                }
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Employee SET Name = @name, Department = @dept WHERE ID = @id";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = int.Parse(txtID.Text) });
                cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar) { Value = txtName.Text });
                cmd.Parameters.Add(new SqlParameter("@dept", SqlDbType.NVarChar) { Value = txtDept.Text });

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Employee Updated successfully!");
                    BtnDisplay_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Employee ID not found.");
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Employee WHERE ID = @id";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = int.Parse(txtID.Text) });

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Employee Deleted successfully!");
                    BtnDisplay_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Employee ID not found.");
                }
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Name, Department FROM Employee WHERE ID = @id";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = int.Parse(txtID.Text) });

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtName.Text = reader["Name"].ToString();
                    txtDept.Text = reader["Department"].ToString();
                }
                else
                {
                    MessageBox.Show("Employee ID not found.");
                    txtName.Text = "";
                    txtDept.Text = "";
                }

                reader.Close();
                con.Close();
            }
        }
    }
}
