using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace AppDevProject
{
    internal class Score
    {
        public int CorrectAnswers { get; set; }
        public double CorrectPercentage { get; set; }
        public string PlayerName { get; set; }
        public DateTime Completed { get; set; }
        public DateTime Started { get; set; }
        public double TimeTook { get; set; }

        public Score() {
            CorrectAnswers = 0;
            Started = DateTime.Now;
        }

        public void getDateTime() {
            Completed = DateTime.Now;
            double timeTook = Completed.TimeOfDay.TotalSeconds - Started.TimeOfDay.TotalSeconds;
        }
    }
}
