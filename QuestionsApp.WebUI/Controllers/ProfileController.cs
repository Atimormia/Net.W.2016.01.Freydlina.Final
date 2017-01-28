using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using QuestionsApp.BLL.Interface.Entities;
using QuestionsApp.BLL.Interface.Services;
using QuestionsApp.WebUI.ViewModels;

namespace QuestionsApp.WebUI.Controllers
{
    public class ProfileController : Controller
    {
        private IUserProfileService userProfileService;

        public ProfileController(IUserProfileService userProfileService)
        {
            this.userProfileService = userProfileService;
        }

        public PartialViewResult _UserProfilePartial(string id)
        {
            var profile = userProfileService.GetByAppUserId(id);
            var userprofile = Mapper.Map<UserProfileEntity, UserProfileViewModel>(profile);
            return PartialView(userprofile);
        }

        
        public FileResult LoadFile(int id)
        {
            var user = userProfileService.GetById(id);
            return File(user.Photo, user.PhotoType);
            //throw new NotImplementedException();
        }

        public ActionResult EditUserProfile(string id)
        {
            UserProfileEntity profile = userProfileService.GetByAppUserId(id);
            UserProfileViewModel profileForm = Mapper.Map<UserProfileEntity, UserProfileViewModel>(profile);
            return View("EditUserProfile", profileForm);
        }

        [HttpPost]
        public ActionResult EditUserProfile(UserProfileViewModel editedProfile)
        {
            UserProfileEntity user = Mapper.Map<UserProfileViewModel, UserProfileEntity>(editedProfile);
            if (ModelState.IsValid)
            {
                if (editedProfile.PhotoFile != null)
                {
                    user.Photo = new byte[editedProfile.PhotoFile.ContentLength];
                    user.PhotoType = editedProfile.PhotoFile.ContentType;
                    editedProfile.PhotoFile.InputStream.Read(user.Photo, 0, editedProfile.PhotoFile.ContentLength);
                }
                userProfileService.Update(user);
                
                //else //Otherwise we add an error and return to the (previous) view with the model data
                //    ModelState.AddModelError(errorField, Resources.UploadError);
                return RedirectToAction("Lections", "Lection");
            }
            return View("EditUserProfile", editedProfile);
        }
        
    }
}