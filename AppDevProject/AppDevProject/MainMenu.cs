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

namespace AppDevProject
{
    public partial class MainMenu : Form
    {
        private Question[] questions;

        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            generateQuestions();
            this.Visible = false;
        }

        private void generateQuestions()
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    questions = new Question[5];
                    MultipleChoiceQuestion question1 = new MultipleChoiceQuestion();
                    question1.Window.Visible = true;
                    questions[0] = question1;
                    break;
                case 1:
                    questions = new Question[10];
                    MultipleChoiceQuestion question2 = new MultipleChoiceQuestion();
                    question2.Window.Visible = true;
                    Thread thread = new Thread(MusicFunc);
                    thread.Start();
                    break;
                case 2:
                    questions = new Question[15];
                    break;
                case 3:
                    questions = new Question[20];
                    break;
            }
        }

        void MusicFunc()
        {
            string text = AppDomain.CurrentDomain.BaseDirectory.ToString();
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Music\beethoven-symphony9-4-ode-to-joy-piano-solo.wav"));
            player.PlayLooping();
        }
    }
}
