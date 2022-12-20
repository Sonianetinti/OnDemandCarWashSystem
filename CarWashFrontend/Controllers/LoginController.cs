using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CarWashFrontend.Models;
using CarWashFrontend.Repository;
using Newtonsoft.Json;

namespace CarWashFrontend.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult HomePage()
        {
            return View();
        }
        public ActionResult LoginUser()
        {
            return View();
        }
        public ActionResult AdminPage()
        {
            return View();
        }
        public ActionResult IncorrectPass()
        {
            return View();
        }

        #region login
        [HttpPost]
        public async Task<ActionResult> LoginUser(LoginViewModel login)
        {


            try
            {
                if (ModelState.IsValid)
                {
                    LoginViewModel newUser = new LoginViewModel();
                    var service = new ServiceRepository();
                    {
                        using (var response = service.VerifyLogin("api/Login", login))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            newUser = JsonConvert.DeserializeObject<LoginViewModel>(apiResponse);
                        }
                    }
                    if (newUser != null)
                    {
                        ViewBag.message = "Login Success";
                        return RedirectToAction("AdminPage");
                    }
                    else
                    {
                        ViewBag.message = "incorrect";
                    }
                }
            }
            catch
            {

            }
            return RedirectToAction("AdminPage");

            

        }
        #endregion


        //Action method to create user
        #region Register
        public async Task<ActionResult> Create(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                UserViewModel newUser = new UserViewModel();
                var service = new ServiceRepository();
                {
                    using (var response = service.PostResponse("Users", user))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        //newUser = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                    }
                }



                return RedirectToAction("Index", "User");
            }
            return View(user);
        }
        #endregion
    }

}
    
