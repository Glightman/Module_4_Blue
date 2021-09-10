using CarShopAPI.Data;
using CarShopAPI.Models;
using Microsoft.EntityFrameworkCore;
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

        public List<Carro> CarrosByUserRole(string role)
        {
            var query = "SELECT c.* FROM Carro c " +
                "JOIN AspNetUsers u ON c.createdById = u.Id " +
                "JOIN AspNetUserRoles ur ON u.id = ur.UserId " +
                "JOIN AspNetRoles r ON ur.RoleId = r.Id " +
                "WHERE r.Name = '" + role + "'";
            return _context.Carro.FromSqlRaw(query).ToList();
        }

        public bool Create(Carro c)
        {
            try
            {
                c.created = DateTime.Now;
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
                c.updated = DateTime.Now;
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
