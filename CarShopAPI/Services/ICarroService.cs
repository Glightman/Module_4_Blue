using CarShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShopAPI.Services
{
    public interface ICarroService
    {
        List<Carro> All();
        Carro Get(int? id);
        bool Create(Carro c);
        bool Update(Carro c);
        bool Delete(int? id);
    }
}
