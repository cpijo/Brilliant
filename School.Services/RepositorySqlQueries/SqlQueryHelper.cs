using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services.RepositorySqlQueries
{
    public class SqlQueryHelper : ISqlQueryHelper
    {
        public SqlCommand command = null;      
        bool _isSuccess = true;
        public SqlQueryHelper()
        {
            command = new SqlCommand();
            command.CommandText = "";
        }


        public virtual void sqlQueries(dynamic obj)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            dynamic _obj = JObject.Parse(json);
            string jsonString = Convert.ToString(obj); //var obj = { StudentId = "StudentId", GradeId = "GradeI2", queryType = "searchByGrade" }
            string gradeId = _obj.GradeId;
            string subjectId = _obj.SubjectId ?? "0";
            string examDate = _obj.ExamDate ?? "0";
            examDate = examDate.Replace('/', '-');
            string teacherId = _obj.TeacherId ?? "0";
            string type = _obj.type ?? "0";
            string sql = "";

            switch (type)
            {
                case "start":
                    //sql = "SELECT  s.UserId,s.Firstname,s.LastName,sm.GradeId,sm.SubjectId,sb.SubjectName,sm.MarkValue " +
                    //"FROM  Student s " +
                    //"INNER JOIN StudentMarks sm ON( sm.StudentId = s.UserId AND sm.GradeId=@GradeId AND sm.SubjectId=@SubjectId AND ExamDate=@ExamDate ) " +
                    //"Left JOIN Subject sb ON sb.SubjectId = sm.SubjectId";

                    sql = "SELECT s.UserId,s.Firstname,s.LastName FROM  Student s " +
                    "WHERE UserId in( " +
                    "SELECT st.StudentId From StudentTeacher st " +
                    "WHERE st.StudentId in( " +
                    "SELECT StudentId from StudentMarks Where GradeId=@GradeId and SubjectId=@SubjectId " +
                     ") " +
                    "AND TeacherId=@TeacherId )";

                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@TeacherId", teacherId);
                    command.Parameters.AddWithValue("@GradeId", gradeId);
                    command.Parameters.AddWithValue("@SubjectId", subjectId);

                    break;

                case "existingRecords":
                    sql = "SELECT  s.UserId,s.Firstname,s.LastName,sm.GradeId,sm.SubjectId,sb.SubjectName,sm.MarkValue " +
                    "FROM  Student s " +
                    "INNER JOIN StudentMarks sm ON( sm.StudentId = s.UserId AND sm.GradeId=@GradeId AND sm.SubjectId=@SubjectId AND ExamDate=@ExamDate ) " +
                    "Left JOIN Subject sb ON sb.SubjectId = sm.SubjectId";

                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@GradeId", gradeId);
                    command.Parameters.AddWithValue("@SubjectId", subjectId);
                    command.Parameters.AddWithValue("@ExamDate", examDate);
                    break;
                case "hasRecords":
                    sql = "SELECT  s.UserId,s.Firstname,s.LastName,sm.GradeId,sm.SubjectId,sb.SubjectName,sm.MarkValue " +
                    "FROM  Student s " +
                    "INNER JOIN StudentMarks sm ON( sm.StudentId = s.UserId AND sm.GradeId=@GradeId AND sm.SubjectId=@SubjectId AND ExamDate=@ExamDate ) " +
                    "Left JOIN Subject sb ON sb.SubjectId = sm.SubjectId";

                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@GradeId", gradeId);
                    command.Parameters.AddWithValue("@SubjectId", subjectId);
                    command.Parameters.AddWithValue("@ExamDate", examDate);
                    break;
                case "noMarksButHasDate":
                    sql = "SELECT  s.UserId,s.Firstname,s.LastName,sm.GradeId,sm.SubjectId,sb.SubjectName,sm.MarkValue " +
                    "FROM  Student s " +
                    "INNER JOIN StudentMarks sm ON( sm.StudentId = s.UserId AND sm.GradeId=@GradeId AND sm.SubjectId=@SubjectId AND ExamDate=@ExamDate AND sm.MarksValue='') " +
                    "Left JOIN Subject sb ON sb.SubjectId = sm.SubjectId";

                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@GradeId", gradeId);
                    command.Parameters.AddWithValue("@SubjectId", subjectId);
                    command.Parameters.AddWithValue("@ExamDate", examDate);
                    break;
                default:
                    break;
            }
        }

    }

    public class UserSqlQuery: SqlQueryHelper
    {
        public override void sqlQueries(dynamic obj)
        {
            base.sqlQueries(null);   
        }
    }
}
