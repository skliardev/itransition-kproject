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

    public IQueryable<Group> GetRecords()
    {
        return context.DbGroups.AsQueryable<Group>();
    }

    public void RemoveRecord(Guid id)
    {
        context.DbGroups.Remove(new Group { Id = id });
    }

    public void SaveRecord(Group record)
    {
        context.Entry(record).State = EntityState.Added;
        context.SaveChanges();
    }

    public void UpdateRecord(Group record)
    {
        context.Entry(record).State = EntityState.Modified;
        context.SaveChanges();
    }
}