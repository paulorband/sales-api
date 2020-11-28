using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Domain.Validators.Contracts
{
	public interface IValidator<TEntity> where TEntity : EntityBase
	{
		bool Validate(TEntity entity, out ValidationResult validatorResult);
	}
}
