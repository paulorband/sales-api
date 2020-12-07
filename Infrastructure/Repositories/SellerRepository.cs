using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.EntityFramework.Repositories
{
	public class SellerRepository : RepositoryBase<Seller>, ISellerRepository
	{
		public SellerRepository(SalesContext salesContext) : base(salesContext)
		{
		}
	}
}
