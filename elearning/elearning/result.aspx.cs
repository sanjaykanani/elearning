using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;
public partial class result : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand com;
    SqlDataReader dr;
    int totques, i, m;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["elearningConnectionString"].ConnectionString);
            com = new SqlCommand("SELECT COUNT(*) AS Expr1 FROM cquestions", con);
            con.Open();
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                totques = Convert.ToInt32(dr[0].ToString());
            }
            dr.Close();
            con.Close();
            m = 0;
            for (i = 1; i <= totques; i++)
            {
                string answer = null;
                string selectedans = null;
                answer = Session["ans" + i.ToString().Trim()].ToString().Trim();
                selectedans = Session["selectedans" + i.ToString().Trim()].ToString().Trim();
                if (selectedans != null)
                {
                    if (String.Compare(answer, selectedans) == 0)
                    {
                        m = m + 5;
                    }
                }
            }
            Label2.Text = m.ToString();
            Session.Abandon();
        }
    }
    protected void homebutton_Click(object sender, EventArgs e)
    {

        Response.Redirect("chapters.aspx");
    }

    protected void viewAnswer_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewAnswers.aspx");
    }

}
