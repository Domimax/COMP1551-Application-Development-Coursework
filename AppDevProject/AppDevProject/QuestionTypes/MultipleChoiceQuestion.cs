using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AppDevProject.QuestionTypes
{
    public class MultipleChoiceQuestion : Question
    {
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;

        public MultipleChoiceQuestion() {
            Window = new Form();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Window.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            Window.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Window.ClientSize = new System.Drawing.Size(800, 450);
            Window.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Window_FormClosed);
            Window.ResumeLayout(false);
            Window.PerformLayout();
        }
        
    }
}