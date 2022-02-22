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

    public IEnumerable<Comment> GetByFilter(Func<Comment, bool> selector)
    {
        foreach(var item in GetRecords()) 
        {
            if(selector(item)) {
                yield return item;
            }
        }
    }

    public IQueryable<Comment> GetRecords()
    {
        return context.DbComments;
    }

    public void RemoveRecord(Guid id)
    {
        context.DbComments.Remove(new Comment { Id = id });
    }

    public void SaveRecord(Comment record)
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