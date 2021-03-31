using FastContacts.Domain.Common.Helper;
using FastContatcs.Domain.Entities._Base;
using FastContatcs.Domain.Entities.Documents.Enums;
using FluentValidation;

namespace FastContatcs.Domain.Entities.Documents
{
    public class Document : Entity<Document>
    {
        public EDocumentType Type { get; private set; }
        public string Number { get; private set; }

        public Document(EDocumentType type, string number)
        {
            Type = type;
            Number = number;
        }

        public override bool Validate()
        {
            RuleFor(f => f.Type)
                .NotNull().WithMessage("Document type must be provided")
                .IsInEnum().WithMessage("Document type is invalid");

            When(f => f.Type == EDocumentType.CPF, () =>
            {
                RuleFor(f => f.Number.Length)
                    .Equal(CPFValidation.CPFLength)
                    .WithMessage("Document number must be {ComparisonValue} characters.");
                
                RuleFor(f => CPFValidation.Validate(f.Number))
                    .Equal(true)
                    .WithMessage("Document number is invalid.");
            });

            When(f => f.Type == EDocumentType.CNPJ, () =>
            {
                RuleFor(f => f.Number.Length)
                    .Equal(CNPJValidation.CNPJLength)
                    .WithMessage("Document number must be {ComparisonValue} characters.");
                
                RuleFor(f => CNPJValidation.Validate(f.Number))
                    .Equal(true)
                    .WithMessage("Document number is invalid.");
            });

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        public void UpdateNumber(string number)
        {
            Number = number;
        }
    }
}
