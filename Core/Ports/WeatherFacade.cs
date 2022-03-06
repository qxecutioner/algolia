using Weather.Core.Ports;
using Weather.Core.Models;
using Weather.Infrastructure;

namespace Weather.Core.Ports{
    public class WeatherFacade : IWeather{
        private IWeatherAlgolia database;

        public WeatherFacade(){
            database = new AlgoliaDBAdapter();
        }

        public void handle(WeatherMO weather)
        {
            database.saveWeather(weather);
        }

        public void handle(List<WeatherMO> weather){
            database.saveWeather(weather);
        }

        public WeatherMO handle(string weather)
        {
            return database.queryWeather($"weather:{weather}");
        }

        public List<string> handle()
        {
            return database.queryIndices();
        }

        public List<TEntity> handle<TEntity>() where TEntity : class{
            return database.queryIndex<TEntity>();
        }
    }
}