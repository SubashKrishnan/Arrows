/* Main function */
$(function () {
	/* Login Button Click */
	$("#btnLogin").click(function () {
		//var val = ValidationLogin();
		if (ValLog() === false) {
			return false;
		}
		$('#Loader').show();
		$('#btnLogin').hide();
		var Login = {};
		Login.strLogUserName = $("#txtLogUserName").val();
		Login.strLogPassword = $("#txtLogPassword").val();
		$.ajax({
			type: "POST",
			url: "/Login/Login",
			data: '{Login: ' + JSON.stringify(Login) + '}',
			contentType: "application/json; charset=utf-8",
			dataType: "json",
			success: function (response) {
			    if (response.IntStatus === 0) {
					$("#divErrorLogin").css("display", "block");
					$("#divErrorLoginActivationFaied").css("display", "none");
					//$("#divErrorEmailExits").css("display", "none");
					$("#txtLogUserName").focus();
					$('#Loader').hide();
					$('#btnLogin').show();
				}
				if (response.IntStatus === 1) {
					var url = $("#RedirectTo").val();
					location.href = url;
				}
				if (response.IntStatus === 2) {
					$("#divErrorLoginActivationFaied").css("display", "block");
					$("#divErrorLogin").css("display", "none");
					//$("#divErrorEmailExits").css("display", "none");
					$("#txtLogUserName").focus();
				}
			},
			failure: function (response) {
				$('#Loader').hide();
				$('#btnLogin').show();
			},
			error: function (response) {
				$('#Loader').hide();
				$('#btnLogin').show();
			}
		});
	});
});
/* Login Validation */
function ValLog() {
	var LogUserName = document.getElementById("txtLogUserName").value;
	var LogPassword = document.getElementById("txtLogPassword").value;
	if (LogUserName === "") {
		$("#divErrorLogUserName").css("display", "block");
		$("#txtLogUserName").focus();
		return false;
	}
	else {
		$("#divErrorLogUserName").css("display", "none");
	}
	if (LogPassword === "") {
		$("#divErrorLogPassword").css("display", "block");
		$("#txtLogPassword").focus();
		return false;
	}
	else {
		$("#divErrorLogPassword").css("display", "none");
	}
	return true;
}
