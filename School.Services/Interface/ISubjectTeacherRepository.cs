using School.Entities.Fields;
using System.Collections.Generic;

namespace School.Services.Interface
{
    public interface ISubjectTeacherRepository : IBaseRepository<Subject>
    {
        List<Subject> GetById(string id,string gradeId);
    }
}