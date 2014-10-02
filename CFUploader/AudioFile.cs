using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CFUploader
{
    public abstract class AudioFile
    {
        private string _albumArtPath;

        public FileInfo File { get; set; }
        public string FullFileName { get; set; }
        public string FileType { get; set; }

        public string Album { get; set; }
        //public string AlbumArtPath { get; set; }        

        public string AlbumArtPath
        {
            get { return _albumArtPath; }
            set { _albumArtPath = (String.IsNullOrEmpty(value)) ? "no album art" : value; }
        }
        
        public string Artist { get; set; }
        public int Bitrate { get; set; }
        public uint DiscNumber { get; set; }
        public TimeSpan Duration { get; set; }
        public string Title { get; set; }
        public uint TrackNumber { get; set; }
        public string Md5Hash { get; set; }
        public string HasAlbumArt { get; set; }

        public AudioFile() { }

        protected AudioFile(string file) 
        {
            File = new FileInfo(file);
            FullFileName = File.FullName;
            Md5Hash = GetMd5();
        }

        private string GetMd5()
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = System.IO.File.OpenRead(FullFileName))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
                }                
            }
        }
    }
}
