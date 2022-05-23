using Microsoft.EntityFrameworkCore;
using OceanAPI.NET6.Data;
using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Repositories
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<Comments> _dbSet;
        public CommentsRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = context.Set<Comments>();
        }

        public async Task<Comments> AddComment(Comments comment)
        {
            await _dbSet.AddAsync(comment);
            await _context.SaveChangesAsync();
            await _context.Entry(comment).Reference(p => p.User).LoadAsync();
            return comment;
        }

        public async Task<Comments> DeleteComment(Comments comment)
        {
            _dbSet.Remove(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comments> EditComment(Comments comment, int id)
        {
            var _comment = await _dbSet.FindAsync(id);
            if (_comment == null)
                return null;
            var response = _context.Entry(_comment);
            response.State = EntityState.Modified;

            await _context.SaveChangesAsync();
            var result = response.Entity;

            return result;
        }

        public async Task<Comments> GetCommentById(int id)
        {
            return await _dbSet.Include(x => x.User).Include(x => x.Product).FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<List<Comments>> GetCommentsByProduct(int productId)
        {
            return await _dbSet.Include(x => x.User).Where(x => x.ProductId.Equals(productId)).ToListAsync();
        }

        public async Task<List<Comments>> GetCommentsByUser(int userId)
        {
            return await _dbSet.Where(x => x.UserId.Equals(userId)).Include(x => x.Product).Include(x => x.User).ToListAsync();
        }
    }
}
