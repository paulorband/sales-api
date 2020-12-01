using Application.Models;
using Domain.Entities;

namespace Application.Services.Contracts
{
	internal interface IProductAppService : IAppServiceBase<Product, ProductModel>
	{
	}
}