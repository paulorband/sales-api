using Application.Mappers.Contracts;
using Application.Models;
using Application.Services.Contracts;
using Domain.Entities;
using Domain.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
	public class SellerAppService : AppServiceBase<Seller, SellerModel>, ISellerAppService
	{
		public SellerAppService(ISellerService sellerService, IMapper<Seller, SellerModel> sellerMapper) : base(sellerService, sellerMapper)
		{
		}
	}
}
