using mercadolibre_challenge.Application.Mutants.Commands.CreateMutant;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace mercadolibre_challenge.WebUI.Controllers
{
    public class MutantController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Create(CheckDnaForXGenesCommand command)
        {
            var isMutant = await Mediator.Send(command);
            if (!isMutant)
            {
                return Forbid();
            }

            return Ok();
        }
    }
}
