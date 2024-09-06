using DataLayer.Models;
using MatchView.CustomDesign;
using MatchView.Events;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatchView.UCs
{
    /// <summary>
    /// Interaction logic for SettingsUC.xaml
    /// </summary>
    public partial class SettingsUC : UserControl
    {
        private string _selectedLanguage;
        private Gender _selectedChampionship;
        private ScreenSize _selectedScreenSize;

        private string _originalLanguage;
        private Gender _originalChampionship;
        private ScreenSize _originalScreenSize;

        private ResourceManager _resourceManager;

        public event EventHandler<SettingsChangedEventArgs> SettingsSaved;

        public SettingsUC(string language, Gender championship, ScreenSize screenSize)
        {
            InitializeComponent();
            _selectedLanguage = language;
            _selectedChampionship = championship;
            _selectedScreenSize = screenSize;

            _originalLanguage = language;
            _originalChampionship = championship;
            _originalScreenSize = screenSize;

            SetLanguageResources();
            PopulateComboBoxes();
        }

        private void SetLanguageResources()
        {
            try
            {
                CultureInfo culture = new CultureInfo(_selectedLanguage);
                string resourceName = $"MatchView.Properties.Resource_{_selectedLanguage}";

                _resourceManager = new ResourceManager(resourceName, typeof(SettingsUC).Assembly);

                txtBlockLanguage.Text = _resourceManager.GetString("lbLangSettings", culture);
                txtBlockChampionship.Text = _resourceManager.GetString("lbChampSettings", culture);
                txtBlockScreenSize.Text = _resourceManager.GetString("lbScreenSizeSettings", culture);
                btnSaveText.Content = _resourceManager.GetString("btnSave", culture);
            }
            catch (Exception)
            {
                CustomMessageBox.ShowCustomMessage("messageDataUnavaliable", "messageWarning", MessageBoxButton.OKCancel, _selectedLanguage);
            }
        }

        private void PopulateComboBoxes()
        {
            CultureInfo culture = new CultureInfo(_selectedLanguage);

            // populate languages 
            comboBoxLanguages.ItemsSource = new List<LanguageItem>
            {
                new LanguageItem { Text = _resourceManager.GetString("ddlEnglish", culture), Tag = "en-US" },
                new LanguageItem { Text = _resourceManager.GetString("ddlCroatian", culture), Tag = "hr-HR" },
                new LanguageItem { Text = _resourceManager.GetString("ddlGerman", culture), Tag = "de-DE" }
            };

            // populate genders 
            comboBoxGenders.ItemsSource = new List<GenderItem>
            {
                new GenderItem(Gender.Men, _resourceManager.GetString("ddlMale", culture)),
                new GenderItem(Gender.Women, _resourceManager.GetString("ddlFemale", culture))
            };

            // populate screen sizes 
            comboBoxScreenSizes.ItemsSource = new List<ScreenSizeItem>
            {
                new ScreenSizeItem(ScreenSize.Original, _resourceManager.GetString("ddlOriginal", culture)),
                new ScreenSizeItem(ScreenSize.Fullscreen, _resourceManager.GetString("ddlFullscreen", culture)),
                new ScreenSizeItem(ScreenSize.Small, _resourceManager.GetString("ddlSmall", culture))
            };

            // set initial selections 
            comboBoxLanguages.SelectedItem = comboBoxLanguages.Items.OfType<LanguageItem>().FirstOrDefault(x => (string)x.Tag == _originalLanguage);
            comboBoxGenders.SelectedItem = comboBoxGenders.Items.OfType<GenderItem>().FirstOrDefault(x => x.GenderValue == _originalChampionship);
            comboBoxScreenSizes.SelectedItem = comboBoxScreenSizes.Items.OfType<ScreenSizeItem>().FirstOrDefault(x => x.ScreenSizeValue == _originalScreenSize);
        }

        private void ComboBoxLanguages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = comboBoxLanguages.SelectedItem as LanguageItem;
            if (selectedItem != null)
            {
                _selectedLanguage = selectedItem.Tag.ToString();
            }
        }

        private void ComboBoxGenders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = comboBoxGenders.SelectedItem as GenderItem;
            if (selectedItem != null)
            {
                _selectedChampionship = selectedItem.GenderValue;
            }
        }

        private void ComboBoxScreenSizes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = comboBoxScreenSizes.SelectedItem as ScreenSizeItem;
            if (selectedItem != null)
            {
                _selectedScreenSize = selectedItem.ScreenSizeValue;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var missingMessages = GetMissingSelectionMessages();

            if (missingMessages.Any())
            {
                string joinedMessages = string.Join(", ", missingMessages);
                string messageTemplate = _resourceManager.GetString("msgMissingSelectionsTemplate", new CultureInfo(_originalLanguage));
                string message = string.Format(messageTemplate, joinedMessages);

                CustomMessageBox.ShowRawResourceMessage(
                    message,
                    _resourceManager.GetString("messageWarning", new CultureInfo(_selectedLanguage)),
                    MessageBoxButton.OKCancel, _selectedLanguage
                );
                return;
            }

            bool? result = CustomMessageBox.ShowFromResources("messageLangAndChamp", "messageWarning", MessageBoxButton.YesNo, _originalLanguage);

            if (result == true)
            {
                SettingsSaved?.Invoke(this, new SettingsChangedEventArgs(_selectedLanguage, _selectedChampionship, _selectedScreenSize));
            }
            return;
        }

        private List<string> GetMissingSelectionMessages()
        {
            List<string> missingMessages = new List<string>();
            CultureInfo cultureInfo = new CultureInfo(_selectedLanguage);

            if (_selectedLanguage == _originalLanguage || comboBoxLanguages.SelectedItem == null)
            {
                string message = _resourceManager.GetString("msgMissingLanguage", cultureInfo);
                if (!string.IsNullOrEmpty(message))
                {
                    missingMessages.Add(message);
                }
            }

            if (_selectedChampionship == _originalChampionship || comboBoxGenders.SelectedItem == null)
            {
                string message = _resourceManager.GetString("msgMissingChampionship", cultureInfo);
                if (!string.IsNullOrEmpty(message))
                {
                    missingMessages.Add(message);
                }
            }

            if (_selectedScreenSize == _originalScreenSize || comboBoxScreenSizes.SelectedItem == null)
            {
                string message = _resourceManager.GetString("msgMissingScreenSize", cultureInfo);
                if (!string.IsNullOrEmpty(message))
                {
                    missingMessages.Add(message);
                }
            }

            return missingMessages;
        }
    }
    
}
