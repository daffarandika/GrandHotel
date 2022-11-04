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
            panel1.Controls.Clear();
            MasterRoomTypeUC master = new MasterRoomTypeUC();
            panel1.Controls.Add(master);
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            ReservationUC reservationUC = new ReservationUC();
            panel1.Controls.Add(reservationUC);
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            CheckInUC checkInUC = new CheckInUC();
            panel1.Controls.Add(checkInUC);
        }

        private void btnAdditionalItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            RequestAdditionalItemUC requestAdditionalItemUC = new RequestAdditionalItemUC();
            panel1.Controls.Add(requestAdditionalItemUC);   
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            CheckOutUC checkOut = new CheckOutUC();
            panel1.Controls.Add(checkOut);
        }

        private void FrontOffice_Load(object sender, EventArgs e)
        {

        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            MasterRoomUC masterRoomUC = new MasterRoomUC();
            panel1.Controls.Add(masterRoomUC);  
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            MasterItemUC item = new MasterItemUC();
            panel1.Controls.Add(item);
        }
    }
}
