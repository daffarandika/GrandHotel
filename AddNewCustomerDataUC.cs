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
    public partial class AddNewCustomerDataUC : UserControl
    {
        public AddNewCustomerDataUC()
        {
            InitializeComponent();
        }

        private void AddNewCustomerDataUC_Load(object sender, EventArgs e)
        {

        }

        private void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            Helper.AddNewControl.phoneNumber = txtPhoneNumber.Text;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            Helper.AddNewControl.name = txtName.Text;
        }
    }
}
