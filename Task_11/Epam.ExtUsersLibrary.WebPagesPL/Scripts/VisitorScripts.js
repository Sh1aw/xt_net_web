$("table").click(function (e) {
    let target = e.target;
    if (target.className!="changeRole") {
        return;
    }
    let visitorId = target.closest("tr").id.split('-')[1];
    $.ajax({
        type: "POST",
        url: "/Pages/Handlers/VisitorActionHandler/SwitchRole",
        data: { vid:visitorId },
        statusCode: {
            400: function () {
                alert("Visitor was deleted/or not found");
            },
        },
        success: function (data) {
            location.reload();
        }
    });
});