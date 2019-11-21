namespace ReportPrinterForVehAsm
{
    partial class WndMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndMain));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colJCLSH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJYLB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHBLSH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCLXXSJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJYXM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.endTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.startTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVIN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colJCLSH,
            this.colJYLB,
            this.colHBLSH,
            this.colCLXXSJ,
            this.colVIN,
            this.colJYXM,
            this.colResult});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.Location = new System.Drawing.Point(0, 70);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1916, 983);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // colJCLSH
            // 
            this.colJCLSH.DataPropertyName = "JCLSH";
            this.colJCLSH.HeaderText = "检测流水号";
            this.colJCLSH.Name = "colJCLSH";
            this.colJCLSH.ReadOnly = true;
            // 
            // colJYLB
            // 
            this.colJYLB.DataPropertyName = "JYLB";
            this.colJYLB.HeaderText = "检验类别";
            this.colJYLB.Name = "colJYLB";
            this.colJYLB.ReadOnly = true;
            // 
            // colHBLSH
            // 
            this.colHBLSH.DataPropertyName = "HBLSH";
            this.colHBLSH.HeaderText = "环保流水号";
            this.colHBLSH.Name = "colHBLSH";
            this.colHBLSH.ReadOnly = true;
            // 
            // colCLXXSJ
            // 
            this.colCLXXSJ.DataPropertyName = "CLXXSJ";
            this.colCLXXSJ.HeaderText = "车辆下线时间";
            this.colCLXXSJ.Name = "colCLXXSJ";
            this.colCLXXSJ.ReadOnly = true;
            // 
            // colVIN
            // 
            this.colVIN.DataPropertyName = "VIN";
            this.colVIN.HeaderText = "VIN";
            this.colVIN.Name = "colVIN";
            this.colVIN.ReadOnly = true;
            // 
            // colJYXM
            // 
            this.colJYXM.DataPropertyName = "JYXM";
            this.colJYXM.HeaderText = "检验项目";
            this.colJYXM.Name = "colJYXM";
            this.colJYXM.ReadOnly = true;
            // 
            // colResult
            // 
            this.colResult.DataPropertyName = "Z_PD";
            this.colResult.HeaderText = "结论";
            this.colResult.Name = "colResult";
            this.colResult.ReadOnly = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSearch.Location = new System.Drawing.Point(1618, 0);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(92, 56);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "检索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPrev.Location = new System.Drawing.Point(1710, 0);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(5);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(106, 56);
            this.btnPrev.TabIndex = 2;
            this.btnPrev.Text = "上一页";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(1816, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 56);
            this.button1.TabIndex = 3;
            this.button1.Text = "下一页";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.endTime);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.startTime);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtVIN);
            this.panel1.Controls.Add(this.btnPrev);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("SimSun", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(0, 14);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1916, 56);
            this.panel1.TabIndex = 6;
            // 
            // endTime
            // 
            this.endTime.Location = new System.Drawing.Point(755, 0);
            this.endTime.Margin = new System.Windows.Forms.Padding(5);
            this.endTime.Name = "endTime";
            this.endTime.Size = new System.Drawing.Size(220, 28);
            this.endTime.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(732, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 45);
            this.label3.TabIndex = 9;
            this.label3.Text = "-";
            // 
            // startTime
            // 
            this.startTime.CustomFormat = "yyyy-MM-dd";
            this.startTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startTime.Location = new System.Drawing.Point(551, 0);
            this.startTime.Margin = new System.Windows.Forms.Padding(5);
            this.startTime.Name = "startTime";
            this.startTime.Size = new System.Drawing.Size(180, 28);
            this.startTime.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Gainsboro;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(368, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 45);
            this.label2.TabIndex = 7;
            this.label2.Text = "车辆下线时间";
            // 
            // txtVIN
            // 
            this.txtVIN.Location = new System.Drawing.Point(101, 0);
            this.txtVIN.Margin = new System.Windows.Forms.Padding(5);
            this.txtVIN.Name = "txtVIN";
            this.txtVIN.Size = new System.Drawing.Size(264, 28);
            this.txtVIN.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 56);
            this.label1.TabIndex = 5;
            this.label1.Text = "VIN";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1916, 14);
            this.panel2.TabIndex = 7;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(1511, 0);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(104, 56);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // WndMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1916, 1053);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("SimSun", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "WndMain";
            this.Text = "环保报告单打印";
            this.Load += new System.EventHandler(this.WndMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.DataGridViewTextBoxColumn colJCLSH;
		private System.Windows.Forms.DataGridViewTextBoxColumn colJYLB;
		private System.Windows.Forms.DataGridViewTextBoxColumn colHBLSH;
		private System.Windows.Forms.DataGridViewTextBoxColumn colCLXXSJ;
		private System.Windows.Forms.DataGridViewTextBoxColumn colVIN;
		private System.Windows.Forms.DataGridViewTextBoxColumn colJYXM;
		private System.Windows.Forms.DataGridViewTextBoxColumn colResult;
        private System.Windows.Forms.DateTimePicker endTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker startTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVIN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExport;
    }
}