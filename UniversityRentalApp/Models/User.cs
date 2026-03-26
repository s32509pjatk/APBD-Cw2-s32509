namespace UniversityRentalApp.Models;

public abstract class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public abstract int MaxRentals { get; }

    protected User(int id, string name)
    {
        Id = id;
        Name = name;
    }
}