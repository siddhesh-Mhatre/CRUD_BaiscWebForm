using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestApplicationOne
{
	public partial class ShowBooks : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				LoadBooks();
			}
		}

		private void LoadBooks()
		{
			using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconn"].ConnectionString))
			{
				conn.Open();
				string query = "EXEC GetAllBooks";
				SqlCommand cmd = new SqlCommand(query, conn);
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();
				da.Fill(dt);
				ListViewBooks.DataSource = dt;
				ListViewBooks.DataBind();
			}
		}

		protected void ListViewBooks_ItemCommand(object sender, ListViewCommandEventArgs e)
		{
			if (e.CommandName == "UpdateStock")
			{
				int bookId = Convert.ToInt32(e.CommandArgument);
				TextBox txtStock = (TextBox)e.Item.FindControl("TextBoxStock");
				int updatedStock = int.Parse(txtStock.Text);

				using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconn"].ConnectionString))
				{
					conn.Open();
					string query = "EXEC UpdateBookStock @BookID, @Stock";
					SqlCommand cmd = new SqlCommand(query, conn);
					cmd.Parameters.AddWithValue("@BookID", bookId);
					cmd.Parameters.AddWithValue("@Stock", updatedStock);

					int rowsAffected = cmd.ExecuteNonQuery();
					if (rowsAffected > 0)
					{
						Response.Write("<script>alert('Stock Updated Successfully')</script>");
					}
					else
					{
						Response.Write("<script>alert('Book Not Found')</script>");
					}
				}

				LoadBooks();
			}
		}

 
	}
}
