using mercadolibre_challenge.Application.Mutants.Commands.CreateMutant;
using mercadolibre_challenge.Domain.ValueObjects;
using mercadolibre_challenge.WebUI.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace mercadolibre_challenge.WebUI.Controllers
{
    public class MutantController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Create(DnaSequenceInputDto dnaRows)
        {
            var command = new CreateDnaSequenceCommand
            {
                Dna = FlatSequence.From(dnaRows.Dna)
            };

            var isMutant = await Mediator.Send(command);
            if (!isMutant)
            {
                return StatusCode((int)HttpStatusCode.Forbidden);
            }

            return Ok();
        }
    }
}
