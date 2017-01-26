using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestionsApp.ORM.Model
{
    [Table("UserProfile")]
    public partial class UserProfile
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserProfile()
        {
            LectionHeaders = new HashSet<LectionHeader>();
            Questions = new HashSet<Question>();
            Reports = new HashSet<Report>();
            UserContacts = new HashSet<UserContact>();
        }
        [Key]
        public int UserProfileId { get; set; }
        
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string FamilyName { get; set; }

        public string PublicEmail { get; set; }

        public string PublicPhoneNumber { get; set; }
        
        public byte[] Photo { get; set; }

        public string PhotoType { get; set; }

        [Column(TypeName = "text")]
        public string About { get; set; }

        [Required]
        public string UserId { get; set; }

        //public virtual ApplicationUser AppUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LectionHeader> LectionHeaders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Question> Questions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Report> Reports { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserContact> UserContacts { get; set; }
    }
}
