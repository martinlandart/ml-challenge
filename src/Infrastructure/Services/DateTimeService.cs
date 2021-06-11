using mercadolibre_challenge.Application.Common.Interfaces;
using System;

namespace mercadolibre_challenge.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
