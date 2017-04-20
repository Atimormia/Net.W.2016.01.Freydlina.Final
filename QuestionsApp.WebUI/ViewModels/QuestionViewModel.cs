using System;

namespace QuestionsApp.WebUI.ViewModels
{
    public class QuestionViewModel
    {
        public int Id { get; set; }

        public int IdForClient { get; set; }

        public string AuthorName { get; set; }

        public string QuestionDescription { get; set; }

        public DateTime QuestionDateTime { get; set; }

        public int Likes { get; set; }

        public bool IsAnswered { get; set; }

        public bool IsBanned { get; set; }

        public int? UserProfileId { get; set; }

        public int LectionEventId { get; set; }

        public virtual UserProfileViewModel UserProfile { get; set; }
    }
}
