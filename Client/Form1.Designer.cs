namespace Client
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.SendFileButton = new System.Windows.Forms.Button();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.PremiumButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SendFileButton
            // 
            this.SendFileButton.AutoSize = true;
            this.SendFileButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.SendFileButton.Location = new System.Drawing.Point(0, 0);
            this.SendFileButton.Name = "SendFileButton";
            this.SendFileButton.Size = new System.Drawing.Size(267, 450);
            this.SendFileButton.TabIndex = 0;
            this.SendFileButton.Text = "UPLOAD FILE";
            this.SendFileButton.UseVisualStyleBackColor = true;
            this.SendFileButton.Click += new System.EventHandler(this.SendFileButton_Click);
            // 
            // DownloadButton
            // 
            this.DownloadButton.AutoSize = true;
            this.DownloadButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.DownloadButton.Location = new System.Drawing.Point(267, 0);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(267, 450);
            this.DownloadButton.TabIndex = 1;
            this.DownloadButton.Text = "DOWNLOAD FILE";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // PremiumButton
            // 
            this.PremiumButton.AutoSize = true;
            this.PremiumButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.PremiumButton.Location = new System.Drawing.Point(534, 0);
            this.PremiumButton.Name = "PremiumButton";
            this.PremiumButton.Size = new System.Drawing.Size(267, 450);
            this.PremiumButton.TabIndex = 2;
            this.PremiumButton.Text = "PREMIUM";
            this.PremiumButton.UseVisualStyleBackColor = true;
            this.PremiumButton.Click += new System.EventHandler(this.PremiumButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PremiumButton);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.SendFileButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SendFileButton;
        private System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.Button PremiumButton;
    }
}

