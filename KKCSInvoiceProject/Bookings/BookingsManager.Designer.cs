namespace KKCSInvoiceProject
{
    partial class BookingsManager
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
            this.lbl_remain = new System.Windows.Forms.Label();
            this.lbl_pettycashremaning = new System.Windows.Forms.Label();
            this.lbl_latest = new System.Windows.Forms.Label();
            this.btn_yearright = new System.Windows.Forms.Button();
            this.btn_yearleft = new System.Windows.Forms.Button();
            this.cmb_month = new System.Windows.Forms.ComboBox();
            this.btn_monthleft = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_template = new System.Windows.Forms.Panel();
            this.lbl_runningamount = new System.Windows.Forms.Label();
            this.lbl_date = new System.Windows.Forms.Label();
            this.btn_edit = new System.Windows.Forms.Button();
            this.lbl_amount = new System.Windows.Forms.Label();
            this.lbl_item = new System.Windows.Forms.Label();
            this.btn_notes = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_new = new System.Windows.Forms.Button();
            this.bnt_monthright = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_year = new System.Windows.Forms.TextBox();
            this.lbl_month = new System.Windows.Forms.Label();
            this.pnl_template.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_remain
            // 
            this.lbl_remain.AutoSize = true;
            this.lbl_remain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbl_remain.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_remain.Location = new System.Drawing.Point(391, 67);
            this.lbl_remain.Name = "lbl_remain";
            this.lbl_remain.Size = new System.Drawing.Size(92, 33);
            this.lbl_remain.TabIndex = 58;
            this.lbl_remain.Text = "$0.00";
            // 
            // lbl_pettycashremaning
            // 
            this.lbl_pettycashremaning.AutoSize = true;
            this.lbl_pettycashremaning.BackColor = System.Drawing.Color.Transparent;
            this.lbl_pettycashremaning.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pettycashremaning.Location = new System.Drawing.Point(23, 66);
            this.lbl_pettycashremaning.Name = "lbl_pettycashremaning";
            this.lbl_pettycashremaning.Size = new System.Drawing.Size(369, 29);
            this.lbl_pettycashremaning.TabIndex = 46;
            this.lbl_pettycashremaning.Text = "Current Petty Cash Remaining:";
            // 
            // lbl_latest
            // 
            this.lbl_latest.AutoSize = true;
            this.lbl_latest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbl_latest.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_latest.Location = new System.Drawing.Point(944, 223);
            this.lbl_latest.Name = "lbl_latest";
            this.lbl_latest.Size = new System.Drawing.Size(144, 29);
            this.lbl_latest.TabIndex = 47;
            this.lbl_latest.Text = "<--LATEST";
            this.lbl_latest.Visible = false;
            // 
            // btn_yearright
            // 
            this.btn_yearright.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_yearright.Location = new System.Drawing.Point(600, 13);
            this.btn_yearright.Name = "btn_yearright";
            this.btn_yearright.Size = new System.Drawing.Size(42, 33);
            this.btn_yearright.TabIndex = 57;
            this.btn_yearright.Text = "--->";
            this.btn_yearright.UseVisualStyleBackColor = true;
            // 
            // btn_yearleft
            // 
            this.btn_yearleft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_yearleft.Location = new System.Drawing.Point(443, 12);
            this.btn_yearleft.Name = "btn_yearleft";
            this.btn_yearleft.Size = new System.Drawing.Size(42, 33);
            this.btn_yearleft.TabIndex = 56;
            this.btn_yearleft.Text = "<--";
            this.btn_yearleft.UseVisualStyleBackColor = true;
            // 
            // cmb_month
            // 
            this.cmb_month.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_month.FormattingEnabled = true;
            this.cmb_month.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmb_month.Location = new System.Drawing.Point(147, 12);
            this.cmb_month.Name = "cmb_month";
            this.cmb_month.Size = new System.Drawing.Size(157, 33);
            this.cmb_month.TabIndex = 55;
            // 
            // btn_monthleft
            // 
            this.btn_monthleft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_monthleft.Location = new System.Drawing.Point(97, 12);
            this.btn_monthleft.Name = "btn_monthleft";
            this.btn_monthleft.Size = new System.Drawing.Size(42, 33);
            this.btn_monthleft.TabIndex = 54;
            this.btn_monthleft.Text = "<--";
            this.btn_monthleft.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(852, 186);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 20);
            this.label8.TabIndex = 53;
            this.label8.Text = "Edit";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(545, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 20);
            this.label6.TabIndex = 52;
            this.label6.Text = "Running Amount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(734, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 20);
            this.label5.TabIndex = 51;
            this.label5.Text = "Notes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(429, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 50;
            this.label4.Text = "Amount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(249, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 49;
            this.label3.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 48;
            this.label2.Text = "Item";
            // 
            // pnl_template
            // 
            this.pnl_template.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pnl_template.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_template.Controls.Add(this.lbl_runningamount);
            this.pnl_template.Controls.Add(this.lbl_date);
            this.pnl_template.Controls.Add(this.btn_edit);
            this.pnl_template.Controls.Add(this.lbl_amount);
            this.pnl_template.Controls.Add(this.lbl_item);
            this.pnl_template.Controls.Add(this.btn_notes);
            this.pnl_template.Location = new System.Drawing.Point(16, 217);
            this.pnl_template.Name = "pnl_template";
            this.pnl_template.Size = new System.Drawing.Size(917, 41);
            this.pnl_template.TabIndex = 45;
            this.pnl_template.Visible = false;
            // 
            // lbl_runningamount
            // 
            this.lbl_runningamount.AutoSize = true;
            this.lbl_runningamount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_runningamount.Location = new System.Drawing.Point(528, 10);
            this.lbl_runningamount.Name = "lbl_runningamount";
            this.lbl_runningamount.Size = new System.Drawing.Size(85, 20);
            this.lbl_runningamount.TabIndex = 27;
            this.lbl_runningamount.Text = "$78.52000";
            // 
            // lbl_date
            // 
            this.lbl_date.AutoSize = true;
            this.lbl_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_date.Location = new System.Drawing.Point(232, 10);
            this.lbl_date.Name = "lbl_date";
            this.lbl_date.Size = new System.Drawing.Size(135, 20);
            this.lbl_date.TabIndex = 25;
            this.lbl_date.Text = "02731413787878";
            // 
            // btn_edit
            // 
            this.btn_edit.BackColor = System.Drawing.SystemColors.Control;
            this.btn_edit.Location = new System.Drawing.Point(826, 10);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(61, 23);
            this.btn_edit.TabIndex = 24;
            this.btn_edit.Text = "Edit";
            this.btn_edit.UseVisualStyleBackColor = false;
            // 
            // lbl_amount
            // 
            this.lbl_amount.AutoSize = true;
            this.lbl_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_amount.Location = new System.Drawing.Point(412, 10);
            this.lbl_amount.Name = "lbl_amount";
            this.lbl_amount.Size = new System.Drawing.Size(85, 20);
            this.lbl_amount.TabIndex = 17;
            this.lbl_amount.Text = "$78.52000";
            // 
            // lbl_item
            // 
            this.lbl_item.AutoSize = true;
            this.lbl_item.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_item.Location = new System.Drawing.Point(13, 10);
            this.lbl_item.Name = "lbl_item";
            this.lbl_item.Size = new System.Drawing.Size(181, 20);
            this.lbl_item.TabIndex = 12;
            this.lbl_item.Text = "PETER GREEN PETER";
            // 
            // btn_notes
            // 
            this.btn_notes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_notes.Location = new System.Drawing.Point(721, 10);
            this.btn_notes.Name = "btn_notes";
            this.btn_notes.Size = new System.Drawing.Size(44, 23);
            this.btn_notes.TabIndex = 10;
            this.btn_notes.Text = "N";
            this.btn_notes.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(375, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(231, 33);
            this.button1.TabIndex = 44;
            this.button1.Text = "Reimburse Petty Cash";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btn_new
            // 
            this.btn_new.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_new.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new.Location = new System.Drawing.Point(19, 113);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(349, 56);
            this.btn_new.TabIndex = 43;
            this.btn_new.Text = "New Petty Cash Item";
            this.btn_new.UseVisualStyleBackColor = false;
            // 
            // bnt_monthright
            // 
            this.bnt_monthright.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnt_monthright.Location = new System.Drawing.Point(308, 12);
            this.bnt_monthright.Name = "bnt_monthright";
            this.bnt_monthright.Size = new System.Drawing.Size(42, 33);
            this.bnt_monthright.TabIndex = 42;
            this.bnt_monthright.Text = "--->";
            this.bnt_monthright.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(378, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 25);
            this.label1.TabIndex = 41;
            this.label1.Text = "Year:";
            // 
            // txt_year
            // 
            this.txt_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_year.Location = new System.Drawing.Point(491, 14);
            this.txt_year.Name = "txt_year";
            this.txt_year.Size = new System.Drawing.Size(104, 31);
            this.txt_year.TabIndex = 40;
            // 
            // lbl_month
            // 
            this.lbl_month.AutoSize = true;
            this.lbl_month.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_month.Location = new System.Drawing.Point(10, 16);
            this.lbl_month.Name = "lbl_month";
            this.lbl_month.Size = new System.Drawing.Size(84, 25);
            this.lbl_month.TabIndex = 39;
            this.lbl_month.Text = "Month:";
            // 
            // BookingsManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 553);
            this.Controls.Add(this.lbl_remain);
            this.Controls.Add(this.lbl_pettycashremaning);
            this.Controls.Add(this.lbl_latest);
            this.Controls.Add(this.btn_yearright);
            this.Controls.Add(this.btn_yearleft);
            this.Controls.Add(this.cmb_month);
            this.Controls.Add(this.btn_monthleft);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnl_template);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_new);
            this.Controls.Add(this.bnt_monthright);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_year);
            this.Controls.Add(this.lbl_month);
            this.Name = "BookingsManager";
            this.Text = "BookingsManager";
            this.pnl_template.ResumeLayout(false);
            this.pnl_template.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_remain;
        private System.Windows.Forms.Label lbl_pettycashremaning;
        private System.Windows.Forms.Label lbl_latest;
        private System.Windows.Forms.Button btn_yearright;
        private System.Windows.Forms.Button btn_yearleft;
        private System.Windows.Forms.ComboBox cmb_month;
        private System.Windows.Forms.Button btn_monthleft;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnl_template;
        private System.Windows.Forms.Label lbl_runningamount;
        private System.Windows.Forms.Label lbl_date;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Label lbl_amount;
        private System.Windows.Forms.Label lbl_item;
        private System.Windows.Forms.Button btn_notes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.Button bnt_monthright;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_year;
        private System.Windows.Forms.Label lbl_month;
    }
}