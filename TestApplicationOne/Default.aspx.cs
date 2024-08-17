using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
namespace TestApplicationOne
{
	public partial class _Default : Page
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
			string pass = TextBox9.Text, email = TextBox2.Text, bankName = TextBox3.Text;
			string name = TextBox1.Text, ifsc = TextBox4.Text, Bank_ac = TextBox5.Text;
			string pan = TextBox6.Text, adhar = TextBox7.Text, doj = TextBox8.Text;

			// Calculate total leaves available from joining date
			int maxLeavesPerMonth = 2;
			DateTime joiningDate = DateTime.ParseExact(doj, "yyyy-MM-dd", null);
			DateTime today = DateTime.Today;
			int monthsWorked = ((today.Year - joiningDate.Year) * 12) + today.Month - joiningDate.Month;
			int totalLeavesAvailable = monthsWorked * maxLeavesPerMonth;
		}

		protected void Button2_Click(object sender, EventArgs e)
		{

		}
	}
}