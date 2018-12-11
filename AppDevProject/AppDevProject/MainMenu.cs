using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Timers;
using AppDevProject.QuestionTypes;

namespace AppDevProject
{
    public partial class MainMenu : Form
    {
        internal static Score GameScore { get; set; } = null;
        internal static System.Timers.Timer GameTimer { get; set; } = null;
        internal static List<Question> Questions { get; set; } = null;

        public MainMenu()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            GameScore = new Score();
            Questions = DBSingleton.GetDBSingletonInstance.getQuestions("5");
            this.Visible = false;
            Questions[Question.Count].ScoreLabel.Text = "Question " + Questions[Question.Count].Id + " out of " + Questions.Count;
            Questions[Question.Count].TimerLabel.Text = "Seconds taken already: " + GameScore.TimeTook + "s.";
            Questions[Question.Count].Window.Visible = true;
            SetTimer();
        }

        private void SetTimer()
        {
            GameTimer = new System.Timers.Timer(1000);
            GameTimer.Elapsed += OnTimedEvent;
            GameTimer.AutoReset = true;
            GameTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e) {
            Invoke(new MethodInvoker(CountSecond));
        }

        private void CountSecond() {
            GameScore.TimeTook++;
            Questions[Question.Count].TimerLabel.Text = "Seconds taken already: " + GameScore.TimeTook + "s.";
        }
    }
}
