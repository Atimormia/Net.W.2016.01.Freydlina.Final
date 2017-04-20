using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestionsApp.ORM.Model
{
    [Table("Question")]
    public partial class Question
    {
        public int Id { get; set; }

        public int IdOnClient { get; set; }

        public string AuthorName { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string QuestionDescription { get; set; }

        public DateTime QuestionDateTime { get; set; }

        public int Likes { get; set; }

        public bool IsAnswered { get; set; }

        public bool IsBanned { get; set; }

        public int? UserProfileId { get; set; }

        public int LectionEventId { get; set; }

        public virtual LectionEvent LectionEvent { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}
