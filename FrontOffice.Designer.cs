namespace GrandHotel
{
    partial class FrontOffice
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnReservation = new System.Windows.Forms.Button();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.btnAdditionalItem = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnRoomType = new System.Windows.Forms.Button();
            this.btnRoom = new System.Windows.Forms.Button();
            this.btnItem = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnReservation
            // 
            this.btnReservation.Location = new System.Drawing.Point(22, 35);
            this.btnReservation.Name = "btnReservation";
            this.btnReservation.Size = new System.Drawing.Size(110, 49);
            this.btnReservation.TabIndex = 0;
            this.btnReservation.Text = "Reservation";
            this.btnReservation.UseVisualStyleBackColor = true;
            this.btnReservation.Click += new System.EventHandler(this.btnReservation_Click);
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Location = new System.Drawing.Point(22, 90);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(110, 49);
            this.btnCheckIn.TabIndex = 1;
            this.btnCheckIn.Text = "Check In";
            this.btnCheckIn.UseVisualStyleBackColor = true;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // btnAdditionalItem
            // 
            this.btnAdditionalItem.Location = new System.Drawing.Point(22, 145);
            this.btnAdditionalItem.Name = "btnAdditionalItem";
            this.btnAdditionalItem.Size = new System.Drawing.Size(110, 49);
            this.btnAdditionalItem.TabIndex = 2;
            this.btnAdditionalItem.Text = "Request Additional Item(s)";
            this.btnAdditionalItem.UseVisualStyleBackColor = true;
            this.btnAdditionalItem.Click += new System.EventHandler(this.btnAdditionalItem_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Location = new System.Drawing.Point(22, 200);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(110, 49);
            this.btnCheckOut.TabIndex = 3;
            this.btnCheckOut.Text = "Check Out";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // btnRoomType
            // 
            this.btnRoomType.Location = new System.Drawing.Point(22, 256);
            this.btnRoomType.Name = "btnRoomType";
            this.btnRoomType.Size = new System.Drawing.Size(110, 49);
            this.btnRoomType.TabIndex = 4;
            this.btnRoomType.Text = "Master Room Type";
            this.btnRoomType.UseVisualStyleBackColor = true;
            this.btnRoomType.Click += new System.EventHandler(this.btnRoomType_Click);
            // 
            // btnRoom
            // 
            this.btnRoom.Location = new System.Drawing.Point(22, 311);
            this.btnRoom.Name = "btnRoom";
            this.btnRoom.Size = new System.Drawing.Size(110, 49);
            this.btnRoom.TabIndex = 5;
            this.btnRoom.Text = "Master Room";
            this.btnRoom.UseVisualStyleBackColor = true;
            this.btnRoom.Click += new System.EventHandler(this.btnRoom_Click);
            // 
            // btnItem
            // 
            this.btnItem.Location = new System.Drawing.Point(22, 366);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new System.Drawing.Size(110, 49);
            this.btnItem.TabIndex = 6;
            this.btnItem.Text = "Master Item";
            this.btnItem.UseVisualStyleBackColor = true;
            this.btnItem.Click += new System.EventHandler(this.btnItem_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(161, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(865, 529);
            this.panel1.TabIndex = 7;
            // 
            // FrontOffice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1055, 601);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnItem);
            this.Controls.Add(this.btnRoom);
            this.Controls.Add(this.btnRoomType);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.btnAdditionalItem);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.btnReservation);
            this.Name = "FrontOffice";
            this.Text = "FrontOffice";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrontOffice_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReservation;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnAdditionalItem;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Button btnRoomType;
        private System.Windows.Forms.Button btnRoom;
        private System.Windows.Forms.Button btnItem;
        private System.Windows.Forms.Panel panel1;
    }
}