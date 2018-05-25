using System;
using System.Collections.Generic;
using System.Linq;

namespace AnnouncingDotvvm.EmbeddedControls.DTO
{
    public class AddressDTO
    {

        public string Name { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string ZIP { get; set; }

        public bool IsCompany { get; set; }

        public string CompanyNumber { get; set; }

        public int CountryId { get; set; }
    }
}