namespace HangOutApp;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	/*
		private void OnCounterClicked(object sender, EventArgs e)
		{

		}
	*/

	protected override async void OnAppearing()
    {
        int score = 0;
        string result = "";

        var service = new ForecastService();
        var forecast = await service.GetForecastAsync(52.6075, 1.7305); // Example: Great Yarmouth


        if (forecast != null)
        {
            int temp = (int)Math.Round((decimal)forecast.main.temp);
            int humidity = forecast.main.humidity;
            int wind = convertMStoMPH(forecast.wind.speed);

            // Score humidity
            if (humidity < 70)
            {
                score += 40;
            }
            else if (humidity < 85)
            {
                score += 20;
            }
            // Score Temperature
            if (temp > 25)
            {
                score += 40;
            }
            else if (temp > 20)
            {
                score += 30;
            }
            else if (temp > 15)
            {
                score += 20;
            }
            // Wind scoring
            if (wind > 10)
            {
                score += 30;
            }
            else if (wind > 5)
            {
                score += 20;
            }
            else
            {
                score += 10;
            }

            if (score > 85)
            {
                result = "Perfect";
            }
            else if (score > 60)
            {
                result = "Pretty Good";
            }
            else if (score > 45)
            {
                result = "Good";
            }
            else if (score >= 30)
            {
                result = "Average";
            }
            else
            {
                result = "Poor";
            }

            Console.WriteLine($"Temp: {forecast.main.temp}, Humidity: {forecast.main.humidity}, Wind: {forecast.wind.speed}");

            ResultLabel.Text = $"Location: {forecast.name}\n" +
                $"Temp: {temp}°C\n" +
                $"Humidity: {humidity}%\n" +
                $"Wind: {wind} mph\n" +
                $"Score: {score}%\n" +
                $"Conditions: {result}";




            // Optional: apply your drying score logic here
        }
        else
        {
            ResultLabel.Text = "Failed to get weather data.";
        }
    }
        
    public int convertMStoMPH(double speedMS)
    {
        return (int)(Math.Round(speedMS * 2.237));
    }

}

