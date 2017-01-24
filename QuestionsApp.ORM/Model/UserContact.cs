using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestionsApp.ORM.Model
{
    [Table("UserContact")]
    public partial class UserContact
    {
        public int Id { get; set; }

        public string ContactName { get; set; }

        [Required]
        public string ContactContent { get; set; }

        public int UserProfileId { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}
