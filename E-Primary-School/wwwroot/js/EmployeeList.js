var DataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/Employees/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "userId", "width": "20%" },
            { "data": "empName", "width": "20%" },
            { "data": "empEmail", "width": "20%" },
            { "data": "empPhoneNumber", "width": "20%" },
            { "data": "empSalary", "width": "20%" },
            { "data": "userType", "width": "20%" },

            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                <a href="/BookList/Edit?id=${data}" class='btn btn-success text-white'
                            style='cursor:pointer; width:100px;'>Edit</a>

                            </div>
                            &nbsp;
                <a class='btn btn-danger text-white'
                            style='cursor:pointer; width:100px;'>Delete</a>
                            </div> `;
                }, "width": "50%"
            }
        ], "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}