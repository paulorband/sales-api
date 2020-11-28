using System;
using System.Collections.Generic;

namespace Sales.Domain.Entities
{
	public class Sale : EntityBase
	{
		public Seller Seller { get; set; }
		public DateTime Date { get; set; }
		public SaleStatus Status { get; set; }
		public IList<SaleItem> Items { get; set; }
	}
}
