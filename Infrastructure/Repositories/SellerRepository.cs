using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityFramework.Repositories
{
	public class SellerRepository : RepositoryBase<Seller>, ISellerRepository
	{
		public SellerRepository(SalesContext salesContext) : base(salesContext)
		{
		}
	}
}
