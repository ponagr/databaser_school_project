class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int Gender { get; set; }
}

class Criminal
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public string Description { get; set; }
    public int GangId { get; set; }
    public string Status { get; set; }
}

class Cop
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public string? Role { get; set; }
}

class Victim
{
    public int Id { get; set; }
    public int PersonId { get; set; }
}

