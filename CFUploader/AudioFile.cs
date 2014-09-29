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

        public AudioFile() { }

        public AudioFile(string file) 
        {
            File = new FileInfo(file);
        }
    }
}
