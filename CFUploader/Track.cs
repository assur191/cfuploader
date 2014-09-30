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
        public string orig_file_name { get; set; }
        public string track_title { get; set; }
        public int track_number_on_disc { get; set; }
        public string composer_last_name { get; set; }
        public string work_title { get; set; }
        public string album_title { get; set; }
        public string album_label { get; set; }
        public string track_path { get; set; }
        public string publisher { get; set; }
        public string composer_first_name { get; set; }
        public string composer_middle_name { get; set; }

        public Track(AudioFile file) 
        {
            Hashtable names = NameFilter.GetNames(file.Artist);            

            orig_file_name = file.File.Name;
            track_title = file.Title;
            track_number_on_disc = (int)file.TrackNumber;
            composer_first_name = (names.ContainsKey("first_name")) ? (string)names["first_name"] : "";
            composer_last_name = (names.ContainsKey("last_name")) ? (string)names["last_name"] : "";
            composer_middle_name = (names.ContainsKey("middle_name")) ? (string)names["middle_name"] : "";
            work_title = "";
            album_title = file.Album;
            album_label = "";
            track_path = file.FullFileName;
            publisher = "";
        }

        public string GetJson() 
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
