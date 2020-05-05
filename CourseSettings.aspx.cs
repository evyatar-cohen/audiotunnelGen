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

public partial class _CourseSettings : System.Web.UI.Page
{
    XmlDocument myDoc = new XmlDocument();
    string userID = "";
    string imagesLibPath = "Logos/";
    string imageNewName = "";
    string theItemId = "";
    

    protected void Page_Load(object sender, EventArgs e)
    {

        if (IsPostBack)
        {
            LabelCounter1.Text = courseNameTB.Text.Length.ToString();
            LabelCounter2.Text = courseDescriptionTB.Text.Length.ToString();
            if (courseNameTB.Text.Length > 0 && courseDescriptionTB.Text.Length > 0)
            {
                UpadteCourse.Style.Add("opacity", "1");
                UpadteCourse.Enabled = true;

            }
            else
            {
                UpadteCourse.Style.Add("opacity", "0.3");
                UpadteCourse.Enabled = false;
            }
        }
    }
    protected void Page_init(object sender, EventArgs e)
    {
        userID = Session["userEmail"].ToString();
        myDoc.Load(Server.MapPath("myTrees/generatorUsers.xml"));
        theItemId = Session["theItemIdSession"].ToString();

        XmlNode node = myDoc.SelectSingleNode("/users/user[@email='" + userID + "']/course[@id='" + theItemId + "']");
        courseNameTB.Text = Server.UrlDecode(node.SelectSingleNode("title").InnerText);
        int nameLength = Convert.ToInt16(courseNameTB.Text.Length);
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

        courseDescriptionTB.Text = Server.UrlDecode(node.SelectSingleNode("description").InnerText);
        int descLength = Convert.ToInt16(courseDescriptionTB.Text.Length);
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

        if (courseNameTB.Text.Length > 0 && courseDescriptionTB.Text.Length > 0)
        {
            UpadteCourse.Style.Add("opacity", "1");
            UpadteCourse.Enabled = true;

        }
        else
        {
            UpadteCourse.Style.Add("opacity", "0.3");
            UpadteCourse.Enabled = false;
        }

        //logo
        string logoFileName = Server.UrlDecode(node.SelectSingleNode("logo").InnerText).ToString();
        if (logoFileName != "")
        {

            ImageforFileUploadLogo.ImageUrl = "~/Logos/" + logoFileName;


        }
        else
        {
            ImageforFileUploadLogo.ImageUrl = "~/generatorElements/uploadlogo.png";
        }
    }



    protected void updateXml()
    {
        userID = Session["userEmail"].ToString();
        string theItemId = Session["theItemIdSession"].ToString();

        XmlNode titleNode = myDoc.SelectSingleNode("/users/user[@email='" + userID + "']/course[@id='" + theItemId + "']/title");
        titleNode.InnerXml = Server.UrlEncode(courseNameTB.Text);

        XmlNode descriptionNode = myDoc.SelectSingleNode("/users/user[@email='" + userID + "']/course[@id='" + theItemId + "']/description");
        descriptionNode.InnerXml = Server.UrlEncode(courseDescriptionTB.Text);

        string imageUrl = ImageforFileUploadLogo.ImageUrl.ToString();
        XmlNode logoNode = myDoc.SelectSingleNode("/users/user[@email='" + userID + "']/course[@id='" + theItemId + "']/logo");

        if (checkDeleteLogo.Checked == true)
        {

            if (imageUrl != "/generatorElements/uploadlogo.png")
            {
                string substringUrl = ImageforFileUploadLogo.ImageUrl.ToString();
                char x = substringUrl[0];
                if(x=='~')
                {
                    logoNode.InnerXml = substringUrl.Substring(8);
                }
                else
                {
                    logoNode.InnerXml = substringUrl.Substring(6);
                }
                
            }

            else
            {
                Random rnd = new Random();
                int rndNum = rnd.Next(1, 4);
                imageNewName = "DefaultLogo" + rndNum + ".png";
                logoNode.InnerXml = imageNewName;
            }


        }

        else
        {
            Random rnd = new Random();
            int rndNum = rnd.Next(1, 4);
            imageNewName = "DefaultLogo" + rndNum + ".png";
            logoNode.InnerXml = imageNewName;
        }

        forCheck.Text =   " " + ImageforFileUploadLogo.ImageUrl.ToString();
        myDoc.Save(Server.MapPath("myTrees/generatorUsers.xml"));

    }


    protected void saveCourse_Click(object sender, EventArgs e)
    {
        updateXml();
        Response.Redirect("Default.aspx");
    }

    static System.Drawing.Image FixedSize(System.Drawing.Image imgPhoto, int Width, int Height)
    {
        int sourceWidth = Convert.ToInt32(imgPhoto.Width);
        int sourceHeight = Convert.ToInt32(imgPhoto.Height);

        int sourceX = 0;
        int sourceY = 0;
        int destX = 0;
        int destY = 0;

        float nPercent = 0;
        float nPercentW = 0;
        float nPercentH = 0;

        nPercentW = ((float)Width / (float)sourceWidth);
        nPercentH = ((float)Height / (float)sourceHeight);
        if (nPercentH < nPercentW)
        {
            nPercent = nPercentH;
            destX = System.Convert.ToInt16((Width -
                          (sourceWidth * nPercent)) / 2);
        }
        else
        {
            nPercent = nPercentW;
            destY = System.Convert.ToInt16((Height -
                          (sourceHeight * nPercent)) / 2);
        }

        int destWidth = (int)(sourceWidth * nPercent);
        int destHeight = (int)(sourceHeight * nPercent);

        System.Drawing.Bitmap bmPhoto = new System.Drawing.Bitmap(Width, Height,
                          PixelFormat.Format24bppRgb);
        bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                         imgPhoto.VerticalResolution);

        System.Drawing.Graphics grPhoto = System.Drawing.Graphics.FromImage(bmPhoto);
        grPhoto.Clear(System.Drawing.Color.White);
        grPhoto.InterpolationMode =
                InterpolationMode.HighQualityBicubic;

        grPhoto.DrawImage(imgPhoto,
            new System.Drawing.Rectangle(destX, destY, destWidth, destHeight),
            new System.Drawing.Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
            System.Drawing.GraphicsUnit.Pixel);

        grPhoto.Dispose();
        return bmPhoto;
    }

    protected void backToDefualt_Click(object sender, EventArgs e)
    {
        string completePath = Server.MapPath("~/Logos/" + Session["imageNewName"].ToString());
        //forCheck.Text = completePath;
        if (System.IO.File.Exists(completePath))
        {

            System.IO.File.Delete(completePath);

        }

       Response.Redirect("Default.aspx");
    }

    protected void forImageDisplay_Click(object sender, EventArgs e)
    {
        userID = Session["userEmail"].ToString();
        //forCheck.Text = "sdfsd";
        string fileType2 = FileUploadLogo.PostedFile.ContentType;
        if (fileType2.Contains("image"))
        {

            // הנתיב המלא של הקובץ עם שמו האמיתי של הקובץ
            string fileName = FileUploadLogo.PostedFile.FileName;

            // הסיומת של הקובץ
            string endOfFileName = fileName.Substring(fileName.LastIndexOf("."));
            //לקיחת הזמן האמיתי למניעת כפילות בתמונות
            string myTime = DateTime.Now.ToString("ddMMyy-HHmmss");

            // חיבור השם החדש עם הסיומת של הקובץ
            imageNewName = myTime + "Logo" + endOfFileName;
            // Bitmap המרת הקובץ שיתקבל למשתנה מסוג
            Bitmap bmpPostedImage = new Bitmap(FileUploadLogo.PostedFile.InputStream);
            //קריאה לפונקציה המקטינה את התמונה
            //אנו שולחים לה את התמונה שלנו בגירסאת הביטמאפ ואת האורך והרוחב שאנו רוצים לתמונה החדשה
            System.Drawing.Image objImage = FixedSize(bmpPostedImage, 300, 300);
            //שמירה של הקובץ לספרייה בשם החדש שלו
            objImage.Save(Server.MapPath(imagesLibPath) + imageNewName);


            //הצגה של הקובץ החדש מהספרייה
            ImageforFileUploadLogo.ImageUrl = imagesLibPath + imageNewName;

        }
        else
        {



        }
        Session["imageNewName"] = imageNewName;
        //forCheck.Text = ImageforFileUploadLogo.ImageUrl.ToString();
        forCheck.Text = Session["imageNewName"].ToString();

    }


}