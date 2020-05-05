<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewCourseSettings.aspx.cs" Inherits="_NewCourseSettings" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <style>
        @import url('https://fonts.googleapis.com/css?family=Rubik&display=swap');
    </style>

    <meta charset="utf-8" />
    <title>מחולל מסור ולמד | דף משחקים</title>
    <meta name="description" content="כאן תוכלו ליצור משחק חדש בעזרת מחולל מסור ולמד." />
    <meta name="keywords" content="מחולל, מסור, למד, כדורגל, משחק לימודי" />
    <meta name="author" content=" אביתר כהן, אסף זיתוני" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=yes">
    <link rel="shortcut icon" type="image/png" href="images/favicon.png" />

    <link href="styles/myStyle.css" rel="stylesheet" />
    <script src="jscripts/jquery-1.12.0.min.js"></script>
    <script src="jscripts/JavaScript.js"></script>
    <link href="styles/myStyle.css" rel="stylesheet" />
</head>
<body id="bodydefault" lang="he" dir="rtl">
    <div id="container">
        <form id="form1" runat="server">
            <div id="header">
                <img id="logo" src="generatorElements/Logosmall.png" />
                <nav id="GenNav">
                    <ul>
                        <li><a href="index.aspx" class="NavLi" id="ToTheGame">אודות</a></li>
                        <li><a class="about" id="ToTheGame1">מדריך</a></li>
                    </ul>
                </nav>
            </div>
            <div id="SettingsPage">
                <div id="SettingsRightPanel">
                <h2>הגדרות</h2>
                <div id="settingstitle">    
                    <h3>כותרת הקורס</h3>
                    <p class="CharLimit" >עד 60 תווים</p>
                    <br />
                    <asp:TextBox ID="courseNameTB" item="1" CharacterLimit="60" Font-Names="Rubik" CssClass="CharacterCount" runat="server"></asp:TextBox>
                    <asp:Label ID="LabelCounter1" class="labelcounters" runat="server" Text="0"></asp:Label>
                </div>
                <div id="settingsDescription">
                    <h3>מבוא הקורס</h3>
                    <p class="CharLimit">עד 200 תווים</p>
                    <br />
                     <asp:TextBox ID="courseDescriptionTB" item="2" CharacterLimit="200" Font-Names="Rubik" CssClass="CharacterCount" runat="server" TextMode="MultiLine" MaxLength="200" Rows="2"></asp:TextBox>
                    <asp:Label ID="LabelCounter2" class="labelcounters" runat="server" Text="0"></asp:Label>
                </div>
                    </div>
            <div id="SettingsLeftPanel">
                <div id="uploadLogo">
                        <asp:Label runat="server" ID="UploadLogoLabel" Font-Names="Rubik">לוגו הקורס</asp:Label>
                        <asp:FileUpload ID="FileUploadLogo" runat="server" />
                        <asp:ImageButton ID="deleteLogoBtn" CssClass="UploadEdit" runat="server" ImageUrl="~/generatorElements/deleteicon.png" OnClientClick="deleteLogo_Click(); return false;" /><br />
                        <asp:ImageButton ID="ImageforFileUploadLogo" CssClass="UploadEdit" runat="server" ImageUrl="~/generatorElements/uploadlogo.png" OnClientClick="openFileUploader(); return false;" />
                        <asp:Button ID="forImageDisplay" runat="server" Text="Button" OnClick="forImageDisplay_Click"  />
                        <asp:CheckBox ID="checkDeleteLogo" Checked="true" runat="server" />
                    </div>
                <div id="settingsBtns">
                    <asp:Button ID="backToDefualt" runat="server" Text="חזור" value="" PostBackUrl="~/Default.aspx" OnClick="backToDefualt_Click" />
                    <asp:Button ID="saveCourse" runat="server" Text="שמירה" value="" OnClick="saveCourse_Click" />
                </div>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
