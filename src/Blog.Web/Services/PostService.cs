using Blog.Web.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Blog.Web.Services
{
    public static class PostService
    {
        public static List<PostDTO> LoadPostsFromWebService(IConfiguration configuration, int page)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(configuration.GetValue<string>("ApiBlog:MainUrl"));
            string getNextPostsRoute = string.Format(configuration.GetValue<string>("ApiBlog:GetNextPostsRoute"), page);

            HttpResponseMessage response = client.GetAsync(getNextPostsRoute).Result;
            var posts = JsonConvert.DeserializeObject<List<PostDTO>>(response.Content.ReadAsStringAsync().Result);

            Cache.CacheDbContext.Instance.AddPostsToCache(posts);

            return posts;
        }

        public static List<PostDTO> LoadPostsFromCache(int page)
        {
            if (page <= 0)
                page = 1;

            int limit = 1,
                skip = limit * (page - 1);

            var posts = Cache.CacheDbContext.Instance
                .Posts
                .OrderByDescending(f => f.CreationDate)
                .Skip(skip)
                .Take(limit)
                .ToList();

            return posts;
        }
    }
}
