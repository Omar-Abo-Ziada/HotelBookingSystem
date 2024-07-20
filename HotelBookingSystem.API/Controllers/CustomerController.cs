using HotelBookingSystem.API.Responses;
using HotelBookingSystem.Core.DTOs;
using HotelBookingSystem.Core.Interfaces;
using HotelBookingSystem.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        //****************************************

        [HttpGet]
        public ActionResult<GeneralResponse> GetAll()
        {
            List<Customer> customers = customerRepository.FindAll().ToList();

            List<GetCustomerDTO> customerDTOs = new List<GetCustomerDTO>(customers.Count);

            foreach (Customer customer in customers)
            {
                GetCustomerDTO dto = new GetCustomerDTO()
                {
                    ID = customer.ID,
                    Name = customer.Name,
                    NationalID = customer.NationalID,
                    AgeCategory = customer.AgeCategory,
                    //CheckIn = customer.CheckIn,
                    //CheckOut = customer.CheckOut,
                    //BranchID = customer.BranchID ?? 0,
                    //IsPreviousCutomer = customer.IsPreviousCutomer,
                    //NumberOfRooms = customer.NumberOfRooms,
                    PhoneNumber = customer.PhoneNumber,
                    //RoomID = customer.RoomID ?? 0,
                };

                customerDTOs.Add(dto);
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = customerDTOs,
            };
        }

        [HttpGet("{id:int}")]
        public ActionResult<GeneralResponse> GetByID(int id)
        {
            Customer? customer = customerRepository.GetById(id);

            if (customer is null)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "There is no Customer found with this ID !"
                };
            }


            GetCustomerDTO customerDTO = new GetCustomerDTO()
            {
                ID = customer.ID,
                Name = customer.Name,
                NationalID = customer.NationalID,
                AgeCategory = customer.AgeCategory,
                //CheckIn = customer.CheckIn,
                //CheckOut = customer.CheckOut,
                //BranchID = customer.BranchID ?? 0,
                //IsPreviousCutomer = customer.IsPreviousCutomer,
                //NumberOfRooms = customer.NumberOfRooms,
                PhoneNumber = customer.PhoneNumber,
                //RoomID = customer.RoomID ?? 0,
            };


            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = customerDTO,
            };
        }
    }
}