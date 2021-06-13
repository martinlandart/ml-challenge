using mercadolibre_challenge.Domain.Common;
using System.Collections.Generic;
using System.Text;

namespace mercadolibre_challenge.Domain.ValueObjects
{
    public sealed class FlatSequence : ValueObject
    {
        public string Sequence { get; }

        private FlatSequence(string sequence)
        {
            Sequence = sequence;
        }

        public static FlatSequence From(IEnumerable<string> rows)
        {
            var sb = new StringBuilder();

            foreach (var row in rows)
            {
                sb.Append(row);
            }

            return new FlatSequence(sb.ToString());
        }

        public static implicit operator string(FlatSequence sequence)
        {
            return sequence.Sequence;
        }

        public static implicit operator FlatSequence(string sequence)
        {
            return new FlatSequence(sequence);
        }

        public static explicit operator FlatSequence(List<string> dnaRows)
        {
            return From(dnaRows);
        }

        public override string ToString()
        {
            return Sequence;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Sequence;
        }
    }
}
