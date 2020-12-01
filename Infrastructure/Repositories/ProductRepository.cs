using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.EntityFramework.Repositories
{
	public class ProductRepository : RepositoryBase<Product>, IProductRepository
	{
		public ProductRepository(SalesContext salesContext) : base(salesContext)
		{
		}
	}
}
