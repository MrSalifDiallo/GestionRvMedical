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
using WindowsServiceSendMail.Helper;
namespace WindowsServiceSendMail
{
    public partial class ServiceSendMailMedical : ServiceBase
    {
        private static Timer aTimer;
        Utils utils=new Utils();
        public ServiceSendMailMedical()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            aTimer=new Timer(1000);
            Utils.WriteLogSystem("Démarrage du Service SendMail ", string.Format("Le service a commencé le {}", DateTime.Now), "Send Mail:");
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;
        }

        protected override void OnStop()
        {
            aTimer.Stop();
            aTimer.Dispose();
            Utils.WriteLogSystem("Arret du Service SendMail", string.Format("Le service est s'arrêté le {}",DateTime.Now),"Send Mail:");
        }
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            try
            {
                Utils.WriteLogSystem("test", "Logging:" + DateTime.Now.ToString(), "Send Mail:");
            }
            catch (Exception ex)
            {

            }
            aTimer.Start();
        }
    }
}
