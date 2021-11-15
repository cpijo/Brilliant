using School.Entities.Fields;
using System.Collections.Generic;

namespace School.Services.Interface
{
    public interface ITeacherRegisterRepository : IBaseRepository<Teacher>
    {
        List<Teacher> GetByAny(dynamic dynamicObj);
    }
}