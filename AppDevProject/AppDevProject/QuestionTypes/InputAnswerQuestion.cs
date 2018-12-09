﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppDevProject.QuestionTypes
{
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

            submitButton.Location = new System.Drawing.Point(250, 300);
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

            textBox.AutoSize = true;
            textBox.Location = new System.Drawing.Point(450, 300);
            textBox.Name = "textBox";
            textBox.Size = new System.Drawing.Size(78, 41);
            textBox.TabIndex = 3;

            Window.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            Window.AutoScaleMode = AutoScaleMode.Font;
            Window.ClientSize = new System.Drawing.Size(800, 450);
            Window.FormClosed += new FormClosedEventHandler(Window_FormClosed);
            Window.Controls.Add(submitButton);
            Window.Controls.Add(questionLabel);
            Window.Controls.Add(textBox);
            Window.ResumeLayout(false);
            Window.PerformLayout();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (MainMenu.Questions[Question.Count].Equals(null))
            {
                Application.Exit();
            }
            if (textBox.Text == Answers[0].AnswerString) {

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
