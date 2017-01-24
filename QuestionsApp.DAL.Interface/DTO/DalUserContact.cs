using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionsApp.DAL.Interface.DTO
{
    public class DalUserContact
    {
        public int Id { get; set; }
        public string ContactName { get; set; }
        public string ContactContent { get; set; }
        public int UserProfileId { get; set; }
    }
}
