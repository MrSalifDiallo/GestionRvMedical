using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.View.GunaUi
{
    public partial class frmSmallLoading : Form
    {
        public frmSmallLoading()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (guna2CircleProgressBar1.Value == 100)
            {
                timer1.Stop();
                this.Hide();
            }
            else
            {
                guna2CircleProgressBar1.Value += 1;
                label1.Text = (Convert.ToInt32(label1.Text) + 1).ToString();
            }
        }

        private void frmSmallLoading_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
