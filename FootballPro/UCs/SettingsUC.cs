using DataLayer.Models;
using FootballPro.CustomDesign;
using FootballPro.Events;
using FootballPro.Properties;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FootballPro.UCs
{
    public partial class SettingsUC : UserControl
    {
        public event EventHandler<SettingsEventArgs>? SettingsSaved;

        private string _selectedLanguage;
        private Gender _selectedChampionship;

        private string _originalLanguage;

        public SettingsUC(string language, Gender championship)
        {
            InitializeComponent();

            if (language == null)
            {
                _selectedLanguage = "en-US";
            }
            else
            {
                _selectedLanguage = language;
                _selectedChampionship = championship;

                _originalLanguage = language;
            }

            switch (_originalLanguage)
            {
                case "en-US":
                    label1.Text = Resource_en_US.lbLangSettings;
                    label2.Text = Resource_en_US.lbChampSettings;
                    break;

                case "hr-HR":
                    label1.Text = Resource_hr_HR.lbLangSettings;
                    label2.Text = Resource_hr_HR.lbChampSettings;
                    break;

                case "de-DE":
                    label1.Text = Resource_de_DE.lbLangSettings;
                    label2.Text = Resource_de_DE.lbChampSettings;
                    break;

                default:
                    label1.Text = Resource_en_US.lbLangSettings;
                    label2.Text = Resource_en_US.lbChampSettings;
                    break;
            }

            btnSaveSettings.Click += BtnSaveSettings_Click;
        }

        // settings load
        private void SettingsUC_Load(object sender, EventArgs e)
        {
            PopulateLanguageDropdown();
            PopulateChampionshipDropdown();
            SetSelectedLanguage();
            SetSelectedChampionship();
        }

        private void PopulateLanguageDropdown()
        {
            cbLanguage.Items.Clear();

            var languageResources = GetLanguageResourcesByCulture(_selectedLanguage);

            cbLanguage.Items.Add(new LanguageItem { Text = languageResources.English, Tag = "en-US" });
            cbLanguage.Items.Add(new LanguageItem { Text = languageResources.German, Tag = "de-DE" });
            cbLanguage.Items.Add(new LanguageItem { Text = languageResources.Croatian, Tag = "hr-HR" });
        }

        private void PopulateChampionshipDropdown()
        {
            cbChampionship.Items.Clear();

            var championshipResources = GetChampionshipResourcesByCulture(_selectedLanguage);

            cbChampionship.Items.Add(new GenderItem(Gender.Men, championshipResources.Male));
            cbChampionship.Items.Add(new GenderItem(Gender.Women, championshipResources.Female));
        }

        private void SetSelectedLanguage()
        {
            foreach (LanguageItem item in cbLanguage.Items)
            {
                if (item.Tag.ToString() == _selectedLanguage)
                {
                    cbLanguage.SelectedItem = item;
                    break;
                }
            }
        }

        private void SetSelectedChampionship()
        {
            cbChampionship.SelectedItem =
                cbChampionship.Items.Cast<GenderItem>().FirstOrDefault(item => item.GenderValue == _selectedChampionship);
        }

        private (string English, string German, string Croatian) GetLanguageResourcesByCulture(string culture)
        {
            return culture switch
            {
                "en-US" => (Resource_en_US.ddlEnglish, Resource_en_US.ddlGerman, Resource_en_US.ddlCroatian),
                "hr-HR" => (Resource_hr_HR.ddlEnglish, Resource_hr_HR.ddlGerman, Resource_hr_HR.ddlCroatian),
                "de-DE" => (Resource_de_DE.ddlEnglish, Resource_de_DE.ddlGerman, Resource_de_DE.ddlCroatian),
                _ => (Resource_en_US.ddlEnglish, Resource_en_US.ddlGerman, Resource_en_US.ddlCroatian)
            };
        }

        private (string Male, string Female) GetChampionshipResourcesByCulture(string culture)
        {
            return culture switch
            {
                "en-US" => (Resource_en_US.ddlMale, Resource_en_US.ddlFemale),
                "hr-HR" => (Resource_hr_HR.ddlMale, Resource_hr_HR.ddlFemale),
                "de-DE" => (Resource_de_DE.ddlMale, Resource_de_DE.ddlFemale),
                _ => (Resource_en_US.ddlMale, Resource_en_US.ddlFemale)
            };
        }

        // saving settings
        private void BtnSaveSettings_Click(object? sender, EventArgs e)
        {
            var selectedItem = cbLanguage.SelectedItem as LanguageItem;
            _selectedLanguage = selectedItem?.Tag.ToString() ?? "en-US";

            _selectedChampionship = (cbChampionship.SelectedItem as GenderItem)?.GenderValue ?? Gender.Men;

            if (_selectedLanguage != _originalLanguage || _selectedChampionship != (cbChampionship.SelectedItem as GenderItem)?.GenderValue)
            {
                DialogResult result = CallConfirmMessage(_originalLanguage, _selectedLanguage, _selectedChampionship);

                if (result == DialogResult.OK)
                {
                    OnSettingsSaved(new SettingsEventArgs { Language = _selectedLanguage, Championship = _selectedChampionship });
                }
            }
            else
            {
                CallDidNotChooseSettingsMessage();
            }
        }

        protected virtual void OnSettingsSaved(SettingsEventArgs e)
        {
            SettingsSaved?.Invoke(this, e);
        }

        private DialogResult CallConfirmMessage(string originalLanguage, string selectedLanguage, Gender selectedChampionship)
        {
            string message = "";
            string warning = "";
            string lan;
            string champ;

            if (originalLanguage == "en-US")
            {
                lan = selectedLanguage switch
                {
                    "hr-HR" => "Croatian",
                    "de-DE" => "German",
                    "en-US" => "English",
                    _ => "English"
                };

                champ = selectedChampionship switch
                {
                    Gender.Men => "mens",
                    Gender.Women => "womens",
                    _ => "mens"
                };

                message = String.Format(Resource_en_US.messageLangAndChamp, lan, champ);
                warning = Resource_en_US.messageWarning;

            }
            else if (originalLanguage == "hr-HR")
            {
                lan = selectedLanguage switch
                {
                    "hr-HR" => "hrvatski",
                    "de-DE" => "njemački",
                    "en-US" => "engleski",
                    _ => "engleski"
                };

                champ = selectedChampionship switch
                {
                    Gender.Men => "mušku",
                    Gender.Women => "žensku",
                    _ => "mušku"
                };

                message = String.Format(Resource_hr_HR.messageLangAndChamp, lan, champ);
                warning = Resource_hr_HR.messageWarning;
            }
            else if (originalLanguage == "de-DE")
            {
                lan = selectedLanguage switch
                {
                    "hr-HR" => "die kroatische",
                    "de-DE" => "die deutsche",
                    "en-US" => "die englische",
                    _ => "Englisch"
                };

                champ = selectedChampionship switch
                {
                    Gender.Men => "Männer",
                    Gender.Women => "Frauen",
                    _ => "Männer"
                };

                message = String.Format(Resource_de_DE.messageLangAndChamp, lan, champ);
                warning = Resource_de_DE.messageWarning;
            }

            var result = CustomMessageBox.Show(message, warning, MessageBoxButtons.OKCancel, _originalLanguage);
            return result;
        }

        private void CallDidNotChooseSettingsMessage()
        {
            string warning = "";
            string message = "";

            switch (_originalLanguage)
            {
                case "en-US":
                    warning = Resource_en_US.messageWarning;
                    message = Resource_en_US.messageChooseLangAndChamp;
                    break;

                case "hr-HR":
                    warning = Resource_hr_HR.messageWarning;
                    message = Resource_hr_HR.messageChooseLangAndChamp;
                    break;

                case "de-DE":
                    warning = Resource_de_DE.messageWarning;
                    message = Resource_de_DE.messageChooseLangAndChamp;
                    break;

                default:
                    warning = Resource_en_US.messageWarning;
                    message = Resource_en_US.messageChooseLangAndChamp;
                    break;
            }
            CustomMessageBox.Show(message, warning, MessageBoxButtons.OK, _originalLanguage);
        }
    }
}
