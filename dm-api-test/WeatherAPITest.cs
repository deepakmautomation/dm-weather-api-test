using dm_api_test.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Text.Json.Nodes;
using static dm_api_test.Models.WeatherModel1;

namespace dm_api_test
{
    public class Tests
    {

        private string apiKey = "use API Key";

        private string baseURL = "https://api.openweathermap.org/data";

        string cityName = "London";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void getWeatherByCity()
        {
            RestClient restClient = new RestClient(baseURL);

            RestRequest restRequest = new RestRequest("/2.5/weather", Method.Get);

            restRequest.AddParameter("q", cityName);

            restRequest.AddParameter("appid", apiKey);

            RestResponse restResponse = restClient.Execute(restRequest);

            Console.WriteLine(restResponse.Content);

            if(restResponse.Content != null)
            {
                var weatherData = JsonConvert.DeserializeObject<WeatherResponse>(restResponse.Content);

                Assert.That(weatherData, Is.Not.Null);

                Assert.That(weatherData.name, Is.EqualTo(cityName));

                Console.WriteLine("City Name is: " + weatherData.name);
            }

        }

    }
}
