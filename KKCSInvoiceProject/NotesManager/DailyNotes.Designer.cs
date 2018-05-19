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
            this.label3 = new System.Windows.Forms.Label();
            this.txt_notes = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cmb_worker = new System.Windows.Forms.ComboBox();
            this.chk_hp = new System.Windows.Forms.CheckBox();
            this.btn_update = new System.Windows.Forms.Button();
            this.txt_title = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Note:";
            // 
            // txt_notes
            // 
            this.txt_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txt_notes.Location = new System.Drawing.Point(18, 213);
            this.txt_notes.Multiline = true;
            this.txt_notes.Name = "txt_notes";
            this.txt_notes.Size = new System.Drawing.Size(716, 414);
            this.txt_notes.TabIndex = 40;
            this.txt_notes.TextChanged += new System.EventHandler(this.txt_notes_TextChanged);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.OrangeRed;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.Color.Black;
            this.btn_save.Location = new System.Drawing.Point(279, 23);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(205, 61);
            this.btn_save.TabIndex = 41;
            this.btn_save.Text = "UNSAVED";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 24);
            this.label8.TabIndex = 187;
            this.label8.Text = "Staff Member:";
            // 
            // cmb_worker
            // 
            this.cmb_worker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cmb_worker.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_worker.FormattingEnabled = true;
            this.cmb_worker.Items.AddRange(new object[] {
            "Please Pick...",
            "Jude",
            "Graham",
            "Noel",
            "Peter",
            "Deb"});
            this.cmb_worker.Location = new System.Drawing.Point(18, 41);
            this.cmb_worker.Name = "cmb_worker";
            this.cmb_worker.Size = new System.Drawing.Size(238, 47);
            this.cmb_worker.TabIndex = 186;
            // 
            // chk_hp
            // 
            this.chk_hp.AutoSize = true;
            this.chk_hp.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_hp.Location = new System.Drawing.Point(517, 14);
            this.chk_hp.Name = "chk_hp";
            this.chk_hp.Size = new System.Drawing.Size(194, 35);
            this.chk_hp.TabIndex = 188;
            this.chk_hp.Text = "High Priority";
            this.chk_hp.UseVisualStyleBackColor = true;
            this.chk_hp.CheckedChanged += new System.EventHandler(this.chk_hp_CheckedChanged);
            // 
            // btn_update
            // 
            this.btn_update.BackColor = System.Drawing.Color.Fuchsia;
            this.btn_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update.ForeColor = System.Drawing.Color.White;
            this.btn_update.Location = new System.Drawing.Point(279, 87);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(178, 38);
            this.btn_update.TabIndex = 189;
            this.btn_update.Text = "Update Changes";
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Visible = false;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // txt_title
            // 
            this.txt_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_title.Location = new System.Drawing.Point(87, 138);
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(496, 31);
            this.txt_title.TabIndex = 190;
            this.txt_title.TextChanged += new System.EventHandler(this.txt_title_TextChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 25);
            this.label1.TabIndex = 191;
            this.label1.Text = "Title:";
            // 
            // DailyNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(763, 639);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_title);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.chk_hp);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmb_worker);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.txt_notes);
            this.Controls.Add(this.label3);
            this.Name = "DailyNotes";
            this.Text = "DailyNotes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_notes;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmb_worker;
        private System.Windows.Forms.CheckBox chk_hp;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.TextBox txt_title;
        private System.Windows.Forms.Label label1;
    }
}