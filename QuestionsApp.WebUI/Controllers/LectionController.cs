using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
            var headersView =
                lectionHeaderService.GetUserHeaders(userProfileId)
                    .Select(Mapper.Map<LectionHeaderEntity, LectionHeaderViewModel>)
                    .ToList();
            foreach (var header in headersView)
            {
                header.LectionEvents =
                    lectionEventService.GetEventsByHeaderId(header.Id)
                        .Select(Mapper.Map<LectionEventEntity, LectionEventViewModel>).ToList();
            }
            return View(headersView);
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
            var status = lectionStatusService.GetByName("Closed");
            lectionEvent.LectionStatusId = status.Id;
            if (ModelState.IsValid)
            {
                lectionEventService.Create(lectionEvent);
                return RedirectToAction("Lections");
            }
            return View();
        }

        public ActionResult EditEvent(int id)
        {
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
        
        public ActionResult DeleteEvent(int id)
        {
            lectionEventService.Delete(id);
            return RedirectToAction("Lections");
        }

        public ActionResult EditHeader(int id)
        {
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
        
        public ActionResult LectionHeader(int id)
        {
            var lectionHeader = lectionEventService.GetHeaderById(id);
            LectionHeaderViewModel model = Mapper.Map<LectionHeaderEntity, LectionHeaderViewModel>(lectionHeader);
            return PartialView("_LectionHeaderPartial",model);
        }

        public FileResult QrCode(int id)
        {
            QRCodeEncoder encoder = new QRCodeEncoder();
            Bitmap img = encoder.Encode("/Lection/LectionEventPage/" + id);
            byte[] file = null;
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                file = stream.ToArray();
            }
            return File(file, "image/jpeg");
        }
    }
}