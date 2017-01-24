using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestionsApp.ORM.Model
{
    [Table("ReportType")]
    public partial class ReportType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReportType()
        {
            Reports = new HashSet<Report>();
        }

        public int Id { get; set; }

        public string ReportTypeName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Report> Reports { get; set; }
    }
}
