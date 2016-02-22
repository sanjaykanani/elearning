using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand com;
    SqlDataReader dr;
    String strchapcode;
    int totchapters, rec;
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["elearningConnectionString"].ConnectionString);
        if (!IsPostBack)
        {
            rec = 1;
            com = new SqlCommand("select * from cchapters where chapno=" + rec, con);
            con.Open();
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                Label2.Text = dr[0].ToString();
                TextBox1.Text = dr[1].ToString();
            }
            dr.Close();
            con.Close();
            com = new SqlCommand("SELECT COUNT(*) AS Expr1 FROM cchapters", con);
            con.Open();
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                totchapters = Convert.ToInt32(dr[0].ToString());
            }
            dr.Close();
            con.Close();
            Session["recordno"] = rec.ToString();
            Session["totchapters"] = totchapters.ToString();
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        strchapcode = DropDownList1.SelectedItem.Text;
        showrec(Convert.ToInt32(strchapcode));
        Session["recordno"] = strchapcode;
    }
    protected void prevbutton_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Session["recordno"]) == 1)
        {
            rec = 1;
        }
        else
        {
            rec = Convert.ToInt32(Session["recordno"]);
            rec = rec - 1;
        }
        Session["recordno"] = rec.ToString();
        showrec(rec);
    }

    protected void showrec(int r)
    {
        com = new SqlCommand("select * from cchapters where chapno=" + r, con);
        con.Open();
        dr = com.ExecuteReader();
        while (dr.Read())
        {
            Label2.Text = dr[0].ToString();
            TextBox1.Text = dr[1].ToString();
        }
        con.Close();
        DropDownList1.Text = r.ToString();
    }

    protected void nxtbutton_Click(object sender, EventArgs e)
    {
        rec = Convert.ToInt32(Session["recordno"]);
        totchapters = Convert.ToInt32(Session["totchapters"]);
        rec = rec + 1;
        if (rec > totchapters) rec = totchapters;
        Session["recordno"] = rec.ToString();
        showrec(rec);
    }
    protected void testbutton_Click(object sender, EventArgs e)
    {
        Response.Redirect("testing.aspx");
    }
}
