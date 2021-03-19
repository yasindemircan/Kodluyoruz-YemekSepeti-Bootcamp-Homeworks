using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using week1_homework1_yasindemircan.Models;
using week1_homework1_yasindemircan.Data;

namespace week1_homework1_yasindemircan.Controllers
{   
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController:ControllerBase
    {
        private readonly SingletonData _singletonData;
        public ProductController(){
            _singletonData = SingletonData.Instance;
        }
        [HttpGet]
        public ActionResult<Product> GetProduct()
        {
            return Ok(_singletonData.Products);
        }
        [HttpGet("{id}")]
        public ActionResult<Product> GetProductModel(int id)
        {
            var data = _singletonData.Products.FirstOrDefault(c => c.Id == id);
            if(data !=  null){
                return Ok(data);
            }
            return NotFound($"{id} Nolu Urun Bulunamadı");
        }
        [HttpDelete("{id}")]
        public ActionResult<Product> DeleteProductById(int id)
        {
           var data = _singletonData.Products.Find(c => c.Id == id);
                if(data==null){
                return NotFound($"{id} Nolu Kayıt Bulunamadı");
            }
             _singletonData.Products.Remove(data);
            return Ok($"{id} Nolu Kayıt Basarıyla Silindi");
        }
        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
        {   
             var data = _singletonData.Products.Find(c => c.Id == product.Id);
             if(data != null){
                 return BadRequest($"{product.Id} Bu id ile kayıtlı bir ürün zaten var");
             }
            _singletonData.Products.Add(product);
             return Ok($"{product.Name} Basarıyla Eklendi");
        }
        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, Product product)
        {
            
            var entity = _singletonData.Products.Find(c => c.Id == id);
            if(entity == null){
                 return NotFound($"{id} Nolu Urun Bulunamadı");
           }
           entity.Name = product.Name;
           entity.Price = product.Price;
          return Ok($"{id} Nolu Urun Basarıyla Guncellendi");
        }

         [HttpOptions]
       public void head(){
           HttpContext.Response.Headers.Add("Allow","GET,POST,PUT,DELETE,OPTIONS");
       }
        
        
    }
}