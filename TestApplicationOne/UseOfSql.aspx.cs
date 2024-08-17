using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace TestApplicationOne
{
	public partial class UseOfSql : System.Web.UI.Page
	{
		SqlConnection conn;
		protected void Page_Load(object sender, EventArgs e)
		{
			string conf = ConfigurationManager.ConnectionStrings["DBconn"].ConnectionString;
			conn = new SqlConnection(conf);
			conn.Open();
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			string Title = TextBox1.Text;
			string Author = TextBox2.Text;
			decimal Price = decimal.Parse(TextBox3.Text);
			int stock = int.Parse(TextBox4.Text);
			string query = $"EXEC AddNewBook {Title}, {Author} ,{Price}, {stock}";
			SqlCommand cmd = new SqlCommand(query, conn);
			SqlDataReader r = cmd.ExecuteReader();
			if (r.HasRows)
			{
				Response.Write("<script>alert('Book Already Exist')</script>");
			}
			else
			{
				Response.Write("<script>alert('Book Added Successfully')</script>");
			}
		}

		protected void Button2_Click(object sender, EventArgs e)
		{
			int id = int.Parse(TextBox5.Text);
			int stock = int.Parse(TextBox6.Text);
			string query = $"EXEC UpdateBookStock {id}, {stock}";
			SqlCommand cmd = new SqlCommand(query, conn);
			SqlDataReader r = cmd.ExecuteReader();
			if (r.HasRows)
			{
				Response.Write("<script>alert('Book Not Found')</script>");
			}
			else
			{
				Response.Write("<script>alert('Stock Updated Successfully')</script>");
			}
		}

		protected void Button3_Click(object sender, EventArgs e)
		{
			int id =int.Parse(TextBox7.Text);
			string query = $"EXEC DeleteBook {id}";
			SqlCommand cmd = new SqlCommand(query, conn);
			SqlDataReader r = cmd.ExecuteReader();
			if (r.HasRows)
			{
				Response.Write("<script>alert('Book Not Found')</script>");
			}
			else
			{
				Response.Write("<script>alert('Book Deleted Successfully')</script>");
			}

		}

		protected void Button4_Click(object sender, EventArgs e)
		{
			int id = int.Parse(TextBox7.Text);
			string query = $"SELECT dbo.CalculateBookStockValue({id}) AS StockValue";
			SqlCommand cmd  = new SqlCommand(query, conn);
			object result = cmd.ExecuteScalar();

			if (result != null)
			{
				// Convert the result to decimal and display or use it as needed
				decimal stockValue = (decimal)result;
				// You can now use stockValue, for example displaying it in a Label
				//LabelStockValue.Text = "Total Stock Value: " + stockValue.ToString("C");
			}
			else
			{
				// Handle the case where no result is returned (BookID not found)
				//LabelStockValue.Text = "No book found with the given ID.";
			}

		}

protected void Button5_Click(object sender, EventArgs e)
{
    try
    {
        // Get the book title from the TextBox
        string bookName = TextBox8.Text;

        // Create the SQL query to call the function
        string query = "SELECT * FROM dbo.GetBookDetailsByTitle(@Title)";

        // Create the SqlCommand and add the parameter
        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@Title", bookName);

        // Execute the command and fill a DataTable with the results
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        // Check if any rows are returned
        if (dt.Rows.Count > 0)
        {
            // Bind the results to a GridView (or any other data control)
            GridViewBookDetails.DataSource = dt;
            GridViewBookDetails.DataBind();
        }
        else
        {
            // Handle the case where no results are returned (no book with that title)
            LabelMessage.Text = "No book found with the given title.";
        }
    }
    catch (Exception ex)
    {
        // Handle any exceptions that occur
        LabelMessage.Text = "An error occurred: " + ex.Message;
    }
}

	}
}