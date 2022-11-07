using System;
using System.Data.OleDb;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using System.Data.SqlClient;

namespace GrandHotel
{
    public partial class CleaningRoomUC : UserControl
    {
        public CleaningRoomUC()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CleaningRoomUC_Load(object sender, EventArgs e)
        {
            fillDGVSchedule();
        }

        private void fillDGVSchedule()
        {
            Helper.fillDataGridView("select cleaningroomdetail.id as ID, room.roomnumber, startdatetime, finishdatetime, note, statuscleaning from CleaningRoomDetail inner join Room on RoomID = Room.id inner join CleaningRoom on CleaningRoomID = CleaningRoom.ID inner join CleaningRoomItem on CleaningRoomDetailID = CleaningRoomDetail.ID inner join Item on itemid = item.id where employeeid = 71", dgvSchedule, new string[] {  });
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // add reference to microsoft excel from Project > add reference > com > Microsoft Excel
            // copy everything in the datagrid view
            dgvSchedule.SelectAll();
            DataObject dataObj = dgvSchedule.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
            dgvSchedule.ClearSelection();
            // make instance of excel, workbook, then worksheet
            Microsoft.Office.Interop.Excel.Application excel;
            Workbook workbook;
            Worksheet worksheet;
            // can i think of this step as making a new abstract object similiar to null?? idfk, will revise later
            object misValue = System.Reflection.Missing.Value;
            excel = new Microsoft.Office.Interop.Excel.Application // open the excel app
            {
                Visible = true
            };
            workbook = excel.Workbooks.Add(misValue);
            worksheet = workbook.Worksheets.get_Item(1);
            Range range = worksheet.Cells[5, 1];
            range.Select();
            worksheet.PasteSpecial(range, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);  
            // adding text manually
            worksheet.Range["A1"].Value = "Date";
            worksheet.Range["A1"].Font.Bold = true;
            worksheet.Range["B1"].Value2 = DateTime.Now.ToString("dd-M-yyyy");

            worksheet.Range["A2"].Value2 = "Employee";
            worksheet.Range["A2"].Font.Bold = true;
            worksheet.Range["B2"].Value2 = Variables.employeeName;
            workbook.SaveAs( Filename : Variables.employeeName + "_" + DateTime.Now.ToString("ddMMyyyy"));
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel file (*.xlsx; *.xls) | *.xlsx; *.xls";
            
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string connPath = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ofd.FileName + ";Extended Properties = \"Excel 12.0 Xml;HDR=YES\"; ";
                    OleDbConnection conn = new OleDbConnection(connPath);
                    OleDbDataAdapter oda = new OleDbDataAdapter("Select [id] from [Sheet1$B5:ZZ]", conn);
                    DataTable dt = new DataTable();
                    oda.Fill(dt);
                    string cleaningRoomID = "";
                    DataTable dt2 = new DataTable();
                
                    dt2.Columns.Add("item");
                    dt2.Columns.Add("qty");
                    dt2.Columns.Add("status");
                    foreach (DataRow row in dt.Rows)
                    {
                        cleaningRoomID = row["id"].ToString();
                        Helper.conn.Open();
                        SqlCommand cmd = new SqlCommand("select CleaningRoomDetail.ID, Item.Name as Item, Qty, status from CleaningRoomDetail inner join CleaningRoomItem on CleaningRoomDetailID = CleaningRoomDetail.ID inner join Item on ItemID = item.ID where cleaningroomdetail.id = '" + cleaningRoomID + "'", Helper.conn);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            dt2.Rows.Add(reader["item"], reader["qty"], reader["status"]);
                        }
                        Helper.conn.Close();
                    }

                    dgvScheduleDetail.DataSource = dt2;
                } catch 
                {
                    MessageBox.Show("The excel that you submitted was not in the correct format", "Incorrect Excel Format", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }

            }
        }
    }
}
