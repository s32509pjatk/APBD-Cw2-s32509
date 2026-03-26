namespace UniversityRentalApp.Models;

public class Camera: Equipment
{
    public string SensorType { get; set; }
    public string VideoResolution { get; set; }

    public Camera(string name, string sensor, string resolution) : base(name)
    {
        SensorType = sensor;
        VideoResolution = resolution;
    }
}