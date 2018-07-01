namespace KKCSInvoiceProject
{
    partial class Refund
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
            this.txt_refundowed = new System.Windows.Forms.TextBox();
            this.cmb_location = new System.Windows.Forms.ComboBox();
            this.lbl_from = new System.Windows.Forms.Label();
            this.lbl_typeofrefund = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_daysearly = new System.Windows.Forms.Label();
            this.lbl_daysearl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pnl_refund = new System.Windows.Forms.Panel();
            this.btn_instructions = new System.Windows.Forms.Button();
            this.pnl_credit = new System.Windows.Forms.Panel();
            this.txt_keyno = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txt_invoiceno = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_eftpos = new System.Windows.Forms.Button();
            this.btn_cash = new System.Windows.Forms.Button();
            this.btn_credit = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnl_refund.SuspendLayout();
            this.pnl_credit.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_refundowed
            // 
            this.txt_refundowed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_refundowed.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_refundowed.Location = new System.Drawing.Point(196, 188);
            this.txt_refundowed.Name = "txt_refundowed";
            this.txt_refundowed.Size = new System.Drawing.Size(153, 44);
            this.txt_refundowed.TabIndex = 149;
            // 
            // cmb_location
            // 
            this.cmb_location.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_location.FormattingEnabled = true;
            this.cmb_location.Items.AddRange(new object[] {
            "Till",
            "Plastic Box"});
            this.cmb_location.Location = new System.Drawing.Point(145, 261);
            this.cmb_location.Name = "cmb_location";
            this.cmb_location.Size = new System.Drawing.Size(156, 28);
            this.cmb_location.TabIndex = 149;
            // 
            // lbl_from
            // 
            this.lbl_from.AutoSize = true;
            this.lbl_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_from.ForeColor = System.Drawing.Color.Black;
            this.lbl_from.Location = new System.Drawing.Point(10, 264);
            this.lbl_from.Name = "lbl_from";
            this.lbl_from.Size = new System.Drawing.Size(129, 20);
            this.lbl_from.TabIndex = 150;
            this.lbl_from.Text = "From Location:";
            // 
            // lbl_typeofrefund
            // 
            this.lbl_typeofrefund.AutoSize = true;
            this.lbl_typeofrefund.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_typeofrefund.Location = new System.Drawing.Point(10, 12);
            this.lbl_typeofrefund.Name = "lbl_typeofrefund";
            this.lbl_typeofrefund.Size = new System.Drawing.Size(161, 25);
            this.lbl_typeofrefund.TabIndex = 146;
            this.lbl_typeofrefund.Text = "Eftpos Refund";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(405, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(264, 37);
            this.label2.TabIndex = 147;
            this.label2.Text = "Customer Name";
            // 
            // lbl_daysearly
            // 
            this.lbl_daysearly.AutoSize = true;
            this.lbl_daysearly.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_daysearly.Location = new System.Drawing.Point(10, 47);
            this.lbl_daysearly.Name = "lbl_daysearly";
            this.lbl_daysearly.Size = new System.Drawing.Size(120, 24);
            this.lbl_daysearly.TabIndex = 153;
            this.lbl_daysearly.Text = "Original Stay:";
            // 
            // lbl_daysearl
            // 
            this.lbl_daysearl.AutoSize = true;
            this.lbl_daysearl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_daysearl.Location = new System.Drawing.Point(10, 101);
            this.lbl_daysearl.Name = "lbl_daysearl";
            this.lbl_daysearl.Size = new System.Drawing.Size(103, 24);
            this.lbl_daysearl.TabIndex = 154;
            this.lbl_daysearl.Text = "Days Early:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 25);
            this.label5.TabIndex = 155;
            this.label5.Text = "Refund Owed: $";
            // 
            // btn_confirm
            // 
            this.btn_confirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_confirm.Location = new System.Drawing.Point(22, 616);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(298, 54);
            this.btn_confirm.TabIndex = 156;
            this.btn_confirm.Text = "Click To Confirm Refund";
            this.btn_confirm.UseVisualStyleBackColor = false;
            this.btn_confirm.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(279, 25);
            this.label6.TabIndex = 157;
            this.label6.Text = "Customers Current Credit: $";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(270, 71);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(127, 44);
            this.textBox1.TabIndex = 159;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(19, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(245, 25);
            this.label7.TabIndex = 160;
            this.label7.Text = "Credit To Be Added: $";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(19, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(195, 25);
            this.label8.TabIndex = 161;
            this.label8.Text = "New Total Credit: $";
            // 
            // pnl_refund
            // 
            this.pnl_refund.BackColor = System.Drawing.Color.White;
            this.pnl_refund.Controls.Add(this.btn_instructions);
            this.pnl_refund.Controls.Add(this.lbl_daysearly);
            this.pnl_refund.Controls.Add(this.lbl_daysearl);
            this.pnl_refund.Controls.Add(this.label5);
            this.pnl_refund.Controls.Add(this.txt_refundowed);
            this.pnl_refund.Controls.Add(this.cmb_location);
            this.pnl_refund.Controls.Add(this.lbl_typeofrefund);
            this.pnl_refund.Controls.Add(this.lbl_from);
            this.pnl_refund.Location = new System.Drawing.Point(22, 220);
            this.pnl_refund.Name = "pnl_refund";
            this.pnl_refund.Size = new System.Drawing.Size(426, 380);
            this.pnl_refund.TabIndex = 162;
            this.pnl_refund.Visible = false;
            // 
            // btn_instructions
            // 
            this.btn_instructions.BackColor = System.Drawing.Color.Red;
            this.btn_instructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_instructions.ForeColor = System.Drawing.Color.White;
            this.btn_instructions.Location = new System.Drawing.Point(245, 10);
            this.btn_instructions.Name = "btn_instructions";
            this.btn_instructions.Size = new System.Drawing.Size(165, 159);
            this.btn_instructions.TabIndex = 173;
            this.btn_instructions.Text = "\"CLICK HERE\" FOR INSTRUCTIONS ON HOW \r\nTO REFUND VIA EFTPOS";
            this.btn_instructions.UseVisualStyleBackColor = false;
            this.btn_instructions.Visible = false;
            // 
            // pnl_credit
            // 
            this.pnl_credit.BackColor = System.Drawing.Color.White;
            this.pnl_credit.Controls.Add(this.label6);
            this.pnl_credit.Controls.Add(this.label8);
            this.pnl_credit.Controls.Add(this.label7);
            this.pnl_credit.Controls.Add(this.textBox1);
            this.pnl_credit.Location = new System.Drawing.Point(468, 220);
            this.pnl_credit.Name = "pnl_credit";
            this.pnl_credit.Size = new System.Drawing.Size(423, 380);
            this.pnl_credit.TabIndex = 163;
            this.pnl_credit.Visible = false;
            // 
            // txt_keyno
            // 
            this.txt_keyno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txt_keyno.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_keyno.Location = new System.Drawing.Point(296, 14);
            this.txt_keyno.Name = "txt_keyno";
            this.txt_keyno.Size = new System.Drawing.Size(75, 38);
            this.txt_keyno.TabIndex = 167;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(213, 15);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 31);
            this.label18.TabIndex = 166;
            this.label18.Text = "KEY:";
            // 
            // txt_invoiceno
            // 
            this.txt_invoiceno.BackColor = System.Drawing.Color.White;
            this.txt_invoiceno.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_invoiceno.Location = new System.Drawing.Point(93, 12);
            this.txt_invoiceno.Name = "txt_invoiceno";
            this.txt_invoiceno.Size = new System.Drawing.Size(95, 38);
            this.txt_invoiceno.TabIndex = 164;
            this.txt_invoiceno.Text = "00000";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(726, 58);
            this.label9.TabIndex = 168;
            this.label9.Text = "The Customer is owed a                 refund for coming in early. \r\nPlease selec" +
    "t the suitable option below:\r\n";
            // 
            // btn_eftpos
            // 
            this.btn_eftpos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_eftpos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_eftpos.Location = new System.Drawing.Point(20, 139);
            this.btn_eftpos.Name = "btn_eftpos";
            this.btn_eftpos.Size = new System.Drawing.Size(186, 57);
            this.btn_eftpos.TabIndex = 169;
            this.btn_eftpos.Text = "Eftpos Refund";
            this.btn_eftpos.UseVisualStyleBackColor = false;
            this.btn_eftpos.Click += new System.EventHandler(this.btn_eftpos_Click);
            // 
            // btn_cash
            // 
            this.btn_cash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_cash.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cash.Location = new System.Drawing.Point(221, 139);
            this.btn_cash.Name = "btn_cash";
            this.btn_cash.Size = new System.Drawing.Size(186, 57);
            this.btn_cash.TabIndex = 170;
            this.btn_cash.Text = "Cash Refund";
            this.btn_cash.UseVisualStyleBackColor = false;
            this.btn_cash.Click += new System.EventHandler(this.btn_cash_Click);
            // 
            // btn_credit
            // 
            this.btn_credit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_credit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_credit.Location = new System.Drawing.Point(418, 139);
            this.btn_credit.Name = "btn_credit";
            this.btn_credit.Size = new System.Drawing.Size(186, 57);
            this.btn_credit.TabIndex = 171;
            this.btn_credit.Text = "+ Add as Credit";
            this.btn_credit.UseVisualStyleBackColor = false;
            this.btn_credit.Click += new System.EventHandler(this.btn_credit_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Lime;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(314, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 29);
            this.label10.TabIndex = 172;
            this.label10.Text = "$000.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 31);
            this.label3.TabIndex = 165;
            this.label3.Text = "INV:";
            // 
            // Refund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 699);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btn_credit);
            this.Controls.Add(this.btn_cash);
            this.Controls.Add(this.btn_eftpos);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_keyno);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.btn_confirm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_invoiceno);
            this.Controls.Add(this.pnl_credit);
            this.Controls.Add(this.pnl_refund);
            this.Controls.Add(this.label2);
            this.Name = "Refund";
            this.Text = "Refund";
            this.pnl_refund.ResumeLayout(false);
            this.pnl_refund.PerformLayout();
            this.pnl_credit.ResumeLayout(false);
            this.pnl_credit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_refundowed;
        private System.Windows.Forms.ComboBox cmb_location;
        private System.Windows.Forms.Label lbl_from;
        private System.Windows.Forms.Label lbl_typeofrefund;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_daysearly;
        private System.Windows.Forms.Label lbl_daysearl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_confirm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pnl_refund;
        private System.Windows.Forms.Panel pnl_credit;
        private System.Windows.Forms.TextBox txt_keyno;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txt_invoiceno;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_eftpos;
        private System.Windows.Forms.Button btn_cash;
        private System.Windows.Forms.Button btn_credit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_instructions;
        private System.Windows.Forms.Label label3;
    }
}