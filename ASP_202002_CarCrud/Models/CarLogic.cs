using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_202002_CarCrud.Models
{
    public class CarLogic
    {
        private List<Car> repo;
        public CarLogic()
        {
            repo = new List<Car>();
        }

        public void Add(Car car)
        {
            repo.Add(car);
        }

        public IEnumerable<Car> GetAll()
        {
            return repo;
        }

        internal void Delete(string id)
        {
            var carToDelete = 
                repo.FirstOrDefault(t => t.Id == id);
            repo.Remove(carToDelete);
        }
    }
}
