using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFUploader
{
    public abstract class AudioFile
    {
        public FileInfo File { get; set; }
        public string FullFileName { get; set; }
        public string FileType { get; set; }

        public string Album { get; set; }
        public string AlbumArtPath { get; set; }
        public string Artist { get; set; }
        public int Bitrate { get; set; }
        public uint DiscNumber { get; set; }
        public TimeSpan Duration { get; set; }
        public string Title { get; set; }
        public uint TrackNumber { get; set; }        

        public AudioFile() { }

        protected AudioFile(string file) 
        {
            File = new FileInfo(file);
            FullFileName = File.FullName;
        }
    }
}
