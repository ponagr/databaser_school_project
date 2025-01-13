class FullCriminal
{
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? Description { get; set; }
    public string? Status { get; set; }
    public FullGang? Gang { get; set; }
    public List<FullConviction?> CrimeRecord { get; set; }
    public List<FullInvestigation?> Investigations { get; set; }
}

class FullGang
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public List<City> Cities { get; set; }
    public List<Criminal> Members { get; set; }
    public List<Relations> GangConnections { get; set; }
}

class Relations
{
    public string? RelationType { get; set; }
    public FullGang Gang { get; set; }
}

class FullInvestigation
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Status { get; set; }
    public List<Cop> Cops { get; set; }
    public List<Criminal> Criminals { get; set; }
    public List<Note?> Notes { get; set; }
    public Crime Crime { get; set; }
}

class FullConviction
{
    public string? Description { get; set; }
    public string? Sentence { get; set; }
    public DateTime? ConvictionDate { get; set; }
    public FullInvestigation Investigation { get; set; }
    public List<Victim?> Victims { get; set; }
}