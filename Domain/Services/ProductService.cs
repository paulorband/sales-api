using Domain.Entities;
using Domain.Repositories;
using Domain.Services.Contracts;

namespace Domain.Services
{
	public class ProductService : ServiceBase<Product>, IProductService
	{
		public ProductService(IProductRepository productRepository) : base(productRepository)
		{
		}
	}
}
