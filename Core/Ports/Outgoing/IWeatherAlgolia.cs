using Weather.Core.Models;

namespace Weather.Core.Ports{

    public interface IWeatherAlgolia{

        public void saveWeather(WeatherMO weather);
        public void saveWeather(List<WeatherMO> weather);

        public WeatherMO queryWeather(string query);

        public List<string> queryIndices();

        public List<TEntity> queryIndex<TEntity>() where TEntity : class;
    }
}