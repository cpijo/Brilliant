using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using School.Entities.Fields;
using School.Services.Interface;

namespace School.Services.Repository
{
    public class GradeClassRepository : RepositoryBase<Subject>, IGradeClassRepository
    {

        public override List<Subject> GetAll()
        {
            command.CommandText = "SELECT * FROM Studentdb.dbo.GradeClass";//GradeClass
            return base.GetAll();
        }

        public override Subject PopulateRecord(SqlDataReader rows)
        {
            try
            {
                Subject model = new Subject();
                model.SubjectId = rows["SubjectId"].ToString();
                model.SubjectName = rows["SubjectName"].ToString();
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
