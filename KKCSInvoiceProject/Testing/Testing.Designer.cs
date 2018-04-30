namespace KKCSInvoiceProject
{
    partial class Testing
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
            this.lbl_testing = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txt_test = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_testing
            // 
            this.lbl_testing.AutoSize = true;
            this.lbl_testing.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_testing.Location = new System.Drawing.Point(23, 20);
            this.lbl_testing.Name = "lbl_testing";
            this.lbl_testing.Size = new System.Drawing.Size(203, 25);
            this.lbl_testing.TabIndex = 0;
            this.lbl_testing.Text = "Testing Placeholder";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(232, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(313, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Print Cash";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txt_test
            // 
            this.txt_test.Location = new System.Drawing.Point(448, 27);
            this.txt_test.Multiline = true;
            this.txt_test.Name = "txt_test";
            this.txt_test.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_test.Size = new System.Drawing.Size(501, 340);
            this.txt_test.TabIndex = 3;
            // 
            // Testing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(991, 440);
            this.Controls.Add(this.txt_test);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_testing);
            this.Name = "Testing";
            this.Text = "Testing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_testing;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txt_test;
    }
}