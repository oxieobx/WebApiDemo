using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPIDemo.DBO.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public IList<Product> Products { get; set; }
    }
}
