using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calexo.CaMuMa
{
    class Parameters
    {
        public const int ActionAddModify = 1;
        public const int ActionAddModifyForced = 2;
        public const int ActionAdd = 3;
        public const int ActionAddSpotify = 4;

        public String Notebook;
        public String Folder;
        public String DevKey;
        // Action = 1 : Add & Modify
        // Action = 2 : Add & Force replace
        // Action = 3 : Just Add
        // Action = 4 : Just Add Spotify
        public int Action;
        public bool AddSpotify;
        public bool ListOnlyMusicFiles;
        public bool SetNotesReadOnly;
        public bool AddIdTags;
    }
}
