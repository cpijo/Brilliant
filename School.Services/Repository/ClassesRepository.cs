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
    public class ClassesRepository : BaseRepository<Classes>, IClassesRepository
    {
        public override List<Classes> GetAll()
        {
            command.CommandText = "SELECT * FROM Class";
            return base.GetAll();
        }
        public override List<Classes> GetById(string id)
        {
            command.CommandText = "SELECT * " +
            "FROM Class " +
            "WHERE ClassId = @ClassId " +
            "Order By GradeName asc";

            command.Parameters.AddWithValue("@GradeId", id);
            return base.GetById(id);
        }

        public override void Save(Classes model)
        {
            command.CommandText = "INSERT INTO Class(ClassId,ClassName) values" +
                                "(@ClassId,@ClassName);";

            //command.Parameters.AddWithValue("@GradeId", model.GradeId);
            //command.Parameters.AddWithValue("@GradeName", model.Grade);
            base.Save(model);
        }
        public override void SaveMany(List<Classes> model)
        {
            Delete(model);
            command.CommandText = "INSERT INTO Class(ClassId,ClassName) values" +
                                "(@ClassId,@ClassName);";
            base.SaveMany(model);
        }
        public override void Update(Classes model)
        {
            //command.CommandText = "UPDATE Grade SET GradeId=@ClassId, ClassName=@ClassName " +
            //                        "WHERE ClassId = '" + model.oldGradeId + "'";
            //command.Parameters.AddWithValue("@ClassId", model.ClassId);
            //command.Parameters.AddWithValue("@ClassName", model.ClassName);
            base.Update(model);
        }

        public override void Delete(List<Classes> model)
        {
            //List<Classes> _model = model.GroupBy(x => x.StudentId).Select(x => x.First()).ToList();
            //string userId = "";
            //for (int i = 0; i < _model.Count(); i++)
            //    userId += "'" + _model[i].StudentId + "',";

            //userId = userId.Substring(0, userId.LastIndexOf(','));
            //command.CommandText = "DELETE FROM Grade WHERE GradeId IN (" + userId + ")";
            base.Delete(model);
        }

        public override Classes PopulateRecord(SqlDataReader rows)
        {
            try
            {
                Classes model = new Classes();
                model.ClassId = rows["ClassId"].ToString();
                model.ClassName = rows["ClassName"].ToString();
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override void command_ExecuteNonQuery(List<Classes> _model)
        {
            foreach (var model in _model)
            {
                try
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("ClassId", model.ClassId);
                    command.Parameters.AddWithValue("@ClassName", model.ClassName);
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


/*SELECT TOP 1000 [GradeId]
      ,[ClassId]
      ,[GradeName]
  FROM [schooldb].[dbo].[GradeClass]*/
