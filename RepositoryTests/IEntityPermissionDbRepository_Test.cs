using System.Collections.Generic;
using System.Data;
using Moq;
using Xunit;
using System.Data.SqlClient;
using System.Threading.Tasks;
using svietnamAPI.Infastructure.Data;
using svietnamAPI.Repositories.Implements.Catalog;
using svietnamAPI.Repositories.Interfaces;
using svietnamAPI.Repositories.Implements;

namespace svietnamTEST.RepositoryTests
{
    public partial class IRepositoryWrapper_Test
    {
        [Fact]
        public async Task Get1_EP_Async()
        {
            var entityCode = "USER";
            var actionType = "READ";
            var roleCodes = new List<string>(new[] { "SELLER-01" });
            var result = await _repositoryWrapper.EntityPermissionDbRepo.Get1_EP_Async(entityCode, actionType, roleCodes);
            Assert.True(true);
        }

    }
}