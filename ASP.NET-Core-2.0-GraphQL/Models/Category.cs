using System.Collections.Generic;

namespace aspnetcoregraphql.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SubCateId { get; set; }

        List<Product> Products { get; set; }
    }
}