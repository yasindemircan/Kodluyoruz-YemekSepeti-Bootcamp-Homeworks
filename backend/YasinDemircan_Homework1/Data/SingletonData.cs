using week1_homework1_yasindemircan.Models;
using System;
using System.Collections.Generic;
using System.IO;
//using Json.Net;

namespace week1_homework1_yasindemircan.Data
{
    public sealed class SingletonData
    {
        private static readonly SingletonData _instace = new SingletonData();
       
       static SingletonData(){

       }
        private SingletonData(){
            string savedData = File.ReadAllText(@"Save.json");
            if(savedData != ""){
                var Data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(savedData);
                foreach (var item in Data)
                {
                    Products.Add(new Product{
                        Id = item.Id,
                        Name = item.Name,
                        Price = item.Price
                    });
                }
            }
            else {
                FillData();
            }
        }
        public static SingletonData Instance{
            get{
                return _instace;
            }
        }
       
        private void FillData(){
           for (int i = 1; i <= 10; i++)
            {
                Products.Add(new Product
                {
                    Id = i,
                    Name = "Product_" + i,
                    Price = 100 + (i * 10)
                });

            } 
        }

        public List<Product> Products = new List<Product>();
        public void SaveData(){          // startup içinden tetikleniyor.
            string outputData = Newtonsoft.Json.JsonConvert.SerializeObject(_instace.Products);
            File.WriteAllText("Save.json",outputData);
        }
    }
    
}