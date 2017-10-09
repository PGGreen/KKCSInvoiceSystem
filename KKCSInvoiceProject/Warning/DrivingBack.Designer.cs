namespace KKCSInvoiceProject
{
    partial class DrivingBack
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
            this.lbl_drivingback = new System.Windows.Forms.Label();
            this.btn_printdrivingback = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_worker = new System.Windows.Forms.ComboBox();
            this.txt_newnote = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_drivingback
            // 
            this.lbl_drivingback.AutoSize = true;
            this.lbl_drivingback.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_drivingback.Location = new System.Drawing.Point(12, 18);
            this.lbl_drivingback.Name = "lbl_drivingback";
            this.lbl_drivingback.Size = new System.Drawing.Size(127, 20);
            this.lbl_drivingback.TabIndex = 0;
            this.lbl_drivingback.Text = "lbl_drivingback";
            // 
            // btn_printdrivingback
            // 
            this.btn_printdrivingback.BackColor = System.Drawing.Color.Black;
            this.btn_printdrivingback.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_printdrivingback.ForeColor = System.Drawing.Color.White;
            this.btn_printdrivingback.Location = new System.Drawing.Point(165, 650);
            this.btn_printdrivingback.Name = "btn_printdrivingback";
            this.btn_printdrivingback.Size = new System.Drawing.Size(174, 81);
            this.btn_printdrivingback.TabIndex = 1;
            this.btn_printdrivingback.Text = "Print Copy For Customer";
            this.btn_printdrivingback.UseVisualStyleBackColor = false;
            this.btn_printdrivingback.Click += new System.EventHandler(this.btn_printdrivingback_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(824, 490);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "Staff Member:";
            // 
            // cmb_worker
            // 
            this.cmb_worker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cmb_worker.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_worker.FormattingEnabled = true;
            this.cmb_worker.Items.AddRange(new object[] {
            "Please Pick...",
            "Jude",
            "Graham",
            "Noel",
            "Peter",
            "Deb"});
            this.cmb_worker.Location = new System.Drawing.Point(968, 490);
            this.cmb_worker.Name = "cmb_worker";
            this.cmb_worker.Size = new System.Drawing.Size(188, 33);
            this.cmb_worker.TabIndex = 11;
            // 
            // txt_newnote
            // 
            this.txt_newnote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_newnote.Location = new System.Drawing.Point(828, 189);
            this.txt_newnote.Multiline = true;
            this.txt_newnote.Name = "txt_newnote";
            this.txt_newnote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_newnote.Size = new System.Drawing.Size(328, 295);
            this.txt_newnote.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(824, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Notes";
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.OrangeRed;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.Color.Black;
            this.btn_save.Location = new System.Drawing.Point(911, 563);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(174, 68);
            this.btn_save.TabIndex = 39;
            this.btn_save.Text = "UNSAVED";
            this.btn_save.UseVisualStyleBackColor = false;
            // 
            // DrivingBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1271, 743);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmb_worker);
            this.Controls.Add(this.txt_newnote);
            this.Controls.Add(this.btn_printdrivingback);
            this.Controls.Add(this.lbl_drivingback);
            this.Name = "DrivingBack";
            this.Text = "DrivingBack";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_drivingback;
        private System.Windows.Forms.Button btn_printdrivingback;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_worker;
        private System.Windows.Forms.TextBox txt_newnote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_save;
    }
}