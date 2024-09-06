using DataLayer.Models;
using FootballPro.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace FootballPro.UCs
{
    public partial class RankingListUC : UserControl
    {
        private string _fifaCode;
        private string _language;
        private List<Match> _matches;
        private List<Player> _players;

        // printing variables
        private List<Control> _currentUCListToPrint;
        private int _printIndex;

        private List<VisitorsUC> _visitorsUCList = new List<VisitorsUC>();
        private List<GoalCardUC> _goalsUCList = new List<GoalCardUC>();
        private List<GoalCardUC> _yellowCardsUCList = new List<GoalCardUC>();

        public RankingListUC(string fifaCode, string language, List<Match> matches, List<Player> players)
        {
            InitializeComponent();

            _fifaCode = fifaCode;
            _language = language;
            _matches = matches;
            _players = players;

            SetTextBasedOnLanguage();
            UpdatePlayerStatistics();

            printDocument.PrintPage += new PrintPageEventHandler(PrintUCs);
        }

        private void SetTextBasedOnLanguage()
        {
            label1.Text = _language switch
            {
                "en-US" => Resource_en_US.lbGoals,
                "hr-HR" => Resource_hr_HR.lbGoals,
                "de-DE" => Resource_de_DE.lbGoals,
                _ => Resource_en_US.lbGoals
            };

            label2.Text = _language switch
            {
                "en-US" => Resource_en_US.lbVisitors,
                "hr-HR" => Resource_hr_HR.lbVisitors,
                "de-DE" => Resource_de_DE.lbVisitors,
                _ => Resource_en_US.lbVisitors
            };

            label3.Text = _language switch
            {
                "en-US" => Resource_en_US.lbYellowCards, 
                "hr-HR" => Resource_hr_HR.lbYellowCards, 
                "de-DE" => Resource_de_DE.lbYellowCards, 
                _ => Resource_en_US.lbYellowCards
            };

            string printButtonText = _language switch
            {
                "en-US" => Resource_en_US.btnPrint, 
                "hr-HR" => Resource_hr_HR.btnPrint, 
                "de-DE" => Resource_de_DE.btnPrint, 
                _ => Resource_en_US.btnPrint 
            };

            btnPrintVisitors.Text = printButtonText;
            btnPrintGoals.Text = printButtonText;
            btnPrintYellowCards.Text = printButtonText;
        }

        private void UpdatePlayerStatistics()
        {
            foreach (var match in _matches)
            {
                UpdateTeamStatistics(match.HomeTeamEvents);
                UpdateTeamStatistics(match.AwayTeamEvents);
            }
        }

        private void UpdateTeamStatistics(List<TeamEvent> matchEvents)
        {
            foreach (var matchEvent in matchEvents)
            {
                if (matchEvent.TypeOfEvent.Equals("goal") || matchEvent.TypeOfEvent.Equals("yellow-card"))
                {
                    Player? player = _players.FirstOrDefault(p => p.Name.Equals(matchEvent.Player));
                    if (player != null)
                    {
                        switch (matchEvent.TypeOfEvent)
                        {
                            case "goal":
                                player.GoalsCount++;
                                break;
                            case "yellow-card":
                                player.YellowCardCount++;
                                break;
                            default:
                                MessageBox.Show($"Unknown event type {matchEvent.TypeOfEvent} encountered.", "Warning", MessageBoxButtons.OK);
                                break;
                        }
                    }
                }
            }
        }

        private void RankingListUC_Load(object sender, EventArgs e)
        {
            SetVisitorsPanel();
            SetGoalCardPanel(MatchEventType.Goal, pnlGoals, _goalsUCList);
            SetGoalCardPanel(MatchEventType.YellowCard, pnlYellowCards, _yellowCardsUCList);
        }

        private void SetVisitorsPanel()
        {
            List<Match> sortedMatches =
                _matches
                .Where(m => m.HomeTeam.Code == _fifaCode || m.AwayTeam.Code == _fifaCode)
                .OrderByDescending(m => m.Attendance)
                .ToList();

            int rankingNo = 1;
            foreach (var match in sortedMatches)
            {
                VisitorsUC visitorsUC = new VisitorsUC(match);

                Label? lbRankingNo = visitorsUC.Controls.Find("lbRankingNo", true).FirstOrDefault() as Label;
                lbRankingNo.Text = rankingNo.ToString();
                rankingNo++;

                pnlVisitors.Controls.Add(visitorsUC);
                _visitorsUCList.Add(visitorsUC);
            }
        }

        private void SetGoalCardPanel(MatchEventType matchEventType, FlowLayoutPanel panel, List<GoalCardUC> ucList)
        {
            var sortedPlayers = _players
                .OrderByDescending(p => matchEventType == MatchEventType.Goal ? p.GoalsCount : p.YellowCardCount)
                .ToList();

            var rankEntriesList = new List<RankEntry>();
            int currentRank = 1;
            RankEntry currentRankEntry = new RankEntry { Rank = currentRank };

            int lastScore = -1;

            foreach (var player in sortedPlayers)
            {
                int currentScore = matchEventType == MatchEventType.Goal ? player.GoalsCount : player.YellowCardCount;

                if (currentScore != lastScore)
                {
                    if (currentRankEntry.Players.Any()) // currentRankEntry has players
                    {
                        rankEntriesList.Add(currentRankEntry);
                    }

                    currentRankEntry = new RankEntry
                    {
                        Rank = currentRank,
                        Players = new List<Player> { player }
                    };
                    currentRank++;
                }
                else
                {
                    currentRankEntry.Players.Add(player);
                }
                lastScore = currentScore;
            }

            if (currentRankEntry.Players.Any())
            {
                rankEntriesList.Add(currentRankEntry);
            }

            // add controls to panel
            foreach (var rankEntry in rankEntriesList)
            {
                foreach (var player in rankEntry.Players)
                {
                    var goalCardUC = new GoalCardUC(matchEventType, player);
                    var lbRankingNo = goalCardUC.Controls.Find("lbRankingGoalsCards", true).FirstOrDefault() as Label;
                    if (lbRankingNo != null)
                    {
                        lbRankingNo.Text = rankEntry.Rank.ToString();
                    }

                    panel.Controls.Add(goalCardUC);
                    ucList.Add(goalCardUC);
                }
            }
        }

        // printing
        private void PrintUCs(object sender, PrintPageEventArgs e)
        {
            if (_currentUCListToPrint == null || !_currentUCListToPrint.Any())
            {
                MessageBox.Show("There is no content available to print.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int yPosition = e.MarginBounds.Top;
            int xPosition = e.MarginBounds.Left;

            while (_printIndex < _currentUCListToPrint.Count)
            {
                Control uc = _currentUCListToPrint[_printIndex];
                Bitmap bmp = new Bitmap(uc.Width, uc.Height);
                uc.DrawToBitmap(bmp, new Rectangle(0, 0, uc.Width, uc.Height));

                e.Graphics.DrawImage(bmp, xPosition, yPosition);

                yPosition += uc.Height + 10; 
                if (yPosition + uc.Height > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    _printIndex++;
                    return;
                }
                _printIndex++;
            }
            e.HasMorePages = false;
            _printIndex = 0;
        }

        private void btnPrintYellowCards_Click(object sender, EventArgs e)
        {
            _currentUCListToPrint = _yellowCardsUCList.Cast<Control>().ToList();
            _printIndex = 0;
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();
        }

        private void btnPrintGoals_Click(object sender, EventArgs e)
        {
            _currentUCListToPrint = _goalsUCList.Cast<Control>().ToList();
            _printIndex = 0;
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();
        }

        private void btnPrintVisitors_Click(object sender, EventArgs e)
        {
            _currentUCListToPrint = _visitorsUCList.Cast<Control>().ToList();
            _printIndex = 0;
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();
        }
    }
}
