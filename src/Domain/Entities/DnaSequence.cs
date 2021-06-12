using mercadolibre_challenge.Domain.ValueObjects;
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
            //var matrix = new char[Sequence.GetLength(0), Sequence.GetLength(0)];
            //FillNucleotideMatrix(matrix);

            var matchingSequences = 0;

            var directions = new Direction[4]
            {
                Direction.Right,
                Direction.DownRight,
                Direction.Down,
                Direction.DownLeft
            };

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    var cur = Sequence[i, j];
                    foreach (var dir in directions)
                    {
                        for (var n = 1; n < 4; n++)
                        {
                            var nextX = i + (n * dir.XAxisMod);
                            var nextY = j + (n * dir.YAxisMod);

                            if (nextX > Sequence.GetLength(0) - 1 || nextY > Sequence.GetLength(0) - 1 || nextX < 0 || nextY < 0)
                            {
                                break;
                            }

                            if (Sequence[nextX, nextY] != cur)
                            {
                                break;
                            }

                            if (n == 3)
                            {
                                matchingSequences++;
                                break;
                            }
                        }

                        //for (int n = 1; n < 4; n++)
                        //{
                        //    if (Sequence[i + (n * dir.XAxisMod), i + (n * dir.YAxisMod)] != cur)
                        //        continue;
                        //    if(n)
                        //}
                    }

                    // start branch
                    // rotate
                    // extend branch or prune
                }
            }

            return matchingSequences > 1;

            //void FillNucleotideMatrix(NucleotideBase[,] dnaSequence)
            //{
            //    for (int i = 0; i < 6; i++)
            //    {
            //        for (int j = 0; j < 6; j++)
            //        {
            //            dnaSequence[i, j] = new NucleotideBase
            //            {
            //                Name = Sequence[i, j],
            //                IsVisited = false
            //            };
            //        }
            //    }
            //}
        }

        private struct NucleotideBase
        {
            public char Name { get; set; }
            public bool IsVisited { get; set; }
        };
    }
}
