using School.Entities.Fields;
using System.Collections.Generic;

namespace School.Services.Interface
{
    public interface IGradeTeacherRepository : IBaseRepository<Grades>
    {
        //List<Grades> GetById(string id, string gradeId);
    }
}