using Domain.Entities;

namespace Application.Models
{
	public class SaleStatusModel
	{
		public long SaleId { get; set; }
		public SaleStatus Status { get; set; }
	}
}
