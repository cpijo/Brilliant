using System.Collections.Generic;

namespace School.Services.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        List<T> GetAll();
        List<T> GetById(string id);
        void Save(T model);
        void SaveMany(List<T> model);
        void Update(T model);
        void Delete(List<T> model);
    }
}