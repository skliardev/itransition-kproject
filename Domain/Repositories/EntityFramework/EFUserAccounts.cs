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
            record.Id = Guid.NewGuid().ToString();
            context.Entry(record).State = EntityState.Added;
        }
        else
        {
            context.Entry(record).State = EntityState.Modified;
        }
        context.SaveChanges();
    }

    IQueryable<UserAccount> IRepository<UserAccount>.GetRecords()
    {
        throw new NotImplementedException();
    }

    void IRepository<UserAccount>.RemoveRecord(Guid id)
    {
        throw new NotImplementedException();
    }

    void IRepository<UserAccount>.SaveRecord(UserAccount record)
    {
        throw new NotImplementedException();
    }
}