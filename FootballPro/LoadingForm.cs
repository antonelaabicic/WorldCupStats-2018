using FootballPro.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballPro
{
    public partial class LoadingForm : Form
    {
        private string _language;

        public LoadingForm(string language)
        {
            InitializeComponent();
            ResetLanguage(language); 
        }

        public void ResetLanguage(string language)
        {
            _language = language;
            label1.Text = _language switch
            {
                "en-US" => Resource_en_US.lbWait,
                "de-DE" => Resource_de_DE.lbWait,
                "hr-HR" => Resource_hr_HR.lbWait,
                _ => Resource_en_US.lbWait
            };
        }

        public void StartLoader()
        {
            this.Show();
            this.BringToFront();
        }

        public void StopLoader()
        {
            this.Hide();
        }
    }
}
