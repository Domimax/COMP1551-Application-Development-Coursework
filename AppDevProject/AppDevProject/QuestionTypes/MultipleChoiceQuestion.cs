using System;
using System.Windows.Forms;

namespace AppDevProject
{
    public class MultipleChoiceQuestion : Question
    {

        public MultipleChoiceQuestion() {
            Window = new Form();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // radioButton1
            System.Windows.Forms.RadioButton radioButton1 = new RadioButton();         
            radioButton1.Location = new System.Drawing.Point(356, 345);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new System.Drawing.Size(78, 41);
            radioButton1.TabIndex = 1;
            radioButton1.Text = "Play music";
            radioButton1.Checked = false;
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += new System.EventHandler(RadioButton1_CheckedChanged);

            Window.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            Window.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Window.ClientSize = new System.Drawing.Size(800, 450);
            Window.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Window_FormClosed);
            Window.Controls.Add(radioButton1);
            Window.ResumeLayout(false);
            Window.PerformLayout();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}