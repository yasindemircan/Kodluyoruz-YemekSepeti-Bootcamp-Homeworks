using week_2.Data;
using System.Collections.Generic;



namespace week_2.mapping
{
    public static class mapExtension
    {
        public static DbModel ToDbModel(this RequestModel blogs){
        
                return(new DbModel{
                    Id = blogs.Id,
                    Date = blogs.Date,
                    Subject = blogs.Subject,
                    TextContext = blogs.TextContext
                });      
        }
         public static List<SaveModel> ToResponseModel(this List<DbModel> blogs){
             
             List<SaveModel> result = new List<SaveModel>();
             for (int i = 0; i < blogs.Count; i++)
             {
                  result.Add(new SaveModel{
                    Id = blogs[i].Id,
                    Date = blogs[i].Date,
                    Subject = blogs[i].Subject,
                    TextContext = blogs[i].TextContext,
                }); 
             }
              return result;
            
        }
    }
}