using Sales.Application.Models;
using Sales.Domain.Entities;

namespace Sales.Application.Services.Contracts
{
	internal interface IProductAppService : IAppServiceBase<Product, ProductModel>
	{
	}
}