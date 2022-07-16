using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSender
{
    public partial class Form1 : Form
    {
        public ServerClass server = new ServerClass();
        public Form1()
        {
            InitializeComponent();
            server.UpdateFilesEvent += UpdateListBoxItems;
            if (!Directory.Exists("Files")) Directory.CreateDirectory("Files");
            try
            {
                Task.Factory.StartNew(server.Work);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void UpdateListBoxItems(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                this.FilesListBox.Items.Clear();
                foreach (string file in Directory.GetFiles("Files"))
                    this.FilesListBox.Items.Add(new MyFile(file, server));
                this.FilesListBox.Refresh();
            }));
        }

        private void FilesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateListBoxItems(server, EventArgs.Empty);
        }

        private void DeleteFileButton_Click(object sender, EventArgs e)
        {
            if (this.FilesListBox.SelectedItem == null) return;
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes) return;

            var item = this.FilesListBox.SelectedItem as MyFile;
            (item as MyFile).file.Delete();
            this.FilesListBox.Items.Remove(item);
            this.UpdateListBoxItems(server, EventArgs.Empty);
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            if (this.FilesListBox.SelectedItem == null) return;
            System.Diagnostics.Process.Start((this.FilesListBox.SelectedItem as MyFile).file.FullName);
        }

        private void SetLifeSpanButton_Click(object sender, EventArgs e)
        {
            if (this.HoursTextBox.Text == String.Empty) this.HoursTextBox.Text = "0";
            if (this.MinutesTextBox.Text == String.Empty) this.MinutesTextBox.Text = "0";
            if (this.SecondsTextBox.Text == String.Empty) this.SecondsTextBox.Text = "0";
            if (this.FilesListBox.SelectedItem == null) return;

            try
            {
                TimeSpan timespan = new TimeSpan(int.Parse(HoursTextBox.Text), int.Parse(MinutesTextBox.Text), int.Parse(SecondsTextBox.Text));
                if (timespan == TimeSpan.Zero) MessageBox.Show("Life span should be larger than 0");
                else
                {
                    (this.FilesListBox.SelectedItem as MyFile).SetDeletionTime(timespan);
                    MessageBox.Show($"Life span set to {timespan.Days}:{timespan.Hours}:{timespan.Minutes}:{timespan.Seconds}");
                }
            }
            catch (FormatException) { MessageBox.Show("Enter whole numbers"); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
