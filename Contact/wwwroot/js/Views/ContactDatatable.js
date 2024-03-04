$(document).ready(function () {
    $('#Contacts').dataTable({
        "processing": true,
        "serverSide": true,
        "saveState": true,
        "filter": true,
        "ajax": {
            "url": "/api/RealContact",
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs": [{
            "targets": [0],
            "visible": false,
            "searchable": false
        }],
        "columns": [
            { "data": "concod", "name": "Id", "autowidth": true },
            { "data": "name", "name": "Contact Name", "autowidth": true },
            { "data": "phone", "name": "Phone", "autowidth": true },
            { "data": "address", "name": "Address", "autowidth": true },
            { "data": "note", "name": "Note", "autowidth": true },
            //{ "data": "dateOfBirth", "name": "DateOfBirth", "autowidth": true },
            //{
            //    "render": function (data, type, row) { return '<span>' + row.dateOfBirth.split('T')[0] + '</span>' },
            //    "name": "DateOfBirth"
            //},
            {
                "render": function (data, type, row) { return '<a href="#" class="btn btn-danger" onclick=DeleteCustomer("' + row.concod + '"); > Delete </a>' },
                "orderable": false
            },

        ],
        "initComplete": function () {
            // Hide preloader after DataTable initialization
            $('.preloader').fadeOut();
        }
    });
});