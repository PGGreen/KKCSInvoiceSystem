namespace KKCSInvoiceProject
{
    partial class CarReturns
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btn_load = new System.Windows.Forms.Button();
            this.lbl_carreturns = new System.Windows.Forms.Label();
            this.btn_invoice = new System.Windows.Forms.Button();
            this.btn_mainmenu = new System.Windows.Forms.Button();
            this.chk_returndate = new System.Windows.Forms.CheckBox();
            this.chk_datebroughtin = new System.Windows.Forms.CheckBox();
            this.btn_keybox = new System.Windows.Forms.Button();
            this.btn_alertsnotes = new System.Windows.Forms.Button();
            this.btn_left = new System.Windows.Forms.Button();
            this.btn_right = new System.Windows.Forms.Button();
            this.chk_datepaid = new System.Windows.Forms.CheckBox();
            this.lbl_filters = new System.Windows.Forms.Label();
            this.chkbox_nocharge = new System.Windows.Forms.CheckBox();
            this.chkbox_onaccount = new System.Windows.Forms.CheckBox();
            this.chkbox_stilltopay = new System.Windows.Forms.CheckBox();
            this.chkbox_internet = new System.Windows.Forms.CheckBox();
            this.chkbox_cheque = new System.Windows.Forms.CheckBox();
            this.chkbox_eftpos = new System.Windows.Forms.CheckBox();
            this.chkbox_cash = new System.Windows.Forms.CheckBox();
            this.chk_filters = new System.Windows.Forms.CheckBox();
            this.chkbox_creditcard = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.dateTimePicker1.Location = new System.Drawing.Point(76, 60);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(394, 35);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // btn_load
            // 
            this.btn_load.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_load.Location = new System.Drawing.Point(551, 61);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(79, 29);
            this.btn_load.TabIndex = 1;
            this.btn_load.Text = "Reload";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // lbl_carreturns
            // 
            this.lbl_carreturns.AutoSize = true;
            this.lbl_carreturns.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_carreturns.Location = new System.Drawing.Point(22, 12);
            this.lbl_carreturns.Name = "lbl_carreturns";
            this.lbl_carreturns.Size = new System.Drawing.Size(172, 31);
            this.lbl_carreturns.TabIndex = 2;
            this.lbl_carreturns.Text = "Car Returns";
            // 
            // btn_invoice
            // 
            this.btn_invoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btn_invoice.Location = new System.Drawing.Point(1362, 65);
            this.btn_invoice.Name = "btn_invoice";
            this.btn_invoice.Size = new System.Drawing.Size(98, 47);
            this.btn_invoice.TabIndex = 76;
            this.btn_invoice.Text = "Invoice";
            this.btn_invoice.UseVisualStyleBackColor = true;
            this.btn_invoice.Click += new System.EventHandler(this.btn_invoice_Click);
            // 
            // btn_mainmenu
            // 
            this.btn_mainmenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btn_mainmenu.Location = new System.Drawing.Point(1363, 12);
            this.btn_mainmenu.Name = "btn_mainmenu";
            this.btn_mainmenu.Size = new System.Drawing.Size(98, 47);
            this.btn_mainmenu.TabIndex = 75;
            this.btn_mainmenu.Text = "Main Menu";
            this.btn_mainmenu.UseVisualStyleBackColor = true;
            this.btn_mainmenu.Click += new System.EventHandler(this.btn_mainmenu_Click);
            // 
            // chk_returndate
            // 
            this.chk_returndate.AutoSize = true;
            this.chk_returndate.Checked = true;
            this.chk_returndate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_returndate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_returndate.Location = new System.Drawing.Point(653, 33);
            this.chk_returndate.Name = "chk_returndate";
            this.chk_returndate.Size = new System.Drawing.Size(116, 24);
            this.chk_returndate.TabIndex = 77;
            this.chk_returndate.Text = "Return Date";
            this.chk_returndate.UseVisualStyleBackColor = true;
            this.chk_returndate.CheckedChanged += new System.EventHandler(this.chk_returndate_CheckedChanged);
            // 
            // chk_datebroughtin
            // 
            this.chk_datebroughtin.AutoSize = true;
            this.chk_datebroughtin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_datebroughtin.Location = new System.Drawing.Point(653, 63);
            this.chk_datebroughtin.Name = "chk_datebroughtin";
            this.chk_datebroughtin.Size = new System.Drawing.Size(171, 24);
            this.chk_datebroughtin.TabIndex = 78;
            this.chk_datebroughtin.Text = "Date Car Brought In";
            this.chk_datebroughtin.UseVisualStyleBackColor = true;
            this.chk_datebroughtin.CheckedChanged += new System.EventHandler(this.chk_datebroughtin_CheckedChanged);
            // 
            // btn_keybox
            // 
            this.btn_keybox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btn_keybox.Location = new System.Drawing.Point(1467, 12);
            this.btn_keybox.Name = "btn_keybox";
            this.btn_keybox.Size = new System.Drawing.Size(98, 47);
            this.btn_keybox.TabIndex = 79;
            this.btn_keybox.Text = "Key Box";
            this.btn_keybox.UseVisualStyleBackColor = true;
            this.btn_keybox.Click += new System.EventHandler(this.btn_keybox_Click);
            // 
            // btn_alertsnotes
            // 
            this.btn_alertsnotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_alertsnotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_alertsnotes.Location = new System.Drawing.Point(1468, 65);
            this.btn_alertsnotes.Name = "btn_alertsnotes";
            this.btn_alertsnotes.Size = new System.Drawing.Size(97, 47);
            this.btn_alertsnotes.TabIndex = 80;
            this.btn_alertsnotes.Text = "Show All\r\nAlerts/Notes";
            this.btn_alertsnotes.UseVisualStyleBackColor = false;
            this.btn_alertsnotes.Click += new System.EventHandler(this.btn_alertsnotes_Click);
            // 
            // btn_left
            // 
            this.btn_left.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_left.Location = new System.Drawing.Point(29, 61);
            this.btn_left.Name = "btn_left";
            this.btn_left.Size = new System.Drawing.Size(42, 32);
            this.btn_left.TabIndex = 81;
            this.btn_left.Text = "<--";
            this.btn_left.UseVisualStyleBackColor = true;
            this.btn_left.Click += new System.EventHandler(this.btn_left_Click);
            // 
            // btn_right
            // 
            this.btn_right.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_right.Location = new System.Drawing.Point(476, 60);
            this.btn_right.Name = "btn_right";
            this.btn_right.Size = new System.Drawing.Size(42, 32);
            this.btn_right.TabIndex = 82;
            this.btn_right.Text = "-->";
            this.btn_right.UseVisualStyleBackColor = true;
            this.btn_right.Click += new System.EventHandler(this.btn_right_Click);
            // 
            // chk_datepaid
            // 
            this.chk_datepaid.AutoSize = true;
            this.chk_datepaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_datepaid.Location = new System.Drawing.Point(653, 95);
            this.chk_datepaid.Name = "chk_datepaid";
            this.chk_datepaid.Size = new System.Drawing.Size(171, 24);
            this.chk_datepaid.TabIndex = 83;
            this.chk_datepaid.Text = "Date Customer Paid";
            this.chk_datepaid.UseVisualStyleBackColor = true;
            this.chk_datepaid.CheckedChanged += new System.EventHandler(this.chk_datepaid_CheckedChanged);
            // 
            // lbl_filters
            // 
            this.lbl_filters.AutoSize = true;
            this.lbl_filters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_filters.Location = new System.Drawing.Point(975, 12);
            this.lbl_filters.Name = "lbl_filters";
            this.lbl_filters.Size = new System.Drawing.Size(59, 20);
            this.lbl_filters.TabIndex = 84;
            this.lbl_filters.Text = "Filters";
            // 
            // chkbox_nocharge
            // 
            this.chkbox_nocharge.AutoSize = true;
            this.chkbox_nocharge.Checked = true;
            this.chkbox_nocharge.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbox_nocharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbox_nocharge.Location = new System.Drawing.Point(974, 111);
            this.chkbox_nocharge.Name = "chkbox_nocharge";
            this.chkbox_nocharge.Size = new System.Drawing.Size(50, 20);
            this.chkbox_nocharge.TabIndex = 96;
            this.chkbox_nocharge.Text = "N/C";
            this.chkbox_nocharge.UseVisualStyleBackColor = true;
            this.chkbox_nocharge.Visible = false;
            // 
            // chkbox_onaccount
            // 
            this.chkbox_onaccount.AutoSize = true;
            this.chkbox_onaccount.Checked = true;
            this.chkbox_onaccount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbox_onaccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbox_onaccount.Location = new System.Drawing.Point(892, 111);
            this.chkbox_onaccount.Name = "chkbox_onaccount";
            this.chkbox_onaccount.Size = new System.Drawing.Size(70, 20);
            this.chkbox_onaccount.TabIndex = 95;
            this.chkbox_onaccount.Text = "On Acc";
            this.chkbox_onaccount.UseVisualStyleBackColor = true;
            this.chkbox_onaccount.Visible = false;
            // 
            // chkbox_stilltopay
            // 
            this.chkbox_stilltopay.AutoSize = true;
            this.chkbox_stilltopay.Checked = true;
            this.chkbox_stilltopay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbox_stilltopay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbox_stilltopay.Location = new System.Drawing.Point(1051, 76);
            this.chkbox_stilltopay.Name = "chkbox_stilltopay";
            this.chkbox_stilltopay.Size = new System.Drawing.Size(71, 20);
            this.chkbox_stilltopay.TabIndex = 94;
            this.chkbox_stilltopay.Text = "To Pay";
            this.chkbox_stilltopay.UseVisualStyleBackColor = true;
            this.chkbox_stilltopay.Visible = false;
            // 
            // chkbox_internet
            // 
            this.chkbox_internet.AutoSize = true;
            this.chkbox_internet.Checked = true;
            this.chkbox_internet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbox_internet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbox_internet.Location = new System.Drawing.Point(892, 76);
            this.chkbox_internet.Name = "chkbox_internet";
            this.chkbox_internet.Size = new System.Drawing.Size(70, 20);
            this.chkbox_internet.TabIndex = 93;
            this.chkbox_internet.Text = "Internet";
            this.chkbox_internet.UseVisualStyleBackColor = true;
            this.chkbox_internet.Visible = false;
            // 
            // chkbox_cheque
            // 
            this.chkbox_cheque.AutoSize = true;
            this.chkbox_cheque.Checked = true;
            this.chkbox_cheque.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbox_cheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbox_cheque.Location = new System.Drawing.Point(974, 76);
            this.chkbox_cheque.Name = "chkbox_cheque";
            this.chkbox_cheque.Size = new System.Drawing.Size(74, 20);
            this.chkbox_cheque.TabIndex = 92;
            this.chkbox_cheque.Text = "Cheque";
            this.chkbox_cheque.UseVisualStyleBackColor = true;
            this.chkbox_cheque.Visible = false;
            // 
            // chkbox_eftpos
            // 
            this.chkbox_eftpos.AutoSize = true;
            this.chkbox_eftpos.Checked = true;
            this.chkbox_eftpos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbox_eftpos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbox_eftpos.Location = new System.Drawing.Point(974, 42);
            this.chkbox_eftpos.Name = "chkbox_eftpos";
            this.chkbox_eftpos.Size = new System.Drawing.Size(65, 20);
            this.chkbox_eftpos.TabIndex = 91;
            this.chkbox_eftpos.Text = "Eftpos";
            this.chkbox_eftpos.UseVisualStyleBackColor = true;
            this.chkbox_eftpos.Visible = false;
            // 
            // chkbox_cash
            // 
            this.chkbox_cash.AutoSize = true;
            this.chkbox_cash.Checked = true;
            this.chkbox_cash.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbox_cash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbox_cash.Location = new System.Drawing.Point(892, 43);
            this.chkbox_cash.Name = "chkbox_cash";
            this.chkbox_cash.Size = new System.Drawing.Size(58, 20);
            this.chkbox_cash.TabIndex = 90;
            this.chkbox_cash.Text = "Cash";
            this.chkbox_cash.UseVisualStyleBackColor = true;
            this.chkbox_cash.Visible = false;
            // 
            // chk_filters
            // 
            this.chk_filters.AutoSize = true;
            this.chk_filters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_filters.Location = new System.Drawing.Point(1051, 12);
            this.chk_filters.Name = "chk_filters";
            this.chk_filters.Size = new System.Drawing.Size(120, 20);
            this.chk_filters.TabIndex = 97;
            this.chk_filters.Text = "Click to Turn On";
            this.chk_filters.UseVisualStyleBackColor = true;
            this.chk_filters.CheckedChanged += new System.EventHandler(this.chk_filters_CheckedChanged);
            // 
            // chkbox_creditcard
            // 
            this.chkbox_creditcard.AutoSize = true;
            this.chkbox_creditcard.Checked = true;
            this.chkbox_creditcard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbox_creditcard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbox_creditcard.Location = new System.Drawing.Point(1051, 42);
            this.chkbox_creditcard.Name = "chkbox_creditcard";
            this.chkbox_creditcard.Size = new System.Drawing.Size(94, 20);
            this.chkbox_creditcard.TabIndex = 98;
            this.chkbox_creditcard.Text = "Credit Card";
            this.chkbox_creditcard.UseVisualStyleBackColor = true;
            this.chkbox_creditcard.Visible = false;
            // 
            // CarReturns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1577, 730);
            this.Controls.Add(this.chkbox_creditcard);
            this.Controls.Add(this.chk_filters);
            this.Controls.Add(this.chkbox_nocharge);
            this.Controls.Add(this.chkbox_onaccount);
            this.Controls.Add(this.chkbox_stilltopay);
            this.Controls.Add(this.chkbox_internet);
            this.Controls.Add(this.chkbox_cheque);
            this.Controls.Add(this.chkbox_eftpos);
            this.Controls.Add(this.chkbox_cash);
            this.Controls.Add(this.lbl_filters);
            this.Controls.Add(this.chk_datepaid);
            this.Controls.Add(this.btn_right);
            this.Controls.Add(this.btn_left);
            this.Controls.Add(this.btn_alertsnotes);
            this.Controls.Add(this.btn_keybox);
            this.Controls.Add(this.chk_datebroughtin);
            this.Controls.Add(this.chk_returndate);
            this.Controls.Add(this.btn_invoice);
            this.Controls.Add(this.btn_mainmenu);
            this.Controls.Add(this.lbl_carreturns);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "CarReturns";
            this.Text = "Car Returns";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.Label lbl_carreturns;
        private System.Windows.Forms.Button btn_invoice;
        private System.Windows.Forms.Button btn_mainmenu;
        private System.Windows.Forms.CheckBox chk_returndate;
        private System.Windows.Forms.CheckBox chk_datebroughtin;
        private System.Windows.Forms.Button btn_keybox;
        private System.Windows.Forms.Button btn_alertsnotes;
        private System.Windows.Forms.Button btn_left;
        private System.Windows.Forms.Button btn_right;
        private System.Windows.Forms.CheckBox chk_datepaid;
        private System.Windows.Forms.Label lbl_filters;
        private System.Windows.Forms.CheckBox chkbox_nocharge;
        private System.Windows.Forms.CheckBox chkbox_onaccount;
        private System.Windows.Forms.CheckBox chkbox_stilltopay;
        private System.Windows.Forms.CheckBox chkbox_internet;
        private System.Windows.Forms.CheckBox chkbox_cheque;
        private System.Windows.Forms.CheckBox chkbox_eftpos;
        private System.Windows.Forms.CheckBox chkbox_cash;
        private System.Windows.Forms.CheckBox chk_filters;
        private System.Windows.Forms.CheckBox chkbox_creditcard;
    }
}