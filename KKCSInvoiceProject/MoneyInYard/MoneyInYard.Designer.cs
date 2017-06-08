namespace KKCSInvoiceProject
{
    partial class MoneyInYard
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txt_headertin = new System.Windows.Forms.Label();
            this.txt_tillheader = new System.Windows.Forms.Label();
            this.btn_load = new System.Windows.Forms.Button();
            this.btn_right = new System.Windows.Forms.Button();
            this.btn_left = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(60, 23);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(235, 24);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // txt_headertin
            // 
            this.txt_headertin.AutoSize = true;
            this.txt_headertin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_headertin.Location = new System.Drawing.Point(1118, 24);
            this.txt_headertin.Name = "txt_headertin";
            this.txt_headertin.Size = new System.Drawing.Size(101, 24);
            this.txt_headertin.TabIndex = 1;
            this.txt_headertin.Text = "Plastic Box";
            // 
            // txt_tillheader
            // 
            this.txt_tillheader.AutoSize = true;
            this.txt_tillheader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tillheader.Location = new System.Drawing.Point(674, 24);
            this.txt_tillheader.Name = "txt_tillheader";
            this.txt_tillheader.Size = new System.Drawing.Size(34, 24);
            this.txt_tillheader.TabIndex = 2;
            this.txt_tillheader.Text = "Till";
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(376, 23);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(75, 23);
            this.btn_load.TabIndex = 3;
            this.btn_load.Text = "Reload";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // btn_right
            // 
            this.btn_right.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_right.Location = new System.Drawing.Point(301, 23);
            this.btn_right.Name = "btn_right";
            this.btn_right.Size = new System.Drawing.Size(38, 23);
            this.btn_right.TabIndex = 4;
            this.btn_right.Text = "-->";
            this.btn_right.UseVisualStyleBackColor = true;
            this.btn_right.Click += new System.EventHandler(this.btn_right_Click);
            // 
            // btn_left
            // 
            this.btn_left.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_left.Location = new System.Drawing.Point(20, 24);
            this.btn_left.Name = "btn_left";
            this.btn_left.Size = new System.Drawing.Size(34, 23);
            this.btn_left.TabIndex = 5;
            this.btn_left.Text = "<--";
            this.btn_left.UseVisualStyleBackColor = true;
            this.btn_left.Click += new System.EventHandler(this.btn_left_Click);
            // 
            // MoneyInYard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1374, 635);
            this.Controls.Add(this.btn_left);
            this.Controls.Add(this.btn_right);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.txt_tillheader);
            this.Controls.Add(this.txt_headertin);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "MoneyInYard";
            this.Text = "MoneyInYard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label txt_headertin;
        private System.Windows.Forms.Label txt_tillheader;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.Button btn_right;
        private System.Windows.Forms.Button btn_left;
    }
}