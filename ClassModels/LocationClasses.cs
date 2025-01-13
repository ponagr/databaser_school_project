class City
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class Area
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public int CityId { get; set; }
}