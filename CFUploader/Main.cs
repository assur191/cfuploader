using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
            Dictionary<string, string> album_art = new Dictionary<string, string>();
            Hashtable dataset = new Hashtable();
           
            foreach(string file in files)
            {
                Mp3File mp3File = new Mp3File(file);
                Track track = new Track(mp3File);                             

                album_art[mp3File.Md5Hash] = mp3File.AlbumArtPath;
                mp3Files.Add(track);             
            }

            if (files != null && files.Length > 0)
            {
                dataset["dataset"] = mp3Files;
                string json = JsonConvert.SerializeObject(dataset);
                string response = SendRest.SendJson(json);
                Debug.WriteLine(response);
                SendRest.SendFilesToServer(album_art);                
            }
            else 
            {
                Debug.WriteLine("No mp3 files found");
            }

            return "";
        }

        public static void Listen() 
        {
            Listener listener = new Listener();
        }

    }
}
