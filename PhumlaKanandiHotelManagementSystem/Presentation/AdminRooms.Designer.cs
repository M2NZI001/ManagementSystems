namespace PhumlaKanandiHotelManagementSystem.Presentation
{
    partial class AdminRooms
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.clearButton = new System.Windows.Forms.Button();
            this.roomStatus_rooms = new System.Windows.Forms.ComboBox();
            this.roomType_rooms = new System.Windows.Forms.ComboBox();
            this.btnBook_rooms = new System.Windows.Forms.Button();
            this.btnSearch_rooms = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRoomNum_rooms = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRoomID_rooms = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView_Rooms = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Rooms)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1299, 834);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.clearButton);
            this.panel3.Controls.Add(this.roomStatus_rooms);
            this.panel3.Controls.Add(this.roomType_rooms);
            this.panel3.Controls.Add(this.btnBook_rooms);
            this.panel3.Controls.Add(this.btnSearch_rooms);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtRoomNum_rooms);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtRoomID_rooms);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 500);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1299, 334);
            this.panel3.TabIndex = 1;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(230)))));
            this.clearButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.clearButton.Location = new System.Drawing.Point(969, 249);
            this.clearButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(201, 54);
            this.clearButton.TabIndex = 48;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // roomStatus_rooms
            // 
            this.roomStatus_rooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.roomStatus_rooms.FormattingEnabled = true;
            this.roomStatus_rooms.Items.AddRange(new object[] {
            "Available",
            "Occupied"});
            this.roomStatus_rooms.Location = new System.Drawing.Point(891, 82);
            this.roomStatus_rooms.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.roomStatus_rooms.Name = "roomStatus_rooms";
            this.roomStatus_rooms.Size = new System.Drawing.Size(222, 33);
            this.roomStatus_rooms.TabIndex = 43;
            // 
            // roomType_rooms
            // 
            this.roomType_rooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.roomType_rooms.FormattingEnabled = true;
            this.roomType_rooms.Items.AddRange(new object[] {
            "Single",
            "Double",
            "Family",
            "Suite"});
            this.roomType_rooms.Location = new System.Drawing.Point(216, 94);
            this.roomType_rooms.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.roomType_rooms.Name = "roomType_rooms";
            this.roomType_rooms.Size = new System.Drawing.Size(222, 33);
            this.roomType_rooms.TabIndex = 42;
            // 
            // btnBook_rooms
            // 
            this.btnBook_rooms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(230)))));
            this.btnBook_rooms.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnBook_rooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBook_rooms.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBook_rooms.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnBook_rooms.Location = new System.Drawing.Point(538, 249);
            this.btnBook_rooms.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBook_rooms.Name = "btnBook_rooms";
            this.btnBook_rooms.Size = new System.Drawing.Size(201, 54);
            this.btnBook_rooms.TabIndex = 40;
            this.btnBook_rooms.Text = "Book";
            this.btnBook_rooms.UseVisualStyleBackColor = false;
            this.btnBook_rooms.Click += new System.EventHandler(this.btnBook_rooms_Click);
            // 
            // btnSearch_rooms
            // 
            this.btnSearch_rooms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(230)))));
            this.btnSearch_rooms.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSearch_rooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch_rooms.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch_rooms.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnSearch_rooms.Location = new System.Drawing.Point(51, 249);
            this.btnSearch_rooms.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch_rooms.Name = "btnSearch_rooms";
            this.btnSearch_rooms.Size = new System.Drawing.Size(201, 54);
            this.btnSearch_rooms.TabIndex = 38;
            this.btnSearch_rooms.Text = "Search";
            this.btnSearch_rooms.UseVisualStyleBackColor = false;
            this.btnSearch_rooms.Click += new System.EventHandler(this.btnAdd_rooms_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(779, 82);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 29);
            this.label4.TabIndex = 36;
            this.label4.Text = "Status:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(141, 92);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 29);
            this.label6.TabIndex = 32;
            this.label6.Text = "Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(687, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 29);
            this.label2.TabIndex = 26;
            this.label2.Text = "Room Number:";
            // 
            // txtRoomNum_rooms
            // 
            this.txtRoomNum_rooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoomNum_rooms.Location = new System.Drawing.Point(891, 34);
            this.txtRoomNum_rooms.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRoomNum_rooms.Name = "txtRoomNum_rooms";
            this.txtRoomNum_rooms.Size = new System.Drawing.Size(288, 30);
            this.txtRoomNum_rooms.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(100, 40);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 29);
            this.label5.TabIndex = 24;
            this.label5.Text = "Room ID:";
            // 
            // txtRoomID_rooms
            // 
            this.txtRoomID_rooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoomID_rooms.Location = new System.Drawing.Point(218, 34);
            this.txtRoomID_rooms.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRoomID_rooms.Name = "txtRoomID_rooms";
            this.txtRoomID_rooms.Size = new System.Drawing.Size(222, 30);
            this.txtRoomID_rooms.TabIndex = 25;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dataGridView_Rooms);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1299, 460);
            this.panel2.TabIndex = 0;
            // 
            // dataGridView_Rooms
            // 
            this.dataGridView_Rooms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Rooms.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_Rooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Rooms.EnableHeadersVisualStyles = false;
            this.dataGridView_Rooms.Location = new System.Drawing.Point(40, 88);
            this.dataGridView_Rooms.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView_Rooms.Name = "dataGridView_Rooms";
            this.dataGridView_Rooms.RowHeadersWidth = 62;
            this.dataGridView_Rooms.Size = new System.Drawing.Size(1224, 338);
            this.dataGridView_Rooms.TabIndex = 23;
            this.dataGridView_Rooms.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Rooms_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 33);
            this.label1.TabIndex = 22;
            this.label1.Text = "Room\'s Data";
            // 
            // AdminRooms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AdminRooms";
            this.Size = new System.Drawing.Size(1299, 834);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Rooms)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView_Rooms;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRoomNum_rooms;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRoomID_rooms;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBook_rooms;
        private System.Windows.Forms.Button btnSearch_rooms;
        private System.Windows.Forms.ComboBox roomStatus_rooms;
        private System.Windows.Forms.ComboBox roomType_rooms;
        private System.Windows.Forms.Button clearButton;
    }
}
