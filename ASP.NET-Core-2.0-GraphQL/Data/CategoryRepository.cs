using System.Collections.Generic;
using System.Threading.Tasks;
using aspnetcoregraphql.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace aspnetcoregraphql.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private List<Category> _categories;

        public CategoryRepository()
        {
            _categories = new List<Category>{
                new Category()
                {
                    Id = 1,
                    Name = "Computers",
                    SubCateId = 1
                },
                new Category()
                {
                    Id = 2,
                    Name = "Mobile Phones",
                    SubCateId = 2
                }
            };
        }

        public Task<List<Category>> CategoriesAsync()
        {
            return Task.FromResult(_categories);
        }

        public Task<Category> GetCategoryAsync(int id)
        {
            return Task.FromResult(_categories.FirstOrDefault(x => x.Id == id));
        }

        public Task<Category> GetCategoryBySubIdAsync(int subId)
        {
            return Task.FromResult(_categories.FirstOrDefault(x => x.SubCateId == subId));
        }
    }
}