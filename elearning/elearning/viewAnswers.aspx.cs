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

public partial class viewAnswers : System.Web.UI.Page
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
                RadioButton1.Checked = true;
                RadioButton1.ForeColor = System.Drawing.Color.Green;
                RadioButton1.Enabled = false;
                RadioButton2.Text = dr[4].ToString();
                RadioButton2.Enabled = false;
                RadioButton3.Text = dr[5].ToString();
                RadioButton3.Enabled = false;
                RadioButton4.Text = dr[6].ToString();
                RadioButton4.Enabled = false;

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
            RadioButton1.ForeColor = System.Drawing.Color.Empty;
            RadioButton2.ForeColor = System.Drawing.Color.Empty;
            RadioButton3.ForeColor = System.Drawing.Color.Empty;
            RadioButton4.ForeColor = System.Drawing.Color.Empty;
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    if (qno == 2)
                    {
                        Session["ans" + qno.ToString().Trim()] = dr[7].ToString();
                        Label2.Text = dr[1].ToString();
                        TextBox1.Text = dr[2].ToString();
                        RadioButton1.Text = dr[3].ToString();
                        RadioButton2.Text = dr[4].ToString();
                        RadioButton3.Text = dr[5].ToString();
                        RadioButton1.Checked = false;
                        RadioButton1.ForeColor = System.Drawing.Color.Empty;
                        RadioButton3.Checked = true;
                        RadioButton3.ForeColor = System.Drawing.Color.Green;
                        RadioButton4.Text = dr[6].ToString();
                    }
                    else if (qno == 3)
                    {
                        Session["ans" + qno.ToString().Trim()] = dr[7].ToString();
                        Label2.Text = dr[1].ToString();
                        TextBox1.Text = dr[2].ToString();
                        RadioButton1.Text = dr[3].ToString();
                        RadioButton2.Text = dr[4].ToString();
                        RadioButton3.Text = dr[5].ToString();

                        RadioButton4.Text = dr[6].ToString();
                        RadioButton3.Checked = false;
                        RadioButton3.ForeColor = System.Drawing.Color.Empty;
                        RadioButton4.Checked = true;
                        RadioButton4.ForeColor = System.Drawing.Color.Green;
                    }
                    else if (qno == 4)
                    {
                        Session["ans" + qno.ToString().Trim()] = dr[7].ToString();
                        Label2.Text = dr[1].ToString();
                        TextBox1.Text = dr[2].ToString();
                        RadioButton1.Text = dr[3].ToString();
                        RadioButton2.Text = dr[4].ToString();
                        RadioButton4.Checked = false;
                        RadioButton4.ForeColor = System.Drawing.Color.Empty;
                        RadioButton2.Checked = true;
                        RadioButton2.ForeColor = System.Drawing.Color.Green;
                        RadioButton3.Text = dr[5].ToString();

                        RadioButton4.Text = dr[6].ToString();

                    }
                }
                // RadioButton1.Checked = false;
                //  RadioButton2.Checked = false;
                //  RadioButton3.Checked = false;
                //  RadioButton4.Checked = false;

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
                                  //RadioButton1.ForeColor = System.Drawing.Color.Empty;
                            break;
                        case "b": RadioButton2.Checked = true;
                                  //RadioButton2.ForeColor = System.Drawing.Color.Empty;
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
                
                Session.Clear();
                Response.Redirect("chapters.aspx");
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
        RadioButton1.ForeColor = System.Drawing.Color.Empty;
        RadioButton2.ForeColor = System.Drawing.Color.Empty;
        RadioButton3.ForeColor = System.Drawing.Color.Empty;
        RadioButton4.ForeColor = System.Drawing.Color.Empty;
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                if (qno == 1)
                {
                    Session["ans" + qno.ToString().Trim()] = dr[7].ToString();
                    Label2.Text = dr[1].ToString();
                    TextBox1.Text = dr[2].ToString();
                    RadioButton1.Text = dr[3].ToString();
                    RadioButton2.Text = dr[4].ToString();
                    RadioButton3.Text = dr[5].ToString();
                    RadioButton1.Checked = true;
                    RadioButton1.ForeColor = System.Drawing.Color.Green;
                    RadioButton4.Text = dr[6].ToString();
                }

                else if (qno == 2)
                {
                    Session["ans" + qno.ToString().Trim()] = dr[7].ToString();
                    Label2.Text = dr[1].ToString();
                    TextBox1.Text = dr[2].ToString();
                    RadioButton1.Text = dr[3].ToString();
                    RadioButton2.Text = dr[4].ToString();
                    RadioButton3.Text = dr[5].ToString();
                    RadioButton1.Checked = false;
                    RadioButton1.ForeColor = System.Drawing.Color.Empty;
                    RadioButton3.Checked = true;
                    RadioButton3.ForeColor = System.Drawing.Color.Green;
                    RadioButton4.Text = dr[6].ToString();
                }
                else if (qno == 3)
                {
                    Session["ans" + qno.ToString().Trim()] = dr[7].ToString();
                    Label2.Text = dr[1].ToString();
                    TextBox1.Text = dr[2].ToString();
                    RadioButton1.Text = dr[3].ToString();
                    RadioButton2.Text = dr[4].ToString();
                    RadioButton3.Text = dr[5].ToString();

                    RadioButton4.Text = dr[6].ToString();
                    RadioButton3.Checked = false;
                    RadioButton3.ForeColor = System.Drawing.Color.Empty;
                    RadioButton4.Checked = true;
                    RadioButton4.ForeColor = System.Drawing.Color.Green;
                }
                else if (qno == 4)
                {
                    Session["ans" + qno.ToString().Trim()] = dr[7].ToString();
                    Label2.Text = dr[1].ToString();
                    TextBox1.Text = dr[2].ToString();
                    RadioButton1.Text = dr[3].ToString();
                    RadioButton2.Text = dr[4].ToString();
                    RadioButton4.Checked = false;
                    RadioButton4.ForeColor = System.Drawing.Color.Empty;
                    RadioButton2.Checked = true;
                    RadioButton2.ForeColor = System.Drawing.Color.Green;
                    RadioButton3.Text = dr[5].ToString();

                    RadioButton4.Text = dr[6].ToString();

                }
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

}
