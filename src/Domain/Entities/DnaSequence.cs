using mercadolibre_challenge.Domain.ValueObjects;

namespace mercadolibre_challenge.Domain.Entities
{
    public class DnaSequence
    {
        public char[,] Sequence { get; set; }

        public bool IsMutant()
        {
            var matchingSequences = 0;

            var directions = new Direction[4]
            {
                Direction.Right,
                Direction.DownRight,
                Direction.Down,
                Direction.DownLeft
            };

            for (int i = 0; i < Sequence.GetLength(0); i++)
            {
                for (int j = 0; j < Sequence.GetLength(0); j++)
                {
                    var cur = Sequence[i, j];
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
                    }
                }
            }

            return matchingSequences > 1;

            bool CoordinateIsOutOfBounds(int nextX, int nextY)
            {
                return nextX > Sequence.GetLength(0) - 1 || nextY > Sequence.GetLength(0) - 1 || nextX < 0 || nextY < 0;
            }
        }
    }
}
