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
    public class GradesRepository : RepositoryBase<Grades>, IGradesRepository
    {
        public override List<Grades> GetAll()
        {
            command.CommandText = "SELECT * FROM Grade";
            return base.GetAll();
        }
        public override List<Grades> GetById(string id)
        {
            command.CommandText = "SELECT * " +
            "FROM Grade " +
            "WHERE GradeId = @GradeId " +
            "Order By GradeName asc";

            command.Parameters.AddWithValue("@GradeId", id);
            return base.GetById(id);
        }

        public override void Save(Grades model)
        {
            command.CommandText = "INSERT INTO Grade(GradeId,GradeName) values" +
                                "(@GradeId,@GradeName);";

            command.Parameters.AddWithValue("@GradeId", model.GradeId);
            command.Parameters.AddWithValue("@GradeName", model.Grade);
            base.Save(model);
        }
        public override void SaveMany(List<Grades> model)
        {
            Delete(model);
            command.CommandText = "INSERT INTO Grade(GradeId,GradeName) values" +
                                "(@GradeId,@GradeName);";
            base.SaveMany(model);
        }
        public override void Update(Grades model)
        {
            command.CommandText = "UPDATE Grade SET GradeId=@GradeId, GradeName=@GradeName " +
                                    "WHERE GradeId = '" + model.oldGradeId + "'";
            command.Parameters.AddWithValue("@GradeId", model.GradeId);
            command.Parameters.AddWithValue("@GradeName", model.Grade);
            base.Update(model);
        }

        public override void Delete(List<Grades> model)
        {
            List<Grades> _model = model.GroupBy(x => x.StudentId).Select(x => x.First()).ToList();
            string userId = "";
            for (int i = 0; i < _model.Count(); i++)
                userId += "'" + _model[i].StudentId + "',";

            userId = userId.Substring(0, userId.LastIndexOf(','));
            command.CommandText = "DELETE FROM Grade WHERE GradeId IN (" + userId + ")";
            base.Delete(_model);
        }

        public override Grades PopulateRecord(SqlDataReader rows)
        {
            try
            {
                Grades model = new Grades();
                model.GradeId = rows["GradeId"].ToString();
                model.Grade = rows["GradeName"].ToString();
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override void command_ExecuteNonQuery(List<Grades> _model)
        {
            foreach (var model in _model)
            {
                try
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("GradeId", model.GradeId);
                    command.Parameters.AddWithValue("@GradeName", model.Grade);
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
