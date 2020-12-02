using Application.Models;
using Application.Services.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class SellersController : ControllerBase<Seller, SellerModel>
	{
		public SellersController(ISellerAppService sellerAppService) : base(sellerAppService)
		{
		}
	}
}
