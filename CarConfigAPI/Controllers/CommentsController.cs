using CarConfigAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarConfigAPI.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        CarConfigApiContext dbContext;

        public CommentsController()
        {
            dbContext = new CarConfigApiContext();
        }

        [HttpGet("/comment/configuration/{configurationId}")]
        public ActionResult<List<Comments>> getAllCommentsByConfigurationId(int configurationId)
        {
            List<ConfigurationComments> temp = dbContext.ConfigurationComments.Where(c => c.ConfigurationId == configurationId).ToList();
            List<Comments> foundComments = new List<Comments>();

            foreach(ConfigurationComments cc in temp)
            {
                Comments foundComment = dbContext.Comments.Where(c => c.Id == cc.CommentId).FirstOrDefault();
                if(foundComment != null)
                {
                    foundComment.CreatedByNavigation = dbContext.Users.Where(u => u.Id == foundComment.CreatedBy).FirstOrDefault();
                    foundComments.Add(foundComment);
                }
            }

            return foundComments;
        }

        [HttpGet("/comment/count/user/{userId}")]
        public long getCommentCountByUserId(long userId)
        {
            return dbContext.Comments.Where(c => c.CreatedBy == userId).ToList().Count();
        }

        [HttpPost("/comment/add")]
        public ActionResult<Comments> saveComment([FromBody] CustomRequestBody body)
        {
            Comments comment = body.comment;
            Configurations configuration = body.configuration;
            ConfigurationComments newEntry = new ConfigurationComments();

            comment.CreatedOn = DateTime.Now;
            comment.CreatedBy = comment.CreatedByNavigation.Id;
            comment.CreatedByNavigation = null;

            dbContext.Comments.Add(comment);
            dbContext.SaveChanges();

            newEntry.CommentId = comment.Id;
            newEntry.ConfigurationId = configuration.Id;

            dbContext.ConfigurationComments.Add(newEntry);
            dbContext.SaveChanges();

            return comment;
        }
    }
}
