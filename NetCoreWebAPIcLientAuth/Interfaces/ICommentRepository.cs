﻿using NetCoreWebAPIcLientAuth.Models;

namespace NetCoreWebAPIcLientAuth.Interfaces
{
    public interface ICommentRepository
    {
        public Task<IList<Comment>> GetAllAsync();
        public Task<Comment?> GetByIdAsync(int id);
        public Task<Comment> CreateAsync(Comment comment);
        public Task<Comment?> UpdateAsync(int id, Comment comment);
        public Task<Comment?> DeleteAsync(int id);
    }
}
