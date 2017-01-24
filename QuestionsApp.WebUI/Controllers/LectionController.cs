using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using MessagingToolkit.QRCode.Codec;
using Microsoft.AspNet.Identity;
using QuestionsApp.BLL.Interface.Entities;
using QuestionsApp.BLL.Interface.Services;
using QuestionsApp.WebUI.ViewModels;

namespace QuestionsApp.WebUI.Controllers
{

    public class LectionController : Controller
    {
        private IUserProfileService userProfileService;
        private ILectionHeaderService lectionHeaderService;
        private ILectionEventService lectionEventService;
        private ILectionStatusService lectionStatusService;
        private IQuestionService questionService;

        public LectionController(IUserProfileService userProfileService, ILectionHeaderService lectionHeaderService,
            ILectionEventService lectionEventService, ILectionStatusService lectionStatusService, IQuestionService questionService)
        {
            this.userProfileService = userProfileService;
            this.lectionHeaderService = lectionHeaderService;
            this.lectionEventService = lectionEventService;
            this.lectionStatusService = lectionStatusService;
            this.questionService = questionService;
        }

        public ActionResult Lections()
        {
            var userProfileId = userProfileService.GetByAppUserId(User.Identity.GetUserId()).Id;
            var headers = lectionHeaderService.GetUserHeaders(userProfileId);
            List<LectionHeaderViewModel> model = headers.Select(Mapper.Map<LectionHeaderEntity, LectionHeaderViewModel>).ToList();
            return View(model);
        }

        public ActionResult CreateHeader()
        {
            return View("CreateLection");
        }

        [HttpPost]
        public ActionResult CreateHeader(LectionHeaderViewModel createdHeader)
        {
            LectionHeaderEntity lectionHeader = Mapper.Map<LectionHeaderViewModel, LectionHeaderEntity>(createdHeader);
            
            UserProfileEntity user = userProfileService.GetByAppUserId(User.Identity.GetUserId());
            //lectionHeader.UserProfile = user;
            lectionHeader.UserProfileId = user.Id;
            if (ModelState.IsValid)
            {
                lectionHeaderService.Create(lectionHeader);

                return RedirectToAction("Lections");
            }

            return View("CreateLection");
        }

        public ActionResult CreateEvent(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LectionEventViewModel model = new LectionEventViewModel {LectionHeaderId = id};
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateEvent(LectionEventViewModel createdEvent)
        {
            LectionEventEntity lectionEvent = Mapper.Map<LectionEventViewModel, LectionEventEntity>(createdEvent);
            //lectionEvent.LectionHeader = lectionHeaderService.GetByAppUserId((int)lectionEvent.LectionHeaderId);
            //LectionStatus status = lectionStatusService.GetByName("Closed");
            //lectionEvent.LectionStatus = status;
            //lectionEvent.LectionStatusId = status.Id;
            if (ModelState.IsValid)
            {
                lectionEventService.Create(lectionEvent);

                return RedirectToAction("Lections");
            }

            return View();
        }

        public ActionResult EditEvent(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LectionEventEntity lectionEvent = lectionEventService.GetById(id);
            if (lectionEvent == null)
            {
                return HttpNotFound();
            }
            LectionEventViewModel eventForm = Mapper.Map<LectionEventEntity, LectionEventViewModel>(lectionEvent);
            eventForm.AllLectionStatuses = lectionStatusService.GetAll().Select(Mapper.Map<LectionStatusEntity, LectionStatusViewModel>);
            return View(eventForm);
        }

        [HttpPost]
        public ActionResult EditEvent(LectionEventViewModel editedEvent)
        {
            LectionEventEntity lectionEvent = Mapper.Map<LectionEventViewModel, LectionEventEntity>(editedEvent);
            if (ModelState.IsValid)
            {
                lectionEventService.Update(lectionEvent);
                return RedirectToAction("Lections");
            }

            return View(editedEvent);
        }
        
        public ActionResult DeleteEvent(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lectionEventService.Delete(id);
            return RedirectToAction("Lections");
        }

        public ActionResult EditHeader(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LectionHeaderEntity header = lectionHeaderService.GetById(id);
            if (header == null)
            {
                return HttpNotFound();
            }
            LectionHeaderViewModel headerForm = Mapper.Map<LectionHeaderEntity, LectionHeaderViewModel>(header);
            return View("EditLection",headerForm);
        }

        [HttpPost]
        public ActionResult EditHeader(LectionHeaderViewModel editedHeaderForm)
        {
            LectionHeaderEntity header = Mapper.Map<LectionHeaderViewModel, LectionHeaderEntity>(editedHeaderForm);
            UserProfileEntity user = userProfileService.GetByAppUserId(User.Identity.GetUserId());
            header.UserProfileId = user.Id;
            if (ModelState.IsValid)
            {
                lectionHeaderService.Update(header);
                return RedirectToAction("Lections");
            }

            return View("EditLection", editedHeaderForm);
        }

        public ActionResult DeleteHeader(int id)
        {
            lectionEventService.DeleteEventsOfHeader(id);
            lectionHeaderService.Delete(id);
            return RedirectToAction("Lections");
        }


        public ActionResult Questions(int id)
        {
            List<QuestionViewModel> model = new List<QuestionViewModel>();
            foreach (var question in questionService.GetMany(q=>q.LectionEventId == id))
            {
                model.Add(Mapper.Map<QuestionEntity,QuestionViewModel>(question));
            }
            return PartialView("_QuestionsPartial", model);
        }

        [HttpPost]
        public ActionResult AddQuestion(QuestionViewModel createdQuestion)
        {
            QuestionEntity question = Mapper.Map<QuestionViewModel, QuestionEntity>(createdQuestion);
            question.QuestionDateTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                questionService.Create(question);

                return RedirectToAction("Questions", new {id= createdQuestion.LectionEventId});
            }
            return View("LectionEventPage", createdQuestion);
        }

        public ActionResult LectionEventPage(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionViewModel model = new QuestionViewModel {LectionEventId = id};
            return View(model);
        }
        
        public ActionResult LectionHeader(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var lectionHeader = lectionEventService.GetHeaderById(id);

            //Bitmap img = null;
            //if (lectionHeader != null && lectionHeader.QrCodeImagePath == null)
            //{
            //    QRCodeEncoder encoder = new QRCodeEncoder();
            //    img = encoder.Encode("/Lection/LectionEventPage/" + id);
            //}
            //if (img != null)
            //{
            //    var fileName = Guid.NewGuid().ToString();
            //    var path = "/Content/images/QRcodes/" + fileName + ".png";
            //    //var fn = Server.MapPath(path);
            //    img.Save(path, System.Drawing.Imaging.ImageFormat.Png);
            //    lectionHeaderService.SaveQrCodeImagePath(lectionHeader.Id, path);
            //    lectionHeader.QrCodeImagePath = path;
            //}
            
            LectionHeaderViewModel model = Mapper.Map<LectionHeaderEntity, LectionHeaderViewModel>(lectionHeader);
            return PartialView("_LectionHeaderPartial",model);
        }
    }
}