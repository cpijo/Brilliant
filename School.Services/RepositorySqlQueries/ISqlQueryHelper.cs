using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services.RepositorySqlQueries
{
    public interface ISqlQueryHelper
    {
        void sqlQueries(dynamic obj);
    }
}
