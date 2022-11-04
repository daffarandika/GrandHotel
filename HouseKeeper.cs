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
    public partial class HouseKeeper : Form
    {
        public HouseKeeper()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            CleaningRoomUC cleaningRoomUC = new CleaningRoomUC();
            panel1.Controls.Add(cleaningRoomUC);
        }
    }
}
