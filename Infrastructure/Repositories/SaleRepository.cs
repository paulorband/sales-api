using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.EntityFramework.Repositories
{
	public class SaleRepository : RepositoryBase<Sale>, ISaleRepository
	{
		public SaleRepository(SalesContext salesContext) : base(salesContext)
		{
		}

		public override IList<Sale> GetAll()
		{
			return SalesContext.Sales
				.Include(s => s.Items)
					.ThenInclude(i => i.Product)
				.Include(s => s.Seller).ToList();
		}
	}
}
