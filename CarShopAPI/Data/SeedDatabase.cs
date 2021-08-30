using CarShopAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShopAPI.Data
{
    public static class SeedDatabase
    {
        public static void Initialize(IHost app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var context = serviceProvider.GetRequiredService<CarShopContext>();

                context.Database.Migrate();

                if (!context.Carro.Any())
                {
                    context.Carro.Add(new Carro
                    {
                        marca = "Chevrolet",
                        modelo = "Onix",
                        ano = 2018,
                        preco = 52000,
                        url1 = "https://revistacarro.com.br/wp-content/uploads/2018/05/chevrolet_onix_lt_1.4_1.png",
                        descricao = "Carro Semi novo. unico dono"
                    });
                    context.Carro.Add(new Carro
                    {
                        marca = "Chevrolet",
                        modelo = "S10",
                        ano = 2018,
                        preco = 150000,
                        url1 = "https://production.autoforce.com/uploads/version/profile_image/5100/model_main_comprar-4x4-2-8-diesel-lt-pacote-r7n_32f5a22372.png",
                        descricao = "Carro Semi novo. unico dono"
                    });
                    context.Carro.Add(new Carro
                    {
                        marca = "Ford",
                        modelo = "Ká Sedan",
                        ano = 2016,
                        preco = 43000,
                        url1 = "https://gqled.com.br/wp-content/uploads/2019/11/NOVO-KA-1.png",
                        descricao = "Carro Semi novo. unico dono"
                    });
                    context.Carro.Add(new Carro
                    {
                        marca = "Ford",
                        modelo = "Eco Sport",
                        ano = 2020,
                        preco = 87000,
                        url1 = "https://production.autoforce.com/uploads/version/profile_image/3012/comprar-freestyle-1-5-at_839776741a.png",
                        descricao = "Carro Semi novo. unico dono"
                    });
                    context.Carro.Add(new Carro
                    {
                        marca = "Fiat",
                        modelo = "Strada",
                        ano = 2019,
                        preco = 74500,
                        url1 = "https://revistacarro.com.br/wp-content/uploads/2018/05/2.png",
                        descricao = "Carro Semi novo. unico dono"
                    });
                    context.Carro.Add(new Carro
                    {
                        marca = "Fiat",
                        modelo = "Argo",
                        ano = 2021,
                        preco = 68730,
                        url1 = "https://production.autoforce.com/uploads/version/profile_image/5352/comprar-1-0_8a75988860.png",
                        descricao = "Carro NOVO"
                    });
                    context.Carro.Add(new Carro
                    {
                        marca = "VolksWagen",
                        modelo = "Voyage",
                        ano = 2018,
                        preco = 52000,
                        url1 = "https://importadora.ams3.digitaloceanspaces.com/2018/08/VoyageAutomtico.png",
                        descricao = "Carro Semi novo. unico dono"
                    });
                    context.Carro.Add(new Carro
                    {
                        marca = "VolksWagen",
                        modelo = "Amarok",
                        ano = 2021,
                        preco = 210000,
                        url1 = "https://i1.wp.com/2021volkswagen.com/wp-content/uploads/2020/11/unnamed-file-36.png",
                        descricao = "Carro NOVO"
                    });
                    context.Carro.Add(new Carro
                    {
                        marca = "Jeep",
                        modelo = "Renegade",
                        ano = 2018,
                        preco = 91200,
                        url1 = "https://production.autoforce.com/uploads/version/profile_image/1463/comprar-1-8-flex-at-pcd_a4a28811f9.png",
                        descricao = "Carro Semi novo. unico dono"
                    });
                    context.Carro.Add(new Carro
                    {
                        marca = "Toyota",
                        modelo = "Hilux SW4",
                        ano = 2021,
                        preco = 283000,
                        url1 = "https://grandbrasil.com.br/wp-content/uploads/2020/03/7f5d4-https-production.autoforce.com-uploads-version-profile_image-1115-model_main_comprar-flex-2-7_701fbe4b56.png",
                        descricao = "Carro Novo"
                    });
                    context.Carro.Add(new Carro
                    {
                        marca = "Porsche",
                        modelo = "Cayman",
                        ano = 2021,
                        preco = 649000,
                        url1 = "https://www.porschecenterbh.com.br/uploads/ad828a614baf34b7d1b39ddddb6b9539.png",
                        descricao = "Carro Novo"
                    });
                    context.Carro.Add(new Carro
                    {
                        marca = "Porsche",
                        modelo = "Macan",
                        ano = 2021,
                        preco = 379000,
                        url1 = "https://s3.us-east-2.amazonaws.com/dealer-inspire-vps-vehicle-images/stock-images/chrome/52bd6390d12604bee9ff868d5e5bf947.png",
                        descricao = "Carro Novo"
                    });
                    context.Carro.Add(new Carro
                    {
                        marca = "BMW",
                        modelo = "X6",
                        ano = 2021,
                        preco = 662950,
                        url1 = "https://catalogo.webmotors.com.br/imagens/prod/348340/BMW_X6_3.0_TWINPOWER_GASOLINA_XDRIVE40I_M_SPORT_AUTOMATICO_34834016533590667.png?s=fill&w=440&h=330&q=80&t=true",
                        descricao = "Carro Novo"
                    });
                    context.Carro.Add(new Carro
                    {
                        marca = "Mercedes",
                        modelo = "Classe C 180",
                        ano = 2021,
                        preco = 237900,
                        url1 = "https://www.mazettoseguros.com.br/blog/wp-content/uploads/2018/04/seguro-c180.png",
                        descricao = "Carro Novo"
                    });
                    context.Carro.Add(new Carro
                    {
                        marca = "Mercedes ",
                        modelo = "GLE",
                        ano = 2021,
                        preco = 722900,
                        url1 = "https://www2.mercedes-benz.com.br/passengercars/mercedes-benz-cars/models/gle/suv-v167/_jcr_content/image.MQ6.2.2x.20210730155522.png",
                        descricao = "Carro Novo"
                    });
                    context.Carro.Add(new Carro
                    {
                        marca = "Ford",
                        modelo = "Edge",
                        ano = 2021,
                        preco = 360749,
                        url1 = "https://www.ford.ca/cmslibs/content/dam/vdm_ford/live/en_ca/ford/nameplate/edge/2021/collections/3-2/21_frd_edg_sel_agbl_ps34.png/_jcr_content/renditions/cq5dam.web.1280.1280.png",
                        descricao = "Carro Novo"
                    });
                    context.Carro.Add(new Carro
                    {
                        marca = "Hyundai",
                        modelo = "Creta",
                        ano = 2021,
                        preco = 83.790,
                        url1 = "https://www.hyundai.com.br/content/dam/hmb/cars/creta/20192020/versions/HMB_Creta_Prestige_Tres-quartos_Esquerda_Prata-Sand.png/_jcr_content/renditions/cq5dam.web.768.768.png",
                        descricao = "Carro Novo"
                    });
                    context.Carro.Add(new Carro
                    {
                        marca = "Renault",
                        modelo = "Scenic Mégane",
                        ano = 2011,
                        preco = 22000,
                        url1 = "https://catalogo.webmotors.com.br/imagens/prod/341179/RENAULT_SCENIC_1.6_KIDS_16V_FLEX_4P_MANUAL_34117912413656743.png?s=fill&w=275&h=183&q=70&t=true",
                        descricao = "Ótimo Carro!"
                    });
                    context.Carro.Add(new Carro
                    {
                        marca = "Chevrolet",
                        modelo = "S10",
                        ano = 2021,
                        preco = 187590,
                        url1 = "https://production.autoforce.com/uploads/version/profile_image/6119/model_main_comprar-4x2-2-5-ecotec-advantage-pacote-r6y_ba45ab0fb7.png",
                        descricao = "Carro Novo"
                    });
                    context.Carro.Add(new Carro
                    {
                        marca = "Ford",
                        modelo = "F150 Raptor",
                        ano = 2022,
                        preco = 500000,
                        url1 = "https://i.pinimg.com/originals/17/ca/bd/17cabdfb787b823bccaa4305c781282b.png",
                        descricao = "Carro Novo"
                    });
                    context.Carro.Add(new Carro
                    {
                        marca = "Ford",
                        modelo = "Bronco",
                        ano = 2022,
                        preco = 256900,
                        url1 = "https://viaforveiculos.com.br/assets/images/versoes/4671218.png",
                        descricao = "Carro Novo"
                    });
                }

                context.SaveChanges();
            }
        }
    }
}
