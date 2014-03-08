using System.Collections.Generic;

namespace AddressForm.MvcWeb.Models
{
    public class HomeIndexModel
    {
        public List<Person> People { get; private set; }

        public HomeIndexModel()
        {
            People = new List<Person>();
        }
    }
}