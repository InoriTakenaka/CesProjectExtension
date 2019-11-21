namespace SystemSettingExtension
{
    partial class WndAddModel
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.m_btnConfirm = new System.Windows.Forms.Button();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(28, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(301, 38);
            this.textBox1.TabIndex = 0;
            // 
            // m_btnConfirm
            // 
            this.m_btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnConfirm.Location = new System.Drawing.Point(28, 96);
            this.m_btnConfirm.Name = "m_btnConfirm";
            this.m_btnConfirm.Size = new System.Drawing.Size(123, 44);
            this.m_btnConfirm.TabIndex = 1;
            this.m_btnConfirm.Text = "确认";
            this.m_btnConfirm.UseVisualStyleBackColor = true;
            this.m_btnConfirm.Click += new System.EventHandler(this.m_btnConfirm_Click);
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnCancel.Location = new System.Drawing.Point(206, 96);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(123, 44);
            this.m_btnCancel.TabIndex = 2;
            this.m_btnCancel.Text = "取消";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // WndAddModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 168);
            this.ControlBox = false;
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.m_btnConfirm);
            this.Controls.Add(this.textBox1);
            this.Name = "WndAddModel";
            this.Text = "输入车型编号";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button m_btnConfirm;
        private System.Windows.Forms.Button m_btnCancel;
    }
}