using KeedoApp.Helper;
using KeedoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KeedoApp.Service
{
    public class MeetingService
    {

        //Singleton instance 
        ConfigureHttpClient ConfigureHttpClient = ConfigureHttpClient.GetInstance();

        //singleton instance httpclient and set Uri
        HttpClient client = ConfigureHttpClient.httpClientGetInstance();

        //URL

        string springMvcUrl = ConfigureHttpClient.initiliazeHttpClient("SpringMVC/servlet");



        /*****************Get Meeting******************************/

        public List<Meeting>getMeetings()
        {
            List<Meeting> meetings = new List<Meeting>();
            HttpResponseMessage httpResponseMessage = client.GetAsync(springMvcUrl + "/meetings/get-all-meeting").Result;

            if (httpResponseMessage.IsSuccessStatusCode)
            {


                meetings = httpResponseMessage.Content.ReadAsAsync<List<Meeting>>().Result;

                return meetings;
            }
            else
            {
                return null;
            }
        }




        /**************Display Event By Id (Detail)**************/

        public Meeting getMeetingById(int id)
        {
            HttpResponseMessage httpResponseMessage = client.GetAsync(springMvcUrl + "/meeting/detail-meeting/" + id.ToString()).Result;
            Meeting meetings = null;

            if (httpResponseMessage.IsSuccessStatusCode)
            {


                meetings = httpResponseMessage.Content.ReadAsAsync<Meeting>().Result;


            }
            else
            {
                meetings = null;
            }
            return meetings;
        }


        /***************Add Event ***************************/


        public async Task<bool> createMeetingAsync(int id, Meeting meeting)
        {

          
            var response = await client.PostAsJsonAsync("/meetings/create-meeting/" + id,meeting);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }

    }



        /*****************Delete Meeting ****************************/
        public bool deleteMeetingById(int id)
        {
            try
            {
                var APIResponse = client.DeleteAsync(springMvcUrl + "/meetings/delete-meeting" + id.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }



        /*********************Update Meeting*************************/

        public bool Update(Event e, int id)
        {
            try
            {
                var APIResponse = client.PutAsJsonAsync<Event>(springMvcUrl + "/event/update-meeting/" + id, e);

                APIResponse.Wait();
                var result = APIResponse.Result;
                System.Diagnostics.Debug.WriteLine(APIResponse.Result);
                if (result.IsSuccessStatusCode)
                    return true;
                else
                    return false;

            }
            catch
            {
                return false;
            }
        }



       
    }



}
