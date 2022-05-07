using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Services
{
    public interface ICommentsService
    {
        Task<Comments> AddComment(Comments comment);
        Task<List<Comments>> GetCommentsByUserId(int userId);
        Task<List<Comments>> GetCommentsByProductId(int productId);
        Task<Comments> EditComment(Comments comment, int id);
        Task<Comments> DeleteComment(Comments comment);
        Task<Comments> GetCommentById(int id);
    }
}
