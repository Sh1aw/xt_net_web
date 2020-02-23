function validateInput(value,container,message,target) {
    if (value.length == 0) {
        spawnAlert(container, message,target);
        return false;
    }
    return true;
}

function CleanDate(date) {
    var r = /([A-z]|\/|\(|\))/g;
    var json = date.replace(r, '');
    return +json;
}

function FormatDate(date) {
    let dates = date.split(".");
    let temp = dates[0];
    dates[0] = dates[2];
    dates[2] = temp;
    return dates.join("-");

}
$("#showContrlPanel").click(function () {
    $(".cntrl_panel").css("display", "block");
    $(".edit_panel").css("display", "none");
});
function spawnAlert(location, message, target) {
    if ($("."+target).length) {
        return;
    }
    $("." + location).append('<div class = "alert alert-danger myalert '+target+'">' + message + '</div>');
    setTimeout(function () {
        $(".myalert").remove();
    }, 5000);
}