using BE.API.DTOs;
using BE.REPOs.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BE.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepo _productRepo;

    public ProductsController(IProductRepo productRepo)
    {
        _productRepo = productRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productRepo.GetAllProductsAsync();
        var result = products.Select(p => new ProductDTO
        {
            ProductId = p.ProductId,
            Name = p.Name,
            Description = p.Description,
            ProductType = p.ProductType,
            Category = p.Category,
            ThumbnailUrl = p.ThumbnailUrl,
            LivePreviewUrl = p.LivePreviewUrl,
            Options = p.ProductOptions.Select(o => new ProductOptionDTO
            {
                ProductOptionId = o.ProductOptionId,
                OptionType = o.OptionType,
                Price = o.Price,
                Description = o.Description
            }).ToList(),
            Images = p.ProductImages.OrderBy(i => i.DisplayOrder).Select(i => i.ImageUrl).ToList()
        });

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _productRepo.GetProductByIdAsync(id);
        if (product == null)
            return NotFound();

        var result = new ProductDTO
        {
            ProductId = product.ProductId,
            Name = product.Name,
            Description = product.Description,
            ProductType = product.ProductType,
            Category = product.Category,
            ThumbnailUrl = product.ThumbnailUrl,
            LivePreviewUrl = product.LivePreviewUrl,
            Options = product.ProductOptions.Select(o => new ProductOptionDTO
            {
                ProductOptionId = o.ProductOptionId,
                OptionType = o.OptionType,
                Price = o.Price,
                Description = o.Description
            }).ToList(),
            Images = product.ProductImages.OrderBy(i => i.DisplayOrder).Select(i => i.ImageUrl).ToList()
        };

        return Ok(result);
    }
}
