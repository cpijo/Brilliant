using School.Entities.Fields;
using System.Collections.Generic;

namespace School.Services.Interface
{
    public interface IStudentResultsRepository : IRepositoryBase<StudentResults>
    {
        List<StudentResults> GetStundentsResults();
        List<StudentResults> GetByAny(dynamic dynamicObj);
    }
}