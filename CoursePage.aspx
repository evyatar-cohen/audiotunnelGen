<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CoursePage.aspx.cs" Inherits="_CoursePage" %>


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
                <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/myTrees/generatorUsers.xml"></asp:XmlDataSource>
           
            <p id="instructions"> 
              קורס -
             <asp:Label ID="CourseTitle" runat="server" Text="Label"></asp:Label>
             <br />
                לחיצה על שיעור מאפשרת את עריכתו 
            </p> 

            <div id="BtnPanellessons">
                <asp:Button ID="NewLesson" class="backBTN" runat="server" Text="שיעור חדש" value="" OnClick="NewLesson_Click" />
                <asp:Button ID="backToDefaultLesson"  class="backBTN" runat="server" Text="חזרה" value="" OnClick="backToDefault_Click" />
                </div>
                
                <div id="LessonsPage">
                <div id="titlerow">
                    <asp:Label runat="server" ID="gridLessonPublishCB" CssClass="titleRow"> פרסום </asp:Label>
                    <asp:Label runat="server" ID="griDlessonTitle" CssClass="titleRow"> שם הקורס</asp:Label>
                    <asp:Label runat="server" ID="gridLessonsStudentsAsnwersImageButtonTitle" CssClass="titleRow">מענה תלמידים </asp:Label>
                    <asp:Label runat="server" ID="gridLessonsdeleteImageButtonTitle" CssClass="titleRow">מחיקה </asp:Label>
                    <asp:Label runat="server" ID="gridLessonsettingsImageButtonTitle" CssClass="titleRow">עריכה </asp:Label>
                </div>
                <div id="tableDiv">
                    <asp:Label ID="noLessons" runat="server" Text="אין קורסים זמינים, לחץ על קורס חדש על מנת ליצור קורס משלך"></asp:Label>
                    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="XmlDataSource1" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                        <ItemTemplate>
                            <asp:Panel ID="LessonRow" CssClass="LessonRow" runat="server">
                            <asp:ImageButton ID="editRow" CssClass="editRow" runat="server" CommandName="editRow" theLessonId='<%#XPathBinder.Eval(Container.DataItem,"@id")%>' Text="Button" />
                                <asp:ImageButton ID="PublishedCheckBox" runat="server" CssClass="publishCB" CommandName="ChangePublishCourse"  theLessonId='<%#XPathBinder.Eval(Container.DataItem,"@id")%>' checkIfPublish='<%#XPathBinder.Eval(Container.DataItem,"@published").ToString()%>'/>
                                <asp:Label ID="gridViewLessonTitle" runat="server" CssClass="gridViewTitle gridViewLessonTitle" Text='<%# Server.UrlDecode(XPathBinder.Eval(Container.DataItem, "title").ToString())%>'> </asp:Label>
                                <asp:ImageButton ID="studentsAnswersImageButton" CssClass="studentsAnswersImageButton" CommandName="studentsAnswers" theLessonId='<%#XPathBinder.Eval(Container.DataItem,"@id")%>' runat="server" ImageUrl="~/generatorElements/eyeicon.png" />
                                <asp:ImageButton ID="deleteImageButton" CssClass="deleteImageButton" CommandName="deleteRow" theLessonId='<%#XPathBinder.Eval(Container.DataItem,"@id")%>' runat="server" ImageUrl="~/generatorElements/deleteicon.png" />
                                <asp:ImageButton ID="LessonssettingsImageButton" CssClass="LessonssettingsImageButton" CommandName="settingsRow" theLessonId='<%#XPathBinder.Eval(Container.DataItem,"@id")%>' runat="server" ImageUrl="~/generatorElements/settingsicon.png" />

                            </asp:Panel>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <asp:Label ID="forCheck" runat="server" Text="Label"></asp:Label>
                <div id="popUpsDefault">
                    <asp:Panel ID="disableDiv" runat="server" Visible="false"></asp:Panel>
                    <asp:Panel ID="deleteCalert" runat="server" Visible="false">
                        <div id="DeleteCdiv">
                            <img id="DeleteImage" src="generatorElements/deletobject.png" />
                            <p id="deletetitle1" class="deletelabel">האם ברצונך למחוק שיעור זה?</p>
                            <p id="deletetitle2" class="deletelabel">השיעור יימחק לצמיתות ולא יהיה ניתן לחזור על פעולה זו.</p>
                            <asp:Button ID="deleteApprove" runat="server" Text="בטוח/ה!, כן - מחק" OnClick="deleteApprove_Click" />
                            <asp:Button ID="deleteCancel" runat="server" Text="התבלבלתי! , לא - חזור" OnClick="deleteCancel_Click" />
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
