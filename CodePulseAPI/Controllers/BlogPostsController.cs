using CodePulseAPI.Data;
using CodePulseAPI.Models.Domain;
using CodePulseAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodePulseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public BlogPostsController(ApplicationDbContext dbContext) => this.dbContext = dbContext;

        [HttpPost]

        public async Task<IActionResult> CreateBlogPost(CreateBlogPostRequestDTO request)
        {
            // Map DTO to Domain Model
            var BlogPost = new BlogPost
            {
                Title = request.Title,
                ShortDescription = request.ShortDescription,
                Contnet = request.Contnet,
                FeaturedImageUrl = request.FeaturedImageUrl,
                UrlHandle = request.UrlHandle,
                PublishedDate = request.PublishedDate,
                Author = request.Author,
                IsVisible = request.IsVisible
            };

            await dbContext.BlogPosts.AddAsync(BlogPost);
            await dbContext.SaveChangesAsync();

            // Domain Model to DTO

            var response = new BlogPostDTO
            {
                Id = BlogPost.Id,
                Title = BlogPost.Title,
                ShortDescription = BlogPost.ShortDescription,
                Contnet = BlogPost.Contnet,
                FeaturedImageUrl = BlogPost.FeaturedImageUrl,
                UrlHandle = BlogPost.UrlHandle,
                PublishedDate = BlogPost.PublishedDate,
                Author = BlogPost.Author,
                IsVisible = BlogPost.IsVisible
            };

            return Ok(response);
        }
    }
}
