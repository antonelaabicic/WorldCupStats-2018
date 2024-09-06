namespace FootballPro.UCs
{
    partial class GoalCardUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbRankingGoalsCards = new Label();
            lbPlayerName = new Label();
            pbPlayer = new PictureBox();
            pbGoalCard = new PictureBox();
            lbNoGoalsCards = new Label();
            ((System.ComponentModel.ISupportInitialize)pbPlayer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbGoalCard).BeginInit();
            SuspendLayout();
            // 
            // lbRankingGoalsCards
            // 
            lbRankingGoalsCards.AutoSize = true;
            lbRankingGoalsCards.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lbRankingGoalsCards.ForeColor = Color.PaleGoldenrod;
            lbRankingGoalsCards.Location = new Point(300, 15);
            lbRankingGoalsCards.Name = "lbRankingGoalsCards";
            lbRankingGoalsCards.Size = new Size(42, 32);
            lbRankingGoalsCards.TabIndex = 9;
            lbRankingGoalsCards.Text = "12";
            // 
            // lbPlayerName
            // 
            lbPlayerName.AutoSize = true;
            lbPlayerName.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lbPlayerName.ForeColor = SystemColors.ButtonHighlight;
            lbPlayerName.Location = new Point(102, 25);
            lbPlayerName.Name = "lbPlayerName";
            lbPlayerName.Size = new Size(143, 20);
            lbPlayerName.TabIndex = 10;
            lbPlayerName.Text = "Name and surname";
            // 
            // pbPlayer
            // 
            pbPlayer.Location = new Point(17, 25);
            pbPlayer.Name = "pbPlayer";
            pbPlayer.Size = new Size(79, 84);
            pbPlayer.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPlayer.TabIndex = 11;
            pbPlayer.TabStop = false;
            // 
            // pbGoalCard
            // 
            pbGoalCard.Location = new Point(135, 59);
            pbGoalCard.Name = "pbGoalCard";
            pbGoalCard.Size = new Size(51, 50);
            pbGoalCard.SizeMode = PictureBoxSizeMode.StretchImage;
            pbGoalCard.TabIndex = 12;
            pbGoalCard.TabStop = false;
            // 
            // lbNoGoalsCards
            // 
            lbNoGoalsCards.AutoSize = true;
            lbNoGoalsCards.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lbNoGoalsCards.ForeColor = SystemColors.ButtonHighlight;
            lbNoGoalsCards.Location = new Point(192, 76);
            lbNoGoalsCards.Name = "lbNoGoalsCards";
            lbNoGoalsCards.Size = new Size(20, 17);
            lbNoGoalsCards.TabIndex = 13;
            lbNoGoalsCards.Text = "12";
            // 
            // GoalCardUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumPurple;
            Controls.Add(lbNoGoalsCards);
            Controls.Add(pbGoalCard);
            Controls.Add(pbPlayer);
            Controls.Add(lbPlayerName);
            Controls.Add(lbRankingGoalsCards);
            Name = "GoalCardUC";
            Size = new Size(342, 135);
            ((System.ComponentModel.ISupportInitialize)pbPlayer).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbGoalCard).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbRankingGoalsCards;
        private Label lbPlayerName;
        private PictureBox pbPlayer;
        private PictureBox pbGoalCard;
        private Label lbNoGoalsCards;
    }
}
