var initData = {module:"users"};
var users = modules;
users.init(initData);
users.loadData();
function checkPass(elem) {
	var pass = $('#Password').val();
	var repass = $('#inputPass').val();
	if (pass != repass) {
		$(this).val('');
		$(this).focus();
		toastr.error("Nhập lại mật khẩu chưa trùng khớp");
		return false;
	}
	$('#submitForm').click();
}

