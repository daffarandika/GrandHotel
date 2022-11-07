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
    public partial class ReservationUC : UserControl
    {
        int totalRoomPrice = 0;
        int totalItemPrice = 0;
        int finalPrice = 0;
        EventArgs eLoad { get; set; }
        object eSender { get; set; }  
        DataTable dtItem = new DataTable();
        Panel searchUser = new Panel();
        Panel addUser = new Panel();
        DataGridView dgvCustomer = new DataGridView();
        TextBox txtCustomerName = new TextBox();
        TextBox txtCustomerPhone = new TextBox();
        Label lblCustomerName = new Label();
        Label lblCustomerPhone = new Label();
        HashSet<string> addedItem = new HashSet<string>();
        public ReservationUC()
        {
            InitializeComponent();
        }
        
        private void ReservationUC_Load(object sender, EventArgs e)
        {
            eLoad = e;
            eSender = sender;
            DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
            check.Name = "Choose";
            dgvCustomer.Columns.Add(check);
            fillRoomTypeCmb();
            cmbRoomType.SelectedIndex = -1;
            fillRoomDGV();
            fillSelectedRoomDgv();
            fillCmbItem();
            radioSearch.Select();
            fillItemDGV();
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "Remove";
            btn.Text = "Remove";
            btn.UseColumnTextForButtonValue = true;
            dgvItem.Columns.Add(btn);
            dgvCustomer.CellContentClick -= dgvCustomerCellClick;
            dgvCustomer.CellContentClick += dgvCustomerCellClick;


        }

        private void dgvCustomerCellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                foreach (DataGridViewRow row in dgvCustomer.Rows)
                {
                    if (row.Index != e.RowIndex)
                    {
                        row.Cells[0].Value = false;
                    }
                }
            }
        }

        private void fillCmbItem()
        {
            Helper.fillComboBox("select * from item", cmbItem, "id", "name");
        }

        void fillSearchCustomerPanel()
        {
            searchUser.Controls.Clear();
            addUser.Controls.Clear();
            panel1.Controls.Clear();
            searchUser.Size = new Size(378, 163);
            dgvCustomer.Size = new Size(378, 163);
            searchUser.Controls.Add(dgvCustomer);
            dgvCustomer.AllowUserToAddRows = false;
            panel1.Controls.Add(searchUser);
            fillCustomerDGV();
        }

        private void fillCustomerDGV()
        {
            Helper.fillDataGridView("select * from Customer where name like '%" + Helper.SearchCustomer.customerName + "%'", dgvCustomer, new string[3] { "id", "nik", "email" });
        }

        void fillAddCustomerPanel()
        {
            addUser.Controls.Clear();
            searchUser.Controls.Clear();
            panel1.Controls.Clear();
            searchUser.Size = new Size(378, 163);
            txtCustomerName.Size = new Size(190, 20);
            txtCustomerPhone.Size = new Size(190, 20);
            lblCustomerName.Location = new Point(60, 28);
            txtCustomerName.Location = new Point(150, 28);
            lblCustomerName.Text = "Name";
            lblCustomerPhone.Location = new Point(60, 68);
            txtCustomerPhone.Location = new Point(150, 68);
            lblCustomerPhone.Text = "Phone";
            searchUser.Controls.Add(txtCustomerName);
            searchUser.Controls.Add(txtCustomerPhone);
            searchUser.Controls.Add(lblCustomerPhone);
            searchUser.Controls.Add(lblCustomerName);
            panel1.Controls.Add(searchUser);
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
            if (cmbRoomType.SelectedIndex == -1)
            {
                Helper.fillDataGridView("select * from room ", dgvRooms, new string[] { "id", "roomtypeid" });
            } else
            {
                string roomTypeID = cmbRoomType.SelectedValue.ToString();
                Helper.fillDataGridView("select * from room where roomtypeid = '" + roomTypeID + "'", dgvRooms, new string[] { "id", "roomtypeid" });
            }

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

        private void btnGTGT_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = (DataGridViewRow)dgvRooms.CurrentRow.Clone();
            for (int i = 0; i<dgvRooms.CurrentRow.Cells.Count; i++)
            {
                row.Cells[i].Value = dgvRooms.CurrentRow.Cells[i].Value;
            }
            dgvSelectedRoom.Rows.Add(row);
            string roomprice = Helper.getRow("select roomprice from roomtype where id = '" + dgvRooms.CurrentRow.Cells["roomtypeid"].Value.ToString() + "'", "roomprice");
            totalRoomPrice += Convert.ToInt32(roomprice);
            finalPrice += totalRoomPrice;
            lblTotal.Text = finalPrice.ToString();
        }


        private void btnLTLT_Click(object sender, EventArgs e)
        {
            string roomprice = Helper.getRow("select roomprice from roomtype where id = '" + dgvSelectedRoom.CurrentRow.Cells["roomtypeid"].Value.ToString() + "'", "roomprice");
            totalRoomPrice -= Convert.ToInt32(roomprice);
            dgvSelectedRoom.Rows.Remove(dgvSelectedRoom.CurrentRow);
            finalPrice -= Convert.ToInt32(roomprice);
            lblTotal.Text = finalPrice.ToString();
        }

        private void radioSearch_CheckedChanged(object sender, EventArgs e)
        {
            if (radioAdd.Checked)
            {
                fillAddCustomerPanel();
                txtSearch.Visible = false;
                lblSearch.Visible = false;
                return;
            }
            if (radioSearch.Checked)
            {
                fillSearchCustomerPanel();
                txtSearch.Visible = true;
                lblSearch.Visible = true;
                return;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Helper.SearchCustomer.customerName = txtSearch.Text;
            fillCustomerDGV();
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
            } else
            {
                addedItem.Add(itemName);
                            dtItem.Rows.Add(itemID, itemName, qty, total.ToString());
            }
            foreach (DataGridViewRow row in dgvItem.Rows)
            {
                totalItemPrice += Convert.ToInt32(row.Cells["total"].Value);
            }
            finalPrice += totalItemPrice;
            lblTotal.Text = totalItemPrice.ToString();
        }

        private void dgvItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.ColumnIndex.ToString());
            if (e.ColumnIndex == 0)
            {
                addedItem.Remove(dgvItem.Rows[e.RowIndex].Cells["item"].Value.ToString());
                dgvItem.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void cmbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbRoomType_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSeachRoom_Click(object sender, EventArgs e)
        {
            fillRoomDGV();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            // make reservation record
            // then make reservationRoom and reservationRequestItem record
            // then link them together using the newly made reservation record's id
            string datetime = DateTime.Now.ToString(Variables.dateTimeFormat);
            string code = Helper.generateCode(6);
            string employeeID = Variables.employeeID;
            string customerID = "";
            //if customer already exits in the database then insert using the check-marked row in dgvCustomer
            if (radioSearch.Checked)
            {
                foreach (DataGridViewRow row in dgvCustomer.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["choose"].Value))
                    {
                        customerID = row.Cells["id"].Value.ToString();
                        break;
                    }
                }
            }
            else
            {
                //if customer doesn't exits in database yet, then insert new customer to customer table then get their id using the max function in sql
                Helper.runQuery("insert into customer (name, phonenumber) values ('" + txtCustomerName.Text + "', '" + txtCustomerPhone.Text + "')");
                customerID = Helper.getRow("select max(id) as max from customer ", "max");
            }
            Helper.runQuery("insert into reservation (datetime, employeeid, customerid, code) " +
                "values ('" + datetime + "', '" + employeeID + "', '" + customerID + "', '" + code + "')");
            string reservationID = Helper.getRow("select max(id) as max from reservation", "max"); // the newly made reservation record's id
            // create new reservationRoom record(s)
            foreach (DataGridViewRow row in dgvSelectedRoom.Rows)
            {
                string roomID = row.Cells["id"].Value.ToString();
                string startDateTime = dtpStart.Value.ToString(Variables.dateFormat);
                string durationNights = txtNights.Text;
                string roomPrice = Helper.getRow("select roomprice from roomtype where id = '" + row.Cells["roomtypeid"].Value.ToString() + "'", "roomprice");
                string checkInDate = Variables.unintializedDate;
                string checkOutDate = checkInDate;
                Helper.runQuery("insert into reservationRoom (reservationid, roomid, startdatetime, durationnights, roomprice, checkindatetime, checkoutdatetime) " +
                "values ('" + reservationID + "', '" + roomID + "', '" + startDateTime + "', '" + durationNights + "', '" + roomPrice + "', '" + checkInDate + "', '" + checkOutDate + "')");
            }
            
            // create new reservationRequestItem record(s)
            if (dgvItem.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvItem.Rows)
                {
                    //
                    string reservationRoomID = Helper.getRow("select max(id) as max from reservationRoom", "max");
                    string itemID = row.Cells["itemid"].Value.ToString();
                    string qty = row.Cells["qty"].Value.ToString();
                    string totalPrice = row.Cells["total"].Value.ToString();
                    Helper.runQuery("insert into reservationRequestItem (reservationRoomID, itemID, qty, totalPrice) " +
                    "values ('" + reservationRoomID + "', '" + itemID + "', '" + qty + "', '" + totalPrice + "')");
                }
            }
            MessageBox.Show(code);
            Controls.Clear();
            InitializeComponent();
            ReservationUC_Load(eSender, eLoad);
        }
    }          
}
