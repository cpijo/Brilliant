using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using School.Entities.Fields;
using School.Services.Interface;
using Newtonsoft.Json.Linq;

namespace School.Services.Repository
{
    public class StudentAttendanceRepository : BaseRepository<StudentAttendance>, IStudentAttendanceRepository
    {

        public override List<StudentAttendance> GetAll()
        {
            command.CommandText = "SELECT * FROM schoolbd.dbo.SubjectResult";
            return base.GetAll();
        }

        public override List<StudentAttendance> GetById(string id)
        {
             command.CommandText = " Select st.StudentId,FirstName,LastName,sm.GradeId,sm.SubjectId,sm.MarkValue,sm.ExamType " +
                "From StudentTeacher st " +
                "INNER JOIN StudentMarks sm1 ON sm1.StudentId=st.StudentId " +
	            "AND sm1.GradeId='Grade12' " +
                "LEFT JOIN StudentMarks sm ON sm.StudentId=st.StudentId " +
	            "AND sm.ExamType='Q2' AND sm.GradeId='Grade12' " +
                "LEFT JOIN Student u ON u.UserId=st.StudentId;"; 
            return base.GetById(id);
        }

        public List<StudentAttendance> GetByAny(dynamic obj)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            dynamic _obj = JObject.Parse(json);
            string jsonString = Convert.ToString(obj); 
            string gradeId = _obj.GradeId;
            string subject = _obj.subject ?? "0";
            Dictionary<string, string> RaceDictionary = dictSQL();
            string sql = "";
            foreach (KeyValuePair<string, string> item in RaceDictionary)
            {
                if (_obj.queryType == item.Key)
                {
                    sql = item.Value;
                    break;
                }
            }

            command.CommandText = sql;
            command.Parameters.AddWithValue("@GradeId", gradeId);
            return base.GetById(gradeId);
        }

        public override StudentAttendance PopulateRecord(SqlDataReader rows)
        {
            try
            {
                StudentAttendance model = new StudentAttendance();
                model.StudentId = rows["StudentId"].ToString();
                model.FirstName = rows["FirstName"].ToString();
                model.LastName = rows["LastName"].ToString();
                model.GradeId = rows["GradeId"].ToString();
                //model.ExamQuarter = rows["ExamQuarter"].ToString();
                model.SubjectId = rows["SubjectId"].ToString();
                //model.MarkValue = rows["MarkValue"].ToString();
                //model.ExamType = rows["ExamType"].ToString();

                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override void command_ExecuteNonQuery(List<StudentAttendance> _model)
        {
            foreach (var model in _model)
            {
                try
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("SubjectId", model.SubjectId);
                    //command.Parameters.AddWithValue("@SubjectName", model.SubjectName);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
                catch (Exception ex)
                {
                }
            }
        }

        private static Dictionary<string, string> dictSQL()
        {
            string searchAllByTeacher = "SELECT s.UserId,s.Firstname,s.LastName,rg.RegisteredId,g.GradeId,g.GradeName ,m.SubjectId,sb.SubjectName,m.MarkValue " +
           "FROM  Student s " +
           "LEFT JOIN RegisteredGrade rg ON rg.StudentId = @StudentId " +
           "LEFT JOIN Grade g ON g.GradeId = rg.GradeId " +
           "LEFT JOIN StudentMarks m ON m.StudentId = s.UserId " +
           "LEFT JOIN Subject sb ON sb.SubjectId = m.SubjectId " +
           "Order By s.Firstname asc";

            string searchByGrade = "SELECT  s.UserId,s.Firstname,s.LastName,rg.GradeId ,g.GradeId,g.GradeName ,sm.SubjectId,sb.SubjectName,sm.MarkValue " +
            "FROM  Student s  " +
            "INNER JOIN GradeStudent rg  " +
            "ON(  " +
                "rg.StudentId = s.UserId " +
            ") " +
            "INNER JOIN Grade g ON( g.GradeId = rg.GradeId AND g.GradeId=@GradeId ) " +
            "Left JOIN StudentMarks sm ON sm.StudentId = s.UserId " +
            "Left JOIN Subject sb ON sb.SubjectId = sm.SubjectId";

            string searchByGradeAndName = "SELECT  s.UserId,s.Firstname,s.LastName,rg.GradeId ,g.GradeId,g.GradeName ,sm.SubjectId,sb.SubjectName,sm.MarkValue " +
            "FROM  Student s " +
            "INNER JOIN Users u ON(s.LastName= u.LastName AND u.LastName LIKE '%' + @LastName+'%' ) " +
            "INNER JOIN GradeStudent rg  " +
            "ON(  " +
                "rg.StudentId = s.UserId " +
            ") " +
            "INNER JOIN Grade g ON( g.GradeId = rg.GradeId AND g.GradeId=@GradeId ) " +
            "Left JOIN StudentMarks sm ON sm.StudentId = s.UserId " +
            "Left JOIN Subject sb ON sb.SubjectId = sm.SubjectId";


            string searchByTeacherAndGrade = "SELECT  s.UserId,s.Firstname,s.LastName,rg.GradeId ,g.GradeId,g.GradeName ,sm.SubjectId,sb.SubjectName,sm.MarkValue " +
            "FROM  Student s " +
            "INNER JOIN Users u ON(s.LastName= u.LastName AND u.LastName LIKE'%Malu%' ) 	" +
            "INNER JOIN GradeStudent rg  " +
            "ON(  " +
                "rg.StudentId = s.UserId " +
             "AND " +
                "rg.StudentId = @StudentId " +
            ") " +
            "INNER JOIN Grade g ON( g.GradeId = rg.GradeId AND g.GradeId=@GradeId ) " +
            "Left JOIN StudentMarks sm ON sm.StudentId = s.UserId " +
            "Left JOIN Subject sb ON sb.SubjectId = sm.SubjectId";


            Dictionary<string, string> lst = new Dictionary<string, string>();

            lst.Add("searchAllByTeacher", searchAllByTeacher);
            lst.Add("searchByGrade", searchByGrade);
            lst.Add("searchByGradeAndName", searchByGradeAndName);
            lst.Add("searchByTeacherAndGrade", searchByTeacherAndGrade);

            return lst;
        }


    }
}
