using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo.DataAceess.IServices;
using WebAPIDemo.DBO.DbContext;
using WebAPIDemo.DBO.Entities;

namespace WebAPIDemo.DataAceess.Services
{
    public class CategoryService : ICategoryService
    {
        DemoDbContext _context;
        public CategoryService(DemoDbContext context)
        {
            this._context = context;
        }

        public async Task<int> Add(Category entity)
        {
            _context.Categories.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {

            var a = _context.Categories.Find(id);

            if(a == null)
            {
                return 0;
            }
            _context.Categories.Remove(a);
            return await _context.SaveChangesAsync();
        }

        public async Task<Category> Find(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<IList<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<int> Update(Category entity)
        {
            var a = CategoryExists(entity.Id);
            if(a == false)
            {
                return 0;
            }

            _context.Entry<Category>(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        //check exist category
        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
