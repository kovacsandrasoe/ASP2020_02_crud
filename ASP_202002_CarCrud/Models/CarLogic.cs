using ASP_202002_CarCrud.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_202002_CarCrud.Models
{
    public class CarLogic
    {
        private CarContext repo;
        public CarLogic(CarContext repo)
        {
            this.repo = repo;
        }

        public void Add(Car car)
        {
            repo.Cars.Add(car);
            repo.SaveChanges();
        }

        public IEnumerable<Car> GetAll()
        {
            return repo.Cars; ;
        }

        internal void Delete(string id)
        {
            var carToDelete = 
                repo.Cars.FirstOrDefault(t => t.Id == id);
            repo.Cars.Remove(carToDelete);
            repo.SaveChanges();
        }

        internal void Save()
        {
            repo.SaveChanges();
        }
    }
}
