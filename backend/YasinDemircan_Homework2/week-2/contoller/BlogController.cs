using System;
using week_2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using week_2.requestModel;
using week_2.mapping;

namespace week_2.contoller
{
      [ApiController]
    [Route("api/[controller]")]
    public class BlogController:ControllerBase
    {
        private DbContextOptions<DatabaseContext>option;
        public BlogController(){
            option = new DbContextOptionsBuilder<DatabaseContext>()
                   .UseInMemoryDatabase(databaseName: "BlogDatabase")
                   .Options;
        } 
         [HttpGet]
           public IActionResult Get(){
               List<SaveModel> result = new List<SaveModel>();
                using (DatabaseContext dbContext = new DatabaseContext(option))
            {
                var entityList = dbContext.DbModels.ToList();
                result = entityList.ToResponseModel();
            }
               return Ok(result);
           } 

            [HttpPost]
        public IActionResult Post([FromBody] RequestModel request){

            
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }


               using (DatabaseContext dbcontext = new DatabaseContext(option)){
                  var entityData = dbcontext.Add(request.ToDbModel());
                Console.WriteLine(entityData);
                dbcontext.SaveChanges();
            }
            
            return Ok();
        }
    }
}