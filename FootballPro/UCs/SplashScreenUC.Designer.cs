namespace FootballPro.UCs
{
    partial class SplashScreenUC
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreenUC));
            panel1 = new Panel();
            lbSC = new Label();
            pBrSC = new ProgressBar();
            pbPlayer = new PictureBox();
            timerSC = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPlayer).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.SeaGreen;
            panel1.Controls.Add(lbSC);
            panel1.Controls.Add(pBrSC);
            panel1.Controls.Add(pbPlayer);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1500, 800);
            panel1.TabIndex = 0;
            // 
            // lbSC
            // 
            lbSC.AutoSize = true;
            lbSC.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lbSC.ForeColor = SystemColors.ButtonHighlight;
            lbSC.Location = new Point(701, 671);
            lbSC.Name = "lbSC";
            lbSC.Size = new Size(0, 25);
            lbSC.TabIndex = 2;
            // 
            // pBrSC
            // 
            pBrSC.Location = new Point(32, 714);
            pBrSC.Name = "pBrSC";
            pBrSC.Size = new Size(1424, 23);
            pBrSC.TabIndex = 1;
            // 
            // pbPlayer
            // 
            pbPlayer.BackColor = Color.SeaGreen;
            pbPlayer.Image = (Image)resources.GetObject("pbPlayer.Image");
            pbPlayer.Location = new Point(327, 0);
            pbPlayer.Name = "pbPlayer";
            pbPlayer.Size = new Size(800, 668);
            pbPlayer.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPlayer.TabIndex = 0;
            pbPlayer.TabStop = false;
            // 
            // timerSC
            // 
            timerSC.Tick += TimerSC_Tick;
            // 
            // SplashScreenUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "SplashScreenUC";
            Size = new Size(1500, 800);
            Load += SplashScreenUC_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbPlayer).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pbPlayer;
        private ProgressBar pBrSC;
        private Label lbSC;
        private System.Windows.Forms.Timer timerSC;
    }
}
