using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrandHotel
{
    public partial class MasterEmployeeUC : UserControl
    {
        bool insertModeEnabled = false;
        bool updateModeEnabled = false;
        bool deleteModeEnabled = false;
        Control[] inputComponents;
        Button[] crudButtons;
        Button[] operationButtons;
        string[] hide;
        public MasterEmployeeUC()
        {
            InitializeComponent();
            inputComponents = new Control[9]
            {
                txtAddress, txtCPassword, txtEmail, txtName, txtName, txtPassword, txtUsername, dtpDOB, cmbJob
            };
            crudButtons = new Button[3]
            {
                btnInsert, btnUpdate, btnDelete
            };
            operationButtons = new Button[2]
            {
                btnSave, btnCancel
            };
            hide = new string[3] { "JobID", "ID1", "Name1" };

        }

        private void MasterEmployeeUC_Load(object sender, EventArgs e)
        {
            fillJobCmb();
            fillEmpDGV();
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUsername.Text = dgvEmployee.CurrentRow.Cells["username"].Value.ToString();
            txtPassword.Text = dgvEmployee.CurrentRow.Cells["password"].Value.ToString();
            txtName.Text = dgvEmployee.CurrentRow.Cells["name"].Value.ToString();
            txtEmail.Text = dgvEmployee.CurrentRow.Cells["email"].Value.ToString();
            txtAddress.Text = dgvEmployee.CurrentRow.Cells["address"].Value.ToString();
            cmbJob.SelectedValue = dgvEmployee.CurrentRow.Cells["jobid"].Value.ToString();
            txtUsername.Text = dgvEmployee.CurrentRow.Cells["username"].Value.ToString();
            dtpDOB.Value = Convert.ToDateTime(dgvEmployee.CurrentRow.Cells["dateofbirth"].Value);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (insertModeEnabled)
            {
                insertAction();
                return;
            }
            if (updateModeEnabled)
            {
                updateAction();
                return;
            }
            if (deleteModeEnabled)
            {
                deleteAction();
                return;
            }
        }

        private void deleteAction()
        {
            Helper.runQuery("delete from employee where employee.id = '" + dgvEmployee.CurrentRow.Cells["id"].Value.ToString() + "'");
            fillEmpDGV();
            Helper.clearText(inputComponents);
        }

        private void updateAction()
        {
            if (Helper.isTextEmpty(inputComponents))
            {
                return;
            }
            string username = txtUsername.Text;
            string password = Helper.toSha256(txtPassword.Text);
            string cpassword = Helper.toSha256(txtCPassword.Text);
            if (password != cpassword)
            {
                Helper.showErrors(new Control[2] { txtPassword, txtCPassword }, "password and confirm password does not match");
                MessageBox.Show("cok;");
                return;
            }
            string name = txtName.Text;
            string email = txtEmail.Text;
            string address = txtAddress.Text;
            string dateofbirth = dtpDOB.Value.ToString("yyyy-MM-dd");
            string jobid = cmbJob.SelectedValue.ToString();
            string employeeid = dgvEmployee.CurrentRow.Cells["id"].Value.ToString();
            string command = "update employee set username = '" + username + "', password = '" + password + "', name = '" + name + "', " +
                "email = '" + email + "', address = '" + address + "', dateofbirth =  '" + dateofbirth + "', jobid = '" + jobid + "' where employee.id = '" + employeeid + "'";
            Helper.runQuery(command);
            fillEmpDGV();
            Helper.clearText(inputComponents);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            enableOperationButtons();
            enableInputComponents();
            disableCrudButtons();
            updateModeEnabled = true;
            insertModeEnabled = false;
            deleteModeEnabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            enableOperationButtons();
            enableInputComponents();
            disableCrudButtons();
            deleteModeEnabled = true;
            insertModeEnabled = false;
            updateModeEnabled = false;
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            enableOperationButtons();
            enableInputComponents();
            disableCrudButtons();
            insertModeEnabled = true;
            updateModeEnabled = false;
            deleteModeEnabled = false;

            //Helper.runQuery("")
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            disableInputComponents();
            enableCrudButtons();
            disableOperationButtons();
            Helper.clearText(inputComponents);
        }
        void fillEmpDGV()
        {
            Helper.fillDataGridView("select *, Job.Name as Job from Employee join Job on JobID = Job.ID order by Employee.ID desc", dgvEmployee, hide);
        }
        void fillJobCmb()
        {
            Helper.fillComboBox("select * from Job", cmbJob, "ID", "Name");
        }
        void enableInputComponents()
        {
            Helper.enableComponents(inputComponents);
        }
        void disableInputComponents()
        {
            Helper.disableComponents(inputComponents);
        }
        void enableCrudButtons()
        {
            Helper.enableComponents(crudButtons);
        }

        void disableCrudButtons()
        {
            Helper.disableComponents(crudButtons);
        }
        void enableOperationButtons()
        {
            Helper.enableComponents(operationButtons);
        }

        void disableOperationButtons()
        {
            Helper.disableComponents(operationButtons);
        }
        void insertAction()
        {
            if (Helper.isTextEmpty(inputComponents))
            {
                return;
            }
            string username = txtUsername.Text;
            string password = Helper.toSha256(txtPassword.Text);
            string cpassword = Helper.toSha256(txtCPassword.Text);
            if (password != cpassword)
            {
                Helper.showErrors(new Control[2] { txtPassword, txtCPassword }, "password and confirm password does not match");
                MessageBox.Show("cok;");
                return;
            }
            string name = txtName.Text;
            string email = txtEmail.Text;
            string address = txtAddress.Text;
            string dateofbirth = dtpDOB.Value.ToString("yyyy-MM-dd");
            string jobid = cmbJob.SelectedValue.ToString();
            string command = "insert into Employee (username, password, email, name, address, dateofbirth, jobid) values " +
                "('"+username+ "', '"+password+"', '"+email+"', '"+name+"', '"+address+"', '"+dateofbirth+"', '"+jobid+"')";
            Helper.runQuery(command);
            fillEmpDGV();
        }

    }
}