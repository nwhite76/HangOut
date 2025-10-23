public class WeatherForecast
{
    public Main main { get; set; }
    public Wind wind { get; set; }
    public string name { get; set; }  // City name (e.g. Great Yarmouth)
}

public class Main
{
    public double temp { get; set; }
    public int humidity { get; set; }
}

public class Wind
{
    public double speed { get; set; }
}
