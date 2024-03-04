using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealContactController : ControllerBase
    {
        private readonly ILogger<RealContactController> _logger;
        private readonly IContact _icontact;
        public RealContactController(ILogger<RealContactController> logger, IContact contact)
        {
            _logger = logger;
            _icontact = contact;
        }
        [HttpPost]
        public IActionResult GetContact()
        {
            var pageSize = int.Parse(Request.Form["length"]);
            var skip = int.Parse(Request.Form["start"]);

            var searchValue = Request.Form["search[value]"];

            var sortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"], "][name]")];
            var sortColumnDirection = Request.Form["order[0][dir]"];

            IQueryable<Domain.Models.Contact> _Contact = _icontact.ENQ(m => string.IsNullOrEmpty(searchValue)
                ? true
                : (m.Name.Contains(searchValue) || m.Address.Contains(searchValue) || m.Note.Contains(searchValue) || m.Phone.Contains(searchValue)));

            //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            //    _Contact = _Contact.OrderBy(string.Concat(sortColumn, " ", sortColumnDirection));

            var data = _Contact.Skip(skip).Take(pageSize).ToList();

            var recordsTotal = _Contact.Count();

            var jsonData = new { recordsFiltered = recordsTotal, recordsTotal, data };

            return Ok(jsonData);
        }
    }
}
