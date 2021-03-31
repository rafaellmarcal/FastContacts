using FastContacts.Domain.Entities.Addresses.Dtos;
using FastContacts.Domain.Entities.Documents.Dtos;
using System;
using System.ComponentModel.DataAnnotations;

namespace FastContacts.Domain.Entities.Persons.Legal.Dtos
{
    public class LegalPersonDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string TradeName { get; set; }

        public DocumentDto Document { get; set; }

        public AddressDto Address { get; set; }
    }
}
