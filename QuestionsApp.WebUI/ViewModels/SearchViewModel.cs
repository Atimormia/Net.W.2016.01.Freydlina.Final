using System.Collections.Generic;

namespace QuestionsApp.WebUI.ViewModels
{
    public class SearchViewModel
    {
        public IEnumerable<LectionHeaderViewModel> Lections { get; set; }
    
        public string SearchText { get; set; }
    }
}