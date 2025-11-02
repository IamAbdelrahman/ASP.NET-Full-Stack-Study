using Demos.Models;

namespace Demos.Repositories
{
    public class ProductsRepo: GenericRepo<Product>
    {
        public ProductsRepo(ITIContext context) : base(context) { }
    }
}
