
namespace BS.Repository
{
    using System.Collections.Generic;

    public interface IRepository<T> where T : class
    {
        ICollection<T> GetAll();

        T GetById(object id);

        void Insert(T t);

        void Update(T t);

        void Delete(int id);

        int Save();
        ICollection<T> GetPartial();
        int CountAll();
        IEnumerable<T> ListAllPaging(string searh, int page, int pageSize);
    }
}
