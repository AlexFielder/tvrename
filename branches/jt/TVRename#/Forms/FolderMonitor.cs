// 
// Main website for TVRename is http://tvrename.com
// 
// Source code available at http://code.google.com/p/tvrename/
// 
// This code is released under GPLv3 http://www.gnu.org/licenses/gpl.html
// 
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;

namespace TVRename
{
    /// <summary>
    /// Summary for FolderMonitor
    ///
    /// WARNING: If you change the name of this class, you will need to change the
    ///          'Resource File Name' property for the managed resource compiler tool
    ///          associated with all .resx files this class depends on.  Otherwise,
    ///          the designers will not be able to interact properly with localized
    ///          resources associated with this form.
    /// </summary>
    public partial class FolderMonitor : Form
    {
        public FolderMonitorProgress FMP;
        public int FMPPercent;
        public bool FMPStopNow;
        public string FMPUpto;
        private readonly TVDoc mDoc;
        // private int mInternalChange;
        // private TheTVDBCodeFinder mTCCF;

        public FolderMonitor(TVDoc doc)
        {
            this.mDoc = doc;

            this.InitializeComponent();

            this.FillFolderStringLists();
        }

        public void FMPShower()
        {
            this.FMP = new FolderMonitorProgress(this);
            this.FMP.ShowDialog();
            this.FMP = null;
        }

        private void bnClose_Click(object sender, System.EventArgs e)
        {
            bool confirmClose = false;
            foreach (FolderMonitorEntry fme in this.mDoc.AddItems)
            {
                if (fme.CodeKnown)
                {
                    confirmClose = true;
                    break;
                }
            }
            if (confirmClose)
            {
                if (DialogResult.OK != MessageBox.Show("Close without adding identified shows to \"My Shows\"?", "Folder Monitor", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                {
                    return;
                }
            }

            this.Close();
        }

        private void FillFolderStringLists()
        {
            this.mDoc.MonitorFolders.Sort();
            this.mDoc.IgnoreFolders.Sort();
            
            this.lstFMMonitorFolders.BeginUpdate();
            this.lstFMMonitorFolders.Items.Clear();
            
            foreach (string folder in this.mDoc.MonitorFolders)
                this.lstFMMonitorFolders.Items.Add(folder);

            this.lstFMMonitorFolders.EndUpdate();

            this.lstFMIgnoreFolders.BeginUpdate();
            this.lstFMIgnoreFolders.Items.Clear();

            foreach (string folder in this.mDoc.IgnoreFolders)
                this.lstFMIgnoreFolders.Items.Add(folder);

            this.lstFMIgnoreFolders.EndUpdate();
        }

        private void bnRemoveMonFolder_Click(object sender, System.EventArgs e)
        {
            for (int i = this.lstFMMonitorFolders.SelectedIndices.Count - 1; i >= 0; i--)
            {
                int n = this.lstFMMonitorFolders.SelectedIndices[i];
                this.mDoc.MonitorFolders.RemoveAt(n);
            }
            this.mDoc.SetDirty();
            this.FillFolderStringLists();
        }

        private void bnRemoveIgFolder_Click(object sender, System.EventArgs e)
        {
            for (int i = this.lstFMIgnoreFolders.SelectedIndices.Count - 1; i >= 0; i--)
            {
                int n = this.lstFMIgnoreFolders.SelectedIndices[i];
                this.mDoc.IgnoreFolders.RemoveAt(n);
            }
            this.mDoc.SetDirty();
            this.FillFolderStringLists();
        }

        private void bnAddMonFolder_Click(object sender, System.EventArgs e)
        {
            this.folderBrowser.SelectedPath = "";
            if (this.lstFMMonitorFolders.SelectedIndex != -1)
            {
                int n = this.lstFMMonitorFolders.SelectedIndex;
                this.folderBrowser.SelectedPath = this.mDoc.MonitorFolders[n];
            }

            if (this.folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.mDoc.MonitorFolders.Add(this.folderBrowser.SelectedPath.ToLower());
                this.mDoc.SetDirty();
                this.FillFolderStringLists();
            }
        }

        private void bnAddIgFolder_Click(object sender, System.EventArgs e)
        {
            this.folderBrowser.SelectedPath = "";
            if (this.lstFMIgnoreFolders.SelectedIndex != -1)
                this.folderBrowser.SelectedPath = this.mDoc.IgnoreFolders[this.lstFMIgnoreFolders.SelectedIndex];

            if (this.folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.mDoc.IgnoreFolders.Add(this.folderBrowser.SelectedPath.ToLower());
                this.mDoc.SetDirty();
                this.FillFolderStringLists();
            }
        }

        private void bnOpenMonFolder_Click(object sender, System.EventArgs e)
        {
            if (this.lstFMMonitorFolders.SelectedIndex != -1)
                TVDoc.SysOpen(this.mDoc.MonitorFolders[this.lstFMMonitorFolders.SelectedIndex]);
        }

        private void bnOpenIgFolder_Click(object sender, System.EventArgs e)
        {
            if (this.lstFMIgnoreFolders.SelectedIndex != -1)
                TVDoc.SysOpen(this.mDoc.MonitorFolders[this.lstFMIgnoreFolders.SelectedIndex]);
        }

        private void lstFMMonitorFolders_DoubleClick(object sender, System.EventArgs e)
        {
            this.bnOpenMonFolder_Click(null, null);
        }

        private void lstFMIgnoreFolders_DoubleClick(object sender, System.EventArgs e)
        {

        }

        private void bnCheck_Click(object sender, System.EventArgs e)
        {
            this.DoCheck();
        }

        private void DoCheck()
        {
            tabControl1.SelectedTab = tbResults;
            tabControl1.Update();

            this.FMPStopNow = false;
            this.FMPUpto = "Checking folders";
            this.FMPPercent = 0;

            Thread fmpshower = new Thread(this.FMPShower);
            fmpshower.Name = "Folder Monitor Progress (Folder Check)";
            fmpshower.Start();

            while ((this.FMP == null) || (!this.FMP.Ready))
                Thread.Sleep(10);

            this.mDoc.MonitorCheckFolders(ref this.FMPStopNow, ref this.FMPPercent);
            
            this.FMPStopNow = true;

            this.FillFMNewShowList(false);

        }

        private void lstFMMonitorFolders_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.None;
            else
                e.Effect = DragDropEffects.Copy;
        }

        private void lstFMIgnoreFolders_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.None;
            else
                e.Effect = DragDropEffects.Copy;
        }

        private void lstFMMonitorFolders_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
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
                        this.mDoc.MonitorFolders.Add(path.ToLower());
                }
                catch
                {
                }
            }
            this.mDoc.SetDirty();
            this.FillFolderStringLists();
        }

        private void lstFMIgnoreFolders_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
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
                        this.mDoc.IgnoreFolders.Add(path.ToLower());
                }
                catch
                {
                }
            }
            this.mDoc.SetDirty();
            this.FillFolderStringLists();
        }

        private void lstFMMonitorFolders_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                this.bnRemoveMonFolder_Click(null, null);
        }

        private void lstFMIgnoreFolders_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                this.bnRemoveIgFolder_Click(null, null);
        }

        private void bnFullAuto_Click(object sender, System.EventArgs e)
        {
            if (this.mDoc.AddItems.Count == 0)
                return;

            this.FMPStopNow = false;
            this.FMPUpto = "Identifying shows";
            this.FMPPercent = 0;

            Thread fmpshower = new Thread(this.FMPShower);
            fmpshower.Name = "Folder Monitor Progress (Full Auto)";
            fmpshower.Start();

            while ((this.FMP == null) || (!this.FMP.Ready))
                Thread.Sleep(10);

            int n = 0;
            int n2 = this.mDoc.AddItems.Count;

            foreach (FolderMonitorEntry ai in this.mDoc.AddItems)
            {
                this.FMPPercent = 100 * n++ / n2;

               if (this.FMPStopNow)
                   break;

                if (ai.CodeKnown)
                    continue;

                int p = ai.Folder.LastIndexOf(System.IO.Path.DirectorySeparatorChar);
                this.FMPUpto = ai.Folder.Substring(p + 1); // +1 makes -1 "not found" result ok
                
                this.mDoc.MonitorGuessShowItem(ai);
                
                // update our display
                this.UpdateFMListItem(ai, true);
                this.lvFMNewShows.Update();
                this.Update();
            }
            this.FMPStopNow = true;
        }

        private void bnRemoveNewFolder_Click(object sender, System.EventArgs e)
        {
            if (this.lvFMNewShows.SelectedItems.Count == 0)
                return;
            foreach (ListViewItem lvi in this.lvFMNewShows.SelectedItems)
            {
                FolderMonitorEntry ai = (FolderMonitorEntry)(lvi.Tag);
                this.mDoc.AddItems.Remove(ai);
            }
            this.FillFMNewShowList(false);
        }

        private void bnIgnoreNewFolder_Click(object sender, System.EventArgs e)
        {
            if (this.lvFMNewShows.SelectedItems.Count == 0)
                return;

            DialogResult res = MessageBox.Show("Add selected folders to the folder monitor ignore list?", "Folder Monitor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res != DialogResult.Yes)
                return;

            foreach (ListViewItem lvi in this.lvFMNewShows.SelectedItems)
            {
                FolderMonitorEntry ai = (FolderMonitorEntry)(lvi.Tag);
                this.mDoc.IgnoreFolders.Add(ai.Folder.ToLower());
                this.mDoc.AddItems.Remove(ai);
            }
            this.mDoc.SetDirty();
            this.FillFMNewShowList(false);
            this.FillFolderStringLists();
        }

        private void lvFMNewShows_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.None;
            else
                e.Effect = DragDropEffects.Copy;
        }

        private void lvFMNewShows_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
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
                    {
                        this.mDoc.MonitorAddSingleFolder(di, true);
                        this.FillFMNewShowList(true);
                    }
                }
                catch
                {
                }
            }
        }

        private void lvFMNewShows_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                this.bnRemoveNewFolder_Click(null, null);
        }

        private void bnNewFolderOpen_Click(object sender, System.EventArgs e)
        {
            if (this.lvFMNewShows.SelectedItems.Count == 0)
                return;
            FolderMonitorEntry ai = this.lvFMNewShows.SelectedItems[0].Tag as FolderMonitorEntry;
            TVDoc.SysOpen(ai.Folder);
        }

        private void lvFMNewShows_DoubleClick(object sender, System.EventArgs e)
        {
            this.bnNewFolderOpen_Click(null, null);
        }

        private void FillFMNewShowList(bool keepSel)
        {
            System.Collections.Generic.List<int> sel = new System.Collections.Generic.List<int>();
            if (keepSel)
            {
                foreach (int i in this.lvFMNewShows.SelectedIndices)
                    sel.Add(i);
            }

            this.lvFMNewShows.BeginUpdate();
            this.lvFMNewShows.Items.Clear();

            foreach (FolderMonitorEntry ai in this.mDoc.AddItems)
            {
                ListViewItem lvi = new ListViewItem();
                UpdateResultEntry(ai, lvi);
                this.lvFMNewShows.Items.Add(lvi);
            }

            if (keepSel)
            {
                foreach (int i in sel)
                {
                    if (i < this.lvFMNewShows.Items.Count)
                        this.lvFMNewShows.Items[i].Selected = true;
                }
            }

            this.lvFMNewShows.EndUpdate();
            this.lvFMNewShows.Update();
        }

        private void UpdateResultEntry(FolderMonitorEntry ai, ListViewItem lvi)
        {
            lvi.SubItems.Clear();
            lvi.Text = ai.Folder;
            lvi.SubItems.Add(ai.CodeKnown ? this.mDoc.GetTVDB(false, "").GetSeries(ai.TVDBCode).Name : "");
            lvi.SubItems.Add(ai.HasSeasonFoldersGuess ? "Folder per season" : "Flat");
            lvi.SubItems.Add(ai.CodeKnown ? ai.TVDBCode.ToString() : "");
            lvi.Tag = ai;
        }

        private void UpdateFMListItem(FolderMonitorEntry ai, bool makevis)
        {
            foreach (ListViewItem lvi in this.lvFMNewShows.Items)
            {
                if (lvi.Tag != ai) // haven't found the entry yet
                    continue;

                UpdateResultEntry(ai, lvi);

                if (makevis)
                    lvi.EnsureVisible();

                break;
            }
        }

        private void bnFolderMonitorDone_Click(object sender, System.EventArgs e)
        {
            if (this.mDoc.AddItems.Count > 0)
            {
                DialogResult res = MessageBox.Show("Add identified shows to \"My Shows\"?", "Folder Monitor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res != DialogResult.Yes)
                    return;

                this.mDoc.MonitorAddAllToMyShows();
            }

            this.Close();
        }

        //private void ProcessAddItems(FolderMonitorEntryList toAdd)
        //{
        //    foreach (FolderMonitorEntry ai in toAdd)
        //    {
        //        if (ai.TheSeries == null)
        //            continue; // skip

        //        // see if there is a matching show item
        //        ShowItem found = null;
        //        foreach (ShowItem si in this.mDoc.GetShowItems(true))
        //        {
        //            if ((ai.TheSeries != null) && (ai.TheSeries.TVDBCode == si.TVDBCode))
        //            {
        //                found = si;
        //                break;
        //            }
        //        }
        //        this.mDoc.UnlockShowItems();
        //        if (found == null)
        //        {
        //           xxx 
        //               ShowItem si = new ShowItem(this.mDoc.GetTVDB(false, ""));
        //            si.TVDBCode = ai.TheSeries.TVDBCode;
        //            //si->ShowName = ai->TheSeries->Name;
        //            this.mDoc.GetShowItems(true).Add(si);
        //            this.mDoc.UnlockShowItems();
        //            this.mDoc.GenDict();
        //            found = si;
        //        }

        //        if ((ai.FolderMode == FolderModeEnum.kfmFolderPerSeason) || (ai.FolderMode == FolderModeEnum.kfmFlat))
        //        {
        //            found.AutoAdd_FolderBase = ai.Folder;
        //            found.AutoAdd_FolderPerSeason = ai.FolderMode == FolderModeEnum.kfmFolderPerSeason;
        //            string foldername = "Season ";

        //            foreach (DirectoryInfo di in new DirectoryInfo(ai.Folder).GetDirectories("*Season *"))
        //            {
        //                string s = di.FullName;
        //                string f = ai.Folder;
        //                if (!f.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()))
        //                    f = f + System.IO.Path.DirectorySeparatorChar;
        //                f = Regex.Escape(f);
        //                s = Regex.Replace(s, f + "(.*Season ).*", "$1", RegexOptions.IgnoreCase);
        //                if (!string.IsNullOrEmpty(s))
        //                {
        //                    foldername = s;
        //                    break;
        //                }
        //            }

        //            found.AutoAdd_SeasonFolderName = foldername;
        //        }

        //        if ((ai.FolderMode == FolderModeEnum.kfmSpecificSeason) && (ai.SpecificSeason != -1))
        //        {
        //            if (!found.ManualFolderLocations.ContainsKey(ai.SpecificSeason))
        //                found.ManualFolderLocations[ai.SpecificSeason] = new StringList();
        //            found.ManualFolderLocations[ai.SpecificSeason].Add(ai.Folder);
        //        }

        //        this.mDoc.Stats().AutoAddedShows++;
        //    }

        //    this.mDoc.Dirty();
        //    toAdd.Clear();

        //    this.FillFMNewShowList(true);
        //}

        //private void GuessAll() // not all -> selected only
        //{
        //    foreach (FolderMonitorEntry ai in this.mDoc.AddItems)
        //        this.mDoc.MonitorGuessShowItem(ai);
        //    this.FillFMNewShowList(false);
        //}

        private void bnVisitTVcom_Click(object sender, System.EventArgs e)
        {
            if (lvFMNewShows.SelectedItems.Count == 0)
                return;

            int code = (this.lvFMNewShows.SelectedItems[0].Tag as FolderMonitorEntry).TVDBCode;
            if (code != -1)
              TVDoc.SysOpen(this.mDoc.GetTVDB(false, "").WebsiteURL(code, -1, false));
        }

        private void bnCheck2_Click(object sender, System.EventArgs e)
        {
            this.DoCheck();
        }

        private void lvFMNewShows_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            bnEditEntry_Click(null, null);
        }

        private void bnEditEntry_Click(object sender, System.EventArgs e)
        {
            if (lvFMNewShows.SelectedItems.Count == 0)
                return;

            FolderMonitorEntry fme = this.lvFMNewShows.SelectedItems[0].Tag as FolderMonitorEntry;
            EditEntry(fme);
            this.UpdateFMListItem(fme, true);
        }

        private void EditEntry(FolderMonitorEntry fme)
        {
            FolderMonitorEdit ed = new FolderMonitorEdit(this.mDoc.GetTVDB(false, ""), fme);
            if ((ed.ShowDialog() != DialogResult.OK )|| (ed.Code == -1))
                return;

            fme.TVDBCode = ed.Code;
        }

    }
}