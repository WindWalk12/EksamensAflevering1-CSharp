﻿using Microsoft.AspNetCore.Mvc;
using DTO.Model;
using BusinessLogic;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        [HttpGet]
        [Route("GetGuestById/{id}")]
        public Guest GetGuestById(int id)
        {
            return GuestBLL.GetGuestById(id);
        }

        [HttpPost]
        [Route("AddGuest")]
        public void AddGuest(Guest guest)
        {
            GuestBLL.AddGuest(guest);
        }

        [HttpGet]
        [Route("GetAllGuests")]
        public List<Guest> GetAllGuests()
        {
            return GuestBLL.GetAllGuests();
        }

        [HttpPost]
        [Route("DeleteGuest")]
        public void DeleteGuest(Guest guest)
        {
            GuestBLL.DeleteGuest(guest);
        }

        [HttpPost]
        [Route("DeleteGuests")]
        public void DeleteGuests(List<Guest> guests)
        {
            GuestBLL.DeleteGuests(guests);
        }
    }
}
