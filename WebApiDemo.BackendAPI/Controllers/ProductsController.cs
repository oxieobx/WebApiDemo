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
    public class ProductsController : ControllerBase
    {
        public IProductService _service;
        public ProductsController(IProductService service)
        {
            _service = service;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<ProductResponse>> GetProducts()
        {
            var response = new ProductResponse() { Data = new List<Product>() { }, Success = true };

            var a = await _service.GetAll();

            if(a.Count == 0)
            {
                return response;
            }

            response.Data = a;
            return response;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponse>> GetProduct(int id)
        {
            var response = new ProductResponse() { Data = new List<Product>() { }, Success = true };
            var a = await _service.Find(id);

            if(a == null)
            {
                return response;
            }
            response.Data.Add(a);
            return response;
        }

        // PUT: api/Products/5

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductResponse>> PutProduct(Product product)
        {
            var response = new ProductResponse() { Data = new List<Product>() { }, Success = true };

            var a = await _service.Update(product);
            if(a == 0)
            {
                response.Success = false;
                return response;
            }
            response.Data.Add(product);
            return response;
        }

        // POST: api/Products

        [HttpPost]
        public async Task<ActionResult<ProductResponse>> PostProduct(Product product)
        {
            var response = new ProductResponse() { Data = new List<Product>() { }, Success = true };
            var a = await _service.Add(product);

            if( a == 0)
            {
                response.Success = false;
                return response;
            }
            response.Data.Add(product);

            return response;
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductResponse>> DeleteProduct(int id)
        {
     
            var response = new ProductResponse() { Data = new List<Product>() { }, Success = true };
            var a = await _service.Delete(id);
            if(a == 0)
            {
                response.Success = false;
                return response;
            }
            return response;
        }

     
    }
}
