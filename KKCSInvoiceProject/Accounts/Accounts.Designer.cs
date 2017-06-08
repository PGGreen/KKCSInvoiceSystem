namespace KKCSInvoiceProject
{
    partial class Accounts
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
            this.lbl_pickdate = new System.Windows.Forms.Label();
            this.lbl_2 = new System.Windows.Forms.Label();
            this.btn_invoice = new System.Windows.Forms.Button();
            this.btn_mainmenu = new System.Windows.Forms.Button();
            this.chk_returndate = new System.Windows.Forms.CheckBox();
            this.chk_datebroughtin = new System.Windows.Forms.CheckBox();
            this.cmb_rego = new System.Windows.Forms.ComboBox();
            this.chk_accounthold = new System.Windows.Forms.CheckBox();
            this.chk_accountopen = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.dateTimePicker1.Location = new System.Drawing.Point(208, 64);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(394, 35);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // btn_load
            // 
            this.btn_load.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btn_load.Location = new System.Drawing.Point(666, 64);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(77, 35);
            this.btn_load.TabIndex = 1;
            this.btn_load.Text = "Load";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // lbl_carreturns
            // 
            this.lbl_carreturns.AutoSize = true;
            this.lbl_carreturns.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_carreturns.Location = new System.Drawing.Point(316, 12);
            this.lbl_carreturns.Name = "lbl_carreturns";
            this.lbl_carreturns.Size = new System.Drawing.Size(172, 31);
            this.lbl_carreturns.TabIndex = 2;
            this.lbl_carreturns.Text = "Car Returns";
            // 
            // lbl_pickdate
            // 
            this.lbl_pickdate.AutoSize = true;
            this.lbl_pickdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pickdate.ForeColor = System.Drawing.Color.Green;
            this.lbl_pickdate.Location = new System.Drawing.Point(22, 64);
            this.lbl_pickdate.Name = "lbl_pickdate";
            this.lbl_pickdate.Size = new System.Drawing.Size(182, 31);
            this.lbl_pickdate.TabIndex = 3;
            this.lbl_pickdate.Text = "1. Pick Date:";
            // 
            // lbl_2
            // 
            this.lbl_2.AutoSize = true;
            this.lbl_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_2.ForeColor = System.Drawing.Color.Green;
            this.lbl_2.Location = new System.Drawing.Point(624, 66);
            this.lbl_2.Name = "lbl_2";
            this.lbl_2.Size = new System.Drawing.Size(39, 31);
            this.lbl_2.TabIndex = 4;
            this.lbl_2.Text = "2.";
            // 
            // btn_invoice
            // 
            this.btn_invoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btn_invoice.Location = new System.Drawing.Point(1027, 67);
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
            this.btn_mainmenu.Location = new System.Drawing.Point(1028, 14);
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
            this.chk_returndate.Location = new System.Drawing.Point(780, 37);
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
            this.chk_datebroughtin.Location = new System.Drawing.Point(780, 78);
            this.chk_datebroughtin.Name = "chk_datebroughtin";
            this.chk_datebroughtin.Size = new System.Drawing.Size(171, 24);
            this.chk_datebroughtin.TabIndex = 78;
            this.chk_datebroughtin.Text = "Date Car Brought In";
            this.chk_datebroughtin.UseVisualStyleBackColor = true;
            this.chk_datebroughtin.CheckedChanged += new System.EventHandler(this.chk_datebroughtin_CheckedChanged);
            // 
            // cmb_rego
            // 
            this.cmb_rego.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmb_rego.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_rego.BackColor = System.Drawing.SystemColors.Window;
            this.cmb_rego.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmb_rego.DropDownWidth = 121;
            this.cmb_rego.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_rego.FormattingEnabled = true;
            this.cmb_rego.Location = new System.Drawing.Point(28, 121);
            this.cmb_rego.Name = "cmb_rego";
            this.cmb_rego.Size = new System.Drawing.Size(923, 33);
            this.cmb_rego.TabIndex = 79;
            this.cmb_rego.SelectedIndexChanged += new System.EventHandler(this.cmb_rego_SelectedIndexChanged);
            // 
            // chk_accounthold
            // 
            this.chk_accounthold.AutoSize = true;
            this.chk_accounthold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_accounthold.Location = new System.Drawing.Point(1003, 146);
            this.chk_accounthold.Name = "chk_accounthold";
            this.chk_accounthold.Size = new System.Drawing.Size(149, 24);
            this.chk_accounthold.TabIndex = 80;
            this.chk_accounthold.Text = "Account On Hold";
            this.chk_accounthold.UseVisualStyleBackColor = true;
            this.chk_accounthold.Visible = false;
            // 
            // chk_accountopen
            // 
            this.chk_accountopen.AutoSize = true;
            this.chk_accountopen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_accountopen.Location = new System.Drawing.Point(1003, 188);
            this.chk_accountopen.Name = "chk_accountopen";
            this.chk_accountopen.Size = new System.Drawing.Size(130, 24);
            this.chk_accountopen.TabIndex = 81;
            this.chk_accountopen.Text = "Account Open";
            this.chk_accountopen.UseVisualStyleBackColor = true;
            this.chk_accountopen.Visible = false;
            // 
            // Accounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1240, 730);
            this.Controls.Add(this.chk_accountopen);
            this.Controls.Add(this.chk_accounthold);
            this.Controls.Add(this.cmb_rego);
            this.Controls.Add(this.chk_datebroughtin);
            this.Controls.Add(this.chk_returndate);
            this.Controls.Add(this.btn_invoice);
            this.Controls.Add(this.btn_mainmenu);
            this.Controls.Add(this.lbl_2);
            this.Controls.Add(this.lbl_pickdate);
            this.Controls.Add(this.lbl_carreturns);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "Accounts";
            this.Text = "Accounts";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.Label lbl_carreturns;
        private System.Windows.Forms.Label lbl_pickdate;
        private System.Windows.Forms.Label lbl_2;
        private System.Windows.Forms.Button btn_invoice;
        private System.Windows.Forms.Button btn_mainmenu;
        private System.Windows.Forms.CheckBox chk_returndate;
        private System.Windows.Forms.CheckBox chk_datebroughtin;
        private System.Windows.Forms.ComboBox cmb_rego;
        private System.Windows.Forms.CheckBox chk_accounthold;
        private System.Windows.Forms.CheckBox chk_accountopen;
    }
}