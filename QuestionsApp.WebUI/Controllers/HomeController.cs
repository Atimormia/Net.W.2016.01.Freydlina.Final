using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using QuestionsApp.BLL.Interface.Entities;
using QuestionsApp.BLL.Interface.Services;
using QuestionsApp.Logger;
using QuestionsApp.WebUI.ViewModels;

namespace QuestionsApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        //IEnumerable<Lection> lections = new[]
        //{
        //    new Lection {Title = "Bootstrap workshop", Desc = "jhdaslfjhal", Url = "", Lector = "Mary Sue"},
        //    new Lection {Title = "CSS workshop", Desc = "jafkhdkjhak", Url = "", Lector = "John Smith"},
        //    new Lection {Title = "JavaScript introduction", Desc = "hfjdhksjh", Url = "", Lector = "Mark Green"},
        //    new Lection {Title = "jQuery introduction", Desc = "gdhgjhg", Url = "", Lector = "Daug Ross"},
        //    new Lection {Title = "Ajax workshop", Desc = "dfjkhjkh", Url = "", Lector = "Fill Richards"}
        //};
        ILectionHeaderService lectionHeaderService;
        ILectionEventService lectionEventService;
        IUserProfileService userProfileService;
        ILogger logger;

        public HomeController() { }

        public HomeController(ILectionHeaderService lectionHeaderService,ILectionEventService lectionEventService, IUserProfileService userProfileService, ILogger logger)
        {
            this.lectionHeaderService = lectionHeaderService;
            this.lectionEventService = lectionEventService;
            this.userProfileService = userProfileService;
            this.logger = logger;
        }

        public ViewResult SearchAll(string searchText)
        {
            logger.Debug("Search action of Home controller started");
            var lections =
                lectionHeaderService.Search(searchText)
                    .Select(Mapper.Map<LectionHeaderEntity, LectionHeaderViewModel>)
                    .ToList();
            foreach (var lection in lections)
            {
                lection.LectionEvents =
                    lectionEventService.GetEventsByHeaderId(lection.Id)
                        .Select(Mapper.Map<LectionEventEntity, LectionEventViewModel>)
                        .ToList();
                var userProfile = userProfileService.GetById(lection.UserProfileId);
                lection.UserProfile = Mapper.Map<UserProfileEntity,UserProfileViewModel>(userProfile);
            }
            SearchViewModel searchViewModel = new SearchViewModel()
            {
                Lections = lections,
                SearchText = searchText
            };
            ViewBag.searchtext = searchText;
            return View("SearchResult", searchViewModel);
        }

        public ActionResult Index()
        {
            logger.Trace("Index action of Home controller started");
            return View();
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}
        
        //public ActionResult _Search(string query)
        //{
        //    var lect = lections.Where(a => a.Title.Contains(query)).ToList();
        //    if (lect.Count <= 0)
        //    {
        //        return null;
        //    }
        //    return PartialView(lect);
        //}

        //public JsonResult JsonSearch(string query)
        //{
        //    var jsondata = lections.Where(a => a.Title.Contains(query)).ToList();
        //    if (jsondata.Count <= 0)
        //    {
        //        return null;
        //    }
        //    return Json(jsondata, JsonRequestBehavior.AllowGet);
        //}

    }

    //public class Lection
    //{
    //    public Lection()
    //    {
    //    }

    //    public string Title { get; set; }
    //    public string Desc { get; set; }
    //    public string Url { get; set; }
    //    public string Lector { get; set; }
    //}
}