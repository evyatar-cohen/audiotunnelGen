<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewLessonSettings.aspx.cs" Inherits="_NewLessonSettings" %>


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
            <div id="LessonSettingsPage">
                <div id="LessonSettingsRightPanel">
                    <h2>הגדרות</h2>
                    <div id="settingstitle">
                        <h3>כותרת השיעור</h3>
                        <p class="CharLimit">עד 60 תווים</p>
                        <br />
                        <asp:TextBox ID="LessonNameTB" item="1" CharacterLimit="60" Font-Names="Rubik" CssClass="LessonCount" runat="server"></asp:TextBox>
                        <asp:Label ID="LabelCounter1" class="labelcounters" runat="server" Text="0"></asp:Label>
                    </div>
                    <div id="settingsDescription">
                        <h3>מבוא הקורס</h3>
                        <p class="CharLimit">עד 200 תווים</p>
                        <br />
                        <asp:TextBox ID="LessonDescriptionTB" item="2" CharacterLimit="200" Font-Names="Rubik" CssClass="LessonCount" runat="server" TextMode="MultiLine" MaxLength="200" Rows="2"></asp:TextBox>
                        <asp:Label ID="LabelCounter2" class="labelcounters" runat="server" Text="0"></asp:Label>
                    </div>
                </div>
                <div id="LessonSettingsLeftPanel">
                    <div id="uploadFiles">
                        <asp:Label runat="server" ID="UploadFfilesLabel" Font-Names="Rubik">העלאת קבצי עזר לשיעור</asp:Label>
                        <asp:ImageButton ID="ImageButton1" runat="server" OnClick="Button2_Click" ImageUrl="~/generatorElements/uploadlogo.png" />             
                        <asp:Panel ID="uploadOptions" runat="server" Visible="false">

                            <asp:Panel ID="disableDiv" runat="server"></asp:Panel>

                            <asp:Panel ID="uploadPopUp" runat="server">
                                <p>חלון הוספת נספחים</p>
                                <p>לתשומת ליבך, באפשרותך להוסיף לינקים או קבצים להורדה</p>
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged1"></asp:RadioButtonList>
                                <asp:Panel ID="urlUpload" runat="server" Visible="true">
                                    <asp:TextBox ID="urlTitle"  placeholder="הוסיפו שם לתצוגה" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="urlLink" placeholder="הוסיפו את כתובת ה-URL" runat="server"></asp:TextBox>
                                </asp:Panel>
                                <asp:Panel ID="browserUpload" runat="server" Visible="false">
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                </asp:Panel>
                                <asp:Button ID="uploadApprove" runat="server" Text="שמור" OnClick="uploadApprove_Click" />
                                <asp:Button ID="uploadCancel" runat="server" Text="ביטול" OnClick="uploadCancel_Click" />
                            </asp:Panel>
                        </asp:Panel>
                        <asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="~/myTrees/TempFiles.xml"></asp:XmlDataSource>
                        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="XmlDataSource2" OnItemCommand="Repeater1_ItemCommand">
                            <ItemTemplate>
                                <asp:Panel ID="fileRow" CssClass="fileRow" runat="server">
                                    <asp:ImageButton ID="deleteFile" CssClass="deleteFile" CommandName="deleteFile" theFileId='<%#XPathBinder.Eval(Container.DataItem,"@id")%>' runat="server" ImageUrl="~/generatorElements/deleteicon.png" />
                                    <asp:ImageButton ID="downloadFile" CssClass="downloadFile" CommandName="Download" CommandArgument='<%# Server.UrlDecode(XPathBinder.Eval(Container.DataItem, "fileName").ToString())%>' fileFormat='<%#XPathBinder.Eval(Container.DataItem,"fileFormat")%>' theFileId='<%#XPathBinder.Eval(Container.DataItem,"@id")%>' runat="server" ImageUrl="~/generatorElements/eyeicon.png" />
                                 <asp:Label ID="fileName" runat="server" CssClass="fileName" Text='<%#shorterFileName(Server.UrlDecode(XPathBinder.Eval(Container.DataItem, "fileName").ToString()),Server.UrlDecode(XPathBinder.Eval(Container.DataItem, "fileFormat").ToString()))%>'> </asp:Label>
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Panel ID="disableDiv2" runat="server" Visible="false"></asp:Panel>
                        <asp:Panel ID="deleteFalert" runat="server" Visible="false">
                            <div id="DeleteFdiv">
                                <img class="deleteimagelesson" id="DeleteImage" src="generatorElements/deletobject.png" />
                                <p id="deletetitle1" class="deletelabel Lessondeletebtn">האם ברצונך למחוק שיעור זה?</p>
                                <p id="deletetitle2" class="deletelabel Lessondeletebtn">השיעור יימחק לצמיתות ולא יהיה ניתן לחזור על פעולה זו.</p>
                                <asp:Button ID="deleteApprove" runat="server" Text="בטוח/ה!, כן - מחק" OnClick="deleteApprove_Click"/>
                                <asp:Button ID="deleteCancel" runat="server" Text="התבלבלתי! , לא - חזור" OnClick="deleteCancel_Click"/>
                            </div>
                        </asp:Panel>
                    </div>
                    <div id="settingsBtns">
                        <asp:Button ID="backToCoursePage" runat="server" Text="חזור" value="" PostBackUrl="~/CoursePage.aspx" OnClick="backToCoursePage_Click" />
                        <asp:Button ID="UpadteLesson" runat="server" Text="שמירה" value="" OnClick="UpadteLesson_Click" />

                    </div>
                    <asp:Label ID="forCheck" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
