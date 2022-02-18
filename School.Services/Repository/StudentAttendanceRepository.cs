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
    public class StudentAttendanceRepository : BaseRepository<StudentAttendance>, IStudentAttendanceRepository
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
            sqlQueries(obj);
            return base.GetById("");
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


        public override void sqlQueries(dynamic obj)
        {
            string stringDate = "09/11/2022";
            string myformat = "dd/MM/yyyy"; //textbox date format
            DateTime stdate = DateTime.ParseExact(stringDate, myformat, null);

            //OR
            DateTime mydate;
            if (DateTime.TryParse(stringDate, out mydate))
            { }
       
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            dynamic _obj = JObject.Parse(json);
            string jsonString = Convert.ToString(obj); //var obj = { StudentId = "StudentId", GradeId = "GradeI2", queryType = "searchByGrade" }
            string gradeId = _obj.GradeId;
            string subjectId = _obj.SubjectId ?? "0";
            string examDate = _obj.ExamDate ?? "0";
            examDate = examDate.Replace('/', '-');
            string teacherId = _obj.TeacherId ?? "0";
            string type = _obj.type ?? "0";
            string _attendanceDate = _obj.AttendanceDate ?? "0";

            DateTime attendanceDate = new DateTime();
            if (_attendanceDate.Length>7)
            {
                attendanceDate = DateTime.ParseExact(_attendanceDate, myformat, null);
            }
           




            string sql = "";

            switch (type)
            {
                case "start":
                    sql = command.CommandText = "Select sa.StudentId,FirstName,LastName,sa2.GradeId,sa2.SubjectId," +
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

                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@TeacherId", teacherId);
                    command.Parameters.AddWithValue("@GradeId", gradeId);
                    command.Parameters.AddWithValue("@SubjectId", subjectId);

                    break;

                case "markRegister":
                    sql = "Select sa.StudentId,FirstName,LastName,sa2.GradeId,sa2.SubjectId," +
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

                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@TeacherId", teacherId);
                    command.Parameters.AddWithValue("@SubjectId", subjectId);
                    command.Parameters.AddWithValue("@AttendanceDate", attendanceDate);
                    command.Parameters.AddWithValue("@GradeId", gradeId);
                    break;
                case "hasRecords":
                    sql = "Select sa.StudentId,FirstName,LastName,sa2.GradeId,sa2.SubjectId," +
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

                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@TeacherId", teacherId);
                    command.Parameters.AddWithValue("@SubjectId", subjectId);
                    command.Parameters.AddWithValue("@AttendanceDate", attendanceDate);
                    command.Parameters.AddWithValue("@GradeId", gradeId);
                    break;
                default:
                    break;
            }
        }



        //https://code-projects.org/school-management-system-in-php-with-source-code/
        //https://zetcode.com/csharp/sqlserver/
        static void Main(string[] args)
        {
            var cs = @"Server=localhost\SQLEXPRESS;Database=testdb;Trusted_Connection=True;";

            var con = new SqlConnection(cs);
            con.Open();

            var cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "DROP TABLE IF EXISTS cars";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE cars(
                id int identity(1,1) NOT NULL PRIMARY KEY,
                name VARCHAR(255) NOT NULL,
                price INT
            )";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Audi',52642)";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Mercedes',57127)";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Skoda',9000)";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Volvo',29000)";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Bentley',350000)";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Citroen',21000)";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Hummer',41400)";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Volkswagen',21600)";
            cmd.ExecuteNonQuery();

            Console.WriteLine("Table cars created");
        }

    }
}
