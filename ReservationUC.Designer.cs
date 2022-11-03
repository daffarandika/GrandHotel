namespace GrandHotel
{
    partial class ReservationUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNights = new System.Windows.Forms.TextBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.cmbRoomType = new System.Windows.Forms.ComboBox();
            this.customerData = new System.Windows.Forms.GroupBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.radioAdd = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioSearch = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.cmbItem = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.NumericUpDown();
            this.dgvItem = new System.Windows.Forms.DataGridView();
            this.dgvRooms = new System.Windows.Forms.DataGridView();
            this.dgvSelectedRoom = new System.Windows.Forms.DataGridView();
            this.btnGTGT = new System.Windows.Forms.Button();
            this.btnLTLT = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnSeachRoom = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.customerData.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedRoom)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reservation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Start Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Room Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(309, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Number of Nights";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "List of all rooms : ";
            // 
            // txtNights
            // 
            this.txtNights.Location = new System.Drawing.Point(404, 33);
            this.txtNights.Name = "txtNights";
            this.txtNights.Size = new System.Drawing.Size(104, 20);
            this.txtNights.TabIndex = 5;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(88, 33);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 20);
            this.dtpStart.TabIndex = 6;
            // 
            // cmbRoomType
            // 
            this.cmbRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoomType.FormattingEnabled = true;
            this.cmbRoomType.Location = new System.Drawing.Point(88, 59);
            this.cmbRoomType.Name = "cmbRoomType";
            this.cmbRoomType.Size = new System.Drawing.Size(200, 21);
            this.cmbRoomType.TabIndex = 7;
            this.cmbRoomType.SelectedIndexChanged += new System.EventHandler(this.cmbRoomType_SelectedIndexChanged);
            this.cmbRoomType.SelectedValueChanged += new System.EventHandler(this.cmbRoomType_SelectedValueChanged);
            // 
            // customerData
            // 
            this.customerData.Controls.Add(this.lblSearch);
            this.customerData.Controls.Add(this.txtSearch);
            this.customerData.Controls.Add(this.radioAdd);
            this.customerData.Controls.Add(this.panel1);
            this.customerData.Controls.Add(this.radioSearch);
            this.customerData.Location = new System.Drawing.Point(23, 304);
            this.customerData.Name = "customerData";
            this.customerData.Size = new System.Drawing.Size(414, 220);
            this.customerData.TabIndex = 8;
            this.customerData.TabStop = false;
            this.customerData.Text = "Customer Data";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(209, 21);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(41, 13);
            this.lblSearch.TabIndex = 7;
            this.lblSearch.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(256, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(135, 20);
            this.txtSearch.TabIndex = 6;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // radioAdd
            // 
            this.radioAdd.AutoSize = true;
            this.radioAdd.Location = new System.Drawing.Point(13, 19);
            this.radioAdd.Name = "radioAdd";
            this.radioAdd.Size = new System.Drawing.Size(69, 17);
            this.radioAdd.TabIndex = 4;
            this.radioAdd.TabStop = true;
            this.radioAdd.Text = "Add New";
            this.radioAdd.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(13, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(378, 163);
            this.panel1.TabIndex = 4;
            // 
            // radioSearch
            // 
            this.radioSearch.AutoSize = true;
            this.radioSearch.Location = new System.Drawing.Point(88, 19);
            this.radioSearch.Name = "radioSearch";
            this.radioSearch.Size = new System.Drawing.Size(59, 17);
            this.radioSearch.TabIndex = 5;
            this.radioSearch.TabStop = true;
            this.radioSearch.Text = "Search";
            this.radioSearch.UseVisualStyleBackColor = true;
            this.radioSearch.CheckedChanged += new System.EventHandler(this.radioSearch_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddItem);
            this.groupBox1.Controls.Add(this.cmbItem);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtQty);
            this.groupBox1.Controls.Add(this.dgvItem);
            this.groupBox1.Location = new System.Drawing.Point(443, 304);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 220);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Items";
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(299, 43);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(75, 23);
            this.btnAddItem.TabIndex = 18;
            this.btnAddItem.Text = "Add";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // cmbItem
            // 
            this.cmbItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItem.FormattingEnabled = true;
            this.cmbItem.Location = new System.Drawing.Point(85, 19);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(198, 21);
            this.cmbItem.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Qty";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Item";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(85, 43);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(198, 20);
            this.txtQty.TabIndex = 14;
            // 
            // dgvItem
            // 
            this.dgvItem.AllowUserToAddRows = false;
            this.dgvItem.AllowUserToDeleteRows = false;
            this.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItem.Location = new System.Drawing.Point(17, 79);
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.ReadOnly = true;
            this.dgvItem.Size = new System.Drawing.Size(345, 135);
            this.dgvItem.TabIndex = 0;
            this.dgvItem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItem_CellClick);
            // 
            // dgvRooms
            // 
            this.dgvRooms.AllowUserToAddRows = false;
            this.dgvRooms.AllowUserToDeleteRows = false;
            this.dgvRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRooms.Location = new System.Drawing.Point(23, 110);
            this.dgvRooms.Name = "dgvRooms";
            this.dgvRooms.ReadOnly = true;
            this.dgvRooms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRooms.Size = new System.Drawing.Size(353, 175);
            this.dgvRooms.TabIndex = 10;
            // 
            // dgvSelectedRoom
            // 
            this.dgvSelectedRoom.AllowUserToAddRows = false;
            this.dgvSelectedRoom.AllowUserToDeleteRows = false;
            this.dgvSelectedRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectedRoom.Location = new System.Drawing.Point(462, 110);
            this.dgvSelectedRoom.Name = "dgvSelectedRoom";
            this.dgvSelectedRoom.ReadOnly = true;
            this.dgvSelectedRoom.Size = new System.Drawing.Size(363, 175);
            this.dgvSelectedRoom.TabIndex = 11;
            // 
            // btnGTGT
            // 
            this.btnGTGT.Location = new System.Drawing.Point(395, 153);
            this.btnGTGT.Name = "btnGTGT";
            this.btnGTGT.Size = new System.Drawing.Size(42, 23);
            this.btnGTGT.TabIndex = 12;
            this.btnGTGT.Text = ">>";
            this.btnGTGT.UseVisualStyleBackColor = true;
            this.btnGTGT.Click += new System.EventHandler(this.btnGTGT_Click);
            // 
            // btnLTLT
            // 
            this.btnLTLT.Location = new System.Drawing.Point(395, 209);
            this.btnLTLT.Name = "btnLTLT";
            this.btnLTLT.Size = new System.Drawing.Size(42, 22);
            this.btnLTLT.TabIndex = 13;
            this.btnLTLT.Text = "<<";
            this.btnLTLT.UseVisualStyleBackColor = true;
            this.btnLTLT.Click += new System.EventHandler(this.btnLTLT_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label8.Location = new System.Drawing.Point(623, 537);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Total : ";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTotal.Location = new System.Drawing.Point(685, 537);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(25, 20);
            this.lblTotal.TabIndex = 15;
            this.lblTotal.Text = "    ";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(627, 569);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 16;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnSeachRoom
            // 
            this.btnSeachRoom.Location = new System.Drawing.Point(312, 59);
            this.btnSeachRoom.Name = "btnSeachRoom";
            this.btnSeachRoom.Size = new System.Drawing.Size(102, 23);
            this.btnSeachRoom.TabIndex = 17;
            this.btnSeachRoom.Text = "Search Room";
            this.btnSeachRoom.UseVisualStyleBackColor = true;
            this.btnSeachRoom.Click += new System.EventHandler(this.btnSeachRoom_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(457, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "List of selected rooms :";
            // 
            // ReservationUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnSeachRoom);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnLTLT);
            this.Controls.Add(this.btnGTGT);
            this.Controls.Add(this.dgvSelectedRoom);
            this.Controls.Add(this.dgvRooms);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.customerData);
            this.Controls.Add(this.cmbRoomType);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.txtNights);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Name = "ReservationUC";
            this.Size = new System.Drawing.Size(865, 595);
            this.Load += new System.EventHandler(this.ReservationUC_Load);
            this.customerData.ResumeLayout(false);
            this.customerData.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedRoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNights;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.ComboBox cmbRoomType;
        private System.Windows.Forms.GroupBox customerData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvRooms;
        private System.Windows.Forms.DataGridView dgvSelectedRoom;
        private System.Windows.Forms.Button btnGTGT;
        private System.Windows.Forms.Button btnLTLT;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown txtQty;
        private System.Windows.Forms.RadioButton radioAdd;
        private System.Windows.Forms.RadioButton radioSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvItem;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.ComboBox cmbItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnSeachRoom;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label label9;
    }
}
