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

        public MultipleChoiceQuestion(int id, string questionText, string questionType, List<Answer> answers)
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
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            ScoreLabel = new Label();
            TimerLabel = new Label();

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

            ScoreLabel.AutoSize = true;
            ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ScoreLabel.Location = new System.Drawing.Point(100, 25);
            ScoreLabel.Name = "scoreLabel";
            ScoreLabel.Size = new System.Drawing.Size(100, 100);
            ScoreLabel.TabIndex = 7;

            TimerLabel.AutoSize = true;
            TimerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TimerLabel.Location = new System.Drawing.Point(450, 25);
            TimerLabel.Name = "timerLabel";
            TimerLabel.Size = new System.Drawing.Size(100, 100);
            TimerLabel.TabIndex = 8;

            Window.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            Window.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Window.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Window.ClientSize = new System.Drawing.Size(800, 450);
            Window.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Window_FormClosed);
            Window.Controls.Add(submitButton);
            Window.Controls.Add(questionLabel);
            Window.Controls.Add(checkBox1);
            Window.Controls.Add(checkBox2);
            Window.Controls.Add(checkBox3);
            Window.Controls.Add(checkBox4);
            Window.Controls.Add(ScoreLabel);
            Window.Controls.Add(TimerLabel);
            Window.ResumeLayout(false);
            Window.PerformLayout();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked && !checkBox4.Checked)
            {
                MessageBox.Show("Please check at least one box.");
            }
            else
            {
                if (checkBox1.Checked == Answers[0].Correct && checkBox2.Checked == Answers[1].Correct &&
                    checkBox3.Checked == Answers[2].Correct && checkBox4.Checked == Answers[3].Correct)
                {
                    MainMenu.GameScore.CorrectAnswers++;
                }
                if (Question.Count == MainMenu.Questions.Count-1)
                {
                    MainMenu.GameTimer.Stop();
                    FinishMenu finishMenu = new FinishMenu();
                    Window.Visible = false;
                    finishMenu.Visible = true;
                }
                else
                {
                    Question.Count++;
                    Window.Visible = false;
                    MainMenu.Questions[Question.Count].ScoreLabel.Text = "Question " + MainMenu.Questions[Question.Count].Id + " out of " + MainMenu.Questions.Count;
                    MainMenu.Questions[Question.Count].Window.Visible = true;
                }
            }
        }
    }
}