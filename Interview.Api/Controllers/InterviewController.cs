using Interview.Models;
using Interview.Models.RequestModels;
using Interview.Models.ResponseModels;
using Interview.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace Interview.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IApiServices _services;

        public InterviewController(IApiServices service, IConfiguration configuration)
        {
            _configuration = configuration;
            _services = service;
        }

        [HttpGet("get-data-weather")]
        public async Task<IActionResult> GetDataWeather()
        {
            try
            {
                var urlWeather = $"http://api.openweathermap.org/data/2.5/group?id=1580578,1581129,1581297,1581188,1587923&units=metric&appid=91b7466cc755db1a94caf6d86a9c788a";
                var client = new HttpClient();
                var response = await client.GetAsync(urlWeather);

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                JObject data = JObject.Parse(content);
                JArray cityList = (JArray)data["list"];

                var listDataResult = new List<CityWeatherData>();

                foreach (JToken cityToken in cityList)
                {
                    CityWeatherData cityData = new CityWeatherData
                    {
                        CityId = (int)cityToken["id"],
                        CityName = (string)cityToken["name"],
                        WeatherMain = (string)cityToken["weather"][0]["main"],
                        WeatherDescription = (string)cityToken["weather"][0]["description"],
                        WeatherIcon = "http://openweathermap.org/img/wn/" + (string)cityToken["weather"][0]["icon"] + "@2x.png",
                        MainTemp = (float)cityToken["main"]["temp"],
                        MainHumidity = (int)cityToken["main"]["humidity"]
                    };

                    listDataResult.Add(cityData);
                }

                if (listDataResult != null && listDataResult.Any())
                {
                    return Ok(new BaseResponse<object>(listDataResult, "200", "Current weather information of cities"));
                }
                return Ok(new BaseResponse<object>(null, "-1", "Failed"));
            }
            catch (Exception ex)
            {
                return Ok(new BaseResponse<object>(string.Empty, "-1", ex.Message));
            }
        }

        [HttpPost("insert-data-student")]
        public async Task<IActionResult> InsertDataStudent(StudentInsertReq req)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var error = ModelState.FirstOrDefault(e => e.Value?.Errors.Count > 0).Value?.Errors?.FirstOrDefault()?.ErrorMessage;
                    return Ok(new BaseResponse<object>(string.Empty, "-1", error));
                }
                var result = await _services.InsertDataStudent(req);

                if (result == 0)
                {
                    return Ok(new BaseResponse<object>(result, "-1", "Insert Fail"));
                }

                return Ok(new BaseResponse<object>(result, "200", "Insert Success"));
            }
            catch (Exception ex)
            {
                return Ok(new BaseResponse<object>(string.Empty, "-1", ex.Message));
            }
        }

        [HttpGet("get-scoreboard-list")]
        public async Task<IActionResult> GetScoreboardList(string lop, int namHoc)
        {
            try
            {

                var result = await _services.GetScoreboardList(lop, namHoc);

                if (result == null || !result.Any())
                {
                    return Ok(new BaseResponse<object>(String.Empty, "0", "Data not found"));
                }

                return Ok(new BaseResponse<object>(result, "200", "Success"));
            }
            catch (Exception ex)
            {
                return Ok(new BaseResponse<object>(string.Empty, "-1", ex.Message));
            }
        }
    }
}