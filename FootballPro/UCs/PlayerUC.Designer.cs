namespace FootballPro.UCs
{
    partial class PlayerUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerUC));
            pbPlayer = new PictureBox();
            lbPlayerName = new Label();
            pbCaptain = new PictureBox();
            pbStar = new PictureBox();
            btnAddPicture = new Button();
            lbPosition = new Label();
            pictureBox1 = new PictureBox();
            lbShirtNumber = new Label();
            ((System.ComponentModel.ISupportInitialize)pbPlayer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCaptain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbStar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pbPlayer
            // 
            resources.ApplyResources(pbPlayer, "pbPlayer");
            pbPlayer.Name = "pbPlayer";
            pbPlayer.TabStop = false;
            // 
            // lbPlayerName
            // 
            resources.ApplyResources(lbPlayerName, "lbPlayerName");
            lbPlayerName.ForeColor = SystemColors.ButtonHighlight;
            lbPlayerName.Name = "lbPlayerName";
            // 
            // pbCaptain
            // 
            resources.ApplyResources(pbCaptain, "pbCaptain");
            pbCaptain.Name = "pbCaptain";
            pbCaptain.TabStop = false;
            // 
            // pbStar
            // 
            resources.ApplyResources(pbStar, "pbStar");
            pbStar.Name = "pbStar";
            pbStar.TabStop = false;
            // 
            // btnAddPicture
            // 
            resources.ApplyResources(btnAddPicture, "btnAddPicture");
            btnAddPicture.BackColor = Color.Maroon;
            btnAddPicture.ForeColor = SystemColors.ButtonHighlight;
            btnAddPicture.Name = "btnAddPicture";
            btnAddPicture.UseVisualStyleBackColor = false;
            btnAddPicture.Click += btnAddPicture_Click;
            // 
            // lbPosition
            // 
            resources.ApplyResources(lbPosition, "lbPosition");
            lbPosition.ForeColor = SystemColors.ButtonHighlight;
            lbPosition.Name = "lbPosition";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            // 
            // lbShirtNumber
            // 
            resources.ApplyResources(lbShirtNumber, "lbShirtNumber");
            lbShirtNumber.ForeColor = SystemColors.ButtonHighlight;
            lbShirtNumber.Name = "lbShirtNumber";
            // 
            // PlayerUC
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(lbShirtNumber);
            Controls.Add(pictureBox1);
            Controls.Add(lbPosition);
            Controls.Add(btnAddPicture);
            Controls.Add(pbStar);
            Controls.Add(pbCaptain);
            Controls.Add(lbPlayerName);
            Controls.Add(pbPlayer);
            Name = "PlayerUC";
            ((System.ComponentModel.ISupportInitialize)pbPlayer).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCaptain).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbStar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbPlayer;
        private Label lbPlayerName;
        private PictureBox pbCaptain;
        private PictureBox pbStar;
        private Button btnAddPicture;
        private Label lbPosition;
        private PictureBox pictureBox1;
        private Label lbShirtNumber;
    }
}
