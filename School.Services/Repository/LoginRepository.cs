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
    public class LoginRepository : RepositoryBase<UserLogin>, ILoginRepository
    {
        public override List<UserLogin> GetAll()
        {
            command.CommandText = "SELECT * FROM SchoolBasa.dbo.Login";
            return base.GetAll();
        }

        public override void SaveMany(List<UserLogin> model)
        {
            Delete(model);
            command.CommandText = "INSERT INTO SchoolBasa.dbo.Login(CourseId,StudentId,Grade) values" +
                                "(@CourseId,@StudentId,@Grade);";
            base.SaveMany(model);
        }


        public override void command_ExecuteNonQuery(List<UserLogin> _model)
        {
            foreach (var model in _model)
            {
                try
                {
                    command.Parameters.Clear();
                    //command.Parameters.AddWithValue("CourseId", model.CourseId);
                    //command.Parameters.AddWithValue("@StudentId", model.StudentId);
                    //command.Parameters.AddWithValue("@Grade", model.Grade);
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
