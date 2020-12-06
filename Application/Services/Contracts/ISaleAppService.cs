using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Contracts
{
	public interface ISaleAppService : IAppServiceBase<Sale, SaleModel>
	{
		void UpdateStatus(SaleStatusModel saleStatusModel);
	}
}
