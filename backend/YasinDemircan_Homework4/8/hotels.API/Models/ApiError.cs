using System;
using Microsoft.AspNetCore.Mvc;

namespace hotels.API.Models
{
    public class ApiError
    {
        public string Message { get; set; }
        public string Detail {get;set;}
         public ApiVersion Version {get;set;}
    }
}
