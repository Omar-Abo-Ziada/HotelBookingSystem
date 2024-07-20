using HotelBookingSystem.MVC.Models;
using HotelBookingSystem.MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
                    GeneralResponse generalResponse = JsonConvert.DeserializeObject<GeneralResponse>(jsonResponse);

                    if (generalResponse.IsSuccess)
                    {
                        // Deserialize data into List<GetHotelDTO>
                        hotelViewModels = JsonConvert.DeserializeObject<List<HotelViewModel>>(generalResponse.Data.ToString());
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

        public async Task<IActionResult> Details(int id)
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
                    GeneralResponse generalResponse = JsonConvert.DeserializeObject<GeneralResponse>(jsonResponse);

                    if (generalResponse.IsSuccess)
                    {
                        // Deserialize data into List<GetHotelDTO>
                        branchViewModels = JsonConvert.DeserializeObject<List<BranchViewModel>>(generalResponse.Data.ToString());
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

            return View(branchViewModels);
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
    }
}