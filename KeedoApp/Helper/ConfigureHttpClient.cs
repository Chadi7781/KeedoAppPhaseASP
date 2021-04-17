using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace KeedoApp.Helper
{
    public  class ConfigureHttpClient
    {
      private static   HttpClient httpClient;
        static string baseAddress;
        private static ConfigureHttpClient _instance;


        public ConfigureHttpClient()
        {

        }

        public static HttpClient httpClientGetInstance()
        {

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:8084");

            return httpClient;
        }
        public  static ConfigureHttpClient GetInstance()
        {
            if(_instance == null)
            {
                _instance = new ConfigureHttpClient();

            }

            return _instance;
        }
        public static string  initiliazeHttpClient(string baseAdress)
        { 
            baseAddress = baseAdress;
            return baseAdress;

        }


    }
}