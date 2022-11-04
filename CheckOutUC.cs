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
    public partial class CheckOutUC : UserControl
    {
        DataTable dtItem = new DataTable();
        List<string> addedItem = new List<string>();
        int totalItemPrice = 0;
        public CheckOutUC()
        {
            InitializeComponent();
        }

        private void CheckOutUC_Load(object sender, EventArgs e)
        {
            fillItemStatusCmb();
            fillCmbRoomNumber();
            fillCmbItem();
            fillDGVItem();
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "Remove";
            btn.Text = "Remove";
            btn.UseColumnTextForButtonValue = true;
            dgvItem.Columns.Add(btn);
        }
        void fillDGVItem()
        {
            dtItem.Columns.Clear();
            dtItem.Columns.Add("ItemID");
            dtItem.Columns.Add("Item");
            dtItem.Columns.Add("Qty");
            dtItem.Columns.Add("Total");
            dgvItem.DataSource = dtItem;
            dgvItem.Columns["ItemID"].Visible = false;
        }
        void fillCmbItem()
        {
            Helper.fillComboBox("select * from item", cmbItem, "id", "name");
        }
        void fillItemStatusCmb()
        {
            Helper.fillComboBox("select * from itemstatus", cmbItemStatus, "id", "name");
        }
        void fillCmbRoomNumber()
        {
            Helper.fillComboBox("select  * from ReservationRoom inner join Room on RoomId = Room.ID where CheckOutDateTime = '" + Variables.unintializedDate + "' order by RoomNumber asc", cmbRoomNumber, "ID", "roomnumber");
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            totalItemPrice = 0;
            string itemName = cmbItem.Text.ToString();
            string itemID = cmbItem.SelectedValue.ToString();
            string qty = txtQty.Value.ToString();
            string price = Helper.getRow("select * from item where name = '" + itemName + "'", "requestprice");

            int total = Convert.ToInt32(qty) * Convert.ToInt32(price);
            if (addedItem.Contains(itemName))
            {
                foreach (DataGridViewRow row in dgvItem.Rows)
                {
                    if (row.Cells["item"].Value.ToString() == itemName)
                    {
                        row.Cells["qty"].Value = Convert.ToInt32(row.Cells["qty"].Value) + Convert.ToInt32(qty);
                        row.Cells["total"].Value = Convert.ToInt32(row.Cells["qty"].Value) * Convert.ToInt32(price);
                        break;
                    }
                }
            }
            else
            {
                addedItem.Add(itemName);
                dtItem.Rows.Add(itemID, itemName, qty, total.ToString());
            }
            foreach (DataGridViewRow row in dgvItem.Rows)
            {
                totalItemPrice += Convert.ToInt32(row.Cells["total"].Value);
            }
            lblTotal.Text = totalItemPrice.ToString();
        }

        private void dgvItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                addedItem.Remove(dgvItem.Rows[e.RowIndex].Cells["item"].Value.ToString());
                dgvItem.Rows.RemoveAt(e.RowIndex);
            }
 
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string reservationRoomID = cmbRoomNumber.SelectedValue.ToString();
            string checkOutDate = DateTime.Now.ToString();
            foreach (DataGridViewRow row in dgvItem.Rows)
            {
                string itemStatusID = cmbItemStatus.SelectedValue.ToString();
                string itemID = row.Cells["itemid"].Value.ToString();
                string qty = row.Cells["qty"].Value.ToString();
                string totalCharge = row.Cells["total"].Value.ToString();
                Helper.runQuery("insert into reservationcheckout (reservationroomid, itemstatusid, itemid, qty, totalcharge) " +
                    "values ('"+reservationRoomID+"', '"+itemStatusID+"', '"+itemID+"', '"+qty+"', '"+totalCharge+"')");
                
            }
            MessageBox.Show("done");
            Helper.runQuery("update reservationroom set checkoutdatetime = '" + checkOutDate + "' where id = '" + reservationRoomID + "'");
        }
    }
}
