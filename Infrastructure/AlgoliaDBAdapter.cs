using Algolia.Search.Clients;
using Algolia.Search.Models.Search;
using Newtonsoft.Json;
using Weather.Core.Models;
using Weather.Core.Ports;

namespace Weather.Infrastructure{

    public class AlgoliaDBAdapter: IWeatherAlgolia{

        private SearchClient client;
        private SearchIndex index;

        public AlgoliaDBAdapter()
        {
            client = new("KFRUB7SA4U","9ddbb5fefc9c96105cf35ef912d7c27b");
            index = client.InitIndex("Weather");
        }

        public void saveWeather(WeatherMO weather){
            index.SaveObject(weather);
        }


        public void saveWeather(List<WeatherMO> weather)
        {
            index.SaveObjects(weather);
        }

        public WeatherMO queryWeather(string query){
            var result = index.Search<WeatherMO>(new Query(){Filters = "weather:Hot"});
            string test = JsonConvert.SerializeObject(result);
            return (WeatherMO)result.UserData;
        }

        public List<string> queryIndices(){
            var result = client.ListIndices();
            return result.Items.Select(indices => indices.Name).ToList<string>();
        }

        public List<TEntity> queryIndex<TEntity>() where TEntity : class{
            var result = index.Search<TEntity>(new Query());
            return result.Hits;
        }

        public void queryIndex(){
            var result = index.Search<WeatherMO>(new Query());
        }
    }
}