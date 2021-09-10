using CarShopAPI.API;
using CarShopAPI.Controllers;
using CarShopAPI.Models;
using CarShopAPI.Services;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarShopTest
{
    public class CarroControllerTest
    {
        int CarQuantity = 10;
        List<Carro> fakeCars;

        public CarroControllerTest()
        {
            fakeCars = new List<Carro>();
            for (var i = 1; i <= CarQuantity; i++)
                fakeCars.Add(new Carro
                {
                    id = i,
                    marca = $"Marca{i}",
                    modelo = $"Modelo{i}",
                    ano = 2000+i,
                    preco = i*5000,
                    url1 = $"url{i}",
                    descricao = "Carro teste!!!"
                });
        }

        [Fact]
        public void GetCar_returns_the_Correct_Cars()
        {
            var carroService = A.Fake<ICarroService>();
            A.CallTo(() => carroService.All()).Returns(fakeCars);
            var controller = new CarroController(carroService);

            ObjectResult result = controller.Index() as ObjectResult;

            var values = result.Value as APIResponse<List<Carro>>;

            Assert.True(
                values.Results == fakeCars &&
                values.Message == "" &&
                values.Succeed
                );
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(0, "Esse carro não existe", false)]
        [InlineData(3000, "Esse carro não existe", false)]
        [InlineData(-233, "Esse carro não existe", false)]
        public void GetCar_Return_Car_By_Id(int? id, string message = "", bool succeed = true)
        {
            var carroService = A.Fake<ICarroService>();
            A.CallTo(() => carroService.Get(id)).Returns(fakeCars.Find(p => p.id == id));

            var controller = new CarroController(carroService);
            ObjectResult result = controller.Index(id) as ObjectResult;

            var exists = fakeCars.Find(p => p.id == id) != null;
            if (exists)
            {
                var values = result.Value as APIResponse<Carro>;
                Assert.True(
                    values.Succeed == succeed &&
                    values.Message == message &&
                    values.Results == fakeCars.Find(p => p.id == id)
                    );
            }
            else
            {
                var values = result.Value as APIResponse<string>;
                Assert.True(
                    values.Succeed == succeed &&
                    values.Message == message &&
                    values.Results == null
                    );
            }

            
        }
    }
}
