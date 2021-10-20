using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestProject.Model
{
    public class WeatherDTO
    {
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }

        public Main Main{ get; set; }
        public Sys Sys { get; set; }
    }
}
