//
// Main website for TVRename is http://tvrename.com
//
// Source code available at http://code.google.com/p/tvrename/
//
// This code is released under GPLv3 http://www.gnu.org/licenses/gpl.html
//


using System;
using System.ComponentModel;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Drawing;


namespace TVRename
{

	/// <summary>
	/// Summary for Preferences
	///
	/// WARNING: If you change the name of this class, you will need to change the
	///          'Resource File Name' property for the managed resource compiler tool
	///          associated with all .resx files this class depends on.  Otherwise,
	///          the designers will not be able to interact properly with localized
	///          resources associated with this form.
	/// </summary>
	public class Preferences : System.Windows.Forms.Form
	{
		private TVDoc mDoc;
	private System.Windows.Forms.TabPage tpScanOptions;
	private System.Windows.Forms.CheckBox cbSearchRSS;
	private System.Windows.Forms.CheckBox cbEpImgs;
	private System.Windows.Forms.CheckBox cbNFOs;
	private System.Windows.Forms.CheckBox cbFolderJpg;
	private System.Windows.Forms.CheckBox cbRenameCheck;
	private System.Windows.Forms.CheckBox cbMissing;
	private System.Windows.Forms.CheckBox cbLeaveOriginals;
	private System.Windows.Forms.CheckBox cbSearchLocally;
	private System.Windows.Forms.Label label28;
	private SourceGrid.Grid ReplacementsGrid;
	private System.Windows.Forms.Button bnReplaceRemove;
	private System.Windows.Forms.Button bnReplaceAdd;
	private System.Windows.Forms.Label label3;
	private System.Windows.Forms.CheckBox cbCheckuTorrent;
	private System.Windows.Forms.CheckBox cbAutoSelInMyShows;
	private System.Windows.Forms.RadioButton rbFolderFanArt;
	private System.Windows.Forms.RadioButton rbFolderPoster;
	private System.Windows.Forms.RadioButton rbFolderBanner;
    private System.Collections.Generic.List<string> LangList;

		public Preferences(TVDoc doc, bool goToScanOpts)
		{
			LangList = null;

			InitializeComponent();

			SetupRSSGrid();
			SetupReplacementsGrid();

			mDoc = doc;

			if (goToScanOpts)
				tabControl1.SelectedTab = tpScanOptions;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
	private System.Windows.Forms.Button OKButton;
	private System.Windows.Forms.Button bnCancel;

































	private System.Windows.Forms.GroupBox groupBox2;
	private System.Windows.Forms.Button bnBrowseWTWRSS;
	private System.Windows.Forms.TextBox txtWTWRSS;







	private System.Windows.Forms.CheckBox cbWTWRSS;
	private System.Windows.Forms.SaveFileDialog saveFile;

	private System.Windows.Forms.TextBox txtWTWDays;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.ComboBox cbStartupTab;
	private System.Windows.Forms.Label label6;



	private System.Windows.Forms.CheckBox cbNotificationIcon;
	private System.Windows.Forms.TextBox txtVideoExtensions;
	private System.Windows.Forms.Label label14;
	private System.Windows.Forms.Label label16;
	private System.Windows.Forms.Label label15;
	private System.Windows.Forms.TextBox txtExportRSSMaxDays;

	private System.Windows.Forms.TextBox txtExportRSSMaxShows;
	private System.Windows.Forms.Label label17;
	private System.Windows.Forms.CheckBox cbKeepTogether;
	private System.Windows.Forms.CheckBox cbLeadingZero;
	private System.Windows.Forms.CheckBox chkShowInTaskbar;
	private System.Windows.Forms.CheckBox cbTxtToSub;
	private System.Windows.Forms.CheckBox cbShowEpisodePictures;
	private System.Windows.Forms.TextBox txtSpecialsFolderName;
	private System.Windows.Forms.Label label13;
	private System.Windows.Forms.TabControl tabControl1;
	private System.Windows.Forms.TabPage tabPage1;
	private System.Windows.Forms.TabPage tabPage2;
	private System.Windows.Forms.TabPage tabPage3;
	private System.Windows.Forms.GroupBox groupBox3;
	private System.Windows.Forms.GroupBox groupBox5;
	private System.Windows.Forms.GroupBox groupBox4;
	private System.Windows.Forms.Button bnBrowseMissingCSV;
	private System.Windows.Forms.CheckBox cbMissingCSV;
	private System.Windows.Forms.TextBox txtMissingCSV;
	private System.Windows.Forms.Button bnBrowseMissingXML;
	private System.Windows.Forms.CheckBox cbMissingXML;
	private System.Windows.Forms.TextBox txtMissingXML;
	private System.Windows.Forms.Button bnBrowseFOXML;

	private System.Windows.Forms.CheckBox cbFOXML;
	private System.Windows.Forms.TextBox txtFOXML;


	private System.Windows.Forms.Button bnBrowseRenamingXML;
	private System.Windows.Forms.CheckBox cbRenamingXML;
	private System.Windows.Forms.TextBox txtRenamingXML;
	private System.Windows.Forms.CheckBox cbIgnoreSamples;


	private System.Windows.Forms.CheckBox cbForceLower;
	private System.Windows.Forms.Label label19;
	private System.Windows.Forms.TextBox txtMaxSampleSize;
	private System.Windows.Forms.Label label21;
	private System.Windows.Forms.Label label20;
	private System.Windows.Forms.TextBox txtParallelDownloads;
	private System.Windows.Forms.Label label22;
	private System.Windows.Forms.TextBox txtOtherExtensions;
	private System.Windows.Forms.TabPage tabPage4;
	private System.Windows.Forms.Button bnOpenSearchFolder;
	private System.Windows.Forms.Button bnRemoveSearchFolder;
	private System.Windows.Forms.Button bnAddSearchFolder;
	private System.Windows.Forms.ListBox lbSearchFolders;
	private System.Windows.Forms.Label label23;
	private System.Windows.Forms.FolderBrowserDialog folderBrowser;
	private System.Windows.Forms.TabPage tabPage5;
	private System.Windows.Forms.Button bnRSSBrowseuTorrent;
	private System.Windows.Forms.Button bnRSSGo;
	private System.Windows.Forms.TextBox txtRSSuTorrentPath;


	private System.Windows.Forms.Label label25;
	private SourceGrid.Grid RSSGrid;

	private System.Windows.Forms.Button bnRSSRemove;
	private System.Windows.Forms.Button bnRSSAdd;
	private System.Windows.Forms.OpenFileDialog openFile;
	private System.Windows.Forms.GroupBox groupBox6;
	private System.Windows.Forms.Button bnUTBrowseResumeDat;
	private System.Windows.Forms.TextBox txtUTResumeDatPath;
	private System.Windows.Forms.Label label27;
	private System.Windows.Forms.Label label26;
	private System.Windows.Forms.TabPage tabPage6;

	private System.Windows.Forms.Button bnLangDown;
	private System.Windows.Forms.Button bnLangUp;

	private System.Windows.Forms.ListBox lbLangs;
	private System.Windows.Forms.Label label24;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components;

#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = (new System.ComponentModel.ComponentResourceManager(typeof(Preferences)));
			this.OKButton = (new System.Windows.Forms.Button());
			this.bnCancel = (new System.Windows.Forms.Button());
			this.ReplacementsGrid = (new SourceGrid.Grid());
			this.groupBox2 = (new System.Windows.Forms.GroupBox());
			this.bnBrowseWTWRSS = (new System.Windows.Forms.Button());
			this.txtWTWRSS = (new System.Windows.Forms.TextBox());
			this.cbWTWRSS = (new System.Windows.Forms.CheckBox());
			this.label17 = (new System.Windows.Forms.Label());
			this.label16 = (new System.Windows.Forms.Label());
			this.label15 = (new System.Windows.Forms.Label());
			this.txtExportRSSMaxDays = (new System.Windows.Forms.TextBox());
			this.txtExportRSSMaxShows = (new System.Windows.Forms.TextBox());
			this.saveFile = (new System.Windows.Forms.SaveFileDialog());
			this.cbTxtToSub = (new System.Windows.Forms.CheckBox());
			this.txtSpecialsFolderName = (new System.Windows.Forms.TextBox());
			this.txtVideoExtensions = (new System.Windows.Forms.TextBox());
			this.cbStartupTab = (new System.Windows.Forms.ComboBox());
			this.cbShowEpisodePictures = (new System.Windows.Forms.CheckBox());
			this.cbLeadingZero = (new System.Windows.Forms.CheckBox());
			this.cbKeepTogether = (new System.Windows.Forms.CheckBox());
			this.chkShowInTaskbar = (new System.Windows.Forms.CheckBox());
			this.cbNotificationIcon = (new System.Windows.Forms.CheckBox());
			this.txtWTWDays = (new System.Windows.Forms.TextBox());
			this.label2 = (new System.Windows.Forms.Label());
			this.label13 = (new System.Windows.Forms.Label());
			this.label14 = (new System.Windows.Forms.Label());
			this.label6 = (new System.Windows.Forms.Label());
			this.label1 = (new System.Windows.Forms.Label());
			this.tabControl1 = (new System.Windows.Forms.TabControl());
			this.tabPage1 = (new System.Windows.Forms.TabPage());
			this.label21 = (new System.Windows.Forms.Label());
			this.cbAutoSelInMyShows = (new System.Windows.Forms.CheckBox());
			this.label20 = (new System.Windows.Forms.Label());
			this.txtParallelDownloads = (new System.Windows.Forms.TextBox());
			this.tabPage2 = (new System.Windows.Forms.TabPage());
			this.bnReplaceRemove = (new System.Windows.Forms.Button());
			this.bnReplaceAdd = (new System.Windows.Forms.Button());
			this.label3 = (new System.Windows.Forms.Label());
			this.label19 = (new System.Windows.Forms.Label());
			this.txtMaxSampleSize = (new System.Windows.Forms.TextBox());
			this.label22 = (new System.Windows.Forms.Label());
			this.txtOtherExtensions = (new System.Windows.Forms.TextBox());
			this.cbForceLower = (new System.Windows.Forms.CheckBox());
			this.cbIgnoreSamples = (new System.Windows.Forms.CheckBox());
			this.tabPage3 = (new System.Windows.Forms.TabPage());
			this.groupBox5 = (new System.Windows.Forms.GroupBox());
			this.bnBrowseFOXML = (new System.Windows.Forms.Button());
			this.cbFOXML = (new System.Windows.Forms.CheckBox());
			this.txtFOXML = (new System.Windows.Forms.TextBox());
			this.groupBox4 = (new System.Windows.Forms.GroupBox());
			this.bnBrowseRenamingXML = (new System.Windows.Forms.Button());
			this.cbRenamingXML = (new System.Windows.Forms.CheckBox());
			this.txtRenamingXML = (new System.Windows.Forms.TextBox());
			this.groupBox3 = (new System.Windows.Forms.GroupBox());
			this.bnBrowseMissingXML = (new System.Windows.Forms.Button());
			this.cbMissingXML = (new System.Windows.Forms.CheckBox());
			this.bnBrowseMissingCSV = (new System.Windows.Forms.Button());
			this.txtMissingXML = (new System.Windows.Forms.TextBox());
			this.cbMissingCSV = (new System.Windows.Forms.CheckBox());
			this.txtMissingCSV = (new System.Windows.Forms.TextBox());
			this.tabPage4 = (new System.Windows.Forms.TabPage());
			this.bnOpenSearchFolder = (new System.Windows.Forms.Button());
			this.bnRemoveSearchFolder = (new System.Windows.Forms.Button());
			this.bnAddSearchFolder = (new System.Windows.Forms.Button());
			this.lbSearchFolders = (new System.Windows.Forms.ListBox());
			this.label23 = (new System.Windows.Forms.Label());
			this.tpScanOptions = (new System.Windows.Forms.TabPage());
			this.label28 = (new System.Windows.Forms.Label());
			this.cbSearchRSS = (new System.Windows.Forms.CheckBox());
			this.cbEpImgs = (new System.Windows.Forms.CheckBox());
			this.cbNFOs = (new System.Windows.Forms.CheckBox());
			this.cbFolderJpg = (new System.Windows.Forms.CheckBox());
			this.cbRenameCheck = (new System.Windows.Forms.CheckBox());
			this.cbMissing = (new System.Windows.Forms.CheckBox());
			this.cbLeaveOriginals = (new System.Windows.Forms.CheckBox());
			this.cbCheckuTorrent = (new System.Windows.Forms.CheckBox());
			this.cbSearchLocally = (new System.Windows.Forms.CheckBox());
			this.tabPage5 = (new System.Windows.Forms.TabPage());
			this.groupBox6 = (new System.Windows.Forms.GroupBox());
			this.bnUTBrowseResumeDat = (new System.Windows.Forms.Button());
			this.txtUTResumeDatPath = (new System.Windows.Forms.TextBox());
			this.bnRSSBrowseuTorrent = (new System.Windows.Forms.Button());
			this.label27 = (new System.Windows.Forms.Label());
			this.label26 = (new System.Windows.Forms.Label());
			this.txtRSSuTorrentPath = (new System.Windows.Forms.TextBox());
			this.RSSGrid = (new SourceGrid.Grid());
			this.bnRSSRemove = (new System.Windows.Forms.Button());
			this.bnRSSAdd = (new System.Windows.Forms.Button());
			this.bnRSSGo = (new System.Windows.Forms.Button());
			this.label25 = (new System.Windows.Forms.Label());
			this.tabPage6 = (new System.Windows.Forms.TabPage());
			this.bnLangDown = (new System.Windows.Forms.Button());
			this.bnLangUp = (new System.Windows.Forms.Button());
			this.lbLangs = (new System.Windows.Forms.ListBox());
			this.label24 = (new System.Windows.Forms.Label());
			this.folderBrowser = (new System.Windows.Forms.FolderBrowserDialog());
			this.openFile = (new System.Windows.Forms.OpenFileDialog());
			this.rbFolderBanner = (new System.Windows.Forms.RadioButton());
			this.rbFolderPoster = (new System.Windows.Forms.RadioButton());
			this.rbFolderFanArt = (new System.Windows.Forms.RadioButton());
			this.groupBox2.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tpScanOptions.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.SuspendLayout();
			// 
			// OKButton
			// 
			this.OKButton.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
			this.OKButton.Location = new System.Drawing.Point(279, 445);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(75, 23);
			this.OKButton.TabIndex = 0;
			this.OKButton.Text = "OK";
			this.OKButton.UseVisualStyleBackColor = true;
			this.OKButton.Click += new System.EventHandler(OKButton_Click);
			// 
			// bnCancel
			// 
			this.bnCancel.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
			this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bnCancel.Location = new System.Drawing.Point(360, 445);
			this.bnCancel.Name = "bnCancel";
			this.bnCancel.Size = new System.Drawing.Size(75, 23);
			this.bnCancel.TabIndex = 1;
			this.bnCancel.Text = "Cancel";
			this.bnCancel.UseVisualStyleBackColor = true;
			this.bnCancel.Click += new System.EventHandler(CancelButton_Click);
			// 
			// ReplacementsGrid
			// 
			this.ReplacementsGrid.BackColor = System.Drawing.SystemColors.Window;
			this.ReplacementsGrid.Location = new System.Drawing.Point(6, 19);
			this.ReplacementsGrid.Name = "ReplacementsGrid";
			this.ReplacementsGrid.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
			this.ReplacementsGrid.SelectionMode = SourceGrid.GridSelectionMode.Cell;
			this.ReplacementsGrid.Size = new System.Drawing.Size(403, 124);
			this.ReplacementsGrid.TabIndex = 20;
			this.ReplacementsGrid.TabStop = true;
			this.ReplacementsGrid.ToolTipText = "";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.bnBrowseWTWRSS);
			this.groupBox2.Controls.Add(this.txtWTWRSS);
			this.groupBox2.Controls.Add(this.cbWTWRSS);
			this.groupBox2.Controls.Add(this.label17);
			this.groupBox2.Controls.Add(this.label16);
			this.groupBox2.Controls.Add(this.label15);
			this.groupBox2.Controls.Add(this.txtExportRSSMaxDays);
			this.groupBox2.Controls.Add(this.txtExportRSSMaxShows);
			this.groupBox2.Location = new System.Drawing.Point(6, 6);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(403, 84);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "When to Watch";
			// 
			// bnBrowseWTWRSS
			// 
			this.bnBrowseWTWRSS.Location = new System.Drawing.Point(321, 18);
			this.bnBrowseWTWRSS.Name = "bnBrowseWTWRSS";
			this.bnBrowseWTWRSS.Size = new System.Drawing.Size(75, 23);
			this.bnBrowseWTWRSS.TabIndex = 2;
			this.bnBrowseWTWRSS.Text = "Browse...";
			this.bnBrowseWTWRSS.UseVisualStyleBackColor = true;
			this.bnBrowseWTWRSS.Click += new System.EventHandler(bnBrowseWTWRSS_Click);
			// 
			// txtWTWRSS
			// 
			this.txtWTWRSS.Location = new System.Drawing.Point(64, 20);
			this.txtWTWRSS.Name = "txtWTWRSS";
			this.txtWTWRSS.Size = new System.Drawing.Size(251, 20);
			this.txtWTWRSS.TabIndex = 1;
			// 
			// cbWTWRSS
			// 
			this.cbWTWRSS.AutoSize = true;
			this.cbWTWRSS.Location = new System.Drawing.Point(10, 22);
			this.cbWTWRSS.Name = "cbWTWRSS";
			this.cbWTWRSS.Size = new System.Drawing.Size(48, 17);
			this.cbWTWRSS.TabIndex = 0;
			this.cbWTWRSS.Text = "RSS";
			this.cbWTWRSS.UseVisualStyleBackColor = true;
			this.cbWTWRSS.CheckedChanged += new System.EventHandler(EnableDisable);
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(212, 53);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(61, 13);
			this.label17.TabIndex = 7;
			this.label17.Text = "days worth.";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(120, 53);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(52, 13);
			this.label16.TabIndex = 5;
			this.label16.Text = "shows, or";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(9, 53);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(71, 13);
			this.label15.TabIndex = 3;
			this.label15.Text = "No more than";
			// 
			// txtExportRSSMaxDays
			// 
			this.txtExportRSSMaxDays.Location = new System.Drawing.Point(178, 50);
			this.txtExportRSSMaxDays.Name = "txtExportRSSMaxDays";
			this.txtExportRSSMaxDays.Size = new System.Drawing.Size(28, 20);
			this.txtExportRSSMaxDays.TabIndex = 6;
			this.txtExportRSSMaxDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtNumberOnlyKeyPress);
			// 
			// txtExportRSSMaxShows
			// 
			this.txtExportRSSMaxShows.Location = new System.Drawing.Point(86, 50);
			this.txtExportRSSMaxShows.Name = "txtExportRSSMaxShows";
			this.txtExportRSSMaxShows.Size = new System.Drawing.Size(28, 20);
			this.txtExportRSSMaxShows.TabIndex = 4;
			this.txtExportRSSMaxShows.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtNumberOnlyKeyPress);
			// 
			// saveFile
			// 
			this.saveFile.DefaultExt = "rss";
			this.saveFile.Filter = "RSS files (*.rss)|*.rss|XML files (*.xml)|*.xml|All files (*.*)|*.*";
			// 
			// cbTxtToSub
			// 
			this.cbTxtToSub.AutoSize = true;
			this.cbTxtToSub.Location = new System.Drawing.Point(6, 259);
			this.cbTxtToSub.Name = "cbTxtToSub";
			this.cbTxtToSub.Size = new System.Drawing.Size(118, 17);
			this.cbTxtToSub.TabIndex = 12;
			this.cbTxtToSub.Text = "Rename .txt to .sub";
			this.cbTxtToSub.UseVisualStyleBackColor = true;
			// 
			// txtSpecialsFolderName
			// 
			this.txtSpecialsFolderName.Location = new System.Drawing.Point(113, 306);
			this.txtSpecialsFolderName.Name = "txtSpecialsFolderName";
			this.txtSpecialsFolderName.Size = new System.Drawing.Size(279, 20);
			this.txtSpecialsFolderName.TabIndex = 15;
			// 
			// txtVideoExtensions
			// 
			this.txtVideoExtensions.Location = new System.Drawing.Point(99, 186);
			this.txtVideoExtensions.Name = "txtVideoExtensions";
			this.txtVideoExtensions.Size = new System.Drawing.Size(293, 20);
			this.txtVideoExtensions.TabIndex = 8;
			// 
			// cbStartupTab
			// 
			this.cbStartupTab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbStartupTab.FormattingEnabled = true;
			this.cbStartupTab.Items.AddRange(new object[3] {"My Shows", "Scan", "When to Watch"});
			this.cbStartupTab.Location = new System.Drawing.Point(103, 35);
			this.cbStartupTab.Name = "cbStartupTab";
			this.cbStartupTab.Size = new System.Drawing.Size(135, 21);
			this.cbStartupTab.TabIndex = 4;
			// 
			// cbShowEpisodePictures
			// 
			this.cbShowEpisodePictures.AutoSize = true;
			this.cbShowEpisodePictures.Location = new System.Drawing.Point(9, 85);
			this.cbShowEpisodePictures.Name = "cbShowEpisodePictures";
			this.cbShowEpisodePictures.Size = new System.Drawing.Size(218, 17);
			this.cbShowEpisodePictures.TabIndex = 12;
			this.cbShowEpisodePictures.Text = "Show episode pictures in episode guides";
			this.cbShowEpisodePictures.UseVisualStyleBackColor = true;
			// 
			// cbLeadingZero
			// 
			this.cbLeadingZero.AutoSize = true;
			this.cbLeadingZero.Location = new System.Drawing.Point(6, 282);
			this.cbLeadingZero.Name = "cbLeadingZero";
			this.cbLeadingZero.Size = new System.Drawing.Size(170, 17);
			this.cbLeadingZero.TabIndex = 13;
			this.cbLeadingZero.Text = "Leading 0 on Season numbers";
			this.cbLeadingZero.UseVisualStyleBackColor = true;
			// 
			// cbKeepTogether
			// 
			this.cbKeepTogether.AutoSize = true;
			this.cbKeepTogether.Location = new System.Drawing.Point(6, 238);
			this.cbKeepTogether.Name = "cbKeepTogether";
			this.cbKeepTogether.Size = new System.Drawing.Size(251, 17);
			this.cbKeepTogether.TabIndex = 11;
			this.cbKeepTogether.Text = "Copy/Move files with same base name as video";
			this.cbKeepTogether.UseVisualStyleBackColor = true;
			this.cbKeepTogether.CheckedChanged += new System.EventHandler(cbKeepTogether_CheckedChanged);
			// 
			// chkShowInTaskbar
			// 
			this.chkShowInTaskbar.AutoSize = true;
			this.chkShowInTaskbar.Location = new System.Drawing.Point(169, 62);
			this.chkShowInTaskbar.Name = "chkShowInTaskbar";
			this.chkShowInTaskbar.Size = new System.Drawing.Size(102, 17);
			this.chkShowInTaskbar.TabIndex = 6;
			this.chkShowInTaskbar.Text = "Show in taskbar";
			this.chkShowInTaskbar.UseVisualStyleBackColor = true;
			this.chkShowInTaskbar.CheckedChanged += new System.EventHandler(chkShowInTaskbar_CheckedChanged);
			// 
			// cbNotificationIcon
			// 
			this.cbNotificationIcon.AutoSize = true;
			this.cbNotificationIcon.Location = new System.Drawing.Point(9, 62);
			this.cbNotificationIcon.Name = "cbNotificationIcon";
			this.cbNotificationIcon.Size = new System.Drawing.Size(154, 17);
			this.cbNotificationIcon.TabIndex = 5;
			this.cbNotificationIcon.Text = "Show notification area icon";
			this.cbNotificationIcon.UseVisualStyleBackColor = true;
			this.cbNotificationIcon.CheckedChanged += new System.EventHandler(cbNotificationIcon_CheckedChanged);
			// 
			// txtWTWDays
			// 
			this.txtWTWDays.Location = new System.Drawing.Point(92, 9);
			this.txtWTWDays.Name = "txtWTWDays";
			this.txtWTWDays.Size = new System.Drawing.Size(28, 20);
			this.txtWTWDays.TabIndex = 1;
			this.txtWTWDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtNumberOnlyKeyPress);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(126, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(111, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "days counts as recent";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(6, 309);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(108, 13);
			this.label13.TabIndex = 14;
			this.label13.Text = "Specials folder name:";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(3, 189);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(90, 13);
			this.label14.TabIndex = 7;
			this.label14.Text = "Video extensions:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 38);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(62, 13);
			this.label6.TabIndex = 3;
			this.label6.Text = "Startup tab:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "When to watch";
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = (System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.tpScanOptions);
			this.tabControl1.Controls.Add(this.tabPage5);
			this.tabControl1.Controls.Add(this.tabPage6);
			this.tabControl1.Location = new System.Drawing.Point(12, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(423, 421);
			this.tabControl1.TabIndex = 5;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(tabControl1_SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.cbStartupTab);
			this.tabPage1.Controls.Add(this.label21);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.cbAutoSelInMyShows);
			this.tabPage1.Controls.Add(this.cbShowEpisodePictures);
			this.tabPage1.Controls.Add(this.label6);
			this.tabPage1.Controls.Add(this.chkShowInTaskbar);
			this.tabPage1.Controls.Add(this.label20);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.cbNotificationIcon);
			this.tabPage1.Controls.Add(this.txtParallelDownloads);
			this.tabPage1.Controls.Add(this.txtWTWDays);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(415, 395);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "General";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(6, 111);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(82, 13);
			this.label21.TabIndex = 0;
			this.label21.Text = "Download up to";
			// 
			// cbAutoSelInMyShows
			// 
			this.cbAutoSelInMyShows.AutoSize = true;
			this.cbAutoSelInMyShows.Location = new System.Drawing.Point(9, 134);
			this.cbAutoSelInMyShows.Name = "cbAutoSelInMyShows";
			this.cbAutoSelInMyShows.Size = new System.Drawing.Size(268, 17);
			this.cbAutoSelInMyShows.TabIndex = 12;
			this.cbAutoSelInMyShows.Text = "Automatically select show and season in My Shows";
			this.cbAutoSelInMyShows.UseVisualStyleBackColor = true;
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(126, 111);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(170, 13);
			this.label20.TabIndex = 2;
			this.label20.Text = "shows simultaneously from thetvdb";
			// 
			// txtParallelDownloads
			// 
			this.txtParallelDownloads.Location = new System.Drawing.Point(92, 108);
			this.txtParallelDownloads.Name = "txtParallelDownloads";
			this.txtParallelDownloads.Size = new System.Drawing.Size(28, 20);
			this.txtParallelDownloads.TabIndex = 1;
			this.txtParallelDownloads.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtNumberOnlyKeyPress);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.bnReplaceRemove);
			this.tabPage2.Controls.Add(this.bnReplaceAdd);
			this.tabPage2.Controls.Add(this.label3);
			this.tabPage2.Controls.Add(this.ReplacementsGrid);
			this.tabPage2.Controls.Add(this.label19);
			this.tabPage2.Controls.Add(this.txtMaxSampleSize);
			this.tabPage2.Controls.Add(this.cbTxtToSub);
			this.tabPage2.Controls.Add(this.label22);
			this.tabPage2.Controls.Add(this.label14);
			this.tabPage2.Controls.Add(this.txtSpecialsFolderName);
			this.tabPage2.Controls.Add(this.label13);
			this.tabPage2.Controls.Add(this.txtOtherExtensions);
			this.tabPage2.Controls.Add(this.txtVideoExtensions);
			this.tabPage2.Controls.Add(this.cbKeepTogether);
			this.tabPage2.Controls.Add(this.cbForceLower);
			this.tabPage2.Controls.Add(this.cbIgnoreSamples);
			this.tabPage2.Controls.Add(this.cbLeadingZero);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(415, 395);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Files and Folders";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// bnReplaceRemove
			// 
			this.bnReplaceRemove.Location = new System.Drawing.Point(90, 149);
			this.bnReplaceRemove.Name = "bnReplaceRemove";
			this.bnReplaceRemove.Size = new System.Drawing.Size(75, 23);
			this.bnReplaceRemove.TabIndex = 22;
			this.bnReplaceRemove.Text = "&Remove";
			this.bnReplaceRemove.UseVisualStyleBackColor = true;
			this.bnReplaceRemove.Click += new System.EventHandler(bnReplaceRemove_Click);
			// 
			// bnReplaceAdd
			// 
			this.bnReplaceAdd.Location = new System.Drawing.Point(9, 149);
			this.bnReplaceAdd.Name = "bnReplaceAdd";
			this.bnReplaceAdd.Size = new System.Drawing.Size(75, 23);
			this.bnReplaceAdd.TabIndex = 22;
			this.bnReplaceAdd.Text = "&Add";
			this.bnReplaceAdd.UseVisualStyleBackColor = true;
			this.bnReplaceAdd.Click += new System.EventHandler(bnReplaceAdd_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 3);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(120, 13);
			this.label3.TabIndex = 21;
			this.label3.Text = "Filename Replacements";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(228, 335);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(55, 13);
			this.label19.TabIndex = 18;
			this.label19.Text = "MB in size";
			// 
			// txtMaxSampleSize
			// 
			this.txtMaxSampleSize.Location = new System.Drawing.Point(172, 332);
			this.txtMaxSampleSize.Name = "txtMaxSampleSize";
			this.txtMaxSampleSize.Size = new System.Drawing.Size(53, 20);
			this.txtMaxSampleSize.TabIndex = 17;
			this.txtMaxSampleSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtNumberOnlyKeyPress);
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(3, 215);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(89, 13);
			this.label22.TabIndex = 9;
			this.label22.Text = "Other extensions:";
			// 
			// txtOtherExtensions
			// 
			this.txtOtherExtensions.Location = new System.Drawing.Point(99, 212);
			this.txtOtherExtensions.Name = "txtOtherExtensions";
			this.txtOtherExtensions.Size = new System.Drawing.Size(293, 20);
			this.txtOtherExtensions.TabIndex = 10;
			// 
			// cbForceLower
			// 
			this.cbForceLower.AutoSize = true;
			this.cbForceLower.Location = new System.Drawing.Point(6, 357);
			this.cbForceLower.Name = "cbForceLower";
			this.cbForceLower.Size = new System.Drawing.Size(167, 17);
			this.cbForceLower.TabIndex = 19;
			this.cbForceLower.Text = "Make all filenames lower case";
			this.cbForceLower.UseVisualStyleBackColor = true;
			// 
			// cbIgnoreSamples
			// 
			this.cbIgnoreSamples.AutoSize = true;
			this.cbIgnoreSamples.Location = new System.Drawing.Point(6, 334);
			this.cbIgnoreSamples.Name = "cbIgnoreSamples";
			this.cbIgnoreSamples.Size = new System.Drawing.Size(166, 17);
			this.cbIgnoreSamples.TabIndex = 16;
			this.cbIgnoreSamples.Text = "Ignore \"sample\" videos, up to";
			this.cbIgnoreSamples.UseVisualStyleBackColor = true;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.groupBox5);
			this.tabPage3.Controls.Add(this.groupBox4);
			this.tabPage3.Controls.Add(this.groupBox3);
			this.tabPage3.Controls.Add(this.groupBox2);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(415, 395);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Automatic Export";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.bnBrowseFOXML);
			this.groupBox5.Controls.Add(this.cbFOXML);
			this.groupBox5.Controls.Add(this.txtFOXML);
			this.groupBox5.Location = new System.Drawing.Point(6, 244);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(402, 55);
			this.groupBox5.TabIndex = 3;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Finding and Organising";
			// 
			// bnBrowseFOXML
			// 
			this.bnBrowseFOXML.Location = new System.Drawing.Point(321, 19);
			this.bnBrowseFOXML.Name = "bnBrowseFOXML";
			this.bnBrowseFOXML.Size = new System.Drawing.Size(75, 23);
			this.bnBrowseFOXML.TabIndex = 2;
			this.bnBrowseFOXML.Text = "Browse...";
			this.bnBrowseFOXML.UseVisualStyleBackColor = true;
			this.bnBrowseFOXML.Click += new System.EventHandler(bnBrowseFOXML_Click);
			// 
			// cbFOXML
			// 
			this.cbFOXML.AutoSize = true;
			this.cbFOXML.Location = new System.Drawing.Point(10, 23);
			this.cbFOXML.Name = "cbFOXML";
			this.cbFOXML.Size = new System.Drawing.Size(48, 17);
			this.cbFOXML.TabIndex = 0;
			this.cbFOXML.Text = "XML";
			this.cbFOXML.UseVisualStyleBackColor = true;
			this.cbFOXML.CheckedChanged += new System.EventHandler(EnableDisable);
			// 
			// txtFOXML
			// 
			this.txtFOXML.Location = new System.Drawing.Point(64, 21);
			this.txtFOXML.Name = "txtFOXML";
			this.txtFOXML.Size = new System.Drawing.Size(251, 20);
			this.txtFOXML.TabIndex = 1;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.bnBrowseRenamingXML);
			this.groupBox4.Controls.Add(this.cbRenamingXML);
			this.groupBox4.Controls.Add(this.txtRenamingXML);
			this.groupBox4.Location = new System.Drawing.Point(6, 181);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(402, 57);
			this.groupBox4.TabIndex = 2;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Renaming";
			// 
			// bnBrowseRenamingXML
			// 
			this.bnBrowseRenamingXML.Location = new System.Drawing.Point(321, 19);
			this.bnBrowseRenamingXML.Name = "bnBrowseRenamingXML";
			this.bnBrowseRenamingXML.Size = new System.Drawing.Size(75, 23);
			this.bnBrowseRenamingXML.TabIndex = 2;
			this.bnBrowseRenamingXML.Text = "Browse...";
			this.bnBrowseRenamingXML.UseVisualStyleBackColor = true;
			this.bnBrowseRenamingXML.Click += new System.EventHandler(bnBrowseRenamingXML_Click);
			// 
			// cbRenamingXML
			// 
			this.cbRenamingXML.AutoSize = true;
			this.cbRenamingXML.Location = new System.Drawing.Point(10, 23);
			this.cbRenamingXML.Name = "cbRenamingXML";
			this.cbRenamingXML.Size = new System.Drawing.Size(48, 17);
			this.cbRenamingXML.TabIndex = 0;
			this.cbRenamingXML.Text = "XML";
			this.cbRenamingXML.UseVisualStyleBackColor = true;
			this.cbRenamingXML.CheckedChanged += new System.EventHandler(EnableDisable);
			// 
			// txtRenamingXML
			// 
			this.txtRenamingXML.Location = new System.Drawing.Point(64, 21);
			this.txtRenamingXML.Name = "txtRenamingXML";
			this.txtRenamingXML.Size = new System.Drawing.Size(251, 20);
			this.txtRenamingXML.TabIndex = 1;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.bnBrowseMissingXML);
			this.groupBox3.Controls.Add(this.cbMissingXML);
			this.groupBox3.Controls.Add(this.bnBrowseMissingCSV);
			this.groupBox3.Controls.Add(this.txtMissingXML);
			this.groupBox3.Controls.Add(this.cbMissingCSV);
			this.groupBox3.Controls.Add(this.txtMissingCSV);
			this.groupBox3.Location = new System.Drawing.Point(6, 96);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(402, 79);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Missing";
			// 
			// bnBrowseMissingXML
			// 
			this.bnBrowseMissingXML.Location = new System.Drawing.Point(321, 44);
			this.bnBrowseMissingXML.Name = "bnBrowseMissingXML";
			this.bnBrowseMissingXML.Size = new System.Drawing.Size(75, 23);
			this.bnBrowseMissingXML.TabIndex = 5;
			this.bnBrowseMissingXML.Text = "Browse...";
			this.bnBrowseMissingXML.UseVisualStyleBackColor = true;
			this.bnBrowseMissingXML.Click += new System.EventHandler(bnBrowseMissingXML_Click);
			// 
			// cbMissingXML
			// 
			this.cbMissingXML.AutoSize = true;
			this.cbMissingXML.Location = new System.Drawing.Point(10, 48);
			this.cbMissingXML.Name = "cbMissingXML";
			this.cbMissingXML.Size = new System.Drawing.Size(48, 17);
			this.cbMissingXML.TabIndex = 3;
			this.cbMissingXML.Text = "XML";
			this.cbMissingXML.UseVisualStyleBackColor = true;
			this.cbMissingXML.CheckedChanged += new System.EventHandler(EnableDisable);
			// 
			// bnBrowseMissingCSV
			// 
			this.bnBrowseMissingCSV.Location = new System.Drawing.Point(321, 14);
			this.bnBrowseMissingCSV.Name = "bnBrowseMissingCSV";
			this.bnBrowseMissingCSV.Size = new System.Drawing.Size(75, 23);
			this.bnBrowseMissingCSV.TabIndex = 2;
			this.bnBrowseMissingCSV.Text = "Browse...";
			this.bnBrowseMissingCSV.UseVisualStyleBackColor = true;
			this.bnBrowseMissingCSV.Click += new System.EventHandler(bnBrowseMissingCSV_Click);
			// 
			// txtMissingXML
			// 
			this.txtMissingXML.Location = new System.Drawing.Point(64, 46);
			this.txtMissingXML.Name = "txtMissingXML";
			this.txtMissingXML.Size = new System.Drawing.Size(251, 20);
			this.txtMissingXML.TabIndex = 4;
			// 
			// cbMissingCSV
			// 
			this.cbMissingCSV.AutoSize = true;
			this.cbMissingCSV.Location = new System.Drawing.Point(10, 19);
			this.cbMissingCSV.Name = "cbMissingCSV";
			this.cbMissingCSV.Size = new System.Drawing.Size(47, 17);
			this.cbMissingCSV.TabIndex = 0;
			this.cbMissingCSV.Text = "CSV";
			this.cbMissingCSV.UseVisualStyleBackColor = true;
			this.cbMissingCSV.CheckedChanged += new System.EventHandler(EnableDisable);
			// 
			// txtMissingCSV
			// 
			this.txtMissingCSV.Location = new System.Drawing.Point(64, 17);
			this.txtMissingCSV.Name = "txtMissingCSV";
			this.txtMissingCSV.Size = new System.Drawing.Size(251, 20);
			this.txtMissingCSV.TabIndex = 1;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.bnOpenSearchFolder);
			this.tabPage4.Controls.Add(this.bnRemoveSearchFolder);
			this.tabPage4.Controls.Add(this.bnAddSearchFolder);
			this.tabPage4.Controls.Add(this.lbSearchFolders);
			this.tabPage4.Controls.Add(this.label23);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(415, 395);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Search Folders";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// bnOpenSearchFolder
			// 
			this.bnOpenSearchFolder.Location = new System.Drawing.Point(168, 369);
			this.bnOpenSearchFolder.Name = "bnOpenSearchFolder";
			this.bnOpenSearchFolder.Size = new System.Drawing.Size(75, 23);
			this.bnOpenSearchFolder.TabIndex = 9;
			this.bnOpenSearchFolder.Text = "&Open";
			this.bnOpenSearchFolder.UseVisualStyleBackColor = true;
			this.bnOpenSearchFolder.Click += new System.EventHandler(bnOpenSearchFolder_Click);
			// 
			// bnRemoveSearchFolder
			// 
			this.bnRemoveSearchFolder.Location = new System.Drawing.Point(87, 369);
			this.bnRemoveSearchFolder.Name = "bnRemoveSearchFolder";
			this.bnRemoveSearchFolder.Size = new System.Drawing.Size(75, 23);
			this.bnRemoveSearchFolder.TabIndex = 8;
			this.bnRemoveSearchFolder.Text = "&Remove";
			this.bnRemoveSearchFolder.UseVisualStyleBackColor = true;
			this.bnRemoveSearchFolder.Click += new System.EventHandler(bnRemoveSearchFolder_Click);
			// 
			// bnAddSearchFolder
			// 
			this.bnAddSearchFolder.Location = new System.Drawing.Point(3, 369);
			this.bnAddSearchFolder.Name = "bnAddSearchFolder";
			this.bnAddSearchFolder.Size = new System.Drawing.Size(75, 23);
			this.bnAddSearchFolder.TabIndex = 7;
			this.bnAddSearchFolder.Text = "&Add";
			this.bnAddSearchFolder.UseVisualStyleBackColor = true;
			this.bnAddSearchFolder.Click += new System.EventHandler(bnAddSearchFolder_Click);
			// 
			// lbSearchFolders
			// 
			this.lbSearchFolders.AllowDrop = true;
			this.lbSearchFolders.Anchor = (System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
			this.lbSearchFolders.FormattingEnabled = true;
			this.lbSearchFolders.Location = new System.Drawing.Point(3, 23);
			this.lbSearchFolders.Name = "lbSearchFolders";
			this.lbSearchFolders.ScrollAlwaysVisible = true;
			this.lbSearchFolders.Size = new System.Drawing.Size(409, 342);
			this.lbSearchFolders.TabIndex = 6;
			this.lbSearchFolders.KeyDown += new System.Windows.Forms.KeyEventHandler(lbSearchFolders_KeyDown);
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(5, 3);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(78, 13);
			this.label23.TabIndex = 5;
			this.label23.Text = "&Search Folders";
			// 
			// tpScanOptions
			// 
			this.tpScanOptions.Controls.Add(this.rbFolderFanArt);
			this.tpScanOptions.Controls.Add(this.rbFolderPoster);
			this.tpScanOptions.Controls.Add(this.rbFolderBanner);
			this.tpScanOptions.Controls.Add(this.label28);
			this.tpScanOptions.Controls.Add(this.cbSearchRSS);
			this.tpScanOptions.Controls.Add(this.cbEpImgs);
			this.tpScanOptions.Controls.Add(this.cbNFOs);
			this.tpScanOptions.Controls.Add(this.cbFolderJpg);
			this.tpScanOptions.Controls.Add(this.cbRenameCheck);
			this.tpScanOptions.Controls.Add(this.cbMissing);
			this.tpScanOptions.Controls.Add(this.cbLeaveOriginals);
			this.tpScanOptions.Controls.Add(this.cbCheckuTorrent);
			this.tpScanOptions.Controls.Add(this.cbSearchLocally);
			this.tpScanOptions.Location = new System.Drawing.Point(4, 22);
			this.tpScanOptions.Name = "tpScanOptions";
			this.tpScanOptions.Padding = System.Windows.Forms.Padding(3);
			this.tpScanOptions.Size = new System.Drawing.Size(415, 395);
			this.tpScanOptions.TabIndex = 6;
			this.tpScanOptions.Text = "Scan Options";
			this.tpScanOptions.UseVisualStyleBackColor = true;
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Location = new System.Drawing.Point(6, 13);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(141, 13);
			this.label28.TabIndex = 10;
			this.label28.Text = "\"Scan\" checks and actions:";
			// 
			// cbSearchRSS
			// 
			this.cbSearchRSS.AutoSize = true;
			this.cbSearchRSS.Location = new System.Drawing.Point(40, 148);
			this.cbSearchRSS.Name = "cbSearchRSS";
			this.cbSearchRSS.Size = new System.Drawing.Size(158, 17);
			this.cbSearchRSS.TabIndex = 7;
			this.cbSearchRSS.Text = "Search RSS for missing files";
			this.cbSearchRSS.UseVisualStyleBackColor = true;
			// 
			// cbEpImgs
			// 
			this.cbEpImgs.AutoSize = true;
			this.cbEpImgs.Location = new System.Drawing.Point(40, 171);
			this.cbEpImgs.Name = "cbEpImgs";
			this.cbEpImgs.Size = new System.Drawing.Size(148, 17);
			this.cbEpImgs.TabIndex = 6;
			this.cbEpImgs.Text = "Episode Thumbnails (.tbn)";
			this.cbEpImgs.UseVisualStyleBackColor = true;
			// 
			// cbNFOs
			// 
			this.cbNFOs.AutoSize = true;
			this.cbNFOs.Location = new System.Drawing.Point(40, 194);
			this.cbNFOs.Name = "cbNFOs";
			this.cbNFOs.Size = new System.Drawing.Size(216, 17);
			this.cbNFOs.TabIndex = 9;
			this.cbNFOs.Text = "XBMC NFO files for shows and episodes";
			this.cbNFOs.UseVisualStyleBackColor = true;
			// 
			// cbFolderJpg
			// 
			this.cbFolderJpg.AutoSize = true;
			this.cbFolderJpg.Location = new System.Drawing.Point(20, 217);
			this.cbFolderJpg.Name = "cbFolderJpg";
			this.cbFolderJpg.Size = new System.Drawing.Size(164, 17);
			this.cbFolderJpg.TabIndex = 8;
			this.cbFolderJpg.Text = "Folder Thumbnails (folder.jpg)";
			this.cbFolderJpg.UseVisualStyleBackColor = true;
			// 
			// cbRenameCheck
			// 
			this.cbRenameCheck.AutoSize = true;
			this.cbRenameCheck.Checked = true;
			this.cbRenameCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbRenameCheck.Location = new System.Drawing.Point(20, 33);
			this.cbRenameCheck.Name = "cbRenameCheck";
			this.cbRenameCheck.Size = new System.Drawing.Size(100, 17);
			this.cbRenameCheck.TabIndex = 3;
			this.cbRenameCheck.Text = "Rename Check";
			this.cbRenameCheck.UseVisualStyleBackColor = true;
			// 
			// cbMissing
			// 
			this.cbMissing.AutoSize = true;
			this.cbMissing.Checked = true;
			this.cbMissing.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbMissing.Location = new System.Drawing.Point(20, 56);
			this.cbMissing.Name = "cbMissing";
			this.cbMissing.Size = new System.Drawing.Size(95, 17);
			this.cbMissing.TabIndex = 2;
			this.cbMissing.Text = "Missing Check";
			this.cbMissing.UseVisualStyleBackColor = true;
			this.cbMissing.CheckedChanged += new System.EventHandler(cbMissing_CheckedChanged);
			// 
			// cbLeaveOriginals
			// 
			this.cbLeaveOriginals.AutoSize = true;
			this.cbLeaveOriginals.Location = new System.Drawing.Point(60, 102);
			this.cbLeaveOriginals.Name = "cbLeaveOriginals";
			this.cbLeaveOriginals.Size = new System.Drawing.Size(129, 17);
			this.cbLeaveOriginals.TabIndex = 5;
			this.cbLeaveOriginals.Text = "Copy files, don\'t move";
			this.cbLeaveOriginals.UseVisualStyleBackColor = true;
			// 
			// cbCheckuTorrent
			// 
			this.cbCheckuTorrent.AutoSize = true;
			this.cbCheckuTorrent.Location = new System.Drawing.Point(41, 125);
			this.cbCheckuTorrent.Name = "cbCheckuTorrent";
			this.cbCheckuTorrent.Size = new System.Drawing.Size(133, 17);
			this.cbCheckuTorrent.TabIndex = 4;
			this.cbCheckuTorrent.Text = "Check �Torrent queue";
			this.cbCheckuTorrent.UseVisualStyleBackColor = true;
			this.cbCheckuTorrent.CheckedChanged += new System.EventHandler(cbSearchLocally_CheckedChanged);
			// 
			// cbSearchLocally
			// 
			this.cbSearchLocally.AutoSize = true;
			this.cbSearchLocally.Checked = true;
			this.cbSearchLocally.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbSearchLocally.Location = new System.Drawing.Point(40, 79);
			this.cbSearchLocally.Name = "cbSearchLocally";
			this.cbSearchLocally.Size = new System.Drawing.Size(213, 17);
			this.cbSearchLocally.TabIndex = 4;
			this.cbSearchLocally.Text = "Look in \"Search Folders\" for mising files";
			this.cbSearchLocally.UseVisualStyleBackColor = true;
			this.cbSearchLocally.CheckedChanged += new System.EventHandler(cbSearchLocally_CheckedChanged);
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.groupBox6);
			this.tabPage5.Controls.Add(this.RSSGrid);
			this.tabPage5.Controls.Add(this.bnRSSRemove);
			this.tabPage5.Controls.Add(this.bnRSSAdd);
			this.tabPage5.Controls.Add(this.bnRSSGo);
			this.tabPage5.Controls.Add(this.label25);
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = System.Windows.Forms.Padding(3);
			this.tabPage5.Size = new System.Drawing.Size(415, 395);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "RSS / �Torrent";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.bnUTBrowseResumeDat);
			this.groupBox6.Controls.Add(this.txtUTResumeDatPath);
			this.groupBox6.Controls.Add(this.bnRSSBrowseuTorrent);
			this.groupBox6.Controls.Add(this.label27);
			this.groupBox6.Controls.Add(this.label26);
			this.groupBox6.Controls.Add(this.txtRSSuTorrentPath);
			this.groupBox6.Location = new System.Drawing.Point(3, 300);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(409, 92);
			this.groupBox6.TabIndex = 19;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "�Torrent";
			// 
			// bnUTBrowseResumeDat
			// 
			this.bnUTBrowseResumeDat.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			this.bnUTBrowseResumeDat.Location = new System.Drawing.Point(328, 53);
			this.bnUTBrowseResumeDat.Name = "bnUTBrowseResumeDat";
			this.bnUTBrowseResumeDat.Size = new System.Drawing.Size(75, 23);
			this.bnUTBrowseResumeDat.TabIndex = 18;
			this.bnUTBrowseResumeDat.Text = "B&rowse...";
			this.bnUTBrowseResumeDat.UseVisualStyleBackColor = true;
			this.bnUTBrowseResumeDat.Click += new System.EventHandler(bnUTBrowseResumeDat_Click);
			// 
			// txtUTResumeDatPath
			// 
			this.txtUTResumeDatPath.Anchor = (System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
			this.txtUTResumeDatPath.Location = new System.Drawing.Point(75, 55);
			this.txtUTResumeDatPath.Name = "txtUTResumeDatPath";
			this.txtUTResumeDatPath.Size = new System.Drawing.Size(247, 20);
			this.txtUTResumeDatPath.TabIndex = 17;
			// 
			// bnRSSBrowseuTorrent
			// 
			this.bnRSSBrowseuTorrent.Location = new System.Drawing.Point(328, 24);
			this.bnRSSBrowseuTorrent.Name = "bnRSSBrowseuTorrent";
			this.bnRSSBrowseuTorrent.Size = new System.Drawing.Size(75, 23);
			this.bnRSSBrowseuTorrent.TabIndex = 12;
			this.bnRSSBrowseuTorrent.Text = "&Browse...";
			this.bnRSSBrowseuTorrent.UseVisualStyleBackColor = true;
			this.bnRSSBrowseuTorrent.Click += new System.EventHandler(bnRSSBrowseuTorrent_Click);
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(7, 29);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(62, 13);
			this.label27.TabIndex = 16;
			this.label27.Text = "Application:";
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.Location = new System.Drawing.Point(7, 58);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(62, 13);
			this.label26.TabIndex = 16;
			this.label26.Text = "resume.&dat:";
			// 
			// txtRSSuTorrentPath
			// 
			this.txtRSSuTorrentPath.Location = new System.Drawing.Point(75, 26);
			this.txtRSSuTorrentPath.Name = "txtRSSuTorrentPath";
			this.txtRSSuTorrentPath.Size = new System.Drawing.Size(247, 20);
			this.txtRSSuTorrentPath.TabIndex = 10;
			// 
			// RSSGrid
			// 
			this.RSSGrid.BackColor = System.Drawing.SystemColors.Window;
			this.RSSGrid.Location = new System.Drawing.Point(3, 36);
			this.RSSGrid.Name = "RSSGrid";
			this.RSSGrid.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
			this.RSSGrid.SelectionMode = SourceGrid.GridSelectionMode.Cell;
			this.RSSGrid.Size = new System.Drawing.Size(409, 226);
			this.RSSGrid.TabIndex = 15;
			this.RSSGrid.TabStop = true;
			this.RSSGrid.ToolTipText = "";
			// 
			// bnRSSRemove
			// 
			this.bnRSSRemove.Location = new System.Drawing.Point(84, 268);
			this.bnRSSRemove.Name = "bnRSSRemove";
			this.bnRSSRemove.Size = new System.Drawing.Size(75, 23);
			this.bnRSSRemove.TabIndex = 13;
			this.bnRSSRemove.Text = "Remove";
			this.bnRSSRemove.UseVisualStyleBackColor = true;
			this.bnRSSRemove.Click += new System.EventHandler(bnRSSRemove_Click);
			// 
			// bnRSSAdd
			// 
			this.bnRSSAdd.Location = new System.Drawing.Point(3, 268);
			this.bnRSSAdd.Name = "bnRSSAdd";
			this.bnRSSAdd.Size = new System.Drawing.Size(75, 23);
			this.bnRSSAdd.TabIndex = 13;
			this.bnRSSAdd.Text = "Add";
			this.bnRSSAdd.UseVisualStyleBackColor = true;
			this.bnRSSAdd.Click += new System.EventHandler(bnRSSAdd_Click);
			// 
			// bnRSSGo
			// 
			this.bnRSSGo.Location = new System.Drawing.Point(165, 268);
			this.bnRSSGo.Name = "bnRSSGo";
			this.bnRSSGo.Size = new System.Drawing.Size(75, 23);
			this.bnRSSGo.TabIndex = 11;
			this.bnRSSGo.Text = "Open";
			this.bnRSSGo.UseVisualStyleBackColor = true;
			this.bnRSSGo.Click += new System.EventHandler(bnRSSGo_Click);
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Location = new System.Drawing.Point(3, 13);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(62, 13);
			this.label25.TabIndex = 8;
			this.label25.Text = "RSS URLs:";
			// 
			// tabPage6
			// 
			this.tabPage6.Controls.Add(this.bnLangDown);
			this.tabPage6.Controls.Add(this.bnLangUp);
			this.tabPage6.Controls.Add(this.lbLangs);
			this.tabPage6.Controls.Add(this.label24);
			this.tabPage6.Location = new System.Drawing.Point(4, 22);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Padding = System.Windows.Forms.Padding(3);
			this.tabPage6.Size = new System.Drawing.Size(415, 395);
			this.tabPage6.TabIndex = 5;
			this.tabPage6.Text = "Languages";
			this.tabPage6.UseVisualStyleBackColor = true;
			// 
			// bnLangDown
			// 
			this.bnLangDown.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			this.bnLangDown.Location = new System.Drawing.Point(195, 48);
			this.bnLangDown.Name = "bnLangDown";
			this.bnLangDown.Size = new System.Drawing.Size(75, 23);
			this.bnLangDown.TabIndex = 7;
			this.bnLangDown.Text = "Move &down";
			this.bnLangDown.UseVisualStyleBackColor = true;
			this.bnLangDown.Click += new System.EventHandler(bnLangDown_Click);
			// 
			// bnLangUp
			// 
			this.bnLangUp.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
			this.bnLangUp.Location = new System.Drawing.Point(195, 19);
			this.bnLangUp.Name = "bnLangUp";
			this.bnLangUp.Size = new System.Drawing.Size(75, 23);
			this.bnLangUp.TabIndex = 8;
			this.bnLangUp.Text = "Move &up";
			this.bnLangUp.UseVisualStyleBackColor = true;
			this.bnLangUp.Click += new System.EventHandler(bnLangUp_Click);
			// 
			// lbLangs
			// 
			this.lbLangs.Anchor = (System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
			this.lbLangs.FormattingEnabled = true;
			this.lbLangs.Location = new System.Drawing.Point(6, 19);
			this.lbLangs.Name = "lbLangs";
			this.lbLangs.Size = new System.Drawing.Size(183, 368);
			this.lbLangs.TabIndex = 6;
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(3, 3);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(179, 13);
			this.label24.TabIndex = 5;
			this.label24.Text = "Preferred languages for thetvdb.com";
			// 
			// folderBrowser
			// 
			this.folderBrowser.ShowNewFolderButton = false;
			// 
			// openFile
			// 
			this.openFile.Filter = "Torrent files (*.torrent)|*.torrent|All files (*.*)|*.*";
			// 
			// rbFolderBanner
			// 
			this.rbFolderBanner.AutoSize = true;
			this.rbFolderBanner.Location = new System.Drawing.Point(40, 240);
			this.rbFolderBanner.Name = "rbFolderBanner";
			this.rbFolderBanner.Size = new System.Drawing.Size(59, 17);
			this.rbFolderBanner.TabIndex = 11;
			this.rbFolderBanner.TabStop = true;
			this.rbFolderBanner.Text = "Banner";
			this.rbFolderBanner.UseVisualStyleBackColor = true;
			// 
			// rbFolderPoster
			// 
			this.rbFolderPoster.AutoSize = true;
			this.rbFolderPoster.Location = new System.Drawing.Point(40, 263);
			this.rbFolderPoster.Name = "rbFolderPoster";
			this.rbFolderPoster.Size = new System.Drawing.Size(55, 17);
			this.rbFolderPoster.TabIndex = 11;
			this.rbFolderPoster.TabStop = true;
			this.rbFolderPoster.Text = "Poster";
			this.rbFolderPoster.UseVisualStyleBackColor = true;
			// 
			// rbFolderFanArt
			// 
			this.rbFolderFanArt.AutoSize = true;
			this.rbFolderFanArt.Location = new System.Drawing.Point(41, 286);
			this.rbFolderFanArt.Name = "rbFolderFanArt";
			this.rbFolderFanArt.Size = new System.Drawing.Size(59, 17);
			this.rbFolderFanArt.TabIndex = 11;
			this.rbFolderFanArt.TabStop = true;
			this.rbFolderFanArt.Text = "Fan Art";
			this.rbFolderFanArt.UseVisualStyleBackColor = true;
			// 
			// Preferences
			// 
			this.AcceptButton = this.OKButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.bnCancel;
			this.ClientSize = new System.Drawing.Size(447, 480);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.bnCancel);
			this.Controls.Add(this.OKButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Preferences";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Preferences";
			this.Load += new System.EventHandler(Preferences_Load);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.tabPage4.ResumeLayout(false);
			this.tabPage4.PerformLayout();
			this.tpScanOptions.ResumeLayout(false);
			this.tpScanOptions.PerformLayout();
			this.tabPage5.ResumeLayout(false);
			this.tabPage5.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.tabPage6.ResumeLayout(false);
			this.tabPage6.PerformLayout();
			this.ResumeLayout(false);

		}

#endregion
	private void OKButton_Click(object sender, System.EventArgs e)
			 {
				 if (!TVSettings.OKExtensionsString(txtVideoExtensions.Text))
				 {
					 MessageBox.Show("Extensions list must be separated by semicolons, and each extension must start with a dot.","Preferences",MessageBoxButtons.OK, MessageBoxIcon.Warning);
					 tabControl1.SelectedIndex = 1;
					 txtVideoExtensions.Focus();
					 return;
				 }
				 if (!TVSettings.OKExtensionsString(txtOtherExtensions.Text))
				 {
					 MessageBox.Show("Extensions list must be separated by semicolons, and each extension must start with a dot.","Preferences",MessageBoxButtons.OK, MessageBoxIcon.Warning);
					 tabControl1.SelectedIndex = 1;
					 txtOtherExtensions.Focus();
					 return;
				 }
				 TVSettings S = mDoc.Settings;
				 S.Replacements.Clear();
				 for (int i =1;i<ReplacementsGrid.RowsCount;i++)
				 {
					 string from = (string)(ReplacementsGrid[i,0].Value);
					 string to = (string)(ReplacementsGrid[i,1].Value);
					 bool ins = (bool)(ReplacementsGrid[i,2].Value);
					 if (!string.IsNullOrEmpty(from))
						 S.Replacements.Add(new Replacement(from,to,ins));
				 }


				 S.ExportWTWRSS = cbWTWRSS.Checked;
				 S.ExportWTWRSSTo = txtWTWRSS.Text;

				 S.ExportMissingXML= cbMissingXML.Checked;
				 S.ExportMissingXMLTo = txtMissingXML.Text;
				 S.ExportMissingCSV = cbMissingCSV.Checked;
				 S.ExportMissingCSVTo = txtMissingCSV.Text;
				 S.ExportRenamingXML = cbRenamingXML.Checked;
				 S.ExportRenamingXMLTo = txtRenamingXML.Text;
				 S.ExportFOXML = cbFOXML.Checked;
				 S.ExportFOXMLTo = txtFOXML.Text;

				 S.WTWRecentDays = Convert.ToInt32(txtWTWDays.Text);
				 S.StartupTab = cbStartupTab.SelectedIndex;
				 S.NotificationAreaIcon = cbNotificationIcon.Checked;
				 S.SetVideoExtensionsString(txtVideoExtensions.Text);
				 S.SetOtherExtensionsString(txtOtherExtensions.Text);
				 S.ExportRSSMaxDays = Convert.ToInt32(txtExportRSSMaxDays.Text);
				 S.ExportRSSMaxShows = Convert.ToInt32(txtExportRSSMaxShows.Text);
				 S.KeepTogether = cbKeepTogether.Checked;
				 S.LeadingZeroOnSeason = cbLeadingZero.Checked;
				 S.ShowInTaskbar = chkShowInTaskbar.Checked;
				 S.RenameTxtToSub = cbTxtToSub.Checked;
				 S.ShowEpisodePictures = cbShowEpisodePictures.Checked;
				 S.AutoSelectShowInMyShows = cbAutoSelInMyShows.Checked;
				 S.SpecialsFolderName = txtSpecialsFolderName.Text;

				 S.ForceLowercaseFilenames = cbForceLower.Checked;
				 S.IgnoreSamples = cbIgnoreSamples.Checked;

				 S.uTorrentPath = txtRSSuTorrentPath.Text;
				 S.ResumeDatPath = txtUTResumeDatPath.Text;

				 S.SearchRSS = cbSearchRSS.Checked;
				 S.EpImgs = cbEpImgs.Checked;
				 S.NFOs = cbNFOs.Checked;
				 S.FolderJpg = cbFolderJpg.Checked;
				 S.RenameCheck = cbRenameCheck.Checked;
				 S.MissingCheck = cbMissing.Checked;
				 S.SearchLocally = cbSearchLocally.Checked;
				 S.LeaveOriginals = cbLeaveOriginals.Checked;
				 S.CheckuTorrent = cbCheckuTorrent.Checked;

				 if (rbFolderFanArt.Checked)
					 S.FolderJpgIs = TVSettings.FolderJpgIsType.FanArt;
				 else if (rbFolderBanner.Checked)
					 S.FolderJpgIs = TVSettings.FolderJpgIsType.Banner;
				 else
					 S.FolderJpgIs = TVSettings.FolderJpgIsType.Poster;

				 if (LangList != null)
				 {
					 //only set if the language tab was visited

					 TheTVDB db = mDoc.GetTVDB(true, "Preferences-OK");
					 db.LanguagePriorityList = LangList;
					 db.SaveCache();
					 db.Unlock("Preferences-OK");
				 }


				 try
				 {
					 S.SampleFileMaxSizeMB = int.Parse(txtMaxSampleSize.Text);
				 }
				 catch
				 {
					 S.SampleFileMaxSizeMB = 50;
				 }

				 try
				 {
					 S.ParallelDownloads = int.Parse(txtParallelDownloads.Text);
				 }
				 catch
				 {
					 S.ParallelDownloads = 4;
				 }

				 if (S.ParallelDownloads < 1)
					 S.ParallelDownloads = 1;
				 else if (S.ParallelDownloads > 8)
					 S.ParallelDownloads = 8;

				 // RSS URLs
				 S.RSSURLs.Clear();
				 for (int i =1;i<RSSGrid.RowsCount;i++)
				 {
					 string url = (string)(RSSGrid[i,0].Value);
					 if (!string.IsNullOrEmpty(url))
						 S.RSSURLs.Add(url);
				 }

				 mDoc.SetDirty();
				 this.DialogResult =DialogResult.OK;
				 this.Close();
			 }
	private void Preferences_Load(object sender, System.EventArgs e)
			 {
				 TVSettings S = mDoc.Settings;
				 int r = 1;

				 foreach (Replacement R in S.Replacements)
				 {
					 AddNewReplacementRow(R.This, R.That, R.CaseInsensitive);
					 r++;
				 }

				 txtMaxSampleSize.Text = S.SampleFileMaxSizeMB.ToString();

				 cbWTWRSS.Checked = S.ExportWTWRSS;
				 txtWTWRSS.Text = S.ExportWTWRSSTo;
				 txtWTWDays.Text = S.WTWRecentDays.ToString();
				 txtExportRSSMaxDays.Text = S.ExportRSSMaxDays.ToString();
				 txtExportRSSMaxShows.Text = S.ExportRSSMaxShows.ToString();

				 cbMissingXML.Checked = S.ExportMissingXML;
				 txtMissingXML.Text = S.ExportMissingXMLTo;
				 cbMissingCSV.Checked = S.ExportMissingCSV;
				 txtMissingCSV.Text = S.ExportMissingCSVTo;

				 cbRenamingXML.Checked = S.ExportRenamingXML;
				 txtRenamingXML.Text = S.ExportRenamingXMLTo;

				 cbFOXML.Checked = S.ExportFOXML;
				 txtFOXML.Text = S.ExportFOXMLTo;

				 cbStartupTab.SelectedIndex = S.StartupTab;
				 cbNotificationIcon.Checked = S.NotificationAreaIcon;
				 txtVideoExtensions.Text = S.GetVideoExtensionsString();
				 txtOtherExtensions.Text = S.GetOtherExtensionsString();

				 cbKeepTogether.Checked = S.KeepTogether;
				 cbKeepTogether_CheckedChanged(null, null);

				 cbLeadingZero.Checked = S.LeadingZeroOnSeason;
				 chkShowInTaskbar.Checked = S.ShowInTaskbar;
				 cbTxtToSub.Checked = S.RenameTxtToSub;
				 cbShowEpisodePictures.Checked = S.ShowEpisodePictures;
				 cbAutoSelInMyShows.Checked = S.AutoSelectShowInMyShows;
				 txtSpecialsFolderName.Text = S.SpecialsFolderName;
				 cbForceLower.Checked = S.ForceLowercaseFilenames;
				 cbIgnoreSamples.Checked = S.IgnoreSamples;
				 txtRSSuTorrentPath.Text = S.uTorrentPath;
				 txtUTResumeDatPath.Text = S.ResumeDatPath;

				 txtParallelDownloads.Text = S.ParallelDownloads.ToString();

				 cbSearchRSS.Checked = S.SearchRSS;
				 cbEpImgs.Checked = S.EpImgs;
				 cbNFOs.Checked = S.NFOs;
				 cbFolderJpg.Checked = S.FolderJpg;
				 cbRenameCheck.Checked = S.RenameCheck;
				 cbCheckuTorrent.Checked = S.CheckuTorrent;
				 cbMissing.Checked = S.MissingCheck;
				 cbSearchLocally.Checked = S.SearchLocally;
				 cbLeaveOriginals.Checked = S.LeaveOriginals;

				 EnableDisable(null, null);

				 FillSearchFolderList();

				 foreach (string s in S.RSSURLs)
					 AddNewRSSRow(s);

				 switch (S.FolderJpgIs)
				 {
				 case TVSettings.FolderJpgIsType.FanArt:
					 rbFolderFanArt.Checked = true;
					 break;
				 case TVSettings.FolderJpgIsType.Banner:
					 rbFolderBanner.Checked = true;
					 break;
				 default:
					 rbFolderPoster.Checked = true;
					 break;
				 }

			 }
			 private void Browse(TextBox txt)
			 {
				 saveFile.FileName = txt.Text;
				 if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					 txt.Text = saveFile.FileName;

			 }
	private void bnBrowseWTWRSS_Click(object sender, System.EventArgs e)
			 {
				 Browse(txtWTWRSS);
			 }
	private void txtNumberOnlyKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			 {
				 // digits only
				 if ((e.KeyChar >= 32) && (!Char.IsDigit(e.KeyChar)))
					 e.Handled = true;
			 }
	private void CancelButton_Click(object sender, System.EventArgs e)
			 {
				 this.Close();
			 }
	private void cbNotificationIcon_CheckedChanged(object sender, System.EventArgs e)
			 {
				 if (!cbNotificationIcon.Checked)
					 chkShowInTaskbar.Checked = true;
			 }
	private void chkShowInTaskbar_CheckedChanged(object sender, System.EventArgs e)
			 {
				 if (!chkShowInTaskbar.Checked)
					 cbNotificationIcon.Checked = true;
			 }
	private void cbKeepTogether_CheckedChanged(object sender, System.EventArgs e)
			 {
				 cbTxtToSub.Enabled = cbKeepTogether.Checked;
			 }
	private void bnBrowseMissingCSV_Click(object sender, System.EventArgs e)
			 {
				 Browse(txtMissingCSV);
			 }
	private void bnBrowseMissingXML_Click(object sender, System.EventArgs e)
			 {
				 Browse(txtMissingXML);
			 }
	private void bnBrowseRenamingXML_Click(object sender, System.EventArgs e)
			 {
				 Browse(txtRenamingXML);
			 }
	private void bnBrowseFOXML_Click(object sender, System.EventArgs e)
			 {
				 Browse(txtFOXML);
			 }
	private void EnableDisable(object sender, System.EventArgs e)
			 {
				 bool wtw = cbWTWRSS.Checked;
				 txtWTWRSS.Enabled = wtw;
				 bnBrowseWTWRSS.Enabled = wtw;
				 label15.Enabled = wtw;
				 label16.Enabled = wtw;
				 label17.Enabled = wtw;
				 txtExportRSSMaxDays.Enabled = wtw;
				 txtExportRSSMaxShows.Enabled = wtw;

				 bool fo = cbFOXML.Checked;
				 txtFOXML.Enabled = fo;
				 bnBrowseFOXML.Enabled = fo;

				 bool ren = cbRenamingXML.Checked;
				 txtRenamingXML.Enabled = ren;
				 bnBrowseRenamingXML.Enabled = ren;

				 bool misx = cbMissingXML.Checked;
				 txtMissingXML.Enabled = misx;
				 bnBrowseMissingXML.Enabled = misx;

				 bool misc = cbMissingCSV.Checked;
				 txtMissingCSV.Enabled = misc;
				 bnBrowseMissingCSV.Enabled = misc;
			 }

			 private void bnAddSearchFolder_Click(object sender, System.EventArgs e)
			 {
				 int n = lbSearchFolders.SelectedIndex;
				 if (n != -1)
					 folderBrowser.SelectedPath = mDoc.SearchFolders[n];
				 else
					 folderBrowser.SelectedPath = "";

				 if (folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				 {
					 mDoc.SearchFolders.Add(folderBrowser.SelectedPath);
					 mDoc.SetDirty();
				 }

				 FillSearchFolderList();
			 }

			 private void bnRemoveSearchFolder_Click(object sender, System.EventArgs e)
			 {
				 int n = lbSearchFolders.SelectedIndex;
				 if (n == -1)
					 return;

				 mDoc.SearchFolders.RemoveAt(n);
				 mDoc.SetDirty();

				 FillSearchFolderList();

			 }

			 private void bnOpenSearchFolder_Click(object sender, System.EventArgs e)
			 {
				 int n = lbSearchFolders.SelectedIndex;
				 if (n == -1)
					 return;
				 TVDoc.SysOpen(mDoc.SearchFolders[n]);
			 }
			 private void FillSearchFolderList()
			 {
				 lbSearchFolders.Items.Clear();
				 mDoc.SearchFolders.Sort();
				 foreach (string efi in mDoc.SearchFolders)
					 lbSearchFolders.Items.Add(efi);
			 }

			 private void lbSearchFolders_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
			 {
				 if (e.KeyCode == Keys.Delete)
					 bnRemoveSearchFolder_Click(null, null);
			 }

			 private void lbSearchFolders_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
			 {
				 if (!e.Data.GetDataPresent(DataFormats.FileDrop))
					 e.Effect = DragDropEffects.None;
				 else
					 e.Effect = DragDropEffects.Copy;
			 }
			 private void lbSearchFolders_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
			 {
				 string[] files = (string[])(e.Data.GetData(DataFormats.FileDrop));
				 for (int i =0;i<files.Length;i++)
				 {
					 string path = files[i];
					 DirectoryInfo di;
					 try
					 {
						 di = new DirectoryInfo(path);
						 if (di.Exists)
						 {
							 mDoc.SearchFolders.Add(path.ToLower());
						 }
					 }
					 catch
					 {
					 }
				 }
				 mDoc.SetDirty();
				 FillSearchFolderList();
			 }
			 private void lbSearchFolders_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
			 {
				 if (e.Button != System.Windows.Forms.MouseButtons.Right)
					 return;
//                 
//				 TODO ?
//				 lbSearchFolders->ClearSelected();
//				 lbSearchFolders->SelectedIndex = lbSearchFolders->IndexFromPoint(Point(e->X,e->Y));
//
//				 int p;
//				 if ((p = lbSearchFolders->SelectedIndex) == -1)
//				 return;
//
//				 Point^ pt = lbSearchFolders->PointToScreen(Point(e->X, e->Y));
//				 RightClickOnFolder(lbSearchFolders->Items[p]->ToString(),pt);
//				 }
//				 
			 }
	private void bnRSSBrowseuTorrent_Click(object sender, System.EventArgs e)
			 {
				 openFile.FileName = txtRSSuTorrentPath.Text;
				 openFile.Filter = "utorrent.exe|utorrent.exe|All Files (*.*)|*.*";
				 if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					 txtRSSuTorrentPath.Text = openFile.FileName;
			 }
	private void bnUTBrowseResumeDat_Click(object sender, System.EventArgs e)
			 {
				 openFile.FileName = txtUTResumeDatPath.Text;
				 openFile.Filter = "resume.dat|resume.dat|All Files (*.*)|*.*";
				 if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					 txtUTResumeDatPath.Text = openFile.FileName;
			 }

			 private void SetupReplacementsGrid()
			 {
				 SourceGrid.Cells.Views.Cell titleModel = new SourceGrid.Cells.Views.Cell();
				 titleModel.BackColor = Color.SteelBlue;
				 titleModel.ForeColor = Color.White;
				 titleModel.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;

				 ReplacementsGrid.Columns.Clear();
				 ReplacementsGrid.Rows.Clear();

				 ReplacementsGrid.RowsCount = 1;
				 ReplacementsGrid.ColumnsCount = 3;
				 ReplacementsGrid.FixedRows = 1;
				 ReplacementsGrid.FixedColumns = 0;
				 ReplacementsGrid.Selection.EnableMultiSelection = false;

				 ReplacementsGrid.Columns[0].AutoSizeMode = SourceGrid.AutoSizeMode.EnableStretch | SourceGrid.AutoSizeMode.EnableAutoSize;
				 ReplacementsGrid.Columns[1].AutoSizeMode = SourceGrid.AutoSizeMode.EnableStretch | SourceGrid.AutoSizeMode.EnableAutoSize;
				 ReplacementsGrid.Columns[2].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize;

				 ReplacementsGrid.Columns[2].Width = 80;

				 ReplacementsGrid.AutoStretchColumnsToFitWidth = true;
				 ReplacementsGrid.Columns.StretchToFit();

				 ReplacementsGrid.Columns[0].Width = ReplacementsGrid.Columns[0].Width - 8; // allow for scrollbar
				 ReplacementsGrid.Columns[1].Width = ReplacementsGrid.Columns[1].Width - 8;

				 //////////////////////////////////////////////////////////////////////
				 // header row

				 SourceGrid.Cells.ColumnHeader h;
				 h = new SourceGrid.Cells.ColumnHeader("Search");
				 h.AutomaticSortEnabled = false;
				 ReplacementsGrid[0,0] = h;
				 ReplacementsGrid[0,0].View = titleModel;

				 h = new SourceGrid.Cells.ColumnHeader("Replace");
				 h.AutomaticSortEnabled = false;
				 ReplacementsGrid[0,1] = h;
				 ReplacementsGrid[0,1].View = titleModel;

				 h = new SourceGrid.Cells.ColumnHeader("Case Ins.");
				 h.AutomaticSortEnabled = false;
				 ReplacementsGrid[0,2] = h;
				 ReplacementsGrid[0,2].View = titleModel;
			 }


			 private void AddNewReplacementRow(string from, string to, bool ins)
			 {
				 SourceGrid.Cells.Views.Cell roModel = new SourceGrid.Cells.Views.Cell();
				 roModel.ForeColor = Color.Gray;

				 int r = ReplacementsGrid.RowsCount;
				 ReplacementsGrid.RowsCount = r + 1;
				 ReplacementsGrid[r, 0] = new SourceGrid.Cells.Cell(from, (new string("")).GetType());
				 ReplacementsGrid[r, 1] = new SourceGrid.Cells.Cell(to, (new string("")).GetType());
				 ReplacementsGrid[r, 2] = new SourceGrid.Cells.CheckBox(null, ins);
				 if (!string.IsNullOrEmpty(from) && (TVSettings.CompulsoryReplacements().IndexOf(from) != -1))
				 {
					 ReplacementsGrid[r,0].Editor.EnableEdit = false;
					 ReplacementsGrid[r,0].View = roModel;
				 }
			 }


			 private void SetupRSSGrid()
			 {
				 SourceGrid.Cells.Views.Cell titleModel = new SourceGrid.Cells.Views.Cell();
				 titleModel.BackColor = Color.SteelBlue;
				 titleModel.ForeColor = Color.White;
				 titleModel.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;

				 RSSGrid.Columns.Clear();
				 RSSGrid.Rows.Clear();

				 RSSGrid.RowsCount = 1;
				 RSSGrid.ColumnsCount = 1;
				 RSSGrid.FixedRows = 1;
				 RSSGrid.FixedColumns = 0;
				 RSSGrid.Selection.EnableMultiSelection = false;

				 RSSGrid.Columns[0].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize | SourceGrid.AutoSizeMode.EnableStretch;

				 RSSGrid.AutoStretchColumnsToFitWidth = true;
				 RSSGrid.Columns.StretchToFit();

				 //////////////////////////////////////////////////////////////////////
				 // header row

				 SourceGrid.Cells.ColumnHeader h;
				 h = new SourceGrid.Cells.ColumnHeader("URL");
				 h.AutomaticSortEnabled = false;
				 RSSGrid[0,0] = h;
				 RSSGrid[0,0].View = titleModel;
			 }

			 private void AddNewRSSRow(string text)
			 {
				 int r = RSSGrid.RowsCount;
				 RSSGrid.RowsCount = r + 1;
				 RSSGrid[r, 0] = new SourceGrid.Cells.Cell(text, (new string("")).GetType());
			 }

	private void bnRSSAdd_Click(object sender, System.EventArgs e)
			 {
				 AddNewRSSRow(null);
			 }
	private void bnRSSRemove_Click(object sender, System.EventArgs e)
			 {
				 // multiselection is off, so we can cheat...
				 int[] rowsIndex = RSSGrid.Selection.GetSelectionRegion().GetRowsIndex();
				 if (rowsIndex.Length)
					 RSSGrid.Rows.Remove(rowsIndex[0]);
			 }
	private void bnRSSGo_Click(object sender, System.EventArgs e)
			 {
				 // multiselection is off, so we can cheat...
				 int[] rowsIndex = RSSGrid.Selection.GetSelectionRegion().GetRowsIndex();

				 if (rowsIndex.Length)
					 TVDoc.SysOpen((string)(RSSGrid[rowsIndex[0],0].Value));
			 }
	private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
			 {
				 if (tabControl1.SelectedIndex == 5) // gone to languages tab
					 SetupLanguages();
			 }
			 private void SetupLanguages()
			 {
				 TheTVDB db = mDoc.GetTVDB(true, "Preferences-SL");
				 if (!db.Connected)
				 {
					 lbLangs.Items.Add("Please Wait");
					 lbLangs.Items.Add("Connecting...");
					 lbLangs.Update();
					 db.Connect();
				 }

				 // make our list
				 // add already prioritised items (that still exist)
				 LangList = new System.Collections.Generic.List<string >();
				 foreach (string s in db.LanguagePriorityList)
					 if (db.LanguageList.ContainsKey(s))
						 LangList.Add(s);

				 // add items that haven't been prioritised
				 foreach (KeyValuePair<string , string > k in db.LanguageList)
					 if (!LangList.Contains(k.Key))
						 LangList.Add(k.Key);
				 db.Unlock("Preferences-SL");

				 FillLanguageList();
			 }
			 private void FillLanguageList()
			 {
				 TheTVDB db = mDoc.GetTVDB(true, "Preferences-FLL");
				 lbLangs.BeginUpdate();
				 lbLangs.Items.Clear();
				 foreach (string l in LangList)
					 lbLangs.Items.Add(db.LanguageList[l]);
				 lbLangs.EndUpdate();
				 db.Unlock("Preferences-FLL");

			 }
	private void bnLangDown_Click(object sender, System.EventArgs e)
			 {
				 int n = lbLangs.SelectedIndex;
				 if (n == -1)
					 return;

				 if (n < (LangList.Count - 1))
				 {
					 LangList.Reverse(n,2);
					 FillLanguageList();
					 lbLangs.SelectedIndex = n+1;
				 }
			 }
	private void bnLangUp_Click(object sender, System.EventArgs e)
			 {
				 int n = lbLangs.SelectedIndex;
				 if (n == -1)
					 return;
				 if (n > 0)
				 {
					 LangList.Reverse(n-1,2);
					 FillLanguageList();
					 lbLangs.SelectedIndex = n-1;
				 }
			 }

	private void cbMissing_CheckedChanged(object sender, System.EventArgs e)
			 {
				 ScanOptEnableDisable();
			 }
			 private void ScanOptEnableDisable()
			 {
				 bool e = cbMissing.Checked;
				 cbSearchRSS.Enabled = e;
				 cbSearchLocally.Enabled = e;
				 cbEpImgs.Enabled = e;
				 cbNFOs.Enabled = e;
				 cbCheckuTorrent.Enabled = e;

				 bool e2 = cbSearchLocally.Checked;
				 cbLeaveOriginals.Enabled = e && e2;
			 }

	private void cbSearchLocally_CheckedChanged(object sender, System.EventArgs e)
			 {
				 ScanOptEnableDisable();
			 }
	private void bnReplaceAdd_Click(object sender, System.EventArgs e)
			 {
				 AddNewReplacementRow(null, null, false);
			 }
	private void bnReplaceRemove_Click(object sender, System.EventArgs e)
			 {
				 // multiselection is off, so we can cheat...
				 int[] rowsIndex = ReplacementsGrid.Selection.GetSelectionRegion().GetRowsIndex();
				 if (rowsIndex.Length)
				 {
					 // don't delete compulsory items
					 int n = rowsIndex[0];
					 string from = (string)(ReplacementsGrid[n,0].Value);
					 if (string.IsNullOrEmpty(from) || (TVSettings.CompulsoryReplacements().IndexOf(from) == -1))
						 ReplacementsGrid.Rows.Remove(n);
				 }
			 }
	}
}