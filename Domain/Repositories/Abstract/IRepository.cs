
namespace project.Domain.Repositories.Abstract;

public interface IRepository<T>
{
    IQueryable<T> GetRecords();
    IEnumerable<T> Filter(Func<T, bool> selector);
    void SaveRecord(T record);
    void RemoveRecord(Guid id);
}