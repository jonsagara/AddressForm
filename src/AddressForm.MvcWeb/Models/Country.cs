using System.ComponentModel.DataAnnotations;

namespace AddressForm.MvcWeb.Models
{
    public class Country
    {
        [MaxLength(2)]
        public string Id { get; set; }

        [MaxLength(3)]
        public string Alpha3Code { get; set; }

        [MaxLength(3)]
        public string NumericCode { get; set; }

        [MaxLength(13)]
        public string Iso3166_2Code { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
    }
}