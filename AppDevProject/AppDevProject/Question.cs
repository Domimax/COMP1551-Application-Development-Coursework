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
        private int id;
        private string question;
        private List<Answer> answers;
        private Form window;
        private Button submit;

        public Form Window { get => window; set => window = value; }

        protected void Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
