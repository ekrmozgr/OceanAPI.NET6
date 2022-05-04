using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Repositories
{
    public interface ICommentsRepository
    {
        Task<Comments> AddComment(Comments comment);
        Task<List<Comments>> GetCommentsByUser(int userId);
        Task<Comments> EditComment(Comments comment, int id);
        Task<Comments> DeleteComment(Comments comments);
        Task<Comments> GetCommentById(int id);
    }
}
