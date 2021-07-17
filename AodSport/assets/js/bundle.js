//// notification popup
function alertToastr(type,text) {
    toastr.options.closeButton = true;
    toastr.options.positionClass = 'toast-top-right';
    toastr.options.showDuration = 1000;
    toastr[type](text);
}
 

//checkbox click checkall
var InitClickCheckAllInTable = function (btnCheckAll, fn) {
    var arrValue = [];
    $("table tbody").find("input[type=checkbox]").click(function () {
        arrValue = [];
        if ($("table tbody").find("input[type=checkbox]").length == $("table tbody").find("input[type=checkbox]:checked").length) {
            $("#" + btnCheckAll).prop("checked", true);
        } else {
            $("#" + btnCheckAll).prop("checked", false);
        }
        $("table tbody").find("input[type=checkbox]:checked").each(function () {
            arrValue.push($(this).val());
        });
        fn(arrValue);
    });
    $("#" + btnCheckAll).click(function () {
        arrValue = [];
        if ($(this).is(':checked')) {
            $("table tbody").find("input[type=checkbox]").each(function () {
                $(this).prop("checked", true);
                arrValue.push($(this).val());
            });
        }
        else {
            $("table tbody").find("input[type=checkbox]").each(function () {
                $(this).prop("checked", false);
            });
        }
        fn(arrValue);
    });
}

//Phục vụ tắt modal
$("#PopupModal").on('hidden.bs.modal', function () {
    $(this).data('bs.modal', null);
});


//Ngôn ngữ validate
Parsley.addMessages('vi', {
    defaultMessage: "Giá trị này không hợp lệ.",
    type: {
        email: "Giá trị này phải là một email hợp lệ.",
        url: "Giá trị này phải là url hợp lệ.",
        number: "Giá trị này phải là số hợp lệ.",
        integer: "Giá trị này phải là một số nguyên hợp lệ.",
        digits: "Giá trị này phải là chữ số.",
        alphanum: "Giá trị này phải là chữ và số."
    },
    notblank: "Không nên bỏ qua cái giá trị này.",
    required: "Giá trị này là bắt buộc.",
    pattern: "Giá trị này có vẻ không hợp lệ.",
    min: "Giá trị này phải lớn hơn hoặc bằng %s.",
    max: "Giá trị này phải thấp hơn hoặc bằng %s.",
    range: "Giá trị này phải nằm trong khoảng từ %s đến %s.",
    minlength: "Giá trị này quá ngắn. Nó phải có %s ký tự trở lên.",
    maxlength: "Giá trị này quá dài. Nó phải có %s ký tự trở xuống.",
    length: "Độ dài giá trị này không hợp lệ. Nó phải nằm trong khoảng từ %s đến %s ký tự.",
    mincheck: "Bạn phải chọn ít nhất %s lựa chọn.",
    maxcheck: "Bạn phải chọn %s lựa chọn hoặc ít hơn.",
    check: "Bạn phải chọn giữa %s và %s lựa chọn.",
    equalto: "Giá trị này phải giống nhau."
});

Parsley.setLocale('vi');

 
if ($('body').find('.select2').size() > 0) {
    $('.select2').select2({
        width:"100%"
    });
}