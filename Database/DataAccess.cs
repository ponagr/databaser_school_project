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
    public static IEnumerable<CrimeCity> CrimeByDateAndCity(string date, string city)
    {
        using IDbConnection db = Connect();
        
        string query = @"
            SELECT c.Name, c.Date, ci.Name AS CityName
            FROM Crime c
            JOIN City ci ON c.CityId = ci.Id
            WHERE c.Date = @Date AND ci.Name = @CityName";
        
        return db.Query<CrimeCity>(query, new { Date = date, CityName = city });
    }
    public static IEnumerable<CriminalsByGang> CriminalsByGang(string gangName)
    {
        using IDbConnection db = Connect();
        
        string query = @"
            SELECT p.Name, p.DateOfBirth, c.Description AS PersonDescription, c.Status, g.Name AS Gang, g.Description AS GangDescription
            FROM Person p
            JOIN Criminal c ON p.Id = c.PersonId
            JOIN Gang g ON c.GangId = g.Id AND g.Name LIKE @GangName";

        return db.Query<CriminalsByGang>(query, new { GangName = gangName });
    }
    public static IEnumerable<ActiveGangsByCity> ActiveGangsByCity(string cityName)
    {
        using IDbConnection db = Connect();
        
        string query = @"
            SELECT g.Name AS Gang, City.Name AS ActiveCity, g.Description AS GangDescription
            FROM Person p
            JOIN Criminal c ON p.Id = c.PersonId
            JOIN Gang g ON g.Id = c.GangId
            JOIN GangToCity GToC ON g.Id = GToC.GangId
            JOIN City ON GToC.CityId = City.Id AND City.Name = @CityName";

        return db.Query<ActiveGangsByCity>(query, new { CityName = cityName });
    }
    public static IEnumerable<CriminalRecordsByCriminal> CriminalRecordsByCriminal(string criminalName)
    {
        using IDbConnection db = Connect();
        
        string query = @"
            SELECT i.Name, i.Description, co.Sentence, Crime.CrimeDate, co.ConvictionDate
            FROM Criminal c
            JOIN CrimeRecord cr ON cr.CriminalId = c.Id
            JOIN Person p ON p.Id = c.PersonId AND p.Name LIKE @CriminalName
            JOIN CriminalToInvestigation CtI ON CtI.CriminalId = c.Id
            JOIN Investigation i ON i.Id = CtI.InvestigationId
            JOIN Crime ON Crime.Id = i.CrimeId
            JOIN Conviction co ON co.InvestigationId = i.Id";

        return db.Query<CriminalRecordsByCriminal>(query, new { CriminalName = criminalName });
    }
    public static IEnumerable<InvestigationsByCriminal> ActiveInvestigationsByCriminal(string criminalName)
    {
        using IDbConnection db = Connect();
        
        string query = @"
            SELECT i.Name, i.Description, cr.CrimeDate, ci.Name AS City
            FROM Investigation i
            JOIN Crime cr ON cr.Id = i.CrimeId
            JOIN City ci ON ci.Id = cr.CityId
            JOIN CriminalToInvestigation CtI ON CtI.InvestigationId = i.Id 
            JOIN Criminal c ON c.Id = CtI.CriminalId
            JOIN Person p ON p.Id = c.PersonId
            WHERE i.[Status] = 'Ongoing' AND p.Name LIKE @CriminalName";

        return db.Query<InvestigationsByCriminal>(query, new { CriminalName = criminalName });
    }
    public static IEnumerable<InvestigationsByCop> ActiveInvestigationsByCop(string copName)
    {
        using IDbConnection db = Connect();
        
        string query = @"
            SELECT i.Name, i.Description, cr.CrimeDate, ci.Name AS City
            FROM Investigation i
            JOIN Crime cr ON cr.Id = i.CrimeId
            JOIN City ci ON ci.Id = cr.CityId
            JOIN CopToInvestigation CtI ON CtI.InvestigationId = i.Id 
            JOIN Cop c ON c.Id = CtI.CopId
            JOIN Person p ON p.Id = c.PersonId
            WHERE i.[Status] = 'Ongoing' AND p.Name LIKE @CopName";

        return db.Query<InvestigationsByCop>(query, new { CopName = copName });
    }
    public static IEnumerable<InvestigationsByCriminal> AllInvestigationsByCriminal(string criminalName)
    {
        using IDbConnection db = Connect();
        
        string query = @"
            SELECT i.Name, i.Description, cr.CrimeDate, ci.Name AS City, i.Status
            FROM Investigation i
            JOIN Crime cr ON cr.Id = i.CrimeId
            JOIN City ci ON ci.Id = cr.CityId
            JOIN CriminalToInvestigation CtI ON CtI.InvestigationId = i.Id 
            JOIN Criminal c ON c.Id = CtI.CriminalId
            JOIN Person p ON p.Id = c.PersonId
            WHERE p.Name LIKE @CriminalName";

        return db.Query<InvestigationsByCriminal>(query, new { CriminalName = criminalName });
    }
    public static IEnumerable<InvestigationsByCop> AllInvestigationsByCop(string copName)
    {
        using IDbConnection db = Connect();

        string query = @"
            SELECT i.Name, i.Description, cr.CrimeDate, ci.Name AS City, i.Status
            FROM Investigation i
            JOIN Crime cr ON cr.Id = i.CrimeId
            JOIN City ci ON ci.Id = cr.CityId
            JOIN CopToInvestigation CtI ON CtI.InvestigationId = i.Id 
            JOIN Cop c ON c.Id = CtI.CopId
            JOIN Person p ON p.Id = c.PersonId
            WHERE p.Name LIKE @CopName";

        return db.Query<InvestigationsByCop>(query, new { CopName = copName });
    }
    public static IEnumerable<GangRelations> GangRelations()
    {
        using IDbConnection db = Connect();

        string query = @"
            SELECT g1.Name AS Gang1, gc.RelationType, g2.Name AS Gang2
            FROM GangConnections gc
            JOIN Gang g1 ON gc.GangId1 = g1.Id
            JOIN Gang g2 ON  gc.GangId2 = g2.Id";

        return db.Query<GangRelations>(query);
    }
    public static IEnumerable<CriminalInfo> CriminalInfo(string criminalName)
    {
        using IDbConnection db = Connect();
        
        string query = @"
            SELECT p.Name, p.Gender, p.DateOfBirth, cr.[Status], cr.[Description], g.Name AS Gang
            FROM Person p 
            JOIN Criminal cr ON cr.PersonId = p.Id
            JOIN Gang g ON g.Id = cr.GangId
            WHERE p.Name LIKE @CriminalName";

        return db.Query<CriminalInfo>(query, new { CriminalName = criminalName });
    }
    public static IEnumerable<GangInfo> GangInfo()
    {
        using IDbConnection db = Connect();

        string query = @"
            SELECT g.Name, COUNT(c.Name) AS ActiveCitys, COUNT(p.Name) AS Members
            FROM Person p 
            JOIN Criminal cr ON cr.PersonId = p.Id
            JOIN Gang g ON g.Id = cr.GangId
            JOIN GangToCity GtC ON GtC.GangId = g.Id
            JOIN City c ON c.Id = GtC.CityId
            GROUP BY g.Name";

        return db.Query<GangInfo>(query);
    }
    public static IEnumerable<GangAmmountByCity> GangAmmountByCity()
    {
        using IDbConnection db = Connect();

        string query = @"
            SELECT c.Name, COUNT(g.Name) AS ActiveGangs
            FROM Gang g
            JOIN GangToCity GtC ON GtC.GangId = g.Id
            JOIN City c ON c.Id = GtC.CityId
            GROUP BY c.Name";

        return db.Query<GangAmmountByCity>(query);
    }
    public static IEnumerable<GangCriminalAmmount> GangCriminalAmmount()
    {
        using IDbConnection db = Connect();

        string query = @"
            SELECT g.Name, COUNT(p.Name) AS Members
            FROM Person p 
            JOIN Criminal c ON c.PersonId = p.Id
            JOIN Gang g ON g.Id = c.GangId
            GROUP BY g.Name";

        return db.Query<GangCriminalAmmount>(query);
    }
    public static IEnumerable<ConvictionByCriminal> CrimeRecordAmmountByCriminal()
    {
        using IDbConnection db = Connect();

        string query = @"
            SELECT p.Name, COUNT(cr.Id) AS Convictions          
            FROM Criminal c
            JOIN CrimeRecord cr ON cr.CriminalId = c.Id
            JOIN Person p ON p.Id = c.PersonId
            JOIN CriminalToInvestigation CtI ON CtI.CriminalId = c.Id
            JOIN Investigation i ON i.Id = CtI.InvestigationId
            JOIN Crime ON Crime.Id = i.CrimeId
            JOIN Conviction co ON co.InvestigationId = i.Id
            GROUP BY p.Name";

        return db.Query<ConvictionByCriminal>(query);
    } 
}