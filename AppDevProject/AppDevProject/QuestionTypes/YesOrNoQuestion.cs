using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppDevProject.QuestionTypes
{
    internal class YesOrNoQuestion : Question
    {
        private RadioButton radioButton1;
        private RadioButton radioButton2;

        public YesOrNoQuestion(int id, string questionText, string questionType, List<Answer> answers)
        {
            Id = id;
            QuestionText = questionText;
            QuestionType = questionType;
            Answers = answers;
            InitializeComponent();
        }

        protected override void InitializeComponent()
        {
            Window = new Form();
            Button submitButton = new Button();
            Label questionLabel = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();

            submitButton.Location = new System.Drawing.Point(350, 400);
            submitButton.Name = "submitButton";
            submitButton.Size = new System.Drawing.Size(78, 41);
            submitButton.TabIndex = 1;
            submitButton.Text = "Submit your answer here";
            submitButton.Click += new System.EventHandler(SubmitButton_Click);

            questionLabel.AutoSize = true;
            questionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            questionLabel.Location = new System.Drawing.Point(300, 100);
            questionLabel.Name = "questionLabel";
            questionLabel.Size = new System.Drawing.Size(100, 100);
            questionLabel.TabIndex = 2;
            questionLabel.Text = QuestionText;

            radioButton1.AutoSize = true;
            radioButton1.Location = new System.Drawing.Point(300, 200);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new System.Drawing.Size(78, 41);
            radioButton1.TabIndex = 3;
            radioButton1.Text = Answers[0].AnswerString;

            radioButton2.AutoSize = true;
            radioButton2.Location = new System.Drawing.Point(400, 200);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new System.Drawing.Size(78, 41);
            radioButton2.TabIndex = 4;
            radioButton2.Text = Answers[1].AnswerString;

            Window.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            Window.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Window.ClientSize = new System.Drawing.Size(800, 450);
            Window.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Window_FormClosed);
            Window.Controls.Add(submitButton);
            Window.Controls.Add(questionLabel);
            Window.Controls.Add(radioButton1);
            Window.Controls.Add(radioButton2);
            Window.ResumeLayout(false);
            Window.PerformLayout();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (MainMenu.Questions[Question.Count] == null)
            {
                Application.Exit();
            }
            Window.Visible = false;
            MainMenu.Questions[Question.Count].Window.Visible = true;
            if (MainMenu.Questions[Question.Count].QuestionType == "Music")
            {
                ((MusicQuestion)MainMenu.Questions[Question.Count]).Thread.Start();
            }
            Question.Count++;
        }
    }
}
