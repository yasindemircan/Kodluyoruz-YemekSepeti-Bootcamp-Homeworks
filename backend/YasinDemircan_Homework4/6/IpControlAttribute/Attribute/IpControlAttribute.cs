using System;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace IpControlAttribute.Attribute
{

    public class IpControlAttribute:ActionFilterAttribute
    {
        private readonly IConfiguration _configuration;
        public IpControlAttribute(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public override void OnActionExecuting(ActionExecutingContext context){
           IPAddress ClientIp = context.HttpContext.Connection.RemoteIpAddress;
           var allowIp = _configuration.GetSection("WhiteList:192.168.1.2");
           var allowIpGroup = _configuration.GetSection("WhiteList:192.168.1.1");
           var IpList = allowIpGroup.Value.Split(",");
            bool IpListRoute = context.RouteData.Values.Values.Contains(IpList[0]) || 
                                context.RouteData.Values.Values.Contains(IpList[1]);

            if(allowIp.Key != ClientIp.ToString() && allowIpGroup.Key != ClientIp.ToString()){
                  context.Result = new StatusCodeResult((int)HttpStatusCode.Forbidden);
                  return;
            }
           if(IpList.Length > 1)

               if(ClientIp.ToString() == allowIpGroup.Key && !IpListRoute){
             context.Result = new StatusCodeResult((int)HttpStatusCode.Forbidden);
               return;  
           }      

            if(ClientIp.ToString() == allowIp.Key && !context.RouteData.Values.Values.Contains(allowIp.Value) ){
             context.Result = new StatusCodeResult((int)HttpStatusCode.Forbidden);
               return;  
           }      

        base.OnActionExecuting(context);
        }
    }
}



