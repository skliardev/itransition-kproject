using project.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using project.Domain.Entities.Review;

namespace project.Domain.Repositories.EntityFramework;

public class EFImages : IRepository<Image>
{
    private readonly AppDbContext context;

    public EFImages(AppDbContext context)
    {
        this.context = context;
    }

    public IQueryable<Image> GetRecords()
    {
        return context.DbImages;
    }

    public void RemoveRecord(Guid id)
    {
        context.DbImages.Remove(new Image { Id = id });
    }

    public void SaveRecord(Image record)
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