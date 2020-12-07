using Application.Models;
using Application.Services.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class SaleController : ControllerBase<Sale, SaleModel>
	{
		public SaleController(ISaleAppService saleAppService) : base(saleAppService)
		{
			SaleAppService = saleAppService;
		}

		public ISaleAppService SaleAppService { get; }

		[NonAction]
		public override void Put([FromBody] SaleModel model)
		{

		}

		/// <summary>
		/// Update status of a Sale
		/// </summary>
		/// <param name="saleStatusModel">
		/// WaitingPayment = 0,
		/// PaymentAccepted = 1,
		/// Canceled = 2,
		/// ShippedToCarrier = 3,
		/// Delivered = 4
		/// </param>
		[Route("Status")]
		[HttpPut]
		public void Status(SaleStatusModel saleStatusModel)
		{
			SaleAppService.UpdateStatus(saleStatusModel);
		}
	}
}
