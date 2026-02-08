using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace eCommerce.Infrastructure.DbContext;

public class DapperDbContext
{
    private readonly IConfiguration _configuration;
    private readonly IDbConnection _connection;
    public DapperDbContext(IConfiguration configuration)
    {
        _configuration = configuration;

        string connectionStringTemplate = _configuration.GetConnectionString("PostrgresConnection")!;
        string connectionString = connectionStringTemplate
            .Replace("$POSTGRES_HOST", Environment.GetEnvironmentVariable("POSTGRES_HOST"))
            .Replace("$POSTGRES_PASSWORD", Environment.GetEnvironmentVariable("POSTRGRES_PASSWORD"));

        //Create new NpgsqlConnection using connection string
        _connection = new NpgsqlConnection(connectionString);
    }

    //Property that returns connection, It contains only get accessor  
    public IDbConnection DbConnection => _connection;
}
