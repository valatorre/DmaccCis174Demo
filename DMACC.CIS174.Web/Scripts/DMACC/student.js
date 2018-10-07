function searchStudent() {
    var search = $("#searchString").val();

    $.ajax({
        url: "Search",
        data: { searchString: search }
    }).done(function(data) {
        $("#studentId").val(data.StudentId);
        $("#studentName").val(data.StudentName);
        $("#studentHeight").val(data.Height);
        $("#studentWeight").val(data.Weight);
    });
}

function updateStudent() {
    var studentId = $("#studentId").val();
    var studentName = $("#studentName").val();
    var height = $("#studentHeight").val();
    var weight = $("#studentWeight").val();

    $.ajax({
        url: "UpdateStudent",
        dataType: "json",
        data: {
            StudentId: studentId,
            StudentName: studentName,
            Height: height,
            Weight: weight
        }
    }).done(function(data) {
        if (data) {
            $("#successMessage").removeClass("hidden")
                .addClass("visible");
        } else {
            $("#errorMessage").removeClass("hidden")
                .addClass("visible");
        }
    });
}