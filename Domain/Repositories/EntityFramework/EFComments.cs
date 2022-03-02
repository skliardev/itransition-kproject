using project.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using project.Domain.Entities.Review;

namespace project.Domain.Repositories.EntityFramework;

public class EFComments : IRepository<Comment>
{
    private readonly AppDbContext context;

    public EFComments(AppDbContext context)
    {
        this.context = context;
    }

    public IQueryable<Comment> GetRecords()
    {
        return context.DbComments.AsQueryable<Comment>();
    }

    public void RemoveRecord(Guid id)
    {
        context.DbComments.Remove(new Comment { Id = id });
    }

    public void SaveRecord(Comment record)
    {
        context.Entry(record).State = EntityState.Added;
        context.SaveChanges();
    }

    public void UpdateRecord(Comment record)
    {
        context.Entry(record).State = EntityState.Modified;
        context.SaveChanges();
    }
}