using System;

namespace QuestionsApp.WebUI.ViewModels
{
    public class QuestionViewModel
    {
        public string Id { get; set; }

        public string AuthorName { get; set; }

        public string QuestionDescription { get; set; }

        public DateTime QuestionDateTime { get; set; }

        public int Likes { get; set; }

        public bool IsAnswered { get; set; }

        public bool IsBanned { get; set; }

        public string UserProfileId { get; set; }

        public string LectionEventId { get; set; }

        public virtual UserProfileViewModel UserProfile { get; set; }
    }
}
