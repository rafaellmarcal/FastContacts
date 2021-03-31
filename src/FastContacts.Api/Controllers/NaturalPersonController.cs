using AutoMapper;
using FastContacts.Domain.Common.Notifier;
using FastContacts.Domain.Entities.Persons.Natural.Dtos;
using FastContacts.Domain.Entities.Persons.Natural.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastContacts.Api.Controllers
{
    [Route("api/[controller]")]
    public class NaturalPersonController : MainController
    {
        private readonly IMapper _mapper;
        private readonly INaturalPersonRepository _naturalPersonRepository;
        private readonly IStoreNaturalPersonService _storeNaturalPersonService;
        private readonly IUpdateNaturalPersonService _updateNaturalPersonService;
        private readonly IDeleteNaturalPersonService _deleteNaturalPersonService;

        public NaturalPersonController(
            IMapper mapper,
            INotifier notifier,
            INaturalPersonRepository naturalPersonRepository,
            IStoreNaturalPersonService storeNaturalPersonService,
            IUpdateNaturalPersonService updateNaturalPersonService,
            IDeleteNaturalPersonService deleteNaturalPersonService)
            : base(notifier)
        {
            _mapper = mapper;
            _naturalPersonRepository = naturalPersonRepository;
            _storeNaturalPersonService = storeNaturalPersonService;
            _updateNaturalPersonService = updateNaturalPersonService;
            _deleteNaturalPersonService = deleteNaturalPersonService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NaturalPersonDto>>> GetAll()
        {
            List<NaturalPersonDto> fornecedores = _mapper.Map<List<NaturalPersonDto>>(await _naturalPersonRepository.GetAll());

            return Ok(fornecedores);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<NaturalPersonDto>> GetById(Guid id)
        {
            NaturalPersonDto dto = _mapper.Map<NaturalPersonDto>(await _naturalPersonRepository.GetById(id));

            if (dto == null)
                return NotFound();

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<NaturalPersonDto>> Post(NaturalPersonDto dto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _storeNaturalPersonService.Store(dto);

            return CustomResponse(dto);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<NaturalPersonDto>> Put(Guid id, NaturalPersonDto dto)
        {
            if (id == Guid.Empty || id != dto.Id)
            {
                NotifyError("Invalid data!");
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _updateNaturalPersonService.Update(dto);

            return CustomResponse(dto);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<NaturalPersonDto>> Delete(Guid id)
        {
            await _deleteNaturalPersonService.Delete(id);

            return CustomResponse();
        }
    }
}
