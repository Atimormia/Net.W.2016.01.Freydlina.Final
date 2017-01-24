using System.Web.Mvc;
using AutoMapper;
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
            UserProfileViewModel userprofile =
                Mapper.Map<UserProfileEntity, UserProfileViewModel>(userProfileService.GetByAppUserId(id));
            return PartialView(userprofile);
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
                //var oldPhoto = userProfileService.GetUser(User.Identity.GetUserId()).PhotoUrl;
                userProfileService.Update(user);
                //Prepare the needed variables
                //Bitmap original = null;
                //var name = "newimagefile";
                //var errorField = string.Empty;

                //if (editedProfile.PhotoFile != null)
                //{
                //    errorField = "File";
                //    name = Path.GetFileNameWithoutExtension(editedProfile.PhotoFile.FileName);
                //    original = Bitmap.FromStream(editedProfile.PhotoFile.InputStream) as Bitmap;
                //}
                //else
                //{
                //    userProfileService.SaveImageURL(User.Identity.GetUserId(), editedProfile.OldPhotoUrl);
                //}


                ////If we had success so far
                //if (original != null)
                //{
                //    var img = CreateImage(original, 0, 0, original.Width, original.Height);
                //    var fileName = Guid.NewGuid().ToString();
                //    var oldFilepath = userProfileService.GetUser(User.Identity.GetUserId()).PhotoUrl;
                //    var oldFile = Server.MapPath(oldFilepath);
                //    //Demo purposes only - save image in the file system
                //    var fn = Server.MapPath("~/Content/images/ProfilePics/" + fileName + ".png");
                //    img.Save(fn, System.Drawing.Imaging.ImageFormat.Png);
                //    userProfileService.SaveImageURL(User.Identity.GetUserId(), "~/Content/images/ProfilePics/" + fileName + ".png");
                //    if (System.IO.File.Exists(oldFile))
                //    {
                //        System.IO.File.Delete(oldFile);
                //    }
                //}
                //else //Otherwise we add an error and return to the (previous) view with the model data
                //    ModelState.AddModelError(errorField, Resources.UploadError);


                return RedirectToAction("Lections", "Lection");
            }
            return View("EditUserProfile", editedProfile);
        }
    }
}