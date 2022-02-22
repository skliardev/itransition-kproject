using project.Domain.Entities;
using project.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace project.Domain.Repositories.EntityFramework;

public class EFUserAccounts : IRepository<UserAccount>
{
    private readonly AppDbContext context;

    public EFUserAccounts(AppDbContext context)
    {
        this.context = context;
    }

    public IEnumerable<UserAccount> GetByFilter(Func<UserAccount, bool> selector)
    {
        foreach(var item in GetRecords()) 
        {
            if(selector(item)) {
                yield return item;
            }
        }
    }

    public IQueryable<UserAccount> GetRecords()
    {
        return context.DbUserAccounts;
    }

    public void RemoveRecord(Guid id)
    {
        context.DbUserAccounts.Remove(new UserAccount { Id = id.ToString() });
    }

    public void SaveRecord(UserAccount record)
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