using DTO.Model;
using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;

namespace MVCGUI.Controllers
{
    public class InfoController : Controller
    {
        [Route("Info")]
        public IActionResult Index(string Ferries)
        {
            var ferriesList = FerryBLL.GetAllFerries();
            var ferriesSelect = ferriesList.OrderBy(f => f.Name).Select(f => new SelectListItem { Value = f.Id.ToString(), Text = f.Name });
            ViewBag.ferries = ferriesSelect;
            if (Ferries != null)
            {
                ViewBag.pickedId = Ferries;
                Ferry ferryDetails = FerryBLL.GetFerryDetails(Convert.ToInt32(Ferries));
                ViewBag.PricePerGuest = ferryDetails.PricePerGuest;
                ViewBag.PricePerCar = ferryDetails.PricePerCar;
                List<Guest> allGuests = AllGuestsOnFerry(ferryDetails);
                ViewBag.TotalGuests = allGuests.Count;
                ViewBag.TotalCars = ferryDetails.Cars.Count;
                ViewBag.TotalPrice =  CalcTotalPrice(allGuests.Count, ferryDetails.PricePerGuest, ferryDetails.Cars.Count, ferryDetails.PricePerCar);
                var guestSelect = allGuests.Select(g => new SelectListItem { Value = g.Id.ToString(), Text = g.Name });
                ViewBag.Guests = guestSelect;
                var carSelect = ferryDetails.Cars.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.NumberPlate });
                ViewBag.Cars = carSelect;
            }
            
            return View("Index");
        }

        private List<Guest> AllGuestsOnFerry(Ferry ferryDetails)
        {
            List<Guest> guests = new List<Guest>();
            foreach (Car car in ferryDetails.Cars)
            {
                Car carDetails = CarBLL.GetCarDetails(car.Id);
                guests.AddRange(carDetails.Guests);
            }
            guests.AddRange(ferryDetails.Guests);
            return guests;
        }

        private string CalcTotalPrice(int guestCount, int guestPrice, int carCount, int carPrice)
        {
            return ((guestCount * guestPrice) + (carCount * carPrice)).ToString();
        }
    }
}
