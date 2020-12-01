using System;
using System.Collections.Generic;

namespace Domain.Entities
{
	public class Sale : EntityBase
	{
		public Seller Seller { get; set; }
		public DateTime Date { get; set; } = DateTime.Now;
		public SaleStatus Status { get; set; } = SaleStatus.WaitingPayment;
		public IList<SaleItem> Items { get; set; } = new List<SaleItem>();

		public void AddItem(SaleItem saleItem)
		{
			Items.Add(saleItem);
		}

		public void RemoveItem(SaleItem saleItem)
		{
			Items.Remove(saleItem);
		}
	}
}
