namespace KKCSInvoiceProject
{
    partial class Refunds
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
            this.label11 = new System.Windows.Forms.Label();
            this.txt_refund1 = new System.Windows.Forms.TextBox();
            this.txt_notes = new System.Windows.Forms.TextBox();
            this.dt_todaysdate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.labl_savedstatus = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_refund2 = new System.Windows.Forms.TextBox();
            this.txt_dollar2 = new System.Windows.Forms.Label();
            this.cmb_refund1 = new System.Windows.Forms.ComboBox();
            this.cmb_refund2 = new System.Windows.Forms.ComboBox();
            this.chkbox_nocharge = new System.Windows.Forms.CheckBox();
            this.dt_cardroppedoff = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dt_originaldue = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_originaltotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_refundowned = new System.Windows.Forms.TextBox();
            this.chk_carpickup = new System.Windows.Forms.CheckBox();
            this.chk_releasekey = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lbl_carreturns
            // 
            this.lbl_carreturns.AutoSize = true;
            this.lbl_carreturns.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_carreturns.Location = new System.Drawing.Point(355, 9);
            this.lbl_carreturns.Name = "lbl_carreturns";
            this.lbl_carreturns.Size = new System.Drawing.Size(123, 31);
            this.lbl_carreturns.TabIndex = 3;
            this.lbl_carreturns.Text = "Refunds";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(276, 401);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 25);
            this.label11.TabIndex = 27;
            this.label11.Text = "$";
            // 
            // txt_refund1
            // 
            this.txt_refund1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_refund1.Location = new System.Drawing.Point(305, 398);
            this.txt_refund1.Name = "txt_refund1";
            this.txt_refund1.Size = new System.Drawing.Size(121, 31);
            this.txt_refund1.TabIndex = 42;
            this.txt_refund1.TextChanged += new System.EventHandler(this.txt_refund1_TextChanged);
            // 
            // txt_notes
            // 
            this.txt_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txt_notes.Location = new System.Drawing.Point(117, 524);
            this.txt_notes.Multiline = true;
            this.txt_notes.Name = "txt_notes";
            this.txt_notes.Size = new System.Drawing.Size(361, 225);
            this.txt_notes.TabIndex = 43;
            // 
            // dt_todaysdate
            // 
            this.dt_todaysdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.5F, System.Drawing.FontStyle.Bold);
            this.dt_todaysdate.Location = new System.Drawing.Point(349, 173);
            this.dt_todaysdate.Name = "dt_todaysdate";
            this.dt_todaysdate.Size = new System.Drawing.Size(434, 35);
            this.dt_todaysdate.TabIndex = 45;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Green;
            this.label6.Location = new System.Drawing.Point(139, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 29);
            this.label6.TabIndex = 44;
            this.label6.Text = "Todays Date:";
            // 
            // labl_savedstatus
            // 
            this.labl_savedstatus.AutoSize = true;
            this.labl_savedstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.labl_savedstatus.ForeColor = System.Drawing.Color.Red;
            this.labl_savedstatus.Location = new System.Drawing.Point(496, 710);
            this.labl_savedstatus.Name = "labl_savedstatus";
            this.labl_savedstatus.Size = new System.Drawing.Size(227, 39);
            this.labl_savedstatus.TabIndex = 72;
            this.labl_savedstatus.Text = "Not Refunded";
            this.labl_savedstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.btn_save.Location = new System.Drawing.Point(537, 621);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(133, 77);
            this.btn_save.TabIndex = 71;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 421);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 25);
            this.label1.TabIndex = 73;
            this.label1.Text = "Amount Taken From:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 569);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 25);
            this.label3.TabIndex = 77;
            this.label3.Text = "Notes:";
            // 
            // txt_refund2
            // 
            this.txt_refund2.Enabled = false;
            this.txt_refund2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_refund2.Location = new System.Drawing.Point(305, 442);
            this.txt_refund2.Name = "txt_refund2";
            this.txt_refund2.Size = new System.Drawing.Size(121, 31);
            this.txt_refund2.TabIndex = 79;
            this.txt_refund2.Visible = false;
            this.txt_refund2.TextChanged += new System.EventHandler(this.txt_refund2_TextChanged);
            // 
            // txt_dollar2
            // 
            this.txt_dollar2.AutoSize = true;
            this.txt_dollar2.Enabled = false;
            this.txt_dollar2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dollar2.Location = new System.Drawing.Point(276, 444);
            this.txt_dollar2.Name = "txt_dollar2";
            this.txt_dollar2.Size = new System.Drawing.Size(25, 25);
            this.txt_dollar2.TabIndex = 78;
            this.txt_dollar2.Text = "$";
            this.txt_dollar2.Visible = false;
            // 
            // cmb_refund1
            // 
            this.cmb_refund1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmb_refund1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_refund1.BackColor = System.Drawing.SystemColors.Window;
            this.cmb_refund1.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmb_refund1.DropDownWidth = 121;
            this.cmb_refund1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_refund1.FormattingEnabled = true;
            this.cmb_refund1.Items.AddRange(new object[] {
            "Till",
            "Tin"});
            this.cmb_refund1.Location = new System.Drawing.Point(449, 396);
            this.cmb_refund1.Name = "cmb_refund1";
            this.cmb_refund1.Size = new System.Drawing.Size(108, 33);
            this.cmb_refund1.TabIndex = 80;
            // 
            // cmb_refund2
            // 
            this.cmb_refund2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmb_refund2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_refund2.BackColor = System.Drawing.SystemColors.Window;
            this.cmb_refund2.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmb_refund2.DropDownWidth = 121;
            this.cmb_refund2.Enabled = false;
            this.cmb_refund2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_refund2.FormattingEnabled = true;
            this.cmb_refund2.Items.AddRange(new object[] {
            "Till",
            "Tin"});
            this.cmb_refund2.Location = new System.Drawing.Point(449, 440);
            this.cmb_refund2.Name = "cmb_refund2";
            this.cmb_refund2.Size = new System.Drawing.Size(108, 33);
            this.cmb_refund2.TabIndex = 81;
            this.cmb_refund2.Visible = false;
            // 
            // chkbox_nocharge
            // 
            this.chkbox_nocharge.AutoSize = true;
            this.chkbox_nocharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.chkbox_nocharge.Location = new System.Drawing.Point(581, 420);
            this.chkbox_nocharge.Name = "chkbox_nocharge";
            this.chkbox_nocharge.Size = new System.Drawing.Size(64, 26);
            this.chkbox_nocharge.TabIndex = 82;
            this.chkbox_nocharge.Text = "Split";
            this.chkbox_nocharge.UseVisualStyleBackColor = true;
            this.chkbox_nocharge.CheckedChanged += new System.EventHandler(this.chkbox_nocharge_CheckedChanged);
            // 
            // dt_cardroppedoff
            // 
            this.dt_cardroppedoff.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.5F, System.Drawing.FontStyle.Bold);
            this.dt_cardroppedoff.Location = new System.Drawing.Point(349, 57);
            this.dt_cardroppedoff.Name = "dt_cardroppedoff";
            this.dt_cardroppedoff.Size = new System.Drawing.Size(434, 35);
            this.dt_cardroppedoff.TabIndex = 84;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(30, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(284, 29);
            this.label2.TabIndex = 83;
            this.label2.Text = "Date Car Dropped Off:";
            // 
            // dt_originaldue
            // 
            this.dt_originaldue.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.5F, System.Drawing.FontStyle.Bold);
            this.dt_originaldue.Location = new System.Drawing.Point(349, 113);
            this.dt_originaldue.Name = "dt_originaldue";
            this.dt_originaldue.Size = new System.Drawing.Size(434, 35);
            this.dt_originaldue.TabIndex = 86;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(76, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(238, 29);
            this.label4.TabIndex = 85;
            this.label4.Text = "Original Due Date:";
            // 
            // txt_originaltotal
            // 
            this.txt_originaltotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_originaltotal.Location = new System.Drawing.Point(209, 253);
            this.txt_originaltotal.Name = "txt_originaltotal";
            this.txt_originaltotal.Size = new System.Drawing.Size(121, 31);
            this.txt_originaltotal.TabIndex = 87;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 25);
            this.label5.TabIndex = 88;
            this.label5.Text = "Originally Paid:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(30, 324);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(212, 33);
            this.label7.TabIndex = 90;
            this.label7.Text = "Refund Owed:";
            // 
            // txt_refundowned
            // 
            this.txt_refundowned.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_refundowned.Location = new System.Drawing.Point(249, 320);
            this.txt_refundowned.Name = "txt_refundowned";
            this.txt_refundowned.Size = new System.Drawing.Size(146, 40);
            this.txt_refundowned.TabIndex = 89;
            // 
            // chk_carpickup
            // 
            this.chk_carpickup.AutoSize = true;
            this.chk_carpickup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_carpickup.Location = new System.Drawing.Point(532, 523);
            this.chk_carpickup.Name = "chk_carpickup";
            this.chk_carpickup.Size = new System.Drawing.Size(149, 28);
            this.chk_carpickup.TabIndex = 91;
            this.chk_carpickup.Text = "Car Picked Up";
            this.chk_carpickup.UseVisualStyleBackColor = true;
            // 
            // chk_releasekey
            // 
            this.chk_releasekey.AutoSize = true;
            this.chk_releasekey.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_releasekey.Location = new System.Drawing.Point(532, 557);
            this.chk_releasekey.Name = "chk_releasekey";
            this.chk_releasekey.Size = new System.Drawing.Size(209, 28);
            this.chk_releasekey.TabIndex = 92;
            this.chk_releasekey.Text = "Release Key Number";
            this.chk_releasekey.UseVisualStyleBackColor = true;
            // 
            // Refunds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 789);
            this.Controls.Add(this.chk_releasekey);
            this.Controls.Add(this.chk_carpickup);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_refundowned);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_originaltotal);
            this.Controls.Add(this.dt_originaldue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dt_cardroppedoff);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkbox_nocharge);
            this.Controls.Add(this.cmb_refund2);
            this.Controls.Add(this.cmb_refund1);
            this.Controls.Add(this.txt_refund2);
            this.Controls.Add(this.txt_dollar2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labl_savedstatus);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.dt_todaysdate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_notes);
            this.Controls.Add(this.txt_refund1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbl_carreturns);
            this.Name = "Refunds";
            this.Text = "Refunds";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_carreturns;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_refund1;
        private System.Windows.Forms.TextBox txt_notes;
        private System.Windows.Forms.DateTimePicker dt_todaysdate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labl_savedstatus;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_refund2;
        private System.Windows.Forms.Label txt_dollar2;
        private System.Windows.Forms.ComboBox cmb_refund1;
        private System.Windows.Forms.ComboBox cmb_refund2;
        private System.Windows.Forms.CheckBox chkbox_nocharge;
        private System.Windows.Forms.DateTimePicker dt_cardroppedoff;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dt_originaldue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_originaltotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_refundowned;
        private System.Windows.Forms.CheckBox chk_carpickup;
        private System.Windows.Forms.CheckBox chk_releasekey;
    }
}