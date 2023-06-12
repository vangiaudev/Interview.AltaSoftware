namespace Interview.Models.ResponseModels
{
    public class CityWeatherData
    {
        public int CityId { get; set; }
        public string? CityName { get; set; }
        public string? WeatherMain { get; set; }
        public string? WeatherDescription { get; set; }
        public string? WeatherIcon { get; set; }
        public float MainTemp { get; set; }
        public int MainHumidity { get; set; }
    }
}