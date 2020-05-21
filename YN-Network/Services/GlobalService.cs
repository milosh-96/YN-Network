using System;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using YN_Network.Models;

namespace YN_Network.Services
{
    public class GlobalService
    {
        public static Fact GetRandomFact()
        {
            var factJson = new WebClient().DownloadString("http://randomuselessfact.appspot.com/random.json?language=en'");
            return JsonSerializer.Deserialize<Fact>(factJson);
        }

        public static MyIpAddress GetMyIpAddress()
        {
            //var myIpJson = new WebClient().DownloadString("https://api.ipify.org/?format=json");
            // return JsonSerializer.Deserialize<MyIpAddress>(myIpJson);
            IHttpContextAccessor accessor = new HttpContextAccessor();
            MyIpAddress myIp = new MyIpAddress { Ip = accessor.HttpContext.Connection.RemoteIpAddress.ToString() };
            return myIp;
        }

    }
}
