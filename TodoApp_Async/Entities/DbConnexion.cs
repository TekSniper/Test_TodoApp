namespace TodoApp_Async.Entities;

public class DbConnexion
{
    private string _connectionString;
    IConfigurationRoot root()
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
        return builder.Build();
    }
    public DbConnexion()
    {
        _connectionString = root().GetSection("ConnectionStrings").GetSection("todo").Value!;
    }

    public SqlConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }
}