using FastContacts.Domain.Entities.Persons.Natural.Enumerators;
using FastContatcs.Domain.Entities._Base;
using FastContatcs.Domain.Entities.Addresses;
using FastContatcs.Domain.Entities.Documents;
using FluentValidation;
using System;

namespace FastContacts.Domain.Entities.Persons.Natural
{
    public class NaturalPerson : Entity<NaturalPerson>
    {
        public string Name { get; private set; }
        public DateTime Birthday { get; private set; }
        public Gender Gender { get; private set; }
        public Guid AddressId { get; private set; }
        public virtual Address Address { get; private set; }
        public Guid DocumentId { get; private set; }
        public virtual Document Document { get; private set; }

        public NaturalPerson(string name, DateTime birthday, Gender gender)
        {
            Name = name;
            Birthday = birthday;
            Gender = gender;
        }

        public override bool Validate()
        {
            RuleFor(f => f.Name)
                .NotEmpty().WithMessage("The field '{PropertyName}' must be filled")
                .Length(2, 200).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters");

            RuleFor(f => f.Birthday)
                .NotNull().WithMessage("The field '{PropertyName}' must be filled")
                .NotEqual(DateTime.MinValue).WithMessage("The field '{PropertyName}' must be a valid date");

            RuleFor(f => f.Gender)
                .NotNull().WithMessage("Document type must be provided")
                .IsInEnum().WithMessage("Document type is invalid");

            RuleFor(f => f.Document)
                .NotNull().WithMessage("The '{PropertyName}' must be provided");

            RuleFor(f => f.Address)
                .NotNull().WithMessage("The '{PropertyName}' must be provided");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void UpdateBirthday(DateTime birthday)
        {
            Birthday = birthday;
        }

        public void UpdateGender(Gender gender)
        {
            Gender = gender;
        }

        public void AssignAddress(Address address)
        {
            Address = address;
        }

        public void AssignDocument(Document document)
        {
            Document = document;
        }
    }
}
