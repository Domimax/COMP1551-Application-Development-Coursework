using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AppDevProject.QuestionTypes
{
    //A question type where the user has to select one option, either yes or no, to answer the question.
    public class YesOrNoQuestion : Question
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
            questionLabel.Location = new System.Drawing.Point(100, 100);
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

            ScoreLabel.AutoSize = true;
            ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ScoreLabel.Location = new System.Drawing.Point(100, 25);
            ScoreLabel.Name = "scoreLabel";
            ScoreLabel.Size = new System.Drawing.Size(100, 100);
            ScoreLabel.TabIndex = 5;

            TimerLabel.AutoSize = true;
            TimerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TimerLabel.Location = new System.Drawing.Point(450, 25);
            TimerLabel.Name = "timerLabel";
            TimerLabel.Size = new System.Drawing.Size(100, 100);
            TimerLabel.TabIndex = 8;

            Window.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            Window.AutoScaleMode = AutoScaleMode.Font;
            Window.StartPosition = FormStartPosition.CenterScreen;
            Window.ClientSize = new System.Drawing.Size(900, 450);
            Window.FormClosed += new FormClosedEventHandler(Window_FormClosed);
            Window.Controls.Add(submitButton);
            Window.Controls.Add(questionLabel);
            Window.Controls.Add(radioButton1);
            Window.Controls.Add(radioButton2);
            Window.Controls.Add(ScoreLabel);
            Window.Controls.Add(TimerLabel);
            Window.ResumeLayout(false);
            Window.PerformLayout();
        }

        protected override void SubmitButton_Click(object sender, EventArgs e)
        {
            //Check if the user provided an answer.
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Please check at least one box.");
            }
            else
            {
                //If the answer is correct, increase the score.
                if ((Answers[0].Correct && radioButton1.Checked) || (Answers[1].Correct && radioButton2.Checked))
                {
                    MainMenu.GameScore.CorrectAnswers++;
                }
                //Check if this question is the last one.
                TryFinalise();
            }
        }
    }
}
