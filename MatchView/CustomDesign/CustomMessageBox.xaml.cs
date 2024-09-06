using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace MatchView.CustomDesign
{
    /// <summary>
    /// Interaction logic for CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window
    {
        public string Message { get; set; } 
        public string TitleWindow { get; set; } 

        public CustomMessageBox()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void PrimaryButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void SecondaryButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                PrimaryButton_Click(this, new RoutedEventArgs());
            }
            else if (e.Key == Key.Escape)
            {
                SecondaryButton_Click(this, new RoutedEventArgs());
            }
        }

        public static bool? ShowFromResources(string messageKey, string titleKey, MessageBoxButton buttons, string language)
        {
            var messageBox = new CustomMessageBox
            {
                TitleWindow = GetResourceString(titleKey, language),
                Message = GetResourceString(messageKey, language)
            };

            ConfigureButtons(messageBox, buttons, language);

            return messageBox.ShowDialog();
        }

        public static bool? ShowCustomMessage(string message, string title, MessageBoxButton buttons, string language)
        {
            var messageBox = new CustomMessageBox
            {
                TitleWindow = title,
                Message = message
            };

            ConfigureButtons(messageBox, buttons, language); 

            return messageBox.ShowDialog();
        }

        public static bool? ShowRawResourceMessage(string message, string titleKey, MessageBoxButton buttons, string language)
        {
            var messageBox = new CustomMessageBox
            {
                TitleWindow = GetResourceString(titleKey, language),
                Message = message
            };

            ConfigureButtons(messageBox, buttons, language);

            return messageBox.ShowDialog();
        }

        public static bool? ShowResourceRawMessage(string messageKey, string title, MessageBoxButton buttons, string language)
        {
            var messageBox = new CustomMessageBox
            {
                TitleWindow = title,
                Message = GetResourceString(messageKey, language)
            };

            ConfigureButtons(messageBox, buttons, language);

            return messageBox.ShowDialog();
        }


        private static void ConfigureButtons(CustomMessageBox messageBox, MessageBoxButton buttons, string language)
        {
            switch (buttons)
            {
                case MessageBoxButton.OKCancel:
                    messageBox.PrimaryButton.Content = GetResourceString("btnOk", language);
                    messageBox.SecondaryButton.Content = GetResourceString("btnCancel", language);
                    break;
                case MessageBoxButton.YesNo:
                    messageBox.PrimaryButton.Content = GetResourceString("btnYes", language);
                    messageBox.SecondaryButton.Content = GetResourceString("btnNo", language);
                    break;
                default:
                    messageBox.SecondaryButton.Visibility = Visibility.Collapsed;
                    messageBox.PrimaryButton.Content = GetResourceString("btnOk", language);
                    break;
            }
        }

        private static string GetResourceString(string key, string culture)
        {
            string resourceName = $"MatchView.Properties.Resource_{culture}";

            ResourceManager resourceManager = new ResourceManager(resourceName, typeof(CustomMessageBox).Assembly);
            CultureInfo cultureInfo = new CultureInfo(culture);
            return resourceManager.GetString(key, cultureInfo) ?? key;
        }
    }
}
