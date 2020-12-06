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

		[Route("Status")]
		[HttpPut]
		public void Status(SaleStatusModel saleStatusModel)
		{
			SaleAppService.UpdateStatus(saleStatusModel);
		}
	}
}
