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
    public class StudentMarksRepository : BaseRepository<StudentSubjectMarks>, IStudentMarksRepository
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
            sqlQueries(obj);
            return base.GetById("");
        }

        public override void Save(StudentSubjectMarks model)
        {
            command.CommandText = "INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue,ExamDate) values" +
                                "(@StudentId,@GradeId,@ExamType,@SubjectId,@MarkValue,@ExamDate) ";

            command.Parameters.AddWithValue("StudentId", model.StudentId);
            command.Parameters.AddWithValue("GradeId", model.GradeId);
            command.Parameters.AddWithValue("ExamType", model.ExamType);
            command.Parameters.AddWithValue("SubjectId", model.SubjectId);
            command.Parameters.AddWithValue("MarkValue", model.MarkValue);
            command.Parameters.AddWithValue("ExamDate", model.ExamDate);
            base.Save(model);
        }


        public override void SaveMany(List<StudentSubjectMarks> model)
        {
            command.CommandText = "INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue,ExamDate) values" +
                                "(@StudentId,@GradeId,@ExamType,@SubjectId,@MarkValue,@ExamDate) ";
            base.SaveMany(model);
        }

        public override void Update(StudentSubjectMarks model)
        {
            //command.CommandText = "UPDATE StudentMarks SET MarkValue=@MarkValue " +
            //        "Symbol=@Symbol WHERE StudentId = @StudentId AND GradeId = @GradeId AND SubjectId = @SubjectId  AND ExamDate = @ExamDate";

            command.CommandText = "UPDATE StudentMarks SET MarkValue=@MarkValue " +
          "WHERE StudentId = @StudentId AND GradeId = @GradeId AND SubjectId = @SubjectId";

            command.Parameters.AddWithValue("@StudentId", model.StudentId);
            command.Parameters.AddWithValue("@GradeId", model.GradeId);
            command.Parameters.AddWithValue("@SubjectId", model.SubjectId);
            command.Parameters.AddWithValue("@MarkValue", model.MarkValue);
            //command.Parameters.AddWithValue("@ExamDate", model.ExamDate);

            base.Update(model);
        }


        public override StudentSubjectMarks PopulateRecord(SqlDataReader rows)
        {
            try
            {
                StudentSubjectMarks model = new StudentSubjectMarks();
                model.StudentId = rows["UserId"].ToString();
                model.FirstName = rows["Firstname"].ToString();
                model.LastName = rows["LastName"].ToString();
                if (rows.FieldCount > 5)
                {
                    model.SubjectId = rows["SubjectId"].ToString();
                    model.SubjectName = rows["SubjectName"].ToString();
                    model.MarkValue = rows["MarkValue"].ToString();
                }
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
                    command.Parameters.AddWithValue("StudentId", model.StudentId);
                    command.Parameters.AddWithValue("GradeId", model.GradeId);
                    command.Parameters.AddWithValue("ExamType", model.ExamType);
                    command.Parameters.AddWithValue("SubjectId", model.SubjectId);
                    command.Parameters.AddWithValue("MarkValue", model.MarkValue);
                    command.Parameters.AddWithValue("ExamDate", model.ExamDate);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
                catch (Exception ex)
                {
                }
            }
        }

        public override void sqlQueries(dynamic obj)
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



        /*
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
*/


    }
}
