using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionsApp.DAL.Interface.DTO
{
    public class DalQuestion
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string QuestionDescription { get; set; }
        public DateTime QuestionDateTime { get; set; }
        public int Likes { get; set; }
        public bool IsAnswered { get; set; }
        public bool IsBanned { get; set; }
        public int? UserProfileId { get; set; }
        public int LectionEventId { get; set; }
        public virtual DalLectionEvent LectionEvent { get; set; }
    }
}
