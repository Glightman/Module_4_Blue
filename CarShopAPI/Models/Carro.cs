using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarShopAPI.Models
{
        public class Carro
        {
            public int id { get; set; }
            public string marca { get; set; }
            public string modelo { get; set; }
            public double preco { get; set; }
            public int ano { get; set; }
            public string url1 { get; set; }
            public string descricao { get; set; }
        }
    }

