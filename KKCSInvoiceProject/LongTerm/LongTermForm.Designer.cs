namespace KKCSInvoiceProject
{
    partial class LongTermForm
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
            this.lbl_ltinvoice = new System.Windows.Forms.Label();
            this.txtBox_carin = new System.Windows.Forms.TextBox();
            this.txtBox_carout = new System.Windows.Forms.TextBox();
            this.lbl_customername = new System.Windows.Forms.Label();
            this.btn_editcustomerfile = new System.Windows.Forms.Button();
            this.pnl_staytemplate = new System.Windows.Forms.Panel();
            this.txtBox_notes = new System.Windows.Forms.TextBox();
            this.btn_savestay = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmb_rego = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_carstatus = new System.Windows.Forms.Label();
            this.pnl_staytemplate.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_ltinvoice
            // 
            this.lbl_ltinvoice.AutoSize = true;
            this.lbl_ltinvoice.BackColor = System.Drawing.Color.MistyRose;
            this.lbl_ltinvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ltinvoice.ForeColor = System.Drawing.Color.Blue;
            this.lbl_ltinvoice.Location = new System.Drawing.Point(804, 5);
            this.lbl_ltinvoice.Name = "lbl_ltinvoice";
            this.lbl_ltinvoice.Size = new System.Drawing.Size(54, 13);
            this.lbl_ltinvoice.TabIndex = 129;
            this.lbl_ltinvoice.Text = "LT1-001";
            // 
            // txtBox_carin
            // 
            this.txtBox_carin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtBox_carin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_carin.Location = new System.Drawing.Point(25, 49);
            this.txtBox_carin.Name = "txtBox_carin";
            this.txtBox_carin.Size = new System.Drawing.Size(170, 31);
            this.txtBox_carin.TabIndex = 129;
            this.txtBox_carin.Text = "DD/MM/YY";
            this.txtBox_carin.TextChanged += new System.EventHandler(this.txtBox_carin_TextChanged);
            // 
            // txtBox_carout
            // 
            this.txtBox_carout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtBox_carout.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_carout.Location = new System.Drawing.Point(25, 156);
            this.txtBox_carout.Name = "txtBox_carout";
            this.txtBox_carout.Size = new System.Drawing.Size(169, 31);
            this.txtBox_carout.TabIndex = 129;
            this.txtBox_carout.Text = "DD/MM/YY";
            this.txtBox_carout.TextChanged += new System.EventHandler(this.txtBox_carout_TextChanged);
            // 
            // lbl_customername
            // 
            this.lbl_customername.AutoSize = true;
            this.lbl_customername.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_customername.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_customername.Location = new System.Drawing.Point(17, 23);
            this.lbl_customername.Name = "lbl_customername";
            this.lbl_customername.Size = new System.Drawing.Size(256, 33);
            this.lbl_customername.TabIndex = 131;
            this.lbl_customername.Text = "Customer Details";
            // 
            // btn_editcustomerfile
            // 
            this.btn_editcustomerfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editcustomerfile.Location = new System.Drawing.Point(938, 12);
            this.btn_editcustomerfile.Name = "btn_editcustomerfile";
            this.btn_editcustomerfile.Size = new System.Drawing.Size(183, 35);
            this.btn_editcustomerfile.TabIndex = 132;
            this.btn_editcustomerfile.Text = "Edit Customer File";
            this.btn_editcustomerfile.UseVisualStyleBackColor = true;
            // 
            // pnl_staytemplate
            // 
            this.pnl_staytemplate.BackColor = System.Drawing.Color.MistyRose;
            this.pnl_staytemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_staytemplate.Controls.Add(this.label1);
            this.pnl_staytemplate.Controls.Add(this.textBox1);
            this.pnl_staytemplate.Controls.Add(this.txtBox_notes);
            this.pnl_staytemplate.Controls.Add(this.btn_savestay);
            this.pnl_staytemplate.Controls.Add(this.label10);
            this.pnl_staytemplate.Controls.Add(this.label9);
            this.pnl_staytemplate.Controls.Add(this.label8);
            this.pnl_staytemplate.Controls.Add(this.cmb_rego);
            this.pnl_staytemplate.Controls.Add(this.lbl_ltinvoice);
            this.pnl_staytemplate.Controls.Add(this.txtBox_carin);
            this.pnl_staytemplate.Controls.Add(this.txtBox_carout);
            this.pnl_staytemplate.Location = new System.Drawing.Point(23, 141);
            this.pnl_staytemplate.Name = "pnl_staytemplate";
            this.pnl_staytemplate.Size = new System.Drawing.Size(863, 253);
            this.pnl_staytemplate.TabIndex = 129;
            // 
            // txtBox_notes
            // 
            this.txtBox_notes.Location = new System.Drawing.Point(25, 210);
            this.txtBox_notes.Multiline = true;
            this.txtBox_notes.Name = "txtBox_notes";
            this.txtBox_notes.Size = new System.Drawing.Size(100, 29);
            this.txtBox_notes.TabIndex = 135;
            this.txtBox_notes.Visible = false;
            // 
            // btn_savestay
            // 
            this.btn_savestay.BackColor = System.Drawing.Color.Red;
            this.btn_savestay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_savestay.ForeColor = System.Drawing.Color.White;
            this.btn_savestay.Location = new System.Drawing.Point(613, 208);
            this.btn_savestay.Name = "btn_savestay";
            this.btn_savestay.Size = new System.Drawing.Size(123, 40);
            this.btn_savestay.TabIndex = 129;
            this.btn_savestay.Text = "Unsaved";
            this.btn_savestay.UseVisualStyleBackColor = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.MistyRose;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(21, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(472, 25);
            this.label10.TabIndex = 134;
            this.label10.Text = "Date Customer \"Picked Up Car FROM Yard\"\r\n";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.MistyRose;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(21, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(395, 25);
            this.label9.TabIndex = 133;
            this.label9.Text = "Date Customer \"Parked Car IN Yard\"";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(520, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 24);
            this.label8.TabIndex = 129;
            this.label8.Text = "Rego:";
            // 
            // cmb_rego
            // 
            this.cmb_rego.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_rego.FormattingEnabled = true;
            this.cmb_rego.Location = new System.Drawing.Point(592, 13);
            this.cmb_rego.Name = "cmb_rego";
            this.cmb_rego.Size = new System.Drawing.Size(153, 28);
            this.cmb_rego.TabIndex = 130;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(524, 98);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(300, 104);
            this.textBox1.TabIndex = 136;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(520, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 24);
            this.label1.TabIndex = 137;
            this.label1.Text = "Note:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(19, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 29);
            this.label2.TabIndex = 136;
            this.label2.Text = "Current";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(19, 423);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 29);
            this.label3.TabIndex = 137;
            this.label3.Text = "Previous";
            // 
            // lbl_carstatus
            // 
            this.lbl_carstatus.AutoSize = true;
            this.lbl_carstatus.BackColor = System.Drawing.Color.Lime;
            this.lbl_carstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_carstatus.ForeColor = System.Drawing.Color.Black;
            this.lbl_carstatus.Location = new System.Drawing.Point(697, 67);
            this.lbl_carstatus.Name = "lbl_carstatus";
            this.lbl_carstatus.Size = new System.Drawing.Size(185, 31);
            this.lbl_carstatus.TabIndex = 138;
            this.lbl_carstatus.Text = "Car IS In Yard";
            // 
            // LongTermForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1172, 643);
            this.Controls.Add(this.lbl_carstatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnl_staytemplate);
            this.Controls.Add(this.btn_editcustomerfile);
            this.Controls.Add(this.lbl_customername);
            this.Name = "LongTermForm";
            this.Text = "LongTermForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnl_staytemplate.ResumeLayout(false);
            this.pnl_staytemplate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_ltinvoice;
        private System.Windows.Forms.TextBox txtBox_carin;
        private System.Windows.Forms.TextBox txtBox_carout;
        private System.Windows.Forms.Label lbl_customername;
        private System.Windows.Forms.Button btn_editcustomerfile;
        private System.Windows.Forms.Panel pnl_staytemplate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmb_rego;
        private System.Windows.Forms.Button btn_savestay;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBox_notes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_carstatus;
    }
}