using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnnouncingDotvvm.StaticCommands.DTO;
using AnnouncingDotvvm.StaticCommands.Model;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;

namespace AnnouncingDotvvm.StaticCommands.Services
{
    public class ProductService
    {
        private readonly NorthwindContext context;

        public ProductService(NorthwindContext context)
        {
            this.context = context;
        }


        public void LoadProducts(BusinessPackDataSet<ProductDTO> products)
        {
            var queryable = GetProductsQuery();
            products.LoadFromQueryable(queryable);
        }

        [AllowStaticCommand]
        public ProductDTO GetById(int id)
        {
            var queryable = GetProductsQuery();
            return queryable.Single(p => p.ProductId == id);
        }

        private IQueryable<ProductDTO> GetProductsQuery()
        {
            var queryable = context.Products
                .Select(p => new ProductDTO()
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    QuantityPerUnit = p.QuantityPerUnit,
                    UnitPrice = p.UnitPrice,
                    UnitsInStock = p.UnitsInStock,
                    UnitsOnOrder = p.UnitsOnOrder,
                    Discontinued = p.Discontinued,
                    ReorderLevel = p.ReorderLevel,
                    CategoryName = p.Category.CategoryName,
                    SupplierName = p.Supplier.CompanyName
                });
            return queryable;
        }

        [AllowStaticCommand]
        public void Reorder(int productId, int quantity)
        {
            var product = context.Products.Find(productId);
            product.UnitsOnOrder += (short)quantity;

            context.SaveChanges();
        }
    }
}
