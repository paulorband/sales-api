using Application.Mappers.Contracts;
using Application.Models;
using Application.Services.Contracts;
using Domain.Entities;
using Domain.Services.Contracts;

namespace Application.Services
{
	public class SaleAppService : AppServiceBase<Sale, SaleModel>, ISaleAppService
	{
		public SaleAppService(ISaleService saleService, IMapper<Sale, SaleModel> saleMapper) : base(saleService, saleMapper)
		{
			SaleService = saleService;
		}

		public ISaleService SaleService { get; }

		public void UpdateStatus(SaleStatusModel saleStatusModel)
		{
			Sale sale = Service.GetById(saleStatusModel.SaleId);

			SaleService.UpdateStatus(sale, saleStatusModel.Status);
		}
	}
}
