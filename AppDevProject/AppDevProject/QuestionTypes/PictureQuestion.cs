using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppDevProject.QuestionTypes
{
    class PictureQuestion : Question
    {
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private RadioButton radioButton4;

        public PictureQuestion()
        {
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
