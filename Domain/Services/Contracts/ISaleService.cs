using Domain.Entities;

namespace Domain.Services.Contracts
{
	public interface ISaleService : IServiceBase<Sale>
	{
		void UpdateStatus(Sale sale, SaleStatus newStatus);
	}
}
