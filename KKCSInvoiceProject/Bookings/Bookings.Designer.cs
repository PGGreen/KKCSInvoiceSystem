namespace KKCSInvoiceProject
{
    partial class Bookings
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
            this.dt_dateright = new System.Windows.Forms.Button();
            this.dt_dateleft = new System.Windows.Forms.Button();
            this.cmb_makemodel = new System.Windows.Forms.ComboBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.txt_lastname = new System.Windows.Forms.TextBox();
            this.lbl_particulars = new System.Windows.Forms.Label();
            this.txt_particulars = new System.Windows.Forms.TextBox();
            this.txt_flighttimes = new System.Windows.Forms.ComboBox();
            this.lbl_accountname = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.txt_ph = new System.Windows.Forms.TextBox();
            this.lbl_flighttime = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dt_returndate = new System.Windows.Forms.DateTimePicker();
            this.lbl_returndate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_rego = new System.Windows.Forms.ComboBox();
            this.txt_firstname = new System.Windows.Forms.TextBox();
            this.cmb_flightleaving = new System.Windows.Forms.ComboBox();
            this.txt_notes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_dlright = new System.Windows.Forms.Button();
            this.btn_dlleft = new System.Windows.Forms.Button();
            this.dt_customerleaving = new System.Windows.Forms.DateTimePicker();
            this.cmd_accountlist = new System.Windows.Forms.ComboBox();
            this.btn_update = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dt_dateright
            // 
            this.dt_dateright.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_dateright.Location = new System.Drawing.Point(718, 443);
            this.dt_dateright.Name = "dt_dateright";
            this.dt_dateright.Size = new System.Drawing.Size(37, 31);
            this.dt_dateright.TabIndex = 303;
            this.dt_dateright.Text = "-->";
            this.dt_dateright.UseVisualStyleBackColor = true;
            this.dt_dateright.Click += new System.EventHandler(this.dt_dateright_Click);
            // 
            // dt_dateleft
            // 
            this.dt_dateleft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_dateleft.Location = new System.Drawing.Point(203, 443);
            this.dt_dateleft.Name = "dt_dateleft";
            this.dt_dateleft.Size = new System.Drawing.Size(37, 31);
            this.dt_dateleft.TabIndex = 302;
            this.dt_dateleft.Text = "<--";
            this.dt_dateleft.UseVisualStyleBackColor = true;
            this.dt_dateleft.Click += new System.EventHandler(this.dt_dateleft_Click);
            // 
            // cmb_makemodel
            // 
            this.cmb_makemodel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmb_makemodel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_makemodel.BackColor = System.Drawing.SystemColors.Window;
            this.cmb_makemodel.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmb_makemodel.DropDownWidth = 121;
            this.cmb_makemodel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_makemodel.FormattingEnabled = true;
            this.cmb_makemodel.Location = new System.Drawing.Point(134, 281);
            this.cmb_makemodel.Name = "cmb_makemodel";
            this.cmb_makemodel.Size = new System.Drawing.Size(268, 33);
            this.cmb_makemodel.TabIndex = 286;
            this.cmb_makemodel.SelectedIndexChanged += new System.EventHandler(this.cmb_makemodel_SelectedIndexChanged);
            this.cmb_makemodel.TextChanged += new System.EventHandler(this.cmb_makemodel_TextChanged);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(23, 22);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(74, 25);
            this.label41.TabIndex = 274;
            this.label41.Text = "Rego:";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(27, 285);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(76, 25);
            this.label40.TabIndex = 273;
            this.label40.Text = "Make:";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(26, 239);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(83, 25);
            this.label39.TabIndex = 272;
            this.label39.Text = "Ph No:";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(24, 193);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(99, 25);
            this.label38.TabIndex = 271;
            this.label38.Text = "L/Name:";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(24, 153);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(100, 25);
            this.label37.TabIndex = 270;
            this.label37.Text = "F/Name:";
            // 
            // txt_lastname
            // 
            this.txt_lastname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_lastname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_lastname.Location = new System.Drawing.Point(135, 192);
            this.txt_lastname.Name = "txt_lastname";
            this.txt_lastname.Size = new System.Drawing.Size(267, 31);
            this.txt_lastname.TabIndex = 268;
            this.txt_lastname.TextChanged += new System.EventHandler(this.txt_lastname_TextChanged);
            // 
            // lbl_particulars
            // 
            this.lbl_particulars.AutoSize = true;
            this.lbl_particulars.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_particulars.Location = new System.Drawing.Point(0, 373);
            this.lbl_particulars.Name = "lbl_particulars";
            this.lbl_particulars.Size = new System.Drawing.Size(68, 25);
            this.lbl_particulars.TabIndex = 266;
            this.lbl_particulars.Text = "Parti:";
            // 
            // txt_particulars
            // 
            this.txt_particulars.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txt_particulars.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_particulars.Location = new System.Drawing.Point(74, 373);
            this.txt_particulars.Name = "txt_particulars";
            this.txt_particulars.Size = new System.Drawing.Size(225, 26);
            this.txt_particulars.TabIndex = 265;
            this.txt_particulars.TextChanged += new System.EventHandler(this.txt_particulars_TextChanged);
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
            "Time Not Known",
            "0920",
            "1215",
            "1440",
            "1720",
            "2025"});
            this.txt_flighttimes.Location = new System.Drawing.Point(244, 484);
            this.txt_flighttimes.Name = "txt_flighttimes";
            this.txt_flighttimes.Size = new System.Drawing.Size(198, 37);
            this.txt_flighttimes.TabIndex = 263;
            this.txt_flighttimes.SelectedIndexChanged += new System.EventHandler(this.txt_flighttimes_SelectedIndexChanged);
            // 
            // lbl_accountname
            // 
            this.lbl_accountname.AutoSize = true;
            this.lbl_accountname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_accountname.Location = new System.Drawing.Point(10, 340);
            this.lbl_accountname.Name = "lbl_accountname";
            this.lbl_accountname.Size = new System.Drawing.Size(58, 25);
            this.lbl_accountname.TabIndex = 259;
            this.lbl_accountname.Text = "Acc:";
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.OrangeRed;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.Color.Black;
            this.btn_save.Location = new System.Drawing.Point(14, 549);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(174, 68);
            this.btn_save.TabIndex = 254;
            this.btn_save.Text = "UNSAVED";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txt_ph
            // 
            this.txt_ph.AcceptsReturn = true;
            this.txt_ph.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_ph.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ph.Location = new System.Drawing.Point(135, 236);
            this.txt_ph.Name = "txt_ph";
            this.txt_ph.Size = new System.Drawing.Size(267, 31);
            this.txt_ph.TabIndex = 247;
            this.txt_ph.TextChanged += new System.EventHandler(this.txt_ph_TextChanged);
            // 
            // lbl_flighttime
            // 
            this.lbl_flighttime.AutoSize = true;
            this.lbl_flighttime.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_flighttime.ForeColor = System.Drawing.Color.Green;
            this.lbl_flighttime.Location = new System.Drawing.Point(9, 488);
            this.lbl_flighttime.Name = "lbl_flighttime";
            this.lbl_flighttime.Size = new System.Drawing.Size(225, 29);
            this.lbl_flighttime.TabIndex = 246;
            this.lbl_flighttime.Text = "RETURN FLIGHT:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(364, 25);
            this.label7.TabIndex = 245;
            this.label7.Text = "FLIGHT THEY ARE LEAVING ON:";
            // 
            // dt_returndate
            // 
            this.dt_returndate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_returndate.Location = new System.Drawing.Point(244, 440);
            this.dt_returndate.Name = "dt_returndate";
            this.dt_returndate.Size = new System.Drawing.Size(468, 38);
            this.dt_returndate.TabIndex = 244;
            this.dt_returndate.ValueChanged += new System.EventHandler(this.dt_returndate_ValueChanged);
            // 
            // lbl_returndate
            // 
            this.lbl_returndate.AutoSize = true;
            this.lbl_returndate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_returndate.ForeColor = System.Drawing.Color.Green;
            this.lbl_returndate.Location = new System.Drawing.Point(3, 445);
            this.lbl_returndate.Name = "lbl_returndate";
            this.lbl_returndate.Size = new System.Drawing.Size(202, 29);
            this.lbl_returndate.TabIndex = 243;
            this.lbl_returndate.Text = "RETURN DATE:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(372, 25);
            this.label5.TabIndex = 242;
            this.label5.Text = "DATE CUSTOMER LEAVING CAR:";
            // 
            // cmb_rego
            // 
            this.cmb_rego.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_rego.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_rego.BackColor = System.Drawing.SystemColors.Window;
            this.cmb_rego.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmb_rego.DropDownWidth = 121;
            this.cmb_rego.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_rego.FormattingEnabled = true;
            this.cmb_rego.Location = new System.Drawing.Point(103, 13);
            this.cmb_rego.Name = "cmb_rego";
            this.cmb_rego.Size = new System.Drawing.Size(231, 39);
            this.cmb_rego.TabIndex = 240;
            this.cmb_rego.SelectedIndexChanged += new System.EventHandler(this.cmb_rego_SelectedIndexChanged);
            this.cmb_rego.TextChanged += new System.EventHandler(this.cmb_text_TextChanged);
            // 
            // txt_firstname
            // 
            this.txt_firstname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_firstname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_firstname.Location = new System.Drawing.Point(135, 150);
            this.txt_firstname.Name = "txt_firstname";
            this.txt_firstname.Size = new System.Drawing.Size(267, 31);
            this.txt_firstname.TabIndex = 239;
            this.txt_firstname.TextChanged += new System.EventHandler(this.txt_firstname_TextChanged);
            // 
            // cmb_flightleaving
            // 
            this.cmb_flightleaving.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmb_flightleaving.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_flightleaving.BackColor = System.Drawing.SystemColors.Window;
            this.cmb_flightleaving.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmb_flightleaving.DropDownWidth = 121;
            this.cmb_flightleaving.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_flightleaving.FormattingEnabled = true;
            this.cmb_flightleaving.Items.AddRange(new object[] {
            "Time Not Known",
            "0600",
            "0640",
            "0945",
            "1240",
            "1505",
            "1745"});
            this.cmb_flightleaving.Location = new System.Drawing.Point(395, 108);
            this.cmb_flightleaving.Name = "cmb_flightleaving";
            this.cmb_flightleaving.Size = new System.Drawing.Size(198, 37);
            this.cmb_flightleaving.TabIndex = 307;
            this.cmb_flightleaving.SelectedIndexChanged += new System.EventHandler(this.cmb_flightleaving_SelectedIndexChanged);
            // 
            // txt_notes
            // 
            this.txt_notes.BackColor = System.Drawing.Color.White;
            this.txt_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txt_notes.Location = new System.Drawing.Point(580, 190);
            this.txt_notes.Multiline = true;
            this.txt_notes.Name = "txt_notes";
            this.txt_notes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_notes.Size = new System.Drawing.Size(254, 208);
            this.txt_notes.TabIndex = 309;
            this.txt_notes.TextChanged += new System.EventHandler(this.txt_notes_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(575, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 25);
            this.label3.TabIndex = 310;
            this.label3.Text = "Notes:";
            // 
            // btn_dlright
            // 
            this.btn_dlright.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dlright.Location = new System.Drawing.Point(916, 65);
            this.btn_dlright.Name = "btn_dlright";
            this.btn_dlright.Size = new System.Drawing.Size(37, 31);
            this.btn_dlright.TabIndex = 313;
            this.btn_dlright.Text = "-->";
            this.btn_dlright.UseVisualStyleBackColor = true;
            this.btn_dlright.Click += new System.EventHandler(this.btn_dlright_Click);
            // 
            // btn_dlleft
            // 
            this.btn_dlleft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dlleft.Location = new System.Drawing.Point(401, 65);
            this.btn_dlleft.Name = "btn_dlleft";
            this.btn_dlleft.Size = new System.Drawing.Size(37, 31);
            this.btn_dlleft.TabIndex = 312;
            this.btn_dlleft.Text = "<--";
            this.btn_dlleft.UseVisualStyleBackColor = true;
            this.btn_dlleft.Click += new System.EventHandler(this.btn_dlleft_Click);
            // 
            // dt_customerleaving
            // 
            this.dt_customerleaving.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_customerleaving.Location = new System.Drawing.Point(442, 62);
            this.dt_customerleaving.Name = "dt_customerleaving";
            this.dt_customerleaving.Size = new System.Drawing.Size(468, 38);
            this.dt_customerleaving.TabIndex = 311;
            this.dt_customerleaving.ValueChanged += new System.EventHandler(this.dt_customerleaving_ValueChanged);
            // 
            // cmd_accountlist
            // 
            this.cmd_accountlist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.cmd_accountlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_accountlist.FormattingEnabled = true;
            this.cmd_accountlist.Location = new System.Drawing.Point(74, 337);
            this.cmd_accountlist.Name = "cmd_accountlist";
            this.cmd_accountlist.Size = new System.Drawing.Size(481, 28);
            this.cmd_accountlist.TabIndex = 315;
            this.cmd_accountlist.SelectedIndexChanged += new System.EventHandler(this.cmd_accountlist_SelectedIndexChanged);
            // 
            // btn_update
            // 
            this.btn_update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update.ForeColor = System.Drawing.Color.White;
            this.btn_update.Location = new System.Drawing.Point(195, 550);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(139, 63);
            this.btn_update.TabIndex = 316;
            this.btn_update.Text = "UPDATE CHANGES";
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Visible = false;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // Bookings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(973, 625);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.cmd_accountlist);
            this.Controls.Add(this.btn_dlright);
            this.Controls.Add(this.btn_dlleft);
            this.Controls.Add(this.dt_customerleaving);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_notes);
            this.Controls.Add(this.cmb_flightleaving);
            this.Controls.Add(this.dt_dateright);
            this.Controls.Add(this.dt_dateleft);
            this.Controls.Add(this.cmb_makemodel);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.txt_lastname);
            this.Controls.Add(this.lbl_particulars);
            this.Controls.Add(this.txt_particulars);
            this.Controls.Add(this.txt_flighttimes);
            this.Controls.Add(this.lbl_accountname);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.txt_ph);
            this.Controls.Add(this.lbl_flighttime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dt_returndate);
            this.Controls.Add(this.lbl_returndate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmb_rego);
            this.Controls.Add(this.txt_firstname);
            this.Name = "Bookings";
            this.Text = "Bookings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button dt_dateright;
        private System.Windows.Forms.Button dt_dateleft;
        private System.Windows.Forms.ComboBox cmb_makemodel;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox txt_lastname;
        private System.Windows.Forms.Label lbl_particulars;
        private System.Windows.Forms.TextBox txt_particulars;
        private System.Windows.Forms.ComboBox txt_flighttimes;
        private System.Windows.Forms.Label lbl_accountname;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox txt_ph;
        private System.Windows.Forms.Label lbl_flighttime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dt_returndate;
        private System.Windows.Forms.Label lbl_returndate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_rego;
        private System.Windows.Forms.TextBox txt_firstname;
        private System.Windows.Forms.ComboBox cmb_flightleaving;
        private System.Windows.Forms.TextBox txt_notes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_dlright;
        private System.Windows.Forms.Button btn_dlleft;
        private System.Windows.Forms.DateTimePicker dt_customerleaving;
        private System.Windows.Forms.ComboBox cmd_accountlist;
        private System.Windows.Forms.Button btn_update;
    }
}