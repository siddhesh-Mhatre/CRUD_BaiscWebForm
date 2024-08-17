using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data.SqlClient;

namespace TestApplicationOne
{
	public partial class ShowEmploye : System.Web.UI.Page
	{
		SqlConnection conn;
		protected void Page_Load(object sender, EventArgs e)
		{
			string conf = ConfigurationManager.ConnectionStrings["DBconn"].ConnectionString;
			conn = new SqlConnection(conf);
			conn.Open();
		}

        protected void Button1_Click(object sender, EventArgs e) // by useing stored procedure
        {

			int num1 = int.Parse(TextBox1.Text);
			int num2 = int.Parse(TextBox2.Text);
			string query = $"exec AddTwoNumbers {num1},{num2}";
			SqlCommand cmd = new SqlCommand(query, conn);
			SqlDataReader reader = cmd.ExecuteReader();
			if (reader.Read())
			{
				// Display the result in a label or other control
			 string result = reader["Result"].ToString();
			}
			reader.Close();

		}

		protected void Button2_Click(object sender, EventArgs e)
		{
			int num1 = int.Parse(TextBox1.Text);
			int num2 = int.Parse(TextBox2.Text);

			// write code for execute the sql fun 
			string query = $"select dbo.AddTwoNumbersFun({num1},{num2}) as Result";
			SqlCommand cmd = new SqlCommand(query, conn);
			SqlDataReader reader = cmd.ExecuteReader();
			if (reader.Read())
			{
				// Display the result in a label or other control
				string result = reader["Result"].ToString();
			}

		}
	}
}

 