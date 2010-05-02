// 
// Main website for TVRename is http://tvrename.com
// 
// Source code available at http://code.google.com/p/tvrename/
// 
// This code is released under GPLv3 http://www.gnu.org/licenses/gpl.html
// 
using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

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
    public partial class Preferences : Form
    {
        private StringList LangList;
        private TVDoc mDoc;

        public Preferences(TVDoc doc, bool goToScanOpts)
        {
            this.LangList = null;

            this.InitializeComponent();

            this.SetupRSSGrid();
            this.SetupReplacementsGrid();

            this.mDoc = doc;

            if (goToScanOpts)
                this.tabControl1.SelectedTab = this.tpScanOptions;
        }

        private void OKButton_Click(object sender, System.EventArgs e)
        {
            if (!TVSettings.OKExtensionsString(this.txtVideoExtensions.Text))
            {
                MessageBox.Show("Extensions list must be separated by semicolons, and each extension must start with a dot.", "Preferences", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.tabControl1.SelectedIndex = 1;
                this.txtVideoExtensions.Focus();
                return;
            }
            if (!TVSettings.OKExtensionsString(this.txtOtherExtensions.Text))
            {
                MessageBox.Show("Extensions list must be separated by semicolons, and each extension must start with a dot.", "Preferences", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.tabControl1.SelectedIndex = 1;
                this.txtOtherExtensions.Focus();
                return;
            }
            TVSettings S = this.mDoc.Settings;
            S.Replacements.Clear();
            for (int i = 1; i < this.ReplacementsGrid.RowsCount; i++)
            {
                string from = (string) (this.ReplacementsGrid[i, 0].Value);
                string to = (string) (this.ReplacementsGrid[i, 1].Value);
                bool ins = (bool) (this.ReplacementsGrid[i, 2].Value);
                if (!string.IsNullOrEmpty(from))
                    S.Replacements.Add(new Replacement(from, to, ins));
            }

            S.ExportWTWRSS = this.cbWTWRSS.Checked;
            S.ExportWTWRSSTo = this.txtWTWRSS.Text;

            S.ExportMissingXML = this.cbMissingXML.Checked;
            S.ExportMissingXMLTo = this.txtMissingXML.Text;
            S.ExportMissingCSV = this.cbMissingCSV.Checked;
            S.ExportMissingCSVTo = this.txtMissingCSV.Text;
            S.ExportRenamingXML = this.cbRenamingXML.Checked;
            S.ExportRenamingXMLTo = this.txtRenamingXML.Text;
            S.ExportFOXML = this.cbFOXML.Checked;
            S.ExportFOXMLTo = this.txtFOXML.Text;

            S.WTWRecentDays = Convert.ToInt32(this.txtWTWDays.Text);
            S.StartupTab = this.cbStartupTab.SelectedIndex;
            S.NotificationAreaIcon = this.cbNotificationIcon.Checked;
            S.SetVideoExtensionsString(this.txtVideoExtensions.Text);
            S.SetOtherExtensionsString(this.txtOtherExtensions.Text);
            S.ExportRSSMaxDays = Convert.ToInt32(this.txtExportRSSMaxDays.Text);
            S.ExportRSSMaxShows = Convert.ToInt32(this.txtExportRSSMaxShows.Text);
            S.KeepTogether = this.cbKeepTogether.Checked;
            S.LeadingZeroOnSeason = this.cbLeadingZero.Checked;
            S.ShowInTaskbar = this.chkShowInTaskbar.Checked;
            S.RenameTxtToSub = this.cbTxtToSub.Checked;
            S.ShowEpisodePictures = this.cbShowEpisodePictures.Checked;
            S.AutoSelectShowInMyShows = this.cbAutoSelInMyShows.Checked;
            S.SpecialsFolderName = this.txtSpecialsFolderName.Text;

            S.ForceLowercaseFilenames = this.cbForceLower.Checked;
            S.IgnoreSamples = this.cbIgnoreSamples.Checked;

            S.uTorrentPath = this.txtRSSuTorrentPath.Text;
            S.ResumeDatPath = this.txtUTResumeDatPath.Text;

            S.SearchRSS = this.cbSearchRSS.Checked;
            S.EpImgs = this.cbEpImgs.Checked;
            S.NFOs = this.cbNFOs.Checked;
            S.FolderJpg = this.cbFolderJpg.Checked;
            S.RenameCheck = this.cbRenameCheck.Checked;
            S.MissingCheck = this.cbMissing.Checked;
            S.SearchLocally = this.cbSearchLocally.Checked;
            S.LeaveOriginals = this.cbLeaveOriginals.Checked;
            S.CheckuTorrent = this.cbCheckuTorrent.Checked;
            S.LookForDateInFilename = this.cbLookForAirdate.Checked;

            if (this.rbFolderFanArt.Checked)
                S.FolderJpgIs = TVSettings.FolderJpgIsType.FanArt;
            else if (this.rbFolderBanner.Checked)
                S.FolderJpgIs = TVSettings.FolderJpgIsType.Banner;
            else
                S.FolderJpgIs = TVSettings.FolderJpgIsType.Poster;

            if (this.LangList != null)
            {
                //only set if the language tab was visited

                TheTVDB db = this.mDoc.GetTVDB(true, "Preferences-OK");
                db.LanguagePriorityList = this.LangList;
                db.SaveCache();
                db.Unlock("Preferences-OK");
            }

            try
            {
                S.SampleFileMaxSizeMB = int.Parse(this.txtMaxSampleSize.Text);
            }
            catch
            {
                S.SampleFileMaxSizeMB = 50;
            }

            try
            {
                S.ParallelDownloads = int.Parse(this.txtParallelDownloads.Text);
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
            for (int i = 1; i < this.RSSGrid.RowsCount; i++)
            {
                string url = (string) (this.RSSGrid[i, 0].Value);
                if (!string.IsNullOrEmpty(url))
                    S.RSSURLs.Add(url);
            }

            this.mDoc.SetDirty();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Preferences_Load(object sender, System.EventArgs e)
        {
            TVSettings S = this.mDoc.Settings;
            int r = 1;

            foreach (Replacement R in S.Replacements)
            {
                this.AddNewReplacementRow(R.This, R.That, R.CaseInsensitive);
                r++;
            }

            this.txtMaxSampleSize.Text = S.SampleFileMaxSizeMB.ToString();

            this.cbWTWRSS.Checked = S.ExportWTWRSS;
            this.txtWTWRSS.Text = S.ExportWTWRSSTo;
            this.txtWTWDays.Text = S.WTWRecentDays.ToString();
            this.txtExportRSSMaxDays.Text = S.ExportRSSMaxDays.ToString();
            this.txtExportRSSMaxShows.Text = S.ExportRSSMaxShows.ToString();

            this.cbMissingXML.Checked = S.ExportMissingXML;
            this.txtMissingXML.Text = S.ExportMissingXMLTo;
            this.cbMissingCSV.Checked = S.ExportMissingCSV;
            this.txtMissingCSV.Text = S.ExportMissingCSVTo;

            this.cbRenamingXML.Checked = S.ExportRenamingXML;
            this.txtRenamingXML.Text = S.ExportRenamingXMLTo;

            this.cbFOXML.Checked = S.ExportFOXML;
            this.txtFOXML.Text = S.ExportFOXMLTo;

            this.cbStartupTab.SelectedIndex = S.StartupTab;
            this.cbNotificationIcon.Checked = S.NotificationAreaIcon;
            this.txtVideoExtensions.Text = S.GetVideoExtensionsString();
            this.txtOtherExtensions.Text = S.GetOtherExtensionsString();

            this.cbKeepTogether.Checked = S.KeepTogether;
            this.cbKeepTogether_CheckedChanged(null, null);

            this.cbLeadingZero.Checked = S.LeadingZeroOnSeason;
            this.chkShowInTaskbar.Checked = S.ShowInTaskbar;
            this.cbTxtToSub.Checked = S.RenameTxtToSub;
            this.cbShowEpisodePictures.Checked = S.ShowEpisodePictures;
            this.cbAutoSelInMyShows.Checked = S.AutoSelectShowInMyShows;
            this.txtSpecialsFolderName.Text = S.SpecialsFolderName;
            this.cbForceLower.Checked = S.ForceLowercaseFilenames;
            this.cbIgnoreSamples.Checked = S.IgnoreSamples;
            this.txtRSSuTorrentPath.Text = S.uTorrentPath;
            this.txtUTResumeDatPath.Text = S.ResumeDatPath;

            this.txtParallelDownloads.Text = S.ParallelDownloads.ToString();

            this.cbSearchRSS.Checked = S.SearchRSS;
            this.cbEpImgs.Checked = S.EpImgs;
            this.cbNFOs.Checked = S.NFOs;
            this.cbFolderJpg.Checked = S.FolderJpg;
            this.cbRenameCheck.Checked = S.RenameCheck;
            this.cbCheckuTorrent.Checked = S.CheckuTorrent;
            this.cbLookForAirdate.Checked = S.LookForDateInFilename;
            this.cbMissing.Checked = S.MissingCheck;
            this.cbSearchLocally.Checked = S.SearchLocally;
            this.cbLeaveOriginals.Checked = S.LeaveOriginals;

            this.EnableDisable(null, null);

            this.FillSearchFolderList();

            foreach (string s in S.RSSURLs)
                this.AddNewRSSRow(s);

            switch (S.FolderJpgIs)
            {
                case TVSettings.FolderJpgIsType.FanArt:
                    this.rbFolderFanArt.Checked = true;
                    break;
                case TVSettings.FolderJpgIsType.Banner:
                    this.rbFolderBanner.Checked = true;
                    break;
                default:
                    this.rbFolderPoster.Checked = true;
                    break;
            }
        }

        private void Browse(TextBox txt)
        {
            this.saveFile.FileName = txt.Text;
            if (this.saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                txt.Text = this.saveFile.FileName;
        }

        private void bnBrowseWTWRSS_Click(object sender, System.EventArgs e)
        {
            this.Browse(this.txtWTWRSS);
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
            if (!this.cbNotificationIcon.Checked)
                this.chkShowInTaskbar.Checked = true;
        }

        private void chkShowInTaskbar_CheckedChanged(object sender, System.EventArgs e)
        {
            if (!this.chkShowInTaskbar.Checked)
                this.cbNotificationIcon.Checked = true;
        }

        private void cbKeepTogether_CheckedChanged(object sender, System.EventArgs e)
        {
            this.cbTxtToSub.Enabled = this.cbKeepTogether.Checked;
        }

        private void bnBrowseMissingCSV_Click(object sender, System.EventArgs e)
        {
            this.Browse(this.txtMissingCSV);
        }

        private void bnBrowseMissingXML_Click(object sender, System.EventArgs e)
        {
            this.Browse(this.txtMissingXML);
        }

        private void bnBrowseRenamingXML_Click(object sender, System.EventArgs e)
        {
            this.Browse(this.txtRenamingXML);
        }

        private void bnBrowseFOXML_Click(object sender, System.EventArgs e)
        {
            this.Browse(this.txtFOXML);
        }

        private void EnableDisable(object sender, System.EventArgs e)
        {
            bool wtw = this.cbWTWRSS.Checked;
            this.txtWTWRSS.Enabled = wtw;
            this.bnBrowseWTWRSS.Enabled = wtw;
            this.label15.Enabled = wtw;
            this.label16.Enabled = wtw;
            this.label17.Enabled = wtw;
            this.txtExportRSSMaxDays.Enabled = wtw;
            this.txtExportRSSMaxShows.Enabled = wtw;

            bool fo = this.cbFOXML.Checked;
            this.txtFOXML.Enabled = fo;
            this.bnBrowseFOXML.Enabled = fo;

            bool ren = this.cbRenamingXML.Checked;
            this.txtRenamingXML.Enabled = ren;
            this.bnBrowseRenamingXML.Enabled = ren;

            bool misx = this.cbMissingXML.Checked;
            this.txtMissingXML.Enabled = misx;
            this.bnBrowseMissingXML.Enabled = misx;

            bool misc = this.cbMissingCSV.Checked;
            this.txtMissingCSV.Enabled = misc;
            this.bnBrowseMissingCSV.Enabled = misc;
        }

        private void bnAddSearchFolder_Click(object sender, System.EventArgs e)
        {
            int n = this.lbSearchFolders.SelectedIndex;
            if (n != -1)
                this.folderBrowser.SelectedPath = this.mDoc.SearchFolders[n];
            else
                this.folderBrowser.SelectedPath = "";

            if (this.folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.mDoc.SearchFolders.Add(this.folderBrowser.SelectedPath);
                this.mDoc.SetDirty();
            }

            this.FillSearchFolderList();
        }

        private void bnRemoveSearchFolder_Click(object sender, System.EventArgs e)
        {
            int n = this.lbSearchFolders.SelectedIndex;
            if (n == -1)
                return;

            this.mDoc.SearchFolders.RemoveAt(n);
            this.mDoc.SetDirty();

            this.FillSearchFolderList();
        }

        private void bnOpenSearchFolder_Click(object sender, System.EventArgs e)
        {
            int n = this.lbSearchFolders.SelectedIndex;
            if (n == -1)
                return;
            TVDoc.SysOpen(this.mDoc.SearchFolders[n]);
        }

        private void FillSearchFolderList()
        {
            this.lbSearchFolders.Items.Clear();
            this.mDoc.SearchFolders.Sort();
            foreach (string efi in this.mDoc.SearchFolders)
                this.lbSearchFolders.Items.Add(efi);
        }

        private void lbSearchFolders_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                this.bnRemoveSearchFolder_Click(null, null);
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
            string[] files = (string[]) (e.Data.GetData(DataFormats.FileDrop));
            for (int i = 0; i < files.Length; i++)
            {
                string path = files[i];
                DirectoryInfo di;
                try
                {
                    di = new DirectoryInfo(path);
                    if (di.Exists)
                        this.mDoc.SearchFolders.Add(path.ToLower());
                }
                catch
                {
                }
            }
            this.mDoc.SetDirty();
            this.FillSearchFolderList();
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
            this.openFile.FileName = this.txtRSSuTorrentPath.Text;
            this.openFile.Filter = "utorrent.exe|utorrent.exe|All Files (*.*)|*.*";
            if (this.openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.txtRSSuTorrentPath.Text = this.openFile.FileName;
        }

        private void bnUTBrowseResumeDat_Click(object sender, System.EventArgs e)
        {
            this.openFile.FileName = this.txtUTResumeDatPath.Text;
            this.openFile.Filter = "resume.dat|resume.dat|All Files (*.*)|*.*";
            if (this.openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.txtUTResumeDatPath.Text = this.openFile.FileName;
        }

        private void SetupReplacementsGrid()
        {
            SourceGrid.Cells.Views.Cell titleModel = new SourceGrid.Cells.Views.Cell();
            titleModel.BackColor = Color.SteelBlue;
            titleModel.ForeColor = Color.White;
            titleModel.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;

            this.ReplacementsGrid.Columns.Clear();
            this.ReplacementsGrid.Rows.Clear();

            this.ReplacementsGrid.RowsCount = 1;
            this.ReplacementsGrid.ColumnsCount = 3;
            this.ReplacementsGrid.FixedRows = 1;
            this.ReplacementsGrid.FixedColumns = 0;
            this.ReplacementsGrid.Selection.EnableMultiSelection = false;

            this.ReplacementsGrid.Columns[0].AutoSizeMode = SourceGrid.AutoSizeMode.EnableStretch | SourceGrid.AutoSizeMode.EnableAutoSize;
            this.ReplacementsGrid.Columns[1].AutoSizeMode = SourceGrid.AutoSizeMode.EnableStretch | SourceGrid.AutoSizeMode.EnableAutoSize;
            this.ReplacementsGrid.Columns[2].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize;

            this.ReplacementsGrid.Columns[2].Width = 80;

            this.ReplacementsGrid.AutoStretchColumnsToFitWidth = true;
            this.ReplacementsGrid.Columns.StretchToFit();

            this.ReplacementsGrid.Columns[0].Width = this.ReplacementsGrid.Columns[0].Width - 8; // allow for scrollbar
            this.ReplacementsGrid.Columns[1].Width = this.ReplacementsGrid.Columns[1].Width - 8;

            //////////////////////////////////////////////////////////////////////
            // header row

            SourceGrid.Cells.ColumnHeader h;
            h = new SourceGrid.Cells.ColumnHeader("Search");
            h.AutomaticSortEnabled = false;
            this.ReplacementsGrid[0, 0] = h;
            this.ReplacementsGrid[0, 0].View = titleModel;

            h = new SourceGrid.Cells.ColumnHeader("Replace");
            h.AutomaticSortEnabled = false;
            this.ReplacementsGrid[0, 1] = h;
            this.ReplacementsGrid[0, 1].View = titleModel;

            h = new SourceGrid.Cells.ColumnHeader("Case Ins.");
            h.AutomaticSortEnabled = false;
            this.ReplacementsGrid[0, 2] = h;
            this.ReplacementsGrid[0, 2].View = titleModel;
        }

        private void AddNewReplacementRow(string from, string to, bool ins)
        {
            SourceGrid.Cells.Views.Cell roModel = new SourceGrid.Cells.Views.Cell();
            roModel.ForeColor = Color.Gray;

            int r = this.ReplacementsGrid.RowsCount;
            this.ReplacementsGrid.RowsCount = r + 1;
            this.ReplacementsGrid[r, 0] = new SourceGrid.Cells.Cell(from, typeof(string));
            this.ReplacementsGrid[r, 1] = new SourceGrid.Cells.Cell(to, typeof(string));
            this.ReplacementsGrid[r, 2] = new SourceGrid.Cells.CheckBox(null, ins);
            if (!string.IsNullOrEmpty(from) && (TVSettings.CompulsoryReplacements().IndexOf(from) != -1))
            {
                this.ReplacementsGrid[r, 0].Editor.EnableEdit = false;
                this.ReplacementsGrid[r, 0].View = roModel;
            }
        }

        private void SetupRSSGrid()
        {
            SourceGrid.Cells.Views.Cell titleModel = new SourceGrid.Cells.Views.Cell();
            titleModel.BackColor = Color.SteelBlue;
            titleModel.ForeColor = Color.White;
            titleModel.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;

            this.RSSGrid.Columns.Clear();
            this.RSSGrid.Rows.Clear();

            this.RSSGrid.RowsCount = 1;
            this.RSSGrid.ColumnsCount = 1;
            this.RSSGrid.FixedRows = 1;
            this.RSSGrid.FixedColumns = 0;
            this.RSSGrid.Selection.EnableMultiSelection = false;

            this.RSSGrid.Columns[0].AutoSizeMode = SourceGrid.AutoSizeMode.EnableAutoSize | SourceGrid.AutoSizeMode.EnableStretch;

            this.RSSGrid.AutoStretchColumnsToFitWidth = true;
            this.RSSGrid.Columns.StretchToFit();

            //////////////////////////////////////////////////////////////////////
            // header row

            SourceGrid.Cells.ColumnHeader h;
            h = new SourceGrid.Cells.ColumnHeader("URL");
            h.AutomaticSortEnabled = false;
            this.RSSGrid[0, 0] = h;
            this.RSSGrid[0, 0].View = titleModel;
        }

        private void AddNewRSSRow(string text)
        {
            int r = this.RSSGrid.RowsCount;
            this.RSSGrid.RowsCount = r + 1;
            this.RSSGrid[r, 0] = new SourceGrid.Cells.Cell(text, typeof(string));
        }

        private void bnRSSAdd_Click(object sender, System.EventArgs e)
        {
            this.AddNewRSSRow(null);
        }

        private void bnRSSRemove_Click(object sender, System.EventArgs e)
        {
            // multiselection is off, so we can cheat...
            int[] rowsIndex = this.RSSGrid.Selection.GetSelectionRegion().GetRowsIndex();
            if (rowsIndex.Length > 0)
                this.RSSGrid.Rows.Remove(rowsIndex[0]);
        }

        private void bnRSSGo_Click(object sender, System.EventArgs e)
        {
            // multiselection is off, so we can cheat...
            int[] rowsIndex = this.RSSGrid.Selection.GetSelectionRegion().GetRowsIndex();

            if (rowsIndex.Length > 0)
                TVDoc.SysOpen((string) (this.RSSGrid[rowsIndex[0], 0].Value));
        }

        private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 5) // gone to languages tab
                this.SetupLanguages();
        }

        private void SetupLanguages()
        {
            TheTVDB db = this.mDoc.GetTVDB(true, "Preferences-SL");
            if (!db.Connected)
            {
                this.lbLangs.Items.Add("Please Wait");
                this.lbLangs.Items.Add("Connecting...");
                this.lbLangs.Update();
                db.Connect();
            }

            // make our list
            // add already prioritised items (that still exist)
            this.LangList = new StringList();
            foreach (string s in db.LanguagePriorityList)
            {
                if (db.LanguageList.ContainsKey(s))
                    this.LangList.Add(s);
            }

            // add items that haven't been prioritised
            foreach (System.Collections.Generic.KeyValuePair<string, string> k in db.LanguageList)
            {
                if (!this.LangList.Contains(k.Key))
                    this.LangList.Add(k.Key);
            }
            db.Unlock("Preferences-SL");

            this.FillLanguageList();
        }

        private void FillLanguageList()
        {
            TheTVDB db = this.mDoc.GetTVDB(true, "Preferences-FLL");
            this.lbLangs.BeginUpdate();
            this.lbLangs.Items.Clear();
            foreach (string l in this.LangList)
                this.lbLangs.Items.Add(db.LanguageList[l]);
            this.lbLangs.EndUpdate();
            db.Unlock("Preferences-FLL");
        }

        private void bnLangDown_Click(object sender, System.EventArgs e)
        {
            int n = this.lbLangs.SelectedIndex;
            if (n == -1)
                return;

            if (n < (this.LangList.Count - 1))
            {
                this.LangList.Reverse(n, 2);
                this.FillLanguageList();
                this.lbLangs.SelectedIndex = n + 1;
            }
        }

        private void bnLangUp_Click(object sender, System.EventArgs e)
        {
            int n = this.lbLangs.SelectedIndex;
            if (n == -1)
                return;
            if (n > 0)
            {
                this.LangList.Reverse(n - 1, 2);
                this.FillLanguageList();
                this.lbLangs.SelectedIndex = n - 1;
            }
        }

        private void cbMissing_CheckedChanged(object sender, System.EventArgs e)
        {
            this.ScanOptEnableDisable();
        }

        private void ScanOptEnableDisable()
        {
            bool e = this.cbMissing.Checked;
            this.cbSearchRSS.Enabled = e;
            this.cbSearchLocally.Enabled = e;
            this.cbEpImgs.Enabled = e;
            this.cbNFOs.Enabled = e;
            this.cbCheckuTorrent.Enabled = e;

            bool e2 = this.cbSearchLocally.Checked;
            this.cbLeaveOriginals.Enabled = e && e2;
        }

        private void cbSearchLocally_CheckedChanged(object sender, System.EventArgs e)
        {
            this.ScanOptEnableDisable();
        }

        private void bnReplaceAdd_Click(object sender, System.EventArgs e)
        {
            this.AddNewReplacementRow(null, null, false);
        }

        private void bnReplaceRemove_Click(object sender, System.EventArgs e)
        {
            // multiselection is off, so we can cheat...
            int[] rowsIndex = this.ReplacementsGrid.Selection.GetSelectionRegion().GetRowsIndex();
            if (rowsIndex.Length > 0)
            {
                // don't delete compulsory items
                int n = rowsIndex[0];
                string from = (string) (this.ReplacementsGrid[n, 0].Value);
                if (string.IsNullOrEmpty(from) || (TVSettings.CompulsoryReplacements().IndexOf(from) == -1))
                    this.ReplacementsGrid.Rows.Remove(n);
            }
        }
    }
}