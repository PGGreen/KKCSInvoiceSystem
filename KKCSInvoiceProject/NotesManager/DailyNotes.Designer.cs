namespace KKCSInvoiceProject
{
    partial class DailyNotes
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
            this.dt_dateandtime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_title = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_maxchar = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_notes = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dt_dateandtime
            // 
            this.dt_dateandtime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_dateandtime.Location = new System.Drawing.Point(73, 50);
            this.dt_dateandtime.Name = "dt_dateandtime";
            this.dt_dateandtime.Size = new System.Drawing.Size(324, 29);
            this.dt_dateandtime.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(469, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please pick the date for the note to appear:";
            // 
            // txt_title
            // 
            this.txt_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_title.Location = new System.Drawing.Point(17, 159);
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(331, 26);
            this.txt_title.TabIndex = 2;
            this.txt_title.TextChanged += new System.EventHandler(this.txt_title_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(336, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Please give a title for the note:";
            // 
            // lbl_maxchar
            // 
            this.lbl_maxchar.AutoSize = true;
            this.lbl_maxchar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_maxchar.Location = new System.Drawing.Point(354, 160);
            this.lbl_maxchar.Name = "lbl_maxchar";
            this.lbl_maxchar.Size = new System.Drawing.Size(58, 25);
            this.lbl_maxchar.TabIndex = 4;
            this.lbl_maxchar.Text = "0/35";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(403, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "--->";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(18, 52);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(49, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "<---";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Note:";
            // 
            // txt_notes
            // 
            this.txt_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txt_notes.Location = new System.Drawing.Point(18, 269);
            this.txt_notes.Multiline = true;
            this.txt_notes.Name = "txt_notes";
            this.txt_notes.Size = new System.Drawing.Size(463, 288);
            this.txt_notes.TabIndex = 40;
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.OrangeRed;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.Color.Black;
            this.btn_save.Location = new System.Drawing.Point(524, 379);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(209, 80);
            this.btn_save.TabIndex = 41;
            this.btn_save.Text = "UNSAVED";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // DailyNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(763, 575);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.txt_notes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_maxchar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_title);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dt_dateandtime);
            this.Name = "DailyNotes";
            this.Text = "DailyNotes";
            this.ResumeLayout(false);
            this.PerformLayout();
            this.FormClosing += DailyNotes_Closing;
        }

        #endregion

        private System.Windows.Forms.DateTimePicker dt_dateandtime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_title;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_maxchar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_notes;
        private System.Windows.Forms.Button btn_save;
    }
}