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
    public class TeacherRepository : RepositoryBase<Teacher>, ITeacherRepository
    {

        public override List<Teacher> GetAll()
        {
            command.CommandText = "SELECT * FROM [schooldb].dbo.Teacher";
            return base.GetAll();
        }

        public override void Save(Teacher model)
        {
            command.CommandText = "INSERT INTO schoolbd.dbo.Student(StudentId,Firstname,LastName,Email,DateOfBirth) values" +
                                    "(@StudentId,@Firstname,@LastName,@Email,@DateOfBirth);";

            command.Parameters.AddWithValue("@TeacherId", model.TeacherId);
            command.Parameters.AddWithValue("@Firstname", model.Firstname);
            command.Parameters.AddWithValue("@LastName", model.LastName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Email", model.Email);
            command.Parameters.AddWithValue("@DateOfBirth", model.DateOfBirth ?? (object)DBNull.Value);
            base.Save(model);
        }

        public override void SaveMany(List<Teacher> _model)
        {
            /*INSERT INTO Teacher(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
             values('TC00000008','TC00000008','Sphiwe','Maluleke',30,'Male','Race','Tsonga','10/19/2021','10/19/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;
            
             
             INSERT INTO Student(UserID,UserName,FirstName,LastName,Age,Gender,Race,Languages,CreatedDate,UpdatedDate,Password,PasswordResetCode,LockoutEnabled,AccessFailedCount,IsLockedOut,IsActive,LastLoginDate,LastLockoutDate,LastSeenDate,UserType)
            values('ST12000006','ST12000006','Cindy12','Golden12',19,'Male','Race','Tsonga','09/11/2021','09/11/2021','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874','C69DA0293EBC7A8E9F5F4F8974B64809BD21F874',0,0,0,0,'','','','') ;

             
             */

            command.CommandText = "INSERT INTO schoolbd.dbo.Student(StudentId,Firstname,LastName,Email,DateOfBirth) values" +
                                    "(@StudentId,@Firstname,@LastName,@Email,@DateOfBirth);";
            base.SaveMany(_model);
        }
        public override void Delete(List<Teacher> model)
        {
            List<Teacher> _model = model.GroupBy(x => x.TeacherId).Select(x => x.First()).ToList();
            string userId = "";
            for (int i = 0; i < _model.Count(); i++)
                userId += "'" + _model[i].TeacherId + "',";

            userId = userId.Substring(0, userId.LastIndexOf(','));
            command.CommandText = "DELETE FROM CollegeDB.dbo.Students WHERE StudentId IN (" + userId + ")";
            base.Delete(_model);
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
                model.Age = int.Parse(rows["Age"].ToString());
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
    }
}
