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
    public class LoginRepository : BaseRepository<UserLogin>, ILoginRepository
    {

        public List<UserLogin> GetByAny(dynamic obj)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            dynamic _obj = JObject.Parse(json);
            string jsonString = Convert.ToString(obj);
            string userName = _obj.userName;
            string password = _obj.password ?? "0";

            string sql = "SELECT * From Teacher " +
             " WHERE UserName=@UserName AND Password=@Password";
            command.CommandText = sql;
            command.Parameters.AddWithValue("@UserName", userName);
            command.Parameters.AddWithValue("@Password", password);
            return base.GetById("");
        }

        public override UserLogin PopulateRecord(SqlDataReader rows)
        {
            try
            {
                UserLogin model = new UserLogin();
                model.UserId = rows["UserId"].ToString();
                model.Username = rows["UserName"].ToString();
                model.Password = rows["Password"].ToString();
                model.Name = rows["FirstName"].ToString();
                model.Surname = rows["LastName"].ToString();
                model.userType = rows["UserType"].ToString();

                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public override List<UserLogin> GetAll()
        {
            command.CommandText = " SELECT sub.* " +
                         "FROM ( " +
                               "SELECT * " +
                                 "FROM student " +
                                "WHERE UserType != 'Friday' " +
                               "UNION " +
                                    "SELECT * " +
                                 "FROM Teacher " +
                                "WHERE UserType != 'Friday' " +
                              ") sub ";


            command.CommandText = " SELECT sub.* " +
                                     "FROM ( " +
                                           "SELECT UserId,UserName 'Username',Password,FirstName 'Name',LastName 'Surname', " +
                                             "FROM student " +
                                            "WHERE UserType != 'Friday' " +
                                           "UNION " +
                                                "SELECT UserId,UserName 'Username',Password,FirstName 'Name',LastName 'Surname', " +
                                             "FROM Teacher " +
                                            "WHERE UserType != 'Friday' " +
                                          ") sub ";

            return base.GetAll();


            /*SELECT UserName
      ,FirstName
      ,LastName INTO #TempLocationCol FROM Student
        GO
        SELECT * FROM #TempLocationCol where FirstName LIKE 'All%'
        
        
        SELECT sub.*
          FROM (
                SELECT *
                  FROM student
                 WHERE UserType != 'Friday'
        
        		UNION
        		         SELECT *
                  FROM Teacher
                 WHERE UserType != 'Friday'
               ) sub*/


            /*
SELECT sub.*
  FROM (
        SELECT UserName,[Password],FirstName 'Student Name',
		CASE UserType
		WHEN 'A' THEN 'Excellent'
		WHEN 'B' THEN 'Good'
		WHEN 'C' THEN 'Average'
		WHEN 'D' THEN 'Poor'
		WHEN 'F' THEN 'Fail'
		ELSE 'Student'
		END 'userType'
          FROM student
         WHERE UserType != 'Friday'

		UNION
		    SELECT UserName,[Password],FirstName 'Student Name',
		CASE UserType
		WHEN 'A' THEN 'Excellent'
		WHEN 'B' THEN 'Good'
		WHEN 'C' THEN 'Average'
		WHEN 'D' THEN 'Poor'
		WHEN 'F' THEN 'Fail'
		ELSE 'Teacher'
		END 'userType'
          FROM Teacher
         WHERE UserType != 'Friday'
       ) sub

	   WHERE sub.userType='Teacher'
	   AND sub.UserName='TC00000008'
	   AND sub.Password='7507239F3C3EB689DB85A29151C0CF5BB5F4A1FD'
       
             
             
        //this will create a new table called  tmpAllUsers with all data from two tables    
     SELECT * INTO tmpAllUsers FROM (

  SELECT top 100 * 

  FROM Student

  UNION All

  SELECT top 100 * 

  FROM Teacher  
) as tmp

SELECT * from tmpAllUsers where UserType ='admin';        
             
             
             
             
             */
        }

        public override List<UserLogin> GetById(string id)
        {
            command.CommandText = "SELECT sub.*" +
           " FROM (" +
           " SELECT UserId,UserName 'Username',Password,FirstName 'Name',LastName 'Surname'," +
           " CASE UserType" +
           " WHEN 'NULL' THEN 'Excellent'" +
           " WHEN '' THEN 'Good'" +
           " ELSE 'Student'" +
           " END 'userType'" +
           " FROM student" +
           " WHERE UserType != 'novalue'" +

           " UNION" +

          " SELECT UserId,UserName 'Username',Password,FirstName 'Name',LastName 'Surname'," +
           " CASE UserType" +
           " WHEN 'NULL' THEN 'Excellent'" +
           " WHEN '' THEN 'Good'" +
           " ELSE 'Teacher'" +
           " END 'userType'" +
           " FROM Teacher" +
           " WHERE UserType != 'novalue'" +
           " ) sub" +
           " WHERE sub.UserName=@UserName" +
           " AND sub.Password=@Password";

            return base.GetById(id);
        }




        public List<UserLogin> Mess_GetByAny(dynamic obj)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            dynamic _obj = JObject.Parse(json);
            string jsonString = Convert.ToString(obj);
            string userName = _obj.userName;
            string password = _obj.password ?? "0";

            string sql = "SELECT sub.*" +
          " FROM (" +
          " SELECT UserId,UserName 'Username',Password,FirstName 'Name',LastName 'Surname'," +
          " CASE UserType" +
          " WHEN 'NULL' THEN 'unknown'" +
          " WHEN '' THEN 'Student'" +
          " ELSE 'Student'" +
          " END 'userType'" +
          " FROM student" +
          " WHERE UserType != 'novalue'" +

          " UNION" +

         " SELECT UserId,UserName 'Username',Password,FirstName 'Name',LastName 'Surname'," +
          " CASE UserType" +
          " WHEN 'NULL' THEN 'Excellent'" +
          " WHEN '' THEN 'Teacher'" +
          " ELSE 'Teacher'" +
          " END 'userType'" +
          " FROM Teacher" +
          " WHERE UserType != 'novalue'" +
          " ) sub" +
          " WHERE sub.UserName=@UserName" +
          " AND sub.Password=@Password";


            command.CommandText = sql;
            command.Parameters.AddWithValue("@UserName", userName);
            command.Parameters.AddWithValue("@Password", password);
            return base.GetById("");



            /*
             SELECT * INTO tmpAllUsers FROM (

  SELECT top 100 * 

  FROM Student

  UNION All

  SELECT top 100 * 

  FROM Teacher  
) as tmp

SELECT * from tmpAllUsers where UserType ='admin';*/
        }

    }
}
