//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data;
//using School.Entities.Fields;
//using School.Services.Interface;
//using Newtonsoft.Json.Linq;

//namespace School.Services.Repository
//{
//    public class StudentSubjectMarksRepository : RepositoryBase<StudentSubjectMarks>, IStudentSubjectMarksRepository
//    {

//        public override List<StudentSubjectMarks> GetAll()
//        {
//            command.CommandText = "SELECT * FROM schoolbd.dbo.SubjectResult";
//            return base.GetAll();
//        }

//        public override List<StudentSubjectMarks> GetById(string id)
//        {
//             //command.CommandText = " s.UserId,s.Firstname,s.LastName FROM  Student s " +
//             //   "WHERE UserId in( " +
//             //   "SELECT st.StudentId From StudentTeacher st " +
//             //   "WHERE st.StudentId in( " +
//             //   "SELECT StudentId from StudentMarks Where GradeId='Grade8' and SubjectId='Eng008' " +
//             //    ") " +
//             //   "AND TeacherId='TC00000008';";

//            command.CommandText = " s.UserId,s.Firstname,s.LastName FROM  Student s " +
//            "WHERE UserId in( " +
//            "SELECT st.StudentId From StudentTeacher st " +
//            "WHERE st.StudentId in( " +
//            "SELECT StudentId from StudentMarks Where GradeId='Grade8' and SubjectId='Eng008' " +
//             ") " +
//            "AND TeacherId='TC00000008';";
//            return base.GetById(id);
//        }


//        public List<StudentSubjectMarks> GetByAny(dynamic obj)
//        {
//            string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
//            dynamic _obj = JObject.Parse(json);
//            string jsonString = Convert.ToString(obj); //var obj = { StudentId = "StudentId", GradeId = "GradeI2", queryType = "searchByGrade" }
//            string SubjectId = _obj.SubjectId;
//            string GradeId = _obj.GradeId;
//            string TeacherId = _obj.TeacherId;
//            TeacherId = "TC00000008";
//            string isStart = _obj.isStart;

//            if (isStart != "0")
//            { }

//            command.CommandText = "SELECT s.UserId,s.Firstname,s.LastName FROM  Student s " +
//            "WHERE UserId in( " +
//            "SELECT st.StudentId From StudentTeacher st " +
//            "WHERE st.StudentId in( " +
//            "SELECT StudentId from StudentMarks Where GradeId=@GradeId and SubjectId=@SubjectId " +
//             ") " +
//            "AND TeacherId=@TeacherId )";
//            //ex = {"Incorrect syntax near ','.\r\nIncorrect syntax near '@TeacherId'."}
//            command.Parameters.AddWithValue("@TeacherId",TeacherId);
//            command.Parameters.AddWithValue("@GradeId",  GradeId);
//            command.Parameters.AddWithValue("@SubjectId",SubjectId);

//            return base.GetById("");
//        }


//        //public List<StudentSubjectMarks> GetByModel(StudentSubjectMarks model)
//        //{
//        //    command.CommandText = " s.UserId,s.Firstname,s.LastName FROM  Student s " +
//        //    "WHERE UserId in( " +
//        //    "SELECT st.StudentId From StudentTeacher st " +
//        //    "WHERE st.StudentId in( " +
//        //    "SELECT StudentId from StudentMarks Where GradeId=@GradeId and SubjectId=@SubjectId " +
//        //     ") " +
//        //    "AND TeacherId=@TeacherId;";

//        //    command.Parameters.AddWithValue("@TeacherId", model.SubjectId);
//        //    command.Parameters.AddWithValue("@GradeId", model.GradeId);
//        //    command.Parameters.AddWithValue("@SubjectId", model.SubjectId);

//        //    return base.GetById("");
//        //}









//        //public List<StudentSubjectMarks> GetByAny(dynamic obj)
//        //{
//        //    string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
//        //    dynamic _obj = JObject.Parse(json);
//        //    string jsonString = Convert.ToString(obj); //var obj = { StudentId = "StudentId", GradeId = "GradeI2", queryType = "searchByGrade" }
//        //    string gradeId = _obj.GradeId;
//        //    string lastName = _obj.studentName ?? "0";
//        //    Dictionary<string, string> RaceDictionary = dictSQL();
//        //    string sql = "";

//        //    foreach (KeyValuePair<string, string> item in RaceDictionary)
//        //    {
//        //        if (_obj.queryType == item.Key)
//        //        {
//        //            sql = item.Value;
//        //            break;
//        //        }
//        //    }

//        //    command.CommandText = sql;
//        //    command.Parameters.AddWithValue("@GradeId", gradeId);
//        //    if (lastName != "0")
//        //    {
//        //        lastName = _obj.studentName;
//        //        command.Parameters.AddWithValue("@LastName", lastName);
//        //    }

//        //    if (true)
//        //    {

//        //    }

//        //    return base.GetById(gradeId);
//        //}

//        public override void SaveMany(List<StudentSubjectMarks> model)
//        {
//            command.CommandText = "INSERT INTO StudentMarks(StudentId,GradeId,ExamType,SubjectId,MarkValue,ExamDate) values" +
//                                "(@StudentId,@GradeId,@ExamType,@SubjectId,@MarkValue,@ExamDate) ";
//            base.SaveMany(model);
//        }


//        public override StudentSubjectMarks PopulateRecord(SqlDataReader rows)
//        {
//            try
//            {
//                StudentSubjectMarks model = new StudentSubjectMarks();
//                model.StudentId = rows["UserId"].ToString();
//                model.FirstName = rows["Firstname"].ToString();
//                model.LastName = rows["LastName"].ToString();
//                if (rows.FieldCount > 5)
//                {
//                    model.SubjectId = rows["SubjectId"].ToString();
//                    model.SubjectName = rows["SubjectName"].ToString();
//                    model.MarkValue = rows["MarkValue"].ToString();
//                }



//                //model.StudentId = rows["StudentId"].ToString();
//                //model.FirstName = rows["FirstName"].ToString();
//                //model.LastName = rows["LastName"].ToString();
//                //model.GradeId = rows["GradeId"].ToString();
//                ////model.ExamQuarter = rows["ExamQuarter"].ToString();
//                //model.SubjectId = rows["SubjectId"].ToString();
//                //model.MarkValue = rows["MarkValue"].ToString();
//                //model.ExamType = rows["ExamType"].ToString();

//                return model;
//            }
//            catch (Exception ex)
//            {
//                throw;
//            }
//        }

//        public override void command_ExecuteNonQuery(List<StudentSubjectMarks> _model)
//        {
//            foreach (var model in _model)
//            {
//                try
//                {
//                    command.Parameters.Clear();
//                    command.Parameters.AddWithValue("StudentId", model.StudentId);
//                    command.Parameters.AddWithValue("GradeId", model.GradeId);
//                    command.Parameters.AddWithValue("ExamType", model.ExamType);
//                    command.Parameters.AddWithValue("SubjectId", model.SubjectId);
//                    command.Parameters.AddWithValue("MarkValue", model.MarkValue);
//                    command.Parameters.AddWithValue("ExamDate", model.ExamDate);
//                    command.Connection.Open();
//                    command.ExecuteNonQuery();
//                    command.Connection.Close();
//                }
//                catch (Exception ex)
//                {
//                }
//            }
//        }


//        private static void newCommand(string type)
//        {


//        }

//        public override void sqlQueries(dynamic obj)
//        {
//            // _dynamic.type = "hasRecords";
//            string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
//            dynamic _obj = JObject.Parse(json);
//            string jsonString = Convert.ToString(obj); //var obj = { StudentId = "StudentId", GradeId = "GradeI2", queryType = "searchByGrade" }
//            string SubjectId = _obj.SubjectId;
//            string GradeId = _obj.GradeId;
//            string TeacherId = _obj.TeacherId; TeacherId = "TC00000008";         
//            string isStart = _obj.isStart;
//            string type = _obj.type ?? "0";
//            string sql = "";
//            switch (type)
//            {
//                case "existingRecords":
//                    sql = "SELECT s.UserId,s.Firstname,s.LastName FROM  Student s " +
//                    "WHERE UserId in( " +
//                    "SELECT st.StudentId From StudentTeacher st " +
//                    "WHERE st.StudentId in( " +
//                    "SELECT StudentId from StudentMarks Where GradeId=@GradeId and SubjectId=@SubjectId " +
//                     ") " +
//                    "AND TeacherId=@TeacherId )";
//                    command.CommandText = sql;
//                    command.Parameters.AddWithValue("@TeacherId", TeacherId);
//                    command.Parameters.AddWithValue("@GradeId", GradeId);
//                    command.Parameters.AddWithValue("@SubjectId", SubjectId);

//                    break;
//                case "hasRecords":
//                    sql = "SELECT s.UserId,s.Firstname,s.LastName FROM  Student s " +
//                    "WHERE UserId in( " +
//                    "SELECT st.StudentId From StudentTeacher st " +
//                    "WHERE st.StudentId in( " +
//                    "SELECT StudentId from StudentMarks Where GradeId=@GradeId and SubjectId=@SubjectId " +
//                     ") " +
//                    "AND TeacherId=@TeacherId )";
//                    break;
//                case "3":
//                    sql = "SELECT s.UserId,s.Firstname,s.LastName FROM  Student s " +
//                    "WHERE UserId in( " +
//                    "SELECT st.StudentId From StudentTeacher st " +
//                    "WHERE st.StudentId in( " +
//                    "SELECT StudentId from StudentMarks Where GradeId=@GradeId and SubjectId=@SubjectId " +
//                     ") " +
//                    "AND TeacherId=@TeacherId )";

//                    break;
//                default:
//                    break;
//            }




//        }





















//        /*

//            private static Dictionary<string, string> dictSQL()
//        {
//            //https://stackoverflow.com/questions/54127494/why-use-reactjs-with-asp-net-core-mvc

//            string searchAllByTeacher = "SELECT s.UserId,s.Firstname,s.LastName,rg.RegisteredId,g.GradeId,g.GradeName ,m.SubjectId,sb.SubjectName,m.MarkValue " +
//           "FROM  Student s " +
//           "LEFT JOIN RegisteredGrade rg ON rg.StudentId = @StudentId " +
//           "LEFT JOIN Grade g ON g.GradeId = rg.GradeId " +
//           "LEFT JOIN StudentMarks m ON m.StudentId = s.UserId " +
//           "LEFT JOIN Subject sb ON sb.SubjectId = m.SubjectId " +
//           "Order By s.Firstname asc";

//            string searchByGrade = "SELECT  s.UserId,s.Firstname,s.LastName,rg.GradeId ,g.GradeId,g.GradeName ,sm.SubjectId,sb.SubjectName,sm.MarkValue " +
//            "FROM  Student s  " +
//            "INNER JOIN GradeStudent rg  " +
//            "ON(  " +
//                "rg.StudentId = s.UserId " +
//            ") " +
//            "INNER JOIN Grade g ON( g.GradeId = rg.GradeId AND g.GradeId=@GradeId ) " +
//            "Left JOIN StudentMarks sm ON sm.StudentId = s.UserId " +
//            "Left JOIN Subject sb ON sb.SubjectId = sm.SubjectId";

//            string searchByGradeAndName = "SELECT  s.UserId,s.Firstname,s.LastName,rg.GradeId ,g.GradeId,g.GradeName ,sm.SubjectId,sb.SubjectName,sm.MarkValue " +
//            "FROM  Student s " +
//            "INNER JOIN Users u ON(s.LastName= u.LastName AND u.LastName LIKE '%' + @LastName+'%' ) " +
//            "INNER JOIN GradeStudent rg  " +
//            "ON(  " +
//                "rg.StudentId = s.UserId " +
//            ") " +
//            "INNER JOIN Grade g ON( g.GradeId = rg.GradeId AND g.GradeId=@GradeId ) " +
//            "Left JOIN StudentMarks sm ON sm.StudentId = s.UserId " +
//            "Left JOIN Subject sb ON sb.SubjectId = sm.SubjectId";


//            string searchByTeacherAndGrade = "SELECT  s.UserId,s.Firstname,s.LastName,rg.GradeId ,g.GradeId,g.GradeName ,sm.SubjectId,sb.SubjectName,sm.MarkValue " +
//            "FROM  Student s " +
//            "INNER JOIN Student u ON(s.LastName= u.LastName AND u.LastName LIKE'%Malu%' ) 	" +
//            "INNER JOIN GradeStudent rg  " +
//            "ON(  " +
//                "rg.StudentId = s.UserId " +
//             "AND " +
//                "rg.StudentId = @StudentId " +
//            ") " +
//            "INNER JOIN Grade g ON( g.GradeId = rg.GradeId AND g.GradeId=@GradeId ) " +
//            "Left JOIN StudentMarks sm ON sm.StudentId = s.UserId " +
//            "Left JOIN Subject sb ON sb.SubjectId = sm.SubjectId";


//            Dictionary<string, string> lst = new Dictionary<string, string>();

//            lst.Add("searchAllByTeacher", searchAllByTeacher);
//            lst.Add("searchByGrade", searchByGrade);
//            lst.Add("searchByGradeAndName", searchByGradeAndName);
//            lst.Add("searchByTeacherAndGrade", searchByTeacherAndGrade);

//            return lst;
//        }

//        */
//    }
//}




/***** Script for SelectTopNRows command from   
 * 


Use schooldb

SELECT UserName
      , FirstName
      , LastName INTO #TempLocationCol FROM Student
GO
SELECT* FROM #TempLocationCol where FirstName LIKE 'All%'


SELECT sub.*
  FROM (
        SELECT*
          FROM student
         WHERE UserType != 'Friday'


        UNION
                 SELECT *
          FROM Teacher
         WHERE UserType != 'Friday'
       ) sub


--https://mode.com/sql-tutorial/sql-sub-queries/

SELECT sub.*
  FROM (
        SELECT FirstName 'Student Name',
        CASE UserType

        WHEN 'A' THEN 'Excellent'

        WHEN 'B' THEN 'Good'

        WHEN 'C' THEN 'Average'

        WHEN 'D' THEN 'Poor'

        WHEN 'F' THEN 'Fail'

        ELSE 'ST'

        END 'userType'
          FROM student
         WHERE UserType != 'Friday'


        UNION
            SELECT FirstName 'Student Name',
        CASE UserType

        WHEN 'A' THEN 'Excellent'

        WHEN 'B' THEN 'Good'

        WHEN 'C' THEN 'Average'

        WHEN 'D' THEN 'Poor'

        WHEN 'F' THEN 'Fail'

        ELSE 'ST'

        END 'userType'
          FROM Teacher
         WHERE UserType != 'Friday'
       ) sub




SELECT sub.*
  FROM(
        SELECT UserName, [Password], FirstName 'Student Name',
        CASE UserType

        WHEN 'A' THEN 'Excellent'

        WHEN 'B' THEN 'Good'

        WHEN 'C' THEN 'Average'

        WHEN 'D' THEN 'Poor'

        WHEN 'F' THEN 'Fail'

        ELSE 'Student'

        END 'userType'
          FROM student
         WHERE UserType != 'Friday'


        UNION
            SELECT UserName, [Password], FirstName 'Student Name',
        CASE UserType

        WHEN 'A' THEN 'Excellent'

        WHEN 'B' THEN 'Good'

        WHEN 'C' THEN 'Average'

        WHEN 'D' THEN 'Poor'

        WHEN 'F' THEN 'Fail'

        ELSE 'Teacher'

        END 'userType'
          FROM Teacher
         WHERE UserType != 'Friday'
       ) sub

       WHERE sub.userType='Teacher'
	   AND sub.UserName='TC00000008'
	   AND sub.Password= 'C69DA0293EBC7A8E9F5F4F8974B64809BD21F874'











SELECT FirstName 'Student Name',
CASE UserType
WHEN 'A' THEN 'Excellent'
WHEN 'B' THEN 'Good'
WHEN 'C' THEN 'Average'
WHEN 'D' THEN 'Poor'
WHEN 'F' THEN 'Fail'
ELSE 'ST'
END 'userType'
FROM student

UNION ALL

SELECT FirstName 'Student Name',
CASE UserType
WHEN 'A' THEN 'Excellent'
WHEN 'B' THEN 'Good'
WHEN 'C' THEN 'Average'
WHEN 'D' THEN 'Poor'
WHEN 'F' THEN 'Fail'
ELSE 'TC'
END 'userType'
FROM Teacher





SELECT FirstName 'Student Name',
CASE UserType
WHEN 'A' THEN 'Excellent'
WHEN 'B' THEN 'Good'
WHEN 'C' THEN 'Average'
WHEN 'D' THEN 'Poor'
WHEN 'F' THEN 'Fail'
ELSE 'ST'
END 'userType'
FROM student

UNION ALL

SELECT FirstName 'Student Name',
CASE UserType
WHEN 'A' THEN 'Excellent'
WHEN 'B' THEN 'Good'
WHEN 'C' THEN 'Average'
WHEN 'D' THEN 'Poor'
WHEN 'F' THEN 'Fail'
ELSE 'TC'
END 'userType'
FROM Teacher








*/