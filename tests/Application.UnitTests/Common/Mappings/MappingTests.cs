using AutoMapper;
using mercadolibre_challenge.Application.Common.Mappings;
using mercadolibre_challenge.Domain.Entities;
using NUnit.Framework;
using System;
using System.Runtime.Serialization;

namespace mercadolibre_challenge.Application.UnitTests.Common.Mappings
{
    public class MappingTests
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = _configuration.CreateMapper();
        }

        [Test]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

    }
}
