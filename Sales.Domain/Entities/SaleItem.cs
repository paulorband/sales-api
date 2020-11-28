namespace Sales.Domain.Entities
{
	public class SaleItem : EntityBase
	{
		public Product Product { get; set; }
		public int Amount { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal TotalPrice => Amount * UnitPrice;
	}
}
