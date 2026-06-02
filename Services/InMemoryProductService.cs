using CoreInventory.Models;
namespace CoreInventory.Services
{
    public class InMemoryProductService
    {
        private List<Product> products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Mouse",
                Code = "M001",
                Stock = 10
            },

            new Product
            {
                Id = 2,
                Name = "Teclado",
                Code = "T002",
                Stock = 5
            },

            new Product
            {
                Id = 3,
                Name = "Monitor",
                Code = "MON003",
                Stock = 3
            }
        };

        public List<Product> GetAll()
        {
            return products;
        }
    }