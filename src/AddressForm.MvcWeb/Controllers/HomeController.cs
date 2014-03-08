using System.Web.Mvc;

namespace AddressForm.MvcWeb.Controllers
{
    public class HomeController : AddressFormBaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}