using System.Net.Http.Json;
using CoreInventory.Web.Models;

namespace CoreInventory.Web.Services;

public class ApiService
{
    private readonly HttpClient _http;

    public ApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        var result = await _http.GetFromJsonAsync<List<Product>>("Products");
        return result ?? [];
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _http.GetFromJsonAsync<Product>($"Products/{id}");
    }

    public async Task<Product?> CreateAsync(Product product)
    {
        var response = await _http.PostAsJsonAsync("Products", product);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Product>();
    }

    public async Task<Product?> UpdateAsync(int id, Product product)
    {
        var response = await _http.PutAsJsonAsync($"Products/{id}", product);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Product>();
    }

    public async Task DeleteAsync(int id)
    {
        var response = await _http.DeleteAsync($"Products/{id}");
        response.EnsureSuccessStatusCode();
    }
}
