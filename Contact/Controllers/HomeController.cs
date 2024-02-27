using Contact.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Contact.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContact _icontact;
        public HomeController(ILogger<HomeController> logger,IContact contact)
        {
            _logger = logger;
            _icontact = contact;
        }
        #region Contact
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> _Contact(int pageindex=0)
        {
            var data =await _icontact.GetAll();
            var x = data.Count();
            return View(data.ToList());
        }
        [HttpPost]
        public async Task<JsonResult> ADDContact([FromBody]Domain.Models.Contact  contact)
        {
           var result= await _icontact.ADD(contact);
           await _icontact.SaveAll();
            return Json(contact);
        }

        #endregion
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
