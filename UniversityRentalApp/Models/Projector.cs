namespace UniversityRentalApp.Models;

public class Projector: Equipment
{
    public string Resolution { get; set; }
    public int Brightness { get; set; }

    public Projector(string name, string res, int lumens) : base(name)
    {
        Resolution = res;
        Brightness = lumens;
    }
}