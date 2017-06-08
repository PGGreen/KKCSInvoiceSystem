namespace KKCSInvoiceProject
{
    partial class StatsManager
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btn_test = new System.Windows.Forms.Button();
            this.btn_savechart = new System.Windows.Forms.Button();
            this.cmb_month = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_day = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_year = new System.Windows.Forms.TextBox();
            this.filter_creditcard = new System.Windows.Forms.CheckBox();
            this.filter_nocharge = new System.Windows.Forms.CheckBox();
            this.filter_onaccount = new System.Windows.Forms.CheckBox();
            this.filter_stilltopay = new System.Windows.Forms.CheckBox();
            this.filter_internet = new System.Windows.Forms.CheckBox();
            this.filter_cheque = new System.Windows.Forms.CheckBox();
            this.filter_eftpos = new System.Windows.Forms.CheckBox();
            this.filter_cash = new System.Windows.Forms.CheckBox();
            this.lbl_filters = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chk_monthly = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.filter_total = new System.Windows.Forms.CheckBox();
            this.lbl_cash = new System.Windows.Forms.Label();
            this.lbl_eftpos = new System.Windows.Forms.Label();
            this.lbl_total = new System.Windows.Forms.Label();
            this.filter_crediteftpos = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 175);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(1414, 471);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // btn_test
            // 
            this.btn_test.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_test.Location = new System.Drawing.Point(908, 28);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(118, 48);
            this.btn_test.TabIndex = 1;
            this.btn_test.Text = "Load Chart";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // btn_savechart
            // 
            this.btn_savechart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_savechart.Location = new System.Drawing.Point(908, 92);
            this.btn_savechart.Name = "btn_savechart";
            this.btn_savechart.Size = new System.Drawing.Size(118, 48);
            this.btn_savechart.TabIndex = 3;
            this.btn_savechart.Text = "Save Chart";
            this.btn_savechart.UseVisualStyleBackColor = true;
            this.btn_savechart.Click += new System.EventHandler(this.btn_savechart_Click);
            // 
            // cmb_month
            // 
            this.cmb_month.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_month.FormattingEnabled = true;
            this.cmb_month.Items.AddRange(new object[] {
            "JANUARY",
            "FEBRUARY",
            "MARCH",
            "APRIL",
            "MAY",
            "JUNE",
            "JULY",
            "AUGUST",
            "SEPTEMBER",
            "OCTOBER",
            "NOVEMBER",
            "DECEMBER"});
            this.cmb_month.Location = new System.Drawing.Point(82, 78);
            this.cmb_month.Name = "cmb_month";
            this.cmb_month.Size = new System.Drawing.Size(147, 28);
            this.cmb_month.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Month:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Day:";
            // 
            // lbl_day
            // 
            this.lbl_day.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_day.Location = new System.Drawing.Point(82, 34);
            this.lbl_day.Name = "lbl_day";
            this.lbl_day.Size = new System.Drawing.Size(147, 26);
            this.lbl_day.TabIndex = 7;
            this.lbl_day.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Year:";
            // 
            // lbl_year
            // 
            this.lbl_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_year.Location = new System.Drawing.Point(82, 124);
            this.lbl_year.Name = "lbl_year";
            this.lbl_year.Size = new System.Drawing.Size(147, 26);
            this.lbl_year.TabIndex = 9;
            this.lbl_year.Text = "2016";
            // 
            // filter_creditcard
            // 
            this.filter_creditcard.AutoSize = true;
            this.filter_creditcard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filter_creditcard.Location = new System.Drawing.Point(606, 39);
            this.filter_creditcard.Name = "filter_creditcard";
            this.filter_creditcard.Size = new System.Drawing.Size(94, 20);
            this.filter_creditcard.TabIndex = 108;
            this.filter_creditcard.Text = "Credit Card";
            this.filter_creditcard.UseVisualStyleBackColor = true;
            // 
            // filter_nocharge
            // 
            this.filter_nocharge.AutoSize = true;
            this.filter_nocharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filter_nocharge.Location = new System.Drawing.Point(527, 108);
            this.filter_nocharge.Name = "filter_nocharge";
            this.filter_nocharge.Size = new System.Drawing.Size(50, 20);
            this.filter_nocharge.TabIndex = 106;
            this.filter_nocharge.Text = "N/C";
            this.filter_nocharge.UseVisualStyleBackColor = true;
            // 
            // filter_onaccount
            // 
            this.filter_onaccount.AutoSize = true;
            this.filter_onaccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filter_onaccount.Location = new System.Drawing.Point(445, 108);
            this.filter_onaccount.Name = "filter_onaccount";
            this.filter_onaccount.Size = new System.Drawing.Size(70, 20);
            this.filter_onaccount.TabIndex = 105;
            this.filter_onaccount.Text = "On Acc";
            this.filter_onaccount.UseVisualStyleBackColor = true;
            // 
            // filter_stilltopay
            // 
            this.filter_stilltopay.AutoSize = true;
            this.filter_stilltopay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filter_stilltopay.Location = new System.Drawing.Point(606, 73);
            this.filter_stilltopay.Name = "filter_stilltopay";
            this.filter_stilltopay.Size = new System.Drawing.Size(71, 20);
            this.filter_stilltopay.TabIndex = 104;
            this.filter_stilltopay.Text = "To Pay";
            this.filter_stilltopay.UseVisualStyleBackColor = true;
            // 
            // filter_internet
            // 
            this.filter_internet.AutoSize = true;
            this.filter_internet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filter_internet.Location = new System.Drawing.Point(445, 73);
            this.filter_internet.Name = "filter_internet";
            this.filter_internet.Size = new System.Drawing.Size(70, 20);
            this.filter_internet.TabIndex = 103;
            this.filter_internet.Text = "Internet";
            this.filter_internet.UseVisualStyleBackColor = true;
            // 
            // filter_cheque
            // 
            this.filter_cheque.AutoSize = true;
            this.filter_cheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filter_cheque.Location = new System.Drawing.Point(527, 73);
            this.filter_cheque.Name = "filter_cheque";
            this.filter_cheque.Size = new System.Drawing.Size(74, 20);
            this.filter_cheque.TabIndex = 102;
            this.filter_cheque.Text = "Cheque";
            this.filter_cheque.UseVisualStyleBackColor = true;
            // 
            // filter_eftpos
            // 
            this.filter_eftpos.AutoSize = true;
            this.filter_eftpos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filter_eftpos.Location = new System.Drawing.Point(527, 39);
            this.filter_eftpos.Name = "filter_eftpos";
            this.filter_eftpos.Size = new System.Drawing.Size(65, 20);
            this.filter_eftpos.TabIndex = 101;
            this.filter_eftpos.Text = "Eftpos";
            this.filter_eftpos.UseVisualStyleBackColor = true;
            // 
            // filter_cash
            // 
            this.filter_cash.AutoSize = true;
            this.filter_cash.Checked = true;
            this.filter_cash.CheckState = System.Windows.Forms.CheckState.Checked;
            this.filter_cash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filter_cash.Location = new System.Drawing.Point(445, 40);
            this.filter_cash.Name = "filter_cash";
            this.filter_cash.Size = new System.Drawing.Size(58, 20);
            this.filter_cash.TabIndex = 100;
            this.filter_cash.Text = "Cash";
            this.filter_cash.UseVisualStyleBackColor = true;
            // 
            // lbl_filters
            // 
            this.lbl_filters.AutoSize = true;
            this.lbl_filters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_filters.Location = new System.Drawing.Point(528, 9);
            this.lbl_filters.Name = "lbl_filters";
            this.lbl_filters.Size = new System.Drawing.Size(59, 20);
            this.lbl_filters.TabIndex = 99;
            this.lbl_filters.Text = "Filters";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(265, 37);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(125, 20);
            this.checkBox1.TabIndex = 110;
            this.checkBox1.Text = "Day/Month/Year";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // chk_monthly
            // 
            this.chk_monthly.AutoSize = true;
            this.chk_monthly.Checked = true;
            this.chk_monthly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_monthly.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_monthly.Location = new System.Drawing.Point(265, 81);
            this.chk_monthly.Name = "chk_monthly";
            this.chk_monthly.Size = new System.Drawing.Size(96, 20);
            this.chk_monthly.TabIndex = 111;
            this.chk_monthly.Text = "Month/Year";
            this.chk_monthly.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox3.Location = new System.Drawing.Point(265, 127);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(66, 20);
            this.checkBox3.TabIndex = 112;
            this.checkBox3.Text = "Yearly";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // filter_total
            // 
            this.filter_total.AutoSize = true;
            this.filter_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filter_total.Location = new System.Drawing.Point(606, 108);
            this.filter_total.Name = "filter_total";
            this.filter_total.Size = new System.Drawing.Size(58, 20);
            this.filter_total.TabIndex = 113;
            this.filter_total.Text = "Total";
            this.filter_total.UseVisualStyleBackColor = true;
            // 
            // lbl_cash
            // 
            this.lbl_cash.AutoSize = true;
            this.lbl_cash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cash.Location = new System.Drawing.Point(12, 669);
            this.lbl_cash.Name = "lbl_cash";
            this.lbl_cash.Size = new System.Drawing.Size(100, 20);
            this.lbl_cash.TabIndex = 114;
            this.lbl_cash.Text = "Cash Total:";
            // 
            // lbl_eftpos
            // 
            this.lbl_eftpos.AutoSize = true;
            this.lbl_eftpos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_eftpos.Location = new System.Drawing.Point(12, 705);
            this.lbl_eftpos.Name = "lbl_eftpos";
            this.lbl_eftpos.Size = new System.Drawing.Size(112, 20);
            this.lbl_eftpos.TabIndex = 115;
            this.lbl_eftpos.Text = "Eftpos Total:";
            // 
            // lbl_total
            // 
            this.lbl_total.AutoSize = true;
            this.lbl_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total.Location = new System.Drawing.Point(12, 738);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(54, 20);
            this.lbl_total.TabIndex = 116;
            this.lbl_total.Text = "Total:";
            // 
            // filter_crediteftpos
            // 
            this.filter_crediteftpos.AutoSize = true;
            this.filter_crediteftpos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filter_crediteftpos.Location = new System.Drawing.Point(706, 39);
            this.filter_crediteftpos.Name = "filter_crediteftpos";
            this.filter_crediteftpos.Size = new System.Drawing.Size(145, 20);
            this.filter_crediteftpos.TabIndex = 117;
            this.filter_crediteftpos.Text = "Credit Card + Eftpos";
            this.filter_crediteftpos.UseVisualStyleBackColor = true;
            // 
            // StatsManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1465, 816);
            this.Controls.Add(this.filter_crediteftpos);
            this.Controls.Add(this.lbl_total);
            this.Controls.Add(this.lbl_eftpos);
            this.Controls.Add(this.lbl_cash);
            this.Controls.Add(this.filter_total);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.chk_monthly);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.filter_creditcard);
            this.Controls.Add(this.filter_nocharge);
            this.Controls.Add(this.filter_onaccount);
            this.Controls.Add(this.filter_stilltopay);
            this.Controls.Add(this.filter_internet);
            this.Controls.Add(this.filter_cheque);
            this.Controls.Add(this.filter_eftpos);
            this.Controls.Add(this.filter_cash);
            this.Controls.Add(this.lbl_filters);
            this.Controls.Add(this.lbl_year);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_day);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_month);
            this.Controls.Add(this.btn_savechart);
            this.Controls.Add(this.btn_test);
            this.Controls.Add(this.chart1);
            this.Name = "StatsManager";
            this.Text = "StatsManager";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.Button btn_savechart;
        private System.Windows.Forms.ComboBox cmb_month;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lbl_day;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lbl_year;
        private System.Windows.Forms.CheckBox filter_creditcard;
        private System.Windows.Forms.CheckBox filter_nocharge;
        private System.Windows.Forms.CheckBox filter_onaccount;
        private System.Windows.Forms.CheckBox filter_stilltopay;
        private System.Windows.Forms.CheckBox filter_internet;
        private System.Windows.Forms.CheckBox filter_cheque;
        private System.Windows.Forms.CheckBox filter_eftpos;
        private System.Windows.Forms.CheckBox filter_cash;
        private System.Windows.Forms.Label lbl_filters;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox chk_monthly;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox filter_total;
        private System.Windows.Forms.Label lbl_cash;
        private System.Windows.Forms.Label lbl_eftpos;
        private System.Windows.Forms.Label lbl_total;
        private System.Windows.Forms.CheckBox filter_crediteftpos;
    }
}