var DataTable;
$(document).ready(function () {
    loadDataTable();
    
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/Students/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            
            { "data": "userId", "width": "20%" },
            { "data": "stdName", "width": "20%" },
            { "data": "stdPassword", "width": "20%" },
            { "data": "stdEmail", "width": "20%" },
            { "data": "stdPhone", "width": "20%" },
            { "data": "stdAddress", "width": "20%" },
            { "data": "stdSection", "width": "5%" },

            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                <a href="/Students/Upsert?id=${data}" class='btn btn-success text-white'
                            style='cursor:pointer; width:100px;'>Edit</a>

                            </div>
                            &nbsp;
                <a class='btn btn-danger text-white'
                            style='cursor:pointer; width:100px;'
                            onclick=Delete('/Students/Delete?id='+${data})>Delete</a>
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