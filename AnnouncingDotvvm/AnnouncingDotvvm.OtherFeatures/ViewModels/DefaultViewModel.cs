using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AnnouncingDotvvm.EmbeddedControls.ViewModels;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;

namespace AnnouncingDotvvm.OtherFeatures.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
        [Bind(Direction.ServerToClientFirstRequest)]
        public List<int> Numbers => Enumerable.Range(0, 10).ToList();


        public AddressViewModel Address { get; set; } = new AddressViewModel();
    }
}
