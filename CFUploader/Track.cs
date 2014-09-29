using CFUploader.RegExFilters;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFUploader
{
    public class Track
    {
        public string OriginalFileName { get; set; }
        public string TrackTitle { get; set; }
        public int    TrackNumberOnDisc  { get; set; }
        public string ComposerLastName { get; set; }
        public string WorkTitle { get; set; }
        public string AlbumTitle { get; set; }
        public string AlbumLabel { get; set; }
        public string TrackPath { get; set; }
        public string Publisher { get; set; }
        public string ComposerFirstName { get; set; }
        public string ComposerMiddleName { get; set; }

        public Track(AudioFile file) 
        {
            Hashtable names = NameFilter.GetNames(file.Artist);            

            OriginalFileName = file.File.Name;
            TrackTitle = file.Title;
            TrackNumberOnDisc = (int) file.TrackNumber;
            ComposerFirstName = (names.ContainsKey("first_name")) ? (string) names["first_name"] : "";
            ComposerLastName = (names.ContainsKey("last_name")) ? (string) names["last_name"] : "";
            ComposerMiddleName = (names.ContainsKey("middle_name")) ? (string) names["middle_name"] : "";
            WorkTitle = "";
            AlbumTitle = file.Album;
            AlbumLabel = "";
            TrackPath = file.FullFileName;
            Publisher = "";
        }

        public string GetJson() 
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
