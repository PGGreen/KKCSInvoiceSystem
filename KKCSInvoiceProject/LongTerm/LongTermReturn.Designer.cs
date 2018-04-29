namespace KKCSInvoiceProject
{
    partial class LongTermReturn
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
            this.lbl_longterm = new System.Windows.Forms.Label();
            this.dt_dateright = new System.Windows.Forms.Button();
            this.dt_dateleft = new System.Windows.Forms.Button();
            this.dt_returndate = new System.Windows.Forms.DateTimePicker();
            this.lbl_returndate = new System.Windows.Forms.Label();
            this.lbl_return = new System.Windows.Forms.Label();
            this.chk_enablereturn = new System.Windows.Forms.CheckBox();
            this.txt_flighttimes = new System.Windows.Forms.ComboBox();
            this.lbl_flighttime = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_longterm
            // 
            this.lbl_longterm.AutoSize = true;
            this.lbl_longterm.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_longterm.Location = new System.Drawing.Point(12, 9);
            this.lbl_longterm.Name = "lbl_longterm";
            this.lbl_longterm.Size = new System.Drawing.Size(182, 37);
            this.lbl_longterm.TabIndex = 0;
            this.lbl_longterm.Text = "Long Term";
            // 
            // dt_dateright
            // 
            this.dt_dateright.Enabled = false;
            this.dt_dateright.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_dateright.Location = new System.Drawing.Point(727, 273);
            this.dt_dateright.Name = "dt_dateright";
            this.dt_dateright.Size = new System.Drawing.Size(37, 31);
            this.dt_dateright.TabIndex = 239;
            this.dt_dateright.Text = "-->";
            this.dt_dateright.UseVisualStyleBackColor = true;
            // 
            // dt_dateleft
            // 
            this.dt_dateleft.Enabled = false;
            this.dt_dateleft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_dateleft.Location = new System.Drawing.Point(212, 273);
            this.dt_dateleft.Name = "dt_dateleft";
            this.dt_dateleft.Size = new System.Drawing.Size(37, 31);
            this.dt_dateleft.TabIndex = 238;
            this.dt_dateleft.Text = "<--";
            this.dt_dateleft.UseVisualStyleBackColor = true;
            // 
            // dt_returndate
            // 
            this.dt_returndate.Enabled = false;
            this.dt_returndate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_returndate.Location = new System.Drawing.Point(253, 270);
            this.dt_returndate.Name = "dt_returndate";
            this.dt_returndate.Size = new System.Drawing.Size(468, 38);
            this.dt_returndate.TabIndex = 237;
            // 
            // lbl_returndate
            // 
            this.lbl_returndate.AutoSize = true;
            this.lbl_returndate.Enabled = false;
            this.lbl_returndate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_returndate.ForeColor = System.Drawing.Color.Green;
            this.lbl_returndate.Location = new System.Drawing.Point(12, 275);
            this.lbl_returndate.Name = "lbl_returndate";
            this.lbl_returndate.Size = new System.Drawing.Size(202, 29);
            this.lbl_returndate.TabIndex = 236;
            this.lbl_returndate.Text = "RETURN DATE:";
            // 
            // lbl_return
            // 
            this.lbl_return.AutoSize = true;
            this.lbl_return.Enabled = false;
            this.lbl_return.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_return.Location = new System.Drawing.Point(12, 226);
            this.lbl_return.Name = "lbl_return";
            this.lbl_return.Size = new System.Drawing.Size(653, 37);
            this.lbl_return.TabIndex = 240;
            this.lbl_return.Text = "If they know their return date enter it here:";
            // 
            // chk_enablereturn
            // 
            this.chk_enablereturn.AutoSize = true;
            this.chk_enablereturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_enablereturn.Location = new System.Drawing.Point(17, 190);
            this.chk_enablereturn.Name = "chk_enablereturn";
            this.chk_enablereturn.Size = new System.Drawing.Size(331, 33);
            this.chk_enablereturn.TabIndex = 242;
            this.chk_enablereturn.Text = "Tick to enable return date";
            this.chk_enablereturn.UseVisualStyleBackColor = true;
            this.chk_enablereturn.CheckedChanged += new System.EventHandler(this.chk_enablereturn_CheckedChanged);
            // 
            // txt_flighttimes
            // 
            this.txt_flighttimes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txt_flighttimes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txt_flighttimes.BackColor = System.Drawing.SystemColors.Window;
            this.txt_flighttimes.Cursor = System.Windows.Forms.Cursors.Default;
            this.txt_flighttimes.DropDownWidth = 121;
            this.txt_flighttimes.Enabled = false;
            this.txt_flighttimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_flighttimes.FormattingEnabled = true;
            this.txt_flighttimes.Location = new System.Drawing.Point(249, 325);
            this.txt_flighttimes.Name = "txt_flighttimes";
            this.txt_flighttimes.Size = new System.Drawing.Size(198, 37);
            this.txt_flighttimes.TabIndex = 244;
            // 
            // lbl_flighttime
            // 
            this.lbl_flighttime.AutoSize = true;
            this.lbl_flighttime.Enabled = false;
            this.lbl_flighttime.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_flighttime.ForeColor = System.Drawing.Color.Green;
            this.lbl_flighttime.Location = new System.Drawing.Point(14, 329);
            this.lbl_flighttime.Name = "lbl_flighttime";
            this.lbl_flighttime.Size = new System.Drawing.Size(225, 29);
            this.lbl_flighttime.TabIndex = 243;
            this.lbl_flighttime.Text = "RETURN FLIGHT:";
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.OrangeRed;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.Color.Black;
            this.btn_save.Location = new System.Drawing.Point(20, 385);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(174, 68);
            this.btn_save.TabIndex = 245;
            this.btn_save.Text = "UNSAVED";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Visible = false;
            // 
            // LongTermReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 465);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.txt_flighttimes);
            this.Controls.Add(this.lbl_flighttime);
            this.Controls.Add(this.chk_enablereturn);
            this.Controls.Add(this.lbl_return);
            this.Controls.Add(this.dt_dateright);
            this.Controls.Add(this.dt_dateleft);
            this.Controls.Add(this.dt_returndate);
            this.Controls.Add(this.lbl_returndate);
            this.Controls.Add(this.lbl_longterm);
            this.Name = "LongTermReturn";
            this.Text = "LongTermReturn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_longterm;
        private System.Windows.Forms.Button dt_dateright;
        private System.Windows.Forms.Button dt_dateleft;
        private System.Windows.Forms.DateTimePicker dt_returndate;
        private System.Windows.Forms.Label lbl_returndate;
        private System.Windows.Forms.Label lbl_return;
        private System.Windows.Forms.CheckBox chk_enablereturn;
        private System.Windows.Forms.ComboBox txt_flighttimes;
        private System.Windows.Forms.Label lbl_flighttime;
        private System.Windows.Forms.Button btn_save;
    }
}