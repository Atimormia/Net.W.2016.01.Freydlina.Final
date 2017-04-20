using System;

namespace QuestionsApp.BLL.Interface.Entities
{
    public class QuestionEntity
    {
        public int Id { get; set; }
        public int IdOnClient { get; set; }
        public string AuthorName { get; set; }
        public string QuestionDescription { get; set; }
        public DateTime QuestionDateTime { get; set; }
        public int Likes { get; set; }
        public bool IsAnswered { get; set; }
        public bool IsBanned { get; set; }
        public int? UserProfileId { get; set; }
        public int LectionEventId { get; set; }
    }
}
