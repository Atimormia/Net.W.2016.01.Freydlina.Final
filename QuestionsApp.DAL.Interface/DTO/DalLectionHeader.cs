using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionsApp.DAL.Interface.DTO
{
    public class DalLectionHeader
    {
        public int Id { get; set; }
        public string LectionTitle { get; set; }
        public string LectionDescription { get; set; }
        public string LectionUrl { get; set; }
        public string QrCode { get; set; }
        public int LectionStatusId { get; set; }
        public int UserProfileId { get; set; }
    }
}
