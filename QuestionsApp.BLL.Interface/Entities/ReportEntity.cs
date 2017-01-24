namespace QuestionsApp.BLL.Interface.Entities
{
    public class ReportEntity
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int ReportTypeId { get; set; }
        public int AuthorProfileId { get; set; }
        public int QuestionId { get; set; }
    } 
}
