using FluentValidation;
using FluentValidation.Results;
using System;

namespace FastContatcs.Domain.Entities._Base
{
    public abstract class Entity<TEntity> : AbstractValidator<TEntity> where TEntity : class
    {
        public Guid Id { get; protected set; }
        public DateTime CreateDate { get; protected set; }
        public bool Active { get; protected set; }
        public ValidationResult ValidationResult { get; protected set; }

        public abstract bool Validate();

        protected Entity()
        {
            Id = Guid.NewGuid();
            CreateDate = DateTime.Now;
            Active = true;
            ValidationResult = new ValidationResult();
        }
    }
}
