using HotelBookingSystem.API.Responses;
using HotelBookingSystem.Core.DTOs;
using HotelBookingSystem.Core.Enums;
using HotelBookingSystem.Core.Interfaces;
using HotelBookingSystem.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository bookingRepository;
        private readonly IHotelRepository hotelRepository;
        private readonly IBranchRepository branchRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly ICustomerBookingRepository customerBookingRepository;
        private readonly IRoomRepository roomRepository;

        public BookingController
        (IBookingRepository bookingRepository,
         IHotelRepository hotelRepository,
         IBranchRepository branchRepository,
         ICustomerRepository customerRepository,
         ICustomerBookingRepository customerBookingRepository,
         IRoomRepository roomRepository)
        {
            this.bookingRepository = bookingRepository;
            this.hotelRepository = hotelRepository;
            this.branchRepository = branchRepository;
            this.customerRepository = customerRepository;
            this.customerBookingRepository = customerBookingRepository;
            this.roomRepository = roomRepository;
        }

        //*******************************************************

        [HttpGet]
        public ActionResult<GeneralResponse> GetAll()
        {
            List<Booking> bookings = bookingRepository.FindAll().ToList();

            List<GetBookingDTO> getBookingDTOs = new List<GetBookingDTO>(bookings.Count);

            foreach (Booking booking in bookings)
            {
                GetBookingDTO dto = new GetBookingDTO()
                {
                    ID = booking.ID,
                    CheckIn = booking.CheckIn,
                    CheckOut = booking.CheckOut,
                    BranchID = booking.BranchID,
                };

                getBookingDTOs.Add(dto);
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = getBookingDTOs,
            };
        }

        [HttpGet("{id:int}")]
        public ActionResult<GeneralResponse> GetByID(int id)
        {
            Booking? booking = bookingRepository.GetById(id);

            int customerID = customerBookingRepository.Find(criteria: cb => cb.BookingID == id).CustomerID;

            if (booking is null)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "There is no booking found with this ID !"
                };
            }

            List<Room> rooms = roomRepository.FindAll(criteria: r => r.BookingID == id).ToList();

            List<GetRoomDTO> getRoomDTOs = new List<GetRoomDTO>(rooms.Count);

            foreach (Room room in rooms)
            {
                GetRoomDTO roomDTO = new GetRoomDTO()
                {
                    Id = room.Id,
                    BookingID = room.BookingID ,
                    BranchID = room.BranchID ,
                    Type = room.Type,
                    NumberOfAdults = room.NumberOfAdults,
                    NumberOfChilds = room.NumberOfChilds,
                    IsBooked = room.IsBooked,
                };

                getRoomDTOs.Add(roomDTO);
            }

            GetBookingWithRoomsDTO getBookingWithRoomsDTO = new GetBookingWithRoomsDTO()
            {
                ID = booking.ID,
                CheckIn = booking.CheckIn,
                CheckOut = booking.CheckOut,
                BranchID = booking.BranchID,
                Discount = booking.Discount,
                IsPreviousCustomer = booking.IsPreviousCustomer,
                CustomerID = customerID,

                Rooms = getRoomDTOs 
            };

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = getBookingWithRoomsDTO,
            };
        }

        [HttpGet("{customerID:int}")]
        public ActionResult<GeneralResponse> GetByCustomerID(int customerID)
        {
            List<int> bookingsIDs = customerBookingRepository
                .FindAll(criteria: cb => cb.CustomerID == customerID)
                .Select(cb => cb.BookingID)
                .ToList();

            List<Booking>? bookings = bookingRepository.FindAll(criteria: b => bookingsIDs.Contains(b.ID)).ToList();

            if (bookings is null || !bookings.Any())
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = $"There is no bookings found with for this Customer ID : ({customerID}) !"
                };
            }

            List<GetBookingDTO> getBookingDTOs = new List<GetBookingDTO>(bookings.Count);

            foreach (Booking booking in bookings)
            {
                GetBookingDTO DTO = new GetBookingDTO()
                {
                    ID = booking.ID,
                    BranchID = booking.BranchID,
                    CheckIn = booking.CheckIn,
                    CheckOut = booking.CheckOut,
                    CustomerID = customerID,
                    Discount = booking.Discount,
                    IsPreviousCustomer = booking.IsPreviousCustomer
                };

                getBookingDTOs.Add(DTO);
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = getBookingDTOs,
            };
        }

        [HttpGet("byhotel/{id:int}")]
        public ActionResult<GeneralResponse> GetBranchesByHotelID(int id)
        {
            string[] localIncludes = { "Branches" };

            Hotel? hotel = hotelRepository.Find(criteria: h => h.ID == id, includes: localIncludes);

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

        [HttpPost]
        public ActionResult<GeneralResponse> Add(PostBookingDTO postBookingDTO)
        {
            if (!ModelState.IsValid)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = "Invalid Model State",
                    Data = ModelState,
                };
            }

            Customer? customer = customerRepository.GetById(postBookingDTO.customerID);

            if (customer is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"No Customer Found with this ID : ({postBookingDTO.customerID})",
                };
            }

            if (branchRepository.GetById(postBookingDTO.BranchID) is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"No Branch Found with this ID : ({postBookingDTO.BranchID})",
                };
            }

            if (postBookingDTO.CheckOut < DateTime.Now ||
                postBookingDTO.CheckIn < DateTime.Now ||
                postBookingDTO.CheckIn > postBookingDTO.CheckOut
                )
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"Invalid Check-in and Check-out Times ," +
                    $"both times should be in the future not past , " +
                    $"Checkout Date must be after Checkin Date",
                };
            }

            //-------------------------------------------

            // first getting all the branch rooms

            string[] roomIncludes = { "Booking" };

            List<Room> allBranchRooms = roomRepository.FindAll(criteria: r => r.BranchID == postBookingDTO.BranchID, includes: roomIncludes)
                                            .ToList();

            if (allBranchRooms.Count < postBookingDTO.NumberOfRooms)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"Number of Rooms : ({postBookingDTO.NumberOfRooms}) Bigger than the All Bracnh Rooms : ({allBranchRooms.Count}) !",
                };
            }

            //-------------------------------------------

            //then getting the availabel branch rooms

            ICollection<Room> availableBranchRooms = new HashSet<Room>();

            foreach (Room room in allBranchRooms)
            {
                if (room?.Booking?.CheckOut is null || DateTime.Now >= room?.Booking?.CheckOut)
                {
                    room.IsBooked = false;
                    availableBranchRooms.Add(room);
                }
            }

            if (availableBranchRooms.Count == 0)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = "There are no avilable rooms in this branch",
                };
            }

            //-------------------------------------------

            // then checking if the avilable rooms in the types he wants or not

            //ICollection<Room> wantedRooms = new HashSet<Room>();

            int numberOfWantedSingleRooms = 0;
            int numberOfWantedDoubleRooms = 0;
            int numberOfWantedSuiteRooms = 0;

            foreach (PostRoomDTO roomDTO in postBookingDTO.postRoomDTOs)
            {
                if (roomDTO.Type == RoomType.Single)
                {
                    numberOfWantedSingleRooms++;
                }
                else if (roomDTO.Type == RoomType.Double)
                {
                    numberOfWantedDoubleRooms++;
                }
                else if (roomDTO.Type == RoomType.Suite)
                {
                    numberOfWantedSuiteRooms++;
                }
            }

            int numberOfAvailableSingleRooms = 0;
            int numberOfAvailableDoubleRooms = 0;
            int numberOfAvailableSuiteRooms = 0;

            foreach (Room room in availableBranchRooms)
            {
                if (room.Type == RoomType.Single)
                {
                    numberOfAvailableSingleRooms++;
                }
                else if (room.Type == RoomType.Double)
                {
                    numberOfAvailableDoubleRooms++;
                }
                else if (room.Type == RoomType.Suite)
                {
                    numberOfAvailableSuiteRooms++;
                }
            }

            if (numberOfAvailableSingleRooms < numberOfWantedSingleRooms ||
                numberOfAvailableDoubleRooms < numberOfWantedDoubleRooms ||
                numberOfAvailableSuiteRooms < numberOfWantedSuiteRooms)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"There are only avilable Single Rooms : ({numberOfAvailableSingleRooms}) ," +
                    $" Double Rooms : ({numberOfAvailableDoubleRooms}) ," +
                    $" Siute Rooms : ({numberOfAvailableSuiteRooms})"
                };
            }

            //***********************************************************************

            // if reached here then all the wanted rooms are available in this time and with the types he want .
            // then start Booking Process :)

            Booking booking = new Booking()
            {
                BranchID = postBookingDTO.BranchID,
                CheckIn = postBookingDTO.CheckIn,
                CheckOut = postBookingDTO.CheckOut,
            };

            // check if the customer booked before or not .
            if (customerBookingRepository.Find(cb => cb.CustomerID == postBookingDTO.customerID) is null)
            {
                booking.IsPreviousCustomer = false;
                booking.Discount = 0m;
            }
            else
            {
                booking.IsPreviousCustomer = true;
                booking.Discount = 0.05m;

                customer.IsPreviousCustomer = true;
                customerBookingRepository.Save();
            }

            bookingRepository.Add(booking);
            bookingRepository.Save(); // to get the Booking ID from EF and use it in the Rooms and Join table

            CustomerBooking customerBooking = new CustomerBooking()
            {
                BookingID = booking.ID,
                CustomerID = postBookingDTO.customerID,
            };

            customerBookingRepository.Add(customerBooking);
            customerBookingRepository.Save();

            //----------------------------------------------

            // then getting the wanted Rooms and updating their info

            ICollection<Room> wantedRooms = new HashSet<Room>();

            foreach (PostRoomDTO postRoomDTO in postBookingDTO.postRoomDTOs)
            {
                if (postRoomDTO.Type == RoomType.Single && numberOfWantedSingleRooms > 0)
                {
                    Room? singleAvailabeRoom = availableBranchRooms.FirstOrDefault(r => r.Type == RoomType.Single);

                    singleAvailabeRoom.IsBooked = true;
                    singleAvailabeRoom.BookingID = booking.ID;
                    singleAvailabeRoom.NumberOfChilds = postRoomDTO.NumberOfChilds;
                    singleAvailabeRoom.NumberOfAdults = postRoomDTO.NumberOfAdults;

                    wantedRooms.Add(singleAvailabeRoom);

                    availableBranchRooms.Remove(singleAvailabeRoom);
                    numberOfWantedSingleRooms--;
                }
                else if (postRoomDTO.Type == RoomType.Double && numberOfWantedDoubleRooms > 0)
                {
                    Room? doubleAvailabeRoom = availableBranchRooms.FirstOrDefault(r => r.Type == RoomType.Double);

                    doubleAvailabeRoom.IsBooked = true;
                    doubleAvailabeRoom.BookingID = booking.ID;
                    doubleAvailabeRoom.NumberOfChilds = postRoomDTO.NumberOfChilds;
                    doubleAvailabeRoom.NumberOfAdults = postRoomDTO.NumberOfAdults;

                    wantedRooms.Add(doubleAvailabeRoom);

                    availableBranchRooms.Remove(doubleAvailabeRoom);
                    numberOfWantedDoubleRooms--;
                }
                else if (postRoomDTO.Type == RoomType.Suite && numberOfWantedSuiteRooms > 0)
                {
                    Room? suiteAvailabeRoom = availableBranchRooms.FirstOrDefault(r => r.Type == RoomType.Suite);

                    suiteAvailabeRoom.IsBooked = true;
                    suiteAvailabeRoom.BookingID = booking.ID;
                    suiteAvailabeRoom.NumberOfChilds = postRoomDTO.NumberOfChilds;
                    suiteAvailabeRoom.NumberOfAdults = postRoomDTO.NumberOfAdults;

                    wantedRooms.Add(suiteAvailabeRoom);

                    availableBranchRooms.Remove(suiteAvailabeRoom);
                    numberOfWantedSuiteRooms--;
                }
            }

            roomRepository.Save();

            //**************************************************
            // last : Now Returning the Booked Rooms in list of DTO

            List<GetRoomDTO> getRoomDTOs = new List<GetRoomDTO>();

            foreach (Room room in wantedRooms)
            {
                GetRoomDTO roomDTO = new GetRoomDTO()
                {
                    Id = room.Id,
                    BookingID = room.BookingID,
                    BranchID = room.BranchID,
                    IsBooked = room.IsBooked,
                    NumberOfAdults = room.NumberOfAdults,
                    NumberOfChilds = room.NumberOfChilds,
                    Type = room.Type
                };

                getRoomDTOs.Add(roomDTO);
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Message = $"({wantedRooms.Count}) Rooms Booked Successfully by customer with ID ({postBookingDTO.customerID}) in Branch with ID ({postBookingDTO.BranchID}) . ",
                Data = getRoomDTOs,
            };
        }

    }
}