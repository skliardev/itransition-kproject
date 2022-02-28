using project.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using project.Domain.Entities.Review;

namespace project.Domain.Repositories.EntityFramework;

public class EFHashTags : IRepository<HashTag>
{
    private readonly AppDbContext context;

    public EFHashTags(AppDbContext context)
    {
        this.context = context;
    }

    public IQueryable<HashTag> GetRecords()
    {
        return context.DbHashTags.AsQueryable<HashTag>();
    }

    public void RemoveRecord(Guid id)
    {
        context.DbHashTags.Remove(new HashTag { Id = id });
    }

    public void SaveRecord(HashTag record)
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