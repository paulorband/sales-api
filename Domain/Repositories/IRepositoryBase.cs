using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Repositories
{
	public interface IRepositoryBase<TEntity> where TEntity : EntityBase
	{
		IList<TEntity> GetAll();
		void Insert(TEntity entity);
		void Update(TEntity entity);
		void Delete(TEntity entity);
		TEntity GetById(long id);
	}
}
