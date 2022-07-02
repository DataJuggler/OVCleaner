namespace OVCleaner
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.OVFolderControl = new DataJuggler.Win.Controls.LabelTextBoxBrowserControl();
            this.CleanButton = new DataJuggler.Win.Controls.Button();
            this.Graph = new System.Windows.Forms.ProgressBar();
            this.AppsCheckBox = new System.Windows.Forms.CheckedListBox();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.AppsLabel = new System.Windows.Forms.Label();
            this.DiscoverButton = new DataJuggler.Win.Controls.Button();
            this.ReclaimStatus = new DataJuggler.Win.Controls.LabelLabelControl();
            this.InfoLabel2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OVFolderControl
            // 
            this.OVFolderControl.BackColor = System.Drawing.Color.Transparent;
            this.OVFolderControl.BrowseType = DataJuggler.Win.Controls.Enumerations.BrowseTypeEnum.Folder;
            this.OVFolderControl.ButtonColor = System.Drawing.Color.LemonChiffon;
            this.OVFolderControl.ButtonImage = ((System.Drawing.Image)(resources.GetObject("OVFolderControl.ButtonImage")));
            this.OVFolderControl.ButtonWidth = 48;
            this.OVFolderControl.DarkMode = false;
            this.OVFolderControl.DisabledLabelColor = System.Drawing.Color.Empty;
            this.OVFolderControl.Editable = true;
            this.OVFolderControl.EnabledLabelColor = System.Drawing.Color.Empty;
            this.OVFolderControl.Filter = null;
            this.OVFolderControl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OVFolderControl.HideBrowseButton = false;
            this.OVFolderControl.LabelBottomMargin = 0;
            this.OVFolderControl.LabelColor = System.Drawing.Color.LemonChiffon;
            this.OVFolderControl.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.OVFolderControl.LabelText = "OV Folder:";
            this.OVFolderControl.LabelTopMargin = 0;
            this.OVFolderControl.LabelWidth = 120;
            this.OVFolderControl.Location = new System.Drawing.Point(43, 74);
            this.OVFolderControl.Name = "OVFolderControl";
            this.OVFolderControl.OnTextChangedListener = null;
            this.OVFolderControl.OpenCallback = null;
            this.OVFolderControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.OVFolderControl.SelectedPath = null;
            this.OVFolderControl.Size = new System.Drawing.Size(913, 32);
            this.OVFolderControl.StartPath = null;
            this.OVFolderControl.TabIndex = 0;
            this.OVFolderControl.TextBoxBottomMargin = 0;
            this.OVFolderControl.TextBoxDisabledColor = System.Drawing.Color.Empty;
            this.OVFolderControl.TextBoxEditableColor = System.Drawing.Color.Empty;
            this.OVFolderControl.TextBoxFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OVFolderControl.TextBoxTopMargin = 0;
            this.OVFolderControl.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // CleanButton
            // 
            this.CleanButton.BackColor = System.Drawing.Color.Transparent;
            this.CleanButton.ButtonText = "Clean";
            this.CleanButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CleanButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CleanButton.ForeColor = System.Drawing.Color.Black;
            this.CleanButton.Location = new System.Drawing.Point(836, 113);
            this.CleanButton.Margin = new System.Windows.Forms.Padding(4);
            this.CleanButton.Name = "CleanButton";
            this.CleanButton.Size = new System.Drawing.Size(120, 44);
            this.CleanButton.TabIndex = 1;
            this.CleanButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Wood;
            this.CleanButton.Click += new System.EventHandler(this.CleanButton_Click);
            // 
            // Graph
            // 
            this.Graph.Location = new System.Drawing.Point(43, 551);
            this.Graph.Name = "Graph";
            this.Graph.Size = new System.Drawing.Size(947, 23);
            this.Graph.TabIndex = 2;
            this.Graph.Visible = false;
            // 
            // AppsCheckBox
            // 
            this.AppsCheckBox.FormattingEnabled = true;
            this.AppsCheckBox.Location = new System.Drawing.Point(43, 158);
            this.AppsCheckBox.Name = "AppsCheckBox";
            this.AppsCheckBox.Size = new System.Drawing.Size(575, 334);
            this.AppsCheckBox.TabIndex = 3;
            // 
            // InfoLabel
            // 
            this.InfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.InfoLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.InfoLabel.Location = new System.Drawing.Point(43, 23);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(903, 36);
            this.InfoLabel.TabIndex = 4;
            this.InfoLabel.Text = "OV Cleaner determined this should be your ov folder. If this is not correct, sele" +
    "ct the ov folder in your users account app data\\local folder.";
            // 
            // AppsLabel
            // 
            this.AppsLabel.BackColor = System.Drawing.Color.Transparent;
            this.AppsLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.AppsLabel.Location = new System.Drawing.Point(43, 132);
            this.AppsLabel.Name = "AppsLabel";
            this.AppsLabel.Size = new System.Drawing.Size(140, 20);
            this.AppsLabel.TabIndex = 5;
            this.AppsLabel.Text = "Installed Apps:";
            // 
            // DiscoverButton
            // 
            this.DiscoverButton.BackColor = System.Drawing.Color.Transparent;
            this.DiscoverButton.ButtonText = "Discover";
            this.DiscoverButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DiscoverButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DiscoverButton.ForeColor = System.Drawing.Color.Black;
            this.DiscoverButton.Location = new System.Drawing.Point(700, 113);
            this.DiscoverButton.Margin = new System.Windows.Forms.Padding(4);
            this.DiscoverButton.Name = "DiscoverButton";
            this.DiscoverButton.Size = new System.Drawing.Size(128, 44);
            this.DiscoverButton.TabIndex = 6;
            this.DiscoverButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Wood;
            this.DiscoverButton.Click += new System.EventHandler(this.DiscoverButton_Click);
            // 
            // ReclaimStatus
            // 
            this.ReclaimStatus.BackColor = System.Drawing.Color.Transparent;
            this.ReclaimStatus.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ReclaimStatus.ForeColor = System.Drawing.Color.LemonChiffon;
            this.ReclaimStatus.LabelColor = System.Drawing.Color.LemonChiffon;
            this.ReclaimStatus.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ReclaimStatus.LabelText = "* Reclaim:";
            this.ReclaimStatus.LabelWidth = 112;
            this.ReclaimStatus.Location = new System.Drawing.Point(627, 166);
            this.ReclaimStatus.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ReclaimStatus.Name = "ReclaimStatus";
            this.ReclaimStatus.Size = new System.Drawing.Size(373, 28);
            this.ReclaimStatus.TabIndex = 7;
            this.ReclaimStatus.ValueLabelColor = System.Drawing.Color.LemonChiffon;
            this.ReclaimStatus.ValueLabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            // 
            // InfoLabel2
            // 
            this.InfoLabel2.BackColor = System.Drawing.Color.Transparent;
            this.InfoLabel2.ForeColor = System.Drawing.Color.LemonChiffon;
            this.InfoLabel2.Location = new System.Drawing.Point(641, 215);
            this.InfoLabel2.Name = "InfoLabel2";
            this.InfoLabel2.Size = new System.Drawing.Size(305, 67);
            this.InfoLabel2.TabIndex = 8;
            this.InfoLabel2.Text = "* This number is an estimate. The actual number is probably a little higher.\r\n";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::OVCleaner.Properties.Resources.BlackImage;
            this.ClientSize = new System.Drawing.Size(1015, 598);
            this.Controls.Add(this.InfoLabel2);
            this.Controls.Add(this.ReclaimStatus);
            this.Controls.Add(this.DiscoverButton);
            this.Controls.Add(this.AppsLabel);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.AppsCheckBox);
            this.Controls.Add(this.Graph);
            this.Controls.Add(this.CleanButton);
            this.Controls.Add(this.OVFolderControl);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OV Cleaner 1.0.0";
            this.ResumeLayout(false);

        }

        #endregion

        private DataJuggler.Win.Controls.LabelTextBoxBrowserControl OVFolderControl;
        private DataJuggler.Win.Controls.Button CleanButton;
        private ProgressBar Graph;
        private CheckedListBox AppsCheckBox;
        private Label InfoLabel;
        private Label AppsLabel;
        private DataJuggler.Win.Controls.Button DiscoverButton;
        private LabelLabelControl ReclaimStatus;
        private Label InfoLabel2;
    }
}