using System;
using System.Runtime.InteropServices;
using System.Text;

namespace winmmBasic
{
    class Mp3Player: IDisposable
    {
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string lpstrCommand,
            StringBuilder lpstrReturnString, int uReturnLength, IntPtr hwndCallback);//C#调用windows native dll 的方法
        public Mp3Player(string filename)
        {
            const string FORMAT = @"open ""{0}"" type mpegvideo alias mp3file";
            string command = string.Format(FORMAT, filename);
            mciSendString(command, null, 0, IntPtr.Zero);
        }

        public void play()
        {
            string command = "play mp3file";
            mciSendString(command, null, 0, IntPtr.Zero);
        }

        public void pause()
        {
            string command = "pause mp3file";
            mciSendString(command, null, 0, IntPtr.Zero);
        }

        public void stop()
        {
            string command = "stop mp3file";
            mciSendString(command, null, 0, IntPtr.Zero);
        }
        public void Dispose()
        {
            string command = "close mp3file";
            mciSendString(command, null, 0, IntPtr.Zero);
        }
    }
}
