using CarConfigAPI.Interfaces;
using CarConfigAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarConfigAPI.Services
{
    public class CommentService : ICommentService
    {
        private readonly CarConfigApiContext dbContext;

        public CommentService(CarConfigApiContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Comments> getAllCommentsByConfigurationId(int configurationId)
        {
            List<ConfigurationComments> temp = dbContext.ConfigurationComments.Where(c => c.ConfigurationId == configurationId).ToList();
            List<Comments> foundComments = new List<Comments>();

            foreach (ConfigurationComments cc in temp)
            {
                Comments foundComment = dbContext.Comments.Where(c => c.Id == cc.CommentId).FirstOrDefault();
                if (foundComment != null)
                {
                    foundComment.CreatedByNavigation = dbContext.Users.Where(u => u.Id == foundComment.CreatedBy).FirstOrDefault();
                    foundComments.Add(foundComment);
                }
            }

            return foundComments;
        }

        public long getCommentCountByUserId(int userId)
        {
            return dbContext.Comments.Where(c => c.CreatedBy == userId).ToList().Count();
        }

        public Comments saveComment(CustomRequestBody body)
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
