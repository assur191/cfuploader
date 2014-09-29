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
        
        public static List<string> GetAudioFiles() 
        {
            string folder = "D:\\Music_Share\\Music\\Alnaes, Eyvind";
            string fileType = "*.mp3";

            AudioFolderFiles mp3Folder = new AudioFolderFiles(folder, fileType); 
            string[] files = mp3Folder.AudioFiles;
            List<string> mp3Files = new List<string>();
           
            foreach(string file in files)
            {
                AudioFile mp3File = new Mp3File(file);

                mp3Files.Add(mp3File.File.FullName);
            }

            return mp3Files;
        }
    }
}
