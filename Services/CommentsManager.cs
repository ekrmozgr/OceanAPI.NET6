using OceanAPI.NET6.Models;
using OceanAPI.NET6.Repositories;

namespace OceanAPI.NET6.Services
{
    public class CommentsManager : ICommentsService
    {
        private readonly ICommentsRepository _commentsRepository;
        public CommentsManager(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        public async Task<Comments> AddComment(Comments comment)
        {
            return await _commentsRepository.AddComment(comment);
        }

        public async Task<Comments> DeleteComment(int id)
        {
            var comment = await _commentsRepository.GetCommentById(id);
            return await _commentsRepository.DeleteComment(comment);
        }

        public async Task<Comments> EditComment(Comments comment, int id)
        {
            return await _commentsRepository.EditComment(comment, id);
        }

        public async Task<Comments> GetCommentById(int id)
        {
            return await _commentsRepository.GetCommentById(id);
        }

        public async Task<List<Comments>> GetCommentsByUserId(int userId)
        {
            return await _commentsRepository.GetCommentsByUser(userId);
        }
    }
}
