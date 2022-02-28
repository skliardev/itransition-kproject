using project.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using project.Domain.Entities.Review;

namespace project.Domain.Repositories.EntityFramework;

public class EFLikes : IRepository<Like>
{
    private readonly AppDbContext context;

    public EFLikes(AppDbContext context)
    {
        this.context = context;
    }

    public IQueryable<Like> GetRecords()
    {
        return context.DbLikes.AsQueryable<Like>();
    }

    public void RemoveRecord(Guid id)
    {
        context.DbLikes.Remove(new Like { Id = id });
    }

    public void SaveRecord(Like record)
    {
        if(record.Id == null)
        {
            context.Entry(record).State = EntityState.Added;
        }
        else
        {
            context.Entry(record).State = EntityState.Modified;
        }
        context.SaveChanges();
    }
}