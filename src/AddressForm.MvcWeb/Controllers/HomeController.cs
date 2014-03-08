using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using AddressForm.MvcWeb.Models;

namespace AddressForm.MvcWeb.Controllers
{
    public class HomeController : AddressFormBaseController
    {
        public async Task<ActionResult> Index()
        {
            var model = new HomeIndexModel();
            model.People.AddRange(await Context.People.ToListAsync());

            return View(model);
        }
    }
}