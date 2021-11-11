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
    public class StudentMarksRepository : RepositoryBase<StudentSubjectMarks>, IStudentMarksRepository
    {

        public override List<StudentSubjectMarks> GetAll()
        {
            command.CommandText = "SELECT * FROM schoolbd.dbo.SubjectResult";
            return base.GetAll();
        }

        public override List<StudentSubjectMarks> GetById(string id)
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

        public List<StudentSubjectMarks> GetByAny(dynamic obj)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            dynamic _obj = JObject.Parse(json);
            string jsonString = Convert.ToString(obj); //var obj = { StudentId = "StudentId", GradeId = "GradeI2", queryType = "searchByGrade" }
            string gradeId = _obj.GradeId;
            string subjectId = _obj.SubjectId ?? "0";
            string examDate = _obj.ExamDate ?? "0";
            examDate = examDate.Replace('/', '-');

            string sql = "SELECT  s.UserId,s.Firstname,s.LastName,sm.GradeId,sm.SubjectId,sb.SubjectName,sm.MarkValue " +
            "FROM  Student s " +
            "INNER JOIN StudentMarks sm ON( sm.StudentId = s.UserId AND sm.GradeId=@GradeId AND sm.SubjectId=@SubjectId AND ExamDate=@ExamDate ) " +
            "Left JOIN Subject sb ON sb.SubjectId = sm.SubjectId";

            sql = "SELECT  s.UserId,s.Firstname,s.LastName,sm.GradeId,sm.SubjectId,sb.SubjectName,sm.MarkValue " +
            "FROM  Student s " +
            "INNER JOIN StudentMarks sm ON( sm.StudentId = s.UserId AND sm.GradeId=@GradeId AND sm.SubjectId=@SubjectId AND ExamDate=@ExamDate ) " +
            "Left JOIN Subject sb ON sb.SubjectId = sm.SubjectId";

            command.CommandText = sql;
            command.Parameters.AddWithValue("@GradeId", gradeId);
            command.Parameters.AddWithValue("@SubjectId", subjectId);
            command.Parameters.AddWithValue("@ExamDate", examDate);

            return base.GetById(gradeId);
        }


        public override StudentSubjectMarks PopulateRecord(SqlDataReader rows)
        {
            try
            {
                StudentSubjectMarks model = new StudentSubjectMarks();
                model.StudentId = rows["UserId"].ToString();
                model.FirstName = rows["FirstName"].ToString();
                model.LastName = rows["LastName"].ToString();
                model.GradeId = rows["GradeId"].ToString();
                //model.ExamQuarter = rows["ExamQuarter"].ToString();
                model.SubjectId = rows["SubjectId"].ToString();
                model.MarkValue = rows["MarkValue"].ToString();
                //model.ExamType = rows["ExamType"].ToString();

                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override void command_ExecuteNonQuery(List<StudentSubjectMarks> _model)
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
    }
}
