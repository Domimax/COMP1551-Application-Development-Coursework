using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace AppDevProject.QuestionTypes
{
    internal class MusicQuestion : Question
    {
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private RadioButton radioButton4;

        public Thread Thread { get; set; }

        public MusicQuestion(int id, string questionText, string questionType, List<Answer> answers)
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
            radioButton3 = new RadioButton();
            radioButton4 = new RadioButton();

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

            radioButton3.AutoSize = true;
            radioButton3.Location = new System.Drawing.Point(300, 250);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new System.Drawing.Size(78, 41);
            radioButton3.TabIndex = 5;
            radioButton3.Text = Answers[2].AnswerString;

            radioButton4.AutoSize = true;
            radioButton4.Location = new System.Drawing.Point(400, 250);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new System.Drawing.Size(78, 41);
            radioButton4.TabIndex = 6;
            radioButton4.Text = Answers[3].AnswerString;

            Window.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            Window.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Window.ClientSize = new System.Drawing.Size(800, 450);
            Window.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Window_FormClosed);
            Window.Controls.Add(submitButton);
            Window.Controls.Add(questionLabel);
            Window.Controls.Add(radioButton1);
            Window.Controls.Add(radioButton2);
            Window.Controls.Add(radioButton3);
            Window.Controls.Add(radioButton4);
            Window.ResumeLayout(false);
            Window.PerformLayout();
            Window.VisibleChanged += new System.EventHandler(Window_VisibleChanged);

            Thread = new Thread(MusicFunc);
        }

        private void Window_VisibleChanged(object sender, EventArgs e)
        {
            if (Window.Visible) {
                Thread.Start();
            }
            else {
                Thread.Abort();
            }
        }

        private Answer FindCorrectSong()
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

        private void MusicFunc()
        {
            WMPLib.WindowsMediaPlayer musicPlayer = new WMPLib.WindowsMediaPlayer();
            musicPlayer.URL = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Music\" + FindCorrectSong().AnswerString + ".mp3");
            musicPlayer.controls.play();
            Thread.Abort();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked && !radioButton4.Checked)
            {
                MessageBox.Show("Please check at least one box.");
            }
            else
            {
                if (radioButton1.Checked == Answers[0].Correct && radioButton2.Checked == Answers[1].Correct &&
                    radioButton3.Checked == Answers[2].Correct && radioButton4.Checked == Answers[3].Correct)
                {
                    MainMenu.GameScore.CorrectAnswers++;
                }
                if (Question.Count == MainMenu.Questions.Count)
                {
                    MessageBox.Show(MainMenu.GameScore.CorrectAnswers.ToString() + " out of " + MainMenu.Questions.Count.ToString() + " correct answers.");
                    Application.Exit();
                }
                else
                {
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
    }
}
