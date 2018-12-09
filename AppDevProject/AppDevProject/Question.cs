using System.Collections.Generic;
using System.Windows.Forms;

namespace AppDevProject
{
    internal abstract class Question
    {
        public static int Count { get; set; } = 0;
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType { get; set; }
        public Form Window { get; set; }
        public List<Answer> Answers { get; set; }

        protected void Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        protected abstract void InitializeComponent();
    }
}
