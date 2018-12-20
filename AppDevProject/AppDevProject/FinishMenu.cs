using System;
using System.Windows.Forms;

namespace AppDevProject
{
    //FinishMenu class implements Form and is showed when all the questions have been answered.
    public partial class FinishMenu : Form
    {
        public FinishMenu()
        {
            InitializeComponent();
            label1.Text = MainMenu.GameScore.CorrectAnswers.ToString() + " out of " + MainMenu.Questions.Count.ToString() + " correct answers.\n" +
            "You completed the quiz in " + MainMenu.GameScore.TimeTook + "seconds.\nPlease enter your name below to save the score.";
        }

        //Method to save the score and play another quiz.
        private void Button1_Click(object sender, EventArgs e)
        {
            //Checks if the textbox is not empty and is not too long.
            if (textBox1.Text == "" || textBox1.TextLength > 10)
            {
                MessageBox.Show("Please input a name of at least one and no more than 10 characters.");
            }
            else
            {
                //Set the player name to the text in the textbox.
                MainMenu.GameScore.PlayerName = textBox1.Text;
                //Add the score of the currently completed quiz to the database.
                DBSingleton.GetDBSingletonInstance.AddScore(MainMenu.GameScore);
                Application.Restart();
            }
        }

        //Method to save the score and exit the application.
        private void Button2_Click(object sender, EventArgs e)
        {
            //Checks if the textbox is not empty and is not too long.
            if (textBox1.Text == "" || textBox1.TextLength > 10)
            {
                MessageBox.Show("Please input a name of at least one and no more than 10 characters.");
            }
            else
            {
                //Set the player name to the text in the textbox.
                MainMenu.GameScore.PlayerName = textBox1.Text;
                //Add the score of the currently completed quiz to the database.
                DBSingleton.GetDBSingletonInstance.AddScore(MainMenu.GameScore);
                Application.Exit();
            }
        }

        private void Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
