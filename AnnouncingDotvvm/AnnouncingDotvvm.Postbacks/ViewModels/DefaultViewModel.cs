using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;

namespace AnnouncingDotvvm.Postbacks.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {

        public List<int> Cargos { get; set; } = new List<int>();

        public int Index { get; set; }

        public void SendCargo(int index)
        {
            Thread.Sleep(3000);
            Cargos.Insert(0, index);
        }

    }
}
