using Domain.Entities;

namespace Domain.Validators.Contracts
{
	public interface IValidator<TEntity> where TEntity : EntityBase
	{
		bool Validate(TEntity entity, out ValidationResult validatorResult);
	}
}
