using project.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using project.Domain.Entities.Review;

namespace project.Domain.Repositories.EntityFramework;

public class EFGroups : IRepository<Group>
{
    private readonly AppDbContext context;

    public EFGroups(AppDbContext context)
    {
        this.context = context;
    }

    public IEnumerable<Group> GetByFilter(Func<Group, bool> selector)
    {
        foreach(var item in GetRecords()) 
        {
            if(selector(item)) {
                yield return item;
            }
        }
    }

    public IQueryable<Group> GetRecords()
    {
        return context.DbGroups;
    }

    public void RemoveRecord(Guid id)
    {
        context.DbGroups.Remove(new Group { Id = id });
    }

    public void SaveRecord(Group record)
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