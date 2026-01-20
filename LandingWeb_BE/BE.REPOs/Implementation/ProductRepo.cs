using BE.BOs.Models;
using BE.DAOs;
using BE.REPOs.Interface;

namespace BE.REPOs.Implementation;

public class ProductRepo : IProductRepo
{
    private readonly ProductDAO _dao;

    public ProductRepo(ProductDAO dao)
    {
        _dao = dao;
    }

    public async Task<List<Product>> GetAllProductsAsync() => await _dao.GetAllAsync();
    public async Task<Product?> GetProductByIdAsync(int id) => await _dao.GetByIdAsync(id);
    public async Task<Product> CreateProductAsync(Product product) => await _dao.CreateAsync(product);
    public async Task UpdateProductAsync(Product product) => await _dao.UpdateAsync(product);
    public async Task DeleteProductAsync(int id) => await _dao.DeleteAsync(id);
}
