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
    public partial class FrontOffice : Form
    {
        public FrontOffice()
        {
            InitializeComponent();
        }

        private void btnRoomType_Click(object sender, EventArgs e)
        {

        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            ReservationUC reservationUC = new ReservationUC();
            panel1.Controls.Add(reservationUC);
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {

        }

        private void btnAdditionalItem_Click(object sender, EventArgs e)
        {

        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {

        }

        private void FrontOffice_Load(object sender, EventArgs e)
        {

        }

        private void btnRoom_Click(object sender, EventArgs e)
        {

        }

        private void btnItem_Click(object sender, EventArgs e)
        {

        }
    }
}
