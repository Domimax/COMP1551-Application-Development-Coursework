using System;
using System.Windows.Forms;

namespace AppDevProject
{
    public partial class FinishMenu : Form
    {
        public FinishMenu()
        {
            InitializeComponent();
            this.label1.Text = MainMenu.GameScore.CorrectAnswers.ToString() + " out of " + MainMenu.Questions.Count.ToString() + " correct answers.\n" +
            "You completed the quiz in " + MainMenu.GameScore.TimeTook + "seconds.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
