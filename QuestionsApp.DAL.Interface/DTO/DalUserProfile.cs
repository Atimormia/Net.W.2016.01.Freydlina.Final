using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionsApp.DAL.Interface.DTO
{
    public class DalUserProfile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FamilyName { get; set; }
        public string PublicEmail { get; set; }
        public string PublicPhoneNumber { get; set; }
        public string ProfileUrl { get; set; }
        public byte[] Photo { get; set; }
        public string PhotoType { get; set; }
        public string About { get; set; }
        public string UserId { get; set; }
    }
}
