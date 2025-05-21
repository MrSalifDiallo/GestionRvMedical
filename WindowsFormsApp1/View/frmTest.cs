using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.View
{
    public partial class frmTest : Form
    {
        ServiceMetierAgenda.AgendaServiceClient serviceAgenda = new ServiceMetierAgenda.AgendaServiceClient(); // ✅ Service WCF
        public frmTest()
        {
            InitializeComponent();
            dgAgenda.DataSource = serviceAgenda.LoadAgenda(DateTime.Now);
            
        }

        private void dgAgenda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
