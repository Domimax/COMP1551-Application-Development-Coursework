using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace AppDevProject.QuestionTypes
{
    class MusicQuestion : Question
    {
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private RadioButton radioButton4;

        public MusicQuestion()
        {
            Window = new Form();
            InitializeComponent();

            Thread thread = new Thread(MusicFunc);
            thread.Start();
        }

        private void InitializeComponent()
        {
            Window.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            Window.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Window.ClientSize = new System.Drawing.Size(800, 450);
            Window.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Window_FormClosed);
            Window.ResumeLayout(false);
            Window.PerformLayout();
        }

        void MusicFunc()
        {
            WMPLib.WindowsMediaPlayer axMusicPlayer = new WMPLib.WindowsMediaPlayer();
            axMusicPlayer.URL = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Music\beethoven-symphony9-4-ode-to-joy-piano-solo.mp3");
            axMusicPlayer.settings.setMode("loop", true);
            axMusicPlayer.controls.play();
        }
    }
}
