using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFUploader
{
    public static class Upload
    {
        public static void UploadAudioFiles(string data_text, string fileType)
        {
            string targetPath = "C:\\Users\\Trevor\\Homestead\\Projects\\classicalforce\\public\\tracks\\";
            string sourceFile;
            string destFile;
            string fileName;

            Dictionary<string, string> unserialized = JsonConvert.DeserializeObject<Dictionary<string, string>>(data_text);

            //foreach (KeyValuePair<string, string> entry in unserialized)
            //{
            //    Debug.WriteLine("key: " + entry.Key + " value: " + entry.Value);
            //    fileName = 
            //}

            sourceFile = unserialized["track_path"];
            int trackID = Convert.ToInt32(unserialized["track_id"]);
            fileName = "TR" + trackID.ToString("D10") + fileType;

            destFile = System.IO.Path.Combine(targetPath, fileName);
            System.IO.File.Copy(sourceFile, destFile, true);
        }
    }
}
