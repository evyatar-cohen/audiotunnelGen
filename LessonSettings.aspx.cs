using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing;

public partial class _LessonSettings : System.Web.UI.Page
{
    XmlDocument myDoc = new XmlDocument();
    XmlDocument myFiles = new XmlDocument();
    string userID = "";
    string FilesLibPath = "UploadedFiles/";
    string courseId = "";
    string lessonId = "";
    string fileId;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            XmlNode newFilesNode = myFiles.ImportNode(myDoc.SelectSingleNode("/users/user[@email='" + userID + "']/course[@id='" + courseId + "']/lessons//lesson[@id='" + lessonId + "']/files"), true);

            XmlNode newLessonFilesNode = myFiles.SelectSingleNode("/files");
            newLessonFilesNode.ParentNode.RemoveChild(newLessonFilesNode);
            myFiles.AppendChild(newFilesNode);
            myFiles.Save(Server.MapPath("myTrees/TempFiles.xml"));

            forCheck.Text = "פעם ראשונה";
        }
        else
        {
            forCheck.Text = "פעם אחרונה";
        }

    }
    protected void Page_init(object sender, EventArgs e)
    {
        myDoc.Load(Server.MapPath("myTrees/generatorUsers.xml"));
        myFiles.Load(Server.MapPath("myTrees/TempFiles.xml"));
        XmlDataSource2.XPath = "/files//file";

        userID = Session["userEmail"].ToString();
        courseId = Session["theItemIdSession"].ToString();
        lessonId = Session["theLessonId"].ToString();



        XmlNode node = myDoc.SelectSingleNode("/users/user[@email='" + userID + "']/course[@id='" + courseId + "']/lessons//lesson[@id='" + lessonId + "']");
        LessonNameTB.Text = Server.UrlDecode(node.SelectSingleNode("title").InnerText);
        int nameLength = Convert.ToInt16(LessonNameTB.Text.Length);
        if (nameLength < 30)
        {
            LabelCounter1.Style.Add("color", "green");
        }
        else
        {
            if (nameLength < 50)
            {
                LabelCounter1.Style.Add("color", "orange");
            }
            else
            {
                LabelCounter1.Style.Add("color", "red");
            }
        }
        LabelCounter1.Text = nameLength.ToString();

        LessonDescriptionTB.Text = Server.UrlDecode(node.SelectSingleNode("description").InnerText);
        int descLength = Convert.ToInt16(LessonDescriptionTB.Text.Length);
        if (descLength < 170)
        {
            LabelCounter2.Style.Add("color", "green");
        }
        else
        {
            if (nameLength < 190)
            {
                LabelCounter2.Style.Add("color", "orange");
            }
            else
            {
                LabelCounter2.Style.Add("color", "red");
            }
        }
        LabelCounter2.Text = descLength.ToString();

        if (LessonNameTB.Text.Length > 0 && LessonDescriptionTB.Text.Length > 0)
        {
            UpadteLesson.Style.Add("opacity", "1");
            UpadteLesson.Enabled = true;

        }
        else
        {
            UpadteLesson.Style.Add("opacity", "0.3");
            UpadteLesson.Enabled = false;
        }

        ListItem answersTypeText = new ListItem();
        answersTypeText.Text = "URL";
        answersTypeText.Value = "URL";
        answersTypeText.Selected = true;
        RadioButtonList1.Items.Add(answersTypeText);

        ListItem answersTypeImage = new ListItem();
        answersTypeImage.Text = "Browser";
        answersTypeImage.Value = "Browser";
        RadioButtonList1.Items.Add(answersTypeImage);
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        ImageButton i = (ImageButton)e.CommandSource;
        string fileFormat = i.Attributes["fileFormat"];
        string fileName = e.CommandArgument.ToString();

        Session["fileId"] = i.Attributes["theFileId"];

        switch (e.CommandName)
        {

            case "Download":
                if (fileFormat == "url")
                {

                    openLink();
                }
                else
                {
                    downloadFile(fileName);
                }

                break;

            case "deleteFile":
                deleteFile();
                break;


        }
    }

    void deleteFile()
    {
        disableDiv2.Visible = true;
        deleteFalert.Visible = true;
    }

    protected void deleteCancel_Click(object sender, EventArgs e)
    {
        disableDiv2.Visible = false;
        deleteFalert.Visible = false;
    }

    protected void deleteApprove_Click(object sender, EventArgs e)
    {

        fileId = Session["fileId"].ToString();
        XmlNode node = myFiles.SelectSingleNode("/files//file[@id='" + fileId + "']");
        node.ParentNode.RemoveChild(node);
        myFiles.Save(Server.MapPath("myTrees/TempFiles.xml"));
        XmlDataSource2.Save();
        Repeater1.DataBind();
        disableDiv2.Visible = false;
        deleteFalert.Visible = false;
    }

    void openLink()
    {
        string fileId = Session["fileId"].ToString();
        XmlNode node = myFiles.SelectSingleNode("/files//file[@id='" + fileId + "']/fileLink");
        string fileLink = node.InnerXml.ToString();
        string redirect = "<script>window.open('" + fileLink + "');</script>";
        Response.Write(redirect);

    }

    void downloadFile(string fileName)
    {

        string filePath = Server.MapPath("~/UploadedFiles/" + fileName);
        FileInfo file = new System.IO.FileInfo(filePath);
        Response.Clear();
        Response.AddHeader("Content-Disposition", ("attachment; filename=" + file.Name));
        Response.AddHeader("Content-Length", file.Length.ToString());
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(file.FullName);
        Response.End();
    }


    protected void urlUploadImageButton_Click(object sender, ImageClickEventArgs e)
    {
        disableDiv.Visible = true;
        uploadOptions.Visible = true;
    }



    protected void uploadCancel_Click(object sender, EventArgs e)
    {
        disableDiv.Visible = false;
        uploadOptions.Visible = false;
    }

    protected void uploadApprove_Click(object sender, EventArgs e)
    {
        XmlNode filesCounterNode = myFiles.SelectSingleNode("/files/filesCounter");
        int newFileId = Convert.ToInt16(filesCounterNode.InnerXml);
        newFileId++;
        filesCounterNode.InnerXml = newFileId.ToString();

        if (((RadioButtonList)FindControl("RadioButtonList1")).SelectedValue == "URL")
        {
            string urlTitleLabel = urlTitle.Text;
            string urlLinkLabel = urlLink.Text;

            XmlElement NewLessonURLNode = myFiles.CreateElement("file");
            NewLessonURLNode.SetAttribute("id", filesCounterNode.InnerXml.ToString());

            XmlElement NewLessonURLNameNode = myFiles.CreateElement("fileName");
            NewLessonURLNameNode.InnerText = urlTitleLabel;
            NewLessonURLNode.AppendChild(NewLessonURLNameNode);

            XmlElement NewLessonURLFormatNode = myFiles.CreateElement("fileFormat");
            NewLessonURLFormatNode.InnerText = "url";
            NewLessonURLNode.AppendChild(NewLessonURLFormatNode);

            XmlElement NewLessonURLLinkNode = myFiles.CreateElement("fileLink");
            NewLessonURLLinkNode.InnerText = urlLinkLabel;
            NewLessonURLNode.AppendChild(NewLessonURLLinkNode);



            XmlNode LessonNode = myFiles.SelectSingleNode("/files");
            LessonNode.AppendChild(NewLessonURLNode);

            urlTitle.Text = "";
            urlLink.Text = "";
            myFiles.Save(Server.MapPath("myTrees/TempFiles.xml"));
            XmlDataSource2.Save();
            Repeater1.DataBind();

        }
        else
        {
            string fileName = FileUpload1.PostedFile.FileName;
            string endOfFileName = fileName.Substring(fileName.LastIndexOf("."));
            string myTime = DateTime.Now.ToString("dd_MM_yy-HH_mm_ss");
            string newFileName = fileName + "_" + myTime;
            FileUpload1.PostedFile.SaveAs(Server.MapPath("UploadedFiles") + "//" + newFileName);

            XmlElement NewLessonFileNode = myFiles.CreateElement("file");
            NewLessonFileNode.SetAttribute("id", filesCounterNode.InnerXml.ToString());

            XmlElement NewLessonFileNameNode = myFiles.CreateElement("fileName");
            NewLessonFileNameNode.InnerText = newFileName;
            NewLessonFileNode.AppendChild(NewLessonFileNameNode);

            XmlElement NewLessonFileFormatNode = myFiles.CreateElement("fileFormat");
            NewLessonFileFormatNode.InnerText = endOfFileName;
            NewLessonFileNode.AppendChild(NewLessonFileFormatNode);

            XmlNode LessonNode = myFiles.SelectSingleNode("/files");
            LessonNode.AppendChild(NewLessonFileNode);

            myFiles.Save(Server.MapPath("myTrees/TempFiles.xml"));
            XmlDataSource2.Save();
            Repeater1.DataBind();


        }


    }

    protected void urlApprove_Click(object sender, EventArgs e)
    {
        string urlTitleLabel = urlTitle.Text;
        string urlLinkLabel = urlLink.Text;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        XmlNode filesCounterNode = myDoc.SelectSingleNode("/users/user[@email='" + userID + "']/course[@id='" + courseId + "']/lessons//lesson[@id='" + lessonId + "']/files/filesCounter");

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        uploadOptions.Visible = true;
        disableDiv.Visible = true;
    }



    protected void RadioButtonList1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (((RadioButtonList)FindControl("RadioButtonList1")).SelectedValue == "URL")
        {

            urlUpload.Visible = true;
            browserUpload.Visible = false;
        }
        else
        {

            urlUpload.Visible = false;
            browserUpload.Visible = true;
        }
    }


    protected void UpadteLesson_Click(object sender, EventArgs e)
    {
        updateXml();
        Response.Redirect("CoursePage.aspx");
    }

    protected void updateXml()
    {


        XmlNode titleNode = myDoc.SelectSingleNode("/users/user[@email='" + userID + "']/course[@id='" + courseId + "']/lessons//lesson[@id='" + lessonId + "']/title");
        titleNode.InnerXml = Server.UrlEncode(LessonNameTB.Text);

        XmlNode descriptionNode = myDoc.SelectSingleNode("/users/user[@email='" + userID + "']/course[@id='" + courseId + "']/lessons//lesson[@id='" + lessonId + "']/description");
        descriptionNode.InnerXml = Server.UrlEncode(LessonDescriptionTB.Text);

        XmlNode currentFiles = myDoc.SelectSingleNode("/users/user[@email='" + userID + "']/course[@id='" + courseId + "']/lessons//lesson[@id='" + lessonId + "']/files");
        currentFiles.ParentNode.RemoveChild(currentFiles);

        XmlNode lessonNode = myDoc.SelectSingleNode("/users/user[@email='" + userID + "']/course[@id='" + courseId + "']/lessons//lesson[@id='" + lessonId + "']");
        XmlNode newLessonFilesNode = myDoc.ImportNode(myFiles.SelectSingleNode("/files"), true);
        lessonNode.AppendChild(newLessonFilesNode);


        //return TempFiles.xml to default
        XmlNode CounterNode = myFiles.SelectSingleNode("/files/filesCounter");
        CounterNode.InnerXml = "0";
        XmlNodeList Filesnode = myFiles.SelectNodes("//file");
        foreach (XmlNode a in Filesnode)
        {
            a.ParentNode.RemoveChild(a);
        }


        myFiles.Save(Server.MapPath("myTrees/TempFiles.xml"));
        myDoc.Save(Server.MapPath("myTrees/generatorUsers.xml"));

    }

    protected void backToCoursePage_Click(object sender, EventArgs e)
    {
        XmlNode CounterNode = myFiles.SelectSingleNode("/files/filesCounter");
        CounterNode.InnerXml = "0";
        XmlNodeList Filesnode = myFiles.SelectNodes("//file");
        foreach (XmlNode a in Filesnode)
        {
            a.ParentNode.RemoveChild(a);
        }
        myFiles.Save(Server.MapPath("myTrees/TempFiles.xml"));
        Response.Redirect("CoursePage.aspx");
    }

    protected string shorterFileName(string fileName, string fileFormat)
    {
        string newName = "";

        if (fileFormat != "url")
        {
            newName = fileName.Substring(0, fileName.IndexOf("_"));
        }
        else
        {
            newName = fileName;
        }


        return newName;
    }
}