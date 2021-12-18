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

        protected readonly Mock<IDataConnectionFactory> _dcfMock;
        protected readonly IRepositoryWrapper _repositoryWrapper;

        public IRepositoryWrapper_Test()
        {
            _dcfMock = new Mock<IDataConnectionFactory>();
            _dcfMock.Setup(dcf => dcf.CreateSqlDbConnection())
            .Returns(() =>
            {
                var DbConnectionString = "Data Source=localhost,1433; Initial Catalog=svietnam_v1_1_db_v1_1; User ID=SA;Password=SABC123##";
                SqlConnection connection = new SqlConnection(DbConnectionString);
                return connection;
            });
            _repositoryWrapper = new RepositoryWrapper(_dcfMock.Object);
        }
    }
}