using mercadolibre_challenge.Domain.Common;
using System.Collections.Generic;

namespace mercadolibre_challenge.Domain.ValueObjects
{
    public sealed class Direction : ValueObject
    {
        private Direction(int xmod, int ymod)
        {
            XAxisMod = xmod;
            YAxisMod = ymod;
        }

        public static Direction Up => new Direction(1, 1);
        public static Direction Down => new Direction(0, -1);
        public static Direction Right => new Direction(1, 0);
        public static Direction Left => new Direction(-1, 0);
        public static Direction UpRight => new Direction(1, 1);
        public static Direction DownRight => new Direction(1, -1);
        public static Direction UpLeft => new Direction(-1, 1);
        public static Direction DownLeft => new Direction(-1, -1);

        public int XAxisMod { get; }
        public int YAxisMod { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return XAxisMod;
            yield return YAxisMod;
        }
    }
}
