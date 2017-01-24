using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestionsApp.ORM.Model
{
    [Table("Report")]
    public partial class Report
    {
        public int Id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Message { get; set; }

        public int ReportTypeId { get; set; }

        public int AuthorProfileId { get; set; }

        public int QuestionId { get; set; }

        public virtual ReportType ReportType { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}
