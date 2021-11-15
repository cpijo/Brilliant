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
    public class CoursesRepository : BaseRepository<Course>, ICoursesRepository
    {

        public override List<Course> GetAll()
        {
            command.CommandText = "SELECT * FROM schoolbd.dbo.Course";
            return base.GetAll();
        }
        public override void Save(Course model)
        {
            command.CommandText = "INSERT INTO schoolbd.dbo.Course(CourseId,CourseName) values" +
                                    "(@CourseId,@CourseName);";
            base.Save(model);
        }
        public override void SaveMany(List<Course> model)
        {
            Delete(model);
            command.CommandText = "INSERT INTO schoolbd.dbo.Course(CourseId,CourseName)" +
                                " values(@CourseId,@CourseName);";            
            base.SaveMany(model);
        }
        public override void Delete(List<Course> model)
        {
            List<Course> _model = model.GroupBy(x => x.CourseId).Select(x => x.First()).ToList();
            string coursId = "";
            for (int i = 0; i < _model.Count(); i++)
                coursId += "'" + _model[i].CourseId + "',";

            coursId = coursId.Substring(0, coursId.LastIndexOf(','));
            command.CommandText = "DELETE FROM schoolbd.dbo.Course WHERE CourseId IN (" + coursId + ")";
            base.Delete(_model);
        }

        public override Course PopulateRecord(SqlDataReader rows)
        {
            try
            {
                Course model = new Course();
                model.CourseId = rows["CourseId"].ToString();
                model.CourseName = rows["CourseName"].ToString();
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override void command_ExecuteNonQuery(List<Course> _model)
        {
            foreach (var model in _model)
            {
                try
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("CourseId", model.CourseId);
                    command.Parameters.AddWithValue("@CourseName", model.CourseName);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
                catch (Exception ex)
                {
                }
            }
        }

    }
}
