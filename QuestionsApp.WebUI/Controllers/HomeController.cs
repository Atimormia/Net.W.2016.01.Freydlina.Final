using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using QuestionsApp.BLL.Interface.Entities;
using QuestionsApp.BLL.Interface.Services;
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

        public HomeController() { }

        public HomeController(ILectionHeaderService lectionHeaderService)
        {
            this.lectionHeaderService = lectionHeaderService;
        }

        public ViewResult SearchAll(string searchText)
        {
            SearchViewModel searchViewModel = new SearchViewModel()
            {
                Lections = lectionHeaderService.Search(searchText).Select(Mapper.Map<LectionHeaderEntity, LectionHeaderViewModel>).ToList(),
                SearchText = searchText
            };
            ViewBag.searchtext = searchText;
            return View("SearchResult", searchViewModel);
        }

        public ActionResult Index()
        {
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