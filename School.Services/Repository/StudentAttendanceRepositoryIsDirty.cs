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
using ToolBox.Common;
using ToolBox.Common.Common;

namespace School.Services.Repository
{
    public class StudentAttendanceRepositoryIsDirty : BaseRepository<StudentAttendance>, IStudentAttendanceRepository
    {

        public override List<StudentAttendance> GetAll()
        {
            command.CommandText = "SELECT * FROM schoolbd.dbo.SubjectResult";
            return base.GetAll();
        }

        public override List<StudentAttendance> GetById(string id)
        {
            command.CommandText = "Select st.StudentId,FirstName,LastName,sm.GradeId,sm.SubjectId,sm.MarkValue,sm.ExamType " +
               "From StudentTeacher st " +
               "INNER JOIN StudentMarks sm1 ON sm1.StudentId=st.StudentId " +
               "AND sm1.GradeId='Grade8' AND sm1.SubjectId='Eng008' " +
               "LEFT JOIN StudentMarks sm ON sm.StudentId=st.StudentId " +
               "AND sm.ExamType='Q2' AND sm.GradeId='Grade8' " +
               "LEFT JOIN Student u ON u.UserId=st.StudentId;";

            command.CommandText = "Select sa.StudentId,FirstName,LastName,sa2.GradeId,sa2.SubjectId," +
                "sa2.Attendance,sa2.AttendanceDate,sa2.CreatedDate,sa2.UpdatedDate " +
                "From Student st " +
                "INNER JOIN StudentAttendance sa " +
                "ON sa.StudentId =st.UserId " +
                "AND sa.TeacherId='TC00000008' " +
                "AND sa.SubjectId='Eng008' " +
                "LEFT JOIN StudentAttendance sa2 " +
                "ON sa2.StudentId =st.UserId " +
                "AND sa2.AttendanceDate='09/11/2022' " +
                "Where sa.GradeId='Grade8';";

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
            List<string> propertyList = new List<string>();
            foreach (KeyValuePair<string, string> item in RaceDictionary)
            {
                if (_obj.queryType == item.Key)
                {
                    sql = item.Value;

                    string properties = sql;//@TeacherId
               
                    while (properties.Contains("@"))
                    {
                    int heshPosition = properties.IndexOf('@');
                        string propertiesTemp = properties.Substring(heshPosition).Trim();
                    int spacePosition = propertiesTemp.IndexOf(' ');
                        string propertie = properties.Substring(heshPosition, spacePosition);

                        int _newStart = propertie.Length+ heshPosition;

                        properties = properties.Substring(_newStart).Trim();
                        propertyList.Add(propertie);
                    }

                    break;
                }
            }

            command.CommandText = sql;
            StudentAttendance mod = new StudentAttendance();
            foreach (string prop in propertyList)
            {
                switch (prop)
                {
                    case "@TeacherId":
                        command.Parameters.AddWithValue("@TeacherId", gradeId);
                        break;
                    case "@GradeId":
                        command.Parameters.AddWithValue("@GradeId", gradeId);
                        break;
                    case "@SubjectId":
                        command.Parameters.AddWithValue("@SubjectId", subject);
                        break;
                    case "@AttendanceDate":
                        command.Parameters.AddWithValue("@SubjectId", _obj.AttendanceDate);
                        break;
                    default:
                        Console.WriteLine("Invalid grade");
                        break;
                }
                //command.Parameters.AddWithValue("@GradeId", gradeId);
            }

            //command.Parameters.AddWithValue("@GradeId", gradeId);
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
                model.GradeId = myNullHelper.nullToEmptyString(rows["GradeId"].ToString());
                //model.ExamQuarter = rows["ExamQuarter"].ToString();
                model.SubjectId = myNullHelper.nullToEmptyString(rows["SubjectId"].ToString());
                model.Attendance = myNullHelper.nullToEmptyString(rows["Attendance"].ToString());
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



            string markRegister = "Select sa.StudentId,FirstName,LastName,sa2.GradeId,sa2.SubjectId," +
                                "sa2.Attendance,sa2.AttendanceDate,sa2.CreatedDate,sa2.UpdatedDate " +
                                "From Student st " +
                                "INNER JOIN StudentAttendance sa " +
                                "ON sa.StudentId =st.UserId " +
                                "AND sa.TeacherId=@TeacherId " +
                                "AND sa.SubjectId=@SubjectId " +
                                "LEFT JOIN StudentAttendance sa2 " +
                                "ON sa2.StudentId =st.UserId " +
                                "AND sa2.AttendanceDate=@AttendanceDate " +
                                "Where sa.GradeId=@GradeId ;";


            Dictionary<string, string> lst = new Dictionary<string, string>();

            lst.Add("searchAllByTeacher", searchAllByTeacher);
            lst.Add("searchByGrade", searchByGrade);
            lst.Add("searchByGradeAndName", searchByGradeAndName);
            lst.Add("searchByTeacherAndGrade", searchByTeacherAndGrade);
            lst.Add("markRegister", markRegister);

            return lst;
        }


    }
}
