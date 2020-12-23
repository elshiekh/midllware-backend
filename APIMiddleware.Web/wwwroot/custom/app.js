$(document).ready(function () {
   var table =  $("#test-registers").DataTable({
        autowidth: true,
        processing: true,
        serverside: true,
        paging: true,
        searching: { regex: true },
        ajax: {
            url: "/Request/LoadTable",
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            data: function (data) {
                return JSON.stringify(data);
            }
        },
        columns: [
            { data: "id" ,visible:false },
            { data: "projectName" },
            { data: "path" },
            { data: "method" },
            { data: "date" },
            { data: "time" },
            { data: "elapsedMilliseconds" },
            { data: "statusCode" },
            {
                data: "isSuccess",
                render: function (data, type, row) {
                    return `<span style="color: green;">${data}</span>`;
                }
            },
            {
                data: null,
                className: "center",
                defaultContent: '<a href="" class="editor_detail">Details</a>'
            }
        ]
    });

    // Edit record
    $('#test-registers').on('click', 'a.editor_detail', function (e) {
        e.preventDefault();
        var row_clicked = $(this).closest('tr');
        var row_object = table.row(row_clicked).data();
        var requestId = row_object.id;
        var url = "/Request/Details?id=" + requestId;
        location.href = url;
    });
});