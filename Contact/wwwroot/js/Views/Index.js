"use strict"
var EditeCod = 0;
$(document).ready(function () {
	LoadTableData();
});

function LoadTableData() {
	$.ajax({
		url: "/Home/_Contact",
		type: 'Get',
		contentType: 'application/json',
		success: function (result) {
			$('#Div_table').html(result);
			DataTableClick();
			$("#conTable").DataTable({
				"responsive": true,
				"lengthChange": false,
				"autoWidth": false,
				"pageLength": 10,
				select: true
			});
		},
		error: function (data) {

		}
	}).done(function () {
		$('.preloader').fadeOut(); 
		connection.invoke("CheckEdite").catch(function (error) {
			return console.error(error);
		});
	})
}
function New() {
	$(".Validation").addClass("hide");
	var Name = $('#Name').val('');
	var Phone = $('#Phone').val('');
	var Address = $('#Address').val('');
	var Note = $('#Note').val('');
	$("#AddData").modal('show');
}
function ADD() {
	$(".Validation").addClass("hide");
	var Name = $('#Name').val();
	var Phone = $('#Phone').val();
	var Address = $('#Address').val();
	var Note = $('#Note').val();
	var valid = true;
	if (String.isNullOrEmpty(Name)) {
		valid = false;
		$("#NameErr").removeClass("hide");
	}

	if (String.isNullOrEmpty(Phone)) {
		valid = false;
		$("#PhoneErr").removeClass("hide");
	}

	if (String.isNullOrEmpty(Address)) {
		valid = false;
		$("#AddressErr").removeClass("hide");
	}

	var Contact = {
		Concod: EditeCod,
		Name: Name,
		Phone: Phone,
		Address: Address,
		Note: Note
	};
	if (valid) {
		if (EditeCod == 0) {
			$.ajax({
				type: "POST",
				url: '/Home/ADDContact/',
				data: JSON.stringify(Contact),
				contentType: "application/json; charset=utf-8",
				dataType: 'json',
				async: true,
				success: function (data) {
					$('#AddData').modal('hide');
					LoadTableData();
				},
				error: function () {

				}
			});

		} else {
			$.ajax({
				type: "POST",
				url: '/Home/UPDContact/',
				data: JSON.stringify(Contact),
				contentType: "application/json; charset=utf-8",
				dataType: 'json',
				async: true,
				success: function (data) {
					$('#AddData').modal('hide');
					EditeCod = 0;
					LoadTableData();
				},
				error: function () {

				}
			});
		}
	}

}
function Close() {
	$("#AddData").modal('hide');
}
function RowSelect(ConCod) {
	connection.invoke("RowSelect", ConCod).catch(function (error) {
		return console.error(error);
	});
}
function Edite(ConCod) {
	//connection.invoke("RowEdite", ConCod).catch(function (error) {
	//    return console.error(error);
	//});

	$.ajax({
		type: "GET",
		url: '/Home/GetContact/',
		data: {
			ConCod: ConCod
		},
		contentType: "application/json; charset=utf-8",
		dataType: 'json',
		async: true,
		success: function (data) {
			$(".Validation").addClass("hide");
			EditeCod = data.concod;
			$('#concod').val(data.concod);
			$('#Name').val(data.name);
			$('#Phone').val(data.phone);
			$('#Address').val(data.address);
			$('#Note').val(data.note);
			$("#AddData").modal('show');
		},
		error: function () {

		}
	});
}
function Delete(ConCod) {
	var name = '';
	$.ajax({
		type: "GET",
		url: '/Home/GetContact/',
		data: {
			ConCod: ConCod
		},
		contentType: "application/json; charset=utf-8",
		dataType: 'json',
		async: true,
		success: function (data) {
			name = data.name;
			if (confirm("do you wanna delete ( " + name + " )")) {
				$.ajax({
					type: "GET",
					url: '/Home/DelContact/',
					data: {
						ConCod: ConCod
					},
					contentType: "application/json; charset=utf-8",
					dataType: 'json',
					async: true,
					success: function (data) {
						
					},
					error: function () {

					}
				});
				//LoadTableData();

			} else {
				console.log("not dele");
			}
		},
		error: function () {

		}
	});
	
}

connection.on("RowSelected", function (ConCod) {
	//console.log(('#Ed-' + ConCod));
	//$('#Ed-' + ConCod).addClass('hide');
	$('table tbody tr').each(function () {
		$(this).siblings().removeClass("rowedite");
	});
	$('#conTable tbody #tr-' + ConCod).addClass("rowedite");;
});

connection.on("RowEditing", function (Editing) {
	//$('table tbody tr').each(function () {
	//    $(this).siblings().removeClass("editing");
	//});
	//Editing.forEach(function (ele) {
	//    console.log('#Ed-' + ele);

	//    $('#Ed-' + ele).addClass('editing');
	//});

});