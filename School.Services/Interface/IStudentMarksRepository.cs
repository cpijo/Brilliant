using School.Entities.Fields;
using System.Collections.Generic;

namespace School.Services.Interface
{
    public interface IStudentMarksRepository : IRepositoryBase<StudentSubjectMarks>
    {
        List<StudentSubjectMarks> GetByAny(dynamic dynamicObj);
    }
}