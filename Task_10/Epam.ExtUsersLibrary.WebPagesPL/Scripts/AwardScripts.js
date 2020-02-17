$("#addAwardBut").click(function (e) {
    e.preventDefault();
    e.stopImmediatePropagation();
    let awardName = $.trim($("#nameAward").val());;
    let awardPic = $("#awardPic").prop('files')[0];
    var form_data = new FormData();
    form_data.append('aPic', awardPic);
    form_data.append('name', awardName);
    if (validateInput(awardName, 'main', 'Award name can`t be empty!')) {
        $.ajax({
            type: "POST",
            url: "/Pages/Controllers/AwardController/AddAwardController",
            processData: false,
            contentType: false,
            data: form_data,
            statusCode: {
                5: function () {
                    alert("Wrong img format");
                },
            },
            success: function (data) {
                var data1 = JSON.parse(data);
                var answer = `<tr id=a-${data1.Id} class="d-flex">
                                    <td class="col-1">${data1.Id}</td>
                                    <td class="col-2" rel="awardPic"><img src="${data1.PicPath}" width="50" height="50" /></td>
                                    <td class="col-5" rel="name">${data1.Name}</td>
                                    <td class="col-2"><img class="editUserBtn" src="/Content/icons/pencil.svg"></td>
                                    <td class="col-2"><img class="delUserBtn" src="/Content/icons/x-circle.svg"></td>
                                  </tr>`;
                $("table").append(answer);
            }
        });
    }
    $(".cntrl_panel form")[0].reset();
});
$("#showContrlPanel").click(function () {
    $(".cntrl_panel").css("display", "block");
    $(".edit_panel").css("display", "none");
});
$("table").click(function (e) {
    let target = e.target;
    if (target.className != 'editUserBtn') {
        return;
    }
    $(".edit_panel").css('display', 'block');
    let oldName = target.closest('tr').querySelector("[rel = 'name']").textContent;
    $("#edit_name").val(oldName);
    let aid = target.closest('tr').id.split('-')[1];
    $("#updateAward").attr("aid", aid);
    $(".cntrl_panel").css("display", "none");
});

$("#updateAward").click(function (e) {
    e.preventDefault();
    e.stopImmediatePropagation();
    let awardId = e.target.getAttribute("aid");
    let newName = $.trim($("#edit_name").val());
    var awardPic = $("#awardPicEdit").prop('files')[0];
    if (validateInput(newName, "main", "Award name can`t be empty")) {
        var form_data = new FormData();
        form_data.append('aPic', awardPic);
        form_data.append('aid', awardId);
        form_data.append('name', newName);
        $.ajax({
            type: "POST",
            url: "/Pages/Controllers/AwardController/UpdateAwardController",
            data: form_data,
            processData: false,
            contentType: false,
            statusCode: {
                4: function () {
                    alert("Error, this award was removed, or not created");
                },
                5: function () {
                    alert("Wrong img format");
                },
            },
            success: function (data) {
                var data1 = JSON.parse(data);
                $("#a-" + awardId)[0].querySelector("[rel = 'name']").textContent = data1.Name;
                $("#a-" + awardId)[0].querySelector("[rel = 'awardPic'] img").setAttribute("src", data1.PicPath);
            }
        });
    }
    $(".edit_panel form")[0].reset();
    e.target.removeAttribute("aid");
    $(".edit_panel").css("display", "none");
});

$("table").click(function (e) {
    let target = e.target;
    if (target.className != 'delUserBtn') {
        return;
    }
    let surety = confirm("This award will be deleted. Proceed?");
    if (!surety) {
        return;
    }
    let awardId = target.closest("tr").id.split('-')[1];
    $.ajax({
        type: "POST",
        url: "/Pages/Controllers/AwardController/DeleteAwardController",
        dataType: "json",
        data: { aid: awardId },
        statusCode: {
            6: function (data) {
                var data1 = JSON.stringify(data.responseJSON);
                if (confirm("Some users already have this award. If you wana continie deleting, this users lose this award!")) {
                    $.ajax({
                        type: "POST",
                        url: "/Pages/Controllers/AwardController/DisAwardController",
                        data: { aid: awardId, uids: data1 },
                        success: function () {
                            $("#a-" + awardId).remove();
                        }
                    });
                }
            },
        },
        complete: function () {
            $("#a-" + awardId).remove();
        }
    });
});