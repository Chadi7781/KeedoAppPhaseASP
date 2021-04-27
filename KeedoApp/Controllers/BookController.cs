using KeedoApp.Models;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace KeedoApp.Controllers
{
    public class BookController : Controller
    {

        HttpClient httpClient;
        string baseAddress;
        public BookController()
        {
            baseAddress = "http://localhost:9293/SpringMVC/servlet/book";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }


        // GET: Book
        public ActionResult Book()
        {


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9293");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("SpringMVC/servlet/book/listBook").Result;

            IEnumerable<Book> book;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                book = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Book>>().Result;


            }
            else
            {
                book = null;
            }


            return View(book);
        }


        // GET: Book
        public ActionResult BookDisponible()
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9293");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("SpringMVC/servlet/book/listDisponibilityBook").Result;

            IEnumerable<Book> book;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                book = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Book>>().Result;


            }
            else
            {
                book = null;
            }



            return View(book);

        }


        // GET: Book
        public ActionResult BookDisponibleClient()
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9293");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("SpringMVC/servlet/book/listDisponibilityBook").Result;

            IEnumerable<Book> book;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                book = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Book>>().Result;


            }
            else
            {
                book = null;
            }



            return View(book);

        }
        // GET: Book
        public ActionResult RandomBook()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9293");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("SpringMVC/servlet/book/randomBook").Result;

            IEnumerable<Book> book;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                book = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Book>>().Result;


            }
            else
            {
                book = null;
            }
            return View();

        }



        // GET: Bus/Details/5
        public ActionResult Details(int Id)
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "/detailsBook/" + Id.ToString()).Result;
            Book book;
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                book = httpResponseMessage.Content.ReadAsAsync<Book>().Result;
            }
            else
            {
                book = null;
            }

            return View(book);
        }


        // GET: Book/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9293");
            client.PostAsJsonAsync<Book>("SpringMVC/servlet/book/addBook", book).
                ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

            return RedirectToAction("Book");
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int Id)
        {
            return View();
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int Id, Book book)
        {
            //HTTP POST
            var putTask = httpClient.PutAsJsonAsync<Book>(baseAddress + "/updateBook/" + Id.ToString(), book);
            putTask.Wait();

            var result = putTask.Result;

            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Bus");
            }
            return View(book);

        }

        // GET: Book/Delete/5
        public ActionResult Delete(int Id)
        {
            return View();
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int Id, FormCollection collection)
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9293/SpringMVC/servlet/book/");

                //HTTP POST
                var putTask = client.DeleteAsync("deleteBook/" + Id.ToString());
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Book");
                }
            }
            return View();
        }
    }
}
