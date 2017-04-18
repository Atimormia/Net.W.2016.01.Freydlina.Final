using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionsApp.DAL.Interface.DTO
{
    public class DalLectionStatus
    {
        public int Id { get; set; }
        public string StatusName { get; set; }
        //public ICollection<DalLectionEvent> LectionEvents { get; set; }
    }
}
