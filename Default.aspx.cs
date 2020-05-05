using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Drawing;

public partial class _Default : System.Web.UI.Page
{
    XmlDocument xmlDoc = new XmlDocument();
    string userID = "";
    protected void Page_init(object sender, EventArgs e)
    {

        userID = Session["userEmail"].ToString();
        //userName.Text = userID;
        XmlDataSource1.XPath = "/users/user[@email='" + userID + "']//course";

        xmlDoc.Load(Server.MapPath("myTrees/generatorUsers.xml"));
        XmlNodeList userNode = xmlDoc.SelectNodes("/users/user[@email='" + userID + "']/@first");
        foreach (XmlNode a in userNode)
        {
            privateName.Text = a.InnerXml.ToString();
        }


        int courseCounter = Convert.ToInt16(xmlDoc.SelectNodes("/users/user[@email='" + userID + "']/course").Count);
        forCheck.Text = courseCounter.ToString();
        if (courseCounter == 0)
        {
            noCourses.Style.Add("display", "block");

        }
        else
        {
            noCourses.Style.Add("display", "none");

        }


        //if (coursesNode == null)
        //{
        //    noCourses.Style.Add("display", "block");

        //}
        //else
        //{
        //    noCourses.Style.Add("display", "none");
        //    forCheck.Text = coursesNode.ToString();
        //}


    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //יביא את האלמנט שהפעיל את הפונקציה הזאת
        ImageButton i = (ImageButton)e.CommandSource;
        // אנו מושכים את האי די של הפריט באמצעות מאפיין לא שמור במערכת שהוספנו באופן ידני לכפתור-תמונה
        string theId = i.Attributes["theItemId"];
        string ifPublish = i.Attributes["checkIfPublish"];
        Session["theItemIdSession"] = i.Attributes["theItemId"];
        Session["theQidSession"] = null;


        // עלינו לברר איזו פקודה צריכה להתבצע - הפקודה רשומה בכל כפתור             
        switch (e.CommandName)
        {
            //אם נלחץ על כפתור מחיקה יקרא לפונקציה של מחיקה                    
            case "deleteRow":
                forCheck.Text = "מחיקה" + theId;
                deleteAlert(theId);
                break;

            case "ChangePublishCourse":
                changePublish(theId, ifPublish);

                break;
            //אם נלחץ על כפתור עריכה (העפרון) נעבור לדף עריכה                    
            case "editRow":
                forCheck.Text = "edit" + theId;
                Response.Redirect("CoursePage.aspx");
                break;

            case "settingsRow":
                forCheck.Text = "settings" + theId;
                Response.Redirect("CourseSettings.aspx");
                break;
        }
    }

    void deleteAlert(string theItemId)
    {
        deleteCalert.Visible = true;
        disableDiv.Visible = true;
    }

    protected void deleteApprove_Click(object sender, EventArgs e)
    {//הסרת ענף של משחק קיים באמצעות זיהוי האיי דיי שניתן לו על ידי לחיצה עליו מתוך הטבלה
        //שמירה ועדכון לתוך העץ ולגריד ויו

        string theItemId = Session["theItemIdSession"].ToString();
        XmlDocument Document = XmlDataSource1.GetXmlDocument();
        XmlNode node = Document.SelectSingleNode("/users/user[@email='" + userID + "']/course[@id='" + theItemId + "']");
        node.ParentNode.RemoveChild(node);
        deleteCalert.Visible = false;
        disableDiv.Visible = false;
        XmlDataSource1.Save();
        Repeater1.DataBind();

        int courseCounter = Convert.ToInt16(xmlDoc.SelectNodes("/users/user[@email='" + userID + "']/course").Count);
        forCheck.Text = "sdasd" + courseCounter.ToString();
        if (courseCounter == 1)
        {
            noCourses.Style.Add("display", "block");

        }

    }

    protected void deleteCancel_Click(object sender, EventArgs e)
    {
        deleteCalert.Visible = false;
        disableDiv.Visible = false;
    }


    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {



        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ImageButton forPublish = (ImageButton)e.Item.FindControl("PublishedCheckBox");
            Label Ccount = (Label)e.Item.FindControl("NumOfCLabel");
            Panel coursePanel = (Panel)e.Item.FindControl("courseRow");
            int numOfLessons = Convert.ToInt16(Ccount.Text);



            if (numOfLessons == 0)
            {
                Ccount.Style.Add("color", "red");
                forPublish.Attributes.Add("src", "generatorElements/checkboxicondisable.png");
                forPublish.Enabled = false;
                //forPublish.ToolTip = "לא ניתן לפרסם" + Environment.NewLine + "חסרות " + (10 - numOfQues).ToString() + " שאלות";

            }

            else
            {
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


        }
    }


    void changePublish(string theItemId, string thePublish)
    {

        XmlDocument Document = XmlDataSource1.GetXmlDocument();
        XmlNode node = Document.SelectSingleNode("/users/user[@email='" + userID + "']/course[@id='" + theItemId + "']");

        forCheck.Text = thePublish + theItemId;
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

    void editCourse()
    {
        forCheck.Text = "edit";
    }


    protected void NewCourse_Click(object sender, EventArgs e)
    {
        Response.Redirect("NewCourseSettings.aspx");
    }


}