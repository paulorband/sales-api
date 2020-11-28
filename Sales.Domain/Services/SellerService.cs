using Sales.Domain.Entities;
using Sales.Domain.Repositories;
using Sales.Domain.Services.Contracts;

namespace Sales.Domain.Services
{
	public class SellerService : ServiceBase<Seller>, ISellerService
	{
		public SellerService(ISellerRepository sellerRepository) : base(sellerRepository)
		{
		}
	}
}
