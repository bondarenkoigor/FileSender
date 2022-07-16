namespace FileSender
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
            this.FilesListBox = new System.Windows.Forms.ListBox();
            this.DeleteFileButton = new System.Windows.Forms.Button();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.SetLifeSpanButton = new System.Windows.Forms.Button();
            this.HoursTextBox = new System.Windows.Forms.TextBox();
            this.MinutesTextBox = new System.Windows.Forms.TextBox();
            this.SecondsTextBox = new System.Windows.Forms.TextBox();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FilesListBox
            // 
            this.FilesListBox.FormattingEnabled = true;
            this.FilesListBox.Location = new System.Drawing.Point(12, 26);
            this.FilesListBox.Name = "FilesListBox";
            this.FilesListBox.Size = new System.Drawing.Size(224, 368);
            this.FilesListBox.TabIndex = 0;
            this.FilesListBox.SelectedIndexChanged += new System.EventHandler(this.FilesListBox_SelectedIndexChanged);
            // 
            // DeleteFileButton
            // 
            this.DeleteFileButton.Location = new System.Drawing.Point(12, 400);
            this.DeleteFileButton.Name = "DeleteFileButton";
            this.DeleteFileButton.Size = new System.Drawing.Size(111, 23);
            this.DeleteFileButton.TabIndex = 1;
            this.DeleteFileButton.Text = "Delete file";
            this.DeleteFileButton.UseVisualStyleBackColor = true;
            this.DeleteFileButton.Click += new System.EventHandler(this.DeleteFileButton_Click);
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Location = new System.Drawing.Point(125, 400);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(111, 23);
            this.OpenFileButton.TabIndex = 2;
            this.OpenFileButton.Text = "Open FIle";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // SetLifeSpanButton
            // 
            this.SetLifeSpanButton.Location = new System.Drawing.Point(12, 454);
            this.SetLifeSpanButton.Name = "SetLifeSpanButton";
            this.SetLifeSpanButton.Size = new System.Drawing.Size(75, 20);
            this.SetLifeSpanButton.TabIndex = 3;
            this.SetLifeSpanButton.Text = "Set life span";
            this.SetLifeSpanButton.UseVisualStyleBackColor = true;
            this.SetLifeSpanButton.Click += new System.EventHandler(this.SetLifeSpanButton_Click);
            // 
            // HoursTextBox
            // 
            this.HoursTextBox.Location = new System.Drawing.Point(93, 454);
            this.HoursTextBox.Name = "HoursTextBox";
            this.HoursTextBox.Size = new System.Drawing.Size(20, 20);
            this.HoursTextBox.TabIndex = 4;
            // 
            // MinutesTextBox
            // 
            this.MinutesTextBox.Location = new System.Drawing.Point(119, 454);
            this.MinutesTextBox.Name = "MinutesTextBox";
            this.MinutesTextBox.Size = new System.Drawing.Size(20, 20);
            this.MinutesTextBox.TabIndex = 5;
            // 
            // SecondsTextBox
            // 
            this.SecondsTextBox.Location = new System.Drawing.Point(145, 454);
            this.SecondsTextBox.Name = "SecondsTextBox";
            this.SecondsTextBox.Size = new System.Drawing.Size(20, 20);
            this.SecondsTextBox.TabIndex = 6;
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Location = new System.Drawing.Point(97, 438);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(62, 13);
            this.TimeLabel.TabIndex = 7;
            this.TimeLabel.Text = "h      m      s";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 487);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.SecondsTextBox);
            this.Controls.Add(this.MinutesTextBox);
            this.Controls.Add(this.HoursTextBox);
            this.Controls.Add(this.SetLifeSpanButton);
            this.Controls.Add(this.OpenFileButton);
            this.Controls.Add(this.DeleteFileButton);
            this.Controls.Add(this.FilesListBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox FilesListBox;
        private System.Windows.Forms.Button DeleteFileButton;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.Button SetLifeSpanButton;
        private System.Windows.Forms.TextBox HoursTextBox;
        private System.Windows.Forms.TextBox MinutesTextBox;
        private System.Windows.Forms.TextBox SecondsTextBox;
        private System.Windows.Forms.Label TimeLabel;
    }
}

