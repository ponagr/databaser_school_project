class Investigation
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public int CrimeId { get; set; }
    public string? Status { get; set; }
}

class CriminalToInvestigation
{
    public int CriminalId { get; set; }
    public int InvestigationId { get; set; }
}

class CopToInvestigation
{
    public int CopId { get; set; }
    public int InvestigationId { get; set; }
}

class Note
{
    public int Id { get; set; }
    public string NoteType { get; set; }
    public DateTime NoteDate { get; set; }
    public string? Description { get; set; }
    public int CopId { get; set; }
    public int InvestigationId { get; set; }
}

class Crime
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}

class Conviction
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public string? Sentence { get; set; }
    public int InvestigationId { get; set; }
    public DateTime? ConvictionDate { get; set; }
    public int? VictimId { get; set; }
}

class CrimeRecord
{
    public int Id { get; set; }
    public int CriminalId { get; set; }
    public int ConvictionId { get; set; }
}