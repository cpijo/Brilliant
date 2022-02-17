using NetcarePortal.Models.Data;
using School.Services.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services.Repository
{
    public delegate bool DelEventHandler();
    public abstract class BaseRepository<T>: IDisposable , IBaseRepository<T> where T : class, new() 
    {
        public static event DelEventHandler Status;

        public SqlCommand command = null;
        public DataTable table = null;
        bool _isSuccess = true;
        public BaseRepository()
        {
            command = new SqlCommand();
            command.CommandText = "";
            table = new DataTable();
        }

        public virtual List<T> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(DataBaseConnectorString.ConnectionString))
            {
                List<T> modelList = new List<T>();
                command.Connection = connection;

                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            T model = null;
                            model = PopulateRecord(reader);

                            modelList.Add(model);
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    connection.Close(); ;
                }
                return modelList;
            }
        }

        public virtual void Save(T model)
        {
            using (SqlConnection connection = new SqlConnection(DataBaseConnectorString.ConnectionString))
            {          
                try
                {
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                    _isSuccess = true;
                }
                catch (Exception ex)
                {
                    _isSuccess = false;

                }
                finally
                {
                    Status += new DelEventHandler(IsSuccess);
                    Status.Invoke();
                    connection.Close();
                }
            }
        }

        public virtual void SaveMany(List<T> model)
        {
            using (SqlConnection connection = new SqlConnection(DataBaseConnectorString.ConnectionString))
            {
                //try
                //{
                //    command.Connection = connection;
                //    connection.Open();
                //    command_ExecuteNonQuery(model);
                //    _isSuccess = true;
                //}



                command.Connection = connection;
                try
                {
                    //connection.Open();
                    command_ExecuteNonQuery(model);
                    _isSuccess = true;
                }
                catch (Exception ex)
                {
                    _isSuccess = false;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public virtual void Update(T model)
        {
            using (SqlConnection connection = new SqlConnection(DataBaseConnectorString.ConnectionString))
            {
                try
                {
                command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    Status += new DelEventHandler(IsSuccess);
                    Status.Invoke();
                    connection.Close();
                }
            }
        }

        public virtual void Delete(List<T> model)
        {
            using (SqlConnection connection = new SqlConnection(DataBaseConnectorString.ConnectionString))
            {
                command.Connection = connection;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    _isSuccess = false;
                }
                finally
                {
                    connection.Close(); ;
                }
            }
        }

        public virtual T PopulateRecord(SqlDataReader reader)
        {
            return null;
        }
        public virtual void command_ExecuteNonQuery(List<T> model)
        {
            command.ExecuteNonQuery();
        }

        public virtual void sqlQueries(dynamic obj)
        {
           
        }



        public virtual List<T> GetById(string id)
        {
            using (SqlConnection connection = new SqlConnection(DataBaseConnectorString.ConnectionString))
            {
                List<T> modelList = new List<T>();
                command.Connection = connection;

                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            T model = null;
                            model = PopulateRecord(reader);

                            modelList.Add(model);
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    connection.Close(); ;
                }
                return modelList;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //context.Dispose();
                }
            }
            this.disposed = true;
        }


        public virtual bool IsSuccess()
        {
            return _isSuccess;
        }

    }
}
