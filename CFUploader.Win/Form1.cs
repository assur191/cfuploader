using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private void OnFolderButtonClick(object sender, EventArgs e)
        {
            List<string> mp3Files = Main.GetAudioFiles();

            listBox1.DataSource = mp3Files;
        }
    }
}
