using Sales.Domain.Entities;
using Sales.Domain.Repositories;
using Sales.Domain.Services.Contracts;

namespace Sales.Domain.Services
{
	public class ProductService : ServiceBase<Product>, IProductService
	{
		public ProductService(IProductRepository productRepository) : base(productRepository)
		{
		}
	}
}
