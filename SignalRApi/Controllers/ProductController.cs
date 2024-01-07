﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

	public ProductController(IProductService productService, IMapper mapper)
	{
		_productService = productService;
		_mapper = mapper;
	}

	[HttpGet]
    public IActionResult ProductList()
    {
        var value = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
        return Ok(value);
    }

    [HttpGet]
    public IActionResult ProductCount()
    {
        return Ok(_productService.TProductCount());
    }

	[HttpGet]
	public IActionResult ProductNamePriceByMax()
	{
		return Ok(_productService.TProductNamePriceByMax());
	}

	[HttpGet]
	public IActionResult ProductNamePriceByMin()
	{
		return Ok(_productService.TProductNamePriceByMin());
	}

	[HttpGet]
	public IActionResult ProductAvgPriceByHamburger()
	{
		return Ok(_productService.TProductAvgPriceByHamburger());
	}

	[HttpGet]
	public IActionResult ProductCountByHamburger()
	{
		return Ok(_productService.TProductCountByCategoryNameHamburger());
	}

	[HttpGet]
	public IActionResult ProductCountByDrink()
	{
		return Ok(_productService.TProductCountByCategoryNameDrink());
	}

	[HttpGet]
	public IActionResult ProductPriceAvg()
	{
		return Ok(_productService.TProductPriceAvg());
	}

	[HttpGet]
    public IActionResult ProductListWithCategory()
    {
        var context = new SignalRContext();
        var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategory
        {
            Description = y.Description,
            ImageUrl = y.ImageUrl,
            Price = y.Price,
            ProductId = y.ProductId,
            ProductName = y.ProductName,
            ProductStatus = y.ProductStatus,
            CategoryName = y.Category.CategoryName
        });
        return Ok(values.ToList());
    }

    [HttpPost]
    public IActionResult CreateProduct(CreateProductDto createProductDto)
    {
		_productService.TAdd(new Product()
        {
            Description = createProductDto.Description,
            ImageUrl = createProductDto.ImageUrl,
            Price = createProductDto.Price,
            ProductName = createProductDto.ProductName,
            ProductStatus = createProductDto.ProductStatus,
            CategoryId = createProductDto.CategoryId
        });
        return Ok("Ürün bilgisi eklendi.");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var value = _productService.TGetById(id);
        _productService.TDelete(value);
        return Ok("Ürün bilgisi silindi.");
    }

    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        var value = _productService.TGetById(id);
        return Ok(value);
    }

    [HttpPut]
    public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
    {
        _productService.TUpdate(new Product()
        {
            Description = updateProductDto.Description,
            ImageUrl = updateProductDto.ImageUrl,
            Price = updateProductDto.Price,
            ProductName = updateProductDto.ProductName,
            ProductStatus = updateProductDto.ProductStatus,
            ProductId = updateProductDto.ProductId,
            CategoryId = updateProductDto.CategoryId
        });
        return Ok("Ürün bilgisi güncellendi.");
    }
}
