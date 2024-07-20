using HotelBookingSystem.API.Responses;
using HotelBookingSystem.Core.DTOs;
using HotelBookingSystem.Core.Interfaces;
using HotelBookingSystem.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IHotelRepository hotelRepository;
        private readonly IBranchRepository branchRepository;

        public BranchController(IHotelRepository hotelRepository, IBranchRepository branchRepository)
        {
            this.hotelRepository = hotelRepository;
            this.branchRepository = branchRepository;
        }

        //****************************************

        [HttpGet]
        public ActionResult<GeneralResponse> GetAll()
        {
            List<Branch> branches = branchRepository.FindAll().ToList();

            List<GetBranchDTO> getBranchDTOs = new List<GetBranchDTO>(branches.Count);

            foreach (Branch branch in branches)
            {
                GetBranchDTO dto = new GetBranchDTO()
                {
                    ID = branch.ID,
                    Country = branch.Country,
                    State = branch.State,
                    City = branch.City,
                    Street = branch.Street,
                    PostalCode = branch.PostalCode,
                    HotelID = branch.HotelID,
                };

                getBranchDTOs.Add(dto);
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = getBranchDTOs,
            };
        }

        [HttpGet("{id:int}")]
        public ActionResult<GeneralResponse> GetByID(int id)
        {
            Branch? branch = branchRepository.GetById(id);

            if (branch is null)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "There is no branch found with this ID !"
                };
            }

            GetBranchDTO getBranchDTO = new GetBranchDTO()
            {
                ID = branch.ID,
                Country = branch.Country,
                State = branch.State,
                City = branch.City,
                Street = branch.Street,
                PostalCode = branch.PostalCode,
                HotelID = branch.HotelID,
            };

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = getBranchDTO,
            };
        }

        [HttpGet("byhotel/{id:int}")]
        public ActionResult<GeneralResponse> GetBranchesByHotelID(int id)
        {
            string[] localIncludes = { "Branches" };

            Hotel? hotel = hotelRepository.Find(criteria : h => h.ID == id , includes : localIncludes);

            if (hotel is null)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "There is no hotel found with this ID !"
                };
            }

            List<GetBranchDTO> getBranchDTOs = new List<GetBranchDTO>(hotel.Branches.Count);

            foreach (Branch branch in hotel.Branches)
            {
                GetBranchDTO dto = new GetBranchDTO()
                {
                    ID = branch.ID,
                    Country = branch.Country,
                    State = branch.State,
                    City = branch.City,
                    Street = branch.Street,
                    PostalCode = branch.PostalCode,
                    HotelID = branch.HotelID,
                };

                getBranchDTOs.Add(dto);
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = getBranchDTOs,
            };
        }
    }
}