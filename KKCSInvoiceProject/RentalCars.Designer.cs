namespace KKCSInvoiceProject
{
    partial class RentalCars
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
            this.txt_rego = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chk_service = new System.Windows.Forms.CheckBox();
            this.chk_reg = new System.Windows.Forms.CheckBox();
            this.reg_cof = new System.Windows.Forms.CheckBox();
            this.dt_reg = new System.Windows.Forms.DateTimePicker();
            this.dt_cof = new System.Windows.Forms.DateTimePicker();
            this.txt_mileage = new System.Windows.Forms.TextBox();
            this.lbl_mil = new System.Windows.Forms.Label();
            this.lbl_acheck = new System.Windows.Forms.Label();
            this.txt_acheck = new System.Windows.Forms.TextBox();
            this.lbl_dif = new System.Windows.Forms.Label();
            this.txt_difference = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            this.pnl_template = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_make = new System.Windows.Forms.Label();
            this.btn_alerts = new System.Windows.Forms.Button();
            this.btn_notes = new System.Windows.Forms.Button();
            this.lbl_returntime = new System.Windows.Forms.Label();
            this.lbl_returndate = new System.Windows.Forms.Label();
            this.lbl_paidstatus = new System.Windows.Forms.Label();
            this.lbl_rego = new System.Windows.Forms.Label();
            this.btn_pickedup = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pnl_template.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_rego
            // 
            this.txt_rego.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_rego.Location = new System.Drawing.Point(24, 172);
            this.txt_rego.Name = "txt_rego";
            this.txt_rego.Size = new System.Drawing.Size(188, 40);
            this.txt_rego.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(75, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "Rego";
            // 
            // chk_service
            // 
            this.chk_service.AutoSize = true;
            this.chk_service.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_service.Location = new System.Drawing.Point(323, 90);
            this.chk_service.Name = "chk_service";
            this.chk_service.Size = new System.Drawing.Size(175, 24);
            this.chk_service.TabIndex = 3;
            this.chk_service.Text = "Service Due/Close";
            this.chk_service.UseVisualStyleBackColor = true;
            this.chk_service.CheckedChanged += new System.EventHandler(this.chk_service_CheckedChanged);
            // 
            // chk_reg
            // 
            this.chk_reg.AutoSize = true;
            this.chk_reg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_reg.Location = new System.Drawing.Point(663, 145);
            this.chk_reg.Name = "chk_reg";
            this.chk_reg.Size = new System.Drawing.Size(99, 24);
            this.chk_reg.TabIndex = 4;
            this.chk_reg.Text = "Reg Due";
            this.chk_reg.UseVisualStyleBackColor = true;
            this.chk_reg.CheckedChanged += new System.EventHandler(this.chk_reg_CheckedChanged);
            // 
            // reg_cof
            // 
            this.reg_cof.AutoSize = true;
            this.reg_cof.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reg_cof.Location = new System.Drawing.Point(912, 145);
            this.reg_cof.Name = "reg_cof";
            this.reg_cof.Size = new System.Drawing.Size(102, 24);
            this.reg_cof.TabIndex = 5;
            this.reg_cof.Text = "COF Due";
            this.reg_cof.UseVisualStyleBackColor = true;
            this.reg_cof.CheckedChanged += new System.EventHandler(this.reg_cof_CheckedChanged);
            // 
            // dt_reg
            // 
            this.dt_reg.Location = new System.Drawing.Point(614, 188);
            this.dt_reg.Name = "dt_reg";
            this.dt_reg.Size = new System.Drawing.Size(200, 20);
            this.dt_reg.TabIndex = 6;
            this.dt_reg.Visible = false;
            // 
            // dt_cof
            // 
            this.dt_cof.Location = new System.Drawing.Point(862, 188);
            this.dt_cof.Name = "dt_cof";
            this.dt_cof.Size = new System.Drawing.Size(200, 20);
            this.dt_cof.TabIndex = 7;
            this.dt_cof.Visible = false;
            // 
            // txt_mileage
            // 
            this.txt_mileage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_mileage.Location = new System.Drawing.Point(371, 130);
            this.txt_mileage.Name = "txt_mileage";
            this.txt_mileage.Size = new System.Drawing.Size(188, 29);
            this.txt_mileage.TabIndex = 8;
            this.txt_mileage.Visible = false;
            // 
            // lbl_mil
            // 
            this.lbl_mil.AutoSize = true;
            this.lbl_mil.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_mil.Location = new System.Drawing.Point(283, 133);
            this.lbl_mil.Name = "lbl_mil";
            this.lbl_mil.Size = new System.Drawing.Size(82, 24);
            this.lbl_mil.TabIndex = 9;
            this.lbl_mil.Text = "Mileage:";
            this.lbl_mil.Visible = false;
            // 
            // lbl_acheck
            // 
            this.lbl_acheck.AutoSize = true;
            this.lbl_acheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_acheck.Location = new System.Drawing.Point(277, 179);
            this.lbl_acheck.Name = "lbl_acheck";
            this.lbl_acheck.Size = new System.Drawing.Size(88, 24);
            this.lbl_acheck.TabIndex = 11;
            this.lbl_acheck.Text = "A-Check:";
            this.lbl_acheck.Visible = false;
            // 
            // txt_acheck
            // 
            this.txt_acheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_acheck.Location = new System.Drawing.Point(371, 176);
            this.txt_acheck.Name = "txt_acheck";
            this.txt_acheck.Size = new System.Drawing.Size(188, 29);
            this.txt_acheck.TabIndex = 10;
            this.txt_acheck.Visible = false;
            // 
            // lbl_dif
            // 
            this.lbl_dif.AutoSize = true;
            this.lbl_dif.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dif.Location = new System.Drawing.Point(265, 219);
            this.lbl_dif.Name = "lbl_dif";
            this.lbl_dif.Size = new System.Drawing.Size(100, 24);
            this.lbl_dif.TabIndex = 12;
            this.lbl_dif.Text = "Difference:";
            this.lbl_dif.Visible = false;
            // 
            // txt_difference
            // 
            this.txt_difference.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_difference.Location = new System.Drawing.Point(371, 216);
            this.txt_difference.Name = "txt_difference";
            this.txt_difference.Size = new System.Drawing.Size(188, 29);
            this.txt_difference.TabIndex = 13;
            this.txt_difference.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(500, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 33);
            this.label5.TabIndex = 14;
            this.label5.Text = "Rental Car";
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Location = new System.Drawing.Point(517, 263);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(116, 57);
            this.btn_add.TabIndex = 16;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // pnl_template
            // 
            this.pnl_template.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pnl_template.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_template.Controls.Add(this.label7);
            this.pnl_template.Controls.Add(this.label6);
            this.pnl_template.Controls.Add(this.lbl_make);
            this.pnl_template.Controls.Add(this.btn_alerts);
            this.pnl_template.Controls.Add(this.btn_notes);
            this.pnl_template.Controls.Add(this.lbl_returntime);
            this.pnl_template.Controls.Add(this.lbl_returndate);
            this.pnl_template.Controls.Add(this.lbl_paidstatus);
            this.pnl_template.Controls.Add(this.lbl_rego);
            this.pnl_template.Controls.Add(this.btn_pickedup);
            this.pnl_template.Location = new System.Drawing.Point(21, 398);
            this.pnl_template.Name = "pnl_template";
            this.pnl_template.Size = new System.Drawing.Size(1041, 41);
            this.pnl_template.TabIndex = 24;
            this.pnl_template.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(818, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(204, 20);
            this.label7.TabIndex = 29;
            this.label7.Text = "CERTIFICATEOFFITNESS";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(575, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 20);
            this.label6.TabIndex = 28;
            this.label6.Text = "REGISTRATIONDUE";
            // 
            // lbl_make
            // 
            this.lbl_make.AutoSize = true;
            this.lbl_make.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_make.Location = new System.Drawing.Point(283, 10);
            this.lbl_make.Name = "lbl_make";
            this.lbl_make.Size = new System.Drawing.Size(193, 20);
            this.lbl_make.TabIndex = 26;
            this.lbl_make.Text = "MILEAGE/ACHECK/DIFF";
            // 
            // btn_alerts
            // 
            this.btn_alerts.BackColor = System.Drawing.Color.Red;
            this.btn_alerts.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_alerts.Location = new System.Drawing.Point(1463, 10);
            this.btn_alerts.Name = "btn_alerts";
            this.btn_alerts.Size = new System.Drawing.Size(33, 23);
            this.btn_alerts.TabIndex = 22;
            this.btn_alerts.Text = "A";
            this.btn_alerts.UseVisualStyleBackColor = false;
            this.btn_alerts.Visible = false;
            // 
            // btn_notes
            // 
            this.btn_notes.BackColor = System.Drawing.Color.DarkViolet;
            this.btn_notes.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_notes.Location = new System.Drawing.Point(1424, 10);
            this.btn_notes.Name = "btn_notes";
            this.btn_notes.Size = new System.Drawing.Size(33, 23);
            this.btn_notes.TabIndex = 21;
            this.btn_notes.Text = "N";
            this.btn_notes.UseVisualStyleBackColor = false;
            this.btn_notes.Visible = false;
            // 
            // lbl_returntime
            // 
            this.lbl_returntime.AutoSize = true;
            this.lbl_returntime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_returntime.Location = new System.Drawing.Point(1293, 10);
            this.lbl_returntime.Name = "lbl_returntime";
            this.lbl_returntime.Size = new System.Drawing.Size(76, 20);
            this.lbl_returntime.TabIndex = 20;
            this.lbl_returntime.Text = "Unknown";
            // 
            // lbl_returndate
            // 
            this.lbl_returndate.AutoSize = true;
            this.lbl_returndate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_returndate.Location = new System.Drawing.Point(1126, 10);
            this.lbl_returndate.Name = "lbl_returndate";
            this.lbl_returndate.Size = new System.Drawing.Size(149, 20);
            this.lbl_returndate.TabIndex = 19;
            this.lbl_returndate.Text = "FRI, 06-01-17 Extra";
            // 
            // lbl_paidstatus
            // 
            this.lbl_paidstatus.AutoSize = true;
            this.lbl_paidstatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lbl_paidstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_paidstatus.Location = new System.Drawing.Point(1042, 10);
            this.lbl_paidstatus.Name = "lbl_paidstatus";
            this.lbl_paidstatus.Size = new System.Drawing.Size(65, 20);
            this.lbl_paidstatus.TabIndex = 18;
            this.lbl_paidstatus.Text = "Internet";
            // 
            // lbl_rego
            // 
            this.lbl_rego.AutoSize = true;
            this.lbl_rego.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_rego.Location = new System.Drawing.Point(112, 8);
            this.lbl_rego.Name = "lbl_rego";
            this.lbl_rego.Size = new System.Drawing.Size(78, 20);
            this.lbl_rego.TabIndex = 13;
            this.lbl_rego.Text = "AAA1234";
            // 
            // btn_pickedup
            // 
            this.btn_pickedup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_pickedup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pickedup.Location = new System.Drawing.Point(9, 8);
            this.btn_pickedup.Name = "btn_pickedup";
            this.btn_pickedup.Size = new System.Drawing.Size(58, 23);
            this.btn_pickedup.TabIndex = 10;
            this.btn_pickedup.Text = "Delete";
            this.btn_pickedup.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(146, 365);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 24);
            this.label8.TabIndex = 25;
            this.label8.Text = "Rego";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(283, 365);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(245, 24);
            this.label9.TabIndex = 26;
            this.label9.Text = "Mileage/A-Check/Difference";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(636, 365);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 24);
            this.label10.TabIndex = 27;
            this.label10.Text = "Reg Due";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(908, 365);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 24);
            this.label11.TabIndex = 28;
            this.label11.Text = "CoF Due";
            // 
            // RentalCars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 588);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pnl_template);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_difference);
            this.Controls.Add(this.lbl_dif);
            this.Controls.Add(this.lbl_acheck);
            this.Controls.Add(this.txt_acheck);
            this.Controls.Add(this.lbl_mil);
            this.Controls.Add(this.txt_mileage);
            this.Controls.Add(this.dt_cof);
            this.Controls.Add(this.dt_reg);
            this.Controls.Add(this.reg_cof);
            this.Controls.Add(this.chk_reg);
            this.Controls.Add(this.chk_service);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_rego);
            this.Name = "RentalCars";
            this.Text = "RentalCars";
            this.pnl_template.ResumeLayout(false);
            this.pnl_template.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_rego;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chk_service;
        private System.Windows.Forms.CheckBox chk_reg;
        private System.Windows.Forms.CheckBox reg_cof;
        private System.Windows.Forms.DateTimePicker dt_reg;
        private System.Windows.Forms.DateTimePicker dt_cof;
        private System.Windows.Forms.TextBox txt_mileage;
        private System.Windows.Forms.Label lbl_mil;
        private System.Windows.Forms.Label lbl_acheck;
        private System.Windows.Forms.TextBox txt_acheck;
        private System.Windows.Forms.Label lbl_dif;
        private System.Windows.Forms.TextBox txt_difference;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Panel pnl_template;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_make;
        private System.Windows.Forms.Button btn_alerts;
        private System.Windows.Forms.Button btn_notes;
        private System.Windows.Forms.Label lbl_returntime;
        private System.Windows.Forms.Label lbl_returndate;
        private System.Windows.Forms.Label lbl_paidstatus;
        private System.Windows.Forms.Label lbl_rego;
        private System.Windows.Forms.Button btn_pickedup;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}