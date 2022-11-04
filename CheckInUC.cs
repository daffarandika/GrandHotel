using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrandHotel
{
    public partial class CheckInUC : UserControl
    {
        string reservationID = "";
        bool customerExists = false;
        string customerID = "";
        public CheckInUC()
        {
            InitializeComponent();
        }
        void fillReservationDGV(string code)
        {
            dgvReservation.Columns.Clear();
            DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn
            {
                Name = "Check in"
            };
            foreach (DataGridViewColumn column in dgvReservation.Columns)
            {
                if (column is DataGridViewCheckBoxColumn)
                {
                    dgvReservation.Columns.Remove(column);
                    break;
                }
            }
            dgvReservation.Columns.Add(check);

            if (code == "")
            {
                Helper.fillDataGridView("select ReservationRoom.id, RoomNumber, RoomFloor, RoomType.Name as RoomType, StartDateTime, DurationNights from ReservationRoom  inner join Reservation on ReservationRoom.ReservationID = Reservation.ID inner join Room on RoomID = Room.ID inner join RoomType on RoomTypeID = RoomType.ID where room.id = 0"
                , dgvReservation, new string[0]);
                dgvReservation.Columns["id"].Visible = false;
                return;
            }
            
            Helper.fillDataGridView("select ReservationRoom.id, RoomNumber, RoomFloor, RoomType.Name as RoomType, StartDateTime, DurationNights from ReservationRoom  inner join Reservation on ReservationRoom.ReservationID = Reservation.ID inner join Room on RoomID = Room.ID inner join RoomType on RoomTypeID = RoomType.ID where code = '" + code + "' and checkindatetime = '" + Variables.unintializedDate + "'"
                , dgvReservation, new string[0]);
            dgvReservation.Columns["id"].Visible = false;
        }
        private void CheckInUC_Load(object sender, EventArgs e)
        {
            fillReservationDGV("");
        }

        private void btnSeach_Click(object sender, EventArgs e)
        {
            string code = txtBookingCode.Text;
            if (!Helper.hasRows("select ReservationRoom.id, RoomNumber, RoomFloor, RoomType.Name as RoomType, StartDateTime, DurationNights from ReservationRoom  inner join Reservation on ReservationRoom.ReservationID = Reservation.ID inner join Room on RoomID = Room.ID inner join RoomType on RoomTypeID = RoomType.ID where code = '" + code + "'"))
            {
                MessageBox.Show("Please recheck the code", "Check in code not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else if (!Helper.hasRows("select ReservationRoom.id, RoomNumber, RoomFloor, RoomType.Name as RoomType, StartDateTime, DurationNights from ReservationRoom  inner join Reservation on ReservationRoom.ReservationID = Reservation.ID inner join Room on RoomID = Room.ID inner join RoomType on RoomTypeID = RoomType.ID where checkindatetime = '"+Variables.unintializedDate+"' and code = '"+code+"'"))
            {
                MessageBox.Show("Every room with this reservation code has been booked in", "Please recheck the code", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                fillReservationDGV(code);
            }

        }

        private void txtPhoneNumber_Leave(object sender, EventArgs e)
        {
            string searchQuery = "select * from customer where phonenumber = '" + txtPhoneNumber.Text + "'";
            if (Helper.hasRows(searchQuery))
            {
                customerExists = true;
                customerID = Helper.getRow(searchQuery, "id");
            }
            if (customerExists)
            {
                txtName.Text = Helper.getRow(searchQuery, "name");
                txtNIK.Text = Helper.getRow(searchQuery, "nik");
                txtEmail.Text = Helper.getRow(searchQuery, "email");
                txtAge.Text = Helper.getRow(searchQuery, "age");
                if (Helper.getRow(searchQuery, "gender") == "M")
                {
                    radioMale.Checked = true;
                    return;
                }
                radioFemale.Checked = true;
                return;
            }
            customerExists = false;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            Helper.runQuery("update customer set name = '" + txtName.Text + "' where id = '" + customerID + "'");
        }

        private void txtNIK_TextChanged(object sender, EventArgs e)
        {
            Helper.runQuery("update customer set nik = '" + txtNIK.Text + "' where id = '" + customerID + "'");
        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {
            Helper.runQuery("update customer set age = '" + txtAge.Text + "' where id = '" + customerID + "'");
        }

        private void radioMale_CheckedChanged(object sender, EventArgs e)
        {
            if (radioMale.Checked)
            {
                Helper.runQuery("update customer set gender = '" + "M" + "' where id = '" + customerID + "'");
                return;
            }
            Helper.runQuery("update customer set gender = '" + "F" + "' where id = '" + customerID + "'");

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            Helper.runQuery("update customer set email = '" + txtEmail.Text + "' where id = '" + customerID + "'");
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            reservationID = Helper.getRow("select reservationid from ReservationRoom inner join Reservation on ReservationRoom.ReservationID = Reservation.ID where code = '" + txtBookingCode.Text + "' ", "reservationid");
            if (!customerExists)
            {
                string name = txtName.Text;
                string phonenumber = txtPhoneNumber.Text;
                string email = txtEmail.Text;
                string age = txtAge.Text;
                string nik = txtNIK.Text;
                string gender = "F";
                if (radioMale.Checked)
                {
                    gender = "m";
                }
                Helper.runQuery("insert into customer (name, email, nik, phonenumber, gender, age)" +
                    "values ('" + name + "', '" + email + "', '" + nik + "', '" + gender + "', '" + phonenumber + "','" + age + "')");
            }
            string checkInDateTime = DateTime.Now.ToString(Variables.dateTimeFormat);
            foreach (DataGridViewRow row in dgvReservation.Rows)
            {
                if ((bool)row.Cells["check in"].Value)
                {
                    Helper.runQuery("update reservationroom set checkInDateTime = '" + checkInDateTime + "' where id = '" + row.Cells["id"].Value.ToString() +"'");
                    fillReservationDGV(txtBookingCode.Text);
                }
            }
            //Helper.runQuery("update reservationroom set checkInDate = '"+checkInDateTime+"' where ");
        }
    }
}
