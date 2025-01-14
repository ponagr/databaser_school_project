//Lägg till klass som hanterar data, och som har metoder för att hämta data från databasen, och skriva data till databasen
//Ska hantera alla klasser som existerar, och ha färdiga stored procedures för att hämta data från databasen
class HandleData
{
    public IEnumerable<Gang> GetGangs(string gangName)
    {
        using (var db = DatabaseFunctions.Connect())
        {

            var query = @"
                SELECT g.Name, COUNT(c.Name) AS ActiveCitys, COUNT(p.Name) AS Members
                FROM Person p
                JOIN Criminal cr ON cr.PersonId = p.Id
                JOIN Gang g ON g.Id = cr.GangId
                JOIN GangToCity GtC ON GtC.GangId = g.Id
                JOIN City c ON c.Id = GtC.CityId
                WHERE g.Name LIKE '%@GangName%'
                GROUP BY g.Name";

            var parameters = new { GangName = gangName };
            var gang = db.Query<string gangName, int citys, int members>(query, parameters);
            return gang;
        }
    }

    public IEnumerable<Person> GetPeople()
    {
        using (var db = DatabaseFunctions.Connect())
        {
            return db.People.ToList();
        }
    }

    public IEnumerable<Crime> GetCrimes()
    {
        using (var db = DatabaseFunctions.Connect())
        {
            return db.Crimes.ToList();
        }
    }

    public IEnumerable<Criminal> GetCriminals()
    {
        using (var db = DatabaseFunctions.Connect())
        {
            return db.Criminals.ToList();
        }
    }

    public IEnumerable<City> GetCities()
    {
        using (var db = DatabaseFunctions.Connect())
        {
            return db.Cities.ToList();
        }
    }

    public IEnumerable<Cop> GetCops()
    {
        using (var db = DatabaseFunctions.Connect())
        {
            return db.Cops.ToList();
        }
    }

    public IEnumerable<CrimeRecord> GetCrimeRecords()
    {
        using (var db = DatabaseFunctions.Connect())
        {
            return db.CrimeRecords.ToList();
        }
    }   
}