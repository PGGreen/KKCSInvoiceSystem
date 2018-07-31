namespace KKCSInvoiceProject
{
    partial class WarningNewAccount
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_addtoaccount = new System.Windows.Forms.Button();
            this.cmd_accountlist = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(837, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "This Rego/Customer is not currently under an account";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MistyRose;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_addtoaccount);
            this.panel1.Controls.Add(this.cmd_accountlist);
            this.panel1.Location = new System.Drawing.Point(58, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(687, 144);
            this.panel1.TabIndex = 1;
            // 
            // btn_addtoaccount
            // 
            this.btn_addtoaccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_addtoaccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addtoaccount.Location = new System.Drawing.Point(19, 78);
            this.btn_addtoaccount.Name = "btn_addtoaccount";
            this.btn_addtoaccount.Size = new System.Drawing.Size(134, 35);
            this.btn_addtoaccount.TabIndex = 1;
            this.btn_addtoaccount.Text = "Add to Account";
            this.btn_addtoaccount.UseVisualStyleBackColor = false;
            this.btn_addtoaccount.Click += new System.EventHandler(this.btn_addtoaccount_Click);
            // 
            // cmd_accountlist
            // 
            this.cmd_accountlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_accountlist.FormattingEnabled = true;
            this.cmd_accountlist.Location = new System.Drawing.Point(19, 26);
            this.cmd_accountlist.Name = "cmd_accountlist";
            this.cmd_accountlist.Size = new System.Drawing.Size(602, 33);
            this.cmd_accountlist.TabIndex = 0;
            this.cmd_accountlist.SelectedIndexChanged += new System.EventHandler(this.cmd_accountlist_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(53, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(346, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Please pick an existing account";
            // 
            // WarningNewAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 293);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "WarningNewAccount";
            this.Text = "WarningNewAccount";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmd_accountlist;
        private System.Windows.Forms.Button btn_addtoaccount;
    }
}