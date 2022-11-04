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
    public partial class MasterRoomUC : UserControl
    {
        bool insertModeEnabled = false;
        bool updateModeEnabled = false;
        bool deleteModeEnabled = false;
        Control[] inputComponents;
        Button[] crudButtons;
        Button[] operationButtons;
        public MasterRoomUC()
        {
            InitializeComponent();
            inputComponents = new Control[]
            {
                txtRoomNumber, txtDesc, txtRoomFloor, cmbRoomType
            };
            crudButtons = new Button[]
            {
                btnInsert, btnUpdate, btnDelete
            };
            operationButtons = new Button[]
            {
                btnCancel, btnSave
            };
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtCPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void MasterRoomTypeUC_Load(object sender, EventArgs e)
        {
            fillRoomTypeCMB();
            fillRoomTypeDGV();
            disableInputComponents();
        }

        private void fillRoomTypeCMB()
        {
            Helper.fillComboBox("select * from roomtype", cmbRoomType, "id", "name");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (insertModeEnabled)
            {
                insertAction();
                cmbRoomType.SelectedIndex = -1;
                return;
            }
            if (updateModeEnabled)
            {
                updateAction();
                cmbRoomType.SelectedIndex = -1;
                return;
            }
            if (deleteModeEnabled)
            {
                deleteAction();
                return;
            }
        }

        private void deleteAction()
        {
            string id = dgvRoomType.CurrentRow.Cells["id"].Value.ToString();
            Helper.runQuery("delete from roomtype where id = '" + id + "'");
            Helper.clearText(inputComponents);
            fillRoomTypeDGV();
        }

        private void updateAction()
        {
            if (Helper.isTextEmpty(inputComponents))
            {
                return;
            }
            string roomNumber = txtRoomNumber.Text;
            string roomTypeID = cmbRoomType.SelectedValue.ToString();
            string roomFloor = txtRoomFloor.Text;
            string desc = txtDesc.Text;
            string id = dgvRoomType.CurrentRow.Cells["id"].Value.ToString();
            string command = "update room set roomNumber = '" + roomNumber + "', roomTypeID = '" + roomTypeID + "', roomFloor = '" + roomFloor + "', description = '" + desc + "' where id = '" + id + "'";
            Helper.runQuery(command);
            fillRoomTypeDGV();
            Helper.clearText(inputComponents);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            enableOperationButtons();
            enableInputComponents();
            disableCrudButtons();
            updateModeEnabled = true;
            insertModeEnabled = false;
            deleteModeEnabled = false;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            enableOperationButtons();
            enableInputComponents();
            disableCrudButtons();
            insertModeEnabled = true;
            updateModeEnabled = false;
            deleteModeEnabled = false;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            enableOperationButtons();
            enableInputComponents();
            disableCrudButtons();
            deleteModeEnabled = true;
            insertModeEnabled = false;
            updateModeEnabled = false;
        }
        void enableInputComponents()
        {
            Helper.enableComponents(inputComponents);
        }
        void disableInputComponents()
        {
            Helper.disableComponents(inputComponents);
        }
        void enableCrudButtons()
        {
            Helper.enableComponents(crudButtons);
        }

        void disableCrudButtons()
        {
            Helper.disableComponents(crudButtons);
        }
        void enableOperationButtons()
        {
            Helper.enableComponents(operationButtons);
        }

        void disableOperationButtons()
        {
            Helper.disableComponents(operationButtons);
        }
        void insertAction()
        {
            if (Helper.isTextEmpty(inputComponents))
            {
                return;
            }
            string roomNumber = txtRoomNumber.Text;
            string roomTypeID = cmbRoomType.SelectedValue.ToString();
            string roomFloor= txtRoomFloor.Text;
            string desc = txtDesc.Text;
            string command = "insert into room (roomnumber, roomtypeid, roomfloor, description) values ('" + roomNumber + "', '" + roomTypeID + "', '" + roomFloor + "', '" + desc + "')";
            Helper.runQuery(command);
            fillRoomTypeDGV();
            Helper.clearText(inputComponents);
        }

        private void fillRoomTypeDGV()
        {
            Helper.fillDataGridView("select room.id, roomnumber, roomtype.name as roomtype, roomtypeid, roomfloor, description from Room inner join RoomType on Room.RoomTypeID = RoomType.ID", dgvRoomType, new string[] {"roomtypeid", "id"});
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            disableInputComponents();
            enableCrudButtons();
            disableOperationButtons();
            Helper.clearText(inputComponents);
        }

        private void dgvRoomType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtRoomNumber.Text = dgvRoomType.CurrentRow.Cells["roomnumber"].Value.ToString();
            txtRoomFloor.Text = dgvRoomType.CurrentRow.Cells["roomfloor"].Value.ToString();
            txtDesc.Text = dgvRoomType.CurrentRow.Cells["description"].Value.ToString();
            cmbRoomType.SelectedValue = dgvRoomType.CurrentRow.Cells["roomtypeid"].Value.ToString();
        }

        private void dgvRoomType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
