using Application.Models;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Services.Contracts
{
	public interface IAppServiceBase<TEntity, TModel> 
		where TEntity : EntityBase
		where TModel : ModelBase
	{
		IList<TModel> GetAll();
		void Insert(TModel entity);
		void Update(TModel entity);
		void Delete(TModel entity);
		void Delete(long id);
		TModel GetById(long id);
	}
}