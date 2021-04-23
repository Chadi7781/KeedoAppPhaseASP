using KeedoApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace KeedoApp.Controllers
{
    public class PostController : Controller
    {
        HttpClient httpClient;
        string baseAddress;
        public PostController()
        {
            baseAddress = "http://localhost:9293/SpringMVC/servlet/";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        // GET: Post
        public ActionResult Index(string searchString)
        {

            IEnumerable<Post> posts;


            HttpResponseMessage httplikemessage;
            HttpResponseMessage httpcmtmessage;

            HttpResponseMessage httpResponseMessage;
            if (String.IsNullOrEmpty(searchString))
            {
                System.Diagnostics.Debug.WriteLine("entered Index");

                httpResponseMessage = httpClient.GetAsync(baseAddress + "Post/get-all-posts").Result;


                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    posts = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Post>>().Result;

                    foreach (Post p in posts)
                    {
                        httplikemessage = httpClient.GetAsync(baseAddress + "Liking/count-post-likes/" + p.IdPost).Result;
                        httpcmtmessage = httpClient.GetAsync(baseAddress + "Comment/count-post-comments/" + p.IdPost).Result;

                        p.Likenb = httplikemessage.Content.ReadAsStringAsync().Result.ToString();
                        p.Cmtnb = httpcmtmessage.Content.ReadAsStringAsync().Result.ToString();
                        // System.Diagnostics.Debug.WriteLine("this is the id" + p.IdPost+ "this is nblike" + httplikemessage.Content.ReadAsStringAsync().Result.ToString());


                    }
                }
                else
                {
                    posts = null;
                }

                return View(posts);
            }
            else
            {
                httpResponseMessage = httpClient.GetAsync(baseAddress + "Post/search-by-admin/?pattern=" + searchString).Result;
                if (httpResponseMessage.IsSuccessStatusCode)
                {

                    posts = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Post>>().Result;
                }
                else
                {
                    posts = null;
                }

                return View(posts);
            }
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "Post/detail-post/" + id.ToString()).Result;
            Post post;
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                post = httpResponseMessage.Content.ReadAsAsync<Post>().Result;
            }
            else
            {
                post = null;
            }

            return View(post);
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(Post post)
        {
            var postTask = httpClient.PostAsJsonAsync<Post>(baseAddress + "Post/add-post", post);
            postTask.Wait();

            var result = postTask.Result;

            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }



        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Post post)
        {
            //HTTP POST
            var putTask = httpClient.PutAsJsonAsync<Post>(baseAddress + "Post/update-post/" + id.ToString(), post);
            putTask.Wait();

            var result = putTask.Result;

            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();

        }




        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            //HTTP POST
            var putTask = httpClient.DeleteAsync(baseAddress + "Post/delete-post/" + id.ToString());
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Post/Details/5
        public ActionResult Likes(int id)
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "Liking/likes-by-post/" + id.ToString()).Result;
            IEnumerable<Liking> like;
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                like = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Liking>>().Result;
            }
            else
            {
                like = null;
            }

            return View(like);
        }
        public ActionResult Comments(int id)
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "Comment/comments-by-post/" + id.ToString()).Result;
            IEnumerable<Comment> comment;
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                comment = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Comment>>().Result;
                foreach (Comment c in comment)
                {
                    System.Diagnostics.Debug.WriteLine("test" + c.Login);

                }

            }
            else
            {
                comment = null;
            }

            return View(comment);
        }

        // GET: Post ID of current user here 
        public ActionResult Timeline(int id)
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "Post/posts-by-user/" + id.ToString()).Result;
            IEnumerable<Post> posts;
            HttpResponseMessage httplikemessage;
            HttpResponseMessage httpcmtmessage;
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                posts = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Post>>().Result;
                foreach (Post p in posts)
                {
                    httplikemessage = httpClient.GetAsync(baseAddress + "Liking/count-post-likes/" + p.IdPost).Result;
                    httpcmtmessage = httpClient.GetAsync(baseAddress + "Comment/count-post-comments/" + p.IdPost).Result;

                    p.Likenb = httplikemessage.Content.ReadAsStringAsync().Result.ToString();
                    p.Cmtnb = httpcmtmessage.Content.ReadAsStringAsync().Result.ToString();
                    // System.Diagnostics.Debug.WriteLine("this is the id" + p.IdPost+ "this is nblike" + httplikemessage.Content.ReadAsStringAsync().Result.ToString());


                }
            }
            else
            {
                posts = null;
            }
            return View(posts);
        }

        public ActionResult Share(int id)
        {
            return (Share(id, null));
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Share(int id, Post post)
        {
            var postTask = httpClient.PostAsync(baseAddress + "Post/share-post/" + id.ToString(), null);
            postTask.Wait();

            var result = postTask.Result;



            return RedirectToAction("Index");

        }
        public ActionResult Reported()
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "Post/reported").Result;
            IEnumerable<Post> posts;
            HttpResponseMessage httplikemessage;
            HttpResponseMessage httpcmtmessage;
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                posts = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Post>>().Result;
                foreach (Post p in posts)
                {
                    httplikemessage = httpClient.GetAsync(baseAddress + "Liking/count-post-likes/" + p.IdPost).Result;
                    httpcmtmessage = httpClient.GetAsync(baseAddress + "Comment/count-post-comments/" + p.IdPost).Result;

                    p.Likenb = httplikemessage.Content.ReadAsStringAsync().Result.ToString();
                    p.Cmtnb = httpcmtmessage.Content.ReadAsStringAsync().Result.ToString();
                    // System.Diagnostics.Debug.WriteLine("this is the id" + p.IdPost+ "this is nblike" + httplikemessage.Content.ReadAsStringAsync().Result.ToString());


                }
            }
            else
            {
                posts = null;
            }
            return View(posts);
        }
        public ActionResult DeleteReported(int id)
        {
            return View();
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult DeleteReported(int id, FormCollection collection)
        {
            //HTTP POST
            var puttTask = httpClient.DeleteAsync(baseAddress + "Post/approve-reported/" + id.ToString());
            puttTask.Wait();
            var putTask = httpClient.DeleteAsync(baseAddress + "Post/delete-post/" + id.ToString());
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Reported");
            }
            return View();
        }

        public ActionResult Approve(int id)
        {
            return (Approve(id, null));
        }
        [HttpPost]
        public ActionResult Approve(int id, FormCollection collection)
        {
            //HTTP POST
            var putTask = httpClient.DeleteAsync(baseAddress + "Post/approve-reported/" + id.ToString());
            putTask.Wait();


            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Reported");
            }
            return View();
        }



        public ActionResult Comment()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Comment(int id, Comment comment)
        {
            var postTask = httpClient.PostAsJsonAsync<Comment>(baseAddress + "Comment/add-comment/" + id.ToString(), comment);
            postTask.Wait();

            var result = postTask.Result;

            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult DeleteComment(int id)
        {
            return View();
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult DeleteComment(int id, FormCollection collection)
        {
            //HTTP POST
            var putTask = httpClient.DeleteAsync(baseAddress + "Comment/delete-comment/" + id.ToString());
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();

        }

        // GET: Post/Edit/5
        public ActionResult EditComment(int id)
        {
            return View();
        }



        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult EditComment(int id, Comment comment)
        {
            //HTTP POST
            var putTask = httpClient.PutAsJsonAsync<Comment>(baseAddress + "Comment/update-comment/" + id.ToString(), comment);
            putTask.Wait();

            var result = putTask.Result;

            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();

        }

        public ActionResult Like(int id)
        {
            return (Like(id, null));
        }
        // POST: Post/Create
        [HttpPost]
        public ActionResult Like(int id, Liking like)
        {
            var postTask = httpClient.PostAsJsonAsync<Liking>(baseAddress + "Liking/add-like/" + id.ToString(), null);
            postTask.Wait();

            var result = postTask.Result;



            return RedirectToAction("Index");

        }
    }
}
