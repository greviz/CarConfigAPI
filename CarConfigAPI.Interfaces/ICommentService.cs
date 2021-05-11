using CarConfigAPI.ViewModels;
using System.Collections.Generic;

namespace CarConfigAPI.Interfaces
{
    public interface ICommentService
    {
        public List<Comments> getAllCommentsByConfigurationId(int configurationId);
        public long getCommentCountByUserId(int userId);
        public Comments saveComment(CustomRequestBody body);
    }
}
