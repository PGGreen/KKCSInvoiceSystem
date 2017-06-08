namespace KKCSInvoiceProject
{
    partial class NotesManager
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
            this.btn_topline = new System.Windows.Forms.Button();
            this.btn_leftline = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dt_dateandtime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_dailynew = new System.Windows.Forms.Button();
            this.btn_constantnew = new System.Windows.Forms.Button();
            this.btn_dailynotesplaceholder = new System.Windows.Forms.Button();
            this.btn_constantplaceholder = new System.Windows.Forms.Button();
            this.btn_constantdelete = new System.Windows.Forms.Button();
            this.btn_right = new System.Windows.Forms.Button();
            this.btn_left = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_topline
            // 
            this.btn_topline.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_topline.Enabled = false;
            this.btn_topline.Location = new System.Drawing.Point(12, 66);
            this.btn_topline.Name = "btn_topline";
            this.btn_topline.Size = new System.Drawing.Size(671, 11);
            this.btn_topline.TabIndex = 2;
            this.btn_topline.UseVisualStyleBackColor = false;
            // 
            // btn_leftline
            // 
            this.btn_leftline.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_leftline.Enabled = false;
            this.btn_leftline.Location = new System.Drawing.Point(284, 12);
            this.btn_leftline.Name = "btn_leftline";
            this.btn_leftline.Size = new System.Drawing.Size(11, 565);
            this.btn_leftline.TabIndex = 3;
            this.btn_leftline.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Daily Notes";
            // 
            // dt_dateandtime
            // 
            this.dt_dateandtime.Location = new System.Drawing.Point(43, 40);
            this.dt_dateandtime.Name = "dt_dateandtime";
            this.dt_dateandtime.Size = new System.Drawing.Size(200, 20);
            this.dt_dateandtime.TabIndex = 5;
            this.dt_dateandtime.ValueChanged += new System.EventHandler(this.dt_dateandtime_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(393, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "General Notes";
            // 
            // btn_dailynew
            // 
            this.btn_dailynew.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_dailynew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dailynew.Location = new System.Drawing.Point(191, 12);
            this.btn_dailynew.Name = "btn_dailynew";
            this.btn_dailynew.Size = new System.Drawing.Size(63, 23);
            this.btn_dailynew.TabIndex = 8;
            this.btn_dailynew.Text = "NEW";
            this.btn_dailynew.UseVisualStyleBackColor = false;
            this.btn_dailynew.Click += new System.EventHandler(this.btn_dailynew_Click);
            // 
            // btn_constantnew
            // 
            this.btn_constantnew.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_constantnew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_constantnew.Location = new System.Drawing.Point(524, 12);
            this.btn_constantnew.Name = "btn_constantnew";
            this.btn_constantnew.Size = new System.Drawing.Size(63, 23);
            this.btn_constantnew.TabIndex = 10;
            this.btn_constantnew.Text = "NEW";
            this.btn_constantnew.UseVisualStyleBackColor = false;
            // 
            // btn_dailynotesplaceholder
            // 
            this.btn_dailynotesplaceholder.BackColor = System.Drawing.Color.PeachPuff;
            this.btn_dailynotesplaceholder.Enabled = false;
            this.btn_dailynotesplaceholder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dailynotesplaceholder.Location = new System.Drawing.Point(23, 96);
            this.btn_dailynotesplaceholder.Name = "btn_dailynotesplaceholder";
            this.btn_dailynotesplaceholder.Size = new System.Drawing.Size(245, 23);
            this.btn_dailynotesplaceholder.TabIndex = 11;
            this.btn_dailynotesplaceholder.UseVisualStyleBackColor = false;
            this.btn_dailynotesplaceholder.Visible = false;
            // 
            // btn_constantplaceholder
            // 
            this.btn_constantplaceholder.BackColor = System.Drawing.Color.PeachPuff;
            this.btn_constantplaceholder.Location = new System.Drawing.Point(410, 96);
            this.btn_constantplaceholder.Name = "btn_constantplaceholder";
            this.btn_constantplaceholder.Size = new System.Drawing.Size(245, 23);
            this.btn_constantplaceholder.TabIndex = 13;
            this.btn_constantplaceholder.UseVisualStyleBackColor = false;
            // 
            // btn_constantdelete
            // 
            this.btn_constantdelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_constantdelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_constantdelete.Location = new System.Drawing.Point(301, 96);
            this.btn_constantdelete.Name = "btn_constantdelete";
            this.btn_constantdelete.Size = new System.Drawing.Size(103, 23);
            this.btn_constantdelete.TabIndex = 15;
            this.btn_constantdelete.Text = "Accept/Delete";
            this.btn_constantdelete.UseVisualStyleBackColor = false;
            // 
            // btn_right
            // 
            this.btn_right.Location = new System.Drawing.Point(247, 39);
            this.btn_right.Name = "btn_right";
            this.btn_right.Size = new System.Drawing.Size(32, 22);
            this.btn_right.TabIndex = 16;
            this.btn_right.Text = "--->";
            this.btn_right.UseVisualStyleBackColor = true;
            this.btn_right.Click += new System.EventHandler(this.btn_right_Click);
            // 
            // btn_left
            // 
            this.btn_left.Location = new System.Drawing.Point(7, 39);
            this.btn_left.Name = "btn_left";
            this.btn_left.Size = new System.Drawing.Size(32, 22);
            this.btn_left.TabIndex = 17;
            this.btn_left.Text = "<---";
            this.btn_left.UseVisualStyleBackColor = true;
            this.btn_left.Click += new System.EventHandler(this.btn_left_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(704, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 47);
            this.button1.TabIndex = 18;
            this.button1.Text = "Print All Notes";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(672, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(11, 565);
            this.button2.TabIndex = 19;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // NotesManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(806, 589);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_left);
            this.Controls.Add(this.btn_right);
            this.Controls.Add(this.btn_constantdelete);
            this.Controls.Add(this.btn_constantplaceholder);
            this.Controls.Add(this.btn_dailynotesplaceholder);
            this.Controls.Add(this.btn_constantnew);
            this.Controls.Add(this.btn_dailynew);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dt_dateandtime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_leftline);
            this.Controls.Add(this.btn_topline);
            this.Name = "NotesManager";
            this.Text = "NotesManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_topline;
        private System.Windows.Forms.Button btn_leftline;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dt_dateandtime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_dailynew;
        private System.Windows.Forms.Button btn_constantnew;
        private System.Windows.Forms.Button btn_dailynotesplaceholder;
        private System.Windows.Forms.Button btn_constantplaceholder;
        private System.Windows.Forms.Button btn_constantdelete;
        private System.Windows.Forms.Button btn_right;
        private System.Windows.Forms.Button btn_left;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}