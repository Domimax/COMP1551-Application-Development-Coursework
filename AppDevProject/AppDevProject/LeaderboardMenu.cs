using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AppDevProject
{
    // LeaderboardMenu class implements Form and shows the score from previous quiz sessions.
    public partial class LeaderboardMenu : Form
    {
        //List of all previous scores.
        private List<Score> scores;

        public LeaderboardMenu()
        {
            //Retrives all scores from the database
            scores = DBSingleton.GetDBSingletonInstance.GetScores();
            InitializeComponent();
            //Sets the text for the label to display all the scores.
            label2.Text = string.Format("{0, 5}", "Nr") + string.Format("{0, 20}", "Player name")
                    + string.Format("{0, 20}", "Percentage") + string.Format("{0, 20}", "Time taken (s)" + "\n\r");
            for (int i = 0; i < scores.Count; i++)
            {
                label2.Text += string.Format("{0, 5}", i + 1) + string.Format("{0, 20}", scores[i].PlayerName)
                    + string.Format("{0, 20}", scores[i].CorrectPercentage) + string.Format("{0, 20}", scores[i].TimeTook) + "\n\r";
            }
            Visible = true;
        }

        private void Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Pressing the Go Back button actually restarts the whole application instead of switching to the MainMenu.
        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
