using Sales.Application.Mappers.Contracts;
using Sales.Application.Models;
using Sales.Application.Services.Contracts;
using Sales.Domain.Entities;
using Sales.Domain.Services.Contracts;

namespace Sales.Application.Services
{
	public class ProductAppService : AppServiceBase<Product, ProductModel>, IProductAppService
	{
		public ProductAppService(IProductService productService, IMapper<Product, ProductModel> productMapper) : base(productService, productMapper)
		{
		}
	}
}
