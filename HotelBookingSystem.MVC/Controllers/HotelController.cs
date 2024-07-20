using HotelBookingSystem.Core.DTOs;
using HotelBookingSystem.MVC.Models;
using HotelBookingSystem.MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelBookingSystem.MVC.Controllers
{
    //[Authorize(Roles = "Customer")]
    public class HotelController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:5006/api/");

        private readonly HttpClient httpClient;

        public HotelController()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = baseAddress;
        }

        public async Task<IActionResult> Index()
        {
            bool tokenExisted = CheckSessionToken();

            if (!tokenExisted)
            {
                return RedirectToAction("Register", "Account");
            }

            List<HotelViewModel> hotelViewModels = new List<HotelViewModel>();

            try
            {
                HttpResponseMessage httpResponse = await httpClient.GetAsync("Hotel/GetAll");

                if (httpResponse.IsSuccessStatusCode)
                {
                    string jsonResponse = await httpResponse.Content.ReadAsStringAsync();

                    // Deserialize the entire response into GeneralResponse
                    GeneralResponse? generalResponse = JsonConvert.DeserializeObject<GeneralResponse>(jsonResponse);

                    if (generalResponse?.IsSuccess ?? false)
                    {
                        // Deserialize data into List<GetHotelDTO>
                        hotelViewModels = JsonConvert.DeserializeObject<List<HotelViewModel>>(generalResponse?.Data?.ToString());
                    }
                    else
                    {
                        // Handle unsuccessful response
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
                else
                {
                    // Handle unsuccessful HTTP response
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            catch (Exception ex)
            {
                // Here we're just adding a model error
                ModelState.AddModelError(string.Empty, $"Error occurred: {ex.Message}");
            }

            return View(hotelViewModels);
        }

        public async Task<IActionResult> HotelBranches(int id)
        {
            bool tokenExisted = CheckSessionToken();

            if (!tokenExisted)
            {
                return RedirectToAction("Register", "Account");
            }

            List<BranchViewModel> branchViewModels = new List<BranchViewModel>();

            try
            {
                HttpResponseMessage httpResponse = await httpClient.GetAsync($"Branch/byhotel/{id}");

                if (httpResponse.IsSuccessStatusCode)
                {
                    string jsonResponse = await httpResponse.Content.ReadAsStringAsync();

                    // Deserialize the entire response into GeneralResponse
                    GeneralResponse? generalResponse = JsonConvert.DeserializeObject<GeneralResponse>(jsonResponse);

                    if (generalResponse?.IsSuccess ?? false)
                    {
                        // Deserialize data into List<GetHotelDTO>
                        branchViewModels = JsonConvert.DeserializeObject<List<BranchViewModel>>(generalResponse?.Data?.ToString());
                    }
                    else
                    {
                        // Handle unsuccessful response
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
                else
                {
                    // Handle unsuccessful HTTP response
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            catch (Exception ex)
            {
                // Here we're just adding a model error
                ModelState.AddModelError(string.Empty, $"Error occurred: {ex.Message}");
            }

            return View("HotelBranches" ,branchViewModels);
        }

        public async Task<IActionResult> CustomerBookings( )
        {
            bool tokenExisted = CheckSessionToken();

            if (!tokenExisted)
            {
                return RedirectToAction("Register", "Account");
            }

            //------------------------------------------

            List<GetBookingDTO> getBookingDTOs = new List<GetBookingDTO>();

            try
            {
                int? customerID = await GetCustomerIDFromSession();

                if (customerID is null)
                {
                    ModelState.AddModelError(string.Empty, $"Can't Parse CustomerID ({customerID}) from Session , " +
                                                           $"Not found or Invalid Format");

                    return RedirectToAction("Login", "Account");
                }
              
                HttpResponseMessage httpResponse = await httpClient.GetAsync($"Booking/GetByCustomerID/{customerID}");

                if (httpResponse.IsSuccessStatusCode)
                {
                    string jsonResponse = await httpResponse.Content.ReadAsStringAsync();

                    // Deserialize the entire response into GeneralResponse
                    GeneralResponse? generalResponse = JsonConvert.DeserializeObject<GeneralResponse>(jsonResponse);

                    if (generalResponse?.IsSuccess ?? false)
                    {
                        // Deserialize data into List<GetHotelDTO>
                        getBookingDTOs = JsonConvert.DeserializeObject<List<GetBookingDTO>>(generalResponse?.Data?.ToString());
                    }
                    else
                    {
                        // Handle unsuccessful response
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
                else
                {
                    // Handle unsuccessful HTTP response
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            catch (Exception ex)
            {
                // Here we're just adding a model error
                ModelState.AddModelError(string.Empty, $"Error occurred: {ex.Message}");
            }

            return View(getBookingDTOs);
        }

        public async Task<IActionResult> BookingDetails(int id)
        {
            bool tokenExisted = CheckSessionToken();

            if (!tokenExisted)
            {
                return RedirectToAction("Register", "Account");
            }

            //-------------------------------------------------

            GetBookingWithRoomsDTO getBookingWithRoomsDTO = new GetBookingWithRoomsDTO();

            try
            {
                HttpResponseMessage httpResponse = await httpClient.GetAsync($"Booking/GetByID/{id}");

                if (httpResponse.IsSuccessStatusCode)
                {
                    string jsonResponse = await httpResponse.Content.ReadAsStringAsync();

                    // Deserialize the entire response into GeneralResponse
                    GeneralResponse? generalResponse = JsonConvert.DeserializeObject<GeneralResponse>(jsonResponse);

                    if (generalResponse?.IsSuccess ?? false)
                    {
                        // Deserialize data into List<GetHotelDTO>
                        getBookingWithRoomsDTO = JsonConvert.DeserializeObject<GetBookingWithRoomsDTO>(generalResponse?.Data?.ToString());
                    }
                    else
                    {
                        // Handle unsuccessful response
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
                else
                {
                    // Handle unsuccessful HTTP response
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            catch (Exception ex)
            {
                // Here we're just adding a model error
                ModelState.AddModelError(string.Empty, $"Error occurred: {ex.Message}");
            }

            return View("BookingDetails" , getBookingWithRoomsDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Book(int branchID)
        {
            bool tokenExisted = CheckSessionToken();

            if (!tokenExisted)
            {
                return RedirectToAction("Register", "Account");
            }

            //-------------------------------------------

            int? customerID = await GetCustomerIDFromSession();

            if (customerID is null)
            {
                ModelState.AddModelError(string.Empty, $"Can't Parse CustomerID ({customerID}) from Session , " +
                                                       $"Not found or Invalid Format");

                return RedirectToAction("Login", "Account");
            }
            else
            {
                PostBookingDTO postBookingDTO = new PostBookingDTO();
                postBookingDTO.BranchID = branchID;
                postBookingDTO.customerID = (int)customerID;

                return View(postBookingDTO);
            }


            //if (int.TryParse(HttpContext.Session.GetString("CustomerID"), out int customerID))
            //{
            //    GetCustomerDTO? getCustomerDTO = await GetCustomerByID(customerID);

            //    if (getCustomerDTO is null)
            //    {
            //        ModelState.AddModelError(string.Empty, $"Can't find customer with this ID : ({customerID})");
            //        return RedirectToAction("Login", "Account");
            //    }
            //    else
            //    {
            //        PostBookingDTO postBookingDTO = new PostBookingDTO();
            //        postBookingDTO.BranchID = branchID;
            //        postBookingDTO.customerID = customerID;

            //        return View(postBookingDTO);
            //    }
            //}
            //else
            //{
            //    ModelState.AddModelError(string.Empty, "Can't Parse CustomerID from Session , Not found or Invalid Format");
            //    return RedirectToAction("Login", "Account");
            //}
        }

        [HttpPost]
        public IActionResult BookRooms(PostBookingDTO postBookingDTO)
        {
            bool tokenExisted = CheckSessionToken();

            if (!tokenExisted)
            {
                return RedirectToAction("Register", "Account");
            }

            //-------------------------------------------

            if(postBookingDTO?.NumberOfRooms == 0)
            {
                ModelState.AddModelError(string.Empty, $"Number Of Rooms Must be bigger than Zero .");

                return RedirectToAction("Book" , new { branchID  = postBookingDTO.BranchID});
            }

            if (postBookingDTO.CheckIn <= DateTime.Now || 
                postBookingDTO.CheckOut <= DateTime.Now ||
                postBookingDTO.CheckIn >= postBookingDTO.CheckOut)
            {
                //ModelState.AddModelError(string.Empty, $"Invalid Check-in and Check-out Times ," +
                //                                        $"both times should be in the future not past , " +
                //                                        $"Checkout Date must be after Checkin Date");

                return View("Book");
            }

            List<PostRoomDTO> postRoomDTOs = new List<PostRoomDTO>(postBookingDTO.NumberOfRooms);

            postBookingDTO.postRoomDTOs = postRoomDTOs;

            //ViewBag.NoOfRooms = postBookingDTO.NumberOfRooms;

            return View(postBookingDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitBooking(PostBookingDTO postBookingDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                HttpResponseMessage httpResponse = await httpClient.PostAsJsonAsync("Booking/Add", postBookingDTO);

                if (httpResponse.IsSuccessStatusCode)
                {
                    string jsonResponse = await httpResponse.Content.ReadAsStringAsync();

                    // Deserialize the entire response into GeneralResponse
                    GeneralResponse? generalResponse = JsonConvert.DeserializeObject<GeneralResponse>(jsonResponse);

                    if (generalResponse?.IsSuccess ?? false)
                    {
                        //HttpContext.Session.Set("CustomerID", Encoding.UTF8.GetBytes(generalResponse.Data.ToJson()));

                        if (int.TryParse(HttpContext.Session.GetString("CustomerID"), out int customerID))
                        {
                            GetCustomerDTO? getCustomerDTO = await GetCustomerByID(customerID);

                            if (getCustomerDTO is null)
                            {
                                ModelState.AddModelError(string.Empty, $"Can't find customer with this ID : ({customerID})");
                            }
                            else
                            {

                                return RedirectToAction("BookingSuccess");

                            }
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Can't Parse CustomerID from Session , Not found or Invalid Format");
                        }

                        return View("Login");
                    }
                    else
                    {
                        // Handle unsuccessful response
                        ModelState.AddModelError(string.Empty, $"Server Message : {generalResponse?.Message} ");
                    }
                }
                else
                {
                    // Handle unsuccessful HTTP response
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error occurred: {ex.Message}");
            }

            return View("Book");
        }

        private bool CheckSessionToken()
        {
            var token = HttpContext.Session.GetString("Token");
            var tokenExpired = HttpContext.Session.GetString("TokenExpires");

            if (string.IsNullOrEmpty(token))
            {
                return false;
            }
            return true;
        }

        private async Task<GetCustomerDTO> GetCustomerByID(int id)
        {
            GetCustomerDTO? getCustomerDTO = new GetCustomerDTO();

            try
            {
                HttpResponseMessage httpResponse = await httpClient.GetAsync($"Customer/GetByID/{id}");

                if (httpResponse.IsSuccessStatusCode)
                {
                    string jsonResponse = await httpResponse.Content.ReadAsStringAsync();

                    // Deserialize the entire response into GeneralResponse
                    GeneralResponse? generalResponse = JsonConvert.DeserializeObject<GeneralResponse>(jsonResponse);

                    if (generalResponse?.IsSuccess ?? false)
                    {
                        // Deserializing data 
                        getCustomerDTO = JsonConvert.DeserializeObject<GetCustomerDTO>(generalResponse?.Data?.ToString());
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
                else
                {
                    // Handle unsuccessful HTTP response
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            catch (Exception ex)
            {
                // Here we're just adding a model error
                ModelState.AddModelError(string.Empty, $"Error occurred: {ex.Message}");
            }

            return getCustomerDTO;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Hotel/BookingSuccess")]
        public IActionResult BookingSuccess()
        {
            return View();
        }

        private async Task<int?> GetCustomerIDFromSession()
        {
            if (int.TryParse(HttpContext.Session.GetString("CustomerID"), out int customerID))
            {
                GetCustomerDTO? getCustomerDTO = await GetCustomerByID(customerID);

                if (getCustomerDTO is null)
                {
                    ModelState.AddModelError(string.Empty, $"Can't find customer with this ID : ({customerID})");
                    //RedirectToAction("Login", "Account");
                    return null;
                }
                else
                {
                    //PostBookingDTO postBookingDTO = new PostBookingDTO();
                    //postBookingDTO.BranchID = branchID;
                    //postBookingDTO.customerID = customerID;

                    //return View(postBookingDTO);
                    return customerID;
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Can't Parse CustomerID from Session , Not found or Invalid Format");
                //return RedirectToAction("Login", "Account");
                return null;
            }

        }
    }
}