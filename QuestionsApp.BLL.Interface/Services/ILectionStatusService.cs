using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionsApp.BLL.Interface.Entities;

namespace QuestionsApp.BLL.Interface.Services
{
    public interface ILectionStatusService: IDisposable
    {
        IEnumerable<LectionStatusEntity> GetAll ();
    }
}
