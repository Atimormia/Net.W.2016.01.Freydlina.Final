using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionsApp.DAL.Interface.DTO
{
    public class DalLectionEvent
    {
        public int Id { get; set; }
        public DateTime LectionStart { get; set; }
        public DateTime LectionEnd { get; set; }
        public string Organization { get; set; }
        public string Auditory { get; set; }
        public int LectionStatusId { get; set; }
        public int LectionHeaderId { get; set; }
        //public virtual DalLectionHeader LectionHeader { get; set; }
        //public virtual DalLectionStatus LectionStatus { get; set; }
    }
}
