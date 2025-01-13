using System.Data.SqlClient;
using System.Data;
using Dapper;

class DatabaseFunctions
{
    public static IDbConnection Connect()
    {
        string connectionString = File.ReadAllText("connectionString.txt");
        return new SqlConnection(connectionString);
    }

    public IEnumerable<T> Select<T, U>(string storedProcedure, U parameters)
    {
        using IDbConnection db = Connect();
        return db.Query<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        //($"SELECT {parameters} FROM {typeof(T).Name}").ToList();
    }

    public void Insert<T, U>(string storedProcedure, U parameters)
    {
        using IDbConnection db = Connect();
        db.Execute($"INSERT INTO {typeof(T).Name} VALUES (@{parameters})", parameters);
    }

    public void Update<T, U>(string storedProcedure, U parameters)
    {
        using IDbConnection db = Connect();
        db.Execute($"UPDATE {typeof(T).Name} SET @{parameters} WHERE Id = @{parameters}", parameters);
    }

    public void Delete<T, U>(string storedProcedure, U parameters)
    {
        using IDbConnection db = Connect();
        db.Execute($"DELETE FROM {typeof(T).Name} WHERE Id = @{parameters}", parameters);
    }

    
}