using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnnouncingDotvvm.EmbeddedControls.DTO;
using DotVVM.Framework.ViewModel;

namespace AnnouncingDotvvm.EmbeddedControls.ViewModels
{
    public class AddressViewModel : DotvvmViewModelBase
    {

        public bool IsInEditMode { get; set; }

        public AddressDTO Address { get; set; } = new AddressDTO()
        {
            Name = "RIGANTI",
            Street = "Sokolovska 352/215",
            City = "Prague",
            CountryId = 1
        };

        public List<CountryDTO> Countries { get; set; } = new List<CountryDTO>()
        {
            new CountryDTO() { Id = 1, Name = "Czech Republic" },
            new CountryDTO() { Id = 2, Name = "Slovakia" },
            new CountryDTO() { Id = 3, Name = "Germany" }
        };

    }
}
