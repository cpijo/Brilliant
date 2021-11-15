using School.Entities.Fields;
using System.Collections.Generic;

namespace School.Services.Interface
{
    public interface IStudentAttendanceRepository : IBaseRepository<StudentAttendance>
    {
        List<StudentAttendance> GetByAny(dynamic dynamicObj);
    }
}