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
    public class StudentsRepository : RepositoryBase<Student>, IStudentRepository
    {
        public override List<Student> GetAll()
        {
            command.CommandText = "SELECT * FROM [schooldb].dbo.Student";
            return base.GetAll();
        }

        public List<Student> GetByColumn(string columnName, string columnValue)
        {
            command.CommandText = "SELECT * FROM [SchoolBasa].dbo.Student " +
                "WHERE StudentId in " +
                   "(SELECT StudentId " +
                     "FROM StudentTeacher " +
                       "WHERE TeacherId=@TeacherId" +
                          ")";

            Student mod = new Student { Email = columnValue };
            return base.GetById(columnValue);
        }

        public override void Save(Student model)
        {
            string dateString = model.CreatedDate.ToString("dd/MM/yyyy");

            string sql = "INSERT INTO Student(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,"+
                          "Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType) "+
                        "values(@UserID,@UserName,@FirstName,@LastName,@Age,@Gender,@Race,@Languages,@CreatedDate,@UpdatedDate,'no password','no password',0,0,0,0,'','','','')";

            command.CommandText = sql;
            command.Parameters.AddWithValue("@UserID", model.StudentId);
            command.Parameters.AddWithValue("@UserName", model.StudentId);
            command.Parameters.AddWithValue("@FirstName", model.Firstname);
            command.Parameters.AddWithValue("@LastName", model.LastName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Age", 20);
            command.Parameters.AddWithValue("@Gender", model.Gender);
            command.Parameters.AddWithValue("@Race", "not set");
            command.Parameters.AddWithValue("@Languages", model.Language);
            command.Parameters.AddWithValue("@CreatedDate", dateString);
            command.Parameters.AddWithValue("@UpdatedDate", dateString);

            base.Save(model);
        }

        public override void SaveMany(List<Student> _model)
        {
            Delete(_model);
            command.CommandText = "INSERT INTO schoolbd.dbo.Student(StudentId,Firstname,LastName,Email,DateOfBirth) values" +
                                    "(@StudentId,@Firstname,@LastName,@Email,@DateOfBirth);";
            base.SaveMany(_model);
        }
        public override void Delete(List<Student> model)
        {
            List<Student> _model = model.GroupBy(x => x.StudentId).Select(x => x.First()).ToList();
            string userId = "";
            for (int i = 0; i < _model.Count(); i++)
                userId += "'" + _model[i].StudentId + "',";

            userId = userId.Substring(0, userId.LastIndexOf(','));
            command.CommandText = "DELETE FROM CollegeDB.dbo.Students WHERE StudentId IN (" + userId + ")";
            base.Delete(_model);
        }

        public override Student PopulateRecord(SqlDataReader rows)
        {
            try
            {

                Student model = new Student();
                model.StudentId = rows["UserID"].ToString();
                model.UserName = rows["UserName"].ToString();
                model.Firstname = rows["Firstname"].ToString();
                model.LastName = rows["LastName"].ToString();
                model.Age = int.Parse(rows["Age"].ToString());
                model.Gender = rows["Gender"].ToString();
                model.Language = rows["Languages"].ToString();
                model.UserType = rows["UserType"].ToString();
                model.CreatedDate =DateTime.Parse(rows["CreatedDate"].ToString());
                model.UpdatedDate = DateTime.Parse(rows["UpdatedDate"].ToString());
                //model.EnrollmentDate = DateTime.Parse(rows["EnrollmentDate"].ToString());
                //model.DateOfBirth = rows["DateOfBirth"].ToString();

                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
            //return base.PopulateRecord(reader);
        }

        /*
        public override Student PopulateRecord(SqlDataReader rows)
        {
            try
            {
                Student model1 = new Student();
                model1.StudentId = rows["UserID"].ToString();
                model1.Firstname = rows["Firstname"].ToString();
                model1.LastName = rows["LastName"].ToString();
                //model1.Email = rows["Email"].ToString();
                //model1.DateOfBirth = rows["DateOfBirth"].ToString();

                return model1;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        */

        public override void command_ExecuteNonQuery(List<Student> _model)
        {
            foreach (var model in _model)
            {
                try
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@UserID", model.StudentId);
                    command.Parameters.AddWithValue("@UserName", model.UserName);
                    command.Parameters.AddWithValue("@Firstname", model.Firstname);
                    command.Parameters.AddWithValue("@LastName", model.Surname);
                    command.Parameters.AddWithValue("@Age", model.Age);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    //command.Parameters.AddWithValue("@DateOfBirth", model.DateOfBirth);
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
