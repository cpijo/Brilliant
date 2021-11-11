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
    public class SubjectResultRepository : RepositoryBase<SubjectResult>, ISubjectResultRepository
    {

        public override List<SubjectResult> GetAll()
        {
            command.CommandText = "SELECT * FROM schoolbd.dbo.SubjectResult";
            return base.GetAll();
        }

        public override List<SubjectResult> GetById(string id)
        {
            command.CommandText = "SELECT s.UserId,s.Firstname,s.LastName,rg.RegisteredId,g.GradeId,g.GradeName ,m.SubjectId,sb.SubjectName,m.MarkValue " +
                    "FROM  Student s " +
                    "INNER JOIN RegisteredGrade rg ON ( rg.StudentId = s.UserId AND s.UserId = @StudentId ) " +
                    "INNER JOIN Grade g ON g.GradeId = rg.GradeId " +
                    "INNER JOIN StudentMarks m ON m.StudentId = s.UserId " +
                    "INNER JOIN Subject sb ON sb.SubjectId = m.SubjectId " +
                    "Order By sb.SubjectName asc";
            command.Parameters.AddWithValue("@StudentId", id);
            return base.GetById(id);
        }
        public override void Save(SubjectResult model)
        {
            command.CommandText = "INSERT INTO schoolbd.dbo.SubjectResult(SubjectId,SubjectName) values" +
                                    "(@SubjectId,@SubjectName);";
            base.Save(model);
        }
        public override void SaveMany(List<SubjectResult> model)
        {
            Delete(model);
            command.CommandText = "INSERT INTO schoolbd.dbo.SubjectResult(SubjectId,SubjectName) values" +
                                    "(@SubjectId,@SubjectName);";
            base.SaveMany(model);
        }

        public override void Update(SubjectResult model)
        {
            command.CommandText = "UPDATE SubjectResult SET SubjectId=@SubjectId,SubjectName=@SubjectName,Marks=@Marks," +
                                    "Symbol=@Symbol,StudentId=@StudentId WHERE StudentId = @StudentId AND  SubjectId = @SubjectId";

            command.CommandText = "UPDATE SubjectResult SET SubjectName=@SubjectName,Marks=@Marks," +
                                "Symbol=@Symbol WHERE StudentId = @StudentId AND SubjectId = @SubjectId";

            command.Parameters.AddWithValue("@StudentId", model.StudentId);
            command.Parameters.AddWithValue("@SubjectId", model.SubjectId);
            command.Parameters.AddWithValue("@SubjectName", model.SubjectName);
            command.Parameters.AddWithValue("@Marks", model.Marks);
            command.Parameters.AddWithValue("@Symbol", model.Symbol);

            base.Update(model);
        }
        public override void Delete(List<SubjectResult> model)
        {
            List<SubjectResult> _model = model.GroupBy(x => x.SubjectId).Select(x => x.First()).ToList();
            string coursId = "";
            for (int i = 0; i < _model.Count(); i++)
                coursId += "'" + _model[i].SubjectId + "',";

            coursId = coursId.Substring(0, coursId.LastIndexOf(','));
            command.CommandText = "DELETE FROM schoolbd.dbo.SubjectResult WHERE SubjectId IN (" + coursId + ")";
            base.Delete(_model);
        }

        public override SubjectResult PopulateRecord(SqlDataReader rows)
        {
            try
            {
                //"SELECT s.StudentId,s.Firstname,s.LastName,s.Email,s.DateOfBirth,rc.RegisteredId,c.CourseName,sr.SubjectId ,sr.SubjectName,sr.Marks ,sr.Symbol "

                SubjectResult model = new SubjectResult();

                //model.StudentId = rows.GetString(0);
                //model.SubjectId = rows.GetString(7);
                //model.SubjectName = rows.GetString(8);
                //model.Marks = rows.GetString(9);
                //model.Symbol = rows.GetString(10);


                model.SubjectId = rows["SubjectId"].ToString();
                model.SubjectName = rows["SubjectName"].ToString();
                model.Marks = rows["MarkValue"].ToString();
                //model.Symbol = rows["Symbol"].ToString();
                model.StudentId = rows["UserId"].ToString();

                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override void command_ExecuteNonQuery(List<SubjectResult> _model)
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
