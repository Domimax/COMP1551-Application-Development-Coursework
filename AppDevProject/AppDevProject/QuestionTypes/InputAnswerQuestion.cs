using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppDevProject.QuestionTypes
{
    class InputAnswerQuestion : Question
    {
        private TextBox textBox;
        private Label questionLabel;

        public InputAnswerQuestion(int id, string questionText, List<Answer> answers)
        {
            Id = id;
            QuestionText = questionText;
            Answers = answers;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Window = new Form();
            textBox = new TextBox();
            SubmitButton = new Button();
            questionLabel = new Label();

            SubmitButton.Location = new System.Drawing.Point(250, 300);
            SubmitButton.Name = "submitButton";
            SubmitButton.Size = new System.Drawing.Size(78, 41);
            SubmitButton.TabIndex = 1;
            SubmitButton.Text = "Submit your answer here.";

            textBox.AutoSize = true;
          //  textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBox.Location = new System.Drawing.Point(450, 300);
            textBox.Name = "textBox";
            textBox.Size = new System.Drawing.Size(78, 41);
            textBox.TabIndex = 2;

            questionLabel.AutoSize = true;
            questionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            questionLabel.Location = new System.Drawing.Point(300, 100);
            questionLabel.Name = "questionLabel";
            questionLabel.Size = new System.Drawing.Size(100, 100);
            questionLabel.TabIndex = 3;
            questionLabel.Text = QuestionText;

            Window.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            Window.AutoScaleMode = AutoScaleMode.Font;
            Window.ClientSize = new System.Drawing.Size(800, 450);
            Window.FormClosed += new FormClosedEventHandler(Window_FormClosed);
            Window.Controls.Add(SubmitButton);
            Window.Controls.Add(textBox);
            Window.Controls.Add(questionLabel);
            Window.ResumeLayout(false);
            Window.PerformLayout();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
