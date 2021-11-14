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
    public class TeacherRegisterRepository : RepositoryBase<Teacher>, ITeacherRegisterRepository
    {

        public override List<Teacher> GetAll()
        {
            command.CommandText = "SELECT * FROM Teacher";
            return base.GetAll();
        }

        public override void Save(Teacher model)
        {
            command.CommandText = "INSERT INTO Teacher(StudentId,Firstname,LastName,Email,DateOfBirth) values" +
                                    "(@StudentId,@Firstname,@LastName,@Email,@DateOfBirth);";

            command.Parameters.AddWithValue("@TeacherId", model.TeacherId);
            command.Parameters.AddWithValue("@Firstname", model.Firstname);
            command.Parameters.AddWithValue("@LastName", model.LastName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Email", model.Email);
            command.Parameters.AddWithValue("@DateOfBirth", model.DateOfBirth ?? (object)DBNull.Value);
            base.Save(model);
        }

        public override Teacher PopulateRecord(SqlDataReader rows)
        {
            try
            {
                Teacher model = new Teacher();
                model.TeacherId = rows["UserID"].ToString();
                model.Firstname = rows["Firstname"].ToString();
                model.LastName = rows["LastName"].ToString();
                model.UserName = rows["UserName"].ToString();
                model.Age = rows["Age"].ToString();
                model.Gender = rows["Gender"].ToString();
                model.Language = rows["Languages"].ToString();
                model.CreatedDate = DateTime.Parse(rows["CreatedDate"].ToString());
                model.UpdatedDate = DateTime.Parse(rows["UpdatedDate"].ToString());

                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override void command_ExecuteNonQuery(List<Teacher> _model)
        {
            foreach (var model in _model)
            {
                try
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@UserID", model.TeacherId);
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

        public List<Teacher> GetByAny(dynamic obj)
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
                    sql = "SELECT * FROM Teacher";
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
