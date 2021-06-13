using MediatR;
using mercadolibre_challenge.Application.Common.Interfaces;
using mercadolibre_challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace mercadolibre_challenge.Application.Mutants.Commands.CreateMutant
{
    public class CreateDnaSequenceCommand : IRequest<bool>
    {
        public string Dna { get; set; }
    }

    public class CheckDnaForXGenesCommandHandler : IRequestHandler<CreateDnaSequenceCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public CheckDnaForXGenesCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateDnaSequenceCommand request, CancellationToken cancellationToken)
        {
            var dnaSequence = new DnaSequence(request.Dna);

            await _context.DnaSequences.Upsert(dnaSequence).RunAsync();

            return dnaSequence.IsMutant;
        }
    }
}
