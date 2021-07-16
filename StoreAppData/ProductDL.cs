using System.Collections.Generic;
using StoreModels;
using System.Linq;

namespace StoreAppData
{
    public class ProductDL : Repository, IProductDL
    {
        // The Singleton for the ProductDl class
        public static ProductDL _productDL = new ProductDL(new StoreAppDBContext(DatabaseConnection.GetDatabaseOptions()));
        public ProductDL(StoreAppDBContext p_context) : base(p_context)
        {
            _context = p_context;
        }

        /// <summary>
        /// Converts an Entities.Product class to a StoreModels.Products class
        /// </summary>
        /// <param name="eProduct">The Entities.Product to be converted</param>
        /// <returns>A converted StoreModels.Products class</returns>
        public static Products EntityToModel(Products eProduct)
        {
            return new Products()
            /*{
                Id = eProduct.ProductId,
                Name = eProduct.ProductName,
                Price = eProduct.ProductPrice,
                Description = eProduct.Description,
                Category = eProduct.Category
            }*/;
        }

        public Products FindProduct(int id)
        {
            Products eProduct = _context.Products.Find(id);
            return eProduct;
        }

        public List<Products> RetrieveProducts()
        {
            return _context.Products.Select(
                rest => rest
            ).ToList();
        }
    }
}