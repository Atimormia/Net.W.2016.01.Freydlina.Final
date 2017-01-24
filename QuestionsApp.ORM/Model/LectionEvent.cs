using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestionsApp.ORM.Model
{
    [Table("LectionEvent")]
    public partial class LectionEvent
    {
        public int Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime LectionStart { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime LectionEnd { get; set; }

        public string Organization { get; set; }

        public string Auditory { get; set; }

        public int LectionHeaderId { get; set; }

        public virtual LectionHeader LectionHeader { get; set; }
        
        public int LectionStatusId { get; set; }

        public virtual LectionStatus LectionStatus { get; set; }
    }
}
