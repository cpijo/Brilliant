using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using School.Entities.Fields;
using School.Services.Interface;
using School.Entities.Fields.StudyMaterial;

namespace School.Services.Repository
{
    public class BooksRepository : BaseRepository<Books>, IBooksRepository
    {
        public override List<Books> GetAll()
        {
            command.CommandText = "SELECT * FROM Books";
            return base.GetAll();
        }
        public override List<Books> GetById(string id)
        {
            command.CommandText = "SELECT * " +
            "FROM Grade " +
            "WHERE BookId = @BookId " +
            "Order By BookName asc";

            command.Parameters.AddWithValue("@BookId", id);
            return base.GetById(id);
        }

        public override void Save(Books model)
        {
            command.CommandText = "INSERT INTO Books(GradeId,GradeName) values" +
                                "(@GradeId,@GradeName);";

            command.Parameters.AddWithValue("@GradeId", model.GradeId);
            command.Parameters.AddWithValue("@GradeName", model.BookName);
            base.Save(model);
        }
        public override void SaveMany(List<Books> model)
        {
            Delete(model);
            command.CommandText = "INSERT INTO Grade(GradeId,GradeName) values" +
                                "(@GradeId,@GradeName);";
            base.SaveMany(model);
        }
        public override void Update(Books model)
        {
            command.CommandText = "UPDATE Grade SET GradeId=@GradeId, GradeName=@GradeName " +
                                    "WHERE GradeId = '" + model.BookName + "'";
            command.Parameters.AddWithValue("@GradeId", model.GradeId);
            command.Parameters.AddWithValue("@GradeName", model.BookName);
            base.Update(model);
        }

        public override void Delete(List<Books> model)
        {
            List<Books> _model = model.GroupBy(x => x.BookName).Select(x => x.First()).ToList();
            string userId = "";
            for (int i = 0; i < _model.Count(); i++)
                userId += "'" + _model[i].BookName + "',";

            userId = userId.Substring(0, userId.LastIndexOf(','));
            command.CommandText = "DELETE FROM Grade WHERE GradeId IN (" + userId + ")";
            base.Delete(_model);
        }

        public override Books PopulateRecord(SqlDataReader rows)
        {
            try
            {
                Books model = new Books();
                model.ISBN = rows["ISBN"].ToString();
                model.BookId = rows["BookId"].ToString();
                //model.BookCode = rows["BookCode"].ToString();
                model.BookName = rows["BookName"].ToString();
                model.BookEdition = int.Parse(rows["BookEdition"].ToString());
                model.AuthorId = rows["AuthorId"].ToString();
                model.Author = rows["Author"].ToString();
                model.PublishedDate = DateTime.Parse(rows["PublishedDate"].ToString());
                model.BookType = rows["BookType"].ToString();
                model.Rating = Decimal.Parse(rows["Rating"].ToString());
                model.GradeId = rows["GradeId"].ToString();
                model.GradeName = rows["GradeName"].ToString();
                model.FilePath = rows["FilePath"].ToString();
                model.FileType = rows["FileType"].ToString();
                model.CreatedDate = DateTime.Parse(rows["CreatedDate"].ToString());
                model.UpdatedDate = DateTime.Parse(rows["UpdatedDate"].ToString());

                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override void command_ExecuteNonQuery(List<Books> _model)
        {
            foreach (var model in _model)
            {
                try
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("GradeId", model.GradeId);
                    command.Parameters.AddWithValue("@GradeName", model.BookName);
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
