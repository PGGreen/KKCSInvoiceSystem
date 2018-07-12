namespace KKCSInvoiceProject
{
    partial class Administrator
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
            this.btn_pricing = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_baddebot = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_pricing
            // 
            this.btn_pricing.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pricing.Location = new System.Drawing.Point(19, 68);
            this.btn_pricing.Name = "btn_pricing";
            this.btn_pricing.Size = new System.Drawing.Size(223, 55);
            this.btn_pricing.TabIndex = 2;
            this.btn_pricing.Text = "Pricing";
            this.btn_pricing.UseVisualStyleBackColor = true;
            this.btn_pricing.Click += new System.EventHandler(this.btn_pricing_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 42);
            this.label1.TabIndex = 3;
            this.label1.Text = "Adminstrator";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(19, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(223, 55);
            this.button1.TabIndex = 4;
            this.button1.Text = "Staff Members";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_baddebot
            // 
            this.btn_baddebot.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_baddebot.Location = new System.Drawing.Point(19, 190);
            this.btn_baddebot.Name = "btn_baddebot";
            this.btn_baddebot.Size = new System.Drawing.Size(223, 55);
            this.btn_baddebot.TabIndex = 5;
            this.btn_baddebot.Text = "Bad Debtors";
            this.btn_baddebot.UseVisualStyleBackColor = true;
            this.btn_baddebot.Click += new System.EventHandler(this.btn_baddebot_Click);
            // 
            // Administrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 768);
            this.Controls.Add(this.btn_baddebot);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_pricing);
            this.Name = "Administrator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_pricing;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_baddebot;
    }
}