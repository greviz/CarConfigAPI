using CarConfigAPI.Services;
using CarConfigAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CarConfigAPI.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentService commentService;

        public CommentsController(CommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpGet("/comment/configuration/{configurationId}")]
        public ActionResult<List<Comments>> getAllCommentsByConfigurationId(int configurationId)
        {
            return commentService.getAllCommentsByConfigurationId(configurationId);
        }

        [HttpGet("/comment/count/user/{userId}")]
        public long getCommentCountByUserId(int userId)
        {
            return commentService.getCommentCountByUserId(userId);
        }

        [HttpPost("/comment/add")]
        public ActionResult<Comments> saveComment([FromBody] CustomRequestBody body)
        {
            return commentService.saveComment(body);
        }
    }
}
