namespace IndustrialInternet.Models;

public class TemperatureSensorLogModel
{
    public int Id { get; set; }
    public DateTime Time { get; set; }
    public double Temperature { get; set; }
    public bool DeviceStatus { get; set; }
    public bool FaultCondition { get; set; }

}