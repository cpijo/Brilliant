using School.Entities.Fields;
using System.Collections.Generic;

namespace School.Services.Interface
{
    public interface IStudentAttendanceRepository : IRepositoryBase<StudentAttendance>
    {
        List<StudentAttendance> GetByAny(dynamic dynamicObj);
    }
}