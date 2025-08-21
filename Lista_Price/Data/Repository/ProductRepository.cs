

using Lista_Price.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Lista_Price.Data.Repository
{

    public class ProductRepository
    {
        private readonly AplicationContext _context;

        public ProductRepository(AplicationContext context)
        {
            _context = context;
         
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product? GetById(int id)
        {
            return _context.Products.FirstOrDefault(e=>e.Id == id);
        }

        public int Create(Product products)
        {
             _context.Products.Add(products);
            _context.SaveChanges();
            return products.Id;
        }

        public Product Update(Product products)
        {
            _context.SaveChanges();
            return products;

        }
        public bool Restore(int productId)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null) return false;

            product.IsActive = true;
            product.UpdatedAt = DateTime.Now;

            _context.SaveChanges();
            return true;
        }



        public bool Delete(Product product)
        {
            product.IsActive = false;
            product.UpdatedAt = DateTime.Now;

            _context.Products.Update(product);
            return _context.SaveChanges() > 0;
        }


    }
}
