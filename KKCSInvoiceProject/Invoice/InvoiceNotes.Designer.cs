﻿namespace KKCSInvoiceProject
{
    partial class InvoiceNotes
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
            this.txt_newnote = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_addnote = new System.Windows.Forms.Button();
            this.lbl_invoice = new System.Windows.Forms.Label();
            this.cmb_worker = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbox_currentnotes = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_newnote
            // 
            this.txt_newnote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_newnote.Location = new System.Drawing.Point(33, 107);
            this.txt_newnote.Multiline = true;
            this.txt_newnote.Name = "txt_newnote";
            this.txt_newnote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_newnote.Size = new System.Drawing.Size(328, 295);
            this.txt_newnote.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(133, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "New Note";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(548, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Current Notes";
            // 
            // btn_addnote
            // 
            this.btn_addnote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_addnote.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addnote.Location = new System.Drawing.Point(116, 474);
            this.btn_addnote.Name = "btn_addnote";
            this.btn_addnote.Size = new System.Drawing.Size(137, 39);
            this.btn_addnote.TabIndex = 4;
            this.btn_addnote.Text = "Add Note";
            this.btn_addnote.UseVisualStyleBackColor = false;
            this.btn_addnote.Click += new System.EventHandler(this.btn_addnote_Click);
            // 
            // lbl_invoice
            // 
            this.lbl_invoice.AutoSize = true;
            this.lbl_invoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_invoice.Location = new System.Drawing.Point(191, 9);
            this.lbl_invoice.Name = "lbl_invoice";
            this.lbl_invoice.Size = new System.Drawing.Size(281, 33);
            this.lbl_invoice.TabIndex = 7;
            this.lbl_invoice.Text = "Invoice Information";
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
            this.cmb_worker.Location = new System.Drawing.Point(173, 418);
            this.cmb_worker.Name = "cmb_worker";
            this.cmb_worker.Size = new System.Drawing.Size(188, 33);
            this.cmb_worker.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 418);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "Staff Member:";
            // 
            // txtbox_currentnotes
            // 
            this.txtbox_currentnotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_currentnotes.Location = new System.Drawing.Point(488, 107);
            this.txtbox_currentnotes.Multiline = true;
            this.txtbox_currentnotes.Name = "txtbox_currentnotes";
            this.txtbox_currentnotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbox_currentnotes.Size = new System.Drawing.Size(459, 332);
            this.txtbox_currentnotes.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(488, 456);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 39);
            this.button2.TabIndex = 6;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // InvoiceNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 542);
            this.Controls.Add(this.txtbox_currentnotes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmb_worker);
            this.Controls.Add(this.lbl_invoice);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_addnote);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_newnote);
            this.Name = "InvoiceNotes";
            this.Text = "InvoiceNotes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_newnote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_addnote;
        private System.Windows.Forms.Label lbl_invoice;
        private System.Windows.Forms.ComboBox cmb_worker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbox_currentnotes;
        private System.Windows.Forms.Button button2;
    }
}