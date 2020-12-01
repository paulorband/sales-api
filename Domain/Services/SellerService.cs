using Domain.Entities;
using Domain.Repositories;
using Domain.Services.Contracts;

namespace Domain.Services
{
	public class SellerService : ServiceBase<Seller>, ISellerService
	{
		public SellerService(ISellerRepository sellerRepository) : base(sellerRepository)
		{
		}
	}
}
