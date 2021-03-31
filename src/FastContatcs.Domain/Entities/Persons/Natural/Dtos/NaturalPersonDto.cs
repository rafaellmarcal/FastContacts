using FastContacts.Domain.Entities.Addresses.Dtos;
using FastContacts.Domain.Entities.Documents.Dtos;
using FastContacts.Domain.Entities.Persons.Natural.Enumerators;
using System;
using System.ComponentModel.DataAnnotations;

namespace FastContacts.Domain.Entities.Persons.Natural.Dtos
{
    public class NaturalPersonDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(200, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime Birthday { get; set; }

        public DocumentDto Document { get; set; }

        public AddressDto Address { get; set; }
    }
}
