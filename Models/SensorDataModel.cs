namespace IndustrialInternet.Models;

public class SensorDataModel
{
    public int SensorId { get; set; }
    public DateTime Time { get; set; }
    public double Temperature { get; set; }
    public double Pressure { get; set; }
    public double Vibration { get; set; }


}