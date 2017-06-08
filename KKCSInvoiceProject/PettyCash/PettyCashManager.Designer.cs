namespace KKCSInvoiceProject
{
    partial class PettyCashManager
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
            this.cmb_month = new System.Windows.Forms.ComboBox();
            this.lbl_month = new System.Windows.Forms.Label();
            this.txt_year = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_reload = new System.Windows.Forms.Button();
            this.btn_left = new System.Windows.Forms.Button();
            this.bnt_right = new System.Windows.Forms.Button();
            this.btn_new = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmb_month
            // 
            this.cmb_month.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_month.FormattingEnabled = true;
            this.cmb_month.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmb_month.Location = new System.Drawing.Point(147, 30);
            this.cmb_month.Name = "cmb_month";
            this.cmb_month.Size = new System.Drawing.Size(157, 33);
            this.cmb_month.TabIndex = 0;
            this.cmb_month.SelectedIndexChanged += new System.EventHandler(this.cmb_month_SelectedIndexChanged);
            // 
            // lbl_month
            // 
            this.lbl_month.AutoSize = true;
            this.lbl_month.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_month.Location = new System.Drawing.Point(12, 34);
            this.lbl_month.Name = "lbl_month";
            this.lbl_month.Size = new System.Drawing.Size(84, 25);
            this.lbl_month.TabIndex = 1;
            this.lbl_month.Text = "Month:";
            // 
            // txt_year
            // 
            this.txt_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_year.Location = new System.Drawing.Point(453, 31);
            this.txt_year.Name = "txt_year";
            this.txt_year.Size = new System.Drawing.Size(104, 31);
            this.txt_year.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(380, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Year:";
            // 
            // btn_reload
            // 
            this.btn_reload.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reload.Location = new System.Drawing.Point(593, 30);
            this.btn_reload.Name = "btn_reload";
            this.btn_reload.Size = new System.Drawing.Size(99, 33);
            this.btn_reload.TabIndex = 4;
            this.btn_reload.Text = "Reload";
            this.btn_reload.UseVisualStyleBackColor = true;
            this.btn_reload.Click += new System.EventHandler(this.btn_reload_Click);
            // 
            // btn_left
            // 
            this.btn_left.Location = new System.Drawing.Point(108, 34);
            this.btn_left.Name = "btn_left";
            this.btn_left.Size = new System.Drawing.Size(32, 23);
            this.btn_left.TabIndex = 6;
            this.btn_left.Text = "<---";
            this.btn_left.UseVisualStyleBackColor = true;
            this.btn_left.Click += new System.EventHandler(this.btn_left_Click);
            // 
            // bnt_right
            // 
            this.bnt_right.Location = new System.Drawing.Point(310, 34);
            this.bnt_right.Name = "bnt_right";
            this.bnt_right.Size = new System.Drawing.Size(32, 23);
            this.bnt_right.TabIndex = 7;
            this.bnt_right.Text = "--->";
            this.bnt_right.UseVisualStyleBackColor = true;
            this.bnt_right.Click += new System.EventHandler(this.bnt_right_Click);
            // 
            // btn_new
            // 
            this.btn_new.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_new.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new.Location = new System.Drawing.Point(835, 15);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(118, 56);
            this.btn_new.TabIndex = 8;
            this.btn_new.Text = "New";
            this.btn_new.UseVisualStyleBackColor = false;
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // PettyCashManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 743);
            this.Controls.Add(this.btn_new);
            this.Controls.Add(this.bnt_right);
            this.Controls.Add(this.btn_left);
            this.Controls.Add(this.btn_reload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_year);
            this.Controls.Add(this.lbl_month);
            this.Controls.Add(this.cmb_month);
            this.Name = "PettyCashManager";
            this.Text = "PettyCashManager";
            this.Load += new System.EventHandler(this.PettyCashManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_month;
        private System.Windows.Forms.Label lbl_month;
        private System.Windows.Forms.TextBox txt_year;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_reload;
        private System.Windows.Forms.Button btn_left;
        private System.Windows.Forms.Button bnt_right;
        private System.Windows.Forms.Button btn_new;
    }
}