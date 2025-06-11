namespace Demo_Lec1.Models
{
    public class ProductRepo
    {
        public List<Product> Products = new List<Product>();
        public List<Product> LoadProducts()
        {
            return new List<Product>()
            {
                new Product() { Id = 1, Name = "Iphone1", Description = "Mobile1", Image="1.png", Price = 1000 },
                new Product() { Id = 2, Name = "Iphone2", Description = "Mobile2", Image="2.png", Price = 2000 },
                new Product() { Id = 3, Name = "Iphone3", Description = "Mobile3", Image="3.png", Price = 3000 },
                new Product() { Id = 4, Name = "Iphone4", Description = "Mobile4", Image="4.png", Price = 4000 }
            };
        }
        public List<Product> GetProducts()
        {
            return LoadProducts();
        }
        public Product GetProductById(int id)
        {
            var products = GetProducts();
            var result = products.Find(x => x.Id == id);
            return result;
        }
    }
}
