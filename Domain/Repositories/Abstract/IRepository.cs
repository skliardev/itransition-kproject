
namespace project.Domain.Repositories.Abstract;

public interface IRepository<T>
{
    IQueryable<T> GetRecords();
    T? GetFirstRecord(Func<T, bool> prediacte)
    {
        return GetRecords().FirstOrDefault<T>(prediacte);
    }
    IEnumerable<T> GetByFilter(Func<T, bool> prediacte)
    {
        foreach(var item in GetRecords()) 
        {
            if(prediacte(item)) {
                yield return item;
            }
        }
    }
    void SaveRecord(T record);
    void RemoveRecord(Guid id)
    {
        
    }
}