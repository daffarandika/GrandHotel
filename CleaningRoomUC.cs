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
            Helper.fillDataGridView("select room.roomnumber, cleaningroomdetail.id, startdatetime, finishdatetime, note, statuscleaning, ItemID, Qty, Status from CleaningRoomDetail inner join Room on RoomID = Room.id inner join CleaningRoom on CleaningRoomID = CleaningRoom.ID inner join CleaningRoomItem on CleaningRoomDetailID = CleaningRoomDetail.ID where employeeid = 71", dgvSchedule, new string[] { "id" });
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
            worksheet.Range["B2"].Value2 = Helper.employeeName;
            workbook.SaveAs( Filename : Helper.employeeName + "_" + DateTime.Now.ToString("ddMMyyyy"));
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel file (*.xlsx; *.xls) | *.xlsx; *.xls";
            
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string connPath = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ofd.FileName + ";Extended Properties = \"Excel 12.0 Xml;HDR=YES\"; ";
                OleDbConnection conn = new OleDbConnection(connPath);
                OleDbDataAdapter oda = new OleDbDataAdapter("Select * from [Sheet1$B5:ZZ]", conn);
                System.Data.DataTable dt = new System.Data.DataTable();
                oda.Fill(dt);
                dgvScheduleDetail.DataSource = dt;
            }
        }
    }
}
