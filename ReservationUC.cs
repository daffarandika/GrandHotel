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
    public partial class ReservationUC : UserControl
    {
        public ReservationUC()
        {
            InitializeComponent();
        }

        private void ReservationUC_Load(object sender, EventArgs e)
        {
            fillRoomTypeCmb();
            fillRoomDGV();
            fillSelectedRoomDgv();
        }
        void fillRoomTypeCmb()
        {
            Helper.fillComboBox("select * from roomtype", cmbRoomType, "id", "name");
        }
        void fillSelectedRoomDgv()
        {
            foreach (DataGridViewColumn column in dgvRooms.Columns)
            {
                dgvSelectedRoom.Columns.Add(column.Clone() as DataGridViewColumn);
            }
        }
        void fillRoomDGV()
        {
            Helper.fillDataGridView("select * from room", dgvRooms, new string[] { "id", "roomtypeid" });
        }

        private void btnGTGT_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = (DataGridViewRow)dgvRooms.CurrentRow.Clone();
            int colIndex = 0;
            for (int i = 0; i<dgvRooms.CurrentRow.Cells.Count; i++)
            {
                row.Cells[i].Value = dgvRooms.CurrentRow.Cells[i].Value;
            }
            dgvSelectedRoom.Rows.Add(row);
        }
    }
}
