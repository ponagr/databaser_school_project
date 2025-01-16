using System;

class Program
{
    static void Main(string[] args)
    {
        Menu.MainMenu();
        
    }
}
public class Menu
{
    public static void MainMenu()
    {
        Console.WriteLine("1. Insert data");
        Console.WriteLine("2. Update data");
        Console.WriteLine("3. Select data");
        Console.WriteLine("4. Exit");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.WriteLine("Not implemented yet");
                //Insert();
                break;
            case "2":
                Console.WriteLine("Not implemented yet");
                //Update();
                break;
            case "3":
                Select();
                break;
            case "4":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }
    public static void Insert()
    {
        Console.WriteLine("1. Person");
        Console.WriteLine("2. Gang");
        Console.WriteLine("3. Crime");
        Console.WriteLine("4. Investigation");
        Console.WriteLine("5. City");
        Console.WriteLine("6. Exit");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                //InsertPerson();
                break;
            case "2":
                //InsertGang();
                break;
            case "3":
                //InsertCrime();
                break;
            case "4":
                //InsertInvestigation();
                break;
            case "5":
                //InsertCity();
                break;
            case "6":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }
    public static void Update()
    {
        Console.WriteLine("1. Person");
        Console.WriteLine("2. Gang");
        Console.WriteLine("3. Crime");
        Console.WriteLine("4. Investigation");
        Console.WriteLine("5. City");
        Console.WriteLine("6. Exit");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                //UpdatePerson();
                break;
            case "2":
                //UpdateGang();
                break;
            case "3":
                //UpdateCrime();
                break;
            case "4":
                //UpdateInvestigation();
                break;
            case "5":
                //UpdateCity();
                break;
            case "6":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }
    public static void Select()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. Crime by Date and City");
            Console.WriteLine("2. Criminals by Gang");
            Console.WriteLine("3. Active Gangs by City");
            Console.WriteLine("4. CriminalRecords by Criminal");
            Console.WriteLine("5. Active Investigations by Criminal");
            Console.WriteLine("6. Active Investigations by Cop");
            Console.WriteLine("7. All Investigations by Criminal");
            Console.WriteLine("8. All Investigations by Cop");
            Console.WriteLine("9. Gang Connections/Relations");
            Console.WriteLine("10. Criminal Info");
            Console.WriteLine("11. Gang Info");
            Console.WriteLine("12. Active Gangs by City");
            Console.WriteLine("13. Gang Criminal Ammount");
            Console.WriteLine("14. CrimeRecord ammount by Criminal");
            Console.WriteLine("15. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    HandleData.CrimeByDateAndCity();
                    break;
                case "2":
                    HandleData.CriminalsByGang();
                    break;
                case "3":
                    HandleData.ActiveGangsByCity();
                    break;
                case "4":
                    HandleData.CriminalRecordsByCriminal();
                    break;
                case "5":
                    HandleData.ActiveInvestigationsByCriminal();
                    break;
                case "6":
                    HandleData.ActiveInvestigationsByCop();
                    break;
                case "7":
                    HandleData.AllInvestigationsByCriminal();
                    break;
                case "8":
                    HandleData.AllInvestigationsByCop();
                    break;
                case "9":
                    HandleData.GangRelations();
                    break;
                case "10":
                    HandleData.CriminalInfo();
                    break;
                case "11":
                    HandleData.GangInfo();
                    break;
                case "12":
                    HandleData.GangAmmountByCity();
                    break;
                case "13":
                    HandleData.GangCriminalAmmount();
                    break;
                case "14":
                    HandleData.CrimeRecordAmmountByCriminal();
                    break;
                case "15":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
            
        }
    }
}
