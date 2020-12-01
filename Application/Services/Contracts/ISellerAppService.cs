using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Contracts
{
	public interface ISellerAppService : IAppServiceBase<Seller, SellerModel>
	{
	}
}
