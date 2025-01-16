class CrimeCity
{
    public string Name { get; set; }
    public string Date { get; set; }
    public string CityName { get; set; }
    public void Print()
    {
        Console.WriteLine("Name\tDate\tCityName");
        Console.WriteLine($"{Name}\t{Date}\t{CityName}");
    }
}
class CriminalsByGang
{
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PersonDescription { get; set; }
    public string Status { get; set; }
    public string Gang { get; set; }
    public string GangDescription { get; set; }
    public void Print()
    {
        Console.WriteLine("Name\tDateOfBirth\tPersonDescription\tStatus\tGang\tGangDescription");
        Console.WriteLine($"{Name}\t{DateOfBirth}\t{PersonDescription}\t{Status}\t{Gang}\t{GangDescription}");
    }
}
class ActiveGangsByCity
{
    public string Gang { get; set; }
    public string ActiveCity { get; set; }
    public string GangDescription { get; set; }
    public void Print()
    {
        Console.WriteLine("Gang\tActiveCity\tGangDescription");
        Console.WriteLine($"{Gang}\t{ActiveCity}\t{GangDescription}");
    }
}
class CriminalRecordsByCriminal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Sentence { get; set; }
    public DateTime CrimeDate { get; set; }
    public DateTime ConvictionDate { get; set; }
    public void Print()
    {
        Console.WriteLine("Name\tDescription\tSentence\tCrimeDate\tConvictionDate");
        Console.WriteLine($"{Name}\t{Description}\t{Sentence}\t{CrimeDate}\t{ConvictionDate}");
    }
}
class InvestigationsByCriminal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CrimeDate { get; set; }
    public string City { get; set; }
    public string? Status { get; set; }
    public void Print()
    {
        Console.WriteLine("Status\tName: Description\tDate\tCity");
        Console.WriteLine($"{Status} - {Name}: {Description}\t{CrimeDate}\t{City}");
    }
}
class InvestigationsByCop
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CrimeDate { get; set; }
    public string City { get; set; }
    public string? Status { get; set; }

    public void Print()
    {
        Console.WriteLine("Status\tName: Description\tDate\tCity");
        Console.WriteLine($"{Status} - {Name}: {Description}\t{CrimeDate}\t{City}");
    }
}
class GangRelations
{
    public string Gang1 { get; set; }
    public string RelationType { get; set; }
    public string Gang2 { get; set; }
    public void Print()
    {
        Console.WriteLine("Gang1\tRelationType\tGang2");
        Console.WriteLine($"{Gang1}\t{RelationType}\t{Gang2}");
    }
}
class CriminalInfo
{
    public string Name { get; set; }
    public int Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Status { get; set; }
    public string Description { get; set; }
    public string Gang { get; set; }
    public void Print()
    {
        string gender;
        if (Gender == 1)
        { 
            gender = "Male"; 
        }
        else
        {
            gender = "Female";
        }
        Console.WriteLine("Status\tName - DateOfBirth - Gender: Description\tGang");
        Console.WriteLine($"{Status}\t{Name} - {DateOfBirth} - {gender}: {Description}\t{Gang}");
    }
}
class GangInfo
{
    public string Name { get; set; }
    public int ActiveCitys { get; set; }
    public int Members { get; set; }
    public void Print()
    {
        Console.WriteLine("Name\tActiveCitys\tMembers");
        Console.WriteLine($"{Name}\t{ActiveCitys}\t{Members}");
    }
}
class GangAmmountByCity
{
    public string Name { get; set; }
    public int ActiveGangs { get; set; }
    public void Print()
    {
        Console.WriteLine("City: ActiveGangs");
        Console.WriteLine($"{Name}: {ActiveGangs}");
    }
}
class GangCriminalAmmount
{
    public string Name { get; set; }
    public int Members { get; set; }
    public void Print()
    {
        Console.WriteLine("Name: Members");
        Console.WriteLine($"{Name}: {Members}");
    }
}
class ConvictionByCriminal
{
    public string Name { get; set; }
    public int Convictions { get; set; }
    public void Print()
    {
        Console.WriteLine("Name: Convictions");
        Console.WriteLine($"{Name}: {Convictions}");
    }
}


