namespace IndustrialInternet.Models;

public class VibrationSensorLogModel
{
    public int Id { get; set; }
    public DateTime Time { get; set; }
    public double Vibration { get; set; }
    public bool DeviceStatus { get; set; }
    public bool FaultCondition { get; set; }
}
