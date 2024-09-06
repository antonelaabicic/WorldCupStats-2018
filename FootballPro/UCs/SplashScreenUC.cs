using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballPro.UCs
{
    public partial class SplashScreenUC : UserControl
    {
        public event EventHandler? ProgressCompleted;

        public SplashScreenUC()
        {
            InitializeComponent();
        }

        private void SplashScreenUC_Load(object sender, EventArgs e)
        {
            timerSC.Start();
        }

        private void TimerSC_Tick(object sender, EventArgs e)
        {
            if (pBrSC.Value < 100)
            {
                pBrSC.Value += 1;
                lbSC.Text = pBrSC.Value.ToString() + "%";
            }
            else
            {
                timerSC.Stop();
                OnProgressCompleted(EventArgs.Empty);
            }
        }

        protected virtual void OnProgressCompleted(EventArgs e)
        {
            ProgressCompleted?.Invoke(this, e);
        }
    }
}
