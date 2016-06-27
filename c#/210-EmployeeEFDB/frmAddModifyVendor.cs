using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Objects;
using System.Data.SqlClient;

namespace VendorMaintenance
{
    public partial class frmAddModifyVendor : Form
    {
        public frmAddModifyVendor()
        {
            InitializeComponent();
        }

        private void frmAddModifyVendor_Load(object sender, EventArgs e)
        {
            RefreshForm();
        }

        public void RefreshForm()
        {
            var employeeData =
            from datarows in PayablesEntity.EmployeeEFDB.Departments
            from amount in datarows.Employees
            select new
            {
                amount.EmployeeId,
                amount.FirstName,
                amount.LastName,
                amount.Age,
                datarows.DeptName
            };
            dataGridView1.DataSource = employeeData.ToList();

            cboDept.DataSource = PayablesEntity.EmployeeEFDB.Departments.ToList();
            cboDept.DisplayMember = "DeptName";
            cboDept.ValueMember = "DeptName";
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {

                Employee employee = new Employee(); // create a new employee object (not a new SQL row (yet))
                this.PutEmployeeData(employee);  // code below loads up all the vendor "properties" (db fields)

                // Add the new employee to the collection of vendors, 1 line of code
                PayablesEntity.EmployeeEFDB.AddToEmployees(employee);  // using the auto-created add method

                try
                {
                    // save changes to the database, 1 line of code
                    PayablesEntity.EmployeeEFDB.SaveChanges();

                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
                RefreshForm();
                this.ClearControls();
            }
            RefreshForm();
        }

        private bool IsValidData()
        {
            if (Validator.IsPresent(txtFName) &&
                Validator.IsPresent(txtLName) &&
                Validator.IsPresent(cboDept) &&
                Validator.IsPresent(txtAge) &&
                Validator.IsInt32(txtAge))
            {
                return true;
            }
            else
                return false;
        }

        private void PutEmployeeData(Employee employee)
        {
            employee.FirstName = txtFName.Text;
            employee.LastName = txtLName.Text;
            employee.Department = (Department)cboDept.SelectedItem;
            employee.Age = Convert.ToInt32(txtAge.Text);
        }

        private void ClearControls()
        {
            txtFName.Text = "";
            txtLName.Text = "";
            txtAge.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dataGridView1.CurrentRow;
            int Employee = (int)(currentRow.Cells[0].Value);
 
            var selectedEmployee = 
                (from employee in PayablesEntity.EmployeeEFDB.Employees
                where employee.EmployeeId == Employee
                select employee).First();

            PayablesEntity.EmployeeEFDB.DeleteObject(selectedEmployee);
            PayablesEntity.EmployeeEFDB.SaveChanges();
            RefreshForm();
        }

        private void cboStates_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cboTerms_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void ZipCodeLabel_Click(object sender, EventArgs e)
        {
        }

        private void txtLName_TextChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}

