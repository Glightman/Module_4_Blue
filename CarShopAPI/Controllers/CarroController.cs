using CarShopAPI.API;
using CarShopAPI.Models;
using CarShopAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarShopAPI.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    [Route("[controller]")]
    public class CarroController : ApiBaseController
    {
        ICarroService _service;
        public CarroController(ICarroService service)
        {
            _service = service;
        }

        /// <summary>
        /// Este método retorna uma lista com todos os carros armazenados no banco de dados da loja.
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult Index() => ApiOk(_service.All());

        /// <summary>
        /// Este método retorna apenas um carro específico selecionado de forma aleatória por meio do seu id.
        /// </summary>
        /// <returns></returns> 
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

        /// <summary>
        /// Este método retorna apenas um carro específico selecionado por meio de seu id recebido como parâmetro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        [HttpGet]
        public IActionResult Index(int? id)
        {
            Carro existente = _service.Get(id);
            return existente == null?
                ApiNotFound("Esse carro não existe") :
                ApiOk(existente);
        }

        /// <summary>
        /// Este método é usado para cadastrar um novo carro no banco de dados.
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns> 
        [HttpPost]
        public IActionResult Create([FromBody] Carro car)
        {
            car.createdById = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return _service.Create(car) ?
                ApiOk("Carro cadastrado com sucesso!") :
                ApiNotFound("Erro ao cadastrar o carro!");
        }

        /// <summary>
        /// Este método é usado para editar um carro que já foi cadastrado no banco de dados.
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns> 
        [HttpPut]
        public IActionResult Update([FromBody] Carro car)
        {
            car.updatedById = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return _service.Update(car) ?
                   ApiOk("Carro atualizado com sucesso!") :
                   ApiNotFound("Erro ao atualizar o carro!");
        }

        /// <summary>
        /// Este método é usado para EXCLUIR um carro existente no banco de dados.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AuthorizeRoles(RoleTypes.Admin)]
        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int? id) =>
            _service.Delete(id) ?
                ApiOk("Carro deletado com sucesso!") :
                ApiNotFound("Erro ao deletar o carro!");

        /// <summary>
        /// Este método é usado para consultar uma lista de carros cadastradados por um determinado usuário/cargo.
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("CarroByRole/{role?}")]
        [HttpGet]
        public IActionResult CarrosByRole(string role)
        {
            return ApiOk(_service.CarrosByUserRole(role));
        }
    }
} 
