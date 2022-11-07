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
    public partial class AddHouseKeepingScheduleUC : UserControl
    {
        DataTable dt = new DataTable();
        string employeeID = "";
        string roomID = "";
        string date = "";
        public AddHouseKeepingScheduleUC()
        {
            InitializeComponent();
        }

        private void AddHouseKeepingScheduleUC_Load(object sender, EventArgs e)
        {
            fillHousekeeperCMB();
            // select Date, Employee.Name as Employee, roomnumber from CleaningRoomDetail inner join CleaningRoom on CleaningRoomID = cleaningroom.ID inner join room on roomid = room.id inner join Employee on EmployeeID = Employee.id
            fillRoomNumberCMB();
            cmbHouseKeeper.SelectedIndex = -1;
            cmbRoomNumber.SelectedIndex = -1;
        }

        private void fillScheduleDGV()
        {
            dgvSchedule.Columns.Clear();
            Helper.fillDataGridView("select cleaningroomid, employeeid, roomid, Date, Employee.Name as Employee, roomnumber from CleaningRoomDetail " +
                "inner join CleaningRoom on CleaningRoomID = cleaningroom.ID " +
                "inner join room on roomid = room.id inner join Employee on EmployeeID = Employee.id " +
                "where employeeid = '" + employeeID + "' and roomid = '" + roomID + "' and date = '" + dtp.Value.ToString(Variables.dateFormat) + "'"
                , dgvSchedule, new string[] { "employeeid", "roomid", "cleaningroomid" });
            DataGridViewButtonColumn dataGridViewButtonColumn = new DataGridViewButtonColumn();
            dataGridViewButtonColumn.Text = "Remove";
            dataGridViewButtonColumn.Name = "Remove";
            dataGridViewButtonColumn.UseColumnTextForButtonValue = true;
            dgvSchedule.Columns.Add(dataGridViewButtonColumn);
        }

        private void fillHousekeeperCMB()
        {
            Helper.fillComboBox("select * from employee where jobid = 3 order by name", cmbHouseKeeper, "id", "name");
        }

        private void fillRoomNumberCMB()
        {
            Helper.fillComboBox("select * from room", cmbRoomNumber, "id", "roomnumber");
        }

        private void cmbRoomNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            roomID = cmbRoomNumber.SelectedValue.ToString();
            fillScheduleDGV();
        }

        private void cmbHouseKeeper_SelectedIndexChanged(object sender, EventArgs e)
        {
            employeeID = cmbHouseKeeper.SelectedValue.ToString();
            fillScheduleDGV();
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            date = dtp.Value.ToString(Variables.dateFormat);
            fillScheduleDGV();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            Helper.runQuery("insert into cleaningroom (date, employeeid) values ('" + dtp.Value.ToString(Variables.dateFormat) + "', '" + employeeID + "')");
            string cleaningRoomID = Helper.getRow("select max(id) as max from cleaningroom", "max");
            Helper.runQuery("insert into cleaningroomdetail (cleaningroomid, roomid, startdatetime, finishdatetime, note, statuscleaning) " +
                "values ('" + cleaningRoomID + "', '" + roomID + "', '" + Variables.unintializedDate + "', '" + Variables.unintializedDate + "', ' ', ' ' )");
            fillScheduleDGV();
        }

        private void dgvSchedule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                string cleaningroomid = dgvSchedule.Rows[e.RowIndex].Cells["cleaningroomid"].Value.ToString();
                Helper.runQuery("delete from cleaningroom where id = '"+ cleaningroomid + "'");
                fillScheduleDGV();
            }

        }
    }
}
