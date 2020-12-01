using Sales.Application.Mappers.Contracts;
using Sales.Application.Models;
using Sales.Application.Services.Contracts;
using Sales.Domain.Entities;
using Sales.Domain.Services.Contracts;

namespace Sales.Application.Services
{
	public class SaleAppService : AppServiceBase<Sale, SaleModel>, ISaleAppService
	{
		public SaleAppService(ISaleService saleService, IMapper<Sale, SaleModel> saleMapper) : base(saleService, saleMapper)
		{
		}
	}
}
