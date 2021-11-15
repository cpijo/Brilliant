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
    public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
    {

        public override List<Subject> GetAll()
        {
            command.CommandText = "SELECT * FROM Schooldb.dbo.Subject";
            return base.GetAll();
        }

        public override List<Subject> GetById(string id)
        {

            command.CommandText = "SELECT s.UserId,s.Firstname,s.LastName,rg.RegisteredId,g.GradeId,g.GradeName ,m.SubjectId,sb.SubjectName,m.MarkValue " +
                    "FROM  Users s " +
                    "LEFT JOIN RegisteredGrade rg ON rg.StudentId = @StudentId " +
                    "LEFT JOIN Grade g ON g.GradeId = rg.GradeId " +
                    "LEFT JOIN StudentMarks m ON m.StudentId = s.UserId " +
                    "LEFT JOIN Subject sb ON sb.SubjectId = m.SubjectId " +
                    "Order By s.Firstname asc";

            command.Parameters.AddWithValue("@StudentId", id);
            return base.GetById(id);
        }
        public override void Save(Subject model)
        {
            command.CommandText = "INSERT INTO Schooldb.dbo.Subject(SubjectId,SubjectName) values" +
                                    "(@SubjectId,@SubjectName);";

            command.Parameters.AddWithValue("@SubjectId", model.SubjectId);
            command.Parameters.AddWithValue("@SubjectName", model.SubjectName);
            base.Save(model);
        }
        public override void SaveMany(List<Subject> model)
        {
            Delete(model);
            command.CommandText = "INSERT INTO schooldb.dbo.Subject(SubjectId,SubjectName) values" +
                                    "(@SubjectId,@SubjectName);";
            base.SaveMany(model);
        }

        public override void Update(Subject model)
        {
            command.CommandText = "UPDATE Subject SET SubjectId=@SubjectId, SubjectName=@SubjectName " +
                                    "WHERE SubjectId = '"+ model.oldSubjectId + "'";
            command.Parameters.AddWithValue("@SubjectId", model.SubjectId);
            command.Parameters.AddWithValue("@SubjectName", model.SubjectName);
            base.Update(model);
        }

        public override void Delete(List<Subject> model)
        {
            List<Subject> _model = model.GroupBy(x => x.SubjectId).Select(x => x.First()).ToList();
            string coursId = "";
            for (int i = 0; i < _model.Count(); i++)
                coursId += "'" + _model[i].SubjectId + "',";

            coursId = coursId.Substring(0, coursId.LastIndexOf(','));
            command.CommandText = "DELETE FROM schooldb.dbo.Subject WHERE SubjectId IN (" + coursId + ")";
            base.Delete(_model);
        }

        public override Subject PopulateRecord(SqlDataReader rows)
        {
            try
            {
                Subject model = new Subject();
                model.SubjectId = rows["SubjectId"].ToString();
                model.SubjectName = rows["SubjectName"].ToString();


                //model.SubjectId = rows.GetString(8);
                //model.SubjectName = rows.GetString(9);

                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override void command_ExecuteNonQuery(List<Subject> _model)
        {
            foreach (var model in _model)
            {
                try
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("SubjectId", model.SubjectId);
                    command.Parameters.AddWithValue("@SubjectName", model.SubjectName);
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
