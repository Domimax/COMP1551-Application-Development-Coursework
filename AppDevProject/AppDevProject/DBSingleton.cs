using AppDevProject.QuestionTypes;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;

namespace AppDevProject
{
    sealed class DBSingleton
    {
        private static readonly object padlock = new object();
        private static DBSingleton instance = null;

        private DBSingleton()
        {

        }

        public static DBSingleton GetDBSingletonInstance()
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new DBSingleton();
                }
                return instance;
            }
        }

        private OleDbConnection GetOleDbConnection()
        {
            String connection = @"Provider=Microsoft.JET.OLEDB.4.0; 
				 Data Source =" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DB\AppDevProjectDB.mdb");
            OleDbConnection myConnection = new OleDbConnection(connection);
            return myConnection;
        }

        public List<Question> getQuestions(string amount)
        {
            List<Question> questions = new List<Question>();
            OleDbConnection connection = GetOleDbConnection();
           // string query = "SELECT * FROM Question WHERE ROWNUM <= " + amount.ToString() + ";";
            string query = "SELECT * FROM Question;";
            OleDbCommand myCommand = new OleDbCommand(query, connection);
            try
            {
                connection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    int id = (int)myReader["ID"];
                    string questionText = (string)myReader["QuestionText"];
                    string questionType = (string)myReader["QuestionType"];
                    Question newQuestion = null;
                    switch (questionType)
                    {
                        case "InputAnswer":
                            newQuestion = new InputAnswerQuestion();
                            break;
                        case "MultipleChoice":
                            newQuestion = new MultipleChoiceQuestion();
                            break;
                        case "Music":
                            newQuestion = new MusicQuestion();
                            break;
                        case "Picture":
                            newQuestion = new PictureQuestion();
                            break;
                        case "YesOrNo":
                            newQuestion = new YesOrNoQuestion();
                            break;
                    }
                    if (newQuestion != null)
                    {
                        newQuestion.Id = id;
                        newQuestion.QuestionText = questionText;
                        questions.Add(newQuestion);
                    }
                    else
                    {
                        throw new Exception("newQuestion variable is null.");
                    }
                }
                if (questions.Count == 0)
                {
                    throw new Exception("Database is empty.");
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Exception: " + ex);
                System.Diagnostics.Debug.WriteLine("Exception: " + ex);
            }
            finally
            {
                connection.Close();
            }
            return questions;
        }
    }
}

