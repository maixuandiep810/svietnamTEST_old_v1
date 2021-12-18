using System.Collections.Generic;
using System.Threading.Tasks;
using svietnamAPI.Dtos.Auth;
using Xunit;

namespace svietnamTEST.ServiceTests
{
    public partial class IServiceWrapper_Test
    {
        [Fact]
        public async Task Get1_ById_Basic_Async()
        {
            var userEntityCode = "User";
            var groupEntityCode = "Group";
            var actionType = "READ";
            var userId = 10001;
            var roleCodes = new List<string>(new[] { "ADMIN-01" });
            // var userEP = await _serviceWrapper.EntityPermissionService.Get1_EP_Async(userEntityCode, actionType, roleCodes);
            var userEP_OP = await _serviceWrapper.EntityPermissionService.Get1_EP_OP_Async(userEntityCode, actionType, roleCodes, userId);
            var groupEP_OP = await _serviceWrapper.EntityPermissionService.Get1_EP_Async(groupEntityCode, actionType, roleCodes);
            var httpEP = new HttpContextEntityPermission();
            httpEP.UserEP = userEP_OP;
            httpEP.GroupEP = groupEP_OP;
            var a = await _serviceWrapper.UserService.Get1_ById_Group_Async(httpEP, userId);
            Assert.True(true);
        }
    }
}