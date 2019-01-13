using aspnetcoregraphql.Data;
using GraphQL.Types;
using System.Linq;

namespace aspnetcoregraphql.Models
{
    public class EasyStoreQuery : ObjectGraphType
    {
        public EasyStoreQuery(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            // 資料回傳型別
            Field<CategoryType>(
                "category", // 查詢命令的名稱
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "id", Description = "Category id"}
                ), // 查詢參數
                resolve: context => categoryRepository.GetCategoryAsync(context.GetArgument<int>("id")).Result // 準備回傳資料
            );

            Field<ProductType>(
                "product",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "id", Description = "Product id"}
                ),
                resolve: context => productRepository.GetProductAsync(context.GetArgument<int>("id")).Result
            );

            Field<CategoryType>(
                "subCategory",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "subId", Description = "SubCategory id" }
                ),
                resolve: context => categoryRepository.GetCategoryBySubIdAsync(context.GetArgument<int>("subId")).Result
            );

            Field<ListGraphType<CategoryType>>(
                "categories",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "offset", Description = "Categories offset" },
                    new QueryArgument<IntGraphType> { Name = "first", Description = "Categories first" }
                ),
                resolve: context => 
                {
                    var categories = categoryRepository.CategoriesAsync().Result;
                    var index = context.GetArgument<int?>("offset");
                    var count = context.GetArgument<int?>("first");
                    if (index.HasValue && count.HasValue)
                        return categories.Skip(index.Value).Take(count.Value).ToList();
                    else
                        return categories;
                }
            );
        }
    }
}