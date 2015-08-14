Here is a quick overview of how TVRename checks your media library, identifies missing episodes, and then locates the files to copy/move/rename across.  (Original version of this text from [issue #20](https://code.google.com/p/tvrename/issues/detail?id=#20)).

(1) TVRename has a list of shows (each is a "ShowItem").  Each show has a number of seasons, and each season has a number of episodes (episodes are downloaded from thetvdb, as "Episode" items.  Once the merge/rename/etc. rules are applied, they are turned into "ProcessedEpisode" classes).

(2) When you do a "Scan", for each of your shows, for each of the seasons, it determines the name of the folder(s) in your media library for that season (function RenameAndMissingCheck).  Automatic and manual folders feature here.  (ShowItem.AllFolderLocations)

(3) For each file in that folder, it determines the season and episode number of the file.

(3b) If the filename doesn't match the official filename template, create a new "action" to rename it.

(4) For each episode that has aired so far in the season, mark each one off as "found" as they are found in (3). (variable "localEps").

(5) After processing all files in the folder, anything not marked off in "localEps" is added as a "missing" action.

The checking of .NFO, .TBN, and folder.jpg files is mixed into the above, too, since its most convenient/efficient to do it at the same time.

At this point we have a list of episodes missing from the media library.  Next step is to figure out where they are:

(6) For each missing episode (function LookForMissingEps)

(7) For each file in the folder in the user's "Search Folders", see if it's name contains the show's name.  If so, determine the season and episode number. (functions FindMissingEp and FindSeasEp).

(7b) If the show has "use sequential number matching" turned on, then also look for the overall number of the episode (function MatchesSequentialNumber).

(8) If found, set up an "action" (i.e. thing to do pending the user's approval in the Scan tab) to rename/move/copy the file as appropriate, with the name as per the global "Filename template".