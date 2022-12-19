using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CarWashFrontend.Models;
using CarWashFrontend.Repository;
using Newtonsoft.Json;

namespace CarWashFrontend.Controllers
{
    public class UserController : Controller
    {
        #region
        public async Task<ActionResult> Index()
        {
            List<UserViewModel> users = new List<UserViewModel>();
            var service = new ServiceRepository();
            {
                using (var response = service.GetResponse("Users"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    users = JsonConvert.DeserializeObject<List<UserViewModel>>(apiResponse);
                }
            }
            return View(users);
        }
        #endregion
        //ActionMethod to delete user
        #region
        public async Task<ActionResult> Delete(int Id)
        {
            var service = new ServiceRepository();
            {
                using (var response = service.DeleteResponse("User/", Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");
        }
        #endregion
        //Actionmethod to update user
        #region
        public async Task<ActionResult> Edit(int Id)
        {
            UserViewModel user = new UserViewModel();
            var service = new ServiceRepository();
            {
                using (var response = service.GetResponse("User/" + "/" + Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //package = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                }
            }
            return View(user);
        }
        #endregion

        [HttpPost]
        public async Task<ActionResult> Edit(PackageViewModel user)
        {
            UserViewModel users = new UserViewModel();
            var service = new ServiceRepository();
            {
                using (var response = service.PutResponse("User/" + "/" + user.Id, user))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    // package = JsonConvert.DeserializeObject<PackageViewModel>(apiResponse);
                }
                return RedirectToAction("User");
            }
        }




    }
}

   
