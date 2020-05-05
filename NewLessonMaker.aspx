<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewLessonMaker.aspx.cs" Inherits="_NewLessonMaker" %>


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
            <div id="LessonMakerPage">

                <div id="editNav">
                    <asp:Button ID="EditTab" runat="server" Text="עריכה" />
                    <asp:Button ID="TreeTab" runat="server" Text="עץ הסתעפות" />
                </div>
                <div id="editArea">

                    <asp:Panel ID="editScreen" runat="server">
                        <div id="mainEditScreen">
                            <h2 class="lessonedittitle">שם השיעור - </h2>
                            <asp:Label ID="LessonTitle" runat="server" Text="Label"></asp:Label>
                            <asp:Button ID="backToCoursePage" runat="server" Text="חזור" />
                            <div id="changingInteraction">
                                <asp:Panel ID="upload" runat="server">
                                    <p class="editinstructions">גררו לציר הזמן בתחתית המסך את קובץ האודיו או לחצו כאן</p>
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                    <asp:Button ID="ConfirmBtn" runat="server" Text="אישור" OnClick="ConfirmBtn_Click" />
                                    <asp:Label ID="forCheck" runat="server" Text="Label"></asp:Label>
                                </asp:Panel>
                                <asp:Panel ID="branchInteraction" runat="server">
                                    <p>לאחר כתיבת השאלה והמסיחים יש להזין את זמני ההסתעפות</p>
                                    <p>שאלה <span>עד X תווים</span></p>
                                    <asp:TextBox ID="BranchQ" runat="server"></asp:TextBox>
                                    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                                    <table>
                                        <tr>
                                            <th></th>
                                            <th>מסיחים <span>עד X תווים</span></th>
                                            <th>התחלה</th>
                                            <th>סיום</th>
                                            <th>סוף הסתעפות</th>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="BranchAns1" CssClass="BranchAns" runat="server"></asp:TextBox>
                                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="BranchStart1" CssClass="BranchStart" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="BranchEnd1" CssClass="BranchEnd" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="BranchFinal1" CssClass="BranchFinal" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="BranchAns2" CssClass="BranchAns" runat="server"></asp:TextBox>
                                                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="BranchStart2" CssClass="BranchStart" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="BranchEnd2" CssClass="BranchEnd" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="BranchFinal2" CssClass="BranchFinal" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="ImageButton2" runat="server" /></td>
                                            <td>
                                                <asp:TextBox ID="BranchAns3" CssClass="BranchAns" runat="server"></asp:TextBox>
                                                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="BranchStart3" CssClass="BranchStart" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="BranchEnd3" CssClass="BranchEnd" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="BranchFinal3" CssClass="BranchFinal" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="ImageButton3" runat="server" /></td>
                                            <td>
                                                <asp:TextBox ID="BranchAns4" CssClass="BranchAns" runat="server"></asp:TextBox>
                                                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="BranchStart4" CssClass="BranchStart" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="BranchEnd4" CssClass="BranchEnd" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="BranchFinal4" CssClass="BranchFinal" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="choiceInteraction" runat="server">
                                    <p>סמנו אילו תשובות נכונות בעזרת הכפתור מימין למסיח, ניתן לסמן יותר מתשובה אחת</p>
                                    <div id="ChoiceQuestion">
                                        <p>שאלה <span>עד X תווים</span></p>
                                        <asp:TextBox ID="ChoiceQ" runat="server"></asp:TextBox>
                                        <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                                    </div>
                                    <div id="coiceAnswers">
                                        <p>מסיחים <span>עד X תווים</span></p>
                                        <div>
                                            <asp:ImageButton ID="ImageButton4" runat="server" />
                                            <asp:TextBox ID="ChoiceAns1" CssClass="ChoiceAns" runat="server"></asp:TextBox>
                                            <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                                        </div>
                                        <div>
                                            <asp:ImageButton ID="ImageButton5" runat="server" />
                                            <asp:TextBox ID="ChoiceAns2" CssClass="ChoiceAns" runat="server"></asp:TextBox>
                                            <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                                        </div>
                                        <div>
                                            <asp:ImageButton ID="ImageButton6" runat="server" />
                                            <asp:TextBox ID="ChoiceAns3" CssClass="ChoiceAns" runat="server"></asp:TextBox>
                                            <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
                                        </div>
                                        <div>
                                            <asp:ImageButton ID="ImageButton7" runat="server" />
                                            <asp:TextBox ID="ChoiceAns4" CssClass="ChoiceAns" runat="server"></asp:TextBox>
                                            <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                                        </div>
                                        <div>
                                            <asp:ImageButton ID="ImageButton8" runat="server" />
                                            <asp:TextBox ID="ChoiceAns5" CssClass="ChoiceAns" runat="server"></asp:TextBox>
                                            <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
                                        </div>
                                        <div>
                                            <asp:ImageButton ID="ImageButton9" runat="server" />
                                            <asp:TextBox ID="ChoiceAns6" CssClass="ChoiceAns" runat="server"></asp:TextBox>
                                            <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="matchInteraction" runat="server">
                                    <p>מלאו את הקטגרויות ולאחר מכן את המסיחים המתאימים בכל אחת מהן</p>
                                    <div id="matchQuestion">
                                        <p>שאלה <span>עד X תווים</span></p>
                                        <asp:TextBox ID="MatchQ" runat="server"></asp:TextBox>
                                        <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
                                    </div>
                                    <div id="categories">
                                        <div id="category1">
                                            <p>קטגוריה א' <span>עד X תווים</span></p>
                                            <asp:TextBox ID="MatchCatA" runat="server"></asp:TextBox>
                                            <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
                                            <div id="category1Items">
                                                <p>מסיחים א' <span>עד X תווים</span></p>
                                                <asp:TextBox ID="MatchCatAans1" CssClass="MatchCatAans" runat="server"></asp:TextBox>
                                                <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>
                                                <asp:TextBox ID="MatchCatAans2" CssClass="MatchCatAans" runat="server"></asp:TextBox>
                                                <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
                                                <asp:TextBox ID="MatchCatAans3" CssClass="MatchCatAans" runat="server"></asp:TextBox>
                                                <asp:Label ID="Label18" runat="server" Text="Label"></asp:Label>
                                                <asp:TextBox ID="MatchCatAans4" CssClass="MatchCatAans" runat="server"></asp:TextBox>
                                                <asp:Label ID="Label19" runat="server" Text="Label"></asp:Label>
                                                <asp:TextBox ID="MatchCatAans5" CssClass="MatchCatAans" runat="server"></asp:TextBox>
                                                <asp:Label ID="Label25" runat="server" Text="Label"></asp:Label>
                                            </div>
                                        </div>
                                        <div id="category2">
                                            <p>קטגוריה א' <span>עד X תווים</span></p>
                                            <asp:TextBox ID="MatchCatB" runat="server"></asp:TextBox>
                                            <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
                                            <div id="category2Items">
                                                <p>מסיחים א' <span>עד X תווים</span></p>
                                                <asp:TextBox ID="MatchCatB1" CssClass="MatchCatBans" runat="server"></asp:TextBox>
                                                <asp:Label ID="Label20" runat="server" Text="Label"></asp:Label>
                                                <asp:TextBox ID="MatchCatB2" CssClass="MatchCatBans" runat="server"></asp:TextBox>
                                                <asp:Label ID="Label21" runat="server" Text="Label"></asp:Label>
                                                <asp:TextBox ID="MatchCatB3" CssClass="MatchCatBans" runat="server"></asp:TextBox>
                                                <asp:Label ID="Label22" runat="server" Text="Label"></asp:Label>
                                                <asp:TextBox ID="MatchCatB4" CssClass="MatchCatBans" runat="server"></asp:TextBox>
                                                <asp:Label ID="Label23" runat="server" Text="Label"></asp:Label>
                                                <asp:TextBox ID="MatchCatB5" CssClass="MatchCatBans" runat="server"></asp:TextBox>
                                                <asp:Label ID="Label24" runat="server" Text="Label"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="orderInteraction" runat="server">
                                    <p>מלאו את כל המסיחים על פי הסדר הנכון, המערכת תציג אותם בסדר אקראי</p>
                                    <div id="orderQuestion">
                                        <p>שאלה <span>עד X תווים</span></p>
                                        <asp:TextBox ID="TextBox39" runat="server"></asp:TextBox>
                                        <asp:Label ID="Label26" runat="server" Text="Label"></asp:Label>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="rulerInteraction" runat="server"></asp:Panel>
                                <asp:Panel ID="openInteraction" runat="server"></asp:Panel>
                            </div>
                            <div id="interactionButtons">
                                <asp:Button ID="Button1" runat="server" Text="אפס" />
                                <asp:Button ID="Button2" runat="server" Text="החל" />
                            </div>
                        </div>
                        <div id="LeftPanelInteractions">
                            <div id="interactionsNav">
                                <table>
                                    <tr>
                                        <td id="branchTd">
                                            <div id="branchIcon"></div>
                                            <asp:Button ID="branchBtn" runat="server" Text="הסתעפות" OnClick="branchBtn_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="choiceTd">
                                            <div id="chiceIcon"></div>
                                            <asp:Button ID="cohiceBtn" runat="server" Text="ברירה" OnClick="cohiceBtn_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="matchTd">
                                            <div id="matchIcon"></div>
                                            <asp:Button ID="matchBtn" runat="server" Text="התאמה" OnClick="matchBtn_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="orderTd">
                                            <div id="orderIcon"></div>
                                            <asp:Button ID="orderBtn" runat="server" Text="סדר" OnClick="orderBtn_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="rulerTd">
                                            <div id="rulerIcon"></div>
                                            <asp:Button ID="rulerBtn" runat="server" Text="סרגל" OnClick="rulerBtn_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="openTd">
                                            <div id="openIcon"></div>
                                            <asp:Button ID="openBtn" runat="server" Text="פתוחה" OnClick="openBtn_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="timePointDiv">
                                <p>נקודת זמן נוכחית</p>
                                <asp:TextBox ID="CurrentTime" runat="server" Text="00:00"></asp:TextBox>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="branchScreen" runat="server"></asp:Panel>
                </div>
                <div id="ProgressArea">
                    <div id="progressbar"></div>
                    <asp:ImageButton ID="PlayButtonEdit" runat="server" ImageUrl="~/generatorElements/playicon.png" />
                </div>
            </div>

        </form>
    </div>
</body>
</html>
