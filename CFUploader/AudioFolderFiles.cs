using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFUploader
{
    public class AudioFolderFiles
    {
        public string[] AudioFiles { get; set; }
        public bool IsValid { get; private set; }

        public AudioFolderFiles(string folder, string fileType)
        {
            if (Directory.Exists(folder))
            {
                AudioFiles = Directory.GetFiles(folder, fileType, SearchOption.AllDirectories);
                IsValid = true;
            }
            else 
            {
                IsValid = false;
            }          
            
        }
    }
}
