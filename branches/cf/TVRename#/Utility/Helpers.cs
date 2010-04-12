// 
// Main website for TVRename is http://tvrename.com
// 
// Source code available at http://code.google.com/p/tvrename/
// 
// This code is released under GPLv3 http://www.gnu.org/licenses/gpl.html
// 
using System.IO;
using System.Text.RegularExpressions;

// Helpful functions and classes

namespace TVRename
{
    public delegate void SetProgressDelegate(int percent);

    public class StringList : System.Collections.Generic.List<string>
    {
    }

    public static class Helpers
    {
        public static string ReadStringFixQuotesAndSpaces(System.Xml.XmlReader r)
        {
            string res = r.ReadElementContentAsString();
            res = res.Replace("\\'", "'");
            res = res.Replace("\\\"", "\"");
            res = res.Trim();
            return res;
        }

        public static System.Drawing.Color WarningColor()
        {
            return System.Drawing.Color.FromArgb(255, 210, 210);
        }

        public static string SimplifyName(string n)
        {
            n = n.ToLower();
            n = n.Replace("the", "");
            n = n.Replace("'", "");
            n = n.Replace("&", "");
            n = n.Replace("and", "");
            n = n.Replace("!", "");
            n = Regex.Replace(n, "[_\\W]+", " ");
            return n;
        }

        public static bool Same(FileInfo a, FileInfo b)
        {
            return string.Compare(a.FullName, b.FullName, true) == 0; // true->ignore case
        }

        public static bool Same(DirectoryInfo a, DirectoryInfo b)
        {
            string n1 = a.FullName;
            string n2 = b.FullName;
            if (!n1.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()))
                n1 = n1 + System.IO.Path.DirectorySeparatorChar;
            if (!n2.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()))
                n2 = n2 + System.IO.Path.DirectorySeparatorChar;

            return string.Compare(n1, n2, true) == 0; // true->ignore case
        }

        public static FileInfo FileInFolder(string dir, string fn)
        {
            return new FileInfo(string.Concat(dir, dir.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()) ? "" : System.IO.Path.DirectorySeparatorChar.ToString(), fn));
        }

        public static FileInfo FileInFolder(DirectoryInfo di, string fn)
        {
            return FileInFolder(di.FullName, fn);
        }
    }
}