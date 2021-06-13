using mercadolibre_challenge.Domain.Common;
using mercadolibre_challenge.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace mercadolibre_challenge.Domain.Entities
{
    public class DnaSequence : AuditableEntity, IHasDomainEvent
    {
        public string Sequence { get; set; }

        public bool IsMutant { get; set; }

        public DnaSequence()
        {
        }

        public DnaSequence(FlatSequence dnaSequence)
        {
            Sequence = dnaSequence;
            IsMutant = SequenceIsMutant();

            bool SequenceIsMutant()
            {
                var dnaMatrix = StringToCharMatrix(Sequence);

                var matchingSequences = 0;

                var directions = new Direction[4]
                {
                Direction.Right,
                Direction.DownRight,
                Direction.Down,
                Direction.DownLeft
                };

                for (int i = 0; i < dnaMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < dnaMatrix.GetLength(0); j++)
                    {
                        var cur = dnaMatrix[i, j];
                        foreach (var dir in directions)
                        {
                            for (var n = 1; n < 4; n++)
                            {
                                var nextX = i + (n * dir.XAxisMod);
                                var nextY = j + (n * dir.YAxisMod);

                                if (CoordinateIsOutOfBounds(nextX, nextY))
                                {
                                    break;
                                }

                                if (dnaMatrix[nextX, nextY] != cur)
                                {
                                    break;
                                }

                                if (n == 3)
                                {
                                    matchingSequences++;
                                    break;
                                }
                            }
                        }
                    }
                }

                return matchingSequences > 1;

                bool CoordinateIsOutOfBounds(int nextX, int nextY)
                {
                    return nextX > dnaMatrix.GetLength(0) - 1 || nextY > dnaMatrix.GetLength(0) - 1 || nextX < 0 || nextY < 0;
                }

                char[,] StringToCharMatrix(string flattenedSquareMatrix)
                {
                    var n = (int)Math.Sqrt(flattenedSquareMatrix.Length);

                    var array = new char[n, n];

                    int k = 0;

                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            array[i, j] = flattenedSquareMatrix[k];
                            k++;
                        }
                    }

                    return array;
                }
            }
        }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
