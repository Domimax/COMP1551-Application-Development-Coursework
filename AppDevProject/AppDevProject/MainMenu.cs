using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AppDevProject
{
    public partial class MainMenu : Form
    {
        internal static Score GameScore { get; set; } = null;
        internal static List<Question> Questions { get; set; } = null;

        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameScore = new Score();
            Questions = DBSingleton.GetDBSingletonInstance().getQuestions("5");
            Questions[Question.Count].Window.Visible = true;
            Question.Count++;
            this.Visible = false;
        }
    }
}
