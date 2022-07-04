using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Task14DataPersistence
{
    internal class Program
    {

        public static string APIKey = "69bbc9286329c22bc01d2b4040bd870d";
        public static HttpClient client = new HttpClient();
        public static List<City> DBCities { get; set; }

        static void Main(string[] args)
        {
            AddCitiesListToDB();
            MainMenu().GetAwaiter().GetResult();
        }


        //fetching records from csv
        public static List<City> LoadCitiesData()
        {
            var list = new List<City>();
            Csv csv = new Csv();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "pk.csv");
            csv.FileOpen(path);
            var objs = csv.Rows[1];
            for (int i = 1; i < csv.Rows.Count(); i++)
                list.Add(new City() { CityName = csv.Rows[i][0], Latitude = Convert.ToDouble(csv.Rows[i][1]), Longitude = Convert.ToDouble(csv.Rows[i][2]), Province = csv.Rows[i][5] });
            return list;
        }


        //saving cities to DB
        public static void AddCitiesListToDB()
        {

            using (var _dbContext = new ApplicationDbContext())
            {

                _dbContext.Database.EnsureCreated();
                if (!_dbContext.CitiesList.Any())
                {
                    List<City> LoadedCitiesCSV = LoadCitiesData();
                    _dbContext.AddRange(LoadedCitiesCSV);
                    _dbContext.SaveChanges();
                }
                DBCities = _dbContext.CitiesList.AsNoTracking().ToList();
            }

        }

        public static async Task MainMenu()
        {
            //var Cities = new List<City>();
            

            Console.WriteLine("\n\n");
            foreach (City city in DBCities)
                Console.WriteLine(city.Id + "\t" + city.CityName + "\t\t" + city.Latitude + "\t" + city.Longitude + "\t" + city.Province);

            Console.WriteLine("\n\n");

            Console.WriteLine("Select a City");
            int num = 0;
            string input = Console.ReadLine();
            try
            {
                num = Convert.ToInt32(input);
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid Input");
                await MainMenu();
            }

            if (DBCities.Select(a => a.Id).ToList().Contains(num))
            {
                if(CheckIfQueryExists(num))
                {
                    using (var _dbContext = new ApplicationDbContext())
                    {

                       var result = _dbContext.APIModel.Include(b=>b.City)
                            .Include(c=>c.Weathers)
                            .Include(d=>d.MainTemp)
                            .Include(e=>e.Wind)
                            .Where(a=>a.CityId== num).AsNoTracking().FirstOrDefault();
                        Console.WriteLine("\n\nRecord Fetched From Local DB");
                        Console.WriteLine(result?.ToString());
                        Console.WriteLine("\n\nPress any key to continue....");
                        Console.ReadLine();
                    }
                }
                else
                {
                    await WheatherAPI(DBCities.Where(a=>a.Id==num).FirstOrDefault());
                }
            }
            else
            {
                Console.WriteLine("Inavlid Selection");
            }
        }

        static bool CheckIfQueryExists(int cityId)
        {
            using (var _dbContext = new ApplicationDbContext())
            {
                var count = _dbContext.APIModel.Where(a => a.CityId == cityId).ToList().Count();
                if(count != 0)
                    return true;
            }
            return false;
        }

        static async Task WheatherAPI(City city)
        {
            client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                HttpResponseMessage response = await client.GetAsync($"weather?lat={city.Latitude}&lon={city.Longitude}&appid={APIKey}");
                if (response.IsSuccessStatusCode)
                {
                    var responseObj = await response.Content.ReadAsStringAsync();
                    JObject jsonResponse = (JObject)JsonConvert.DeserializeObject(responseObj);


                    JToken wheatherValue = jsonResponse.GetValue("weather");
                    var array = wheatherValue.ToObject<List<Weather>>();
                    JToken windValue = jsonResponse.GetValue("wind");
                    JToken mainValue = jsonResponse.GetValue("main");
                    var apiObject = new APIModel()
                    {
                        Wind = windValue.ToObject<Wind>(),
                        CityId = city.Id,
                        MainTemp = mainValue.ToObject<MainTemp>(),
                        name = (string)jsonResponse.GetValue("name"),
                        Weathers = new Weather() { description = array[0].description, main = array[0].main }
                    };

                    using (var _dbContext = new ApplicationDbContext())
                        {
                        _dbContext.Database.EnsureCreated();
                        _dbContext.Attach(apiObject);
                        _dbContext.SaveChanges();
                        Console.WriteLine("\n\n");
                        var result = _dbContext.APIModel.Include(b => b.City)
                            .Include(c => c.Weathers)
                            .Include(d => d.MainTemp)
                            .Include(e => e.Wind)
                            .Where(a => a.CityId == city.Id).AsNoTracking().FirstOrDefault();
                        Console.WriteLine("\n\nRecord Fetched From API and saved DB");
                        Console.WriteLine(result.ToString());
                        Console.WriteLine("\n\nPress any key to continue....");
                        Console.ReadLine();
                    }

                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    Console.WriteLine("Not found");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Press any key to Continue....");
            Console.ReadLine();
        }
    }
}
