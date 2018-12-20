using System;

namespace AppDevProject
{
    //Score class is used to store information about a players stats in a specific quiz session.
    internal class Score
    {
        public int Id { get; set; }
        public int CorrectAnswers { get; set; }
        public double CorrectPercentage { get; set; }
        public string PlayerName { get; set; }
        public DateTime Completed { get; set; }
        public int TimeTook { get; set; }
        public int QuestionNumber { get; set; }

        // Constructor used to create a score when a new quiz is started.
        public Score()
        {
            CorrectAnswers = 0;
            TimeTook = 0;
        }

        // Constructor used to create scores to display for the leaderboard.
        public Score(int id, int correctAnswers, double correctPercentage, 
            string playerName, DateTime completed, int timeTook, int questionNumber)
        {
            Id = id;
            CorrectAnswers = correctAnswers;
            CorrectPercentage = correctPercentage;
            PlayerName = playerName;
            Completed = completed;
            TimeTook = timeTook;
            QuestionNumber = questionNumber;
        }
    }
}
