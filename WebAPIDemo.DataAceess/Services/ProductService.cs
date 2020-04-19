using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.DataAceess.GenericCommonService;
using WebAPIDemo.DataAceess.IServices;
using WebAPIDemo.DBO.DbContext;
using WebAPIDemo.DBO.Entities;

namespace WebAPIDemo.DataAceess.Services
{
    public class ProductService : IProductService
    {
        private readonly DemoDbContext _context;

        public ProductService(DemoDbContext context)
        {
            this._context = context;
        }

        public async Task<int> Add(Product entity)
        {
             await _context.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var a = _context.Products.Find(id);
            if(a == null)
            {
                return 0;
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<IList<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<int> Update(Product entity)
        {
            var a = ProductExists(entity.Id);

            if (a == false)
            {
                return 0;
            }

            _context.Entry<Product>(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<Product> Find(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        //check exist products
        private bool ProductExists(int id)
        {
            return _context.Products.Any(p => p.Id == id);
        }
    }
}
