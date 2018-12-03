using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Business.Services;
using Blog.WebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        #region Local Variables

        private IServiceProvider _serviceProvider;
        private IPostService _postService;
        private IUserService _userService;
        private ICommentService _commentService;

        #endregion

        #region Constructors

        public BlogController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            _postService = serviceProvider.GetService<IPostService>();
            _userService = serviceProvider.GetService<IUserService>();
            _commentService = serviceProvider.GetService<ICommentService>();
        }

        #endregion

        #region API Methods

        [HttpGet("GetNextPosts")]
        public IActionResult GetNextPosts(int page)
        {
            var postsResult = _postService.GetLatestPosts(page);
            if (!postsResult.Success)
                return BadRequest(postsResult.Message);

            var result = new List<PostDTO>();

            foreach (var post in postsResult.Posts)
            {
                var dto = new PostDTO
                {
                    PostId = post.PostId,
                    Title = post.Title,
                    Body = post.Body,
                    CreationDate = post.CreationDate
                };

                var userResult = _userService.GetUserByUserId(post.UserId);
                if (userResult.Success && userResult.User != null)
                    dto.UserName = userResult.User.UserName;

                var commentsResult = _commentService.GetCommentsByPostId(post.PostId);
                if (commentsResult.Success)
                {
                    foreach (var comment in commentsResult.Comments)
                    {
                        dto.Comments.Add(new CommentDTO
                        {
                            CommentId = comment.CommentId,
                            Name = comment.Name,
                            Email = comment.Email,
                            Body = comment.Body
                        });
                    }
                }

                result.Add(dto);
            }

            return Ok(result);
        }

        #endregion
    }
}