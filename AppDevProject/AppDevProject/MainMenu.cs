using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AppDevProject
{
    public partial class MainMenu : Form
    {
        private List<Question> Questions { get; set; }

        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Questions = DBSingleton.GetDBSingletonInstance().getQuestions("5");
            Questions[0].Window.Visible = true;
            this.Visible = false;
        }
    }
}
