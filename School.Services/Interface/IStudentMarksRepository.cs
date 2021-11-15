using School.Entities.Fields;
using System.Collections.Generic;

namespace School.Services.Interface
{
    public interface IStudentMarksRepository : IBaseRepository<StudentSubjectMarks>
    {
        List<StudentSubjectMarks> GetByAny(dynamic dynamicObj);
    }
}