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
                <a href="/employees/insertEmployee?id=${data}" class='btn btn-success text-white'
                            style='cursor:pointer; width:100px;'>Edit</a>

                            </div>
                            &nbsp;
                <a class='btn btn-danger text-white'
                   style='cursor:pointer; width:100px;'
                   onclick=Delete('/employees/Delete?id='+${data})>Delete</a>
                            </div> `;
                }, "width": "50%"
            }
        ], "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}
function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}