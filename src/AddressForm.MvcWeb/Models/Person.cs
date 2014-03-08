using System;
using System.ComponentModel.DataAnnotations;

namespace AddressForm.MvcWeb.Models
{
    public class Person
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string StreetAddress { get; set; }

        [MaxLength(100)]
        public string ExtendedAddress { get; set; }

        [MaxLength(50)]
        public string Locality { get; set; }

        [MaxLength(50)]
        public string Region { get; set; }

        [MaxLength(30)]
        public string PostalCode { get; set; }

        [Required]
        [MaxLength(2)]
        public string Country { get; set; }
    }
}