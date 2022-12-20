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
    public class CarController : Controller
    {

        #region
        public async Task<ActionResult> CarDetails()
        {
            List<CarViewModel> cars = new List<CarViewModel>();
            var service = new ServiceRepository();
            {
                using (var response = service.GetResponse("Car"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cars = JsonConvert.DeserializeObject<List<CarViewModel>>(apiResponse);
                }
            }
            return View(cars);
        }
        #endregion


        //ActionMethod to delete user
        #region
        public async Task<ActionResult> Delete(int Id)
        {
            var service = new ServiceRepository();
            {
                using (var response = service.DeleteResponse("Car/", Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("CarDetails");
        }
        #endregion
        //Actionmethod to update user
        #region
        public async Task<ActionResult> Edit(int Id)
        {
            CarViewModel car = new CarViewModel();
            var service = new ServiceRepository();
            {
                using (var response = service.GetResponse("Car/" + "/" + Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    car = JsonConvert.DeserializeObject<CarViewModel>(apiResponse);
                }
            }
            return View(car);
        }
        #endregion
        [HttpPost]
        public async Task<ActionResult> Edit(CarViewModel car)
        {
            CarViewModel cars = new CarViewModel();
            var service = new ServiceRepository();
            {
                using (var response = service.PutResponse("Car/" + "/" + car.Id, car))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    // cars = JsonConvert.DeserializeObject<PackageViewModel>(apiResponse);
                }
                return RedirectToAction("CarDetails");
            }
        }
        #region

        public async Task<ActionResult> CreateCar(CarViewModel car)
        {
            if (ModelState.IsValid)
            {
                CarViewModel newCar = new CarViewModel();
                var service = new ServiceRepository();
                {
                    using (var response = service.PostResponse("Car/", car))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        //newUser = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                    }
                }



                return RedirectToAction("CarDetails");
            }
            return View(car);
        }
#endregion


    }
}