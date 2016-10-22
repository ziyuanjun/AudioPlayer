using Microsoft.Win32;
using NAudio.Wave;
using System;
using System.Windows;

namespace wpfDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string filename = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
        }

        WaveOut waveout = null;
        WaveFileReader wavefilereader = null;

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            dispose();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "wav file|*.wav";
            if (openFileDialog.ShowDialog() != true) return;
            filename = openFileDialog.FileName;
            wavefilereader = new WaveFileReader(filename);
            waveout = new WaveOut();
            waveout.Init(wavefilereader);
        }
                    

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            if (waveout == null) return;
            waveout.Play();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            if (waveout == null) return;
            waveout.Pause();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            if (waveout == null) return;
            waveout.Stop();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            dispose();
        }

        private void dispose()
        {
            if (wavefilereader != null)
            {
                wavefilereader.Close();
                wavefilereader = null;
            }
            if (waveout != null)
            {
                waveout.Stop();
                waveout.Dispose();
                waveout = null;
            }
        }
    }
}
