namespace SystemSettingExtension
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
            this.m_Title = new System.Windows.Forms.Label();
            this.m_VehModel = new System.Windows.Forms.ListBox();
            this.m_btnAdd = new System.Windows.Forms.Button();
            this.m_Delete = new System.Windows.Forms.Button();
            this.m_SaveASM = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_Pages = new System.Windows.Forms.TabControl();
            this.m_pageAsm = new System.Windows.Forms.TabPage();
            this.m_Edit40NO = new System.Windows.Forms.TextBox();
            this.m_Edit40CO = new System.Windows.Forms.TextBox();
            this.m_Edit40HC = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_Edit25NO = new System.Windows.Forms.TextBox();
            this.m_Edit25CO = new System.Windows.Forms.TextBox();
            this.m_Edit25HC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_pageVmas = new System.Windows.Forms.TabPage();
            this.m_SaveVmas = new System.Windows.Forms.Button();
            this.m_EditHCNOXZ = new System.Windows.Forms.TextBox();
            this.m_EditNOXZ = new System.Windows.Forms.TextBox();
            this.m_EditCOXZ = new System.Windows.Forms.TextBox();
            this.m_EditHCXZ = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.m_pageSDS = new System.Windows.Forms.TabPage();
            this.m_SaveSds = new System.Windows.Forms.Button();
            this.m_EditLSX = new System.Windows.Forms.TextBox();
            this.m_EditLXX = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.m_EditGDSCO = new System.Windows.Forms.TextBox();
            this.m_EditGDSHC = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.m_EditDSCO = new System.Windows.Forms.TextBox();
            this.m_EditDSHC = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.m_pageLugdown = new System.Windows.Forms.TabPage();
            this.m_SaveLD = new System.Windows.Forms.Button();
            this.m_EditHSU = new System.Windows.Forms.TextBox();
            this.m_EditLGM = new System.Windows.Forms.TextBox();
            this.m_EditLDNO = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.m_EditZSXZ = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.m_EditGLXZ = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.m_EditGXSXS = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.m_pageFreeAcc = new System.Windows.Forms.TabPage();
            this.m_SaveFa = new System.Windows.Forms.Button();
            this.m_EditBTGHSU = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.m_EditFaBTG = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.m_Pages.SuspendLayout();
            this.m_pageAsm.SuspendLayout();
            this.m_pageVmas.SuspendLayout();
            this.m_pageSDS.SuspendLayout();
            this.m_pageLugdown.SuspendLayout();
            this.m_pageFreeAcc.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_Title
            // 
            this.m_Title.AutoSize = true;
            this.m_Title.Font = new System.Drawing.Font("Yu Gothic Light", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_Title.Location = new System.Drawing.Point(9, 6);
            this.m_Title.Name = "m_Title";
            this.m_Title.Size = new System.Drawing.Size(559, 48);
            this.m_Title.TabIndex = 0;
            this.m_Title.Text = "企业环保限值自定义介面";
            // 
            // m_VehModel
            // 
            this.m_VehModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_VehModel.FormattingEnabled = true;
            this.m_VehModel.ItemHeight = 25;
            this.m_VehModel.Location = new System.Drawing.Point(3, 3);
            this.m_VehModel.Name = "m_VehModel";
            this.m_VehModel.Size = new System.Drawing.Size(244, 679);
            this.m_VehModel.TabIndex = 1;
            this.m_VehModel.SelectedIndexChanged += new System.EventHandler(this.m_VehModel_SelectedIndexChanged);
            this.m_VehModel.DoubleClick += new System.EventHandler(this.m_VehModel_DoubleClick);
            // 
            // m_btnAdd
            // 
            this.m_btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnAdd.Location = new System.Drawing.Point(0, 707);
            this.m_btnAdd.Name = "m_btnAdd";
            this.m_btnAdd.Size = new System.Drawing.Size(115, 34);
            this.m_btnAdd.TabIndex = 2;
            this.m_btnAdd.Text = "添加";
            this.m_btnAdd.UseVisualStyleBackColor = true;
            this.m_btnAdd.Click += new System.EventHandler(this.m_btnAdd_Click);
            // 
            // m_Delete
            // 
            this.m_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_Delete.Location = new System.Drawing.Point(123, 707);
            this.m_Delete.Name = "m_Delete";
            this.m_Delete.Size = new System.Drawing.Size(124, 34);
            this.m_Delete.TabIndex = 3;
            this.m_Delete.Text = "删除";
            this.m_Delete.UseVisualStyleBackColor = true;
            this.m_Delete.Click += new System.EventHandler(this.m_Delete_Click);
            // 
            // m_SaveASM
            // 
            this.m_SaveASM.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_SaveASM.Location = new System.Drawing.Point(1062, 601);
            this.m_SaveASM.Name = "m_SaveASM";
            this.m_SaveASM.Size = new System.Drawing.Size(115, 34);
            this.m_SaveASM.TabIndex = 3;
            this.m_SaveASM.Text = "保存";
            this.m_SaveASM.UseVisualStyleBackColor = true;
            this.m_SaveASM.Click += new System.EventHandler(this.m_SaveASM_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_Pages);
            this.panel1.Controls.Add(this.m_VehModel);
            this.panel1.Controls.Add(this.m_Delete);
            this.panel1.Controls.Add(this.m_btnAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1465, 744);
            this.panel1.TabIndex = 6;
            // 
            // m_Pages
            // 
            this.m_Pages.Controls.Add(this.m_pageAsm);
            this.m_Pages.Controls.Add(this.m_pageVmas);
            this.m_Pages.Controls.Add(this.m_pageSDS);
            this.m_Pages.Controls.Add(this.m_pageLugdown);
            this.m_Pages.Controls.Add(this.m_pageFreeAcc);
            this.m_Pages.Location = new System.Drawing.Point(255, 3);
            this.m_Pages.Name = "m_Pages";
            this.m_Pages.SelectedIndex = 0;
            this.m_Pages.Size = new System.Drawing.Size(1198, 729);
            this.m_Pages.TabIndex = 6;
            // 
            // m_pageAsm
            // 
            this.m_pageAsm.Controls.Add(this.m_Edit40NO);
            this.m_pageAsm.Controls.Add(this.m_SaveASM);
            this.m_pageAsm.Controls.Add(this.m_Edit40CO);
            this.m_pageAsm.Controls.Add(this.m_Edit40HC);
            this.m_pageAsm.Controls.Add(this.label6);
            this.m_pageAsm.Controls.Add(this.label7);
            this.m_pageAsm.Controls.Add(this.label8);
            this.m_pageAsm.Controls.Add(this.label5);
            this.m_pageAsm.Controls.Add(this.m_Edit25NO);
            this.m_pageAsm.Controls.Add(this.m_Edit25CO);
            this.m_pageAsm.Controls.Add(this.m_Edit25HC);
            this.m_pageAsm.Controls.Add(this.label4);
            this.m_pageAsm.Controls.Add(this.label3);
            this.m_pageAsm.Controls.Add(this.label2);
            this.m_pageAsm.Controls.Add(this.label1);
            this.m_pageAsm.Location = new System.Drawing.Point(4, 22);
            this.m_pageAsm.Name = "m_pageAsm";
            this.m_pageAsm.Padding = new System.Windows.Forms.Padding(3);
            this.m_pageAsm.Size = new System.Drawing.Size(1190, 703);
            this.m_pageAsm.TabIndex = 0;
            this.m_pageAsm.Text = "稳态工况法";
            this.m_pageAsm.UseVisualStyleBackColor = true;
            // 
            // m_Edit40NO
            // 
            this.m_Edit40NO.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_Edit40NO.Location = new System.Drawing.Point(401, 190);
            this.m_Edit40NO.Name = "m_Edit40NO";
            this.m_Edit40NO.Size = new System.Drawing.Size(100, 32);
            this.m_Edit40NO.TabIndex = 17;
            // 
            // m_Edit40CO
            // 
            this.m_Edit40CO.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_Edit40CO.Location = new System.Drawing.Point(401, 129);
            this.m_Edit40CO.Name = "m_Edit40CO";
            this.m_Edit40CO.Size = new System.Drawing.Size(100, 32);
            this.m_Edit40CO.TabIndex = 16;
            // 
            // m_Edit40HC
            // 
            this.m_Edit40HC.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_Edit40HC.Location = new System.Drawing.Point(401, 68);
            this.m_Edit40HC.Name = "m_Edit40HC";
            this.m_Edit40HC.Size = new System.Drawing.Size(100, 32);
            this.m_Edit40HC.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(299, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 26);
            this.label6.TabIndex = 14;
            this.label6.Text = "NO限值";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(299, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 26);
            this.label7.TabIndex = 13;
            this.label7.Text = "CO限值";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(299, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 26);
            this.label8.TabIndex = 12;
            this.label8.Text = "HC限值";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(297, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 31);
            this.label5.TabIndex = 11;
            this.label5.Text = "40工况";
            // 
            // m_Edit25NO
            // 
            this.m_Edit25NO.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_Edit25NO.Location = new System.Drawing.Point(119, 190);
            this.m_Edit25NO.Name = "m_Edit25NO";
            this.m_Edit25NO.Size = new System.Drawing.Size(100, 32);
            this.m_Edit25NO.TabIndex = 10;
            // 
            // m_Edit25CO
            // 
            this.m_Edit25CO.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_Edit25CO.Location = new System.Drawing.Point(119, 129);
            this.m_Edit25CO.Name = "m_Edit25CO";
            this.m_Edit25CO.Size = new System.Drawing.Size(100, 32);
            this.m_Edit25CO.TabIndex = 9;
            // 
            // m_Edit25HC
            // 
            this.m_Edit25HC.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_Edit25HC.Location = new System.Drawing.Point(119, 68);
            this.m_Edit25HC.Name = "m_Edit25HC";
            this.m_Edit25HC.Size = new System.Drawing.Size(100, 32);
            this.m_Edit25HC.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(17, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "NO限值";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(17, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "CO限值";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(17, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "HC限值";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(16, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "25工况";
            // 
            // m_pageVmas
            // 
            this.m_pageVmas.Controls.Add(this.m_SaveVmas);
            this.m_pageVmas.Controls.Add(this.m_EditHCNOXZ);
            this.m_pageVmas.Controls.Add(this.m_EditNOXZ);
            this.m_pageVmas.Controls.Add(this.m_EditCOXZ);
            this.m_pageVmas.Controls.Add(this.m_EditHCXZ);
            this.m_pageVmas.Controls.Add(this.label12);
            this.m_pageVmas.Controls.Add(this.label11);
            this.m_pageVmas.Controls.Add(this.label10);
            this.m_pageVmas.Controls.Add(this.label9);
            this.m_pageVmas.Location = new System.Drawing.Point(4, 22);
            this.m_pageVmas.Name = "m_pageVmas";
            this.m_pageVmas.Padding = new System.Windows.Forms.Padding(3);
            this.m_pageVmas.Size = new System.Drawing.Size(1190, 703);
            this.m_pageVmas.TabIndex = 1;
            this.m_pageVmas.Text = "瞬态工况法";
            this.m_pageVmas.UseVisualStyleBackColor = true;
            // 
            // m_SaveVmas
            // 
            this.m_SaveVmas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_SaveVmas.Location = new System.Drawing.Point(1062, 601);
            this.m_SaveVmas.Name = "m_SaveVmas";
            this.m_SaveVmas.Size = new System.Drawing.Size(115, 34);
            this.m_SaveVmas.TabIndex = 8;
            this.m_SaveVmas.Text = "保存";
            this.m_SaveVmas.UseVisualStyleBackColor = true;
            this.m_SaveVmas.Click += new System.EventHandler(this.m_SaveVmas_Click);
            // 
            // m_EditHCNOXZ
            // 
            this.m_EditHCNOXZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_EditHCNOXZ.Location = new System.Drawing.Point(291, 242);
            this.m_EditHCNOXZ.Name = "m_EditHCNOXZ";
            this.m_EditHCNOXZ.Size = new System.Drawing.Size(223, 38);
            this.m_EditHCNOXZ.TabIndex = 7;
            // 
            // m_EditNOXZ
            // 
            this.m_EditNOXZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_EditNOXZ.Location = new System.Drawing.Point(291, 175);
            this.m_EditNOXZ.Name = "m_EditNOXZ";
            this.m_EditNOXZ.Size = new System.Drawing.Size(223, 38);
            this.m_EditNOXZ.TabIndex = 6;
            // 
            // m_EditCOXZ
            // 
            this.m_EditCOXZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_EditCOXZ.Location = new System.Drawing.Point(291, 108);
            this.m_EditCOXZ.Name = "m_EditCOXZ";
            this.m_EditCOXZ.Size = new System.Drawing.Size(223, 38);
            this.m_EditCOXZ.TabIndex = 5;
            // 
            // m_EditHCXZ
            // 
            this.m_EditHCXZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_EditHCXZ.Location = new System.Drawing.Point(291, 41);
            this.m_EditHCXZ.Name = "m_EditHCXZ";
            this.m_EditHCXZ.Size = new System.Drawing.Size(223, 38);
            this.m_EditHCXZ.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(62, 249);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(164, 31);
            this.label12.TabIndex = 3;
            this.label12.Text = "HC/NO限值";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(62, 182);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 31);
            this.label11.TabIndex = 2;
            this.label11.Text = "NO限值";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(62, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 31);
            this.label10.TabIndex = 1;
            this.label10.Text = "CO限值";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(62, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 31);
            this.label9.TabIndex = 0;
            this.label9.Text = "HC限值";
            // 
            // m_pageSDS
            // 
            this.m_pageSDS.Controls.Add(this.m_SaveSds);
            this.m_pageSDS.Controls.Add(this.m_EditLSX);
            this.m_pageSDS.Controls.Add(this.m_EditLXX);
            this.m_pageSDS.Controls.Add(this.label17);
            this.m_pageSDS.Controls.Add(this.label18);
            this.m_pageSDS.Controls.Add(this.m_EditGDSCO);
            this.m_pageSDS.Controls.Add(this.m_EditGDSHC);
            this.m_pageSDS.Controls.Add(this.label15);
            this.m_pageSDS.Controls.Add(this.label16);
            this.m_pageSDS.Controls.Add(this.m_EditDSCO);
            this.m_pageSDS.Controls.Add(this.m_EditDSHC);
            this.m_pageSDS.Controls.Add(this.label14);
            this.m_pageSDS.Controls.Add(this.label13);
            this.m_pageSDS.Location = new System.Drawing.Point(4, 22);
            this.m_pageSDS.Name = "m_pageSDS";
            this.m_pageSDS.Padding = new System.Windows.Forms.Padding(3);
            this.m_pageSDS.Size = new System.Drawing.Size(1190, 703);
            this.m_pageSDS.TabIndex = 2;
            this.m_pageSDS.Text = "双怠速";
            this.m_pageSDS.UseVisualStyleBackColor = true;
            // 
            // m_SaveSds
            // 
            this.m_SaveSds.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_SaveSds.Location = new System.Drawing.Point(1062, 601);
            this.m_SaveSds.Name = "m_SaveSds";
            this.m_SaveSds.Size = new System.Drawing.Size(115, 34);
            this.m_SaveSds.TabIndex = 12;
            this.m_SaveSds.Text = "保存";
            this.m_SaveSds.UseVisualStyleBackColor = true;
            this.m_SaveSds.Click += new System.EventHandler(this.m_SaveSds_Click);
            // 
            // m_EditLSX
            // 
            this.m_EditLSX.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_EditLSX.Location = new System.Drawing.Point(510, 192);
            this.m_EditLSX.Name = "m_EditLSX";
            this.m_EditLSX.Size = new System.Drawing.Size(110, 38);
            this.m_EditLSX.TabIndex = 11;
            // 
            // m_EditLXX
            // 
            this.m_EditLXX.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_EditLXX.Location = new System.Drawing.Point(185, 192);
            this.m_EditLXX.Name = "m_EditLXX";
            this.m_EditLXX.Size = new System.Drawing.Size(109, 38);
            this.m_EditLXX.TabIndex = 10;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(356, 199);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(85, 31);
            this.label17.TabIndex = 9;
            this.label17.Text = "λ上限";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(31, 199);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(85, 31);
            this.label18.TabIndex = 8;
            this.label18.Text = "λ下限";
            // 
            // m_EditGDSCO
            // 
            this.m_EditGDSCO.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_EditGDSCO.Location = new System.Drawing.Point(510, 116);
            this.m_EditGDSCO.Name = "m_EditGDSCO";
            this.m_EditGDSCO.Size = new System.Drawing.Size(110, 38);
            this.m_EditGDSCO.TabIndex = 7;
            // 
            // m_EditGDSHC
            // 
            this.m_EditGDSHC.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_EditGDSHC.Location = new System.Drawing.Point(185, 116);
            this.m_EditGDSHC.Name = "m_EditGDSHC";
            this.m_EditGDSHC.Size = new System.Drawing.Size(109, 38);
            this.m_EditGDSHC.TabIndex = 6;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(356, 123);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(141, 31);
            this.label15.TabIndex = 5;
            this.label15.Text = "高怠速CO";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(31, 123);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(140, 31);
            this.label16.TabIndex = 4;
            this.label16.Text = "高怠速HC";
            // 
            // m_EditDSCO
            // 
            this.m_EditDSCO.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_EditDSCO.Location = new System.Drawing.Point(510, 38);
            this.m_EditDSCO.Name = "m_EditDSCO";
            this.m_EditDSCO.Size = new System.Drawing.Size(110, 38);
            this.m_EditDSCO.TabIndex = 3;
            // 
            // m_EditDSHC
            // 
            this.m_EditDSHC.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_EditDSHC.Location = new System.Drawing.Point(185, 38);
            this.m_EditDSHC.Name = "m_EditDSHC";
            this.m_EditDSHC.Size = new System.Drawing.Size(109, 38);
            this.m_EditDSHC.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(356, 45);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(113, 31);
            this.label14.TabIndex = 1;
            this.label14.Text = "怠速CO";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(31, 45);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 31);
            this.label13.TabIndex = 0;
            this.label13.Text = "怠速HC";
            // 
            // m_pageLugdown
            // 
            this.m_pageLugdown.Controls.Add(this.m_SaveLD);
            this.m_pageLugdown.Controls.Add(this.m_EditHSU);
            this.m_pageLugdown.Controls.Add(this.m_EditLGM);
            this.m_pageLugdown.Controls.Add(this.m_EditLDNO);
            this.m_pageLugdown.Controls.Add(this.label24);
            this.m_pageLugdown.Controls.Add(this.label23);
            this.m_pageLugdown.Controls.Add(this.label22);
            this.m_pageLugdown.Controls.Add(this.m_EditZSXZ);
            this.m_pageLugdown.Controls.Add(this.label21);
            this.m_pageLugdown.Controls.Add(this.m_EditGLXZ);
            this.m_pageLugdown.Controls.Add(this.label20);
            this.m_pageLugdown.Controls.Add(this.m_EditGXSXS);
            this.m_pageLugdown.Controls.Add(this.label19);
            this.m_pageLugdown.Location = new System.Drawing.Point(4, 22);
            this.m_pageLugdown.Name = "m_pageLugdown";
            this.m_pageLugdown.Padding = new System.Windows.Forms.Padding(3);
            this.m_pageLugdown.Size = new System.Drawing.Size(1190, 703);
            this.m_pageLugdown.TabIndex = 3;
            this.m_pageLugdown.Text = "加载减速法";
            this.m_pageLugdown.UseVisualStyleBackColor = true;
            // 
            // m_SaveLD
            // 
            this.m_SaveLD.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_SaveLD.Location = new System.Drawing.Point(1062, 601);
            this.m_SaveLD.Name = "m_SaveLD";
            this.m_SaveLD.Size = new System.Drawing.Size(115, 34);
            this.m_SaveLD.TabIndex = 13;
            this.m_SaveLD.Text = "保存";
            this.m_SaveLD.UseVisualStyleBackColor = true;
            this.m_SaveLD.Click += new System.EventHandler(this.m_SaveLD_Click);
            // 
            // m_EditHSU
            // 
            this.m_EditHSU.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_EditHSU.Location = new System.Drawing.Point(152, 203);
            this.m_EditHSU.Name = "m_EditHSU";
            this.m_EditHSU.Size = new System.Drawing.Size(117, 38);
            this.m_EditHSU.TabIndex = 11;
            // 
            // m_EditLGM
            // 
            this.m_EditLGM.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_EditLGM.Location = new System.Drawing.Point(466, 130);
            this.m_EditLGM.Name = "m_EditLGM";
            this.m_EditLGM.Size = new System.Drawing.Size(117, 38);
            this.m_EditLGM.TabIndex = 10;
            // 
            // m_EditLDNO
            // 
            this.m_EditLDNO.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_EditLDNO.Location = new System.Drawing.Point(152, 130);
            this.m_EditLDNO.Name = "m_EditLDNO";
            this.m_EditLDNO.Size = new System.Drawing.Size(117, 38);
            this.m_EditLDNO.TabIndex = 9;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(6, 210);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(131, 31);
            this.label24.TabIndex = 8;
            this.label24.Text = "HSU限值";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(312, 137);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(131, 31);
            this.label23.TabIndex = 7;
            this.label23.Text = "LGM限值";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(6, 137);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(113, 31);
            this.label22.TabIndex = 6;
            this.label22.Text = "NO限值";
            // 
            // m_EditZSXZ
            // 
            this.m_EditZSXZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_EditZSXZ.Location = new System.Drawing.Point(466, 69);
            this.m_EditZSXZ.Name = "m_EditZSXZ";
            this.m_EditZSXZ.Size = new System.Drawing.Size(117, 38);
            this.m_EditZSXZ.TabIndex = 5;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(312, 76);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(126, 31);
            this.label21.TabIndex = 4;
            this.label21.Text = "转速限值";
            // 
            // m_EditGLXZ
            // 
            this.m_EditGLXZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_EditGLXZ.Location = new System.Drawing.Point(152, 69);
            this.m_EditGLXZ.Name = "m_EditGLXZ";
            this.m_EditGLXZ.Size = new System.Drawing.Size(117, 38);
            this.m_EditGLXZ.TabIndex = 3;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(6, 76);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(126, 31);
            this.label20.TabIndex = 2;
            this.label20.Text = "功率限值";
            // 
            // m_EditGXSXS
            // 
            this.m_EditGXSXS.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_EditGXSXS.Location = new System.Drawing.Point(268, 12);
            this.m_EditGXSXS.Name = "m_EditGXSXS";
            this.m_EditGXSXS.Size = new System.Drawing.Size(117, 38);
            this.m_EditGXSXS.TabIndex = 1;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(6, 19);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(210, 31);
            this.label19.TabIndex = 0;
            this.label19.Text = "光吸收系数限值";
            // 
            // m_pageFreeAcc
            // 
            this.m_pageFreeAcc.Controls.Add(this.m_SaveFa);
            this.m_pageFreeAcc.Controls.Add(this.m_EditBTGHSU);
            this.m_pageFreeAcc.Controls.Add(this.label26);
            this.m_pageFreeAcc.Controls.Add(this.m_EditFaBTG);
            this.m_pageFreeAcc.Controls.Add(this.label25);
            this.m_pageFreeAcc.Location = new System.Drawing.Point(4, 22);
            this.m_pageFreeAcc.Name = "m_pageFreeAcc";
            this.m_pageFreeAcc.Padding = new System.Windows.Forms.Padding(3);
            this.m_pageFreeAcc.Size = new System.Drawing.Size(1190, 703);
            this.m_pageFreeAcc.TabIndex = 4;
            this.m_pageFreeAcc.Text = "自由加速法";
            this.m_pageFreeAcc.UseVisualStyleBackColor = true;
            // 
            // m_SaveFa
            // 
            this.m_SaveFa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_SaveFa.Location = new System.Drawing.Point(1065, 601);
            this.m_SaveFa.Name = "m_SaveFa";
            this.m_SaveFa.Size = new System.Drawing.Size(115, 34);
            this.m_SaveFa.TabIndex = 14;
            this.m_SaveFa.Text = "保存";
            this.m_SaveFa.UseVisualStyleBackColor = true;
            this.m_SaveFa.Click += new System.EventHandler(this.m_SaveFa_Click);
            // 
            // m_EditBTGHSU
            // 
            this.m_EditBTGHSU.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_EditBTGHSU.Location = new System.Drawing.Point(330, 118);
            this.m_EditBTGHSU.Name = "m_EditBTGHSU";
            this.m_EditBTGHSU.Size = new System.Drawing.Size(158, 38);
            this.m_EditBTGHSU.TabIndex = 3;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(28, 125);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(131, 31);
            this.label26.TabIndex = 2;
            this.label26.Text = "HSU限值";
            // 
            // m_EditFaBTG
            // 
            this.m_EditFaBTG.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_EditFaBTG.Location = new System.Drawing.Point(330, 21);
            this.m_EditFaBTG.Name = "m_EditFaBTG";
            this.m_EditFaBTG.Size = new System.Drawing.Size(158, 38);
            this.m_EditFaBTG.TabIndex = 1;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(28, 28);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(182, 31);
            this.label25.TabIndex = 0;
            this.label25.Text = "不透光度限值";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_Title);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1465, 61);
            this.panel2.TabIndex = 7;
            // 
            // WndMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1465, 802);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "WndMain";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.m_Pages.ResumeLayout(false);
            this.m_pageAsm.ResumeLayout(false);
            this.m_pageAsm.PerformLayout();
            this.m_pageVmas.ResumeLayout(false);
            this.m_pageVmas.PerformLayout();
            this.m_pageSDS.ResumeLayout(false);
            this.m_pageSDS.PerformLayout();
            this.m_pageLugdown.ResumeLayout(false);
            this.m_pageLugdown.PerformLayout();
            this.m_pageFreeAcc.ResumeLayout(false);
            this.m_pageFreeAcc.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label m_Title;
        private System.Windows.Forms.ListBox m_VehModel;
        private System.Windows.Forms.Button m_btnAdd;
        private System.Windows.Forms.Button m_Delete;
        private System.Windows.Forms.Button m_SaveASM;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl m_Pages;
        private System.Windows.Forms.TabPage m_pageAsm;
        private System.Windows.Forms.TextBox m_Edit40NO;
        private System.Windows.Forms.TextBox m_Edit40CO;
        private System.Windows.Forms.TextBox m_Edit40HC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox m_Edit25NO;
        private System.Windows.Forms.TextBox m_Edit25CO;
        private System.Windows.Forms.TextBox m_Edit25HC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage m_pageVmas;
        private System.Windows.Forms.Button m_SaveVmas;
        private System.Windows.Forms.TextBox m_EditHCNOXZ;
        private System.Windows.Forms.TextBox m_EditNOXZ;
        private System.Windows.Forms.TextBox m_EditCOXZ;
        private System.Windows.Forms.TextBox m_EditHCXZ;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage m_pageSDS;
        private System.Windows.Forms.Button m_SaveSds;
        private System.Windows.Forms.TextBox m_EditLSX;
        private System.Windows.Forms.TextBox m_EditLXX;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox m_EditGDSCO;
        private System.Windows.Forms.TextBox m_EditGDSHC;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox m_EditDSCO;
        private System.Windows.Forms.TextBox m_EditDSHC;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabPage m_pageLugdown;
        private System.Windows.Forms.Button m_SaveLD;
        private System.Windows.Forms.TextBox m_EditHSU;
        private System.Windows.Forms.TextBox m_EditLGM;
        private System.Windows.Forms.TextBox m_EditLDNO;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox m_EditZSXZ;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox m_EditGLXZ;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox m_EditGXSXS;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TabPage m_pageFreeAcc;
        private System.Windows.Forms.Button m_SaveFa;
        private System.Windows.Forms.TextBox m_EditBTGHSU;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox m_EditFaBTG;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Panel panel2;
    }
}

