using BE.BOs.Models;
using Microsoft.EntityFrameworkCore;

namespace BE.DAOs;

public class ProductDAO
{
    private readonly AppDbContext _context;

    public ProductDAO(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAllAsync() => 
        await _context.Products
            .Include(p => p.ProductOptions)
            .Include(p => p.ProductImages)
            .ToListAsync();

    public async Task<Product?> GetByIdAsync(int id) => 
        await _context.Products
            .Include(p => p.ProductOptions)
            .Include(p => p.ProductImages)
            .Include(p => p.Reviews)
            .FirstOrDefaultAsync(p => p.ProductId == id);

    public async Task<Product> CreateAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await GetByIdAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
