using System;
using System.Windows.Forms;
using winmmBasic;

namespace winmmForm
{
    public partial class MainForm : Form
    {
        Mp3Player _mp3player;
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openfiledialog = new OpenFileDialog())
            {
                openfiledialog.Filter = "Mp3|*.mp3";
                openfiledialog.InitialDirectory = @"\\VBOXSVR\ziyuan\Program\AudioPlayer\AudioFiles";
                if (openfiledialog.ShowDialog() == DialogResult.OK)
                {
                    _mp3player = new Mp3Player(openfiledialog.FileName);
                }
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if(_mp3player!=null)
               _mp3player.play();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if(_mp3player!=null)
               _mp3player.stop();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(_mp3player!=null)
               _mp3player.Dispose();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if(_mp3player!=null)
               _mp3player.pause();

        }
    }
}
