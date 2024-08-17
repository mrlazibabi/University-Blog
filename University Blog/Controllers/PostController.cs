using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University_Blog.Data;
using University_Blog.Models;
using University_Blog.Services.Implement;

namespace University_Blog.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostService _postService;

        public PostController(PostService postService)
        {
            _postService = postService;
        }

        [HttpGet("/api/post/get-all")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllPosts()
        {
            try
            {
                var posts = await _postService.GetAllPosts();
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred");
            }
        }

        [HttpGet("/api/post/{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPostById(int id)
        {
            try
            {
                var post = await _postService.GetPostById(id);

                if (post == null)
                {
                    return NotFound();
                }

                return Ok(post);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred");
            }
        }

        [HttpGet("/api/post/search")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPostsByTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return BadRequest("Please provide a title to search for");
            }

            try
            {
                var posts = await _postService.GetPostsByTitle(title);

                if (posts == null || !posts.Any())
                {
                    return NotFound("No posts found with that title");
                }

                return Ok(posts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred");
            }
        }

        [HttpPost("/api/post/add")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddPost(PostDTO model)
        {
            try
            {
                // Validate the model using a validator
                //var validationResult = _validator.Validate(model);
                //if (!validationResult.IsValid)
                //{
                //    return BadRequest(validationResult.Errors);
                //}

                var newPost = await _postService.AddPost(model);
                return Ok(newPost);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred");
            }
        }

        [HttpPut("/api/post/{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePost(int id, PostDTO model)
        {
            if (id != model.Id)
            {
                return BadRequest("Id mismatch in request");
            }

            try
            {
                // Validate the model
                //var validationResult = _validator.Validate(model);
                //if (!validationResult.IsValid)
                //{
                //    return BadRequest(validationResult.Errors);
                //}

                await _postService.UpdatePost(id, model);
                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred");
            }
        }

        [HttpDelete("/api/post/{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                await _postService.DeletePost(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred");
            }
        }

    }
}

