//Metoder för felhantering och liknande
class Misc
{
    public static string FirstUpper(string input)
    {
        return input.Substring(0, 1).ToUpper() + input.Substring(1);
    }


}

class UI
{
    public static void PrintInTable(List<Person> people)
    {
        //Fixa linjer, och gör så att avståndet mellan kolumnerna är lika stort, ta bort tid från DateOfBirth, Gör metod generell för alla klasser
        //Skriv ut gender som Male, Female eller Unknown, baserat på 0,1 eller 2
        Console.WriteLine("ID\tName\tDate of Birth\tAddress\tGender");
        foreach (Person person in people)
        {
            Console.WriteLine($"{person.Id}\t{person.Name}\t{person.DateOfBirth}");
        }
    }
}