class Gang
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}

class CriminalToGang
{
    public int Id { get; set; }
    public int CriminalId { get; set; }
    public DateTime? JoinDate { get; set; }
    public string? Status { get; set; }
    public string? CriminalLevel { get; set; }
    public int GangId { get; set; }
}

class GangConnections
{
    public int Id { get; set; }
    public int GangId1 { get; set; }
    public int GangId2 { get; set; }
    public string? RelationType { get; set; }
}

class GangConnectionsNote
{
    public int Id { get; set; }
    public string NoteType { get; set; }
    public DateTime NoteDate { get; set; }
    public string? Description { get; set; }
    public int GangConnectionsId { get; set; }
}

class GangToCity
{
    public int GangId { get; set; }
    public int CityId { get; set; }
}