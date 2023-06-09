namespace IndustrialInternet.Models;
public class PressureSensorLogModel
{
    public int Id { get; set; }
    public DateTime Time { get; set; }
    public double Pressure { get; set; }
    public bool DeviceStatus { get; set; }
    public bool FaultCondition { get; set; }

}