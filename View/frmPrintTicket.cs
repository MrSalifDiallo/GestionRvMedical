using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Model;
using WindowsFormsApp1.Report;

namespace WindowsFormsApp1.View
{
    public partial class frmPrintTicket: Form
    {
        public frmPrintTicket()
        {
            InitializeComponent();
        }
        BdRvMedicalContext bd = new BdRvMedicalContext();
        private void frmPrintTicket_Load(object sender, EventArgs e)
        {
            rptTicketRv ticket = new rptTicketRv();
            ticket.SetDataSource(GetTableTicket(0));
            crystalReportViewer1.ReportSource = ticket;
            crystalReportViewer1.Refresh();
        }

        public DataTable GetTableTicket(int? idRv=0)
        {
            DataTable table = new DataTable();
            table.Columns.Add("NomPrenom", typeof(string));
            table.Columns.Add("DateNaissance", typeof(DateTime));
            table.Columns.Add("DateRv", typeof(DateTime));
            table.Columns.Add("HeureRv", typeof(string));
            table.Columns.Add("Medecin", typeof(string));
            table.Columns.Add("DataQr", typeof(byte));

            var leRv = bd.AllRendezvous.Where(a => a.IdRv == idRv).FirstOrDefault();
            if (leRv!=null)
            {
                table.Rows.Add(leRv.Patient.NomPrenom, leRv.Patient.DateNaissance,
                leRv.DateRv, leRv.Medecin.NomPrenom);
            }
            else
            {
                table.Rows.Add("Diallo Salif", DateTime.Now,
                 DateTime.Now, "Omar Samb",new byte[0]);
            }
                return table;
        }
    }
}
