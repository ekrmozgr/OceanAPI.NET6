using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Services
{
    public interface ICommentsService
    {
        Task<Comments> AddComment(Comments comment);
        Task<List<Comments>> GetCommentsByUserId(int userId);
        Task<Comments> EditComment(Comments comment, int id);
        Task<Comments> DeleteComment(int id);
        Task<Comments> GetCommentById(int id);
    }
}
