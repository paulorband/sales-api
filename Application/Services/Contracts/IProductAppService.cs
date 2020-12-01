using Application.Models;
using Domain.Entities;

namespace Application.Services.Contracts
{
	public interface IProductAppService : IAppServiceBase<Product, ProductModel>
	{
	}
}