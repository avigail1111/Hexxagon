using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Media;
//using System.Windows.Forms;
//using System.Linq;
using System.Threading;
using System.Runtime.InteropServices;


namespace Hexxagon
{
   public  class Sound1
    {
        public Sound1()
        {
         
        }
        private System.Media.SoundPlayer SP = new System.Media.SoundPlayer();
        Byte[] bytes = new Byte[256];
        //OpenFileDialog file = new OpenFileDialog();
        string CommandString;
        [DllImport("winmm.dll")] // DLL. for song
        private static extern long mciSendString(string lpstrCommand, StringBuilder lpstrReturnString, int uReturnLength, int hwndCallback);
        [DllImport("winmm.dll")] // DLL. for Vilum
        public static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);
        [DllImport("winmm.dll")] // DLL. for Vilum
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        // the button that start the mp3 player
        public  void Start()
        {
            CommandString = "open " + "\"" +Song_name+ "\"" + " type MPEGVideo alias MediaFile";
            mciSendString(CommandString, null, 0, 0);
            CommandString = "play MediaFile";
            mciSendString(CommandString, null, 0, 0);
        }
        // the button that stop the mp3 player
        public  void Stop()
        {
            CommandString = "stop MediaFile";
            mciSendString(CommandString, null, 0, 0);
        }
        // set up or down the voise volume
        public  void volume(int level)
        {
            // Calculate the volume that's being set
            int NewVolume = ((ushort.MaxValue / 10) * level);
            // Set the same volume for both the left and the right channels
            uint NewVolumeAllChannels = (((uint)NewVolume & 0x0000ffff) | ((uint)NewVolume << 16));
            // Set the volume
            waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels);
        }

        // open the shearch and put the code that where is the mp3 file is in the (file)
        string Song_name;
        public void Search(string url)
        {
            CommandString = "close MediaFile";
            mciSendString(CommandString, null, 0, 0);
            Song_name= url; //" " + file.FileName;
          
        }

    }

}


