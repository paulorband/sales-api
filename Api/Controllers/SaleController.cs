using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using Application.Services.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class SaleController : ControllerBase<Sale, SaleModel>
	{
		public SaleController(ISaleAppService saleAppService) : base(saleAppService)
		{
		}
	}
}
