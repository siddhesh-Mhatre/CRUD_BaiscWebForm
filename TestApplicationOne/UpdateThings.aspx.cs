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
	public partial class UpdateThings : System.Web.UI.Page
	{
		SqlConnection conn;
		protected void Page_Load(object sender, EventArgs e)
		{
			string conf = ConfigurationManager.ConnectionStrings["DBconn"].ConnectionString;
			conn = new SqlConnection(conf);
			conn.Open();
			if (!IsPostBack)
			{
				LoadBooks();
			}
		}

		private void LoadBooks()
		{
			string query = "EXEC GetAllBooks";
			SqlCommand cmd = new SqlCommand(query, conn);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			da.Fill(dt);
			ListViewBooks.DataSource = dt;
			ListViewBooks.DataBind();
		}
		protected void ListViewBooks_ItemCommand(object sender, ListViewCommandEventArgs e)
		{
			if (e.CommandName == "UpdateStock")
			{
				int bookId = Convert.ToInt32(e.CommandArgument);
				TextBox txtStock = (TextBox)e.Item.FindControl("TextBoxStock");
				int updatedStock = int.Parse(txtStock.Text);

				string query = $"EXEC UpdateBookStock {bookId}, {updatedStock}";
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

				// Close the reader and reload the books
				r.Close();
				LoadBooks();
			}
		}
		protected void Page_Unload(object sender, EventArgs e)
		{
			if (conn != null && conn.State == ConnectionState.Open)
			{
				conn.Close();
			}
		}

	}
}