using DataLayer.Models;
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
    public partial class GoalCardUC : UserControl
    {
        private MatchEventType _matchEventType;
        private Player _player;

        public GoalCardUC(MatchEventType matchEventType, Player player)
        {
            InitializeComponent();

            _matchEventType = matchEventType;
            _player = player;

            InitializePlayer();
        }

        private void InitializePlayer()
        {
            lbPlayerName.Text = _player.Name;
            lbNoGoalsCards.Text = _matchEventType == MatchEventType.Goal ? _player.GoalsCount.ToString() : _player.YellowCardCount.ToString();
            this.BackColor = _matchEventType == MatchEventType.Goal ? Color.SlateBlue : Color.MediumPurple;

            SetPlayerPicture();
            SetGoalCardImage();
        }

        private void SetPlayerPicture()
        {
            if (!string.IsNullOrEmpty(_player.ImagePath) && File.Exists(_player.ImagePath))
            {
                pbPlayer.Image = Image.FromFile(_player.ImagePath);
            }
        }

        private void SetGoalCardImage()
        {
            string basePath = "../../../../FootballPro/Resources";
            string imagePath = _matchEventType == MatchEventType.Goal ? Path.Combine(basePath, "goal.png") : Path.Combine(basePath, "yellow_card.png");

            if (File.Exists(imagePath))
            {
                pbGoalCard.Image = Image.FromFile(imagePath);
            }
            else
            {
                MessageBox.Show("Image not found.", "Warning", MessageBoxButtons.OK);
            }
        }
    }
}
