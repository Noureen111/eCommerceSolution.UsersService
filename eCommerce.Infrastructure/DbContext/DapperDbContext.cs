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

        string? connectionString = _configuration.GetConnectionString("PostrgresConnection");

        //Create new NpgsqlConnection using connection string
        _connection = new NpgsqlConnection(connectionString);
    }

    //Property that returns connection, It contains only get accessor  
    public IDbConnection DbConnection => _connection;
}
