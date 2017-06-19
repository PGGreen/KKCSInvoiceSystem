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
            this.chk_addascredit = new System.Windows.Forms.CheckBox();
            this.txt_refundowed = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pnl_refund = new System.Windows.Forms.Panel();
            this.pnl_credit = new System.Windows.Forms.Panel();
            this.btn_close = new System.Windows.Forms.Button();
            this.pnl_refund.SuspendLayout();
            this.pnl_credit.SuspendLayout();
            this.SuspendLayout();
            // 
            // chk_addascredit
            // 
            this.chk_addascredit.AutoSize = true;
            this.chk_addascredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_addascredit.ForeColor = System.Drawing.Color.Black;
            this.chk_addascredit.Location = new System.Drawing.Point(477, 71);
            this.chk_addascredit.Name = "chk_addascredit";
            this.chk_addascredit.Size = new System.Drawing.Size(309, 29);
            this.chk_addascredit.TabIndex = 152;
            this.chk_addascredit.Text = "ADD AS CREDIT INSTEAD";
            this.chk_addascredit.UseVisualStyleBackColor = true;
            this.chk_addascredit.CheckedChanged += new System.EventHandler(this.chk_addascredit_CheckedChanged);
            // 
            // txt_refundowed
            // 
            this.txt_refundowed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_refundowed.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_refundowed.Location = new System.Drawing.Point(196, 149);
            this.txt_refundowed.Name = "txt_refundowed";
            this.txt_refundowed.Size = new System.Drawing.Size(153, 44);
            this.txt_refundowed.TabIndex = 149;
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Till",
            "Plastic Box"});
            this.comboBox2.Location = new System.Drawing.Point(145, 222);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(156, 28);
            this.comboBox2.TabIndex = 149;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.ForeColor = System.Drawing.Color.Black;
            this.label43.Location = new System.Drawing.Point(10, 225);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(129, 20);
            this.label43.TabIndex = 150;
            this.label43.Text = "From Location:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 25);
            this.label1.TabIndex = 146;
            this.label1.Text = "Refund";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(291, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(264, 37);
            this.label2.TabIndex = 147;
            this.label2.Text = "Customer Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 24);
            this.label3.TabIndex = 153;
            this.label3.Text = "Days Early:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(215, 24);
            this.label4.TabIndex = 154;
            this.label4.Text = "Total Price Already Paid:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 25);
            this.label5.TabIndex = 155;
            this.label5.Text = "Refund Owed: $";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(15, 283);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(298, 54);
            this.button1.TabIndex = 156;
            this.button1.Text = "Click To Confirm Refund";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 25);
            this.label6.TabIndex = 157;
            this.label6.Text = "Current Credit: $";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(24, 203);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(298, 54);
            this.button2.TabIndex = 158;
            this.button2.Text = "Click To Confirm Credit";
            this.button2.UseVisualStyleBackColor = false;
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
            this.label8.Size = new System.Drawing.Size(141, 25);
            this.label8.TabIndex = 161;
            this.label8.Text = "New Credit: $";
            // 
            // pnl_refund
            // 
            this.pnl_refund.BackColor = System.Drawing.Color.White;
            this.pnl_refund.Controls.Add(this.label3);
            this.pnl_refund.Controls.Add(this.label4);
            this.pnl_refund.Controls.Add(this.label5);
            this.pnl_refund.Controls.Add(this.txt_refundowed);
            this.pnl_refund.Controls.Add(this.comboBox2);
            this.pnl_refund.Controls.Add(this.label1);
            this.pnl_refund.Controls.Add(this.label43);
            this.pnl_refund.Controls.Add(this.button1);
            this.pnl_refund.Location = new System.Drawing.Point(12, 106);
            this.pnl_refund.Name = "pnl_refund";
            this.pnl_refund.Size = new System.Drawing.Size(426, 354);
            this.pnl_refund.TabIndex = 162;
            // 
            // pnl_credit
            // 
            this.pnl_credit.BackColor = System.Drawing.Color.White;
            this.pnl_credit.Controls.Add(this.label6);
            this.pnl_credit.Controls.Add(this.button2);
            this.pnl_credit.Controls.Add(this.label8);
            this.pnl_credit.Controls.Add(this.label7);
            this.pnl_credit.Controls.Add(this.textBox1);
            this.pnl_credit.Enabled = false;
            this.pnl_credit.Location = new System.Drawing.Point(477, 106);
            this.pnl_credit.Name = "pnl_credit";
            this.pnl_credit.Size = new System.Drawing.Size(500, 354);
            this.pnl_credit.TabIndex = 163;
            this.pnl_credit.Visible = false;
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.Location = new System.Drawing.Point(408, 499);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(95, 54);
            this.btn_close.TabIndex = 162;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // Refund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 594);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.chk_addascredit);
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
        private System.Windows.Forms.CheckBox chk_addascredit;
        private System.Windows.Forms.TextBox txt_refundowed;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pnl_refund;
        private System.Windows.Forms.Panel pnl_credit;
        private System.Windows.Forms.Button btn_close;
    }
}