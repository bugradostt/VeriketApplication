using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        }

        // Servis duruduğunda
        protected override void OnStop()
        {
        }
        
      
    }
}
