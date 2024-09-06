namespace FootballPro.UCs
{
    partial class RankingListUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RankingListUC));
            btnPrintVisitors = new Button();
            panel2 = new Panel();
            label2 = new Label();
            pnlVisitors = new FlowLayoutPanel();
            btnPrintGoals = new Button();
            panel1 = new Panel();
            label1 = new Label();
            pnlGoals = new FlowLayoutPanel();
            btnPrintYellowCards = new Button();
            panel3 = new Panel();
            label3 = new Label();
            pnlYellowCards = new FlowLayoutPanel();
            printDocument = new System.Drawing.Printing.PrintDocument();
            printPreviewDialog = new PrintPreviewDialog();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // btnPrintVisitors
            // 
            btnPrintVisitors.BackColor = Color.Maroon;
            resources.ApplyResources(btnPrintVisitors, "btnPrintVisitors");
            btnPrintVisitors.ForeColor = SystemColors.ButtonHighlight;
            btnPrintVisitors.Name = "btnPrintVisitors";
            btnPrintVisitors.UseVisualStyleBackColor = false;
            btnPrintVisitors.Click += btnPrintVisitors_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.WindowFrame;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(pnlVisitors);
            resources.ApplyResources(panel2, "panel2");
            panel2.Name = "panel2";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Name = "label2";
            // 
            // pnlVisitors
            // 
            pnlVisitors.AllowDrop = true;
            resources.ApplyResources(pnlVisitors, "pnlVisitors");
            pnlVisitors.Name = "pnlVisitors";
            // 
            // btnPrintGoals
            // 
            btnPrintGoals.BackColor = Color.Maroon;
            resources.ApplyResources(btnPrintGoals, "btnPrintGoals");
            btnPrintGoals.ForeColor = SystemColors.ButtonHighlight;
            btnPrintGoals.Name = "btnPrintGoals";
            btnPrintGoals.UseVisualStyleBackColor = false;
            btnPrintGoals.Click += btnPrintGoals_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.WindowFrame;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pnlGoals);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Name = "label1";
            // 
            // pnlGoals
            // 
            pnlGoals.AllowDrop = true;
            resources.ApplyResources(pnlGoals, "pnlGoals");
            pnlGoals.Name = "pnlGoals";
            // 
            // btnPrintYellowCards
            // 
            btnPrintYellowCards.BackColor = Color.Maroon;
            resources.ApplyResources(btnPrintYellowCards, "btnPrintYellowCards");
            btnPrintYellowCards.ForeColor = SystemColors.ButtonHighlight;
            btnPrintYellowCards.Name = "btnPrintYellowCards";
            btnPrintYellowCards.UseVisualStyleBackColor = false;
            btnPrintYellowCards.Click += btnPrintYellowCards_Click;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.WindowFrame;
            panel3.Controls.Add(label3);
            panel3.Controls.Add(pnlYellowCards);
            resources.ApplyResources(panel3, "panel3");
            panel3.Name = "panel3";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Name = "label3";
            // 
            // pnlYellowCards
            // 
            pnlYellowCards.AllowDrop = true;
            resources.ApplyResources(pnlYellowCards, "pnlYellowCards");
            pnlYellowCards.Name = "pnlYellowCards";
            // 
            // printPreviewDialog
            // 
            resources.ApplyResources(printPreviewDialog, "printPreviewDialog");
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.Name = "printPreviewDialog";
            // 
            // RankingListUC
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnPrintYellowCards);
            Controls.Add(panel3);
            Controls.Add(btnPrintGoals);
            Controls.Add(panel1);
            Controls.Add(btnPrintVisitors);
            Controls.Add(panel2);
            Name = "RankingListUC";
            Load += RankingListUC_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnPrintVisitors;
        private Panel panel2;
        private Label label2;
        private FlowLayoutPanel pnlVisitors;
        private Button btnPrintGoals;
        private Panel panel1;
        private Label label1;
        private FlowLayoutPanel pnlGoals;
        private Button btnPrintYellowCards;
        private Panel panel3;
        private Label label3;
        private FlowLayoutPanel pnlYellowCards;
        private System.Drawing.Printing.PrintDocument printDocument;
        private PrintPreviewDialog printPreviewDialog;
    }
}
