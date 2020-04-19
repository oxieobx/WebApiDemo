using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIDemo.DataAceess.IServices;
using WebAPIDemo.DataAceess.Services;
using WebAPIDemo.DBO.DbContext;
using WebAPIDemo.DBO.Entities;
using WebAPIDemo.ViewModels.Response;

namespace WebApiDemo.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;




        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<CategoryResponse>> GetCategories()
        {
            CategoryResponse response = new CategoryResponse()
            {
                Data = new List<Category>(),
                Success = true
            };

            var a = await _service.GetAll();
            if (a.Count == 0)
            {
                response.Data = null;
                response.Success = false;
                return response;
            }
            response.Data = a;
            return response;
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResponse>> GetCategory(int id)
        {
            CategoryResponse response = new CategoryResponse()
            {
                Data = new List<Category>(),
                Success = true
            };

            var a = await _service.Find(id);

            if (a != null)
            {
                response.Data.Add(a);
                response.Success = true;
            }

            return response;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryResponse>> UpdateCategory(Category category)
        {
            CategoryResponse reponse = new CategoryResponse()
            {
                Data = new List<Category>(),
                Success = true
            };
            var a = await _service.Update(category);
            if (a == 0)
            {
                reponse.Success = false;
                return reponse;
            }

            reponse.Data.Add(category);
            return reponse;
        }


        [HttpPost]
        public async Task<ActionResult<CategoryResponse>> AddCategory(Category category)
        {
            CategoryResponse reponse = new CategoryResponse()
            {
                Data = new List<Category>(),
                Success = true
            };

            var a = await _service.Add(category);
            if(a == 0)
            {
                reponse.Success = false;
                return reponse;
            }

            reponse.Data.Add(category);
            return reponse;
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryResponse>> DeleteCategory(int id)
        {
            CategoryResponse reponse = new CategoryResponse()
            {
                Data = new List<Category>(),
                Success = true
            };

            var a = await _service.Delete(id);
            if( a == 0)
            {
                reponse.Success = false;
            }
            return reponse;
        }

    }
}
