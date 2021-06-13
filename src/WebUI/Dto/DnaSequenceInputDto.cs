using System.Collections.Generic;

namespace mercadolibre_challenge.WebUI.Dto
{
    public class DnaSequenceInputDto
    {
        public IEnumerable<string> Dna { get; set; } = new List<string>();
    }
}
