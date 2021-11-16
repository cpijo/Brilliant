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
    public class UserRolesRepository : BaseRepository<UserRoles>, IUserRolesRepository
    {

        public override List<UserRoles> GetById(string userId)
        {

            command.CommandText = "SELECT r.RoleID,r.RoleName FROM Roles r " +
                    "INNER JOIN UserRoles u ON u.RoleID = r.RoleID " +
                    "AND u.UserId = @UserId";

            command.Parameters.AddWithValue("@UserId", userId);
            return base.GetById(userId);
        }

        public override UserRoles PopulateRecord(SqlDataReader rows)
        {
            try
            {
                UserRoles model = new UserRoles();
                model.RoleID = int.Parse(rows["RoleID"].ToString());
                model.UserId = rows["UserId"].ToString();
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override void command_ExecuteNonQuery(List<UserRoles> _model)
        {
            foreach (var model in _model)
            {
                try
                {
                    var _sos = model.RoleID;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@UserId", model.UserId);
                    command.Parameters.AddWithValue("RoleID", model.RoleID);
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

        public override void SaveMany(List<UserRoles> _model)
        {
            if (_model==null ||_model.Count > 0)
            {
              Delete(_model);
            }
            command.CommandText = "INSERT INTO UserRoles(UserId,RoleID) values(@UserId, @RoleID)";
            base.SaveMany(_model);
        }

        public override void Delete(List<UserRoles> model)
        {
            string userId = model[0].UserId;
            command.CommandText = "DELETE FROM UserRoles WHERE UserId='" + userId + "'";
            base.Delete(model);
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
