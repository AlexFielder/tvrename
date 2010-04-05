// 
// Main website for TVRename is http://tvrename.com
// 
// Source code available at http://code.google.com/p/tvrename/
// 
// This code is released under GPLv3 http://www.gnu.org/licenses/gpl.html
// 
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

// Download and process a .RSS feed, primarily for getting .torrent files

namespace TVRename
{
    public class RSSItem
    {
        public int Episode;
        public int Season;
        public string ShowName;
        public string Title;
        public string URL;

        public RSSItem(string url, string title, int season, int episode, string showName)
        {
            this.URL = url;
            this.Season = season;
            this.Episode = episode;
            this.Title = title;
            this.ShowName = showName;
        }
    }

    public class RSSItemList : System.Collections.Generic.List<RSSItem>
    {
        private FNPRegexList Rexps; // only trustable while in DownloadRSS or its called functions

        public bool DownloadRSS(string URL, FNPRegexList rexps)
        {
            this.Rexps = rexps;

            System.Net.WebClient wc = new System.Net.WebClient();
            try
            {
                byte[] r = wc.DownloadData(URL);

                MemoryStream ms = new MemoryStream(r);

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreComments = true;
                settings.IgnoreWhitespace = true;
                XmlReader reader = XmlReader.Create(ms, settings);

                reader.Read();
                if (reader.Name != "xml")
                    return false;

                reader.Read();

                if (reader.Name != "rss")
                    return false;

                reader.Read();

                while (!reader.EOF)
                {
                    if ((reader.Name == "rss") && (!reader.IsStartElement()))
                        break;

                    if (reader.Name == "channel")
                    {
                        if (!this.ReadChannel(reader.ReadSubtree()))
                            return false;
                        reader.Read();
                    }
                    else
                        reader.ReadOuterXml();
                }

                ms.Close();
            }
            catch
            {
                return false;
            }
            finally
            {
                this.Rexps = null;
            }

            return true;
        }

        private bool ReadChannel(XmlReader r)
        {
            r.Read();
            r.Read();
            while (!r.EOF)
            {
                if ((r.Name == "channel") && (!r.IsStartElement()))
                    break;
                if (r.Name == "item")
                {
                    if (!this.ReadItem(r.ReadSubtree()))
                        return false;
                    r.Read();
                }
                else
                    r.ReadOuterXml();
            }
            return true;
        }

        public bool ReadItem(XmlReader r)
        {
            string title = "";
            string link = "";
            string description = "";

            r.Read();
            r.Read();
            while (!r.EOF)
            {
                if ((r.Name == "item") && (!r.IsStartElement()))
                    break;
                if (r.Name == "title")
                    title = r.ReadElementContentAsString();
                else if (r.Name == "description")
                    description = r.ReadElementContentAsString();
                else if ((r.Name == "link") && (string.IsNullOrEmpty(link)))
                    link = r.ReadElementContentAsString();
                else if ((r.Name == "enclosure") && (r.GetAttribute("type") == "application/x-bittorrent"))
                {
                    link = r.GetAttribute("url");
                    r.ReadOuterXml();
                }
                else
                    r.ReadOuterXml();
            }
            if ((string.IsNullOrEmpty(title)) || (string.IsNullOrEmpty(link)))
                return false;

            int season = -1;
            int episode = -1;
            string showName = "";

            TVDoc.FindSeasEp("", title, out season, out episode, null, this.Rexps);

            try
            {
                Match m = Regex.Match(description, "Show Name: (.*?)[;|$]", RegexOptions.IgnoreCase);
                if (m.Success)
                    showName = m.Groups[1].ToString();
                m = Regex.Match(description, "Season: ([0-9]+)", RegexOptions.IgnoreCase);
                if (m.Success)
                    season = int.Parse(m.Groups[1].ToString());
                m = Regex.Match(description, "Episode: ([0-9]+)", RegexOptions.IgnoreCase);
                if (m.Success)
                    episode = int.Parse(m.Groups[1].ToString());
            }
            catch
            {
            }

            if ((season != -1) && (episode != -1))
                this.Add(new RSSItem(link, title, season, episode, showName));

            return true;
        }
    }
}
