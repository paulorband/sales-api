using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Domain.Repositories
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
