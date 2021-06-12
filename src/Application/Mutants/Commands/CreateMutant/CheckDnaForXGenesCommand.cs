using MediatR;
using mercadolibre_challenge.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace mercadolibre_challenge.Application.Mutants.Commands.CreateMutant
{
    public class CheckDnaForXGenesCommand : IRequest<bool>
    {
        public List<string> Dna { get; set; }
    }

    public class CheckDnaForXGenesCommandHandler : IRequestHandler<CheckDnaForXGenesCommand, bool>
    {
        public Task<bool> Handle(CheckDnaForXGenesCommand request, CancellationToken cancellationToken)
        {
            var dnaSequence = new DnaSequence
            {
                Sequence = ConvertRowsToMultiDimensionalArray(request.Dna)
            };

            // TODO Add domain event for DnaSequence creation

            return Task.FromResult(dnaSequence.IsMutant());
        }

        private static char[,] ConvertRowsToMultiDimensionalArray(List<string> rows)
        {
            var dnaSequenceSize = rows[0].Length;

            var array = new char[dnaSequenceSize, dnaSequenceSize];

            for (int i = 0; i < dnaSequenceSize; i++)
            {
                for (int j = 0; j < dnaSequenceSize; j++)
                {
                    array[i, j] = rows[i][j];
                }
            }

            return array;
        }
    }
}
