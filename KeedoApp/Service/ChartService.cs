using KeedoApp.Helper;
using KeedoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace KeedoApp.Service
{
    public class ChartService
    {

        //Singleton instance 
        ConfigureHttpClient ConfigureHttpClient = ConfigureHttpClient.GetInstance();

        //singleton instance httpclient and set Uri(http://localhost:8084);
        HttpClient client = ConfigureHttpClient.httpClientGetInstance();

        //URL

        string springMvcUrl = ConfigureHttpClient.initiliazeHttpClient("SpringMVC/servlet");


        //CHART EVENT

        /*************************************************************/

        public int countEvent()
        {
            HttpResponseMessage httpResponseMessage = client.GetAsync(springMvcUrl + "/event/countEvent").Result;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                //recuperation 1 er json affichage events
                int count = httpResponseMessage.Content.ReadAsAsync<int>().Result;

                return count;
                //recuperation 2 eme json collamount
            }
            return 0;
        }

        /*************************************************************/
        public int countEventCollAmount ()
        {
            HttpResponseMessage httpResponseMessage = client.GetAsync(springMvcUrl + "/event/countEventCollAmount").Result;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                //recuperation 1 er json affichage events
                int count = httpResponseMessage.Content.ReadAsAsync<int>().Result;

                return count;
                //recuperation 2 eme json collamount
            }
            return 0;
        }

        

        /*************************************************************/
        public float countAVGEventCollAmount()
        {
            HttpResponseMessage httpResponseMessage = client.GetAsync(springMvcUrl + "/event/averageCollAmount").Result;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                //recuperation 1 er json affichage events
                float count = httpResponseMessage.Content.ReadAsAsync<float>().Result;

                return count;
                //recuperation 2 eme json collamount
            }
            return 0;
        }
        
        /*************************************************************/
        public float countParticipations()
        {
            HttpResponseMessage httpResponseMessage = client.GetAsync(springMvcUrl + "/event/countEventParticipation").Result;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                //recuperation 1 er json affichage events
                float count = httpResponseMessage.Content.ReadAsAsync<float>().Result;

                return count;
                //recuperation 2 eme json collamount
            }
            return 0;
        }

        public float countDonations()
        {
            HttpResponseMessage httpResponseMessage = client.GetAsync(springMvcUrl + "/donation/countDonations").Result;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                //recuperation 1 er json affichage events
                float count = httpResponseMessage.Content.ReadAsAsync<float>().Result;

                return count;
                //recuperation 2 eme json collamount
            }
            return 0;
        }

        /****************************Top 5 Events**********************************************/
        public IEnumerable<String> displaybestEventsByViews()
        {
            HttpResponseMessage httpResponseMessage = client.GetAsync(springMvcUrl + "/event/displaybestEventsByViews").Result;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                //recuperation 1 er json affichage events
                IEnumerable<String> displayViews = httpResponseMessage.Content.ReadAsAsync<IEnumerable<String>>().Result;


                return displayViews;
                //recuperation 2 eme json collamount
            }
            return null;
        }


        public IEnumerable<String> displayEventsByCollAmount()
        {
            HttpResponseMessage httpResponseMessage = client.GetAsync(springMvcUrl + "/event/displayEventsByCollAmount").Result;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                //recuperation 1 er json affichage events
                IEnumerable<String> displayViews = httpResponseMessage.Content.ReadAsAsync<IEnumerable<String>>().Result;


                return displayViews;
                //recuperation 2 eme json collamount
            }
            return null;
        }

        public IEnumerable<Event> getEventsToday()
        {
            HttpResponseMessage httpResponseMessage = client.GetAsync(springMvcUrl + "/event/getAllEventForToday").Result;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                //recuperation 1 er json affichage events
                IEnumerable<Event> displayViews = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Event>>().Result;


                return displayViews;
                //recuperation 2 eme json collamount
            }
            return null;
        }
    }
}