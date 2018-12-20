using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AppDevProject
{
    // Abstract class for different question types
    public abstract class Question
    {
        // Variable Count stores the number of the question the player is currently answering
        public static int Count { get; set; } = 0;
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType { get; set; }
        public Form Window { get; set; }
        public Label ScoreLabel { get; set; }
        public Label TimerLabel { get; set; }
        public List<Answer> Answers { get; set; }

        // Abstract method to initialise the UI Window variable of a specific question
        protected abstract void InitializeComponent();
        protected abstract void SubmitButton_Click(object sender, EventArgs e);

        protected void Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Method is called each time a question is answered to check if it was the last question of the quiz
        //and proceed to the FinishMenu
        protected void TryFinalise() {
            //Checks if the question counter reached the end of the List of all questions
            if (Count == MainMenu.Questions.Count - 1)
            {
                //Stop the game timer so that it is possible to save the value for the score.
                MainMenu.GameTimer.Stop();
                //Get the time of completion of the quiz.
                MainMenu.GameScore.Completed = DateTime.Now;
                //Calculating the percentage of correct answers.
                MainMenu.GameScore.CorrectPercentage = ((double)MainMenu.GameScore.CorrectAnswers / MainMenu.Questions.Count) * 100;
                //Record the total number of questions in the quiz.
                MainMenu.GameScore.QuestionNumber = MainMenu.Questions.Count;
                //Show the FinishMenu
                FinishMenu finishMenu = new FinishMenu();
                Window.Visible = false;
                finishMenu.Visible = true;
            }
            //If not the last question, continue.
            else
            {
                //Increase the question counter.
                Count++;
                Window.Visible = false;
                //Set the ScoreLabel of the next question to show the position in the quiz.
                MainMenu.Questions[Question.Count].ScoreLabel.Text = "Question " + MainMenu.Questions[Question.Count].Id + " out of " + MainMenu.Questions.Count;
                //Show the next question.
                MainMenu.Questions[Question.Count].Window.Visible = true;
            }
        }
    }
}
