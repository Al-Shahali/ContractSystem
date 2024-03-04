using Contact.Models;
using Domain.Interfaces;
using Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Contact.Controllers
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContact _icontact;
        public HomeController(ILogger<HomeController> logger, IContact contact)
        {
            _logger = logger;
            _icontact = contact;
        }
        #region Contact
        //[IsLogIn]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> _Contact(int pageindex = 0)
        {
            var data = await _icontact.GetAll();
            return View(data);
        }
        [HttpPost]
        public async Task<JsonResult> ADDContact([FromBody] Domain.Models.Contact contact)
        {
            var result = await _icontact.ADD(contact);
            await _icontact.SaveAll();
            return Json(contact);
        }

        [HttpGet]
        public JsonResult GetContact(int ConCod)
        {
            var result = _icontact.GetContact(ConCod).Result;
            return Json(result);
        }

        [HttpPost]
        public async Task<JsonResult> UPDContact([FromBody] Domain.Models.Contact contact)
        {
            var _contact = _icontact.GetContact(contact.Concod).Result;
            if (_contact != null)
            {
                _contact.Name = contact.Name;
                _contact.Address = contact.Address;
                _contact.Note = contact.Note;
                _icontact.UPDContact(_contact);
                await _icontact.SaveAll();
            }
            return Json(contact);
        }
        [HttpGet]
        public async Task DelContactAsync(int ConCod)
        {
            _icontact.DELContact(ConCod);
            await _icontact.SaveAll();
        }

        #endregion
        //[IsLogIn]

        public IActionResult Privacy()
        {
            return View();
        }
        #region Login
        public IActionResult Login()
        {
            int? usrcod = Convert.ToInt32(Get("usrcod"));
            if (usrcod.HasValue)
            {
                Redirect("Home/Index");
            }
            return View();
        }
        public JsonResult IsUserPass([FromBody] User user)
        {
            var result = Usererrore.CheckUser(user.Name, user.Password);
            if (result == null)
            {
                return Json(Usererrore.GetMSG("STP100"));
            }
            Set("usrcod", result.UsrCod.ToString(), 1);
            return Json(Usererrore.GetMSG("GEN100"));
        }
        #endregion
        public IActionResult NotFound()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region Cookie
        public string? Get(string Key)
        {
            return HttpContext.Request.Cookies[Key];
        }

        public void Set(string key, string value, int? expiretime)
        {
            CookieOptions options = new();
            if (expiretime.HasValue)
                options.Expires = DateTime.Now.AddMinutes(expiretime.Value);
            else
                options.Expires = DateTime.Now.AddMinutes(1);
            Response.Cookies.Append(key, value, options);
        }
        #endregion
    }
}
