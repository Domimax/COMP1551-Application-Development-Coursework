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
        public int TimeTook { get; set; }

        public Score() {
            CorrectAnswers = 0;
            TimeTook = 0;
        }

        public void getDateTime() {
            Completed = DateTime.Now;
        }
    }
}
