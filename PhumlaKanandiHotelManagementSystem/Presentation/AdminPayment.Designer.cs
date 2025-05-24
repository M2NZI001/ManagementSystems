namespace PhumlaKanandiHotelManagementSystem.Presentation
{
    partial class AdminPayment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.backButtonAdminPayments = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBookingID_payment = new System.Windows.Forms.TextBox();
            this.btnMakePayment_payment = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.depositAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalAmountToBePayed_payment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPriceOfStay = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtSearchByBookingID_payment = new System.Windows.Forms.TextBox();
            this.btnSearch_payment = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSearchByGuestID_payment = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView_payment = new System.Windows.Forms.DataGridView();
            this.printConfirmationButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_payment)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
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
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(230)))));
            this.panel3.Controls.Add(this.printConfirmationButton);
            this.panel3.Controls.Add(this.backButtonAdminPayments);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtBookingID_payment);
            this.panel3.Controls.Add(this.btnMakePayment_payment);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.depositAmount);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtTotalAmountToBePayed_payment);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtPriceOfStay);
            this.panel3.Location = new System.Drawing.Point(28, 555);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1250, 234);
            this.panel3.TabIndex = 4;
           
            // 
            // backButtonAdminPayments
            // 
            this.backButtonAdminPayments.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.backButtonAdminPayments.Location = new System.Drawing.Point(1103, 177);
            this.backButtonAdminPayments.Name = "backButtonAdminPayments";
            this.backButtonAdminPayments.Size = new System.Drawing.Size(121, 45);
            this.backButtonAdminPayments.TabIndex = 53;
            this.backButtonAdminPayments.Text = "Back";
            this.backButtonAdminPayments.UseVisualStyleBackColor = true;
            this.backButtonAdminPayments.Click += new System.EventHandler(this.backButtonAdminPayments_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(89, 30);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 29);
            this.label5.TabIndex = 50;
            this.label5.Text = "Booking ID:";
            // 
            // txtBookingID_payment
            // 
            this.txtBookingID_payment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookingID_payment.Location = new System.Drawing.Point(225, 29);
            this.txtBookingID_payment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBookingID_payment.Name = "txtBookingID_payment";
            this.txtBookingID_payment.ReadOnly = true;
            this.txtBookingID_payment.Size = new System.Drawing.Size(163, 30);
            this.txtBookingID_payment.TabIndex = 51;
            this.txtBookingID_payment.TextChanged += new System.EventHandler(this.txtBookingID_payment_TextChanged);
            // 
            // btnMakePayment_payment
            // 
            this.btnMakePayment_payment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(230)))));
            this.btnMakePayment_payment.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnMakePayment_payment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMakePayment_payment.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMakePayment_payment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnMakePayment_payment.Location = new System.Drawing.Point(972, 16);
            this.btnMakePayment_payment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMakePayment_payment.Name = "btnMakePayment_payment";
            this.btnMakePayment_payment.Size = new System.Drawing.Size(252, 54);
            this.btnMakePayment_payment.TabIndex = 46;
            this.btnMakePayment_payment.Text = "Make Payment";
            this.btnMakePayment_payment.UseVisualStyleBackColor = false;
            this.btnMakePayment_payment.Click += new System.EventHandler(this.btnMakePayment_payment_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 178);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 29);
            this.label3.TabIndex = 48;
            this.label3.Text = "Deposit Amount:";
            // 
            // depositAmount
            // 
            this.depositAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.depositAmount.Location = new System.Drawing.Point(225, 177);
            this.depositAmount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.depositAmount.Name = "depositAmount";
            this.depositAmount.Size = new System.Drawing.Size(163, 30);
            this.depositAmount.TabIndex = 49;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(524, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 29);
            this.label2.TabIndex = 46;
            this.label2.Text = "Payment Amount:";
            // 
            // txtTotalAmountToBePayed_payment
            // 
            this.txtTotalAmountToBePayed_payment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmountToBePayed_payment.Location = new System.Drawing.Point(756, 29);
            this.txtTotalAmountToBePayed_payment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTotalAmountToBePayed_payment.Name = "txtTotalAmountToBePayed_payment";
            this.txtTotalAmountToBePayed_payment.Size = new System.Drawing.Size(163, 30);
            this.txtTotalAmountToBePayed_payment.TabIndex = 47;
            this.txtTotalAmountToBePayed_payment.TextChanged += new System.EventHandler(this.txtTotalAmountToBePayed_payment_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 101);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 29);
            this.label1.TabIndex = 44;
            this.label1.Text = "Total Price for Stay:";
            // 
            // txtPriceOfStay
            // 
            this.txtPriceOfStay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPriceOfStay.Location = new System.Drawing.Point(225, 100);
            this.txtPriceOfStay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPriceOfStay.Name = "txtPriceOfStay";
            this.txtPriceOfStay.Size = new System.Drawing.Size(163, 30);
            this.txtPriceOfStay.TabIndex = 45;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(230)))));
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.dataGridView_payment);
            this.panel2.Location = new System.Drawing.Point(28, 22);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1250, 505);
            this.panel2.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel5.Controls.Add(this.txtSearchByBookingID_payment);
            this.panel5.Controls.Add(this.btnSearch_payment);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.txtSearchByGuestID_payment);
            this.panel5.Location = new System.Drawing.Point(20, 20);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(417, 425);
            this.panel5.TabIndex = 58;
            // 
            // txtSearchByBookingID_payment
            // 
            this.txtSearchByBookingID_payment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchByBookingID_payment.Location = new System.Drawing.Point(70, 60);
            this.txtSearchByBookingID_payment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearchByBookingID_payment.Name = "txtSearchByBookingID_payment";
            this.txtSearchByBookingID_payment.Size = new System.Drawing.Size(163, 30);
            this.txtSearchByBookingID_payment.TabIndex = 45;
            this.txtSearchByBookingID_payment.TextChanged += new System.EventHandler(this.txtSearchByBookingID_payment_TextChanged);
            // 
            // btnSearch_payment
            // 
            this.btnSearch_payment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(230)))));
            this.btnSearch_payment.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSearch_payment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch_payment.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch_payment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnSearch_payment.Location = new System.Drawing.Point(32, 312);
            this.btnSearch_payment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch_payment.Name = "btnSearch_payment";
            this.btnSearch_payment.Size = new System.Drawing.Size(360, 54);
            this.btnSearch_payment.TabIndex = 55;
            this.btnSearch_payment.Text = "Search";
            this.btnSearch_payment.UseVisualStyleBackColor = false;
            this.btnSearch_payment.Click += new System.EventHandler(this.btnSearch_payment_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(66, 128);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 29);
            this.label8.TabIndex = 56;
            this.label8.Text = "Guest ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(66, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 29);
            this.label4.TabIndex = 44;
            this.label4.Text = "Booking ID";
            // 
            // txtSearchByGuestID_payment
            // 
            this.txtSearchByGuestID_payment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchByGuestID_payment.Location = new System.Drawing.Point(70, 160);
            this.txtSearchByGuestID_payment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearchByGuestID_payment.Name = "txtSearchByGuestID_payment";
            this.txtSearchByGuestID_payment.Size = new System.Drawing.Size(163, 30);
            this.txtSearchByGuestID_payment.TabIndex = 57;
            this.txtSearchByGuestID_payment.TextChanged += new System.EventHandler(this.txtSearchByGuestID_payment_TextChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel4.Location = new System.Drawing.Point(470, 20);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(15, 463);
            this.panel4.TabIndex = 54;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(750, 40);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(210, 33);
            this.label6.TabIndex = 53;
            this.label6.Text = "Payment Data";
            // 
            // dataGridView_payment
            // 
            this.dataGridView_payment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_payment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_payment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_payment.EnableHeadersVisualStyles = false;
            this.dataGridView_payment.Location = new System.Drawing.Point(510, 118);
            this.dataGridView_payment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView_payment.Name = "dataGridView_payment";
            this.dataGridView_payment.RowHeadersWidth = 62;
            this.dataGridView_payment.Size = new System.Drawing.Size(714, 365);
            this.dataGridView_payment.TabIndex = 25;
            this.dataGridView_payment.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_payment_CellContentClick);
            // 
            // printConfirmationButton
            // 
            this.printConfirmationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(230)))));
            this.printConfirmationButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.printConfirmationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.printConfirmationButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printConfirmationButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.printConfirmationButton.Location = new System.Drawing.Point(972, 99);
            this.printConfirmationButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.printConfirmationButton.Name = "printConfirmationButton";
            this.printConfirmationButton.Size = new System.Drawing.Size(252, 54);
            this.printConfirmationButton.TabIndex = 54;
            this.printConfirmationButton.Text = "Print Confirmation";
            this.printConfirmationButton.UseVisualStyleBackColor = false;
            this.printConfirmationButton.Click += new System.EventHandler(this.printConfirmationButton_Click);
            // 
            // AdminPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AdminPayment";
            this.Size = new System.Drawing.Size(1299, 834);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_payment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView_payment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSearchByBookingID_payment;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox depositAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalAmountToBePayed_payment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPriceOfStay;
        private System.Windows.Forms.Button btnMakePayment_payment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBookingID_payment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSearchByGuestID_payment;
        private System.Windows.Forms.Button btnSearch_payment;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button backButtonAdminPayments;
        private System.Windows.Forms.Button printConfirmationButton;
    }
}
