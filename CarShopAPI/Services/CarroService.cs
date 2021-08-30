using CarShopAPI.Data;
using CarShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShopAPI.Services
{
    public class CarroService : ICarroService
    {
        CarShopContext _context;
        
        public CarroService(CarShopContext context)
        {
            _context = context;
        }
        public List<Carro> All()
        {
            return _context.Carro.ToList();
        }

        public bool Create(Carro c)
        {
            try
            {
                _context.Add(c);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int? id)
        {
            try
            {
                _context.Remove(this.Get(id));
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Carro Get(int? id)
        {
            return _context.Carro.FirstOrDefault(c => c.id == id);
        }

        public bool Update(Carro c)
        {
            if (!_context.Carro.Any(car => car.id == c.id))
                throw new Exception("Esse carro não existe!");
            try
            {
                _context.Update(c);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
