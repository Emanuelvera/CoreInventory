using CoreInventory.Models;

namespace CoreInventory.Services;

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

    public Product? GetById(int id)
    {
        return products.FirstOrDefault(p => p.Id == id);
    }

    public void Delete(Product product)
    {
        products.Remove(product);
    }

    public Product Add(Product product)
    {
        product.Id = products.Any() ? products.Max(p => p.Id) + 1 : 1;
        products.Add(product);
        return product;
    }

    public Product? Update(int id, Product updatedProduct)
    {
        var existing = products.FirstOrDefault(p => p.Id == id);
        if (existing == null) return null;

        existing.Name = updatedProduct.Name;
        existing.Code = updatedProduct.Code;
        existing.Stock = updatedProduct.Stock;
        return existing;
    }
}
