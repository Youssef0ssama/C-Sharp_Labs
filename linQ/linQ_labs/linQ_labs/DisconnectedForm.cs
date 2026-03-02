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
    public partial class DisconnectedForm : Form
    {
        string connectionString = "Data Source=YOUSSEF\\SQLEXPRESS;Initial Catalog=CompanyDB;Integrated Security=True;TrustServerCertificate=True;";

        SqlDataAdapter adapter;
        DataTable dt;

        public DisconnectedForm()
        {
            InitializeComponent();

            btnDisplay.Click += BtnDisplay_Click;
            btnInsert.Click += BtnInsert_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnSearch.Click += BtnSearch_Click;

            InitializeDisconnectedData();
        }

        private void InitializeDisconnectedData()
        {
            string query = "SELECT * FROM Employee";
            adapter = new SqlDataAdapter(query, connectionString);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            dt = new DataTable();
            adapter.Fill(dt);

            if (dt.Columns.Contains("ID"))
            {
                dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };
            }
        }

        private void BtnDisplay_Click(object sender, EventArgs e)
        {
            dt.Clear();
            adapter.Fill(dt);
            Employees.DataSource = dt;
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            DataRow newRow = dt.NewRow();
            newRow["ID"] = txtID.Text;
            newRow["Name"] = txtName.Text;
            newRow["Department"] = txtDept.Text;

            dt.Rows.Add(newRow);
            adapter.Update(dt);
            MessageBox.Show("Employee Added (Disconnected Mode)!");
            Employees.DataSource = dt;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            DataRow row = dt.Rows.Find(txtID.Text);

            if (row != null)
            {
                row["Name"] = txtName.Text;
                row["Department"] = txtDept.Text;
                adapter.Update(dt);
                MessageBox.Show("Employee Updated (Disconnected Mode)!");
            }
            else
            {
                MessageBox.Show("Employee ID not found.");
            }

            Employees.DataSource = dt;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DataRow row = dt.Rows.Find(txtID.Text);

            if (row != null)
            {
                row.Delete();
                adapter.Update(dt);
                MessageBox.Show("Employee Deleted (Disconnected Mode)!");
            }
            else
            {
                MessageBox.Show("Employee ID not found.");
            }

            Employees.DataSource = dt;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            DataRow row = dt.Rows.Find(txtID.Text);

            if (row != null)
            {
                txtName.Text = row["Name"].ToString();
                txtDept.Text = row["Department"].ToString();
            }
            else
            {
                MessageBox.Show("Employee ID not found.");
                txtName.Text = "";
                txtDept.Text = "";
            }
        }
    }
}
