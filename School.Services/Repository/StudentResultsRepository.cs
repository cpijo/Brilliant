using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using School.Entities.Fields;
using School.Services.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace School.Services.Repository
{
    public class StudentResultsRepository : RepositoryBase<StudentResults>, IStudentResultsRepository
    {
        public override List<StudentResults> GetAll()
        {
            command.CommandText = "SELECT s.UserId,s.Firstname,s.LastName,rg.RegisteredId,g.GradeId,g.GradeName " +
            "FROM  Student s " +
            "INNER JOIN RegisteredGrade rg ON rg.StudentId = s.UserId " +
            "INNER JOIN Grade g ON g.GradeId = rg.GradeId " +
            "Order By s.LastName asc ";
            return base.GetAll();
        }

        public override List<StudentResults> GetById(string id)
        {
            command.CommandText = "SELECT s.UserId,s.Firstname,s.LastName,rg.RegisteredId,g.GradeId,g.GradeName ,m.SubjectId,sb.SubjectName,m.MarkValue " +
            "FROM  Student s " +
            "LEFT JOIN RegisteredGrade rg ON rg.StudentId = @StudentId " +
            "LEFT JOIN Grade g ON g.GradeId = rg.GradeId " +
            "LEFT JOIN StudentMarks m ON m.StudentId = s.UserId " +
            "LEFT JOIN Subject sb ON sb.SubjectId = m.SubjectId " +
            "Order By s.Firstname asc";

            command.Parameters.AddWithValue("@StudentId", id);
            return base.GetById(id);
        }

        public List<StudentResults> GetByAny(dynamic obj)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            dynamic _obj = JObject.Parse(json);
            string gradeId = _obj.GradeId;
            string lastName = _obj.studentName ?? "0";
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
            if (lastName != "0")
            {
                lastName = _obj.studentName;
                command.Parameters.AddWithValue("@LastName", lastName);
            }
            return base.GetById(gradeId);
        }

        public override void SaveMany(List<StudentResults> _model)
        {
            Delete(_model);
            command.CommandText = "INSERT INTO CollegeDB.dbo.StudentResults(StudentId,Firstname,Surname,CourseId,CourseName,Grade) values" +
                                    "(@StudentId,@Firstname,@Surname,@CourseId,@CourseName,@Grade)";
            base.SaveMany(_model);
        }

        public override void Delete(List<StudentResults> model)
        {
            List<StudentResults> _model = model.GroupBy(x => x.StudentId).Select(x => x.First()).ToList();
            string userId = "";
            for (int i = 0; i < _model.Count(); i++)
                userId += "'" + _model[i].StudentId + "',";

            userId = userId.Substring(0, userId.LastIndexOf(','));
            command.CommandText = "DELETE FROM CollegeDB.dbo.StudentResults WHERE StudentId IN (" + userId + ")";
            base.Delete(_model);
        }

        public override StudentResults PopulateRecord(SqlDataReader rows)
        {
            try
            {
                StudentResults model = new StudentResults();
                model.StudentId = rows["UserId"].ToString();
                model.Firstname = rows["Firstname"].ToString();
                model.LastName = rows["LastName"].ToString();
                model.GradeId = rows["GradeId"].ToString();
                model.GradeName = rows["GradeName"].ToString();
                if (rows.FieldCount > 6)
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

        public override void command_ExecuteNonQuery(List<StudentResults> _model)
        {
            foreach (var model in _model)
            {
                try
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("StudentId", model.StudentId);
                    command.Parameters.AddWithValue("@Firstname", model.Firstname);
                    command.Parameters.AddWithValue("@LastName", model.LastName);
                    command.Parameters.AddWithValue("CourseId", model.CourseId);
                    command.Parameters.AddWithValue("@CourseName", model.CourseName);
                    command.Parameters.AddWithValue("@RegisteredId", model.RegisteredId);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
                catch (Exception ex)
                {
                }
            }
        }

        private List<StudentResults> _StudentResults = new List<StudentResults>();
        public List<StudentResults> GetResults
        {
            get { return _StudentResults; }
            set { _StudentResults = value; }
        }
        public List<StudentResults> GetStundentsResults()
        {
            command.CommandText = "SELECT s.StudentId,s.Firstname,s.Surname,c.CourseId,c.CourseName,g.Grade " +
                               "FROM  CollegeDB.dbo.Student s " +
                               "INNER JOIN  CollegeDB.dbo.Grades g ON g.StudentId = s.StudentId " +
                               "INNER JOIN  CollegeDB.dbo.Courses c ON c.CourseId = g.CourseId " +
                               "Order By s.Surname asc ";

            command.CommandText = "SELECT s.StudentId,s.Firstname,s.LastName,s.Email,c.CourseId,rc.RegisteredId,c.CourseName " +
                   "FROM  schoolbd.dbo.Student s " +
                   "INNER JOIN schoolbd.dbo.RegisteredCourse rc ON rc.StudentId = s.StudentId " +
                   "INNER JOIN schoolbd.dbo.Course c ON c.CourseId = rc.CourseId " +
                   "Order By s.LastName asc ";

            return base.GetAll();
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

            string searchByGrade = "SELECT  s.UserId,s.Firstname,s.LastName,rg.GradeId ,g.GradeName " +
            "FROM  Student s  " +
            "INNER JOIN GradeStudent rg  " +
            "ON(  " +
                "rg.StudentId = s.UserId AND rg.GradeId=@GradeId " +
            ") " +
            "INNER JOIN Grade g ON( g.GradeId = rg.GradeId AND g.GradeId=@GradeId ) ";
            //"INNER JOIN StudentMarks sm ON sm.StudentId = s.UserId " +
            //"INNER JOIN Subject sb ON sb.SubjectId = sm.SubjectId";

            string searchByGrade_1 = "SELECT  s.UserId,s.Firstname,s.LastName,rg.GradeId ,g.GradeId,g.GradeName ,sm.SubjectId,sb.SubjectName,sm.MarkValue " +
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
            "INNER JOIN Student u ON(s.LastName= u.LastName AND u.LastName LIKE '%' + @LastName+'%' ) " +
            "INNER JOIN GradeStudent rg  " +
            "ON(  " +
                "rg.StudentId = s.UserId " +
            ") " +
            "INNER JOIN Grade g ON( g.GradeId = rg.GradeId AND g.GradeId=@GradeId ) " +
            "Left JOIN StudentMarks sm ON sm.StudentId = s.UserId " +
            "Left JOIN Subject sb ON sb.SubjectId = sm.SubjectId";

            string searchByTeacherAndGrade = "SELECT  s.UserId,s.Firstname,s.LastName,rg.GradeId ,g.GradeId,g.GradeName ,sm.SubjectId,sb.SubjectName,sm.MarkValue " +
            "FROM  Student s " +
            "INNER JOIN Student u ON(s.LastName= u.LastName AND u.LastName LIKE'%Malu%' ) 	" +
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
