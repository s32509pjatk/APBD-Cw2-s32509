namespace UniversityRentalApp.Models;

public class Laptop: Equipment
{
    public int RamSize { get; set; }
    public string CpuType { get; set; }

    public Laptop(string name, int ram, string cpu) : base(name)
    {
        RamSize = ram;
        CpuType = cpu;
    }
}