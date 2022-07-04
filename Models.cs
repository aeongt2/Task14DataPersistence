using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task14DataPersistence
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Province { get; set; }
        public override string ToString()
        {
            return "City { CityName: \t" + CityName + "Latitude: \t" + Latitude+ "Longitude: \t" + Longitude + "Province: \t" + Province + " }";
        }
    }


    public class APIModel
    {
        public int Id { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        public string name { get; set; }
        public int MainTempId { get; set; }
        public MainTemp MainTemp { get; set; }
        public int WeatherId { get; set; }
        public Weather Weathers { get; set; }
        public int WindId { get; set; }
        public Wind Wind { get; set; }

        public override string ToString()
        {
            return "APIModel  \n"+ City+ "\n" + MainTemp + "\n" + Weathers +"\n"+Wind+"\n";
        }
    }
    public class Weather
    {
        public int Id { get; set; }
        public string main { get; set; }
        public string description { get; set; }

        public override string ToString()
        {
            return "Wheather { main: " + main + "\tDescription: " + description+" }";
        }
    }
    public class MainTemp
    {
        public int Id { get; set; }
        public float temp { get; set; }
        public float feels_like { get; set; }
        public float temp_min { get; set; }
        public float temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public int sea_level { get; set; }
        public int grnd_level { get; set; }

        public override string ToString()
        {
            return "MainTemp { temp: " + temp + "\tfeels_like: " + feels_like + "\ttemp_min: " + temp_min + "\ttemp_max: " + temp_max + "\tpressure: " + pressure+ "\thumidity: " + humidity + "\tsea_level: " + sea_level+ "\tgrnd_level: " + grnd_level + " }";
        }
    }
    public class Wind
    {
        public int Id { get; set; }
        public float speed { get; set; }
        public int deg { get; set; }
        public float gust { get; set; }
        public override string ToString()
        {
            return "Wind { speed: " + speed + "\tdeg: " + deg + "\tgust: " + gust +  " }";
        }
    }
    public class Coordinate
    {
        public int Id { get; set; }
        public float lon { get; set; }
        public float lat { get; set; }
        public override string ToString()
        {
            return "Coordinate { lon: " + lon + "\tlat: " + lat + " }";
        }
    }
}
