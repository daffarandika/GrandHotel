using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrandHotel
{
    public partial class Login : Form
    {
        bool showPassword = true;
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string password = Helper.toSha256(txtPassword.Text);
            string username = txtUsername.Text;
            string command = "select * from Employee where Username = '" + username + "' and Password = '" + password + "'";
            if (Helper.hasRows(command))
            {
                Variables.employeeID = Helper.getRow("select id from employee where Username = '" + username + "' and Password = '" + password + "'", "id");
                switch (Helper.getRow(command, "JobID"))
                {
                    case "1":
                        Admin admin = new Admin();
                        Hide();
                        admin.ShowDialog();
                        Close();
                        break;
                    case "2":
                        FrontOffice frontOffice = new FrontOffice();
                        Hide();
                        frontOffice.ShowDialog();
                        Close();
                        break;
                    case "3":
                        HouseKeeper houseKeeper = new HouseKeeper();
                        Hide();
                        houseKeeper.ShowDialog();
                        Close();
                        break;
                    case "4":
                        Supervisor supervisor = new Supervisor();
                        Hide();
                        supervisor.ShowDialog();
                        Close();
                        break;
                    default:
                        MessageBox.Show("how is this even possible");
                        break;
                }
                return;
            }
            MessageBox.Show("no");
            
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = showPassword;
        }

        private void checkShow_CheckedChanged(object sender, EventArgs e)
        {
            showPassword = !showPassword;
            txtPassword.UseSystemPasswordChar = showPassword;
            txtPassword.Focus();
        }
    }
}
