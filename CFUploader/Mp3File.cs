using Id3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TagLib;

namespace CFUploader
{
    public class Mp3File : AudioFile
    {
        public Mp3File(string file) : base(file) 
        {
            FileType = "MP3";
            GetID3Data();
        }        

        public void GetID3Data() 
        {
            TagLib.File file = TagLib.File.Create(FullFileName);
            var tag = file.GetTag(TagLib.TagTypes.Id3v2);

            Album = tag.Album;
            AlbumArtPath = "C:\\Users\\Trevor\\Documents\\TempImages\\" + Title + ".jpg";
            Artist = tag.FirstAlbumArtist;
            DiscNumber = tag.Disc;
            Title = tag.Title;
            TrackNumber = tag.Track;
            Bitrate = file.Properties.AudioBitrate;
            Duration = file.Properties.Duration;        

        }
    }
}
