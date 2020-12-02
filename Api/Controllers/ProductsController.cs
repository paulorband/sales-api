using Application.Models;
using Application.Services.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase<Product, ProductModel>
	{
		public IProductAppService ProductAppService { get; }

		public ProductsController(IProductAppService productAppService) : base(productAppService)
		{
			ProductAppService = productAppService;
		}
	}
}
