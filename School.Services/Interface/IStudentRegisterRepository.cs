using School.Entities.Fields;
using System.Collections.Generic;

namespace School.Services.Interface
{
    public interface IStudentRegisterRepository : IBaseRepository<Student>
    {
        List<Student> GetByAny(dynamic dynamicObj);
    }
}