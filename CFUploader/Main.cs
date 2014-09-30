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
        
        public static string GetAudioFiles(string path) 
        {
            
            //string folder = "D:\\Music_Share\\Music\\Alnaes, Eyvind";
            string folder = path;
            string fileType = "*.mp3";

            AudioFolderFiles mp3Folder = new AudioFolderFiles(folder, fileType); 
            string[] files = mp3Folder.AudioFiles;
            List<Track> mp3Files = new List<Track>();
            List<string> album_art = new List<string>();
            Hashtable dataset = new Hashtable();
           
            foreach(string file in files)
            {
                Mp3File mp3File = new Mp3File(file);
                Track track = new Track(mp3File);
                             

                album_art.Add(mp3File.AlbumArtPath);
                mp3Files.Add(track);             
            }

            dataset["dataset"] = mp3Files;
            string json = JsonConvert.SerializeObject(dataset);
            //SendRest.SendJson(json);
            SendRest.SendFilesToServer(album_art);

            return "";
        }

    }
}
