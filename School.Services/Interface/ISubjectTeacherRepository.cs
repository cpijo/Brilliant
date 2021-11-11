using School.Entities.Fields;
using System.Collections.Generic;

namespace School.Services.Interface
{
    public interface ISubjectTeacherRepository : IRepositoryBase<Subject>
    {
        List<Subject> GetById(string id,string gradeId);
    }
}