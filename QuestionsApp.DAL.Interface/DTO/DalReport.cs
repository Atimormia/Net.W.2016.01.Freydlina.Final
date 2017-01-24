using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionsApp.DAL.Interface.DTO
{
    public class DalReport
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int ReportTypeId { get; set; }
        public int AuthorProfileId { get; set; }
        public int QuestionId { get; set; }
    } 
}
