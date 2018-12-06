using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using WMPLib;
using AppDevProject.QuestionTypes;

namespace AppDevProject
{
    public partial class MainMenu : Form
    {
        private List<Question> questions;

        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateQuestions();
            this.Visible = false;

            Thread thread = new Thread(MusicFunc);
            thread.Start();
        }

        private void GenerateQuestions()
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    DB db = new DB();
                    db.getStuff();
                    //AddQuestions();
                    break;
                case 1:
                    AddQuestions();
                    AddQuestions();
                    break;
                case 2:
                    AddQuestions();
                    AddQuestions();
                    AddQuestions();
                    break;
                case 3:
                    AddQuestions();
                    AddQuestions();
                    AddQuestions();
                    AddQuestions();
                    break;
            }
        }

        private void AddQuestions() {
            questions.Add(new InputAnswerQuestion());
            questions.Add(new MultipleChoiceQuestion());
            questions.Add(new MusicQuestion());
            questions.Add(new PictureQuestion());
            questions.Add(new YesOrNoQuestion());
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
