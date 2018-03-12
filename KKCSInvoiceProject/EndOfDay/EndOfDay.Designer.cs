namespace KKCSInvoiceProject
{
    partial class EndOfDay
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
            this.txt_eodheader = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_total = new System.Windows.Forms.Label();
            this.txtbox_notes = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_eftposin = new System.Windows.Forms.Label();
            this.pnl_stepsthree = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.cmb_stepthree = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_sod = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_cashin = new System.Windows.Forms.Label();
            this.lbl_refunds = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnl_steptwo = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chk_eftposreset = new System.Windows.Forms.CheckBox();
            this.lbl_eftpostotals = new System.Windows.Forms.Label();
            this.cmb_Steptwo = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.pnl_stepfive = new System.Windows.Forms.Panel();
            this.cmb_printerpicked2 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_printconfirmation = new System.Windows.Forms.Button();
            this.chk_signedform = new System.Windows.Forms.CheckBox();
            this.lbl_haveyousigned = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmb_printerpicked1 = new System.Windows.Forms.ComboBox();
            this.btn_printdailytotal = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.btn_endday = new System.Windows.Forms.Button();
            this.pnl_stepfour = new System.Windows.Forms.Panel();
            this.cmb_worker = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_runningtotals = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dt_eodpick = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_dateleft = new System.Windows.Forms.Button();
            this.btn_dateright = new System.Windows.Forms.Button();
            this.lbl_dayend = new System.Windows.Forms.Label();
            this.pnl_stepsthree.SuspendLayout();
            this.pnl_steptwo.SuspendLayout();
            this.pnl_stepfive.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl_stepfour.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_eodheader
            // 
            this.txt_eodheader.AutoSize = true;
            this.txt_eodheader.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_eodheader.Location = new System.Drawing.Point(10, 14);
            this.txt_eodheader.Name = "txt_eodheader";
            this.txt_eodheader.Size = new System.Drawing.Size(386, 31);
            this.txt_eodheader.TabIndex = 84;
            this.txt_eodheader.Text = "End of Day - 01/01/16 (Thur)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 31);
            this.label1.TabIndex = 85;
            this.label1.Text = "3. Cash";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(6, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(378, 37);
            this.label10.TabIndex = 94;
            this.label10.Text = "Total Cash Taken Today:";
            // 
            // lbl_total
            // 
            this.lbl_total.AutoSize = true;
            this.lbl_total.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lbl_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total.Location = new System.Drawing.Point(381, 180);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(134, 37);
            this.lbl_total.TabIndex = 95;
            this.lbl_total.Text = "$000.00";
            // 
            // txtbox_notes
            // 
            this.txtbox_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_notes.Location = new System.Drawing.Point(20, 86);
            this.txtbox_notes.Multiline = true;
            this.txtbox_notes.Name = "txtbox_notes";
            this.txtbox_notes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbox_notes.Size = new System.Drawing.Size(513, 284);
            this.txtbox_notes.TabIndex = 106;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 31);
            this.label5.TabIndex = 122;
            this.label5.Text = "2. EFTPOS";
            // 
            // lbl_eftposin
            // 
            this.lbl_eftposin.AutoSize = true;
            this.lbl_eftposin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lbl_eftposin.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_eftposin.Location = new System.Drawing.Point(111, 57);
            this.lbl_eftposin.Name = "lbl_eftposin";
            this.lbl_eftposin.Size = new System.Drawing.Size(134, 37);
            this.lbl_eftposin.TabIndex = 128;
            this.lbl_eftposin.Text = "$000.00";
            // 
            // pnl_stepsthree
            // 
            this.pnl_stepsthree.BackColor = System.Drawing.Color.White;
            this.pnl_stepsthree.Controls.Add(this.label15);
            this.pnl_stepsthree.Controls.Add(this.cmb_stepthree);
            this.pnl_stepsthree.Controls.Add(this.label11);
            this.pnl_stepsthree.Controls.Add(this.label9);
            this.pnl_stepsthree.Controls.Add(this.label1);
            this.pnl_stepsthree.Controls.Add(this.lbl_sod);
            this.pnl_stepsthree.Controls.Add(this.label4);
            this.pnl_stepsthree.Controls.Add(this.label6);
            this.pnl_stepsthree.Controls.Add(this.lbl_cashin);
            this.pnl_stepsthree.Controls.Add(this.lbl_refunds);
            this.pnl_stepsthree.Controls.Add(this.label10);
            this.pnl_stepsthree.Controls.Add(this.lbl_total);
            this.pnl_stepsthree.Controls.Add(this.label3);
            this.pnl_stepsthree.Enabled = false;
            this.pnl_stepsthree.Location = new System.Drawing.Point(12, 359);
            this.pnl_stepsthree.Name = "pnl_stepsthree";
            this.pnl_stepsthree.Size = new System.Drawing.Size(557, 326);
            this.pnl_stepsthree.TabIndex = 132;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(17, 271);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(156, 25);
            this.label15.TabIndex = 134;
            this.label15.Text = "Is this Correct?";
            // 
            // cmb_stepthree
            // 
            this.cmb_stepthree.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmb_stepthree.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_stepthree.BackColor = System.Drawing.SystemColors.Window;
            this.cmb_stepthree.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmb_stepthree.DropDownWidth = 121;
            this.cmb_stepthree.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_stepthree.FormattingEnabled = true;
            this.cmb_stepthree.Items.AddRange(new object[] {
            "Correct",
            "Incorrect"});
            this.cmb_stepthree.Location = new System.Drawing.Point(179, 261);
            this.cmb_stepthree.Name = "cmb_stepthree";
            this.cmb_stepthree.Size = new System.Drawing.Size(182, 41);
            this.cmb_stepthree.TabIndex = 134;
            this.cmb_stepthree.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(230, 227);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 20);
            this.label11.TabIndex = 123;
            this.label11.Text = "$180.00)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 227);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(207, 20);
            this.label9.TabIndex = 122;
            this.label9.Text = "(Tomorrows Till Start of Day:";
            // 
            // lbl_sod
            // 
            this.lbl_sod.AutoSize = true;
            this.lbl_sod.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sod.Location = new System.Drawing.Point(195, 57);
            this.lbl_sod.Name = "lbl_sod";
            this.lbl_sod.Size = new System.Drawing.Size(90, 25);
            this.lbl_sod.TabIndex = 87;
            this.lbl_sod.Text = "$180.00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 25);
            this.label4.TabIndex = 88;
            this.label4.Text = "Cash Taken In:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 25);
            this.label6.TabIndex = 90;
            this.label6.Text = "Refunds:";
            // 
            // lbl_cashin
            // 
            this.lbl_cashin.AutoSize = true;
            this.lbl_cashin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cashin.Location = new System.Drawing.Point(195, 102);
            this.lbl_cashin.Name = "lbl_cashin";
            this.lbl_cashin.Size = new System.Drawing.Size(90, 25);
            this.lbl_cashin.TabIndex = 91;
            this.lbl_cashin.Text = "$000.00";
            // 
            // lbl_refunds
            // 
            this.lbl_refunds.AutoSize = true;
            this.lbl_refunds.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_refunds.Location = new System.Drawing.Point(186, 141);
            this.lbl_refunds.Name = "lbl_refunds";
            this.lbl_refunds.Size = new System.Drawing.Size(97, 25);
            this.lbl_refunds.TabIndex = 93;
            this.lbl_refunds.Text = "-$000.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 25);
            this.label3.TabIndex = 121;
            this.label3.Text = "Start of Day Till:";
            // 
            // pnl_steptwo
            // 
            this.pnl_steptwo.BackColor = System.Drawing.Color.White;
            this.pnl_steptwo.Controls.Add(this.label13);
            this.pnl_steptwo.Controls.Add(this.label7);
            this.pnl_steptwo.Controls.Add(this.chk_eftposreset);
            this.pnl_steptwo.Controls.Add(this.lbl_eftpostotals);
            this.pnl_steptwo.Controls.Add(this.cmb_Steptwo);
            this.pnl_steptwo.Controls.Add(this.label5);
            this.pnl_steptwo.Controls.Add(this.label14);
            this.pnl_steptwo.Controls.Add(this.lbl_eftposin);
            this.pnl_steptwo.Enabled = false;
            this.pnl_steptwo.Location = new System.Drawing.Point(12, 148);
            this.pnl_steptwo.Name = "pnl_steptwo";
            this.pnl_steptwo.Size = new System.Drawing.Size(557, 196);
            this.pnl_steptwo.TabIndex = 133;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(260, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(156, 25);
            this.label13.TabIndex = 133;
            this.label13.Text = "Is this Correct?";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(376, 24);
            this.label7.TabIndex = 132;
            this.label7.Text = "-------------------------------------------------------------";
            // 
            // chk_eftposreset
            // 
            this.chk_eftposreset.AutoSize = true;
            this.chk_eftposreset.Enabled = false;
            this.chk_eftposreset.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_eftposreset.Location = new System.Drawing.Point(315, 154);
            this.chk_eftposreset.Name = "chk_eftposreset";
            this.chk_eftposreset.Size = new System.Drawing.Size(116, 28);
            this.chk_eftposreset.TabIndex = 131;
            this.chk_eftposreset.Text = "Confirmed";
            this.chk_eftposreset.UseVisualStyleBackColor = true;
            this.chk_eftposreset.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lbl_eftpostotals
            // 
            this.lbl_eftpostotals.AutoSize = true;
            this.lbl_eftpostotals.Enabled = false;
            this.lbl_eftpostotals.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_eftpostotals.ForeColor = System.Drawing.Color.Red;
            this.lbl_eftpostotals.Location = new System.Drawing.Point(22, 124);
            this.lbl_eftpostotals.Name = "lbl_eftpostotals";
            this.lbl_eftpostotals.Size = new System.Drawing.Size(341, 58);
            this.lbl_eftpostotals.TabIndex = 130;
            this.lbl_eftpostotals.Text = "Please make sure eftpos totals\r\nare reset/cleared to $0.00";
            // 
            // cmb_Steptwo
            // 
            this.cmb_Steptwo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmb_Steptwo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_Steptwo.BackColor = System.Drawing.SystemColors.Window;
            this.cmb_Steptwo.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmb_Steptwo.DropDownWidth = 121;
            this.cmb_Steptwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Steptwo.FormattingEnabled = true;
            this.cmb_Steptwo.Items.AddRange(new object[] {
            "Correct",
            "Incorrect"});
            this.cmb_Steptwo.Location = new System.Drawing.Point(261, 53);
            this.cmb_Steptwo.Name = "cmb_Steptwo";
            this.cmb_Steptwo.Size = new System.Drawing.Size(182, 41);
            this.cmb_Steptwo.TabIndex = 129;
            this.cmb_Steptwo.SelectedIndexChanged += new System.EventHandler(this.cmb_StepThree_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(15, 57);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 37);
            this.label14.TabIndex = 124;
            this.label14.Text = "Total:";
            // 
            // pnl_stepfive
            // 
            this.pnl_stepfive.BackColor = System.Drawing.Color.White;
            this.pnl_stepfive.Controls.Add(this.cmb_printerpicked2);
            this.pnl_stepfive.Controls.Add(this.label12);
            this.pnl_stepfive.Controls.Add(this.btn_printconfirmation);
            this.pnl_stepfive.Controls.Add(this.chk_signedform);
            this.pnl_stepfive.Controls.Add(this.lbl_haveyousigned);
            this.pnl_stepfive.Enabled = false;
            this.pnl_stepfive.Location = new System.Drawing.Point(586, 148);
            this.pnl_stepfive.Name = "pnl_stepfive";
            this.pnl_stepfive.Size = new System.Drawing.Size(557, 124);
            this.pnl_stepfive.TabIndex = 135;
            // 
            // cmb_printerpicked2
            // 
            this.cmb_printerpicked2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_printerpicked2.FormattingEnabled = true;
            this.cmb_printerpicked2.Items.AddRange(new object[] {
            "B&W (Large Printer)",
            "Colour (Small Printer)"});
            this.cmb_printerpicked2.Location = new System.Drawing.Point(22, 45);
            this.cmb_printerpicked2.Name = "cmb_printerpicked2";
            this.cmb_printerpicked2.Size = new System.Drawing.Size(234, 33);
            this.cmb_printerpicked2.TabIndex = 234;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(14, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(282, 31);
            this.label12.TabIndex = 104;
            this.label12.Text = "5. Print Confirmation";
            // 
            // btn_printconfirmation
            // 
            this.btn_printconfirmation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_printconfirmation.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_printconfirmation.Location = new System.Drawing.Point(312, 12);
            this.btn_printconfirmation.Name = "btn_printconfirmation";
            this.btn_printconfirmation.Size = new System.Drawing.Size(193, 55);
            this.btn_printconfirmation.TabIndex = 134;
            this.btn_printconfirmation.Text = "Print";
            this.btn_printconfirmation.UseVisualStyleBackColor = false;
            this.btn_printconfirmation.Click += new System.EventHandler(this.btn_printconfirmation_Click);
            // 
            // chk_signedform
            // 
            this.chk_signedform.AutoSize = true;
            this.chk_signedform.Enabled = false;
            this.chk_signedform.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_signedform.Location = new System.Drawing.Point(444, 90);
            this.chk_signedform.Name = "chk_signedform";
            this.chk_signedform.Size = new System.Drawing.Size(57, 20);
            this.chk_signedform.TabIndex = 132;
            this.chk_signedform.Text = "YES";
            this.chk_signedform.UseVisualStyleBackColor = true;
            this.chk_signedform.CheckedChanged += new System.EventHandler(this.chk_signedform_CheckedChanged);
            // 
            // lbl_haveyousigned
            // 
            this.lbl_haveyousigned.AutoSize = true;
            this.lbl_haveyousigned.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_haveyousigned.ForeColor = System.Drawing.Color.Blue;
            this.lbl_haveyousigned.Location = new System.Drawing.Point(6, 79);
            this.lbl_haveyousigned.Name = "lbl_haveyousigned";
            this.lbl_haveyousigned.Size = new System.Drawing.Size(432, 37);
            this.lbl_haveyousigned.TabIndex = 131;
            this.lbl_haveyousigned.Text = "Have you signed the form?:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.cmb_printerpicked1);
            this.panel1.Controls.Add(this.btn_printdailytotal);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Location = new System.Drawing.Point(12, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 84);
            this.panel1.TabIndex = 133;
            // 
            // cmb_printerpicked1
            // 
            this.cmb_printerpicked1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_printerpicked1.FormattingEnabled = true;
            this.cmb_printerpicked1.Items.AddRange(new object[] {
            "B&W (Large Printer)",
            "Colour (Small Printer)"});
            this.cmb_printerpicked1.Location = new System.Drawing.Point(22, 41);
            this.cmb_printerpicked1.Name = "cmb_printerpicked1";
            this.cmb_printerpicked1.Size = new System.Drawing.Size(234, 33);
            this.cmb_printerpicked1.TabIndex = 233;
            // 
            // btn_printdailytotal
            // 
            this.btn_printdailytotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_printdailytotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_printdailytotal.Location = new System.Drawing.Point(291, 11);
            this.btn_printdailytotal.Name = "btn_printdailytotal";
            this.btn_printdailytotal.Size = new System.Drawing.Size(193, 55);
            this.btn_printdailytotal.TabIndex = 103;
            this.btn_printdailytotal.Text = "Print";
            this.btn_printdailytotal.UseVisualStyleBackColor = false;
            this.btn_printdailytotal.Click += new System.EventHandler(this.btn_printdailytotal_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(14, 7);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(271, 31);
            this.label21.TabIndex = 85;
            this.label21.Text = "1. Print Daily Totals";
            // 
            // btn_endday
            // 
            this.btn_endday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_endday.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_endday.Location = new System.Drawing.Point(346, 691);
            this.btn_endday.Name = "btn_endday";
            this.btn_endday.Size = new System.Drawing.Size(223, 64);
            this.btn_endday.TabIndex = 136;
            this.btn_endday.Text = "END DAY";
            this.btn_endday.UseVisualStyleBackColor = false;
            this.btn_endday.Visible = false;
            this.btn_endday.Click += new System.EventHandler(this.btn_endday_Click);
            // 
            // pnl_stepfour
            // 
            this.pnl_stepfour.BackColor = System.Drawing.Color.White;
            this.pnl_stepfour.Controls.Add(this.cmb_worker);
            this.pnl_stepfour.Controls.Add(this.label16);
            this.pnl_stepfour.Enabled = false;
            this.pnl_stepfour.Location = new System.Drawing.Point(586, 58);
            this.pnl_stepfour.Name = "pnl_stepfour";
            this.pnl_stepfour.Size = new System.Drawing.Size(557, 76);
            this.pnl_stepfour.TabIndex = 134;
            // 
            // cmb_worker
            // 
            this.cmb_worker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cmb_worker.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_worker.FormattingEnabled = true;
            this.cmb_worker.Items.AddRange(new object[] {
            "Please Pick...",
            "Jude",
            "Graham",
            "Noel",
            "Peter",
            "Deb"});
            this.cmb_worker.Location = new System.Drawing.Point(245, 18);
            this.cmb_worker.Name = "cmb_worker";
            this.cmb_worker.Size = new System.Drawing.Size(279, 39);
            this.cmb_worker.TabIndex = 137;
            this.cmb_worker.SelectedIndexChanged += new System.EventHandler(this.cmb_worker_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(14, 23);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(221, 31);
            this.label16.TabIndex = 85;
            this.label16.Text = "4. Staff Member";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.txtbox_notes);
            this.panel3.Location = new System.Drawing.Point(586, 291);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(557, 394);
            this.panel3.TabIndex = 135;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(13, 51);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(288, 25);
            this.label17.TabIndex = 135;
            this.label17.Text = "Please enter any notes here:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(14, 11);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(91, 31);
            this.label20.TabIndex = 85;
            this.label20.Text = "Notes";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.lbl_runningtotals);
            this.panel4.Controls.Add(this.label18);
            this.panel4.Location = new System.Drawing.Point(1166, 58);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(346, 627);
            this.panel4.TabIndex = 136;
            // 
            // lbl_runningtotals
            // 
            this.lbl_runningtotals.AutoSize = true;
            this.lbl_runningtotals.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_runningtotals.Location = new System.Drawing.Point(18, 59);
            this.lbl_runningtotals.Name = "lbl_runningtotals";
            this.lbl_runningtotals.Size = new System.Drawing.Size(157, 25);
            this.lbl_runningtotals.TabIndex = 86;
            this.lbl_runningtotals.Text = "Running Totals";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(70, 11);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(211, 31);
            this.label18.TabIndex = 85;
            this.label18.Text = "Running Totals";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1518, 160);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(254, 377);
            this.textBox1.TabIndex = 86;
            this.textBox1.Visible = false;
            // 
            // dt_eodpick
            // 
            this.dt_eodpick.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_eodpick.Location = new System.Drawing.Point(487, 16);
            this.dt_eodpick.Name = "dt_eodpick";
            this.dt_eodpick.Size = new System.Drawing.Size(334, 29);
            this.dt_eodpick.TabIndex = 137;
            this.dt_eodpick.ValueChanged += new System.EventHandler(this.dt_eodpick_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(893, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 23);
            this.button1.TabIndex = 138;
            this.button1.Text = "Send Hours Email";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_dateleft
            // 
            this.btn_dateleft.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dateleft.Location = new System.Drawing.Point(421, 14);
            this.btn_dateleft.Name = "btn_dateleft";
            this.btn_dateleft.Size = new System.Drawing.Size(61, 33);
            this.btn_dateleft.TabIndex = 140;
            this.btn_dateleft.Text = "<--";
            this.btn_dateleft.UseVisualStyleBackColor = true;
            this.btn_dateleft.Click += new System.EventHandler(this.btn_dateleft_Click);
            // 
            // btn_dateright
            // 
            this.btn_dateright.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dateright.Location = new System.Drawing.Point(826, 15);
            this.btn_dateright.Name = "btn_dateright";
            this.btn_dateright.Size = new System.Drawing.Size(61, 33);
            this.btn_dateright.TabIndex = 141;
            this.btn_dateright.Text = "-->";
            this.btn_dateright.UseVisualStyleBackColor = true;
            this.btn_dateright.Click += new System.EventHandler(this.btn_dateright_Click);
            // 
            // lbl_dayend
            // 
            this.lbl_dayend.AutoSize = true;
            this.lbl_dayend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbl_dayend.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dayend.Location = new System.Drawing.Point(12, 705);
            this.lbl_dayend.Name = "lbl_dayend";
            this.lbl_dayend.Size = new System.Drawing.Size(328, 39);
            this.lbl_dayend.TabIndex = 142;
            this.lbl_dayend.Text = "Day Not Yet Ended";
            // 
            // EndOfDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(1529, 874);
            this.Controls.Add(this.lbl_dayend);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_dateright);
            this.Controls.Add(this.btn_dateleft);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dt_eodpick);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnl_stepfour);
            this.Controls.Add(this.btn_endday);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_stepfive);
            this.Controls.Add(this.pnl_steptwo);
            this.Controls.Add(this.pnl_stepsthree);
            this.Controls.Add(this.txt_eodheader);
            this.Name = "EndOfDay";
            this.Text = "EOD";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnl_stepsthree.ResumeLayout(false);
            this.pnl_stepsthree.PerformLayout();
            this.pnl_steptwo.ResumeLayout(false);
            this.pnl_steptwo.PerformLayout();
            this.pnl_stepfive.ResumeLayout(false);
            this.pnl_stepfive.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_stepfour.ResumeLayout(false);
            this.pnl_stepfour.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txt_eodheader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl_total;
        private System.Windows.Forms.TextBox txtbox_notes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_eftposin;
        private System.Windows.Forms.Panel pnl_stepsthree;
        private System.Windows.Forms.Panel pnl_steptwo;
        private System.Windows.Forms.Panel pnl_stepfive;
        private System.Windows.Forms.CheckBox chk_signedform;
        private System.Windows.Forms.Label lbl_haveyousigned;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_sod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_cashin;
        private System.Windows.Forms.Label lbl_refunds;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_printdailytotal;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btn_printconfirmation;
        private System.Windows.Forms.ComboBox cmb_Steptwo;
        private System.Windows.Forms.Button btn_endday;
        private System.Windows.Forms.Label lbl_eftpostotals;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chk_eftposreset;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmb_stepthree;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel pnl_stepfour;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmb_worker;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker dt_eodpick;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmb_printerpicked2;
        private System.Windows.Forms.ComboBox cmb_printerpicked1;
        private System.Windows.Forms.Button btn_dateleft;
        private System.Windows.Forms.Button btn_dateright;
        private System.Windows.Forms.Label lbl_runningtotals;
        private System.Windows.Forms.Label lbl_dayend;
    }
}