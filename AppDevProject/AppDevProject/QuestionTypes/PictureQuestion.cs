using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace AppDevProject.QuestionTypes
{
    internal class PictureQuestion : Question
    {
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Answer chosenPicture;

        public PictureQuestion(int id, string questionText, string questionType, List<Answer> answers)
        {
            Id = id;
            QuestionText = questionText;
            QuestionType = questionType;
            Answers = answers;
            chosenPicture = null;
            InitializeComponent();
        }

        protected override void InitializeComponent()
        {
            Window = new Form();
            Button submitButton = new Button();
            Label questionLabel = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox4)).BeginInit();
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

            pictureBox1.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Pictures\" + Answers[0].AnswerString + ".jpg");
            pictureBox1.Location = new System.Drawing.Point(200, 150);
            pictureBox1.Margin = new Padding(2, 2, 2, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(90, 90);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Click += new System.EventHandler(PictureBox1_Click);

            pictureBox2.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Pictures\" + Answers[1].AnswerString + ".jpg");
            pictureBox2.Location = new System.Drawing.Point(450, 150);
            pictureBox2.Margin = new Padding(2, 2, 2, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(90, 90);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            pictureBox2.Click += new System.EventHandler(PictureBox2_Click);

            pictureBox3.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Pictures\" + Answers[2].AnswerString + ".jpg");
            pictureBox3.Location = new System.Drawing.Point(200, 250);
            pictureBox3.Margin = new Padding(2, 2, 2, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new System.Drawing.Size(90, 90);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 5;
            pictureBox3.TabStop = false;
            pictureBox3.Click += new System.EventHandler(PictureBox3_Click);

            pictureBox4.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Pictures\" + Answers[3].AnswerString + ".jpg");
            pictureBox4.Location = new System.Drawing.Point(450, 250);
            pictureBox4.Margin = new Padding(2, 2, 2, 2);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new System.Drawing.Size(90, 90);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 6;
            pictureBox4.TabStop = false;
            pictureBox4.Click += new System.EventHandler(PictureBox4_Click);

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
            Window.AutoScaleMode = AutoScaleMode.Font;
            Window.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Window.ClientSize = new System.Drawing.Size(800, 450);
            Window.FormClosed += new FormClosedEventHandler(Window_FormClosed);
            Window.Controls.Add(submitButton);
            Window.Controls.Add(questionLabel);
            Window.Controls.Add(pictureBox1);
            Window.Controls.Add(pictureBox2);
            Window.Controls.Add(pictureBox3);
            Window.Controls.Add(pictureBox4);
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox4)).EndInit();
            Window.Controls.Add(ScoreLabel);
            Window.Controls.Add(TimerLabel);
            Window.ResumeLayout(false);
            Window.PerformLayout();
        }

        private Answer FindCorrectPicture()
        {
            bool found = false;
            int count = 0;
            while (!found)
            {
                if (Answers[count].Correct == true)
                {
                    found = true;
                }
                else
                {
                    count++;
                }
            }
            return Answers[count];
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            chosenPicture = Answers[0];
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            chosenPicture = Answers[1];
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            chosenPicture = Answers[2];
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            chosenPicture = Answers[3];
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (chosenPicture == null)
            {
                MessageBox.Show("Please select a picture.");
            }
            else
            {
                if (chosenPicture.Id == FindCorrectPicture().Id)
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
