namespace AppDevProject
{
    class Answer
    {
        public Answer(int id, string answerString, bool correct) {
            this.Id = id;
            this.AnswerString = answerString;
            this.Correct = correct;
        }

        public string AnswerString { get; set; }
        public int Id { get; set; }
        public bool Correct { get; set; }
    }
}
