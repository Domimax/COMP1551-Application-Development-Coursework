using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Timers;

namespace AppDevProject
{
    // MainMenu class acts as the starting point for the quiz. Implements the Form class.
    public partial class MainMenu : Form
    {
        //Delegate for the timer.
        public delegate void TimerDelegate();
        //GameScore variable is the score for the quiz that is currently being solved.
        public static Score GameScore { get; set; } = null;
        //GameTimer variable is a timer for the current quiz. Stops when the quiz is finished.
        public static System.Timers.Timer GameTimer { get; set; } = null;
        //A list of questions for the current quiz.
        public static List<Question> Questions { get; set; } = null;

        public MainMenu()
        {
            InitializeComponent();
        }

        //Button to begin a new quiz
        private void Button1_Click(object sender, EventArgs e)
        {
            //Checks if a user has selected the preferred number of questions for the quiz.
            if (comboBox1.SelectedItem != null)
            {
                GameScore = new Score();
                //Retrieves the selected number of questions from the database.
                Questions = DBSingleton.GetDBSingletonInstance.GetQuestions(comboBox1.SelectedItem.ToString());
                //Sets the MainMenu Form to invisible.
                this.Visible = false;
                //Initialization of the Text property of ScoreLabel and TimerLabel
                Questions[Question.Count].ScoreLabel.Text = "Question " + Questions[Question.Count].Id + " out of " + Questions.Count;
                Questions[Question.Count].TimerLabel.Text = "Seconds taken already: " + GameScore.TimeTook + "s.";          
                //Sets the Window of the next question to visible.
                Questions[Question.Count].Window.Visible = true;
                SetTimer();
            }
            else {
                MessageBox.Show("Please select the number of questions.");
            }
        }

        //Initialisation of the timer which ticks every second
        private void SetTimer()
        {
            GameTimer = new System.Timers.Timer(1000);
            GameTimer.Elapsed += OnTimedEvent;
            GameTimer.AutoReset = true;
            GameTimer.Enabled = true;
        }

        //The event is called every time the timer elapses
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            TimerDelegate handler = CountSecond;
            Invoke(handler);
        }

        // Method for the timer delegate
        private void CountSecond()
        {
            //Increment time of the quiz
            GameScore.TimeTook++;
            //Change the TimerLabel of the current question to reflect the time spent.
            Questions[Question.Count].TimerLabel.Text = "Seconds taken already: " + GameScore.TimeTook + "s.";
        }

        //Method to show leaderboards in a separate form.
        private void Button2_Click(object sender, EventArgs e)
        {
            Visible = false;
            LeaderboardMenu leaderboardMenu = new LeaderboardMenu();
        }
    }
}
