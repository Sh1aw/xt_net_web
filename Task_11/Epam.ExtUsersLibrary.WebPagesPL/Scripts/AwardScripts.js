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
            url: "/Pages/Handlers/AwardActionHandler/AddAward",
            processData: false,
            contentType: false,
            data: form_data,
            statusCode: {
                5: function () {
                    alert("Wrong img format");
                },
                7: function(){
                    location.reload();
                }
            },
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
            url: "/Pages/Handlers/AwardActionHandler/UpdateAward",
            data: form_data,
            processData: false,
            contentType: false,
            statusCode: {
                4: function () {
                    alert("Error, this award was removed, or not created");
                },
                6: function () {
                    alert("Wrong img format");
                },
                7: function() {
                    location.reload();
                }
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
        url: "/Pages/Handlers/AwardActionHandler/DeleteAward",
        dataType: "json",
        data: { aid: awardId },
        statusCode: {
            6: function (data) {
                var data1 = JSON.stringify(data.responseJSON);
                if (confirm("Some users already have this award. " +
                    "If you wana continie deleting, this users lose this award!")) {
                    $.ajax({
                        type: "POST",
                        url: "/Pages/Handlers/AwardActionHandler/DisAward",
                        data: { aid: awardId, uids: data1 },
                        success: function () {
                            $("#a-" + awardId).remove();
                        }
                    });
                }
            },
            200:function () {
                $("#a-" + awardId).remove();
            }
        },
        success: function () {
            $("#a-" + awardId).remove();
        }
    });
});