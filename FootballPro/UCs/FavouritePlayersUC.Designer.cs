namespace FootballPro.UCs
{
    partial class FavouritePlayersUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FavouritePlayersUC));
            pnlPlayers = new FlowLayoutPanel();
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            label2 = new Label();
            pnlFavPlayers = new FlowLayoutPanel();
            pbLeftArrow = new PictureBox();
            pbRightArrow = new PictureBox();
            btnSaveFavPlayers = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLeftArrow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbRightArrow).BeginInit();
            SuspendLayout();
            // 
            // pnlPlayers
            // 
            pnlPlayers.AllowDrop = true;
            resources.ApplyResources(pnlPlayers, "pnlPlayers");
            pnlPlayers.Name = "pnlPlayers";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.WindowFrame;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pnlPlayers);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Name = "label1";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.WindowFrame;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(pnlFavPlayers);
            resources.ApplyResources(panel2, "panel2");
            panel2.Name = "panel2";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Name = "label2";
            // 
            // pnlFavPlayers
            // 
            pnlFavPlayers.AllowDrop = true;
            resources.ApplyResources(pnlFavPlayers, "pnlFavPlayers");
            pnlFavPlayers.Name = "pnlFavPlayers";
            // 
            // pbLeftArrow
            // 
            pbLeftArrow.BackColor = Color.Transparent;
            resources.ApplyResources(pbLeftArrow, "pbLeftArrow");
            pbLeftArrow.Name = "pbLeftArrow";
            pbLeftArrow.TabStop = false;
            pbLeftArrow.Click += pbLeftArrow_Click;
            // 
            // pbRightArrow
            // 
            pbRightArrow.BackColor = Color.Transparent;
            resources.ApplyResources(pbRightArrow, "pbRightArrow");
            pbRightArrow.Name = "pbRightArrow";
            pbRightArrow.TabStop = false;
            pbRightArrow.Click += pbRightArrow_Click;
            // 
            // btnSaveFavPlayers
            // 
            btnSaveFavPlayers.BackColor = Color.Maroon;
            resources.ApplyResources(btnSaveFavPlayers, "btnSaveFavPlayers");
            btnSaveFavPlayers.ForeColor = SystemColors.ButtonHighlight;
            btnSaveFavPlayers.Name = "btnSaveFavPlayers";
            btnSaveFavPlayers.UseVisualStyleBackColor = false;
            btnSaveFavPlayers.Click += BtnFavPlayersSaved_Click;
            // 
            // FavouritePlayersUC
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnSaveFavPlayers);
            Controls.Add(pbRightArrow);
            Controls.Add(pbLeftArrow);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "FavouritePlayersUC";
            Load += FavouritePlayersUC_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLeftArrow).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbRightArrow).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel pnlPlayers;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Label label2;
        private FlowLayoutPanel pnlFavPlayers;
        private PictureBox pbLeftArrow;
        private PictureBox pbRightArrow;
        private Button btnSaveFavPlayers;
    }
}
