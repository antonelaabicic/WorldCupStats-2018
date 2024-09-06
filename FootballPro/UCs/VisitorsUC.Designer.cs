namespace FootballPro.UCs
{
    partial class VisitorsUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisitorsUC));
            pictureBox1 = new PictureBox();
            lbTeamVsTeam = new Label();
            lbVenue = new Label();
            lbLocation = new Label();
            lbRankingNo = new Label();
            pictureBox2 = new PictureBox();
            lbNoVisitors = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(17, 53);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(47, 48);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lbTeamVsTeam
            // 
            lbTeamVsTeam.AutoSize = true;
            lbTeamVsTeam.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lbTeamVsTeam.ForeColor = SystemColors.ButtonHighlight;
            lbTeamVsTeam.Location = new Point(17, 15);
            lbTeamVsTeam.Name = "lbTeamVsTeam";
            lbTeamVsTeam.Size = new Size(107, 20);
            lbTeamVsTeam.TabIndex = 1;
            lbTeamVsTeam.Text = "Team1 : Team2";
            // 
            // lbVenue
            // 
            lbVenue.AutoSize = true;
            lbVenue.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lbVenue.ForeColor = SystemColors.ButtonHighlight;
            lbVenue.Location = new Point(60, 53);
            lbVenue.Name = "lbVenue";
            lbVenue.Size = new Size(45, 17);
            lbVenue.TabIndex = 6;
            lbVenue.Text = "Venue";
            // 
            // lbLocation
            // 
            lbLocation.AutoSize = true;
            lbLocation.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lbLocation.ForeColor = SystemColors.ButtonHighlight;
            lbLocation.Location = new Point(60, 84);
            lbLocation.Name = "lbLocation";
            lbLocation.Size = new Size(59, 17);
            lbLocation.TabIndex = 7;
            lbLocation.Text = "Location";
            // 
            // lbRankingNo
            // 
            lbRankingNo.AutoSize = true;
            lbRankingNo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lbRankingNo.ForeColor = Color.PaleGoldenrod;
            lbRankingNo.Location = new Point(301, 5);
            lbRankingNo.Name = "lbRankingNo";
            lbRankingNo.Size = new Size(28, 32);
            lbRankingNo.TabIndex = 8;
            lbRankingNo.Text = "8";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(225, 53);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(53, 48);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // lbNoVisitors
            // 
            lbNoVisitors.AutoSize = true;
            lbNoVisitors.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lbNoVisitors.ForeColor = SystemColors.ButtonHighlight;
            lbNoVisitors.Location = new Point(284, 69);
            lbNoVisitors.Name = "lbNoVisitors";
            lbNoVisitors.Size = new Size(57, 17);
            lbNoVisitors.TabIndex = 10;
            lbNoVisitors.Text = "5464464";
            // 
            // VisitorsUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Teal;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(lbNoVisitors);
            Controls.Add(pictureBox2);
            Controls.Add(lbRankingNo);
            Controls.Add(lbLocation);
            Controls.Add(lbVenue);
            Controls.Add(lbTeamVsTeam);
            Controls.Add(pictureBox1);
            Name = "VisitorsUC";
            Size = new Size(338, 121);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lbTeamVsTeam;
        private Label lbVenue;
        private Label lbLocation;
        private Label lbRankingNo;
        private PictureBox pictureBox2;
        private Label lbNoVisitors;
    }
}
