namespace UniversityRentalApp.Models;

public class Employee : User
{
    public override int MaxRentals => 5;
    public Employee(int id, string name) : base(id, name) { }
}