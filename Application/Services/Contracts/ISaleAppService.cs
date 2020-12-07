using Application.Models;
using Domain.Entities;

namespace Application.Services.Contracts
{
	public interface ISaleAppService : IAppServiceBase<Sale, SaleModel>
	{
		void UpdateStatus(SaleStatusModel saleStatusModel);
	}
}
