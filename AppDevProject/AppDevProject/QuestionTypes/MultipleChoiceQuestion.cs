using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AppDevProject.QuestionTypes
{
    internal class MultipleChoiceQuestion : Question
    {
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;

        public MultipleChoiceQuestion(int id, string questionText, string questionType, List<Answer> answers) {
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
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();

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

            checkBox1.AutoSize = true;
            checkBox1.Location = new System.Drawing.Point(300, 200);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(78, 41);
            checkBox1.TabIndex = 3;
            checkBox1.Text = Answers[0].AnswerString;

            checkBox2.AutoSize = true;
            checkBox2.Location = new System.Drawing.Point(400, 200);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new System.Drawing.Size(78, 41);
            checkBox2.TabIndex = 4;
            checkBox2.Text = Answers[1].AnswerString;

            checkBox3.AutoSize = true;
            checkBox3.Location = new System.Drawing.Point(300, 250);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new System.Drawing.Size(78, 41);
            checkBox3.TabIndex = 5;
            checkBox3.Text = Answers[2].AnswerString;

            checkBox4.AutoSize = true;
            checkBox4.Location = new System.Drawing.Point(400, 250);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new System.Drawing.Size(78, 41);
            checkBox4.TabIndex = 6;
            checkBox4.Text = Answers[3].AnswerString;
         
            Window.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            Window.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Window.ClientSize = new System.Drawing.Size(800, 450);
            Window.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Window_FormClosed);
            Window.Controls.Add(submitButton);
            Window.Controls.Add(questionLabel);
            Window.Controls.Add(checkBox1);
            Window.Controls.Add(checkBox2);
            Window.Controls.Add(checkBox3);
            Window.Controls.Add(checkBox4);
            Window.ResumeLayout(false);
            Window.PerformLayout();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (Question.Count > MainMenu.Questions.Count)
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