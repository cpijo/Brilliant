using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Common.CreateClassFromDatabase
{
    class Class2
    {
    }


    public static class DataSetGenerator
    {
        public static DataSet Priests()
        {
            DataTable priestsDataTable = new DataTable();
            priestsDataTable.Columns.Add(new DataColumn()
            {
                ColumnName = "first_name",
                DataType = typeof(string)
            });
            priestsDataTable.Columns.Add(new DataColumn()
            {
                ColumnName = "last_name",
                DataType = typeof(string)
            });
            priestsDataTable.Columns.Add(new DataColumn()
            {
                ColumnName = "dob",
                DataType = typeof(DateTime)
            });
            priestsDataTable.Columns.Add(new DataColumn()
            {
                ColumnName = "job_title",
                DataType = typeof(string)
            });
            priestsDataTable.Columns.Add(new DataColumn()
            {
                ColumnName = "taken_name",
                DataType = typeof(string)
            });
            priestsDataTable.Columns.Add(new DataColumn()
            {
                ColumnName = "is_american",
                DataType = typeof(string)
            });

            priestsDataTable.Rows.Add(new object[] { "Lenny", "Belardo", new DateTime(1971, 3, 24), "Pontiff", "Pius XIII", "yes" });
            priestsDataTable.Rows.Add(new object[] { "Angelo", "Voiello", new DateTime(1952, 11, 18), "Cardinal Secretary of State", "", "no" });
            priestsDataTable.Rows.Add(new object[] { "Michael", "Spencer", new DateTime(1942, 5, 12), "Archbishop of New York", "", "yes" });
            priestsDataTable.Rows.Add(new object[] { "Sofia", "(Unknown)", new DateTime(1974, 7, 2), "Director of Marketing", "", "no" });
            priestsDataTable.Rows.Add(new object[] { "Bernardo", "Gutierrez", new DateTime(1966, 9, 16), "Master of Ceremonies", "", "no" });

            DataSet priestsDataSet = new DataSet();
            priestsDataSet.Tables.Add(priestsDataTable);

            return priestsDataSet;
        }

        public static DataSet Ranchers()
        {
            DataTable ranchersTable = new DataTable();
            ranchersTable.Columns.Add(new DataColumn()
            {
                ColumnName = "firstName",
                DataType = typeof(string)
            });
            ranchersTable.Columns.Add(new DataColumn()
            {
                ColumnName = "lastName",
                DataType = typeof(string)
            });
            ranchersTable.Columns.Add(new DataColumn()
            {
                ColumnName = "dateOfBirth",
                DataType = typeof(DateTime)
            });
            ranchersTable.Columns.Add(new DataColumn()
            {
                ColumnName = "jobTitle",
                DataType = typeof(string)
            });
            ranchersTable.Columns.Add(new DataColumn()
            {
                ColumnName = "nickName",
                DataType = typeof(string)
            });
            ranchersTable.Columns.Add(new DataColumn()
            {
                ColumnName = "isAmerican",
                DataType = typeof(string)
            });

            ranchersTable.Rows.Add(new object[] { "Colt", "Bennett", new DateTime(1987, 1, 15), "Ranchhand", "", "y" });
            ranchersTable.Rows.Add(new object[] { "Jameson", "Bennett", new DateTime(1984, 10, 10), "Ranchhand", "Rooster", "y" });
            ranchersTable.Rows.Add(new object[] { "Beau", "Bennett", new DateTime(1944, 8, 9), "Rancher", "", "y" });
            ranchersTable.Rows.Add(new object[] { "Margaret", "Bennett", new DateTime(1974, 7, 2), "Bar Owner", "Maggie", "y" });
            ranchersTable.Rows.Add(new object[] { "Abigail", "Phillips", new DateTime(1987, 4, 24), "Teacher", "Abby", "y" });

            DataSet ranchersDataSet = new DataSet();
            ranchersDataSet.Tables.Add(ranchersTable);

            return ranchersDataSet;
        }
    }





    [AttributeUsage(AttributeTargets.Property)]
    public class DataNamesAttribute : Attribute
    {
        protected List<string> _valueNames { get; set; }

        public List<string> ValueNames
        {
            get
            {
                return _valueNames;
            }
            set
            {
                _valueNames = value;
            }
        }

        public DataNamesAttribute()
        {
            _valueNames = new List<string>();
        }

        public DataNamesAttribute(params string[] valueNames)
        {
            _valueNames = valueNames.ToList();
        }
    }




    public class Person
    {
        [DataNames("first_name", "firstName")]
        public string FirstName { get; set; }

        [DataNames("last_name", "lastName")]
        public string LastName { get; set; }

        [DataNames("dob", "dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [DataNames("job_title", "jobTitle")]
        public string JobTitle { get; set; }

        [DataNames("taken_name", "nickName")]
        public string TakenName { get; set; }

        [DataNames("is_american", "isAmerican")]
        public bool IsAmerican { get; set; }
    }


    //https://exceptionnotfound.net/mapping-datatables-and-datarows-to-objects-in-csharp-and-net-using-reflection/
    //Reflection
    public class DataNamesMapper<TEntity> where TEntity : class, new()
    {
        //public TEntity Map(DataRow row) {}
        //public IEnumerable<TEntity> Map(DataTable table) {  }


        public TEntity Map(DataRow row)
        {
            //Step 1 - Get the Column Names
            var columnNames = row.Table.Columns
                                       .Cast<DataColumn>()
                                       .Select(x => x.ColumnName)
                                       .ToList();

            //Step 2 - Get the Property Data Names
            var properties = (typeof(TEntity)).GetProperties()
                                              .Where(x => x.GetCustomAttributes(typeof(DataNamesAttribute), true).Any())
                                              .ToList();

            //Step 3 - Map the data
            TEntity entity = new TEntity();
            foreach (var prop in properties)
            {
               // PropertyMapHelper.Map(typeof(TEntity), row, prop, entity);
            }

            return entity;
        }
    }





public  class Product2
{
    public int? ProductId { get; set; }
    public string ProductName { get; set; }
    public DateTime? IntroductionDate { get; set; }
    public decimal? Cost { get; set; }
    public decimal? Price { get; set; }
    public bool? IsDiscontinued { get; set; }
}

}