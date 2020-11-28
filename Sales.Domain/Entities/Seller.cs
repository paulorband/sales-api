namespace Sales.Domain.Entities
{
	public class Seller : EntityBase
	{
		public decimal Cpf { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Telefone { get; set; }
	}
}
