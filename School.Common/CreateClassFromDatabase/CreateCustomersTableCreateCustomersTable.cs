using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Common.CreateClassFromDatabase
{
    class CreateCustomersTableCreateCustomersTable
    {
        private DataSet dtSet;
        // Create Customers table
        private void CreateCustomersTable()
        {
            // Create a new DataTable.
            DataTable custTable = new DataTable("Customers");
            DataColumn dtColumn;
            DataRow myDataRow;

            // Create id column
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(Int32);
            dtColumn.ColumnName = "id";
            dtColumn.Caption = "Cust ID";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = true;
            // Add column to the DataColumnCollection.
            custTable.Columns.Add(dtColumn);

            // Create Name column.
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "Name";
            dtColumn.Caption = "Cust Name";
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            /// Add column to the DataColumnCollection.
            custTable.Columns.Add(dtColumn);

            // Create Address column.
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "Address";
            dtColumn.Caption = "Address";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            // Add column to the DataColumnCollection.
            custTable.Columns.Add(dtColumn);

            // Make id column the primary key column.
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = custTable.Columns["id"];
            custTable.PrimaryKey = PrimaryKeyColumns;

            // Create a new DataSet
            dtSet = new DataSet();

            // Add custTable to the DataSet.
            dtSet.Tables.Add(custTable);

            // Add data rows to the custTable using NewRow method
            // I add three customers with their addresses, names and ids
            myDataRow = custTable.NewRow();
            myDataRow["id"] = 1001;
            myDataRow["Address"] = "43 Lanewood Road, cito, CA";
            myDataRow["Name"] = "George Bishop";
            custTable.Rows.Add(myDataRow);
            myDataRow = custTable.NewRow();
            myDataRow["id"] = 1002;
            myDataRow["name"] = "Rock joe";
            myDataRow["Address"] = " kind of Prussia, PA";
            custTable.Rows.Add(myDataRow);
            myDataRow = custTable.NewRow();
            myDataRow["id"] = 1003;
            myDataRow["Name"] = "Miranda";
            myDataRow["Address"] = "279 P. Avenue, Bridgetown, PA";
            custTable.Rows.Add(myDataRow);
        }

        // Create Orders table
        private void CreateOrdersTable()
        {
            // Create a DataTable
            DataTable ordersTable = new DataTable("Orders");
            DataColumn dtColumn;
            DataRow dtRow;

            // Create OrderId column
            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.Int32");
            dtColumn.ColumnName = "OrderId";
            dtColumn.AutoIncrement = true;
            dtColumn.Caption = "Order ID";
            dtColumn.ReadOnly = true;
            dtColumn.Unique = true;
            ordersTable.Columns.Add(dtColumn);

            // Create Name column.
            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "Name";
            dtColumn.Caption = "Item Name";
            ordersTable.Columns.Add(dtColumn);

            // Create CustId column which Reprence Cust Id from
            // The cust Table
            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.Int32");
            dtColumn.ColumnName = "CustId";
            dtColumn.AutoIncrement = false;
            dtColumn.Caption = "CustId";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            ordersTable.Columns.Add(dtColumn);

            // Create Description column.
            dtColumn = new DataColumn();
            dtColumn.DataType = Type.GetType("System.String");
            dtColumn.ColumnName = "Description";
            dtColumn.Caption = "DescriptionName";
            ordersTable.Columns.Add(dtColumn);

            // Add ordersTable to DataSet
            dtSet.Tables.Add(ordersTable);

            // ADD two rows to the customer Id 1001
            dtRow = ordersTable.NewRow();
            dtRow["OrderId"] = 0;
            dtRow["Name"] = "ASP Book";
            dtRow["custId"] = 1001;
            dtRow["Description"] = "Same Day";
            ordersTable.Rows.Add(dtRow);
            dtRow = ordersTable.NewRow();
            dtRow["OrderId"] = 1;
            dtRow["Name"] = " C# Book";
            dtRow["custId"] = 1001;
            dtRow["description"] = "2 DAY AIR";
            ordersTable.Rows.Add(dtRow);
            // Add two rows to Customer id 1002
            dtRow = ordersTable.NewRow();
            dtRow["OrderId"] = 2;
            dtRow["Name"] = "Data Quest";
            dtRow["Description"] = "Monthly magazine";
            dtRow["CustId"] = 1002;
            ordersTable.Rows.Add(dtRow);
            dtRow = ordersTable.NewRow();
            dtRow["OrderId"] = 3;
            dtRow["Name"] = "PC Magazine";
            dtRow["Description"] = "Monthly Magazine";
            dtRow["CustId"] = 1003;
            ordersTable.Rows.Add(dtRow);
            // Add two rows to Customer id 1003
            dtRow = ordersTable.NewRow();
            dtRow["OrderId"] = 4;
            dtRow["Name"] = "PCMagazine";
            dtRow["Description"] = "Monthly Magazine";
            dtRow["custId"] = 1003;
            ordersTable.Rows.Add(dtRow);
            dtRow = ordersTable.NewRow();
            dtRow["OrderId"] = 5;
            dtRow["Name"] = "C# Book";
            dtRow["CustId"] = 1003;
            dtRow["Description"] = "2 Day Air ";
            ordersTable.Rows.Add(dtRow);
        }

        // This method creates a customer order relationship and data tables
        // Also displays Customers table data in a DataGridView control
        private void BindData()
        {
            DataRelation dtRelation;
            DataColumn custCol = dtSet.Tables["Customers"].Columns["id"];
            DataColumn orderCol = dtSet.Tables["orders"].Columns["custId"];
            dtRelation = new DataRelation("CustOrderRelation ", custCol, orderCol);
            dtSet.Tables["orders"].ParentRelations.Add(dtRelation);

            //// Create a BindingSource
            //BindingSource bs = new BindingSource();
            //bs.DataSource = dtSet.Tables["Customers"];

            //// Bind data to DataGridView.DataSource
            //dataGridView1.DataSource = bs;
        }

        public void Usege_Form1()
        {

            CreateCustomersTable();
            CreateOrdersTable();
            BindData();
        }

        //https://www.c-sharpcorner.com/UploadFile/mahesh/datatable-in-C-Sharp/
    }
}



/*


    private void ConvertDataReaderToTableManually()
{
    SqlConnection conn = null;
    try
    {
        string connString = ConfigurationManager.ConnectionStrings["NorthwindConn"].ConnectionString;
        conn = new SqlConnection(connString);
        string query = "SELECT * FROM Customers";
        SqlCommand cmd = new SqlCommand(query, conn);
        conn.Open();
 
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        DataTable dtSchema = dr.GetSchemaTable();
        DataTable dt = new DataTable();
        // You can also use an ArrayList instead of List<> 
        List<DataColumn> listCols = new List<DataColumn>();
        if (dtSchema != null)
        {
            foreach (DataRow drow in dtSchema.Rows)
            {
                string columnName = System.Convert.ToString(drow["ColumnName"]);
                DataColumn column = new DataColumn(columnName, (Type)(drow["DataType"]));
                column.Unique = (bool)drow["IsUnique"];
                column.AllowDBNull = (bool)drow["AllowDBNull"];
                column.AutoIncrement = (bool)drow["IsAutoIncrement"];
                listCols.Add(column);
                dt.Columns.Add(column);
            }
 
        }
 
        // Read rows from DataReader and populate the DataTable 
 
        while (dr.Read())
        {
            DataRow dataRow = dt.NewRow();
            for (int i = 0; i < listCols.Count; i++)
            {
                dataRow[((DataColumn)listCols[i])] = dr[i];
            }
 
            dt.Rows.Add(dataRow);
        }
 
        GridView2.DataSource = dt;
        GridView2.DataBind();
    }
 
    catch (SqlException ex)
    {
        // handle error 
    }
 
    catch (Exception ex)
    {
        // handle error 
    }
 
    finally
    {
        conn.Close();
    }
}




                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("FirstColumn\tSecond Column\t\tThird Column\t\tForth Column\t");
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3}",
                            reader[0], reader[1], reader[2], reader[3]));
                    }
                }



@{
var db = Database.Open("SmallBakery"); 
var selectQueryString = "SELECT * FROM Product ORDER BY Name"; 
}
<html> 
<body> 
<h1>Small Bakery Products</h1> 
<table> 
<tr>
<th>Id</th> 
<th>Product</th> 
<th>Description</th> 
<th>Price</th> 
</tr>
@foreach(var row in db.Query(selectQueryString))
{
<tr> 
<td>@row.Id</td> 
<td>@row.Name</td> 
<td>@row.Description</td> 
<td align="right">@row.Price</td> 
</tr> 
}
</table> 
</body> 
</html>




*/
