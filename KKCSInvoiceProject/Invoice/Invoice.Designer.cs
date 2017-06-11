namespace KKCSInvoiceProject
{
    partial class Invoice
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
            this.txt_firstname = new System.Windows.Forms.TextBox();
            this.cmb_rego = new System.Windows.Forms.ComboBox();
            this.dt_datein = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dt_returndate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_ph = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmb_timeinhours = new System.Windows.Forms.ComboBox();
            this.cmb_timeinminutes = new System.Windows.Forms.ComboBox();
            this.txt_invoiceno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.txt_notes = new System.Windows.Forms.TextBox();
            this.txt_alerts = new System.Windows.Forms.TextBox();
            this.txt_paidstatus = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txt_keyno = new System.Windows.Forms.TextBox();
            this.lbl_accountname = new System.Windows.Forms.Label();
            this.btn_print = new System.Windows.Forms.Button();
            this.btn_mainmenu = new System.Windows.Forms.Button();
            this.btn_returns = new System.Windows.Forms.Button();
            this.txt_flighttimes = new System.Windows.Forms.ComboBox();
            this.lbl_datepaid = new System.Windows.Forms.Label();
            this.btn_keybox = new System.Windows.Forms.Button();
            this.txt_particulars = new System.Windows.Forms.TextBox();
            this.lbl_particulars = new System.Windows.Forms.Label();
            this.btn_update = new System.Windows.Forms.Button();
            this.txt_lastname = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_total = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pnl_refund = new System.Windows.Forms.Panel();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.txt_refundowed = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.lbl_daysearly = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.lbl_changesmade = new System.Windows.Forms.Label();
            this.btn_revertchanges = new System.Windows.Forms.Button();
            this.lbl_pickuptitle = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.txt_account = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.pnl_overdue = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.pnl_splitpayment = new System.Windows.Forms.Panel();
            this.label27 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_makemodel = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.btn_addinv = new System.Windows.Forms.Button();
            this.btn_addcustalert = new System.Windows.Forms.Button();
            this.cmb_paidstatus = new System.Windows.Forms.ComboBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.pnl_refund.SuspendLayout();
            this.pnl_overdue.SuspendLayout();
            this.pnl_splitpayment.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_firstname
            // 
            this.txt_firstname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_firstname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_firstname.Location = new System.Drawing.Point(131, 141);
            this.txt_firstname.Name = "txt_firstname";
            this.txt_firstname.Size = new System.Drawing.Size(267, 31);
            this.txt_firstname.TabIndex = 3;
            this.txt_firstname.TextChanged += new System.EventHandler(this.txt_clientname_TextChanged);
            // 
            // cmb_rego
            // 
            this.cmb_rego.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmb_rego.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_rego.BackColor = System.Drawing.SystemColors.Window;
            this.cmb_rego.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmb_rego.DropDownWidth = 121;
            this.cmb_rego.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_rego.FormattingEnabled = true;
            this.cmb_rego.Location = new System.Drawing.Point(437, 267);
            this.cmb_rego.Name = "cmb_rego";
            this.cmb_rego.Size = new System.Drawing.Size(231, 39);
            this.cmb_rego.TabIndex = 11;
            this.cmb_rego.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.cmb_rego.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // dt_datein
            // 
            this.dt_datein.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold);
            this.dt_datein.Location = new System.Drawing.Point(131, 97);
            this.dt_datein.Name = "dt_datein";
            this.dt_datein.Size = new System.Drawing.Size(285, 23);
            this.dt_datein.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "DATE IN:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Green;
            this.label6.Location = new System.Drawing.Point(56, 354);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 31);
            this.label6.TabIndex = 15;
            this.label6.Text = "DUE DATE:";
            // 
            // dt_returndate
            // 
            this.dt_returndate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_returndate.Location = new System.Drawing.Point(243, 349);
            this.dt_returndate.Name = "dt_returndate";
            this.dt_returndate.Size = new System.Drawing.Size(453, 38);
            this.dt_returndate.TabIndex = 16;
            this.dt_returndate.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(435, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 25);
            this.label7.TabIndex = 17;
            this.label7.Text = "TIME IN:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Green;
            this.label10.Location = new System.Drawing.Point(20, 414);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(204, 31);
            this.label10.TabIndex = 20;
            this.label10.Text = "FLIGHT TIME:";
            // 
            // txt_ph
            // 
            this.txt_ph.AcceptsReturn = true;
            this.txt_ph.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_ph.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ph.Location = new System.Drawing.Point(131, 227);
            this.txt_ph.Name = "txt_ph";
            this.txt_ph.Size = new System.Drawing.Size(267, 31);
            this.txt_ph.TabIndex = 22;
            this.txt_ph.TextChanged += new System.EventHandler(this.txt_ph_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(777, 183);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(146, 25);
            this.label13.TabIndex = 30;
            this.label13.Text = "Total Price $";
            // 
            // cmb_timeinhours
            // 
            this.cmb_timeinhours.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_timeinhours.FormattingEnabled = true;
            this.cmb_timeinhours.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.cmb_timeinhours.Location = new System.Drawing.Point(543, 92);
            this.cmb_timeinhours.Name = "cmb_timeinhours";
            this.cmb_timeinhours.Size = new System.Drawing.Size(51, 33);
            this.cmb_timeinhours.TabIndex = 31;
            this.cmb_timeinhours.Text = "06";
            // 
            // cmb_timeinminutes
            // 
            this.cmb_timeinminutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_timeinminutes.FormattingEnabled = true;
            this.cmb_timeinminutes.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.cmb_timeinminutes.Location = new System.Drawing.Point(600, 92);
            this.cmb_timeinminutes.Name = "cmb_timeinminutes";
            this.cmb_timeinminutes.Size = new System.Drawing.Size(51, 33);
            this.cmb_timeinminutes.TabIndex = 32;
            this.cmb_timeinminutes.Text = "00";
            // 
            // txt_invoiceno
            // 
            this.txt_invoiceno.BackColor = System.Drawing.Color.White;
            this.txt_invoiceno.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_invoiceno.Location = new System.Drawing.Point(98, 15);
            this.txt_invoiceno.Name = "txt_invoiceno";
            this.txt_invoiceno.Size = new System.Drawing.Size(95, 38);
            this.txt_invoiceno.TabIndex = 36;
            this.txt_invoiceno.Text = "00000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 31);
            this.label3.TabIndex = 37;
            this.label3.Text = "INV:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.OrangeRed;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.Color.Black;
            this.btn_save.Location = new System.Drawing.Point(1267, 176);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(174, 68);
            this.btn_save.TabIndex = 38;
            this.btn_save.Text = "UNSAVED";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txt_notes
            // 
            this.txt_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txt_notes.Location = new System.Drawing.Point(25, 519);
            this.txt_notes.Multiline = true;
            this.txt_notes.Name = "txt_notes";
            this.txt_notes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_notes.Size = new System.Drawing.Size(254, 208);
            this.txt_notes.TabIndex = 39;
            this.txt_notes.Visible = false;
            this.txt_notes.TextChanged += new System.EventHandler(this.txt_notes_TextChanged);
            // 
            // txt_alerts
            // 
            this.txt_alerts.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txt_alerts.Location = new System.Drawing.Point(319, 519);
            this.txt_alerts.Multiline = true;
            this.txt_alerts.Name = "txt_alerts";
            this.txt_alerts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_alerts.Size = new System.Drawing.Size(254, 208);
            this.txt_alerts.TabIndex = 58;
            this.txt_alerts.Visible = false;
            this.txt_alerts.TextChanged += new System.EventHandler(this.txt_alerts_TextChanged);
            // 
            // txt_paidstatus
            // 
            this.txt_paidstatus.AutoSize = true;
            this.txt_paidstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_paidstatus.Location = new System.Drawing.Point(737, 270);
            this.txt_paidstatus.Name = "txt_paidstatus";
            this.txt_paidstatus.Size = new System.Drawing.Size(167, 25);
            this.txt_paidstatus.TabIndex = 59;
            this.txt_paidstatus.Text = "PAID STATUS:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(233, 18);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 31);
            this.label18.TabIndex = 62;
            this.label18.Text = "KEY:";
            // 
            // txt_keyno
            // 
            this.txt_keyno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txt_keyno.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_keyno.Location = new System.Drawing.Point(316, 17);
            this.txt_keyno.Name = "txt_keyno";
            this.txt_keyno.Size = new System.Drawing.Size(75, 38);
            this.txt_keyno.TabIndex = 63;
            // 
            // lbl_accountname
            // 
            this.lbl_accountname.AutoSize = true;
            this.lbl_accountname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_accountname.Location = new System.Drawing.Point(780, 18);
            this.lbl_accountname.Name = "lbl_accountname";
            this.lbl_accountname.Size = new System.Drawing.Size(58, 25);
            this.lbl_accountname.TabIndex = 65;
            this.lbl_accountname.Text = "Acc:";
            this.lbl_accountname.Visible = false;
            this.lbl_accountname.Click += new System.EventHandler(this.lbl_accountname_Click);
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_print.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_print.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_print.Location = new System.Drawing.Point(924, 421);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(145, 41);
            this.btn_print.TabIndex = 71;
            this.btn_print.Text = "Print Receipt";
            this.btn_print.UseVisualStyleBackColor = false;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // btn_mainmenu
            // 
            this.btn_mainmenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_mainmenu.Location = new System.Drawing.Point(1296, 14);
            this.btn_mainmenu.Name = "btn_mainmenu";
            this.btn_mainmenu.Size = new System.Drawing.Size(105, 37);
            this.btn_mainmenu.TabIndex = 73;
            this.btn_mainmenu.Text = "Main Menu";
            this.btn_mainmenu.UseVisualStyleBackColor = true;
            this.btn_mainmenu.Click += new System.EventHandler(this.btn_mainmenu_Click);
            // 
            // btn_returns
            // 
            this.btn_returns.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_returns.Location = new System.Drawing.Point(1296, 61);
            this.btn_returns.Name = "btn_returns";
            this.btn_returns.Size = new System.Drawing.Size(105, 37);
            this.btn_returns.TabIndex = 74;
            this.btn_returns.Text = "Returns";
            this.btn_returns.UseVisualStyleBackColor = true;
            this.btn_returns.Click += new System.EventHandler(this.btn_returns_Click);
            // 
            // txt_flighttimes
            // 
            this.txt_flighttimes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txt_flighttimes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txt_flighttimes.BackColor = System.Drawing.SystemColors.Window;
            this.txt_flighttimes.Cursor = System.Windows.Forms.Cursors.Default;
            this.txt_flighttimes.DropDownWidth = 121;
            this.txt_flighttimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_flighttimes.FormattingEnabled = true;
            this.txt_flighttimes.Items.AddRange(new object[] {
            "0920",
            "0935",
            "1110",
            "1140",
            "1245",
            "1350",
            "1525",
            "1610",
            "1710",
            "1840",
            "1930"});
            this.txt_flighttimes.Location = new System.Drawing.Point(243, 411);
            this.txt_flighttimes.Name = "txt_flighttimes";
            this.txt_flighttimes.Size = new System.Drawing.Size(96, 37);
            this.txt_flighttimes.TabIndex = 85;
            this.txt_flighttimes.SelectedIndexChanged += new System.EventHandler(this.txt_flighttimes_SelectedIndexChanged);
            // 
            // lbl_datepaid
            // 
            this.lbl_datepaid.AutoSize = true;
            this.lbl_datepaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_datepaid.ForeColor = System.Drawing.Color.Blue;
            this.lbl_datepaid.Location = new System.Drawing.Point(1098, 187);
            this.lbl_datepaid.Name = "lbl_datepaid";
            this.lbl_datepaid.Size = new System.Drawing.Size(124, 20);
            this.lbl_datepaid.TabIndex = 88;
            this.lbl_datepaid.Text = "Paid: 17/06/16";
            // 
            // btn_keybox
            // 
            this.btn_keybox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_keybox.Location = new System.Drawing.Point(1296, 109);
            this.btn_keybox.Name = "btn_keybox";
            this.btn_keybox.Size = new System.Drawing.Size(105, 37);
            this.btn_keybox.TabIndex = 92;
            this.btn_keybox.Text = "Key Box";
            this.btn_keybox.UseVisualStyleBackColor = true;
            this.btn_keybox.Click += new System.EventHandler(this.btn_keybox_Click);
            // 
            // txt_particulars
            // 
            this.txt_particulars.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txt_particulars.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_particulars.Location = new System.Drawing.Point(844, 51);
            this.txt_particulars.Name = "txt_particulars";
            this.txt_particulars.Size = new System.Drawing.Size(225, 26);
            this.txt_particulars.TabIndex = 94;
            this.txt_particulars.Visible = false;
            this.txt_particulars.TextChanged += new System.EventHandler(this.txt_particulars_TextChanged);
            // 
            // lbl_particulars
            // 
            this.lbl_particulars.AutoSize = true;
            this.lbl_particulars.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_particulars.Location = new System.Drawing.Point(770, 51);
            this.lbl_particulars.Name = "lbl_particulars";
            this.lbl_particulars.Size = new System.Drawing.Size(68, 25);
            this.lbl_particulars.TabIndex = 96;
            this.lbl_particulars.Text = "Parti:";
            this.lbl_particulars.Visible = false;
            this.lbl_particulars.Click += new System.EventHandler(this.lbl_particulars_Click);
            // 
            // btn_update
            // 
            this.btn_update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update.ForeColor = System.Drawing.Color.White;
            this.btn_update.Location = new System.Drawing.Point(1366, 363);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(139, 63);
            this.btn_update.TabIndex = 100;
            this.btn_update.Text = "UPDATE CHANGES";
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Visible = false;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // txt_lastname
            // 
            this.txt_lastname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_lastname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_lastname.Location = new System.Drawing.Point(131, 183);
            this.txt_lastname.Name = "txt_lastname";
            this.txt_lastname.Size = new System.Drawing.Size(267, 31);
            this.txt_lastname.TabIndex = 105;
            this.txt_lastname.TextChanged += new System.EventHandler(this.txt_lastname_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(932, 221);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 13);
            this.label8.TabIndex = 115;
            this.label8.Text = "(Credit Card fee of 2% applies)";
            // 
            // txt_total
            // 
            this.txt_total.BackColor = System.Drawing.SystemColors.Info;
            this.txt_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_total.ForeColor = System.Drawing.Color.ForestGreen;
            this.txt_total.Location = new System.Drawing.Point(929, 174);
            this.txt_total.Name = "txt_total";
            this.txt_total.Size = new System.Drawing.Size(160, 44);
            this.txt_total.TabIndex = 29;
            this.txt_total.TextChanged += new System.EventHandler(this.txt_total_TextChanged);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(20, 144);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(100, 25);
            this.label37.TabIndex = 137;
            this.label37.Text = "F/Name:";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(20, 184);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(99, 25);
            this.label38.TabIndex = 138;
            this.label38.Text = "L/Name:";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(22, 230);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(83, 25);
            this.label39.TabIndex = 139;
            this.label39.Text = "Ph No:";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(23, 276);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(76, 25);
            this.label40.TabIndex = 140;
            this.label40.Text = "Make:";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(514, 235);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(74, 25);
            this.label41.TabIndex = 141;
            this.label41.Text = "Rego:";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(787, 215);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 29);
            this.button2.TabIndex = 142;
            this.button2.Text = "Use $20 Credit";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(12, 140);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(112, 20);
            this.label28.TabIndex = 148;
            this.label28.Text = "Paid Status: ";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Cash",
            "Credit Card",
            "Eftpos",
            "Internet",
            "Cheque",
            "N/C",
            "To Pay"});
            this.comboBox1.Location = new System.Drawing.Point(128, 139);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 147;
            // 
            // pnl_refund
            // 
            this.pnl_refund.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnl_refund.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_refund.Controls.Add(this.checkBox4);
            this.pnl_refund.Controls.Add(this.textBox5);
            this.pnl_refund.Controls.Add(this.txt_refundowed);
            this.pnl_refund.Controls.Add(this.comboBox2);
            this.pnl_refund.Controls.Add(this.label43);
            this.pnl_refund.Controls.Add(this.label42);
            this.pnl_refund.Controls.Add(this.lbl_daysearly);
            this.pnl_refund.Controls.Add(this.label25);
            this.pnl_refund.Location = new System.Drawing.Point(600, 519);
            this.pnl_refund.Name = "pnl_refund";
            this.pnl_refund.Size = new System.Drawing.Size(254, 208);
            this.pnl_refund.TabIndex = 144;
            this.pnl_refund.Visible = false;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox4.ForeColor = System.Drawing.Color.White;
            this.checkBox4.Location = new System.Drawing.Point(12, 157);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(213, 20);
            this.checkBox4.TabIndex = 152;
            this.checkBox4.Text = "ADD AS CREDIT INSTEAD";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.White;
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(91, 6);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(80, 22);
            this.textBox5.TabIndex = 149;
            this.textBox5.Text = "R-0000";
            // 
            // txt_refundowed
            // 
            this.txt_refundowed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_refundowed.Location = new System.Drawing.Point(138, 74);
            this.txt_refundowed.Name = "txt_refundowed";
            this.txt_refundowed.Size = new System.Drawing.Size(98, 22);
            this.txt_refundowed.TabIndex = 149;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Till",
            "Plastic Box"});
            this.comboBox2.Location = new System.Drawing.Point(138, 116);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(99, 21);
            this.comboBox2.TabIndex = 149;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.ForeColor = System.Drawing.Color.White;
            this.label43.Location = new System.Drawing.Point(10, 115);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(129, 20);
            this.label43.TabIndex = 150;
            this.label43.Text = "From Location:";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.White;
            this.label42.Location = new System.Drawing.Point(9, 75);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(123, 20);
            this.label42.TabIndex = 149;
            this.label42.Text = "Refund Owed:";
            // 
            // lbl_daysearly
            // 
            this.lbl_daysearly.AutoSize = true;
            this.lbl_daysearly.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_daysearly.ForeColor = System.Drawing.Color.White;
            this.lbl_daysearly.Location = new System.Drawing.Point(10, 40);
            this.lbl_daysearly.Name = "lbl_daysearly";
            this.lbl_daysearly.Size = new System.Drawing.Size(104, 20);
            this.lbl_daysearly.TabIndex = 149;
            this.lbl_daysearly.Text = "Days Early: ";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(8, 5);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(68, 20);
            this.label25.TabIndex = 1;
            this.label25.Text = "Refund";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Enabled = false;
            this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox3.Location = new System.Drawing.Point(600, 489);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(76, 20);
            this.checkBox3.TabIndex = 153;
            this.checkBox3.Text = "Refund";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // lbl_changesmade
            // 
            this.lbl_changesmade.AutoSize = true;
            this.lbl_changesmade.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_changesmade.ForeColor = System.Drawing.Color.Red;
            this.lbl_changesmade.Location = new System.Drawing.Point(1234, 276);
            this.lbl_changesmade.Name = "lbl_changesmade";
            this.lbl_changesmade.Size = new System.Drawing.Size(245, 74);
            this.lbl_changesmade.TabIndex = 154;
            this.lbl_changesmade.Text = "WARNING!\r\nChanges Made";
            this.lbl_changesmade.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_changesmade.Visible = false;
            this.lbl_changesmade.Click += new System.EventHandler(this.lbl_changesmade_Click);
            // 
            // btn_revertchanges
            // 
            this.btn_revertchanges.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_revertchanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_revertchanges.ForeColor = System.Drawing.Color.Black;
            this.btn_revertchanges.Location = new System.Drawing.Point(1222, 363);
            this.btn_revertchanges.Name = "btn_revertchanges";
            this.btn_revertchanges.Size = new System.Drawing.Size(138, 63);
            this.btn_revertchanges.TabIndex = 155;
            this.btn_revertchanges.Text = "REVERT CHANGES";
            this.btn_revertchanges.UseVisualStyleBackColor = false;
            this.btn_revertchanges.Visible = false;
            this.btn_revertchanges.Click += new System.EventHandler(this.btn_revertchanges_Click);
            // 
            // lbl_pickuptitle
            // 
            this.lbl_pickuptitle.AutoSize = true;
            this.lbl_pickuptitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pickuptitle.Location = new System.Drawing.Point(796, 335);
            this.lbl_pickuptitle.Name = "lbl_pickuptitle";
            this.lbl_pickuptitle.Size = new System.Drawing.Size(108, 20);
            this.lbl_pickuptitle.TabIndex = 156;
            this.lbl_pickuptitle.Text = "PICKED UP:";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(760, 372);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(144, 20);
            this.label45.TabIndex = 159;
            this.label45.Text = "CAR LOCATION:";
            // 
            // txt_account
            // 
            this.txt_account.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txt_account.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_account.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_account.Location = new System.Drawing.Point(844, 18);
            this.txt_account.Name = "txt_account";
            this.txt_account.Size = new System.Drawing.Size(377, 26);
            this.txt_account.TabIndex = 163;
            this.txt_account.Visible = false;
            this.txt_account.TextChanged += new System.EventHandler(this.txt_account_TextChanged);
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(1075, 51);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(97, 25);
            this.button5.TabIndex = 164;
            this.button5.Text = "Edit Account";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(877, 488);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(122, 20);
            this.checkBox1.TabIndex = 166;
            this.checkBox1.Text = "Split Payment";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Enabled = false;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.Location = new System.Drawing.Point(1151, 489);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(86, 20);
            this.checkBox2.TabIndex = 167;
            this.checkBox2.Text = "Overdue";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // pnl_overdue
            // 
            this.pnl_overdue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnl_overdue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_overdue.Controls.Add(this.comboBox1);
            this.pnl_overdue.Controls.Add(this.label28);
            this.pnl_overdue.Controls.Add(this.textBox3);
            this.pnl_overdue.Controls.Add(this.textBox6);
            this.pnl_overdue.Controls.Add(this.label44);
            this.pnl_overdue.Controls.Add(this.label46);
            this.pnl_overdue.Controls.Add(this.label47);
            this.pnl_overdue.Location = new System.Drawing.Point(1151, 519);
            this.pnl_overdue.Name = "pnl_overdue";
            this.pnl_overdue.Size = new System.Drawing.Size(254, 208);
            this.pnl_overdue.TabIndex = 153;
            this.pnl_overdue.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(164, 6);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(80, 22);
            this.textBox3.TabIndex = 149;
            this.textBox3.Text = "OC-0000";
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(139, 86);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(98, 22);
            this.textBox6.TabIndex = 149;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.ForeColor = System.Drawing.Color.White;
            this.label44.Location = new System.Drawing.Point(10, 87);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(106, 20);
            this.label44.TabIndex = 149;
            this.label44.Text = "Extra Owed:";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.ForeColor = System.Drawing.Color.White;
            this.label46.Location = new System.Drawing.Point(10, 45);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(131, 20);
            this.label46.TabIndex = 149;
            this.label46.Text = "Days Overdue: ";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.ForeColor = System.Drawing.Color.White;
            this.label47.Location = new System.Drawing.Point(8, 5);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(148, 20);
            this.label47.TabIndex = 1;
            this.label47.Text = "Overdue Charges";
            // 
            // pnl_splitpayment
            // 
            this.pnl_splitpayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnl_splitpayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_splitpayment.Controls.Add(this.label27);
            this.pnl_splitpayment.Controls.Add(this.textBox1);
            this.pnl_splitpayment.Controls.Add(this.textBox2);
            this.pnl_splitpayment.Controls.Add(this.comboBox3);
            this.pnl_splitpayment.Controls.Add(this.label17);
            this.pnl_splitpayment.Controls.Add(this.label26);
            this.pnl_splitpayment.Controls.Add(this.label35);
            this.pnl_splitpayment.Location = new System.Drawing.Point(877, 519);
            this.pnl_splitpayment.Name = "pnl_splitpayment";
            this.pnl_splitpayment.Size = new System.Drawing.Size(254, 208);
            this.pnl_splitpayment.TabIndex = 153;
            this.pnl_splitpayment.Visible = false;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(10, 41);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(158, 40);
            this.label27.TabIndex = 153;
            this.label27.Text = "(First Payment Is \r\nAbove Per Normal)";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(143, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(80, 22);
            this.textBox1.TabIndex = 149;
            this.textBox1.Text = "SP-0000";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(140, 97);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(98, 22);
            this.textBox2.TabIndex = 149;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Till",
            "Plastic Box"});
            this.comboBox3.Location = new System.Drawing.Point(140, 140);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(99, 21);
            this.comboBox3.TabIndex = 149;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(10, 137);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(129, 20);
            this.label17.TabIndex = 150;
            this.label17.Text = "From Location:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(11, 97);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(76, 20);
            this.label26.TabIndex = 149;
            this.label26.Text = "Amount:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.Color.White;
            this.label35.Location = new System.Drawing.Point(8, 5);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(119, 20);
            this.label35.TabIndex = 1;
            this.label35.Text = "Split Payment";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(779, 137);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(327, 25);
            this.label11.TabIndex = 26;
            this.label11.Text = "Please Pick Return Date/Time";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(415, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 31);
            this.button1.TabIndex = 168;
            this.button1.Text = "Search By Name";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // txt_makemodel
            // 
            this.txt_makemodel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txt_makemodel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txt_makemodel.BackColor = System.Drawing.SystemColors.Window;
            this.txt_makemodel.Cursor = System.Windows.Forms.Cursors.Default;
            this.txt_makemodel.DropDownWidth = 121;
            this.txt_makemodel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_makemodel.FormattingEnabled = true;
            this.txt_makemodel.Location = new System.Drawing.Point(130, 272);
            this.txt_makemodel.Name = "txt_makemodel";
            this.txt_makemodel.Size = new System.Drawing.Size(268, 33);
            this.txt_makemodel.TabIndex = 169;
            // 
            // comboBox4
            // 
            this.comboBox4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBox4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox4.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox4.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBox4.DropDownWidth = 121;
            this.comboBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "Standard - Coming In On Flight",
            "Unknown Date & Time",
            "Unknown Date",
            "Unknown Time",
            "Driving Back",
            "Bus",
            "Non-Flight",
            "Other"});
            this.comboBox4.Location = new System.Drawing.Point(362, 416);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(334, 28);
            this.comboBox4.TabIndex = 170;
            // 
            // btn_addinv
            // 
            this.btn_addinv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addinv.Location = new System.Drawing.Point(25, 483);
            this.btn_addinv.Name = "btn_addinv";
            this.btn_addinv.Size = new System.Drawing.Size(215, 29);
            this.btn_addinv.TabIndex = 171;
            this.btn_addinv.Text = "Add Invoice 00000 Note";
            this.btn_addinv.UseVisualStyleBackColor = true;
            // 
            // btn_addcustalert
            // 
            this.btn_addcustalert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addcustalert.Location = new System.Drawing.Point(319, 484);
            this.btn_addcustalert.Name = "btn_addcustalert";
            this.btn_addcustalert.Size = new System.Drawing.Size(178, 29);
            this.btn_addcustalert.TabIndex = 172;
            this.btn_addcustalert.Text = "Add Customer Alert";
            this.btn_addcustalert.UseVisualStyleBackColor = true;
            // 
            // cmb_paidstatus
            // 
            this.cmb_paidstatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmb_paidstatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_paidstatus.BackColor = System.Drawing.SystemColors.Window;
            this.cmb_paidstatus.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmb_paidstatus.DropDownWidth = 121;
            this.cmb_paidstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_paidstatus.FormattingEnabled = true;
            this.cmb_paidstatus.Items.AddRange(new object[] {
            "Please Pick a Status...",
            "",
            "Cash",
            "Eftpos",
            "Credit Card",
            "",
            "On Account",
            "",
            "No Charge",
            "",
            "To Pay",
            "",
            "Internet",
            "Cheque"});
            this.cmb_paidstatus.Location = new System.Drawing.Point(909, 262);
            this.cmb_paidstatus.Name = "cmb_paidstatus";
            this.cmb_paidstatus.Size = new System.Drawing.Size(231, 39);
            this.cmb_paidstatus.TabIndex = 173;
            // 
            // comboBox5
            // 
            this.comboBox5.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBox5.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox5.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox5.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBox5.DropDownWidth = 121;
            this.comboBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] {
            "Car In Yard",
            "Car Is Picked Up"});
            this.comboBox5.Location = new System.Drawing.Point(914, 331);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(231, 28);
            this.comboBox5.TabIndex = 174;
            // 
            // comboBox6
            // 
            this.comboBox6.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBox6.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox6.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox6.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBox6.DropDownWidth = 121;
            this.comboBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Items.AddRange(new object[] {
            "Front",
            "Back"});
            this.comboBox6.Location = new System.Drawing.Point(914, 369);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(231, 28);
            this.comboBox6.TabIndex = 175;
            // 
            // Invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(1525, 734);
            this.Controls.Add(this.comboBox6);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.cmb_paidstatus);
            this.Controls.Add(this.btn_addcustalert);
            this.Controls.Add(this.btn_addinv);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.txt_makemodel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pnl_splitpayment);
            this.Controls.Add(this.pnl_overdue);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.txt_account);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.lbl_pickuptitle);
            this.Controls.Add(this.btn_revertchanges);
            this.Controls.Add(this.lbl_changesmade);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.pnl_refund);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_lastname);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.lbl_particulars);
            this.Controls.Add(this.txt_particulars);
            this.Controls.Add(this.btn_keybox);
            this.Controls.Add(this.lbl_datepaid);
            this.Controls.Add(this.txt_flighttimes);
            this.Controls.Add(this.btn_returns);
            this.Controls.Add(this.btn_mainmenu);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.lbl_accountname);
            this.Controls.Add(this.txt_keyno);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txt_paidstatus);
            this.Controls.Add(this.txt_alerts);
            this.Controls.Add(this.txt_notes);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_invoiceno);
            this.Controls.Add(this.cmb_timeinminutes);
            this.Controls.Add(this.cmb_timeinhours);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txt_total);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_ph);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dt_returndate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dt_datein);
            this.Controls.Add(this.cmb_rego);
            this.Controls.Add(this.txt_firstname);
            this.Name = "Invoice";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.pnl_refund.ResumeLayout(false);
            this.pnl_refund.PerformLayout();
            this.pnl_overdue.ResumeLayout(false);
            this.pnl_overdue.PerformLayout();
            this.pnl_splitpayment.ResumeLayout(false);
            this.pnl_splitpayment.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Invoice_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.TextBox txt_firstname;
        private System.Windows.Forms.ComboBox cmb_rego;
        private System.Windows.Forms.DateTimePicker dt_datein;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dt_returndate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_ph;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmb_timeinhours;
        private System.Windows.Forms.ComboBox cmb_timeinminutes;
        private System.Windows.Forms.TextBox txt_invoiceno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox txt_notes;
        private System.Windows.Forms.TextBox txt_alerts;
        private System.Windows.Forms.Label txt_paidstatus;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txt_keyno;
        private System.Windows.Forms.Label lbl_accountname;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Button btn_mainmenu;
        private System.Windows.Forms.Button btn_returns;
        private System.Windows.Forms.ComboBox txt_flighttimes;
        private System.Windows.Forms.Label lbl_datepaid;
        private System.Windows.Forms.Button btn_keybox;
        private System.Windows.Forms.TextBox txt_particulars;
        private System.Windows.Forms.Label lbl_particulars;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.TextBox txt_lastname;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_total;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel pnl_refund;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txt_refundowed;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label lbl_daysearly;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label lbl_changesmade;
        private System.Windows.Forms.Button btn_revertchanges;
        private System.Windows.Forms.Label lbl_pickuptitle;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox txt_account;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Panel pnl_overdue;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Panel pnl_splitpayment;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox txt_makemodel;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Button btn_addinv;
        private System.Windows.Forms.Button btn_addcustalert;
        private System.Windows.Forms.ComboBox cmb_paidstatus;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.ComboBox comboBox6;
    }
}