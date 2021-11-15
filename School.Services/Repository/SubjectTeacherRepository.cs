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
    public class SubjectTeacherRepository : BaseRepository<Subject>, ISubjectTeacherRepository
    {

        public override List<Subject> GetAll()
        {
            command.CommandText = "SELECT * FROM SchoolBasa.dbo.Subject";
            return base.GetAll();
        }

        public override List<Subject> GetById(string id)
        {

            //            id = "1111";

            /*
            Private Function ShowTotalCount()
    Dim rdr As SqlDataReader
    Dim cmd As SqlCommand = Nothing
    Dim totcount As Integer = 0
    Dim CommandText As String = "SELECT
    (SELECT COUNT(*) FROM [dbo].[MyDownTime]) as count_mydowntime,
    (SELECT COUNT(*) FROM [dbo].[MyDownTime]) as count_mydowntime,
    (SELECT COUNT(*) FROM [dbo].[MyOutput]) as count_myoutput,
    (SELECT COUNT(*) FROM [dbo].[MySpeed]) as count_myspeed,
    (SELECT COUNT(*) FROM [dbo].[MyTemperature]) as count_mytemperature,
    (SELECT COUNT(*) FROM [dbo].[MyUtility]) as count_myutility"
        objlocalconn.Open()
        cmd = New SqlCommand(CommandText, objlocalconn)
        cmd.CommandType = CommandType.Text
        rdr = cmd.ExecuteReader()
        If rdr.HasRows Then
            Do While rdr.Read()
                Console.WriteLine("{0} - {1}", rdr["count_mydowntime"], Convert.ToInt32(rdr.GetValue(0)))
    Loop
        End If
End Function

            */


            //     command.CommandText = "SELECT s.StudentId,s.Firstname,s.LastName,s.Email,c.CourseId,rc.RegisteredId,c.CourseName " +
            //"FROM  schoolbd.dbo.Student s " +
            //"LEFT JOIN schoolbd.dbo.RegisteredCourse rc ON rc.StudentId = s.StudentId " +
            //"LEFT JOIN schoolbd.dbo.Course c ON c.CourseId = rc.CourseId " +
            //"Order By s.LastName asc ";







            string sql = "SELECT * FROM SchoolBasa.dbo.Grade " +
                     "WHERE GradeId in " +
                        "(SELECT GradeId " +
                          "FROM SchoolBasa.dbo.GradeTeacher " +
                            "WHERE TeacherId=@TeacherId" +
                               ")";

            
            sql ="SELECT * FROM Subject s " +
                    "WHERE SubjectId IN ( " +
			        "SELECT SubjectId FROM Teaching WHERE TeacherId = 'TC00000001' " +
			        ")";

    
            command.CommandText = sql;







            command.Parameters.AddWithValue("@TeacherId", id);

            return base.GetById(id);
        }
        public override void Save(Subject model)
        {
            command.CommandText = "INSERT INTO schoolbd.dbo.Subject(SubjectId,SubjectName) values" +
                                    "(@SubjectId,@SubjectName);";
            base.Save(model);
        }
        public override void SaveMany(List<Subject> model)
        {
            Delete(model);
            command.CommandText = "INSERT INTO schoolbd.dbo.Subject(SubjectId,SubjectName) values" +
                                    "(@SubjectId,@SubjectName);";
            base.SaveMany(model);
        }
        public override void Delete(List<Subject> model)
        {
            List<Subject> _model = model.GroupBy(x => x.SubjectId).Select(x => x.First()).ToList();
            string coursId = "";
            for (int i = 0; i < _model.Count(); i++)
                coursId += "'" + _model[i].SubjectId + "',";

            coursId = coursId.Substring(0, coursId.LastIndexOf(','));
            command.CommandText = "DELETE FROM SchoolBasa.dbo.Courses WHERE SubjectId IN (" + coursId + ")";
            base.Delete(_model);
        }

        public override Subject PopulateRecord(SqlDataReader rows)
        {
            try
            {
                Subject model = new Subject();
                model.SubjectId = rows["SubjectId"].ToString();
                model.SubjectName = rows["SubjectName"].ToString();


                //model.SubjectId = rows.GetString(8);
                //model.SubjectName = rows.GetString(9);

                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override void command_ExecuteNonQuery(List<Subject> _model)
        {
            foreach (var model in _model)
            {
                try
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("SubjectId", model.SubjectId);
                    command.Parameters.AddWithValue("@SubjectName", model.SubjectName);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
                catch (Exception ex)
                {
                }
            }
        }

        public List<Subject> GetById(string teacherId, string gradeId)
        {
            string sql = "SELECT * FROM Subject s " +
                    "WHERE SubjectId IN ( " +
                    "SELECT SubjectId FROM Teaching WHERE TeacherId = @TeacherId " +
                    ")";

            teacherId = "TC00000001";
            command.CommandText = sql;
            command.Parameters.AddWithValue("@TeacherId", teacherId);

            return base.GetById(teacherId);
        }
    }
}
