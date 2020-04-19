using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPIDemo.DBO.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
