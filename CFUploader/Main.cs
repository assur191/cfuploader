using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFUploader
{
    public class Main
    {           
        
        public static string GetAudioFiles() 
        {
            
            string folder = "D:\\Music_Share\\Music\\Alnaes, Eyvind";
            string fileType = "*.mp3";

            AudioFolderFiles mp3Folder = new AudioFolderFiles(folder, fileType); 
            string[] files = mp3Folder.AudioFiles;
            List<Track> mp3Files = new List<Track>();
            Hashtable dataset = new Hashtable();
           
            foreach(string file in files)
            {
                AudioFile mp3File = new Mp3File(file);
                Track track = new Track(mp3File);                

                mp3Files.Add(track);             
            }

            dataset["dataset"] = mp3Files;
            string json = JsonConvert.SerializeObject(dataset);
            SendRest.SendJson(json);

            return "";
        }

    }
}
