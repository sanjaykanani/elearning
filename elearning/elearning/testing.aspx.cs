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

public partial class testing : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand com;
    SqlDataReader dr;
    int qno;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["elearningConnectionString"].ConnectionString);
        if (!IsPostBack)
        {
            
            qno = 1;
            Session["question_no"] = qno;
            Session["marks"] = 0;

            com = new SqlCommand("select * from cquestions where question_no=" + qno, con);
            con.Open();
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                Session["ans" + qno.ToString().Trim()] = dr[7].ToString();
                Label2.Text = dr[1].ToString();
                TextBox1.Text = dr[2].ToString();
                RadioButton1.Text = dr[3].ToString();
                RadioButton2.Text = dr[4].ToString();
                RadioButton3.Text = dr[5].ToString();
                RadioButton4.Text = dr[6].ToString();
               
            }
            dr.Close();
            con.Close();
        }
    }
    protected void nextquest_Click(object sender, EventArgs e)
    {
        string selectedans = null;
        if (RadioButton1.Checked == true)
            selectedans = "a";
        if (RadioButton2.Checked == true)
            selectedans = "b";
        if (RadioButton3.Checked == true)
            selectedans = "c";
        if (RadioButton4.Checked == true)
            selectedans = "d";
        if (selectedans != null)
        {
            qno = Convert.ToInt32(Session["question_no"]);
            Session["selectedans" + qno.ToString().Trim()] = selectedans;
            qno = qno + 1;
            Session["question_no"] = qno;
            com = new SqlCommand("select * from cquestions where question_no=" + qno, con);
            con.Open();
            dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                { 
                    Session["ans" + qno.ToString().Trim()] = dr[7].ToString();
                    Label2.Text = dr[1].ToString();
                    TextBox1.Text = dr[2].ToString();
                    RadioButton1.Text = dr[3].ToString();
                    RadioButton2.Text = dr[4].ToString();
                    RadioButton3.Text = dr[5].ToString();
                    RadioButton4.Text = dr[6].ToString();
                  
                }
                RadioButton1.Checked = false;
                RadioButton2.Checked = false;
                RadioButton3.Checked = false;
                RadioButton4.Checked = false;
                
                if (Session["selectedans" + qno.ToString()] != null)
                {
                    string k = Session["selectedans" + qno.ToString().Trim()].ToString();
                    Response.Write("next selectedans" + qno.ToString().Trim() + k);
                    RadioButton1.Checked = false;
                    RadioButton2.Checked = false;
                    RadioButton3.Checked = false;
                    RadioButton4.Checked = false;
                    switch (k)
                    {
                        case "a": RadioButton1.Checked = true;
                            break;
                        case "b": RadioButton2.Checked = true;
                            break;
                        case "c": RadioButton3.Checked = true;
                            break;
                        case "d": RadioButton4.Checked = true;
                            break;
                    }
                }
                 
                dr.Close();
                con.Close();
            }
            else
            {
                Response.Redirect("result.aspx");
            }
        }
    }
    protected void prevquest_Click(object sender, EventArgs e)
    {
        string selectedans = null;
        qno = Convert.ToInt32(Session["question_no"]);
        if (RadioButton1.Checked == true)
            selectedans = "a";
        if (RadioButton2.Checked == true)
            selectedans = "b";
        if (RadioButton3.Checked == true)
            selectedans = "c";
        if (RadioButton4.Checked == true)
            selectedans = "d";
        Session["selectedans" + qno.ToString().Trim()] = selectedans;
        if (qno != 1)
        {
            qno = qno - 1;
            Session["question_no"] = qno;
        }
        Response.Write("Question number is: " + qno);
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["elearningConnectionString"].ConnectionString);
        com = new SqlCommand("select * from cquestions where question_no=" + qno, con);
        con.Open();
        dr = com.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                    Session["ans" + qno.ToString().Trim()] = dr[7].ToString();
                    Label2.Text = dr[1].ToString();
                    TextBox1.Text = dr[2].ToString();
                    RadioButton1.Text = dr[3].ToString();
                    RadioButton2.Text = dr[4].ToString();
                    RadioButton3.Text = dr[5].ToString();
                    RadioButton4.Text = dr[6].ToString();
            }
        }
        dr.Close();
        con.Close();
        RadioButton1.Checked = false;
        RadioButton2.Checked = false;
        RadioButton3.Checked = false;
        RadioButton4.Checked = false;
        if (Session["selectedans" + qno.ToString().Trim()] != null)
        {
            string k = Session["selectedans" + qno.ToString().Trim()].ToString();
            Response.Write("previous selectedans" + qno.ToString().Trim() + k);
            switch (k)
            {
                case "a": RadioButton1.Checked = true;
                    break;

                case "b": RadioButton2.Checked = true;
                    break;
                case "c": RadioButton3.Checked = true;
                    break;
                case "d": RadioButton4.Checked = true;
                    break;
            }
        }
       
    }

    protected void cancelbutton_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("chapters.aspx");
    }
}
