using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppDevProject
{
    public abstract class Question
    {
        private List<Answer> answers;

        public int Id { get; set; }
        public string QuestionText { get; set; }
        public Button SubmitButton { get; set; }
        public Form Window { get; set; }
        internal List<Answer> Answers { get => answers; set => answers = value; }

        protected void Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
