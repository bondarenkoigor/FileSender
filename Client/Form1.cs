using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Client
{
    public partial class Form1 : Form
    {
        Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        int maxDownloads = 5;
        int downloadCount = 0;

        public Form1()
        {
            InitializeComponent();

            Task.Factory.StartNew(() => // listen for identificator
            {
                while (true)
                {
                    lock (clientSocket)
                    {
                        if (clientSocket.Available > 0) MessageBox.Show("id: " + ReceiveString());
                    }
                }
            });

            try
            {
                clientSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SendFileButton_Click(object sender, EventArgs e)
        {
            lock (clientSocket)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.ShowDialog();
                if (openFileDialog.FileName == String.Empty) return;
                clientSocket.Send(Encoding.Unicode.GetBytes("file"));
                ReceiveString(); //confirm message type
                clientSocket.Send(Encoding.Unicode.GetBytes(new FileInfo(openFileDialog.FileName).Name));
                ReceiveString();//confirm file
                clientSocket.SendFile(openFileDialog.FileName);
            }
        }
        private string ReceiveString()
        {
            byte[] buffer = new byte[256];
            int byteCount = 0;
            StringBuilder sb = new StringBuilder();
            do
            {
                byteCount = clientSocket.Receive(buffer);
                if (byteCount == 0) break;
                sb.Append(Encoding.Unicode.GetString(buffer, 0, byteCount));
            } while (clientSocket.Available > 0);
            return sb.ToString();
        }
        private byte[] ReceiveFile()
        {
            byte[] buffer = new byte[256];
            int byteCount = 0;
            List<byte> bytes = new List<byte>();
            do
            {
                byteCount = clientSocket.Receive(buffer);
                if (byteCount == 0) break;
                bytes.AddRange(buffer);
            } while (clientSocket.Available > 0);
            return bytes.ToArray();
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            if(downloadCount >= maxDownloads)
            {
                MessageBox.Show("You reached download limit");
                return;
            }
            lock (clientSocket)
            {
                string Identificator = Microsoft.VisualBasic.Interaction.InputBox("Enter identificator:");
                if (Identificator == String.Empty) return;
                clientSocket.Send(Encoding.Unicode.GetBytes("download"));
                ReceiveString(); //confirm message type
                clientSocket.Send(Encoding.Unicode.GetBytes(Identificator));
                if (ReceiveString() == "correct")
                {
                    clientSocket.Send(Encoding.Unicode.GetBytes("Receiving file name"));
                    string filename = ReceiveString();
                    clientSocket.Send(Encoding.Unicode.GetBytes("Receiving file"));
                    File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $"\\{filename}", ReceiveFile());
                    MessageBox.Show("File saved to Documents folder");
                    downloadCount++;

                }
                else MessageBox.Show("wrong identificator");
            }
        }

        private void PremiumButton_Click(object sender, EventArgs e)
        {
            if(maxDownloads == 50)
            {
                MessageBox.Show("Premium already activated");
                return;
            }

            string key = Microsoft.VisualBasic.Interaction.InputBox("enter key:");
            if (key == "SECRETKEY")
            {
                this.maxDownloads = 50;
                MessageBox.Show("Premium activated");
            }
            else MessageBox.Show("incorrect key");
        }
    }
}
