using Sales.Application.Models;
using Sales.Domain.Entities;
using System.Collections.Generic;

namespace Sales.Application.Services.Contracts
{
	public interface IAppServiceBase<TEntity, TModel> 
		where TEntity : EntityBase
		where TModel : ModelBase
	{
		IList<TModel> GetAll();
		void Insert(TModel entity);
		void Update(TModel entity);
		void Delete(TModel entity);
		TModel GetById(long id);
	}
}