namespace AppDevProject
{
    class Answer
    {
        public Answer(int id, string answerString) {
            this.Id = id;
            this.AnswerString = answerString;
        }

        public string AnswerString { get; set; }
        public int Id { get; set; }
    }
}
