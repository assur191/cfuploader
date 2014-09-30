using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CFUploader.Win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Main.Listen();
        }

        private void OnFolderButtonClick(object sender, EventArgs e)
        {
            //int size = -1;
            //DialogResult result = folderBrowserDialog1.ShowDialog(); // Show the dialog.
            //if (result == DialogResult.OK) // Test result.
            //{
            //    string path = folderBrowserDialog1.SelectedPath;
            //    try
            //    {
            //        string resp = Main.GetAudioFiles(path);
            //    }
            //    catch (IOException)
            //    {
            //    }
            //}     

            Main.GetAudioFiles("D:\\Music_Share\\Music\\Alnaes, Eyvind");

            //listBox1.DataSource = mp3Files;
            //textBox1.Text = resp;
        }
    }
}
