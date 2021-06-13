using MediatR;
using mercadolibre_challenge.Application.Common.Interfaces;
using mercadolibre_challenge.Domain.Entities;
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

            _context.DnaSequences.Add(dnaSequence);
            await _context.SaveChangesAsync(cancellationToken);

            return dnaSequence.IsMutant;
        }
    }
}
