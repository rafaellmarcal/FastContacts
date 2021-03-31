using AutoMapper;
using FastContacts.Domain.Common.Notifier;
using FastContacts.Domain.Entities.Persons.Legal.Dtos;
using FastContacts.Domain.Entities.Persons.Legal.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastContacts.Api.Controllers
{
    [Route("api/[controller]")]
    public class LegalPersonController : MainController
    {
        private readonly IMapper _mapper;
        private readonly ILegalPersonRepository _legalPersonRepository;
        private readonly IStoreLegalPersonService _storeLegalPersonService;
        private readonly IUpdateLegalPersonService _updateLegalPersonService;
        private readonly IDeleteLegalPersonService _deleteLegalPersonService;

        public LegalPersonController(
            IMapper mapper,
            INotifier notifier,
            ILegalPersonRepository legalPersonRepository,
            IStoreLegalPersonService storeLegalPersonService,
            IUpdateLegalPersonService updateLegalPersonService,
            IDeleteLegalPersonService deleteLegalPersonService)
            : base(notifier)
        {
            _mapper = mapper;
            _legalPersonRepository = legalPersonRepository;
            _storeLegalPersonService = storeLegalPersonService;
            _updateLegalPersonService = updateLegalPersonService;
            _deleteLegalPersonService = deleteLegalPersonService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LegalPersonDto>>> GetAll()
        {
            List<LegalPersonDto> fornecedores = _mapper.Map<List<LegalPersonDto>>(await _legalPersonRepository.GetAll());

            return Ok(fornecedores);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<LegalPersonDto>> GetById(Guid id)
        {
            LegalPersonDto dto = _mapper.Map<LegalPersonDto>(await _legalPersonRepository.GetById(id));

            if (dto == null)
                return NotFound();

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<LegalPersonDto>> Post(LegalPersonDto dto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _storeLegalPersonService.Store(dto);

            return CustomResponse(dto);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<LegalPersonDto>> Put(Guid id, LegalPersonDto dto)
        {
            if (id == Guid.Empty || id != dto.Id)
            {
                NotifyError("Invalid data");
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _updateLegalPersonService.Update(dto);

            return CustomResponse(dto);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<LegalPersonDto>> Delete(Guid id)
        {
            await _deleteLegalPersonService.Delete(id);

            return CustomResponse();
        }
    }
}
