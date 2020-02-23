$("#addUserBtn").click(function (e) {
    e.preventDefault();
    e.stopImmediatePropagation();
    var userName = $.trim($("#userName").val());
    var userDob = $.trim($("#userDob").val());
    var userPic = $("#userPic").prop('files')[0];
    var form_data = new FormData();
    form_data.append('uPic', userPic);
    form_data.append('name', userName);
    form_data.append('dob', userDob);
    if (validateInput(userName, "main", "UserName cant be empty", "uname")
        && validateInput(userDob, "main", "Date cant be empty", "udob")) {
        $.ajax({
            type: "POST",
            url: "/Pages/Handlers/UserActionHandler/AddUser",
            data: form_data,
            processData: false,
            contentType: false,
            statusCode: {
                5: function () {
                    alert("Wrong img format");
                },
                7: function(){
                    location.reload();
                },
                8: function(){
                    alert("Invalid user date of birth");
                }
            },
        });
    }

});

$("table").click(function (e) {
    let target = e.target;
    if (target.className != 'delUserBtn') {
        return;
    }
    let surety = confirm("This user will be deleted. Proceed?");
    if (!surety) {
        return;
    }
    let userId = target.parentElement.parentElement.id.split('-')[1];
    $.ajax({
        type: "POST",
        url: "/Pages/Handlers/UserActionHandler/DeleteUser",
        data: { id: userId },
        statusCode: {
            404: function () {
                alert("User does not exist");
            },
        },
        success: function () {
            $("#u-" + userId).remove();
        }
    });
});

$("table").click(function (e) {
    let target = e.target;
    if (target.className != 'editUserBtn') {
        return;
    }
    $(".edit_panel").css('display', 'block');
    let oldName = target.closest("tr").querySelector("[rel = 'name']").textContent;
    let oldDob = target.closest("tr").querySelector("[rel = 'dob']").textContent;
    $("#edit_name").val(oldName);
    $("#edit_dob").val(FormatDate(oldDob));
    let uid = target.closest("tr").id.split('-')[1];
    $("#giveUserSomeAward").attr("uid", uid);
    $("#updateUser").attr("uid", uid);
    $(".cntrl_panel").css("display", "none");
});

$("#giveUserSomeAward").click(function (e) {
    e.preventDefault();
    e.stopImmediatePropagation();
    let userId = e.target.getAttribute("uid");
    let awardId = $(".edit_panel select").val();
    $.ajax({
        type: "POST",
        url: "/Pages/Handlers/UserActionHandler/GiveUserAward",
        data: { uId: userId, aId: awardId },
        statusCode: {
            8: function () {
                alert("Already rewarded");
            },
        },
        success: function (data) {
            var data1 = JSON.parse(data);
            console.log(data1);
            let newAnswer = `<li id=aw-${data1.Id} style="clear: both">
                                        <span>${data1.Name}</span>
                                        <span style="float: right">
                                            <img class="userAwardRemoving" src="/Content/icons/x-circle.svg" width="20" height="20"/>
                                        </span>
                                    </li>`;
            $("#u-" + userId)[0].querySelector('[rel = "awards"] ol').insertAdjacentHTML('beforeend', newAnswer);
        }
    })
});

$("#updateUser").click(function (e) {
    e.preventDefault();
    e.stopImmediatePropagation();
    let userId = e.target.getAttribute("uid");
    var userPic = $("#userPicEdit").prop('files')[0];
    let newName = $.trim($("#edit_name").val());
    let newDob = $("#edit_dob").val();
    if (validateInput(newName, "main", "User name can`t be empty")
        && validateInput(newDob, "main", "Date cant be empty", "udob")) {
        let form_data = new FormData();
        form_data.append('uPic', userPic);
        form_data.append('uid', userId);
        form_data.append('name', newName);
        form_data.append('dob', newDob);
        $.ajax({
            type: "POST",
            url: "/Pages/Handlers/UserActionHandler/UpdateUser",
            data: form_data,
            processData: false,
            contentType: false,
            statusCode: {
                5: function () {
                    alert("Wrong img format");
                },
                7: function(){
                    location.reload();
                }
            },
            // success: function (data) {
            //     var data1 = JSON.parse(data);
            //     $("#u-" + userId)[0].querySelector("[rel = 'name']").textContent = data1.Name;
            //     $("#u-" + userId)[0].querySelector("[rel = 'userPic'] img").setAttribute("src", data1.UserPicPath);
            //     $("#u-" + userId)[0].querySelector("[rel = 'age']").textContent = data1.Age;
            //     $("#u-" + userId)[0].querySelector("[rel = 'dob']").textContent = new Date(CleanDate(data1.DateOfBirth)).toLocaleDateString();
            // }
        });
    }
    $(".edit_panel form")[0].reset();
    e.target.removeAttribute("aid");
    $(".edit_panel").css("display", "none");
});

$("table").click(function (e) {
    let target = e.target;
    if (target.className != 'userAwardRemoving') {
        return;
    }
    let surety = confirm("This user will lose this reward. Proceed?");
    if (!surety) {
        return;
    }
    let awardId = target.closest('li').id.split('-')[1];
    let userId = target.closest('tr').id.split('-')[1];
    $.ajax({
        type: "POST",
        url: "/Pages/Handlers/UserActionHandler/RemoveUserAward",
        data: { uId: userId, aId: awardId },
        success: function () {
            target.closest('li').remove();
        }
    });
});