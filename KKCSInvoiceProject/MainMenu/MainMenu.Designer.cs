namespace KKCSInvoiceProject
{
    partial class MainMenu
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
            this.btn_invoice = new System.Windows.Forms.Button();
            this.btn_returns = new System.Windows.Forms.Button();
            this.btn_keybox = new System.Windows.Forms.Button();
            this.btn_eod = new System.Windows.Forms.Button();
            this.btn_printcarreturns = new System.Windows.Forms.Button();
            this.pnl_notes = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.ms_mainstrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pettyCashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bankingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tillPBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.financesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_debug = new System.Windows.Forms.Label();
            this.txt_noofcars = new System.Windows.Forms.Label();
            this.cmb_printerpicked = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_template = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pnl_notes.SuspendLayout();
            this.ms_mainstrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_invoice
            // 
            this.btn_invoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_invoice.Font = new System.Drawing.Font("Perpetua Titling MT", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_invoice.Location = new System.Drawing.Point(286, 80);
            this.btn_invoice.Name = "btn_invoice";
            this.btn_invoice.Size = new System.Drawing.Size(187, 50);
            this.btn_invoice.TabIndex = 1;
            this.btn_invoice.Text = "Invoice";
            this.btn_invoice.UseVisualStyleBackColor = false;
            this.btn_invoice.Click += new System.EventHandler(this.btn_invoice_Click);
            // 
            // btn_returns
            // 
            this.btn_returns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_returns.Font = new System.Drawing.Font("Perpetua Titling MT", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_returns.Location = new System.Drawing.Point(495, 80);
            this.btn_returns.Name = "btn_returns";
            this.btn_returns.Size = new System.Drawing.Size(189, 50);
            this.btn_returns.TabIndex = 2;
            this.btn_returns.Text = "Returns";
            this.btn_returns.UseVisualStyleBackColor = false;
            this.btn_returns.Click += new System.EventHandler(this.btn_returns_Click);
            // 
            // btn_keybox
            // 
            this.btn_keybox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_keybox.Font = new System.Drawing.Font("Perpetua Titling MT", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_keybox.Location = new System.Drawing.Point(704, 79);
            this.btn_keybox.Name = "btn_keybox";
            this.btn_keybox.Size = new System.Drawing.Size(189, 50);
            this.btn_keybox.TabIndex = 3;
            this.btn_keybox.Text = "Key Box";
            this.btn_keybox.UseVisualStyleBackColor = false;
            this.btn_keybox.Click += new System.EventHandler(this.btn_keybox_Click);
            // 
            // btn_eod
            // 
            this.btn_eod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_eod.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_eod.Location = new System.Drawing.Point(1053, 136);
            this.btn_eod.Name = "btn_eod";
            this.btn_eod.Size = new System.Drawing.Size(98, 45);
            this.btn_eod.TabIndex = 11;
            this.btn_eod.Text = "End Day";
            this.btn_eod.UseVisualStyleBackColor = false;
            this.btn_eod.Click += new System.EventHandler(this.btn_eod_Click);
            // 
            // btn_printcarreturns
            // 
            this.btn_printcarreturns.BackColor = System.Drawing.Color.Black;
            this.btn_printcarreturns.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_printcarreturns.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_printcarreturns.Location = new System.Drawing.Point(583, 175);
            this.btn_printcarreturns.Name = "btn_printcarreturns";
            this.btn_printcarreturns.Size = new System.Drawing.Size(234, 45);
            this.btn_printcarreturns.TabIndex = 17;
            this.btn_printcarreturns.Text = "Print Car Returns";
            this.btn_printcarreturns.UseVisualStyleBackColor = false;
            this.btn_printcarreturns.Click += new System.EventHandler(this.btn_printcarreturns_Click);
            // 
            // pnl_notes
            // 
            this.pnl_notes.AutoScroll = true;
            this.pnl_notes.BackColor = System.Drawing.Color.Azure;
            this.pnl_notes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_notes.Controls.Add(this.button1);
            this.pnl_notes.Controls.Add(this.txt_template);
            this.pnl_notes.Controls.Add(this.label3);
            this.pnl_notes.Location = new System.Drawing.Point(17, 262);
            this.pnl_notes.Name = "pnl_notes";
            this.pnl_notes.Size = new System.Drawing.Size(1331, 542);
            this.pnl_notes.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Eras Bold ITC", 18F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(602, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Notes";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // ms_mainstrip
            // 
            this.ms_mainstrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ms_mainstrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.pettyCashToolStripMenuItem,
            this.bankingToolStripMenuItem,
            this.bookingsToolStripMenuItem,
            this.accountsToolStripMenuItem,
            this.tillPBToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.testToolStripMenuItem});
            this.ms_mainstrip.Location = new System.Drawing.Point(0, 0);
            this.ms_mainstrip.Name = "ms_mainstrip";
            this.ms_mainstrip.Size = new System.Drawing.Size(1371, 25);
            this.ms_mainstrip.TabIndex = 26;
            this.ms_mainstrip.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(39, 21);
            this.toolStripMenuItem1.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // pettyCashToolStripMenuItem
            // 
            this.pettyCashToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.pettyCashToolStripMenuItem.Name = "pettyCashToolStripMenuItem";
            this.pettyCashToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.pettyCashToolStripMenuItem.Text = "Petty Cash";
            this.pettyCashToolStripMenuItem.Click += new System.EventHandler(this.pettyCashToolStripMenuItem_Click);
            // 
            // bankingToolStripMenuItem
            // 
            this.bankingToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bankingToolStripMenuItem.Name = "bankingToolStripMenuItem";
            this.bankingToolStripMenuItem.Size = new System.Drawing.Size(65, 21);
            this.bankingToolStripMenuItem.Text = "Banking";
            this.bankingToolStripMenuItem.Click += new System.EventHandler(this.bankingToolStripMenuItem_Click);
            // 
            // bookingsToolStripMenuItem
            // 
            this.bookingsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bookingsToolStripMenuItem.Name = "bookingsToolStripMenuItem";
            this.bookingsToolStripMenuItem.Size = new System.Drawing.Size(73, 21);
            this.bookingsToolStripMenuItem.Text = "Bookings";
            this.bookingsToolStripMenuItem.Click += new System.EventHandler(this.bookingsToolStripMenuItem_Click);
            // 
            // accountsToolStripMenuItem
            // 
            this.accountsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.accountsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountsToolStripMenuItem1,
            this.newAccountToolStripMenuItem});
            this.accountsToolStripMenuItem.Name = "accountsToolStripMenuItem";
            this.accountsToolStripMenuItem.Size = new System.Drawing.Size(72, 21);
            this.accountsToolStripMenuItem.Text = "Accounts";
            // 
            // accountsToolStripMenuItem1
            // 
            this.accountsToolStripMenuItem1.Name = "accountsToolStripMenuItem1";
            this.accountsToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.accountsToolStripMenuItem1.Text = "Accounts";
            this.accountsToolStripMenuItem1.Click += new System.EventHandler(this.accountsToolStripMenuItem1_Click);
            // 
            // newAccountToolStripMenuItem
            // 
            this.newAccountToolStripMenuItem.Name = "newAccountToolStripMenuItem";
            this.newAccountToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newAccountToolStripMenuItem.Text = "New Account";
            this.newAccountToolStripMenuItem.Click += new System.EventHandler(this.newAccountToolStripMenuItem_Click);
            // 
            // tillPBToolStripMenuItem
            // 
            this.tillPBToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tillPBToolStripMenuItem.Name = "tillPBToolStripMenuItem";
            this.tillPBToolStripMenuItem.Size = new System.Drawing.Size(81, 21);
            this.tillPBToolStripMenuItem.Text = "Till <-> PB";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionToolStripMenuItem,
            this.statisticsToolStripMenuItem1,
            this.financesToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(55, 21);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // versionToolStripMenuItem
            // 
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.versionToolStripMenuItem.Text = "Version";
            this.versionToolStripMenuItem.Click += new System.EventHandler(this.versionToolStripMenuItem_Click);
            // 
            // statisticsToolStripMenuItem1
            // 
            this.statisticsToolStripMenuItem1.Name = "statisticsToolStripMenuItem1";
            this.statisticsToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.statisticsToolStripMenuItem1.Text = "Statistics";
            // 
            // financesToolStripMenuItem1
            // 
            this.financesToolStripMenuItem1.Name = "financesToolStripMenuItem1";
            this.financesToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.financesToolStripMenuItem1.Text = "Finances";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.tEstToolStripMenuItem_Click);
            // 
            // lbl_debug
            // 
            this.lbl_debug.AutoSize = true;
            this.lbl_debug.BackColor = System.Drawing.Color.Black;
            this.lbl_debug.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_debug.ForeColor = System.Drawing.Color.White;
            this.lbl_debug.Location = new System.Drawing.Point(10, 142);
            this.lbl_debug.Name = "lbl_debug";
            this.lbl_debug.Size = new System.Drawing.Size(458, 39);
            this.lbl_debug.TabIndex = 29;
            this.lbl_debug.Text = "WARNING: DEBUG MODE";
            // 
            // txt_noofcars
            // 
            this.txt_noofcars.AutoSize = true;
            this.txt_noofcars.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_noofcars.ForeColor = System.Drawing.Color.Red;
            this.txt_noofcars.Location = new System.Drawing.Point(606, 220);
            this.txt_noofcars.Name = "txt_noofcars";
            this.txt_noofcars.Size = new System.Drawing.Size(196, 39);
            this.txt_noofcars.TabIndex = 231;
            this.txt_noofcars.Text = "35/70 Cars";
            // 
            // cmb_printerpicked
            // 
            this.cmb_printerpicked.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_printerpicked.FormattingEnabled = true;
            this.cmb_printerpicked.Items.AddRange(new object[] {
            "Colour (Small Printer)",
            "B&W (Large Printer)"});
            this.cmb_printerpicked.Location = new System.Drawing.Point(583, 136);
            this.cmb_printerpicked.Name = "cmb_printerpicked";
            this.cmb_printerpicked.Size = new System.Drawing.Size(234, 32);
            this.cmb_printerpicked.TabIndex = 232;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button3.Font = new System.Drawing.Font("Perpetua Titling MT", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(916, 79);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(235, 51);
            this.button3.TabIndex = 233;
            this.button3.Text = "Long Term";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Perpetua Titling MT", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(412, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(615, 32);
            this.label1.TabIndex = 234;
            this.label1.Text = "Kerikeri Car Storage Invoice System";
            // 
            // txt_template
            // 
            this.txt_template.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_template.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_template.Location = new System.Drawing.Point(23, 49);
            this.txt_template.Multiline = true;
            this.txt_template.Name = "txt_template";
            this.txt_template.ReadOnly = true;
            this.txt_template.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_template.Size = new System.Drawing.Size(280, 150);
            this.txt_template.TabIndex = 1;
            this.txt_template.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Mark As Closed";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1371, 816);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.cmb_printerpicked);
            this.Controls.Add(this.txt_noofcars);
            this.Controls.Add(this.lbl_debug);
            this.Controls.Add(this.pnl_notes);
            this.Controls.Add(this.btn_printcarreturns);
            this.Controls.Add(this.btn_eod);
            this.Controls.Add(this.btn_keybox);
            this.Controls.Add(this.btn_returns);
            this.Controls.Add(this.btn_invoice);
            this.Controls.Add(this.ms_mainstrip);
            this.MainMenuStrip = this.ms_mainstrip;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu";
            this.pnl_notes.ResumeLayout(false);
            this.pnl_notes.PerformLayout();
            this.ms_mainstrip.ResumeLayout(false);
            this.ms_mainstrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_invoice;
        private System.Windows.Forms.Button btn_returns;
        private System.Windows.Forms.Button btn_keybox;
        private System.Windows.Forms.Button btn_eod;
        private System.Windows.Forms.Button btn_printcarreturns;
        private System.Windows.Forms.Panel pnl_notes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip ms_mainstrip;
        private System.Windows.Forms.ToolStripMenuItem pettyCashToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bankingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tillPBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
        private System.Windows.Forms.Label lbl_debug;
        private System.Windows.Forms.Label txt_noofcars;
        private System.Windows.Forms.ComboBox cmb_printerpicked;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem statisticsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem financesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem accountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountsToolStripMenuItem1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_template;
        private System.Windows.Forms.Button button1;
    }
}