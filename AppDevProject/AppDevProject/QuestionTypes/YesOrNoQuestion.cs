﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppDevProject.QuestionTypes
{
    class YesOrNoQuestion : Question
    {
        private RadioButton radioButtonYes;
        private RadioButton radioButtonNo;
        private Label yes;
        private Label no;

        public YesOrNoQuestion()
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
