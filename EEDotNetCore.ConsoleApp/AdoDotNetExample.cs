using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace EEDotNetCore.ConsoleApp
{
    internal class AdoDotNetExample
    {
        private readonly SqlConnectionStringBuilder _sql = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "EEDotNetCore",
            UserID = "sa",
            Password = "edp@123"

        };

        public void Read()
        {
            
            SqlConnection connection = new SqlConnection(_sql.ConnectionString);
            
            connection.Open();
            Console.WriteLine("Connection Open.");

            string query = "select * from Tbl_blog";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
    
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();
            Console.WriteLine("Connection Close.");

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("Blog ID =>" + dr["BlogId"]);
                Console.WriteLine("Blog Title =>" + dr["BlogTitle"]);
                Console.WriteLine("Blog Author =>" + dr["BlogAuthor"]);
                Console.WriteLine("Blog Content =>" + dr["BlogContent"]);
                Console.WriteLine("-----------------------");

            }
        }
        public void Edit(int id)
        {
            SqlConnection connection = new SqlConnection(_sql.ConnectionString);

            connection.Open();
            ;

            string query = "select * from Tbl_blog where BlogId =@BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);  
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();
            if(dt.Rows.Count == 0)
            {
                Console.WriteLine("No data found.");
                return;
            }
            DataRow dr = dt.Rows[0];
           
                Console.WriteLine("Blog ID =>" + dr["BlogId"]);
                Console.WriteLine("Blog Title =>" + dr["BlogTitle"]);
                Console.WriteLine("Blog Author =>" + dr["BlogAuthor"]);
                Console.WriteLine("Blog Content =>" + dr["BlogContent"]);
                Console.WriteLine("-----------------------");

            
        }
        public void Create(string title, string author, string content)
        {
            SqlConnection connection = new SqlConnection(_sql.ConnectionString);

            connection.Open();

            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle,
           @BlogAuthor,
		   @BlogContent)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BlogTitle", title);
            command.Parameters.AddWithValue("@BlogAuthor", author);
            command.Parameters.AddWithValue("@BlogContent", content);
            int result=command.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "saving successful." : "saving failed.";

            Console.WriteLine(message);
        }

        public void Update(int id,string title, string author, string content)
        {
            SqlConnection connection = new SqlConnection(_sql.ConnectionString);

            connection.Open();

            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId=@BlogId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BlogId",id);
            command.Parameters.AddWithValue("@BlogTitle", title);
            command.Parameters.AddWithValue("@BlogAuthor", author);
            command.Parameters.AddWithValue("@BlogContent", content);
            int result = command.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Update successful." : "Update failed.";

            Console.WriteLine(message);
        }

        public void Delete(int id)
        {
            SqlConnection connection = new SqlConnection(_sql.ConnectionString);

            connection.Open();

            string query = "delete from Tbl_Blog where BlogId=@BlogId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BlogId", id);
            int result = command.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Delete successful." : "Delete failed.";

            Console.WriteLine(message);
        }
    }

    
}
