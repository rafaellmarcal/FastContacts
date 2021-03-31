using FastContatcs.Domain.Entities.Documents.Enums;
using System.ComponentModel.DataAnnotations;

namespace FastContacts.Domain.Entities.Documents.Dtos
{
    public class DocumentDto
    {
        [Required(ErrorMessage = "The field {0} is required")]
        public EDocumentType Type { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(14, ErrorMessage = "The Document Number must be between {2} and {1} characters", MinimumLength = 11)]
        public string Number { get; set; }
    }
}
