using project.Domain.Entities;
using project.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace project.Domain.Repositories.EntityFramework;

public class EFUserAccounts : IRepository<UserAccount>
{
    public AppDbContext DbContext { get; }
    private readonly AppDbContext context;

    public EFUserAccounts(AppDbContext context)
    {
        this.context = context;
        DbContext = context;
    }

    public IQueryable<UserAccount> GetRecords()
    {
        return context.DbUserAccounts.AsQueryable<UserAccount>();
    }

    public void RemoveRecord(Guid id)
    {
        context.DbUserAccounts.Remove(new UserAccount { Id = id.ToString() });
    }

    public void SaveRecord(UserAccount record)
    {
        record.Id = Guid.NewGuid().ToString();
        context.Entry(record).State = EntityState.Added;
        context.SaveChanges();
    }

    public void UpdateRecord(UserAccount record)
    {
        context.Entry(record).State = EntityState.Modified;
        context.SaveChanges();
    }
}