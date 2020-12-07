using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework
{
	public class SalesContext : DbContext
	{
		public SalesContext(DbContextOptions<SalesContext> options) : base(options)
		{
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<SaleItem> SaleItems { get; set; }
		public DbSet<Seller> Sellers { get; set; }
		public DbSet<Sale> Sales { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			ConfigureProduct(modelBuilder.Entity<Product>());
			ConfigureSeller(modelBuilder.Entity<Seller>());
			ConfigureSaleItem(modelBuilder.Entity<SaleItem>());
			ConfigureSale(modelBuilder.Entity<Sale>());
		}

		private void ConfigureProduct(EntityTypeBuilder<Product> entityTypeBuilder)
		{
			entityTypeBuilder
				.HasKey(p => p.Id);

			entityTypeBuilder
				.Property(p => p.Name);

			entityTypeBuilder
				.Property(p => p.Price);


			entityTypeBuilder.HasData(
				new Product { Id = 1, Name = "Smart TV LG 55\" 4K 55OLEDCX", Price = 4999 },
				new Product { Id = 2, Name = "Smart TV LG 65\" 4K 65OLEDCX", Price = 5999 },
				new Product { Id = 3, Name = "Smart TV Samsung 55\" 4K 55QLED", Price = 5499 },
				new Product { Id = 4, Name = "Smart TV TCL 49\" FHD 49TU7700", Price = 1999 },
				new Product { Id = 5, Name = "Smart TV LG 86\" 8K 86OLEDCX", Price = 29999 }
			);
		}

		private void ConfigureSeller(EntityTypeBuilder<Seller> entityTypeBuilder)
		{
			entityTypeBuilder
				.HasKey(p => p.Id);

			entityTypeBuilder
				.Property(p => p.Name);

			entityTypeBuilder
				.Property(p => p.Cpf);

			entityTypeBuilder
				.Property(p => p.Email);

			entityTypeBuilder
				.Property(p => p.Telefone);


			entityTypeBuilder.HasData(
				new Seller { Id = 1, Cpf = 12345678901, Email = "joao.alberto@gmail.com", Name = "João Alberto", Telefone = "31954562545" },
				new Seller { Id = 2, Cpf = 98765432105, Email = "antonio.costa@gmail.com", Name = "Antônio Costa", Telefone = "31954562546" },
				new Seller { Id = 3, Cpf = 89786543215, Email = "jose.neto@gmail.com", Name = "Jose Neto", Telefone = "31954562547" }
			);
		}

		private void ConfigureSaleItem(EntityTypeBuilder<SaleItem> entityTypeBuilder)
		{
			entityTypeBuilder
				.HasKey(p => p.Id);

			entityTypeBuilder
				.Property(p => p.Amount);

			entityTypeBuilder
				.Property(p => p.UnitPrice);

			entityTypeBuilder
				.HasOne(p => p.Product)
				.WithMany()
				.IsRequired();

			entityTypeBuilder
				.HasOne(p => p.Sale)
				.WithMany(s => s.Items)
				.IsRequired();

			entityTypeBuilder
				.Ignore(p => p.TotalPrice);

		}

		private void ConfigureSale(EntityTypeBuilder<Sale> entityTypeBuilder)
		{
			entityTypeBuilder
				.HasKey(p => p.Id);

			entityTypeBuilder
				.Property(p => p.Status);

			entityTypeBuilder
				.Property(p => p.Date);

			entityTypeBuilder
				.HasOne(p => p.Seller)
				.WithMany()
				.IsRequired();

			entityTypeBuilder
				.HasMany(p => p.Items)
				.WithOne(i => i.Sale)
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
