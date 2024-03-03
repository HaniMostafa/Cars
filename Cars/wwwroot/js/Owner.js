var dataTable
$(document).ready(function () {
    loadDataTable();

});

function loadDataTable() {
    dataTable = $('#tbldata').DataTable({
        "ajax": { url: '/Admin/Owner/GetAll' },
        "columns": [
            {
                data: 'image', "Width": "25%", "render": function (data) {
                    return `<img src="${data}" alt="Owner Image" style="max-width: 100px; max-height: 100px;">`;
                }
            },
            { data: 'name', "Width": "15%" },
            { data: 'phone', "Width": "15%" },
            {
                data: 'faceBookUrl', "Width": "10%", "render": function (data) {
                    return `<span class="d-inline-block text-truncate" style="max-width: 100px;" title="${data}">${data}</span>`;
                }
            },
            {
                data: 'instigram', "Width": "10%", "render": function (data) {
                    return `<span class="d-inline-block text-truncate" style="max-width: 100px;" title="${data}">${data}</span>`;
                }
            },
            {
                data: 'olx', "Width": "10%", "render": function (data) {
                    return `<span class="d-inline-block text-truncate" style="max-width: 100px;" title="${data}">${data}</span>`;
                }
            },
            {
                data: 'gps', "Width": "10%", "render": function (data) {
                    return `<span class="d-inline-block text-truncate" style="max-width: 100px;" title="${data}">${data}</span>`;
                }
            },
            {
                data: 'id', "render": function (data) {
                    return `<div class="btn-group" role="group">
                        <a href="/admin/Owner/upsert?id=${data}" class="btn btn-primary mx-2">
                            <i class="bi bi-pencil-square"></i> Edit
                        </a>
                        <a onClick=Delete("/admin/Owner/Delete/${data}") class="btn btn-danger mx-2">
                            <i class="bi bi-trash-fill"></i> Delete
                        </a>
                    </div>`;
                },
                "Width": "15%"
            }
        ]
    });
}


function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'delete',
                success: function (data) {
                    dataTable.ajax.reload();
                    toaster.success(data.message);

                }
            })

        }
    });
}