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

public partial class _NewLessonMaker : System.Web.UI.Page
{
    XmlDocument myDoc = new XmlDocument();
    XmlDocument myPods = new XmlDocument();
    string userID = "user1@gmail.com";
    string courseId = "2";
    string lessonId = "2";
    string FilesLibPath = "Podcasts/";
    string fileId;


    protected void Page_init(object sender, EventArgs e)
    {
        upload.Visible = true;
        openInteraction.Visible = false;
        rulerInteraction.Visible = false;
        orderInteraction.Visible = false;
        matchInteraction.Visible = false;
        choiceInteraction.Visible = false;
        branchInteraction.Visible = false;

        //userID = Session["userEmail"].ToString();
        //courseId = Session["theItemIdSession"].ToString();
        //lessonId = Session["theLessonId"].ToString();
        myDoc.Load(Server.MapPath("myTrees/generatorUsers.xml"));
        myPods.Load(Server.MapPath("myTrees/tempLesson.xml"));
    }





    protected void branchBtn_Click(object sender, EventArgs e)
    {
        upload.Visible = false;
        openInteraction.Visible = false;
        rulerInteraction.Visible = false;
        orderInteraction.Visible = false;
        matchInteraction.Visible = false;
        choiceInteraction.Visible = false;
        branchInteraction.Visible = true;
    }

    protected void cohiceBtn_Click(object sender, EventArgs e)
    {
        upload.Visible = false;
        openInteraction.Visible = false;
        rulerInteraction.Visible = false;
        orderInteraction.Visible = false;
        matchInteraction.Visible = false;
        choiceInteraction.Visible = true;
        branchInteraction.Visible = false;
    }

    protected void matchBtn_Click(object sender, EventArgs e)
    {
        upload.Visible = false;
        openInteraction.Visible = false;
        rulerInteraction.Visible = false;
        orderInteraction.Visible = false;
        matchInteraction.Visible = true;
        choiceInteraction.Visible = false;
        branchInteraction.Visible = false;
    }

    protected void orderBtn_Click(object sender, EventArgs e)
    {
        upload.Visible = false;
        openInteraction.Visible = false;
        rulerInteraction.Visible = false;
        orderInteraction.Visible = true;
        matchInteraction.Visible = false;
        choiceInteraction.Visible = false;
        branchInteraction.Visible = false;
    }



    protected void rulerBtn_Click(object sender, EventArgs e)
    {
        upload.Visible = false;
        openInteraction.Visible = false;
        rulerInteraction.Visible = true;
        orderInteraction.Visible = false;
        matchInteraction.Visible = false;
        choiceInteraction.Visible = false;
        branchInteraction.Visible = false;
    }

    protected void openBtn_Click(object sender, EventArgs e)
    {
        upload.Visible = false;
        openInteraction.Visible = true;
        rulerInteraction.Visible = false;
        orderInteraction.Visible = false;
        matchInteraction.Visible = false;
        choiceInteraction.Visible = false;
        branchInteraction.Visible = false;
    }

    protected void ConfirmBtn_Click(object sender, EventArgs e)
    {
        if (FileUpload1.PostedFile.ContentType == "audio/mpeg")
        {
            forCheck.Text = "yep";
            string fileName = FileUpload1.PostedFile.FileName;
            string endOfFileName = fileName.Substring(fileName.LastIndexOf("."));
            string myTime = DateTime.Now.ToString("ddMMyy-HHmmss");
            string newFileName = fileName + "_" + myTime;
            FileUpload1.PostedFile.SaveAs(Server.MapPath("Podcasts") + "//" + newFileName);

            XmlNode audioNode = myPods.SelectSingleNode("/lesson/audio");
            audioNode.InnerXml = newFileName.ToString();
            myPods.Save(Server.MapPath("myTrees/tempLesson.xml"));
        }

        else

        {
            forCheck.Text = "לא MP3";
        }



        //XmlElement NewLessonFileNode = myFiles.CreateElement("file");
        //NewLessonFileNode.SetAttribute("id", filesCounterNode.InnerXml.ToString());

        //XmlElement NewLessonFileNameNode = myFiles.CreateElement("fileName");
        //NewLessonFileNameNode.InnerText = newFileName;
        //NewLessonFileNode.AppendChild(NewLessonFileNameNode);

        //XmlElement NewLessonFileFormatNode = myFiles.CreateElement("fileFormat");
        //NewLessonFileFormatNode.InnerText = endOfFileName;
        //NewLessonFileNode.AppendChild(NewLessonFileFormatNode);

        //XmlNode LessonNode = myFiles.SelectSingleNode("/files");
        //LessonNode.AppendChild(NewLessonFileNode);



    }
}