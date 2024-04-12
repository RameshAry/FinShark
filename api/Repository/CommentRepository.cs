using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetAllAsync(CommentQueryObject queryObject)
        {
            var comments = _context.Comments.Include(a => a.AppUser).AsQueryable();

            if (!string.IsNullOrEmpty(queryObject.Symbol))
            {
                comments = comments.Where(a => a.Stock.Symbol == queryObject.Symbol);
            };

            if (queryObject.IsDescending == true)
            {
                comments = comments.OrderByDescending(c => c.CreatedOn);
            }
            return await comments.ToListAsync();

        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            var comment = await _context.Comments.Include(a => a.AppUser).FirstOrDefaultAsync(c => c.Id == id);

            if (comment == null)
            {
                return null;
            }

            return comment;
        }

        public async Task<Comment?> CreateAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var commentModel = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);

            if (commentModel == null)
            {
                return null;

            }
            _context.Comments.Remove(commentModel);
            _context.SaveChanges();
            return commentModel;
        }

        public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
        {
            var exitingComment = await _context.Comments.FindAsync(id);
            if (exitingComment == null)
            {
                return null;
            }

            exitingComment.Content = commentModel.Content;
            exitingComment.Title = commentModel.Title;

            await _context.SaveChangesAsync();

            return exitingComment;
        }
    }
}