var dataTable
$(document).ready(function () {
    loadDataTable();

});
function loadDataTable() {
    dataTable = $('#tbldata').DataTable({
        "ajax": { url: '/Admin/Car/GetAll' },
        "columns": [
            { data: 'title', "Width": "25%" },
            { data: 'kilometer', "Width": "15%" },
            { data: 'year', "Width": "10%" },
            { data: 'trim', "Width": "20%" },
            { data: 'numberOfDoors', "Width": "15%" },
            { data: 'numberCylinders', "Width": "15%" },
            { data: 'bodyType', "Width": "15%" },
            { data: 'color', "Width": "15%" },
            { data: 'kindOfCar.name', "Width": "15%" },
            {
                data: 'id', "render": function (data) {

                    return `<div class="w-75 btn-group" role="group">
                     <a href="/admin/Car/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Edit</a>
                     <a onClick=Delete("/admin/Car/Delete/${data}") class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
                    </div>`
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