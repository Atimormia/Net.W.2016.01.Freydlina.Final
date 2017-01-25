using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestionsApp.WebUI.ViewModels
{
    public class LectionHeaderViewModel
    {
        public int Id { get; set; }

        [Required]
        public string LectionTitle { get; set; }

        [Column(TypeName = "text")]
        public string LectionDescription { get; set; }
        
        public string QrCodeImagePath { get; set; }

        public int UserProfileId { get; set; }

        public virtual UserProfileViewModel UserProfile { get; set; }

        public virtual IEnumerable<LectionEventViewModel> LectionEvents { get; set; }
    }
    
}
