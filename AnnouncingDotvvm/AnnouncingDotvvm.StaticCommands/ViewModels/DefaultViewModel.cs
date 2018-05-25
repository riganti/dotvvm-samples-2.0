using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AnnouncingDotvvm.StaticCommands.DTO;
using AnnouncingDotvvm.StaticCommands.Services;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;

namespace AnnouncingDotvvm.StaticCommands.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
        private readonly ProductService productService;


        public BusinessPackDataSet<ProductDTO> Items { get; set; } = new BusinessPackDataSet<ProductDTO>()
        {
            SortingOptions =
            {
                SortExpression = nameof(ProductDTO.ProductId)
            },
            PagingOptions =
            {
                PageSize = 50
            }
        };

        public ReoderDialogViewModel ReorderDialog { get; set; } = new ReoderDialogViewModel();

        public ReoderDialogViewModel ReorderDialog2 { get; set; } = new ReoderDialogViewModel();

        public DefaultViewModel(ProductService productService)
        {
            this.productService = productService;
        }


        public override Task PreRender()
        {
            if (Items.IsRefreshRequired)
            {
                productService.LoadProducts(Items);
            }

            return base.PreRender();
        }


        public void ShowReorderDialog(int id)
        {
            ReorderDialog.Product = productService.GetById(id);
        }

        public void MakeOrder()
        {
            productService.Reorder(ReorderDialog.Product.ProductId, ReorderDialog.OrderQuantity);
            ReorderDialog.Product = null;
        }

        public void CancelOrder()
        {
            ReorderDialog.Product = null;
        }
    }
}
