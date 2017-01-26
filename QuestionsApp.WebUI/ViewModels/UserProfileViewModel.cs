using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace QuestionsApp.WebUI.ViewModels
{
    public class UserProfileViewModel
    {
        public string UserProfileId { get; set; }

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Second name")]
        public string SecondName { get; set; }

        [Display(Name = "Family name")]
        public string FamilyName { get; set; }

        [Display(Name = "Public email")]
        [DataType(DataType.EmailAddress)]
        public string PublicEmail { get; set; }

        [Display(Name = "Public phone number")]
        [DataType(DataType.PhoneNumber)]
        public string PublicPhoneNumber { get; set; }

        public byte[] Photo { get; set; }

        public string PhotoType { get; set; }

        public HttpPostedFileBase PhotoFile { get; set; }

        public string About { get; set; }

        public string UserId { get; set; }

        public virtual ICollection<UserContactViewModel> UserContacts { get; set; }
    }

    public class UserContactViewModel
    {
        public int Id { get; set; }

        public string ContactName { get; set; }

        public string ContactContent { get; set; }

        public int UserProfileId { get; set; }
    }
}
