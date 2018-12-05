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
        private Form window;
        protected String name;
        protected String description;

        public string Description { get => description; set => description = value; }
        public string Name { get => name; set => name = value; }
        public Form Window { get => window; set => window = value; }

        protected void Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
