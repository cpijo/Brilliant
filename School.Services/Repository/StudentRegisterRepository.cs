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
    public class StudentRegisterRepository : RepositoryBase<Student>, IStudentRegisterRepository
    {
        public override List<Student> GetAll()
        {
            command.CommandText = "SELECT * FROM Student";
            return base.GetAll();
        }

        public override void Save(Student model)
        {
            string dateString = model.CreatedDate.ToString("MM/dd/yyyy");
            model.Age = model.Age ?? 0;

            string sql = "INSERT INTO Student(UserId,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate," +
                          "Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType) " +
                        "values(@UserId,@UserName,@FirstName,@LastName,@Age,@Gender,@Race,@Languages,@CreatedDate,@UpdatedDate,'no password','no password',0,0,0,0,'','','','')";

            command.CommandText = sql;
            command.Parameters.AddWithValue("@UserId", model.StudentId);
            command.Parameters.AddWithValue("@UserName", model.StudentId);
            command.Parameters.AddWithValue("@FirstName", model.Firstname);
            command.Parameters.AddWithValue("@LastName", model.LastName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Age", model.Age);
            command.Parameters.AddWithValue("@Gender", model.Gender);
            command.Parameters.AddWithValue("@Race", "not set");
            command.Parameters.AddWithValue("@Languages", model.Language);
            command.Parameters.AddWithValue("@CreatedDate", dateString);
            command.Parameters.AddWithValue("@UpdatedDate", dateString);

            base.Save(model);
        }

        public override Student PopulateRecord(SqlDataReader rows)
        {
            try
            {
                Student model = new Student();
                model.StudentId = rows["UserId"].ToString();
                model.UserName = rows["UserName"].ToString();
                model.Firstname = rows["FirstName"].ToString();
                model.LastName = rows["LastName"].ToString();
                model.Age = int.Parse(rows["Age"].ToString());
                model.Gender = rows["Gender"].ToString();
                model.Language = rows["Languages"].ToString();
                model.UserType = rows["UserType"].ToString();
                model.CreatedDate = DateTime.Parse(rows["CreatedDate"].ToString());
                model.UpdatedDate = DateTime.Parse(rows["UpdatedDate"].ToString());

                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

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

        public List<Student> GetByAny(dynamic obj)
        {
            sqlQueries(obj);
            return base.GetById("");
        }

        public override void sqlQueries(dynamic obj)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            dynamic _obj = JObject.Parse(json);
            string jsonString = Convert.ToString(obj); //var obj = { StudentId = "StudentId", GradeId = "GradeI2", queryType = "searchByGrade" }
            string searchValue = _obj.searchValue;
            string type = _obj.type ?? "0";
            string sql = "";

            switch (type)
            {
                case "all":
                    sql = "SELECT * FROM Student";
                    break;

                case "byGrade":
                    sql = "SELECT * FROM Teacher t " +
                        "INNER JOIN GradeTeacher gt ON t.UserId=gt.TeacherId AND gt.GradeId=@GradeId";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@GradeId", searchValue);
                    break;
                case "byGender":
                    sql = "SELECT * FROM Teacher WHERE Gender=@Gender";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@Gender", searchValue);
                    break;
                case "bySurname":
                    sql = "SELECT * FROM Teacher WHERE LastName LIKE '%' + @LastName+'%' ";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@LastName", searchValue);
                    break;
                default:
                    break;
            }
        }

    }
}
