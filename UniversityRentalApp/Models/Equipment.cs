namespace UniversityRentalApp.Models;

public abstract class Equipment
{
    public string Id { get; } = Guid.NewGuid().ToString().Substring(0, 8);
    
    public string Name { get; set; }
    public bool IsAvailable { get; set; } = true;

    protected Equipment(string name)
    {
        Name = name;
    }
}