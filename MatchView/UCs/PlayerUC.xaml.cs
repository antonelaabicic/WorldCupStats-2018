using DataLayer.Models;
using MatchView.Events;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for PlayerUC.xaml
    /// </summary>
    public partial class PlayerUC : UserControl
    {
        private Gender _championship;
        private bool _isFavTeam;
        private Player _player;
        private ScreenSize _screenSize;

        public event EventHandler<PlayerDataEventArgs> PlayerTransferData;

        public PlayerUC(Gender championship, bool isFavTeam, Player player, ScreenSize screenSize)
        {
            InitializeComponent();
            _championship = championship;
            _isFavTeam = isFavTeam;
            _player = player;
            _screenSize = screenSize;

            InitializePlayer(player);
            DataContext = this;
        }
        private void InitializePlayer(Player player)
        {
            if (_screenSize == ScreenSize.Small)
            {
                this.Width = 85;
                this.Height = 105;

                profileBorder.Width = 75;
                profileBorder.Height = 75;

                profileEllipse.Width = 70;
                profileEllipse.Height = 70;

                shirtBorder.Width = 30;
                shirtBorder.Height = 30;
                shirtBorder.Margin = new Thickness(20, 0, 0, 20);

                lbShirtNo.FontSize = 16;
            }

            lbShirtNo.Text = player.ShirtNumber.ToString();
        }

        public void SetPlayerImagePath(string newImagePath)
        {
            var imagePath = newImagePath;

            imagePath = imagePath.Replace("\\", "/");

            Uri imageUri;
            if (Uri.IsWellFormedUriString(imagePath, UriKind.RelativeOrAbsolute))
            {
                imageUri = new Uri(imagePath, UriKind.RelativeOrAbsolute);
            }
            else
            {
                imageUri = new Uri(imagePath, UriKind.Relative);
            }

            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = imageUri;
            bitmapImage.EndInit();

            playerProfileImg.ImageSource = bitmapImage;

            _player.ImagePath = imagePath;
        }


        public Brush TeamColor
        {
            get
            {
                return _isFavTeam ? Brushes.Orange : Brushes.Red;
            }
        }

        private void OnPlayerControlClicked(object sender, MouseButtonEventArgs e)
        {
            PlayerTransferData?.Invoke(this, new PlayerDataEventArgs(_player));
        }
    }
}
