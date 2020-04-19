using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPIDemo.ViewModels.Response
{
    public class BaseResponse<T> where T : class
    {
        public IList<T> Data { get; set; }
        public bool Success { get; set; }
    }
}
