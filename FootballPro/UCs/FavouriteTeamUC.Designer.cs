namespace FootballPro.UCs
{
    partial class FavouriteTeamUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FavouriteTeamUC));
            panel1 = new Panel();
            btnFavTeam = new Button();
            cbTeams = new ComboBox();
            label2 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.BackColor = SystemColors.WindowFrame;
            panel1.Controls.Add(btnFavTeam);
            panel1.Controls.Add(cbTeams);
            panel1.Controls.Add(label2);
            panel1.Name = "panel1";
            // 
            // btnFavTeam
            // 
            btnFavTeam.BackColor = Color.Teal;
            resources.ApplyResources(btnFavTeam, "btnFavTeam");
            btnFavTeam.ForeColor = SystemColors.ButtonHighlight;
            btnFavTeam.Name = "btnFavTeam";
            btnFavTeam.UseVisualStyleBackColor = false;
            btnFavTeam.Click += btnFavTeam_Click;
            // 
            // cbTeams
            // 
            cbTeams.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTeams.FormattingEnabled = true;
            resources.ApplyResources(cbTeams, "cbTeams");
            cbTeams.Name = "cbTeams";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Name = "label2";
            // 
            // FavouriteTeamUC
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "FavouriteTeamUC";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnFavTeam;
        private ComboBox cbTeams;
        private Label label2;
    }
}
