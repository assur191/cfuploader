using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFUploader
{
    public class Main
    {
        private string folder = "D:\\Music_Share\\Music\\Alnaes, Eyvind";
        private string fileType = "*.mp3";
        
        public Main() 
        {
            AudioFolderFiles mp3Folder = new AudioFolderFiles(folder, fileType);            
        }
    }
}
