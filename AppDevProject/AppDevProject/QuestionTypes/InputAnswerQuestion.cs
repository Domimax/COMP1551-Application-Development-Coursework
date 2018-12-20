using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AppDevProject.QuestionTypes
{
    //A question type where you have to input your own answer to the question into a textbox.
    internal class InputAnswerQuestion : Question
    {
        private TextBox textBox;

        public InputAnswerQuestion(int id, string questionText, string questionType, List<Answer> answers)
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
            textBox = new TextBox();
            ScoreLabel = new Label();
            TimerLabel = new Label();

            submitButton.Location = new System.Drawing.Point(250, 300);
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

            textBox.AutoSize = true;
            textBox.Location = new System.Drawing.Point(450, 300);
            textBox.Name = "textBox";
            textBox.Size = new System.Drawing.Size(78, 41);
            textBox.TabIndex = 3;

            ScoreLabel.AutoSize = true;
            ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ScoreLabel.Location = new System.Drawing.Point(100, 25);
            ScoreLabel.Name = "scoreLabel";
            ScoreLabel.Size = new System.Drawing.Size(100, 100);
            ScoreLabel.TabIndex = 4;

            TimerLabel.AutoSize = true;
            TimerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TimerLabel.Location = new System.Drawing.Point(450, 25);
            TimerLabel.Name = "timerLabel";
            TimerLabel.Size = new System.Drawing.Size(100, 100);
            TimerLabel.TabIndex = 5;

            Window.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            Window.AutoScaleMode = AutoScaleMode.Font;
            Window.StartPosition = FormStartPosition.CenterScreen;
            Window.ClientSize = new System.Drawing.Size(900, 450);
            Window.FormClosed += new FormClosedEventHandler(Window_FormClosed);
            Window.Controls.Add(submitButton);
            Window.Controls.Add(questionLabel);
            Window.Controls.Add(textBox);
            Window.Controls.Add(ScoreLabel);
            Window.Controls.Add(TimerLabel);
            Window.Name = "InputAnswerQuestion" + Id;
            Window.Text = "Input your own answer!";
            Window.ResumeLayout(false);
            Window.PerformLayout();
        }

        protected override void SubmitButton_Click(object sender, EventArgs e)
        {
            //Check if the user provided an answer.
            if (textBox.Text == "")
            {
                MessageBox.Show("Please input something into the text box.");
            }
            else
            {
                //If the answer is correct, increase the score.
                if (textBox.Text.ToLower() == Answers[0].AnswerString.ToLower())
                {
                    MainMenu.GameScore.CorrectAnswers++;
                }
                //Check if this question is the last one.
                TryFinalise();
            }
        }
    }
}
