using Dal;
using Dal.Model;

namespace Repository
{
    public class TravelRepository : ITravelRepository<Travel>
    {
        BlueContext context;
       

        public TravelRepository(BlueContext ctxt)
        {
            this.context = ctxt;
            this.context.Database.EnsureCreated();
        }
       

      
        public Travel Add(Travel travel)
        {
            if (travel != null)
            {
                foreach (var item in this.context.Travels)
                {
                    if (item.Equals(travel)) return null;
                }
                this.context.Travels.Add(travel);
                this.context.SaveChanges();

                return travel;
            }
            else
            {
                return null;
            }
        }

        public Travel Delete(int id)
        {
            Travel itemtoRemove = this.context.Travels.Single(t => t.TravelID == id);
            if (itemtoRemove != null)
            {
                context.Travels.Remove(itemtoRemove);
                context.SaveChanges();

                return itemtoRemove;

            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Travel> Get()
        {
         
            var req = from e in this.context.Travels
                      select e;
            var list = this.context.Travels.ToList<Travel>();
            list.Sort();
            return list;
        }

        public Travel Get(int id)
        {
            return this.context.Travels.Single(t => t.TravelID == id);
        }

        public IEnumerable<Travel> GetByArrival(string arrival)
        {
            var req = from e in this.context.Travels
                      where e.Arrival == arrival
                      select e;
            return req.ToList<Travel>();
        }

        public IEnumerable<Travel> GetByDeparture(string departure)
        {
            var req = from e in this.context.Travels
                      where e.Departure == departure
                      select e;
            return req.ToList<Travel>();
        }

        public IEnumerable<Travel> GetByDepartureArrivalAndPassengers(string departure, string arrival, int passengers)
        {
            var req = from e in this.context.Travels
                      where e.Departure == departure & e.Arrival == arrival & e.NumberOfPassengers == passengers
                      select e;
            return req.ToList<Travel>();
        }

        public bool Update(Travel travel, int id)
        {
            Travel itemToUpdate = this.context.Travels.Single(t => t.TravelID == travel.TravelID);
            try
            {
                this.context.Travels.Entry(itemToUpdate).CurrentValues.SetValues(travel);

                this.context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public FileSettings GenerateFile(int id)
        {

            Travel TravelObject = this.context.Travels.Single(el => el.TravelID == id);
            string fileContent = "travel Details : " + "\nDeparture date: " + TravelObject.DepartureDate.ToString() + "\nArrival date: " + TravelObject.ArrivalDate.ToString() + "\n" +
                " Departure Location : " + TravelObject.Departure + "\nArrival Location : " + TravelObject.Arrival + "\nNumber of Passangers: " + TravelObject.NumberOfPassengers;

            string ABSOLUTE_PATH = AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppDomain.CurrentDomain.BaseDirectory.IndexOf("\\bin"));
            string fullFilePath = Path.Combine(ABSOLUTE_PATH, TravelObject.TravelID.ToString());

            using (StreamWriter writer = new StreamWriter(fullFilePath))
            {
                 writer.Write(fileContent);
            }
            return new FileSettings()
            {
                FileContent = fileContent,
                Name = TravelObject.TravelID.ToString()
            };
        }



    }

}
