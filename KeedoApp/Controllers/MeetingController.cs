using KeedoApp.Models;
using KeedoApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace KeedoApp.Controllers
{
    public class MeetingController : Controller
    {

        MeetingService meetingService = new MeetingService();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEventsMeeting()
        {

            
            List<Meeting> meetings = meetingService.getMeetings();

            return new JsonResult { Data = meetings, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
 
        

        [HttpPost]
        public JsonResult SaveEventMeeting(Meeting m)
        {
            var status = false;

            var idKindergarden = 1;
                if (m.IdMeeting > 0)
                {
                    //Update the event
                    var v =meetingService.getMeetingById(m.IdMeeting);
                    if (v != null)
                    {
                        v.Description = m.Description;
                        v.StartDate = m.StartDate;
                        v.Description = m.Description;
                        v.IsFullDay = m.IsFullDay;
                        v.ThemeColor = m.ThemeColor;
                    }
                }
                else
                {
                    meetingService.createMeetingAsync(idKindergarden,m);
                }

                status = true;

            
            return new JsonResult { Data = new { status = status } };
        }

      }
}


    //Meeting

    // GET: Consultation/Create
    /*public ActionResult Create()
    {

    var _AccessToken = "eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJwYXJlbnQiLCJpYXQiOjE2MTk2MzYxODEsImV4cCI6MTYyMDUwMDE4MX0.WcixiXIMJ5ztdxGfuwvNSlDWdKhYYu-1h9xM4Lehta_FNN_tPLz_0fqF1PJbvGjRVy44et1UNQqHsAD5kc96pw"
            Session["AccessToken"] = _AccessToken;
    client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));

        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage httpResponseMessage = client.GetAsync("kid/getAll").Result;
        HttpResponseMessage httpResponseMessage2 = client.GetAsync("consult/getDoctors").Result;
        IEnumerable<User> doctors;
        IEnumerable<Kid> kids;
        if (httpResponseMessage.IsSuccessStatusCode)
        {
            kids = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Kid>>().Result;
        }
        else
        {
            kids = null;
        }
        if (httpResponseMessage2.IsSuccessStatusCode)
        {
            doctors = httpResponseMessage2.Content.ReadAsAsync<IEnumerable<User>>().Result;
        }
        else
        {
            doctors = null;
        }
        

        return View();
    }


    */









