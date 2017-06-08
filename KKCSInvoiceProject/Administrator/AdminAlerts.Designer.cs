namespace KKCSInvoiceProject
{
    partial class AdminAlerts
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
            this.lbl_alerttitle = new System.Windows.Forms.Label();
            this.txt_text = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_preview = new System.Windows.Forms.Button();
            this.lbl_savestatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_alerttitle
            // 
            this.lbl_alerttitle.AutoSize = true;
            this.lbl_alerttitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_alerttitle.Location = new System.Drawing.Point(156, 23);
            this.lbl_alerttitle.Name = "lbl_alerttitle";
            this.lbl_alerttitle.Size = new System.Drawing.Size(154, 25);
            this.lbl_alerttitle.TabIndex = 0;
            this.lbl_alerttitle.Text = "Alert Settings";
            // 
            // txt_text
            // 
            this.txt_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txt_text.Location = new System.Drawing.Point(28, 127);
            this.txt_text.Multiline = true;
            this.txt_text.Name = "txt_text";
            this.txt_text.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_text.Size = new System.Drawing.Size(783, 506);
            this.txt_text.TabIndex = 40;
            this.txt_text.TextChanged += new System.EventHandler(this.txt_text_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "No Key Policy"});
            this.comboBox1.Location = new System.Drawing.Point(28, 69);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(265, 33);
            this.comboBox1.TabIndex = 41;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Location = new System.Drawing.Point(28, 660);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(135, 51);
            this.btn_save.TabIndex = 42;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_preview
            // 
            this.btn_preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_preview.Location = new System.Drawing.Point(676, 660);
            this.btn_preview.Name = "btn_preview";
            this.btn_preview.Size = new System.Drawing.Size(135, 51);
            this.btn_preview.TabIndex = 43;
            this.btn_preview.Text = "Preview";
            this.btn_preview.UseVisualStyleBackColor = true;
            this.btn_preview.Click += new System.EventHandler(this.btn_preview_Click);
            // 
            // lbl_savestatus
            // 
            this.lbl_savestatus.AutoSize = true;
            this.lbl_savestatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_savestatus.ForeColor = System.Drawing.Color.Red;
            this.lbl_savestatus.Location = new System.Drawing.Point(169, 673);
            this.lbl_savestatus.Name = "lbl_savestatus";
            this.lbl_savestatus.Size = new System.Drawing.Size(104, 25);
            this.lbl_savestatus.TabIndex = 44;
            this.lbl_savestatus.Text = "Unsaved";
            // 
            // AdminAlerts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 777);
            this.Controls.Add(this.lbl_savestatus);
            this.Controls.Add(this.btn_preview);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.txt_text);
            this.Controls.Add(this.lbl_alerttitle);
            this.Name = "AdminAlerts";
            this.Text = "AdminAlerts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_alerttitle;
        private System.Windows.Forms.TextBox txt_text;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_preview;
        private System.Windows.Forms.Label lbl_savestatus;
    }
}