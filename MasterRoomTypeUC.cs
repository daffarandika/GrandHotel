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
    public partial class MasterRoomTypeUC : UserControl
    {
        bool insertModeEnabled = false;
        bool updateModeEnabled = false;
        bool deleteModeEnabled = false;
        Control[] inputComponents;
        Button[] crudButtons;
        Button[] operationButtons;
        public MasterRoomTypeUC()
        {
            InitializeComponent();
            inputComponents = new Control[]
            {
                txtName, txtCapacity, txtPrice
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
            fillRoomTypeDGV();
            disableInputComponents();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (insertModeEnabled)
            {
                insertAction();
                return;
            }
            if (updateModeEnabled)
            {
                updateAction();
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
            string name = txtName.Text;
            string capacity = txtCapacity.Text;
            string price = txtPrice.Text;
            string id = dgvRoomType.CurrentRow.Cells["id"].Value.ToString();
            string command = "update roomtype set name = '" + name + "', capacity = '" + capacity + "', roomprice = '" + price + "' where id = '" + id + "'";
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
            string name = txtName.Text;
            string capacity = txtCapacity.Text;
            string price = txtPrice.Text;
            string command = "insert into roomtype (name, capacity, roomprice) values ('" + name + "', '" + capacity + "', '" + price + "')";
            Helper.runQuery(command);
            fillRoomTypeDGV();
            Helper.clearText(inputComponents);
        }

        private void fillRoomTypeDGV()
        {
            Helper.fillDataGridView("select * from roomtype", dgvRoomType, new string[] { "id" });
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
            txtName.Text = dgvRoomType.CurrentRow.Cells["name"].Value.ToString();
            txtCapacity.Text = dgvRoomType.CurrentRow.Cells["capacity"].Value.ToString();
            txtPrice.Text = dgvRoomType.CurrentRow.Cells["roomprice"].Value.ToString();

        }

        private void dgvRoomType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
