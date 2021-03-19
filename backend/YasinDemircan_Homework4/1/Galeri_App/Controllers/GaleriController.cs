using System;
using Galeri_App.Car;
using Microsoft.AspNetCore.Mvc;

namespace Galeri_App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GaleriController:ControllerBase
    {
        private readonly ICarForShow _singletonService;
         private readonly ICarForShow _singletonService2;
        private readonly ICarForSell _transientService;
         private readonly ICarForSell _transientService2;

        private readonly ICarForTest _scopedService;
        private readonly ICarForTest _scopedService2;

        public GaleriController(ICarForTest scopedService,
         ICarForTest scopedService2,
         ICarForShow singletonService,
         ICarForShow singletonService2,
         ICarForSell transientService,
         ICarForSell transientService2)
        {
            _scopedService = scopedService;
            _scopedService2 = scopedService2;
            _singletonService = singletonService;
            _singletonService2 =  singletonService2;
            _transientService = transientService;
            _transientService2 = transientService2;
        }
          [HttpGet]
        public string Get()
        {
            string result = $"Satın Almak için gelen1: {_transientService2.GetName()} {Environment.NewLine}" +
                             $"Test Sürüsü için Gelen1: {_scopedService.GetName() } {Environment.NewLine}" +
                             $"Showroom Aracını incelemek için gelen1: {_singletonService.GetName() } {Environment.NewLine}" +
                             $"Satin Almak İçin Gelen2: {_transientService.GetName()} {Environment.NewLine}" +
                             $"Test Sürüsü için Gelen2: {_scopedService2.GetName()} {Environment.NewLine}" +
                             $"Showroom Aracını incelemek için gelen2: {_singletonService2.GetName()} {Environment.NewLine}";
            return  result;
          /*
            Burada Olayı biraz hikayeleştirmek gerekirse: Bir X markasının oto galerisini düşünebiliriz, bu x markasının galerisine
            2021 yılı için yeni araçlar gelmektedir. Bu araçlardan bir kaç tanesini Showroom kısmına alırlar ve 2022 model araç gelene kadar o araç 
            showroomda sergilenir, ve yine belirli bir sayida aracı Test aracı olarak ayrılır bayiye gelen müşteriler almadan önce test sürüsüne
            cıkabilmesi için, geriye kalan araçlar satılmak üzere müşterileri beklerler.
            şimdi bizim sunucumuda bu kodu ayağa kaldırmayı bir yıl olarak ele alırsak, yani 2021 model araçlar galeriye geldi ve aralarından bir kaç
            tanesi Showrooma kondu. Bu araçlar 2021 yılı boyuncu hiç değişmeyecek sürekli olarak aynıları sergilenicek(Singleton).
            Şimdi galeriye gelip araç test etmek isteyen müşterilere bakalım, yılın başında gelen ve test aracı olarak ayırılan araçlar test edilmek 
            üzere müşterilere verilir eger bir requesti bir güne denk tutarsak, gün içinde gelen her müşteriye aynı test aracı verilecektir(Scoped).
            Son olarak satın almak için gelen müşteriler kalıyor, Burada müşterilere aynı aracı sadece bir kez satabileceğimizden her satın alma için gelen
            müşteriye farklı araclar veriliyor(Transient).  
        Çıktı:
            Satın Almak için gelen1: 25 Nolu Araç 
            Test Sürüsü için Gelen1: 30 Nolu Araç 
            Showroom Aracını incelemek için gelen1: 42 Nolu Araç 
            Satin Almak İçin Gelen2: 59 Nolu Araç 
            Test Sürüsü için Gelen2: 30 Nolu Araç 
            Showroom Aracını incelemek için gelen2: 42 Nolu Araç
            */
        }
    }
}
