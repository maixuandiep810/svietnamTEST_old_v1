using AutoMapper;
using svietnamAPI.Infastructure.AutoMapper;
using Xunit;

namespace svietnamTEST.InfastructureTests
{
    public class AutoMapper_Tests
    {
        private readonly IMapper _mapper;

        public AutoMapper_Tests()
        {

            // AutoMapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            mappingConfig.AssertConfigurationIsValid();
            _mapper = mappingConfig.CreateMapper();
        }

        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }
    }
}