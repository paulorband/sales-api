using Application.Mappers;
using Application.Mappers.Contracts;
using Application.Models;
using Application.Services;
using Application.Services.Contracts;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services;
using Domain.Services.Contracts;
using Domain.Validation;
using Domain.Validation.Contracts;
using Infrastructure.EntityFramework.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Extensions
{
	public static class ServiceCollectionExtension
	{
		public static void AddDomainServices(this IServiceCollection services)
		{
			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<ISaleService, SaleService>();
			services.AddScoped<ISellerService, SellerService>();
			services.AddScoped<IValidator<Sale>, SaleValidator>();

		}

		public static void AddRepositories(this IServiceCollection services)
		{
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<ISaleRepository, SaleRepository>();
			services.AddScoped<ISellerRepository, SellerRepository>();
		}

		public static void AddAppServices(this IServiceCollection services)
		{
			services.AddScoped<IProductAppService, ProductAppService>();
			services.AddScoped<ISaleAppService, SaleAppService>();
			services.AddScoped<ISellerAppService, SellerAppService>();
			
			services.AddScoped<IMapper<Sale, SaleModel>, SaleMapper>();
			services.AddScoped<IMapper<SaleItem, SaleItemModel>, SaleItemMapper>();
			services.AddScoped<IMapper<Product, ProductModel>, ProductMapper>();
			services.AddScoped<IMapper<Seller, SellerModel>, SellerMapper>();
		}
	}

}
