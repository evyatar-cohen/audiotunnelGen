
$(document).ready(function () {

    $(".visibleCB").click(function (e) {

        notRealCBid = e.currentTarget.id;
        var lastChar = notRealCBid[notRealCBid.length - 1];
        console.log(lastChar);
        var realCB = document.getElementById("GridView1_PublishedCheckBox_" + lastChar);
        if (realCB.checked == true) {
            realCB.checked = false;
        }
        else {
            realCB.checked = true;
        }
    });

    $(".countLogin").keyup(function () {
        checkLogin(); //קריאה לפונקציה שבודקת את מספר התווים
    });

    //בהעתקה של תוכן לתיבת הטקסט
    $(".countLogin").on("paste", function () {
        checkLogin();//קריאה לפונקציה שבודקת את מספר התווים
    });

    $(".countLogin").change(function () {
        checkLogin();//קריאה לפונקציה שבודקת את מספר התווים
    });

    $(".CharacterCount").keyup(function () {
        checkCharacter($(this)); //קריאה לפונקציה שבודקת את מספר התווים
        checkSettings();
    });

    //בהעתקה של תוכן לתיבת הטקסט
    $(".CharacterCount").on("paste", function () {
        checkCharacter($(this));//קריאה לפונקציה שבודקת את מספר התווים
        checkSettings();
    });

    $(".CharacterCount").change(function () {
        checkSettings();//קריאה לפונקציה שבודקת את מספר התווים
    });


    $(".LessonCount").keyup(function () {
        checkCharacter($(this)); //קריאה לפונקציה שבודקת את מספר התווים
        checkLessonSettings();
    });

    //בהעתקה של תוכן לתיבת הטקסט
    $(".LessonCount").on("paste", function () {
        checkCharacter($(this));//קריאה לפונקציה שבודקת את מספר התווים
        checkLessonSettings();
    });

    $(".LessonCount").change(function () {
        checkCharacter($(this));//קריאה לפונקציה שבודקת את מספר התווים
        checkLessonSettings();
    });



    function checkLogin() {
        if (document.getElementById("userTb").value === "" || document.getElementById("passwordTb").value === "") {
            document.getElementById("userBtn").setAttribute('disabled', 'disabled');
            document.getElementById("userBtn").style.opacity = "0.3";
        }
        else {
            document.getElementById("userBtn").removeAttribute('disabled', 'disabled');
            document.getElementById("userBtn").style.opacity = "1";
        }

    }

    function checkSettings() {
        if (document.getElementById("courseNameTB").value === "" || document.getElementById("courseDescriptionTB").value === "") {
            if (document.getElementById("saveCourse")) {
                document.getElementById("saveCourse").setAttribute('disabled', 'disabled');
                document.getElementById("saveCourse").style.opacity = "0.3";
            }
            else {
                document.getElementById("UpadteCourse").setAttribute('disabled', 'disabled');
                document.getElementById("UpadteCourse").style.opacity = "0.3";
            }

        }
        else {
            if (document.getElementById("saveCourse")) {
                document.getElementById("saveCourse").removeAttribute('disabled', 'disabled');
                document.getElementById("saveCourse").style.opacity = "1";
            }

            else {
                document.getElementById("UpadteCourse").removeAttribute('disabled', 'disabled');
                document.getElementById("UpadteCourse").style.opacity = "1";
            }

        }

    }

    function checkLessonSettings() {
        console.log("lessonSettings");
        if (document.getElementById("LessonNameTB").value === "" || document.getElementById("LessonDescriptionTB").value === "") {
            if (document.getElementById("UpadteLesson")) {
                document.getElementById("UpadteLesson").setAttribute('disabled', 'disabled');
                document.getElementById("UpadteLesson").style.opacity = "0.3";
            }
            else {
                console.log("savelesson");
                document.getElementById("saveLesson").setAttribute('disabled', 'disabled');
                document.getElementById("saveLesson").style.opacity = "0.3";
            }


        }
        else {
            if (document.getElementById("UpadteLesson")) {
                document.getElementById("UpadteLesson").removeAttribute('disabled', 'disabled');
                document.getElementById("UpadteLesson").style.opacity = "1";
            }
            else {
                document.getElementById("saveLesson").removeAttribute('disabled', 'disabled');
                document.getElementById("saveLesson").style.opacity = "1";
            }

        }

    }




    function checkCharacter(myTextBox) {

        //משתנה למספר התווים הנוכחי בתיבת הטקסט
        var countCurrentC = myTextBox.val().length;

        //משתנה המקבל את מספר תיבת הטקסט 
        var itemNumber = myTextBox.attr("item");

        //משתנה המכיל את מספר התווים שמוגבל לתיבה זו
        var CharacterLimitNum = myTextBox.attr("CharacterLimit");


        if (itemNumber == 1) {
            if (countCurrentC > 30) {
                if (countCurrentC < 50) {
                    document.getElementById("LabelCounter1").style.color = "orange";
                }
                else {
                    document.getElementById("LabelCounter1").style.color = "red";
                }


            }
            else {
                document.getElementById("LabelCounter1").style.color = "green";
            }

            //בדיקה האם ישנה חריגה במספר התווים
            if (countCurrentC > CharacterLimitNum) {

                //מחיקת התווים המיותרים בתיבה
                myTextBox.val(myTextBox.val().substring(0, CharacterLimitNum));
                //עדכון של מספר התווים הנוכחי
                countCurrentC = CharacterLimitNum;

            }
        }

        else {
            if (itemNumber == 2) {
                if (countCurrentC > 170) {
                    if (countCurrentC < 190) {
                        document.getElementById("LabelCounter2").style.color = "orange";
                    }
                    else {
                        document.getElementById("LabelCounter2").style.color = "red";
                    }


                }
                else {
                    document.getElementById("LabelCounter2").style.color = "green";
                }

                //בדיקה האם ישנה חריגה במספר התווים
                if (countCurrentC > CharacterLimitNum) {

                    //מחיקת התווים המיותרים בתיבה
                    myTextBox.val(myTextBox.val().substring(0, CharacterLimitNum));
                    //עדכון של מספר התווים הנוכחי
                    countCurrentC = CharacterLimitNum;

                }
            }
        }


        //הדפסה כמה תווים הוקלדו מתוך כמה
        $("#LabelCounter" + itemNumber).text(countCurrentC);
    }

    $("#FileUploadLogo").change(function () {
        if (this.files && this.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#forImageDisplay').click();
            };
            reader.readAsDataURL(this.files[0]);
        }
    });

});

function openFileUploader() {
    $('#FileUploadLogo').click();
}

function deleteLogo_Click() {
    $('#ImageforFileUploadLogo').attr('src', "/generatorElements/uploadlogo.png");
    document.getElementById("checkDeleteLogo").checked = false;


}

function openLessonFileUploader() {
    $('#browseUpload').click();
}

function displayFiles() {
    var inputedFiles = document.getElementById("browseUpload").files;
    console.log(document.getElementById("browseUpload").files.length);

    for (var i = 0; i < inputedFiles.length; i++) {

    }
    //var filesNameList=
}


function urlList() {
    var urlLink = document.getElementById("urlLink").value;

    var fileRow = document.createElement("DIV");
    fileRow.classList.add("fileRow");
    var urlText = document.createElement("P");
    urlText.innerHTML = document.getElementById("urlTitle").value;
    urlText.classList.add("urlText");
    fileRow.appendChild(urlText);

    var eyeIcon = document.createElement("DIV");
    eyeIcon.classList.add("fileEyeIcon");
    console.log(urlLink, "window.open('" + urlLink + "','_blank'");
    eyeIcon.setAttribute('onclick', "window.open('" + urlLink + "', '_blank')");
    fileRow.appendChild(eyeIcon);

    var trashIcon = document.createElement("DIV");
    trashIcon.classList.add("fileTrashIcon");
    fileRow.appendChild(trashIcon);

    document.getElementById("filesList").appendChild(fileRow);

    document.getElementById("disableDiv").style.visibility = 'hidden';
    document.getElementById("urlUplaodAlert").style.visibility = 'hidden';
}

function urlCancel_Click() {

    $("#disableDiv").style.visibility = 'hidden';
    $("#urlUplaodAlert").style.visibility = 'hidden';
}

function urlUploadImageButton_Click() {
    document.getElementById("disableDiv").style.visibility = 'visible';
    document.getElementById("urlUplaodAlert").style.visibility = 'visible';
}
