using Weather.Core.Models;

namespace Weather.Core.Ports{
    public interface IWeather{
        public void handle(WeatherMO weather);

        public WeatherMO handle(string weather);

        public List<string> handle();

        public List<TEntity> handle<TEntity>() where TEntity : class;
    }
}