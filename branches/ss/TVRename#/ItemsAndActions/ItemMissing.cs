﻿// 
// Main website for TVRename is http://tvrename.com
// 
// Source code available at http://code.google.com/p/tvrename/
// 
// This code is released under GPLv3 http://www.gnu.org/licenses/gpl.html
// 
namespace TVRename
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    public class ItemMissing : Item, ScanListItem
    {
        public string TheFileNoExt;

        public ItemMissing(ProcessedEpisode pe, string whereItShouldBeNoExt)
        {
            this.Episode = pe;
            this.TheFileNoExt = whereItShouldBeNoExt;
        }

        #region Item Members

        public bool SameAs(Item o)
        {
            return (o is ItemMissing) && (string.Compare((o as ItemMissing).TheFileNoExt, this.TheFileNoExt) == 0);
        }

        public int Compare(Item o)
        {
            ItemMissing miss = o as ItemMissing;
            return o == null ? 0 : (this.TheFileNoExt + this.Episode.Name).CompareTo(miss.TheFileNoExt + miss.Episode.Name);
        }

        #endregion

        #region ScanListItem Members

        public ProcessedEpisode Episode { get; private set; }

        public IgnoreItem Ignore
        {
            get
            {
                if (string.IsNullOrEmpty(this.TheFileNoExt))
                    return null;
                return new IgnoreItem(this.TheFileNoExt);
            }
        }

        public ListViewItem ScanListViewItem
        {
            get
            {
                ListViewItem lvi = new ListViewItem {
                                                        Text = this.Episode.SI.ShowName()
                                                    };

                lvi.SubItems.Add(this.Episode.SeasonNumber.ToString());
                lvi.SubItems.Add(this.Episode.NumsAsString());

                DateTime? dt = this.Episode.GetAirDateDT(true);
                if ((dt != null) && (dt.Value.CompareTo(DateTime.MaxValue)) != 0)
                    lvi.SubItems.Add(dt.Value.ToShortDateString());
                else
                    lvi.SubItems.Add("");

                FileInfo fi = new FileInfo(this.TheFileNoExt);
                lvi.SubItems.Add(fi.DirectoryName);
                lvi.SubItems.Add(fi.Name);

                lvi.Tag = this;

                return lvi;
            }
        }

        public int ScanListViewGroup
        {
            get { return 0; }
        }

        public string TargetFolder
        {
            get
            {
                if (string.IsNullOrEmpty(this.TheFileNoExt))
                    return null;
                return new FileInfo(this.TheFileNoExt).DirectoryName;
            }
        }

        public int IconNumber
        {
            get { return 1; }
        }

        #endregion
    }
}