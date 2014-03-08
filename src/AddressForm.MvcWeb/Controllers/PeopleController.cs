using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AddressForm.MvcWeb.Controllers
{
    public class PeopleController : AddressFormBaseController
    {
        public ActionResult New()
        {
            return View();
        }
    }
}