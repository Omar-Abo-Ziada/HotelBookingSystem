using HotelBookingSystem.API.Responses;
using HotelBookingSystem.Core.DTOs;
using HotelBookingSystem.Core.Interfaces;
using HotelBookingSystem.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository hotelRepository;

        public HotelController(IHotelRepository hotelRepository)
        {
            this.hotelRepository = hotelRepository;
        }

        //****************************************

        [HttpGet]
        public ActionResult<GeneralResponse> GetAll()
        {
            List<Hotel> hotels = hotelRepository.FindAll().ToList();

            List<GetHotelDTO> getHotelDTOs = new List<GetHotelDTO>(hotels.Count);

            foreach (Hotel hotel in hotels)
            {
                GetHotelDTO dto = new GetHotelDTO()
                {
                    ID = hotel.ID,
                    Name = hotel.Name,
                };

                getHotelDTOs.Add(dto);
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = getHotelDTOs,
            };
        }

        [HttpGet("{id:int}")]
        public ActionResult<GeneralResponse> GetByID(int id)
        {
            Hotel? hotel = hotelRepository.GetById(id);

            if (hotel is null)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "There is no hotel found with this ID !"
                };
            }

            GetHotelDTO getHotelDTO = new GetHotelDTO()
            {
                ID = hotel.ID,
                Name = hotel.Name,
            };

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = getHotelDTO,
            };
        }
    }
}