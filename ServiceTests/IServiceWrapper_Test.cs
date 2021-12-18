using Moq;
using System.Data.SqlClient;
using svietnamAPI.Infastructure.Data;
using svietnamAPI.Repositories.Interfaces;
using svietnamAPI.Repositories.Implements;
using svietnamAPI.StartupConfiguration.AppSetting;
using svietnamTEST.DataTest.StartupConfiguration;
using AutoMapper;
using svietnamAPI.Infastructure.AutoMapper;
using svietnamAPI.Services.Implements;

namespace svietnamTEST.ServiceTests
{
    public partial class IServiceWrapper_Test
    {

        protected readonly Mock<IDataConnectionFactory> _dcfMock;
        protected readonly IRepositoryWrapper _repositoryWrapper;
        protected readonly ServerSetting _serverSetting;
        protected readonly IMapper _mapper;
        protected readonly ServiceWrapper _serviceWrapper;


        public IServiceWrapper_Test()
        {
            // RepositoryWrapper
            _dcfMock = new Mock<IDataConnectionFactory>();
            _dcfMock.Setup(dcf => dcf.CreateSqlDbConnection())
            .Returns(() =>
            {
                var DbConnectionString = "Data Source=localhost,1433; Initial Catalog=svietnam_v1_1_db_v1_1; User ID=SA;Password=SABC123##";
                SqlConnection connection = new SqlConnection(DbConnectionString);
                return connection;
            });
            _repositoryWrapper = new RepositoryWrapper(_dcfMock.Object);
            // AutoMapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            mappingConfig.AssertConfigurationIsValid();
            _mapper = mappingConfig.CreateMapper();
            // ServerSetting
            _serverSetting = ServerSettingData.ServerSetting;
            _serviceWrapper = new ServiceWrapper(_serverSetting, _mapper, _repositoryWrapper);
        }
    }
}