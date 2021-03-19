using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using hotels.API.Models;
using Microsoft.Extensions.Hosting;

namespace hotels.API.Filters
{
    public class JsonExceptionFilters:IExceptionFilter
    {

        private readonly IWebHostEnvironment _env;
        public JsonExceptionFilters(IWebHostEnvironment env)
        {
            _env = env;
        }
        public void OnException(ExceptionContext context){
            var isDevelopment = _env.IsDevelopment();
             /*
                Development Ortamı 
                    Message = Exception.message 
                    Detail  = stackTrace
                Production ortamı
                    Message = "Api Error"
                    Detail = exception.Message
            */
            var err = new ApiError{
                Version = context.HttpContext.GetRequestedApiVersion(),
                Message = isDevelopment ? context.Exception.Message: "Api Error",
                Detail = isDevelopment ? context.Exception.StackTrace:context.Exception.Message
            };
            context.Result = new ObjectResult(err) {StatusCode = 500};
        }
    }
}
