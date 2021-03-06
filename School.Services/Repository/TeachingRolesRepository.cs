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
    public class TeachingRolesRepository : BaseRepository<TeachingRoles>, ITeachingRolesRepository
    {
        public override List<TeachingRoles> GetById(string userId)
        {

            command.CommandText = "SELECT r.RoleID,r.RoleName FROM Roles r " +
                    "INNER JOIN UserRoles u ON u.RoleID = r.RoleID " +
                    "AND u.UserId = @UserId";

            command.Parameters.AddWithValue("@UserId", userId);
            return base.GetById(userId);
        }
        public override void SaveMany(List<TeachingRoles> _model)
        {
            if (_model == null || _model.Count > 0)
            {
               // Delete(_model);
            }
            command.CommandText = "INSERT INTO Teaching(TeacherId,SubjectId,ClassId,GradeId) values(@TeacherId,@SubjectId,@ClassId,@GradeId)";
            base.SaveMany(_model);
        }

        public override void Delete(List<TeachingRoles> model)
        {
            string userId = model[0].TeacherId;
            command.CommandText = "DELETE FROM Teaching WHERE Teaching='" + userId + "'";
            base.Delete(model);


            /*
            DELETE FROM Teaching   
            WHERE TeacherId IN   
            (SELECT TeacherId   
            FROM Teaching   
            WHERE TeacherId ='TC00000008'
	        AND GradeId='Grade008'
	        );  
            */
        }

        public override TeachingRoles PopulateRecord(SqlDataReader rows)
        {
            try
            {
                TeachingRoles model = new TeachingRoles();
                model.TeacherId = rows["TeacherId"].ToString();
                model.SubjectId = rows["SubjectId"].ToString();
                model.ClassId = rows["ClassId"].ToString();
                model.GradeId = rows["GradeId"].ToString();
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override void command_ExecuteNonQuery(List<TeachingRoles> _model)
        {
            foreach (var model in _model)
            {
                try
                {
                  
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@TeacherId", model.TeacherId);
                    command.Parameters.AddWithValue("SubjectId", model.SubjectId);
                    command.Parameters.AddWithValue("@ClassId", model.ClassId);
                    command.Parameters.AddWithValue("GradeId", model.GradeId);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
                catch (Exception ex)
                {
                    //ex = {"The connection was not closed. The connection's current state is open."}
                }
            }
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
                    sql = "SELECT r.RoleID,r.RoleName FROM Roles r" +
                   "INNER JOIN UserRoles u ON u.RoleID = r.RoleID " +
                   "AND u.UserID = @UserID";
                    break;

                case "byId":
                    sql = "SELECT r.RoleID,r.RoleName FROM Roles r" +
                    "INNER JOIN UserRoles u ON u.RoleID = r.RoleID " +
                    "AND u.UserID = @UserID";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@GradeId", searchValue);
                    break;
                case "byUsername":
                    sql = "SELECT r.RoleID,r.RoleName FROM Roles r" +
                    "INNER JOIN UserRoles u ON u.RoleID = r.RoleID " +
                    "AND u.UserID = @UserID";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@Gender", searchValue);
                    break;
                case "byEmail":
                    sql = "SELECT r.RoleID,r.RoleName FROM Roles r" +
                    "INNER JOIN UserRoles u ON u.RoleID = r.RoleID " +
                    "AND u.UserID = @UserID";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@LastName", searchValue);
                    break;
                case "byUsernameAndPassword":
                    sql = "SELECT r.RoleID,r.RoleName FROM Roles r" +
                    "INNER JOIN UserRoles u ON u.RoleID = r.RoleID " +
                    "AND u.UserID = @UserID";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@LastName", searchValue);
                    command.Parameters.AddWithValue("@LastName", searchValue);
                    break;
                case "byEmailAndPassword":
                    sql = "SELECT r.RoleID,r.RoleName FROM Roles r" +
                   "INNER JOIN UserRoles u ON u.RoleID = r.RoleID " +
                   "AND u.UserID = @UserID";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@LastName", searchValue);
                    command.Parameters.AddWithValue("@LastName", searchValue);
                    break;
                default:
                    break;
            }
        }
    }



}
