$(document).ready(function () {
    // Multiselect 
    //$('.modal select').multiselect({
    //    enableFiltering: true,
    //    enableCaseInsensitiveFiltering: true,
    //    filterPlaceholder: 'Tìm kiếm',
    //    nonSelectedText: 'Chọn',
    //    allSelectedText: 'Tất cả',
    //    maxHeight: 400
    //});
 
    $('select').each(function () {
        if ($(this).data('select2')) { 
            $(this).select2("destroy");
        }
    });
    $('select').select2();

    // datepicker
    $('.datepicker-group').datepicker({
        format: 'dd/mm/yyyy',
        todayBtn: "linked",
        clearBtn: true,
        language: "vi",
        autoclose: true,
        todayHighlight: true
    });
    // maskintput
    var $demoMaskedInput = $('.datepicker-group');
    $demoMaskedInput.find('.date').inputmask('dd/mm/yyyy', { placeholder: '__/__/____' });
	// parley validate
    $('#basicForm').parsley();
});