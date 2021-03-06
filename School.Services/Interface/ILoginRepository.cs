using School.Entities.Fields;
using System.Collections.Generic;

namespace School.Services.Interface
{
    public interface ILoginRepository : IBaseRepository<UserLogin>
    {
        List<UserLogin> GetByAny(dynamic dynamicObj);
    }
}