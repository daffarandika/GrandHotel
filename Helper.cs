using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrandHotel
{
    internal class Helper
    {
        public static SqlConnection conn = new SqlConnection("Data Source=DESKTOP-GHNE639;Initial Catalog=GrandHotel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public static string toSha256(string input)
        {
            SHA256 sha256 = SHA256.Create();
            StringBuilder sb = new StringBuilder();
            byte[] res = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte b in res)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        public static void runQuery(string command)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(command, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static bool hasRows(string command)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(command, conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            if (sdr.HasRows)
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }
        public static string getRow(string command, string value)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(command, conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            string row = sdr[value].ToString();
            conn.Close();
            return row;
        }
        public static void fillComboBox(string command, ComboBox cmb, string valueMember, string displayMember)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(command, conn);
            DataTable dt = new DataTable();
            dt.Columns.Add(valueMember);
            dt.Columns.Add(displayMember);
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Rows.Clear();
            while (sdr.Read())
            {
                dt.Rows.Add(sdr[valueMember], sdr[displayMember]);
            }
            cmb.DataSource = dt;
            cmb.DisplayMember = displayMember;
            cmb.ValueMember = valueMember;
            conn.Close();
        }
        public static void fillDataGridView (string command, DataGridView dgv, string[] hiddenColumns)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(command, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgv.DataSource = dt;
            for (int i = 0; i < hiddenColumns.Length; i++)
            {
                dgv.Columns[hiddenColumns[i]].Visible = false;
            }
            conn.Close();
        }
        public static void enableComponents(Control[] controls)
        {
            foreach (Control con in controls)
            {
                con.Enabled = true;
            }
        }
        public static void disableComponents(Control[] controls)
        {
            foreach (Control con in controls)
            {
                con.Enabled = false;
            }
        }
        public static void clearText(Control[] controls)
        {
            foreach (Control control in controls)
            {
                control.Text = "";
            }
        }
        public static void showErrors(Control[] controls, string message)
        {
            ErrorProvider ep = new ErrorProvider();
            foreach (Control c in controls)
            {
                ep.SetError(c, message);
            }
        }
        public static bool isTextEmpty(Control[] controls)
        {
            bool isTextEmpty = false;
            foreach (Control control in controls)
            {
                if(control.Text == "")
                {
                    showErrors(new Control[1] {control}, "input cannot be empty");
                    isTextEmpty = true;
                }
            }
            return isTextEmpty;
        }
    }
}
