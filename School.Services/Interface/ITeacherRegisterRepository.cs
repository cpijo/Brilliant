using School.Entities.Fields;
using System.Collections.Generic;

namespace School.Services.Interface
{
    public interface ITeacherRegisterRepository : IRepositoryBase<Teacher>
    {
        List<Teacher> GetByAny(dynamic dynamicObj);
    }
}