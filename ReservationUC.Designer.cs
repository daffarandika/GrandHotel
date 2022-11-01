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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cmbRoomType = new System.Windows.Forms.ComboBox();
            this.customerData = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvRooms = new System.Windows.Forms.DataGridView();
            this.dgvSelectedRoom = new System.Windows.Forms.DataGridView();
            this.btnGTGT = new System.Windows.Forms.Button();
            this.btnLTLT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedRoom)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(18, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reservation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Start Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Room Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(321, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Number of Nights";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "label5";
            // 
            // txtNights
            // 
            this.txtNights.Location = new System.Drawing.Point(416, 71);
            this.txtNights.Name = "txtNights";
            this.txtNights.Size = new System.Drawing.Size(104, 20);
            this.txtNights.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(100, 71);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // cmbRoomType
            // 
            this.cmbRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoomType.FormattingEnabled = true;
            this.cmbRoomType.Location = new System.Drawing.Point(100, 109);
            this.cmbRoomType.Name = "cmbRoomType";
            this.cmbRoomType.Size = new System.Drawing.Size(200, 21);
            this.cmbRoomType.TabIndex = 7;
            // 
            // customerData
            // 
            this.customerData.Location = new System.Drawing.Point(35, 375);
            this.customerData.Name = "customerData";
            this.customerData.Size = new System.Drawing.Size(377, 195);
            this.customerData.TabIndex = 8;
            this.customerData.TabStop = false;
            this.customerData.Text = "Customer Data";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(470, 375);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 195);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Data";
            // 
            // dgvRooms
            // 
            this.dgvRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRooms.Location = new System.Drawing.Point(35, 188);
            this.dgvRooms.Name = "dgvRooms";
            this.dgvRooms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRooms.Size = new System.Drawing.Size(377, 150);
            this.dgvRooms.TabIndex = 10;
            // 
            // dgvSelectedRoom
            // 
            this.dgvSelectedRoom.AllowUserToAddRows = false;
            this.dgvSelectedRoom.AllowUserToDeleteRows = false;
            this.dgvSelectedRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectedRoom.Location = new System.Drawing.Point(470, 188);
            this.dgvSelectedRoom.Name = "dgvSelectedRoom";
            this.dgvSelectedRoom.ReadOnly = true;
            this.dgvSelectedRoom.Size = new System.Drawing.Size(377, 150);
            this.dgvSelectedRoom.TabIndex = 11;
            // 
            // btnGTGT
            // 
            this.btnGTGT.Location = new System.Drawing.Point(422, 220);
            this.btnGTGT.Name = "btnGTGT";
            this.btnGTGT.Size = new System.Drawing.Size(42, 23);
            this.btnGTGT.TabIndex = 12;
            this.btnGTGT.Text = ">>";
            this.btnGTGT.UseVisualStyleBackColor = true;
            this.btnGTGT.Click += new System.EventHandler(this.btnGTGT_Click);
            // 
            // btnLTLT
            // 
            this.btnLTLT.Location = new System.Drawing.Point(422, 277);
            this.btnLTLT.Name = "btnLTLT";
            this.btnLTLT.Size = new System.Drawing.Size(42, 22);
            this.btnLTLT.TabIndex = 13;
            this.btnLTLT.Text = "<<";
            this.btnLTLT.UseVisualStyleBackColor = true;
            // 
            // ReservationUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.btnLTLT);
            this.Controls.Add(this.btnGTGT);
            this.Controls.Add(this.dgvSelectedRoom);
            this.Controls.Add(this.dgvRooms);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.customerData);
            this.Controls.Add(this.cmbRoomType);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtNights);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ReservationUC";
            this.Size = new System.Drawing.Size(948, 628);
            this.Load += new System.EventHandler(this.ReservationUC_Load);
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
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cmbRoomType;
        private System.Windows.Forms.GroupBox customerData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvRooms;
        private System.Windows.Forms.DataGridView dgvSelectedRoom;
        private System.Windows.Forms.Button btnGTGT;
        private System.Windows.Forms.Button btnLTLT;
    }
}
