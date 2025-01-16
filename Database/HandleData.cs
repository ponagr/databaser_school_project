//Lägg till klass som hanterar data, och som har metoder för att hämta data från databasen, och skriva data till databasen
//Ska hantera alla klasser som existerar, och ha färdiga stored procedures för att hämta data från databasen
using Microsoft.SqlServer.Server;
using System.Data.SqlClient;
using System.Data;
using Dapper;

class HandleData
{
    //Lägg till foreach loop för att skriva ut alla klasser i databasen, möjligtvis en Print() metod för varje klass?
    public static IDbConnection Connect()
    {
        string connectionString = File.ReadAllText("connectionString.txt");
        return new SqlConnection(connectionString);
    }
    public static void CrimeByDateAndCity()
    {
        Console.WriteLine("Enter date");
        string date = Console.ReadLine();
        Console.WriteLine("Enter city");
        string city = Console.ReadLine();
        IEnumerable<CrimeCity> crimeCity = DatabaseFunctions.CrimeByDateAndCity(date, city);
        foreach (var item in crimeCity)
        {
            item.Print();
            Console.WriteLine();
        }
        Console.ReadKey();
    }
    public static void CriminalsByGang()
    {
        Console.WriteLine("Enter gang name");
        string gangName = Console.ReadLine();
        IEnumerable<CriminalsByGang> criminalGang = DatabaseFunctions.CriminalsByGang(gangName);
        foreach (var item in criminalGang)
        {
            item.Print();
            Console.WriteLine();
        }
        Console.ReadKey();
    }
    public static void ActiveGangsByCity()
    {
        Console.WriteLine("Enter city name");
        string cityName = Console.ReadLine();
        IEnumerable<ActiveGangsByCity> gangsByCities = DatabaseFunctions.ActiveGangsByCity(cityName);
        foreach (var item in gangsByCities)
        {
            item.Print();
            Console.WriteLine();
        }
        Console.ReadKey();
    }
    public static void CriminalRecordsByCriminal()
    {
        Console.WriteLine("Enter criminal name");
        string criminalName = Console.ReadLine();
        IEnumerable<CriminalRecordsByCriminal> criminalRecords = DatabaseFunctions.CriminalRecordsByCriminal(criminalName);
        foreach (var item in criminalRecords)
        {
            item.Print();
            Console.WriteLine();
        }
        Console.ReadKey();
    }
    public static void ActiveInvestigationsByCriminal()
    {
        Console.WriteLine("Enter criminal name");
        string name = Console.ReadLine();
        IEnumerable<InvestigationsByCriminal> activeCriminalInvestigations = DatabaseFunctions.ActiveInvestigationsByCriminal(name);
        foreach (var item in activeCriminalInvestigations)
        {
            item.Print();
            Console.WriteLine();
        }
        Console.ReadKey();
    }
    public static void ActiveInvestigationsByCop()
    {
        Console.WriteLine("Enter cop name");
        string copName = Console.ReadLine();
        IEnumerable<InvestigationsByCop> activeCopInvestigations = DatabaseFunctions.ActiveInvestigationsByCop(copName);
        foreach (var item in activeCopInvestigations)
        {
            item.Print();
            Console.WriteLine();
        }
        Console.ReadKey();
    }
    public static void AllInvestigationsByCriminal()
    {
        Console.WriteLine("Enter criminal name");
        string nameCriminal = Console.ReadLine();
        IEnumerable<InvestigationsByCriminal> allCriminalInvestigations = DatabaseFunctions.AllInvestigationsByCriminal(nameCriminal);
        foreach (var item in allCriminalInvestigations)
        {
            item.Print();
            Console.WriteLine();
        }
        Console.ReadKey();
    }
    public static void AllInvestigationsByCop()
    {
        Console.WriteLine("Enter cop name");
        string nameCop = Console.ReadLine();
        IEnumerable<InvestigationsByCop> allCopInvestigations = DatabaseFunctions.AllInvestigationsByCop(nameCop);
        foreach (var item in allCopInvestigations)
        {
            item.Print();
            Console.WriteLine();
        }
        Console.ReadKey();
    }
    public static void GangRelations()
    {
        IEnumerable<GangRelations> gangRelations = DatabaseFunctions.GangRelations();
        foreach (var item in gangRelations)
        {
            item.Print();
            Console.WriteLine();
        }
        Console.ReadKey();
    }
    public static void CriminalInfo()
    {
        Console.WriteLine("Enter criminal name");
        string input = Console.ReadLine();
        IEnumerable<CriminalInfo> criminalInfo = DatabaseFunctions.CriminalInfo(input);
        foreach (var item in criminalInfo)
        {
            item.Print();
            Console.WriteLine();
        }
        Console.ReadKey();
    }
    public static void GangInfo()
    {
        IEnumerable<GangInfo> gangInfo = DatabaseFunctions.GangInfo();
        foreach (var item in gangInfo)
        {
            item.Print();
            Console.WriteLine();
        }
        Console.ReadKey();
    }
    public static void GangAmmountByCity()
    {
        IEnumerable<GangAmmountByCity> gangCitys = DatabaseFunctions.GangAmmountByCity();
        foreach (var item in gangCitys)
        {
            item.Print();
            Console.WriteLine();
        }
        Console.ReadKey();
    }
    public static void GangCriminalAmmount()
    {
        IEnumerable<GangCriminalAmmount> gangMembers = DatabaseFunctions.GangCriminalAmmount();
        foreach (var item in gangMembers)
        {
            item.Print();
            Console.WriteLine();
        }
        Console.ReadKey();
    }
    public static void CrimeRecordAmmountByCriminal()
    {
        IEnumerable<ConvictionByCriminal> convictions = DatabaseFunctions.CrimeRecordAmmountByCriminal();
        foreach (var item in convictions)
        {
            item.Print();
            Console.WriteLine();
        }
        Console.ReadKey();
    }

}