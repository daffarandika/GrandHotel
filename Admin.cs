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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MasterEmployeeUC masterEmployeeUC = new MasterEmployeeUC();
            panel1.Controls.Remove(masterEmployeeUC);
            panel1.Controls.Add(masterEmployeeUC);
        }
    }
}
