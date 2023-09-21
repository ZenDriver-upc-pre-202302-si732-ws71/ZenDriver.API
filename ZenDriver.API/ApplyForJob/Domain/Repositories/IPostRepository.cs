using ZenDriver.API.ApplyForJob.Domain.Models;

namespace ZenDriver.API.ApplyForJob.Domain.Repositories;

public interface IPostRepository
{
    Task<IEnumerable<Post>> ListAsync();
    Task AddAsync(Post post);
    Task<Post> FindByIdAsync(int id);
    void Update(Post post);
    void Remove(Post post);
}