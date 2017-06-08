namespace KKCSInvoiceProject
{
    partial class AdminFlightTimes
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
            this.lbl_savestatus = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.cmb_pickday = new System.Windows.Forms.ComboBox();
            this.txt_text = new System.Windows.Forms.TextBox();
            this.lbl_alerttitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_savestatus
            // 
            this.lbl_savestatus.AutoSize = true;
            this.lbl_savestatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_savestatus.ForeColor = System.Drawing.Color.Red;
            this.lbl_savestatus.Location = new System.Drawing.Point(178, 461);
            this.lbl_savestatus.Name = "lbl_savestatus";
            this.lbl_savestatus.Size = new System.Drawing.Size(104, 25);
            this.lbl_savestatus.TabIndex = 50;
            this.lbl_savestatus.Text = "Unsaved";
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Location = new System.Drawing.Point(37, 448);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(135, 51);
            this.btn_save.TabIndex = 48;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // cmb_pickday
            // 
            this.cmb_pickday.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_pickday.FormattingEnabled = true;
            this.cmb_pickday.Items.AddRange(new object[] {
            "Mon - Fri",
            "Sat",
            "Sun"});
            this.cmb_pickday.Location = new System.Drawing.Point(37, 71);
            this.cmb_pickday.Name = "cmb_pickday";
            this.cmb_pickday.Size = new System.Drawing.Size(265, 33);
            this.cmb_pickday.TabIndex = 47;
            this.cmb_pickday.SelectedIndexChanged += new System.EventHandler(this.cmb_pickday_SelectedIndexChanged);
            // 
            // txt_text
            // 
            this.txt_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txt_text.Location = new System.Drawing.Point(37, 129);
            this.txt_text.Multiline = true;
            this.txt_text.Name = "txt_text";
            this.txt_text.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_text.Size = new System.Drawing.Size(265, 298);
            this.txt_text.TabIndex = 46;
            this.txt_text.TextChanged += new System.EventHandler(this.txt_text_TextChanged);
            // 
            // lbl_alerttitle
            // 
            this.lbl_alerttitle.AutoSize = true;
            this.lbl_alerttitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_alerttitle.Location = new System.Drawing.Point(32, 26);
            this.lbl_alerttitle.Name = "lbl_alerttitle";
            this.lbl_alerttitle.Size = new System.Drawing.Size(234, 25);
            this.lbl_alerttitle.TabIndex = 45;
            this.lbl_alerttitle.Text = "Flight Times Settings";
            // 
            // AdminFlightTimes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 545);
            this.Controls.Add(this.lbl_savestatus);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.cmb_pickday);
            this.Controls.Add(this.txt_text);
            this.Controls.Add(this.lbl_alerttitle);
            this.Name = "AdminFlightTimes";
            this.Text = "AdminFlightTimes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_savestatus;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.ComboBox cmb_pickday;
        private System.Windows.Forms.TextBox txt_text;
        private System.Windows.Forms.Label lbl_alerttitle;
    }
}