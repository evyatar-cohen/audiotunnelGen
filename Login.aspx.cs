using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Drawing;

public partial class Login : System.Web.UI.Page
{
    XmlDocument xmlDoc = new XmlDocument();


    protected void Page_init(object sender, EventArgs e)
    {
        xmlDoc.Load(Server.MapPath("myTrees/generatorUsers.xml"));


    }





    protected void userBtn_Click(object sender, EventArgs e)
    {
        string email = userTb.Text;
        XmlNode realPasswordNode;
        realPasswordNode = xmlDoc.SelectSingleNode("/users/user[@email='" + email + "']/@password");

        if (realPasswordNode != null)
        {
            if (realPasswordNode.InnerXml.ToString() == passwordTb.Text)
            {
                Session["userEmail"] = email;
                Response.Redirect("Default.aspx", true);
            }
            else
            {
                feedbacklogin.Text = "סיסמא לא נכונה";
            }
        }

        else
        {
            feedbacklogin.Text = "משתמש לא קיים";

        }



    }
}