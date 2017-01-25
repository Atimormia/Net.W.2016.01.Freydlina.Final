using System;

namespace QuestionsApp.BLL.Interface.Entities
{
    public class LectionEventEntity
    {
        public int Id { get; set; }
        public DateTime LectionStart { get; set; }
        public DateTime LectionEnd { get; set; }
        public string Organization { get; set; }
        public string Auditory { get; set; }
        public int LectionStatusId { get; set; }
        public int LectionHeaderId { get; set; }
    }
}
