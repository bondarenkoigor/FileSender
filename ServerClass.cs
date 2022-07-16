using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;

namespace FileSender
{
    public class ServerClass
    {
        private IPEndPoint iPEnd;
        private Socket socket;
        private Socket clientSocket;
        private readonly int PORT = 1234;
        public ServerClass()
        {
            iPEnd = new IPEndPoint(IPAddress.Parse("127.0.0.1"), PORT);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Work()
        {
            try
            {
                socket.Bind(iPEnd);
                socket.Listen(10);
                clientSocket = socket.Accept();

                while (true)
                {
                    string messageType = ReceiveString();
                    clientSocket.Send(Encoding.Unicode.GetBytes("message type confirmed"));
                    if (messageType == "file")
                    {
                        string fileName = ReceiveString();
                        clientSocket.Send(Encoding.Unicode.GetBytes("file name received"));
                        using (NetworkStream networkStream = new NetworkStream(clientSocket))
                        {
                            using (FileStream fileStream = File.Open("Files\\" + fileName, FileMode.OpenOrCreate))
                            {
                                byte[] buffer = new byte[256];
                                do
                                {
                                    networkStream.Read(buffer, 0, buffer.Length);
                                    fileStream.Write(buffer, 0, buffer.Length);
                                } while (networkStream.DataAvailable);
                            }
                        }
                        UpdateFilesEvent?.Invoke(this, EventArgs.Empty);
                        SendIdToUser(new MyFile("Files\\" + fileName, this));
                    }
                    else if (messageType == "download")
                    {
                        string identificator = ReceiveString();
                        var foundFile = Directory.GetFiles("Files").ToList<string>().Find(file => new MyFile(file, this).Identificator == int.Parse(identificator));
                        if (foundFile == default)
                        {
                            clientSocket.Send(Encoding.Unicode.GetBytes("incorrect"));
                            continue;
                        }
                        clientSocket.Send(Encoding.Unicode.GetBytes("correct"));
                        ReceiveString();//confirm sending file name
                        clientSocket.Send(Encoding.Unicode.GetBytes(new FileInfo(foundFile).Name));
                        ReceiveString();//confirm sending file
                        clientSocket.Send(File.ReadAllBytes(foundFile));

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SendIdToUser(MyFile file) =>
            clientSocket.Send(Encoding.Unicode.GetBytes(file.Identificator.ToString()));

        public event EventHandler UpdateFilesEvent;
        public void UpdateFiles() => UpdateFilesEvent?.Invoke(this, EventArgs.Empty);
        private string ReceiveString()
        {
            byte[] buffer = new byte[256];
            int byteCount = 0;
            StringBuilder sb = new StringBuilder();
            do
            {
                byteCount = clientSocket.Receive(buffer);
                sb.Append(Encoding.Unicode.GetString(buffer, 0, byteCount));
            } while (clientSocket.Available > 0);
            return sb.ToString();
        }

    }
}
