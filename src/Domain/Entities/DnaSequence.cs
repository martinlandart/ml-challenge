using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mercadolibre_challenge.Domain.Entities
{
    public class DnaSequence
    {
        public char[,] Sequence { get; set; }

        public bool IsMutant()
        {
            throw new NotImplementedException();
        }
    }
}
