using FluentValidation;
using mercadolibre_challenge.Domain.Entities;
using System;

namespace mercadolibre_challenge.Application.Mutants.Commands.CreateMutant
{
    public class CreateDnaSequenceCommandValidator : AbstractValidator<CreateDnaSequenceCommand>
    {
        public CreateDnaSequenceCommandValidator()
        {
            RuleFor(d => d.Dna).Must(BeSquareMatrix).WithMessage("Dna sequence must be a square matrix");
            RuleFor(d => d.Dna.Length).GreaterThan(0).WithMessage("Dna sequence must not be empty");
            RuleFor(d => d.Dna).Must(ContainOnlyValidCharacters).WithMessage("Dna sequence must contain only valid DNA letters");
        }

        private bool BeSquareMatrix(string dna)
        {
            double result = Math.Sqrt(dna.Length);
            return result % 1 == 0;
        }

        private bool ContainOnlyValidCharacters(string dna)
        {
            foreach (var c in dna)
            {
                if (!DnaSequence.ValidLetters.Contains(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
