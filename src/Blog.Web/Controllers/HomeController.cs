using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Web.Models;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Blog.Web.Controllers
{
    public class HomeController : Controller
    {
        IConfiguration configuration;

        public HomeController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        private List<PostDTO> LoadPosts(int page)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(configuration.GetValue<string>("ApiBlog:MainUrl"));
            string getNextPostsRoute = string.Format(configuration.GetValue<string>("ApiBlog:GetNextPostsRoute"), page);

            HttpResponseMessage response = client.GetAsync(getNextPostsRoute).Result;
            var posts = JsonConvert.DeserializeObject<List<PostDTO>>(response.Content.ReadAsStringAsync().Result);

            if (TempData["CurrentPosts"] == null)
                TempData["CurrentPosts"] = posts;
            else
                ((List<PostDTO>)TempData["CurrentPosts"]).AddRange(posts);

            return posts;
        }

        public IActionResult Index(int page = 1)
        {
            if (page <= 0)
                page = 1;

            var posts = LoadPosts(page);

            if (posts == null || posts.Count == 0)
            {
                page--;
                LoadPosts(page);
            }

            @ViewBag.CurrentPage = page;
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
