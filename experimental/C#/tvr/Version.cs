public static class GlobalMembersVersion
{
		internal static string DisplayVersionString()
		{
			string v = "2.2.0a8";


	#if DEBUG
			return v + " (Debug)";
	#else
			return v;
	#endif
		}

		internal static bool ForceExperimentalOn()
		{
			return true; // ************************
		}
}
//
// Main website for TVRename is http://tvrename.com
//
// Source code available at http://code.google.com/p/tvrename/
//
// This code is released under GPLv3 http://www.gnu.org/licenses/gpl.html
//


namespace TVRename
{
}