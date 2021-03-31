using FastContatcs.Domain.Entities._Base;
using FluentValidation;

namespace FastContatcs.Domain.Entities.Addresses
{
    public class Address : Entity<Address>
    {
        public string ZipCode { get; private set; }
        public string AddressOne { get; private set; }
        public string AddressTwo { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }

        public Address(string zipCode, string country, string state, string city, string addressOne, string addressTwo)
        {
            ZipCode = zipCode;
            Country = country;
            State = state;
            City = city;
            AddressOne = addressOne;
            AddressTwo = addressTwo;
        }

        public override bool Validate()
        {
            RuleFor(c => c.ZipCode)
                .NotEmpty().WithMessage("The field {PropertyName} must be filled")
                .Length(8).WithMessage("The field {PropertyName} must be {MaxLength} characters");

            RuleFor(c => c.AddressOne)
                .NotEmpty().WithMessage("The field {PropertyName} must be filled")
                .Length(2, 200).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters");

            RuleFor(c => c.City)
                .NotEmpty().WithMessage("The field {PropertyName} must be filled")
                .Length(2, 100).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters");

            RuleFor(c => c.State)
                .NotEmpty().WithMessage("The field {PropertyName} must be filled")
                .Length(2, 50).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters");

            RuleFor(c => c.Country)
                .NotEmpty().WithMessage("The field {PropertyName} must be filled")
                .Length(2, 50).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        public void UpdateZipCode(string zipCode)
        {
            ZipCode = zipCode;
        }

        public void UpdateAddressOne(string addressOne)
        {
            AddressOne = addressOne;
        }

        public void UpdateAddressTwo(string addressTwo)
        {
            AddressTwo = addressTwo;
        }

        public void UpdateCity(string city)
        {
            City = city;
        }

        public void UpdateState(string state)
        {
            State = state;
        }

        public void UpdateCountry(string country)
        {
            Country = country;
        }
    }
}
