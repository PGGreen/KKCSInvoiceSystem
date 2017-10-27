namespace KKCSInvoiceProject
{
    partial class CustomerShow
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
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_price = new System.Windows.Forms.Label();
            this.lbl_ccfee = new System.Windows.Forms.Label();
            this.lbl_paidby = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.pnl_invoice = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dt_returndate = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dt_datein = new System.Windows.Forms.TextBox();
            this.txt_carmake = new System.Windows.Forms.TextBox();
            this.txt_carrego = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnl_invoice.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(438, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Your Invoice";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(225, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(225, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 33);
            this.label4.TabIndex = 3;
            this.label4.Text = "Car Rego:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(225, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 33);
            this.label5.TabIndex = 4;
            this.label5.Text = "Car Make:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(131, 322);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 33);
            this.label8.TabIndex = 7;
            this.label8.Text = "5 Days";
            // 
            // lbl_price
            // 
            this.lbl_price.AutoSize = true;
            this.lbl_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_price.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbl_price.Location = new System.Drawing.Point(374, 351);
            this.lbl_price.Name = "lbl_price";
            this.lbl_price.Size = new System.Drawing.Size(343, 108);
            this.lbl_price.TabIndex = 8;
            this.lbl_price.Text = "$27.00";
            this.lbl_price.Visible = false;
            // 
            // lbl_ccfee
            // 
            this.lbl_ccfee.AutoSize = true;
            this.lbl_ccfee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ccfee.Location = new System.Drawing.Point(465, 444);
            this.lbl_ccfee.Name = "lbl_ccfee";
            this.lbl_ccfee.Size = new System.Drawing.Size(225, 20);
            this.lbl_ccfee.TabIndex = 186;
            this.lbl_ccfee.Text = "(Credit Card fee of 2% applies)";
            this.lbl_ccfee.Visible = false;
            // 
            // lbl_paidby
            // 
            this.lbl_paidby.AutoSize = true;
            this.lbl_paidby.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_paidby.Location = new System.Drawing.Point(699, 390);
            this.lbl_paidby.Name = "lbl_paidby";
            this.lbl_paidby.Size = new System.Drawing.Size(238, 33);
            this.lbl_paidby.TabIndex = 187;
            this.lbl_paidby.Text = "Paid By: To Pay";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(442, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 33);
            this.label3.TabIndex = 188;
            this.label3.Text = "--->";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(440, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(230, 37);
            this.label12.TabIndex = 189;
            this.label12.Text = "Parking Costs";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::KKCSInvoiceProject.Properties.Resources.Car_Storage_Logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(94, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(216, 202);
            this.pictureBox1.TabIndex = 190;
            this.pictureBox1.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(440, 82);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(259, 111);
            this.label13.TabIndex = 191;
            this.label13.Text = "First Day:\r\n2-7 Days:\r\nDays thereafter:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(76, 217);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(255, 37);
            this.label14.TabIndex = 192;
            this.label14.Text = "Welcomes You!";
            // 
            // pnl_invoice
            // 
            this.pnl_invoice.BackColor = System.Drawing.Color.Linen;
            this.pnl_invoice.Controls.Add(this.label16);
            this.pnl_invoice.Controls.Add(this.label7);
            this.pnl_invoice.Controls.Add(this.dt_returndate);
            this.pnl_invoice.Controls.Add(this.label15);
            this.pnl_invoice.Controls.Add(this.dt_datein);
            this.pnl_invoice.Controls.Add(this.label8);
            this.pnl_invoice.Controls.Add(this.lbl_paidby);
            this.pnl_invoice.Controls.Add(this.txt_carmake);
            this.pnl_invoice.Controls.Add(this.lbl_ccfee);
            this.pnl_invoice.Controls.Add(this.txt_carrego);
            this.pnl_invoice.Controls.Add(this.txt_name);
            this.pnl_invoice.Controls.Add(this.lbl_price);
            this.pnl_invoice.Controls.Add(this.label1);
            this.pnl_invoice.Controls.Add(this.label6);
            this.pnl_invoice.Controls.Add(this.label3);
            this.pnl_invoice.Controls.Add(this.label5);
            this.pnl_invoice.Controls.Add(this.label2);
            this.pnl_invoice.Controls.Add(this.label4);
            this.pnl_invoice.Location = new System.Drawing.Point(94, 276);
            this.pnl_invoice.Name = "pnl_invoice";
            this.pnl_invoice.Size = new System.Drawing.Size(1144, 469);
            this.pnl_invoice.TabIndex = 193;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(52, 322);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 33);
            this.label16.TabIndex = 196;
            this.label16.Text = "Stay:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(228, 412);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(163, 33);
            this.label7.TabIndex = 195;
            this.label7.Text = "Total Price:";
            // 
            // dt_returndate
            // 
            this.dt_returndate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_returndate.Location = new System.Drawing.Point(673, 275);
            this.dt_returndate.Name = "dt_returndate";
            this.dt_returndate.Size = new System.Drawing.Size(396, 38);
            this.dt_returndate.TabIndex = 194;
            this.dt_returndate.TextChanged += new System.EventHandler(this.dt_returndate_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(498, 278);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(179, 33);
            this.label15.TabIndex = 193;
            this.label15.Text = "Return Date:";
            // 
            // dt_datein
            // 
            this.dt_datein.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_datein.Location = new System.Drawing.Point(170, 276);
            this.dt_datein.Name = "dt_datein";
            this.dt_datein.Size = new System.Drawing.Size(269, 38);
            this.dt_datein.TabIndex = 192;
            this.dt_datein.TextChanged += new System.EventHandler(this.dt_datein_TextChanged);
            // 
            // txt_carmake
            // 
            this.txt_carmake.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_carmake.Location = new System.Drawing.Point(382, 213);
            this.txt_carmake.Name = "txt_carmake";
            this.txt_carmake.Size = new System.Drawing.Size(371, 38);
            this.txt_carmake.TabIndex = 191;
            this.txt_carmake.TextChanged += new System.EventHandler(this.txt_carmake_TextChanged);
            // 
            // txt_carrego
            // 
            this.txt_carrego.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_carrego.Location = new System.Drawing.Point(382, 152);
            this.txt_carrego.Name = "txt_carrego";
            this.txt_carrego.Size = new System.Drawing.Size(371, 38);
            this.txt_carrego.TabIndex = 190;
            this.txt_carrego.TextChanged += new System.EventHandler(this.txt_carrego_TextChanged);
            // 
            // txt_name
            // 
            this.txt_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_name.Location = new System.Drawing.Point(382, 90);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(371, 38);
            this.txt_name.TabIndex = 189;
            this.txt_name.TextChanged += new System.EventHandler(this.txt_name_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(51, 278);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 33);
            this.label6.TabIndex = 5;
            this.label6.Text = "Date In:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(702, 82);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(120, 111);
            this.label17.TabIndex = 194;
            this.label17.Text = "$15.00\r\n$12.00\r\n$10.00\r\n";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(443, 202);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(425, 20);
            this.label18.TabIndex = 195;
            this.label18.Text = "2% charge applies for every Credit Card Transaction";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(817, 82);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(183, 31);
            this.label19.TabIndex = 196;
            this.label19.Text = "(per 24 hours)";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(817, 117);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(183, 31);
            this.label20.TabIndex = 197;
            this.label20.Text = "(per 24 hours)";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(815, 154);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(183, 31);
            this.label21.TabIndex = 198;
            this.label21.Text = "(per 24 hours)";
            // 
            // CustomerShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1320, 757);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.pnl_invoice);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.pictureBox1);
            this.Name = "CustomerShow";
            this.Text = "Customer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnl_invoice.ResumeLayout(false);
            this.pnl_invoice.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_price;
        private System.Windows.Forms.Label lbl_ccfee;
        private System.Windows.Forms.Label lbl_paidby;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel pnl_invoice;
        private System.Windows.Forms.TextBox txt_carmake;
        private System.Windows.Forms.TextBox txt_carrego;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox dt_returndate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox dt_datein;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
    }
}