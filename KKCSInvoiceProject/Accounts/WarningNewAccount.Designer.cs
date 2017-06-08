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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_createnewaccount = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
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
            this.panel1.Location = new System.Drawing.Point(58, 134);
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
            this.label2.Location = new System.Drawing.Point(53, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(290, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "1. Add to Existing Account";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(52, 313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 31);
            this.label3.TabIndex = 3;
            this.label3.Text = "Or";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(53, 398);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "2. ";
            // 
            // btn_createnewaccount
            // 
            this.btn_createnewaccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_createnewaccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_createnewaccount.Location = new System.Drawing.Point(98, 387);
            this.btn_createnewaccount.Name = "btn_createnewaccount";
            this.btn_createnewaccount.Size = new System.Drawing.Size(371, 46);
            this.btn_createnewaccount.TabIndex = 5;
            this.btn_createnewaccount.Text = "CREATE NEW ACCOUNT";
            this.btn_createnewaccount.UseVisualStyleBackColor = false;
            this.btn_createnewaccount.Click += new System.EventHandler(this.btn_createnewaccount_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(98, 536);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(245, 34);
            this.button3.TabIndex = 6;
            this.button3.Text = "Fill Out Paper Account Form";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(52, 469);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 31);
            this.label5.TabIndex = 7;
            this.label5.Text = "Or";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(53, 540);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 25);
            this.label6.TabIndex = 8;
            this.label6.Text = "3. ";
            // 
            // WarningNewAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 623);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btn_createnewaccount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_createnewaccount;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}