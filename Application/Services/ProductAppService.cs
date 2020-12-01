using Application.Mappers.Contracts;
using Application.Models;
using Application.Services.Contracts;
using Domain.Entities;
using Domain.Services.Contracts;

namespace Application.Services
{
	public class ProductAppService : AppServiceBase<Product, ProductModel>, IProductAppService
	{
		public ProductAppService(IProductService productService, IMapper<Product, ProductModel> productMapper) : base(productService, productMapper)
		{
		}
	}
}
