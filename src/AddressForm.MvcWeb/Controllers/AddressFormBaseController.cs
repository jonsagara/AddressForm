using System.Web.Mvc;
using AddressForm.MvcWeb.Models;

namespace AddressForm.MvcWeb.Controllers
{
    public class AddressFormBaseController : Controller
    {
        protected AddressFormDbContext Context { get; private set; }


        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Context = new AddressFormDbContext();

            base.OnActionExecuting(filterContext);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            using (Context) { }

            base.OnActionExecuted(filterContext);
        }
    }
}