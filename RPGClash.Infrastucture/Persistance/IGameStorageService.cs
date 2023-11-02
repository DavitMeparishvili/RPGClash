namespace RPGClash.Infrastucture.Persistance
{
    public interface IGameStorageService
    {
        public Task SetValue<T>(string key, T value);

        public Task<T> GetValue<T>(string key);
    }
}
