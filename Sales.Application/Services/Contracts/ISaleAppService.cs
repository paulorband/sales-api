using Sales.Application.Models;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Application.Services.Contracts
{
	public interface ISaleAppService : IAppServiceBase<Sale, SaleModel>
	{
	}
}
