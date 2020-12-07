using Domain.Entities;

namespace Domain.Validation.Contracts
{
	public interface IValidator<TEntity> where TEntity : EntityBase
	{
		bool Validate(TEntity entity, out ValidationResult validatorResult);
	}
}
