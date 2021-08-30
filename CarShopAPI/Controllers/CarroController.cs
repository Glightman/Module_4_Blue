using CarShopAPI.API;
using CarShopAPI.Models;
using CarShopAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShopAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CarroController : ApiBaseController
    {
        ICarroService _service;
        public CarroController(ICarroService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index() => ApiOk(_service.All());

        [Route("Random"), HttpGet]
        public IActionResult RandomItem()
        {
            Random rnd = new Random();
            List<Carro> carros = _service.All();            
            int r = rnd.Next(carros.Count);
            Carro existente = _service.Get(r);
            return existente == null?
                ApiNotFound("O item não foi encontrado") :
                ApiOk(existente);
        }
        

        [Route("{id}")]
        [HttpGet]
        public IActionResult Index(int? id)
        {
            Carro existente = _service.Get(id);
            return existente == null?
                ApiNotFound("Esse carro não existe") :
                ApiOk(existente);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Carro car) =>
            _service.Create(car) ?
                ApiOk("Carro cadastrado com sucesso!") :
                ApiNotFound("Erro ao cadastrar o carro!");

        [HttpPut]
        public IActionResult Update([FromBody] Carro car) =>
            _service.Update(car)?
                ApiOk("Carro atualizado com sucesso!") :
                ApiNotFound("Erro ao atualizar o carro!");

        [Route("{id}")]
        [HttpDelete]
        public IActionResult Update(int? id) =>
            _service.Delete(id) ?
                ApiOk("Carro deletado com sucesso!") :
                ApiNotFound("Erro ao deletar o carro!");
    }
} 
