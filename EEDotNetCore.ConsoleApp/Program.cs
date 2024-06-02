// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.Intrinsics.Arm;
using System.Data;
using EEDotNetCore.ConsoleApp;
Console.WriteLine("Hello, World!");

//Ctrl +    . => Suggestion
//F10   => one line after one line
//F11   
//F9 BreakPoint
// => C# + Db

/*SqlConnectionStringBuilder  stringBuilder = new SqlConnectionStringBuilder();
stringBuilder.DataSource = ".";  //sever name
stringBuilder.InitialCatalog = "EEDotNetCore"; //database name
stringBuilder.UserID = "sa";
stringBuilder.Password = "edp@123";
SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);   
//SqlConnection   connection=new SqlConnection("Data Source =.; Initial Catalog = EEDotNetCore; User ID = sa; Password = edp@123");
connection.Open();
Console.WriteLine("Connection Open.");

string query = "select * from Tbl_blog";
SqlCommand cmd = new SqlCommand(query, connection);
SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//datatable
DataTable dt = new DataTable();
adapter.Fill(dt);

connection.Close();
Console.WriteLine("Connection Close.");

// dataset => datatable
//datatable => datarow
//datarow => datacolumn
foreach (DataRow dr in dt.Rows)
{
    Console.WriteLine("Blog ID =>" + dr["BlogId"]);
    Console.WriteLine("Blog Title =>" + dr["BlogTitle"]);
    Console.WriteLine("Blog Author =>" + dr["BlogAuthor"]);
    Console.WriteLine("Blog Content =>" + dr["BlogContent"]);
    Console.WriteLine("-----------------------");

}*/

// finished Ado.Net Read

AdoDotNetExample    ado=new AdoDotNetExample();
//ado.Read();
//ado.Create("title","author","content");
//ado.Update(12, "Test Title", "Test Author", "Test Content");
//ado.Delete(12);
ado.Edit(12);
ado.Edit(1);


Console.ReadKey(); 