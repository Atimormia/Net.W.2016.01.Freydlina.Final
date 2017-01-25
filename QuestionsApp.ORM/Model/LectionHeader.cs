using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestionsApp.ORM.Model
{
    [Table("LectionHeader")]
    public partial class LectionHeader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LectionHeader()
        {
            LectionEvents = new HashSet<LectionEvent>();
        }

        public int Id { get; set; }

        [Required]
        public string LectionTitle { get; set; }

        [Column(TypeName = "text")]
        public string LectionDescription { get; set; }
        
        public int UserProfileId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LectionEvent> LectionEvents { get; set; }
        
        public virtual UserProfile UserProfile { get; set; }
    }
}
