using System.Data.SqlClient;
using System.Data;
using Dapper;

static class Menu
{
    
}

class Program
{
    static void Main(string[] args)
    {
        using (IDbConnection db = DatabaseFunctions.Connect())
        {
            List<Person> people = db.Query<Person>("SELECT * FROM Person").ToList();
            UI.PrintInTable(people);
        }
    }
}



