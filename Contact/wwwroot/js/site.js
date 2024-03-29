﻿// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function DataTableClick() {
    $('table tbody tr').click(function () {
        $(this).siblings().css("background", "").removeClass("rowselect");
        $(this).addClass("rowselect");
    });
}
$(function () {
    $(".table-datatable").DataTable({
        "responsive": true,
        "lengthChange": false,
        "autoWidth": false,
        "pageLength":10
    });
    //$('#example2').DataTable({
    //    "paging": true,
    //    "lengthChange": false,
    //    "searching": false,
    //    "ordering": true,
    //    "info": true,
    //    "autoWidth": false,
    //    "responsive": true,
    //});
});
String.isNullOrEmpty = function (value) {
    return (!value || value == undefined || value == "" || value.length == 0);
}