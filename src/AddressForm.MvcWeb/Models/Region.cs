using System;
using System.ComponentModel.DataAnnotations;

namespace AddressForm.MvcWeb.Models
{
    public class Region
    {
        public Guid Id { get; set; }

        [MaxLength(2)]
        public string CountryId { get; set; }
        public Country Country { get; set; }

        [MaxLength(2)]
        public string Abbreviation { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
    }
}