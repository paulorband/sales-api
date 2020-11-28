using Sales.Domain.Entities;
using Sales.Domain.Repositories;
using Sales.Domain.Services.Contracts;

namespace Sales.Domain.Services
{
	public class SaleService : ServiceBase<Sale>, ISaleService
	{
		public SaleService(ISaleRepository saleRepository) : base(saleRepository)
		{
		}
	}
}
