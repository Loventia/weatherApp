using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;

namespace weatherApp
{
    public partial class MainPage : ContentPage
    {
        private double _temperature;

        public double Temperature
        {
            get { return _temperature; }
            set
            {
                _temperature = value;

                OnPropertyChanged();
            }
        }


        private Main _weather;

        public Main WeatherInformation
        {
            get { return _weather; }
            set
            {
                _weather = value;

                OnPropertyChanged();
            }
        }

        public openWeatherData AllWeather
        {
            get;
            set;
        }




        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = AllWeather;
        }

        /* public List<Weather> Weathers { get => WeatherData(); }

         private List<Weather> WeatherData()
         {
             var tempList = new List<Weather>();
             tempList.Add(new Weather { Temp = "22", Date = "Sunday 16", Icon = "weather.png" });
             tempList.Add(new Weather { Temp = "21", Date = "Monday 17", Icon = "weather.png" });
             tempList.Add(new Weather { Temp = "20", Date = "Tuesday 18", Icon = "weather.png" });
             tempList.Add(new Weather { Temp = "12", Date = "Wednesday 19", Icon = "weather.png" });
             tempList.Add(new Weather { Temp = "17", Date = "Thursday 20", Icon = "weather.png" });
             tempList.Add(new Weather { Temp = "20", Date = "Friday 21", Icon = "weather.png" });

             return tempList;
         }
     }
        */

        public class Weather
        {
            public string Temp { get; set; }
            public string Date { get; set; }
            public string Icon { get; set; }
        }
        private async Task GetWeatherData()


        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");


            string response = await client.GetStringAsync("https://api.openweathermap.org/data/2.5/weather?lat=35&lon=139&appid=6db90c3aad6452a161801bb3bca1d9b1");


            ///////////////////////////////
            ///
            var weatherData = Newtonsoft.Json.JsonConvert.DeserializeObject<openWeatherData>(response);

 

            if (weatherData != null)
            {
                AllWeather = weatherData;

                //    Temperature = weatherData.main.temp;


                //        WeatherInformation = weatherData.main;


            }
      
            
        }

        protected async  override void OnAppearing()
        {
            base.OnAppearing();

            await GetWeatherData();
        }
    }
    

}
