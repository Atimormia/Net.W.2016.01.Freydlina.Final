using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuestionsApp.ORM.Model
{
    public partial class LectionStatus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LectionStatus()
        {
            LectionEvents = new HashSet<LectionEvent>();
        }

        public int Id { get; set; }

        [Required]
        public string StatusName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LectionEvent> LectionEvents { get; set; }
    }
}
