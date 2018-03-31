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
            this.lbl_carreturns = new System.Windows.Forms.Label();
            this.cmd_accountlist = new System.Windows.Forms.ComboBox();
            this.chk_accountholder = new System.Windows.Forms.CheckBox();
            this.chk_accountinvoices = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_carreturns
            // 
            this.lbl_carreturns.AutoSize = true;
            this.lbl_carreturns.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_carreturns.Location = new System.Drawing.Point(317, 19);
            this.lbl_carreturns.Name = "lbl_carreturns";
            this.lbl_carreturns.Size = new System.Drawing.Size(135, 31);
            this.lbl_carreturns.TabIndex = 2;
            this.lbl_carreturns.Text = "Accounts";
            // 
            // cmd_accountlist
            // 
            this.cmd_accountlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_accountlist.FormattingEnabled = true;
            this.cmd_accountlist.Location = new System.Drawing.Point(19, 67);
            this.cmd_accountlist.Name = "cmd_accountlist";
            this.cmd_accountlist.Size = new System.Drawing.Size(606, 33);
            this.cmd_accountlist.TabIndex = 82;
            // 
            // chk_accountholder
            // 
            this.chk_accountholder.AutoSize = true;
            this.chk_accountholder.Checked = true;
            this.chk_accountholder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_accountholder.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_accountholder.Location = new System.Drawing.Point(19, 106);
            this.chk_accountholder.Name = "chk_accountholder";
            this.chk_accountholder.Size = new System.Drawing.Size(243, 28);
            this.chk_accountholder.TabIndex = 83;
            this.chk_accountholder.Text = "Show Account Holders";
            this.chk_accountholder.UseVisualStyleBackColor = true;
            // 
            // chk_accountinvoices
            // 
            this.chk_accountinvoices.AutoSize = true;
            this.chk_accountinvoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_accountinvoices.Location = new System.Drawing.Point(378, 106);
            this.chk_accountinvoices.Name = "chk_accountinvoices";
            this.chk_accountinvoices.Size = new System.Drawing.Size(247, 28);
            this.chk_accountinvoices.TabIndex = 84;
            this.chk_accountinvoices.Text = "Show Account Invoices";
            this.chk_accountinvoices.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(641, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 33);
            this.button1.TabIndex = 85;
            this.button1.Text = "Edit Base Account";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(807, 20);
            this.label1.TabIndex = 86;
            this.label1.Text = "---------------------------------------------------------------------------------" +
    "----------------------------------------------------";
            // 
            // Accounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1240, 730);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chk_accountinvoices);
            this.Controls.Add(this.chk_accountholder);
            this.Controls.Add(this.cmd_accountlist);
            this.Controls.Add(this.lbl_carreturns);
            this.Name = "Accounts";
            this.Text = "+";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_carreturns;
        private System.Windows.Forms.ComboBox cmd_accountlist;
        private System.Windows.Forms.CheckBox chk_accountholder;
        private System.Windows.Forms.CheckBox chk_accountinvoices;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}