using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Drawing;

public partial class _CoursePage : System.Web.UI.Page
{
    XmlDocument xmlDoc = new XmlDocument();
    string userID = "";
    protected void Page_init(object sender, EventArgs e)
    {
        xmlDoc.Load(Server.MapPath("myTrees/generatorUsers.xml"));
        userID = Session["userEmail"].ToString();
        string theItemId = Session["theItemIdSession"].ToString();
        //userName.Text = userID;
        XmlNode node = xmlDoc.SelectSingleNode("/users/user[@email='" + userID + "']/course[@id='" + theItemId + "']");
        CourseTitle.Text = Server.UrlDecode(node.SelectSingleNode("title").InnerText);

        XmlDataSource1.XPath = "/users/user[@email='" + userID + "']/course[@id='" + theItemId + "']/lessons//lesson";

        int LessonCounter = Convert.ToInt16(xmlDoc.SelectNodes("/users/user[@email='" + userID + "']/course[@id='" + theItemId + "']/lessons//lesson").Count);
        forCheck.Text = "sdasd" + LessonCounter.ToString();
        if (LessonCounter == 0)
        {
            noLessons.Style.Add("display", "block");
        }
        else
        {
            noLessons.Style.Add("display", "none");
        }



    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //יביא את האלמנט שהפעיל את הפונקציה הזאת
        ImageButton i = (ImageButton)e.CommandSource;
        // אנו מושכים את האי די של הפריט באמצעות מאפיין לא שמור במערכת שהוספנו באופן ידני לכפתור-תמונה
        string theLessonId = i.Attributes["theLessonId"];
        string ifPublish = i.Attributes["checkIfPublish"];
        Session["theLessonId"] = i.Attributes["theLessonId"];



        // עלינו לברר איזו פקודה צריכה להתבצע - הפקודה רשומה בכל כפתור             
        switch (e.CommandName)
        {
            //אם נלחץ על כפתור מחיקה יקרא לפונקציה של מחיקה                    
            case "deleteRow":
                forCheck.Text = "מחיקה" + theLessonId;
                deleteAlert(theLessonId);
                break;

            case "ChangePublishCourse":
                forCheck.Text = "פובליש" + theLessonId;
                changePublish(theLessonId, ifPublish);

                break;
            //אם נלחץ על כפתור עריכה (העפרון) נעבור לדף עריכה                    
            case "editRow":
                forCheck.Text = "edit" + theLessonId;
                checkIfnewOrExist(theLessonId);
                break;

            case "settingsRow":
                forCheck.Text = "settings" + theLessonId;
                Response.Redirect("LessonSettings.aspx");

                break;

            case "studentsAnswers":
                forCheck.Text = "studdents" + theLessonId;

                break;
        }
    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        ImageButton forPublish = (ImageButton)e.Item.FindControl("PublishedCheckBox");
        Panel coursePanel = (Panel)e.Item.FindControl("LessonRow");

        string pub = forPublish.Attributes["checkIfPublish"];
        if (pub == "False")
        {

            forPublish.Enabled = true;
            forPublish.ImageUrl = "~/generatorElements/checkboxicon.png";
            coursePanel.Style.Add("background-color", "#f4f4f4");
        }
        else
        {
            coursePanel.Style.Add("background-color", "#e8f1f7");
            forPublish.Enabled = true;
            forPublish.ImageUrl = "~/generatorElements/checkboxiconactive.png";
        }

    }


    void deleteAlert(string theItemId)
    {
        deleteCalert.Visible = true;
        disableDiv.Visible = true;
    }

    protected void deleteApprove_Click(object sender, EventArgs e)
    {
        string theItemId = Session["theItemIdSession"].ToString();
        string theLessonId = Session["theLessonId"].ToString();
        XmlDocument Document = XmlDataSource1.GetXmlDocument();
        XmlNode node = Document.SelectSingleNode("/users/user[@email='" + userID + "']/course[@id='" + theItemId + "']/lessons//lesson[@id='" + theLessonId + "']");
        node.ParentNode.RemoveChild(node);
        deleteCalert.Visible = false;
        disableDiv.Visible = false;
        XmlDataSource1.Save();
        Repeater1.DataBind();

        int LessonCounter = Convert.ToInt16(xmlDoc.SelectNodes("/users/user[@email='" + userID + "']/course[@id='" + theItemId + "']/lessons//lesson").Count);
        forCheck.Text = "sdasd" + LessonCounter.ToString();
        if (LessonCounter == 1)
        {
            noLessons.Style.Add("display", "block");

        }

    }

    protected void deleteCancel_Click(object sender, EventArgs e)
    {
        deleteCalert.Visible = false;
        disableDiv.Visible = false;
    }

    void changePublish(string lessonId, string thePublish)
    {
        string theItemId = Session["theItemIdSession"].ToString();
        XmlDocument Document = XmlDataSource1.GetXmlDocument();
        XmlNode node = Document.SelectSingleNode("/users/user[@email='" + userID + "']/course[@id='" + theItemId + "']/lessons//lesson[@id='" + lessonId + "']");

        forCheck.Text = thePublish + lessonId;
        if (thePublish == "True")
        {
            node.Attributes["published"].InnerText = "False";
        }
        else
        {
            node.Attributes["published"].InnerText = "True";
        }

        XmlDataSource1.Save();
        Repeater1.DataBind();
    }

    protected void NewLesson_Click(object sender, EventArgs e)
    {
        Response.Redirect("NewLessonSettings.aspx");
    }

    protected void backToDefault_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    void checkIfnewOrExist(string lessonId)
    {
        string theItemId = Session["theItemIdSession"].ToString();
        XmlDocument Document = XmlDataSource1.GetXmlDocument();
        XmlNode node = Document.SelectSingleNode("/users/user[@email='" + userID + "']/course[@id='" + theItemId + "']/lessons//lesson[@id='" + lessonId + "']/audio");

        if (node.InnerXml.ToString() == "")
        {
            Response.Redirect("NewLessonMaker.aspx");
        }

        else
        {
            forCheck.Text = "עמוד שיעור קיים מייקר";
        }



    }
}
