using Application.Models;
using Domain.Entities;

namespace Application.Services.Contracts
{
	public interface ISellerAppService : IAppServiceBase<Seller, SellerModel>
	{
	}
}
