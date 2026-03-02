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
    public partial class EntityFrameworkForm : Form
    {
        public EntityFrameworkForm()
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
            using (CompanyContext db = new CompanyContext())
            {
                Employees.DataSource = db.Employees.ToList();
            }
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            using (CompanyContext db = new CompanyContext())
            {
                Employee newEmp = new Employee
                {
                    ID = int.Parse(txtID.Text),
                    Name = txtName.Text,
                    Department = txtDept.Text
                };

                db.Employees.Add(newEmp);

                db.SaveChanges();

                MessageBox.Show("Employee Added successfully using Entity Framework!");
                BtnDisplay_Click(null, null);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            using (CompanyContext db = new CompanyContext())
            {
                int searchId = int.Parse(txtID.Text);

                Employee emp = db.Employees.FirstOrDefault(e => e.ID == searchId);

                if (emp != null)
                {
                    emp.Name = txtName.Text;
                    emp.Department = txtDept.Text;

                    db.SaveChanges();

                    MessageBox.Show("Employee Updated successfully using Entity Framework!");
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
            using (CompanyContext db = new CompanyContext())
            {
                int searchId = int.Parse(txtID.Text);

                Employee emp = db.Employees.FirstOrDefault(e => e.ID == searchId);

                if (emp != null)
                {
                    db.Employees.Remove(emp);

                    db.SaveChanges();

                    MessageBox.Show("Employee Deleted successfully using Entity Framework!");
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
            using (CompanyContext db = new CompanyContext())
            {
                int searchId = int.Parse(txtID.Text);

                Employee emp = db.Employees.FirstOrDefault(e => e.ID == searchId);

                if (emp != null)
                {
                    txtName.Text = emp.Name;
                    txtDept.Text = emp.Department;
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
}

