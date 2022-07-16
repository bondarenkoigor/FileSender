using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSender
{
    public class MyFile
    {
        public FileInfo file;
        public DateTime DeletionTime { get; set; }
        private ServerClass Server { get; set; }
        public int Identificator { get; set; }

        public MyFile(string filepath, ServerClass server)
        {
            this.file = new FileInfo(filepath);
            this.Server = server;
            Random random = new Random(Convert.ToInt32(file.FullName.Length + file.Length + file.LastWriteTime.Hour));
            Identificator = random.Next();
        }

        public void SetDeletionTime(TimeSpan timespan)
        {
            this.DeletionTime = DateTime.Now.Add(timespan);
            Task.Run(() =>
            {
                while (true)
                {
                    if (DateTime.Now > DeletionTime)
                    {
                        file.Delete();
                        Server.UpdateFiles();
                        break;
                    }
                }
            });
        }

        public override string ToString()
        {
            return file.Name + " [" + file.CreationTime.ToShortDateString() + "]";
        }
    }
}
