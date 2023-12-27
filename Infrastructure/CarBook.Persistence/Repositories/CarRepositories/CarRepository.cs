using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarRepository
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _carBookContext;

        public CarRepository(CarBookContext carBookContext)
        {
           _carBookContext = carBookContext;
        }

        public List<Car> GetCarListWithBrand()
        {
           var values = _carBookContext.Cars.Include(x => x.Brand).ToList();
            return values;
        }
    }
}
