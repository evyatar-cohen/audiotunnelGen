<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
            <style> @import url('https://fonts.googleapis.com/css?family=Rubik&display=swap');</style>
       <title>מחולל מסור ולמד / דף הרשמה</title>
    <meta name="description" content="מסך ההרשמה לאתר המחולל." />
    <meta name="keywords" content=" הרשמה, מחולל, מסור, למד, כדורגל, משחק לימודי" />
    <meta name="author" content=" אביתר כהן, אסף זיתוני" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=yes">
<link rel="shortcut icon" type="image/png" href="images/favicon.png"/>
        <script src="jScripts/jquery-1.12.0.min.js"></script>
    <script src="jScripts/JavaScript.js"></script>
    <link href="styles/myStyle.css" rel="stylesheet" />

</head>
    <link href="https://fonts.googleapis.com/css2?family=Rubik:ital,wght@0,300;0,400;0,500;0,700;0,900;1,300;1,400;1,500;1,700;1,900&display=swap" rel="stylesheet">
<body lang="he" dir="rtl" style="margin: 0px 0px 0px 0px;">
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
        
        <div id="loginpage">
            <div id="logoApp"> <img id="loginlogo" src="generatorElements/LogoLogin.png" /></div>
            <asp:TextBox ID="userTb" placeholder="אימייל"  Font-Names="Rubik" CssClass="countLogin logintextbox" runat="server" ></asp:TextBox><br />
            <asp:TextBox ID="passwordTb" placeholder="סיסמא" Font-Names="Rubik" runat="server" CssClass="countLogin logintextbox" TextMode="Password"></asp:TextBox><br />
            <asp:Button ID="userBtn" runat="server" Text="כניסה" disabled="disabled" OnClick="userBtn_Click" />
            <asp:Label ID="exampleuser" runat="server" Text="user1@gmail.com, user1"></asp:Label>
            <asp:Label ID="feedbacklogin" runat="server" Visible="true"  Text=""></asp:Label>

            <a id="newuserA">הירשם</a>
            

            
        
        <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/myTrees/XMLFile.xml"></asp:XmlDataSource>
    </div>

    </form>
</body>
</html>
