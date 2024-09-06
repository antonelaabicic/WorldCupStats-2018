using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MatchView
{
    /// <summary>
    /// Interaction logic for LoadingWindow.xaml
    /// </summary>
    public partial class LoadingWindow : Window
    {
        private string _language;
        public string WaitText { get; set; }

        public LoadingWindow(string language)
        {
            InitializeComponent();
            _language = language;
            DataContext = this;

            SetLocalizedText();
        }

        private void SetLocalizedText()
        {
            WaitText = GetResourceString("lbWait", _language);
        }

        private static string GetResourceString(string key, string language)
        {
            string resourceName = $"MatchView.Properties.Resource_{language}";

            ResourceManager resourceManager = new ResourceManager(resourceName, typeof(LoadingWindow).Assembly);
            CultureInfo cultureInfo = new CultureInfo(language);
            return resourceManager.GetString(key, cultureInfo) ?? key;
        }

        public void StartLoader()
        {
            if (!IsVisible)
            {
                Show();
                Activate(); 
            }
        }

        public void StopLoader()
        {
            if (IsVisible)
            {
                Close();
            }
        }
    }
}
