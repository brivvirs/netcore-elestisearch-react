using autocomplete.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace autocomplete.TempData
{

    public static class Cities
    {

        public static List<HintWord> GetHints(HintSection section)
        {
            var hints = GetCities().Select(word => new HintWord(section, word)).ToList();
            var count = hints.Count;
            return hints;

        }

        public static List<string> GetCities()
        {
            var citiesString = downloadCities();
            return ConvertToList(citiesString);
        }


        private static string downloadCities()
        {
            using (WebClient client = new WebClient())
            {
                string s = client.DownloadString("https://raw.githubusercontent.com/lutangar/cities.json/master/cities.json");
                return s;
            }
        }

        private static List<string> ConvertToList(string cityJson)
        {
            var result = JsonConvert.DeserializeObject<List<dynamic>>(cityJson);
            return result.Select(x => (string)x.name).ToList();
        }


    }
}
