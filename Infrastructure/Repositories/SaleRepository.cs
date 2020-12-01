using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityFramework.Repositories
{
	public class SaleRepository : RepositoryBase<Sale>, ISaleRepository
	{
		public SaleRepository(SalesContext salesContext) : base(salesContext)
		{
		}
	}
}
