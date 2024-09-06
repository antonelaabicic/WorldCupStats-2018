using DataLayer.Models;
using FootballPro.Properties;
using Newtonsoft.Json;
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
    public partial class PlayerUC : UserControl
    {
        public bool IsSelected { get; set; }
        private Gender _gender;
        private string _language;
        private Player _player;
        private string baseDefaultPicturePath = "../../../../DataLayer/Images";
        private Point _mouseDownLocation;

        public PlayerUC(Gender gender, Player player, string language)
        {
            InitializeComponent();
            _gender = gender;
            _language = language;
            _player = player;
            InitializePlayer();
            SetButtonText();

            this.Click += PlayerUC_Click;
            this.MouseDown += PlayerUC_MouseDown;
            this.MouseMove += PlayerUC_MouseMove;
        }

        private void SetButtonText()
        {
            btnAddPicture.Text = _language switch
            {
                "en-US" => Resource_en_US.btnAddPicture,
                "de-DE" => Resource_de_DE.btnAddPicture,
                "hr-HR" => Resource_hr_HR.btnAddPicture,
                _ => Resource_en_US.btnAddPicture
            };
        }

        private void InitializePlayer()
        {
            lbPlayerName.Text = _player.Name;
            lbShirtNumber.Text = _player.ShirtNumber.ToString();
            lbPosition.Text = _player.Position;
            pbCaptain.Visible = _player.Captain;

            SetPlayerPicture();
            this.BackColor = _gender == Gender.Men ? Color.ForestGreen : Color.SteelBlue;
        }

        private void SetPlayerPicture()
        {
            if (!string.IsNullOrEmpty(_player.ImagePath) && File.Exists(_player.ImagePath))
            {
                pbPlayer.Image = Image.FromFile(_player.ImagePath);
            }
            else
            {
                SetDefaultPicture();
            }
        }

        private void SetDefaultPicture()
        {
            string defaultPicturePath = _gender == Gender.Men
                ? Path.Combine(baseDefaultPicturePath, "male_player.png")
                : Path.Combine(baseDefaultPicturePath, "female_player.png");

            if (File.Exists(defaultPicturePath))
            {
                pbPlayer.Image = Image.FromFile(defaultPicturePath);
                _player.ImagePath = defaultPicturePath;
            }
            else
            {
                pbPlayer.Image = Image.FromFile(Path.Combine(baseDefaultPicturePath, "genderneutral_icon.png"));
                _player.ImagePath = Path.Combine(baseDefaultPicturePath, "genderneutral_icon.png");
                MessageBox.Show("Default player picture not found.", "Warning", MessageBoxButtons.OK);
            }
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pbPlayer.Image = new Bitmap(openFileDialog.FileName);
                    _player.ImagePath = openFileDialog.FileName;
                }
            }
        }

        private void PlayerUC_Click(object? sender, EventArgs e)
        {
            IsSelected = !IsSelected;
            if (_gender == Gender.Men)
            {
                this.BackColor = IsSelected ? Color.DarkSeaGreen : Color.ForestGreen;
            }
            else
            {
                this.BackColor = IsSelected ? Color.CadetBlue : Color.SteelBlue;
            }
        }

        private void PlayerUC_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _mouseDownLocation = e.Location;
            }
        }

        private void PlayerUC_MouseMove(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Math.Abs(e.X - _mouseDownLocation.X) > SystemInformation.DragSize.Width ||
                    Math.Abs(e.Y - _mouseDownLocation.Y) > SystemInformation.DragSize.Height)
                {
                    var parentPanel = this.Parent as FlowLayoutPanel;
                    if (parentPanel != null)
                    {
                        var selectedPlayerUCs = parentPanel.Controls.OfType<PlayerUC>().Where(p => p.IsSelected).ToList();
                        if (selectedPlayerUCs.Count > 1)
                        {
                            DoDragDrop(selectedPlayerUCs, DragDropEffects.Move);
                        }
                        else
                        {
                            DoDragDrop(this, DragDropEffects.Move);
                        }
                    }
                }
            }
        }

        public Player GetPlayer()
        {
            return _player;
        }
    }
}