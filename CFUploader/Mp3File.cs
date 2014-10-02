using Id3;
using System;
using System.Drawing;
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
        private byte[] _albumArt;

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
            Artist = tag.FirstAlbumArtist;
            DiscNumber = tag.Disc;
            Title = tag.Title;
            TrackNumber = tag.Track;
            Bitrate = file.Properties.AudioBitrate;
            Duration = file.Properties.Duration;

            AlbumArtPath = "C:\\Users\\Trevor\\Documents\\TempImages\\" + Title + ".jpg";
            if (tag.Pictures != null && tag.Pictures.Length > 0) 
            {
                _albumArt = tag.Pictures[0].Data.Data;
                System.IO.File.WriteAllBytes(AlbumArtPath, _albumArt);
                HasAlbumArt = "true";
            }
            

                           
        }
    }
}
