namespace UniversityRentalApp.Models;

public class Student : User
{
    public override int MaxRentals => 2;

    public Student(int id, string name) : base(id, name) { }
}