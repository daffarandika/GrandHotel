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
    public partial class RequestAdditionalItemUC : UserControl
    {
        private void RequestAdditionalItemUC_Load(object sender, EventArgs e)
        {
            fillCmbRoomNumber();
            fillCmbItem();
            fillItemDGV();
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "Remove";
            btn.Text = "Remove";
            btn.UseColumnTextForButtonValue = true;
            dgvItem.Columns.Add(btn);
        }
        DataTable dtItem = new DataTable();
        List<string> addedItem = new List<string>();
        int totalItemPrice = 0;
        void fillCmbRoomNumber()
        {
            Helper.fillComboBox("select  * from ReservationRoom inner join Room on RoomId = Room.ID where CheckOutDateTime = '" + Variables.unintializedDate + "' order by RoomNumber asc", cmbRoomNumber, "ID", "roomnumber");
        }

        public RequestAdditionalItemUC()
        {
            InitializeComponent();
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
        void fillCmbItem()
        {
            Helper.fillComboBox("select * from item", cmbItem, "id", "name");
        }
        void fillItemDGV()
        {
            dtItem.Columns.Clear();
            dtItem.Columns.Add("ItemID");
            dtItem.Columns.Add("Item");
            dtItem.Columns.Add("Qty");
            dtItem.Columns.Add("Total");
            dgvItem.DataSource = dtItem;
            dgvItem.Columns["ItemID"].Visible = false;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dgvItem.Rows)
            {
                string reservationRoomID = cmbRoomNumber.SelectedValue.ToString();
                string itemID = dr.Cells["ItemID"].Value.ToString();
                string qty = dr.Cells["qty"].Value.ToString();
                string totalPrice = dr.Cells["total"].Value.ToString();
                Helper.runQuery("insert into reservationRequestItem (reservationRoomID, itemID, qty, totalPrice) values ('" + reservationRoomID + "', '" + itemID + "', '" + qty + "', '" + totalPrice + "')");
            }
            MessageBox.Show("success");
        }
    }
}
