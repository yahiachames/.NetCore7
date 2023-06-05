using Dal.Model;

namespace Repository
{
    public interface ITravelRepository<T>
    {
        public IEnumerable<T> Get();

        // todo refacto optionnal
        public IEnumerable<T> GetByDeparture(string departure);

        public IEnumerable<T> GetByArrival(string arrival);

        public IEnumerable<T> GetByDepartureArrivalAndPassengers(string departure, string arrival, int passengers);

        public T Get(int id);

        public T Add(T T);

        public bool Update(T T, int id);

        public T Delete(int id);
        public FileSettings GenerateFile(int id);
    }
}