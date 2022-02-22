using project.Domain.Entities;
using project.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace project.Domain.Repositories.EntityFramework;

public class EFUserReviews : IRepository<UserReview>
{
    private readonly AppDbContext context;

    public EFUserReviews(AppDbContext context)
    {
        this.context = context;
    }

    public IQueryable<UserReview> GetRecords()
    {
        return context.DbUserReviews;
    }

    public void RemoveRecord(Guid id)
    {
        context.DbUserReviews.Remove(new UserReview { Id = id });
    }

    public void SaveRecord(UserReview record)
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