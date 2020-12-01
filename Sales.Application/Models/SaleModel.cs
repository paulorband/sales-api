using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Application.Models
{
	public class SaleModel : ModelBase
	{
		public SellerModel Seller { get; set; }
		public DateTime Date { get; set; } = DateTime.Now;
		public SaleStatus Status { get; set; } = SaleStatus.WaitingPayment;
		public IList<SaleItemModel> Items { get; set; } = new List<SaleItemModel>();
	}
}
