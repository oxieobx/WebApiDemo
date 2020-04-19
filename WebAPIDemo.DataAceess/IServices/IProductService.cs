using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.DataAceess.GenericCommonService;
using WebAPIDemo.DBO.Entities;

namespace WebAPIDemo.DataAceess.IServices
{
    public interface IProductService  : ICommonService<Product>
    {

    }
}
