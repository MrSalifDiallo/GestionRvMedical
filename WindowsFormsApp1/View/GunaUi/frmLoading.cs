using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.View.GunaUi
{
    public partial class frmLoading : Form
    {
        public event EventHandler LoadingCompleted;

        /// <summary>
        /// Déclenche l'événement pour signaler que le chargement est terminé
        /// </summary>
        protected virtual void OnLoadingCompleted()
        {
            LoadingCompleted?.Invoke(this, EventArgs.Empty);
        }

        public frmLoading()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (guna2CircleProgressBar1.Value == 100)
            {
                timer1.Stop();
                // Déclenche l'événement pour signaler que le chargement est terminé
                OnLoadingCompleted();
                //Principal p = new Principal();
                //p.Show();
                //this.Hide();
            }
            else
            {
                guna2CircleProgressBar1.Value += 1;
                lblValeur.Text = (Convert.ToInt32(lblValeur.Text) + 1).ToString();
            }
        }

        private void frmLoading_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            timer1.Start();
        }
    }
}
