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
    public class GradeClassRepository : BaseRepository<GradeClass>, IGradeClassRepository
    {

        public override List<GradeClass> GetAll()
        {
            command.CommandText = "SELECT * FROM GradeClass";
            command.CommandText = "Select g.GradeId,g.ClassId,g.GradeName,c.ClassName From GradeClass g " + 
                                    "LEFT JOIN Class c ON c.ClassId =g.ClassId";
            return base.GetAll();
        }

        public override GradeClass PopulateRecord(SqlDataReader rows)
        {
            try
            {
                GradeClass model = new GradeClass();
                model.GradeId = rows["GradeId"].ToString();
                model.ClassId = rows["ClassId"].ToString();
                model.GradeName = rows["GradeName"].ToString();
                model.ClassName = rows["ClassName"].ToString();
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
