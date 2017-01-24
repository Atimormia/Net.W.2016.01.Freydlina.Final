using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuestionsApp.WebUI.ViewModels
{
    public class LectionEventViewModel
    {
        public string Id { get; set; }

        public DateTime LectionStart { get; set; }

        public DateTime LectionEnd { get; set; }

        public string Organization { get; set; }

        public string Auditory { get; set; }

        public string LectionUrl { get; set; }

        [Display(Name = "Status")]
        public string LectionStatusId { get; set; }

        public string LectionHeaderId { get; set; }

        public virtual LectionHeaderViewModel LectionHeader { get; set; }

        public virtual IEnumerable<LectionStatusViewModel> AllLectionStatuses { get; set; }
    }

    public class LectionStatusViewModel
    {
        public string Id { get; set; }

        public string StatusName { get; set; }
    }
}
