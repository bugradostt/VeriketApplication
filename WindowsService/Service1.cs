using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsService
{
    public partial class Service1 : ServiceBase
    {
        Timer veriketTimer = new Timer();
        public Service1()
        {
            InitializeComponent();
        }

        // Servis çalıştığında
        protected override void OnStart(string[] args)
        {
            string msg = DateTime.Now + ", Servis Başladı , -";
            WriteFile(msg);

            veriketTimer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            veriketTimer.Interval = 60000;
            veriketTimer.Start();
        }

        // Servis duruduğunda
        protected override void OnStop()
        {
            string msg = DateTime.Now + ", Servis Durdu , -";
            WriteFile(msg);
        }

        // Çalıştığı süre içerisinde
        public void OnElapsedTime(object source, ElapsedEventArgs e)
        {

            string msg = DateTime.Now + " , " + Environment.MachineName + " , " + Environment.UserName;
            WriteFile(msg);
        }

        public void WriteFile(string message)
        {
            // ProgramData klasörünün yolunu
            string programDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

            // VeriketApp klasörünün yolu
            string veriketAppFolderPath = Path.Combine(programDataPath, "VeriketApp");

            // Eğer VeriketApp klasörü yoksa oluştur
            if (!Directory.Exists(veriketAppFolderPath))
            {
                Directory.CreateDirectory(veriketAppFolderPath);
            }

            string textFilePath = Path.Combine(veriketAppFolderPath, "VeriketAppTest.txt");

            if (!File.Exists(textFilePath))
            {
                // Dosya yoksa eklesin
                using (StreamWriter sw = File.CreateText(textFilePath))
                {
                    sw.WriteLine(message);
                }

            }
            else
            {
                // Dosya varsa içine mesaj yazsın
                using (StreamWriter sw = File.AppendText(textFilePath))
                {
                    sw.WriteLine(message);
                }
            }
        }


    }
}
