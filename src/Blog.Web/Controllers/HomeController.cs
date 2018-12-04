using Blog.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Diagnostics;

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
            List<PostDTO> posts = new List<PostDTO>();

            bool isOnline = configuration.GetValue<bool>("ApiBlog:IsOnline");

            if (isOnline)
                posts = Services.PostService.LoadPostsFromWebService(configuration, page);
            else
                posts = Services.PostService.LoadPostsFromCache(page);

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
