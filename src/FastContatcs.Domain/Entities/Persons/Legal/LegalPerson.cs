using FastContatcs.Domain.Entities._Base;
using FastContatcs.Domain.Entities.Addresses;
using FastContatcs.Domain.Entities.Documents;
using FluentValidation;
using System;

namespace FastContatcs.Domain.Entities.Persons.Legal
{
    public class LegalPerson : Entity<LegalPerson>
    {
        public string CompanyName { get; private set; }
        public string TradeName { get; private set; }
        public Guid AddressId { get; private set; }
        public virtual Address Address { get; private set; }
        public Guid DocumentId { get; private set; }
        public virtual Document Document { get; private set; }

        public LegalPerson(string companyName, string tradeName)
        {
            CompanyName = companyName;
            TradeName = tradeName;
        }

        public override bool Validate()
        {
            RuleFor(f => f.CompanyName)
                .NotEmpty().WithMessage("The field '{PropertyName}' must be filled")
                .Length(2, 100).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters");

            RuleFor(f => f.TradeName)
                .NotEmpty().WithMessage("The field '{PropertyName}' must be filled")
                .Length(2, 100).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters");

            RuleFor(f => f.Document)
                .NotNull().WithMessage("The '{PropertyName}' must be provided");

            RuleFor(f => f.Address)
                .NotNull().WithMessage("The '{PropertyName}' must be provided");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        public void UpdateCompanyName(string companyName)
        {
            CompanyName = companyName;
        }

        public void UpdateTradeName(string tradeName)
        {
            TradeName = tradeName;
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
