var FormFileUpload = function () {
    return {

        //main function to initiate the module
        init: function (changeName, type, result, input, url, auto, name, multiple, value, setname, valueName, setSize, valueSize, fileType, imageHoSo) {
            // setname = "false";
            //debugger;
            var maxNumberOfFiles = 1;
            if (multiple == "True") { maxNumberOfFiles = 100; }
            var form = $("#" + name).closest('form');
            if (!form)
                form = ".fileupload";
            if (!input) {
                input = "input.files_"+name;
            }
            if (!url) {
                url = "/JqueryUpload/UploadFiles";
            }
            auto = auto == "True" ? true : false;   // de upload anh luon khi chon
            if (!result) {
                result = ".result-table";
            }
            var temp = "template";
            switch (type) {
                case "pdf":
                    fileType = /(\.|\/)(pdf)$/i;
                    temp = "document";
                    break;
                case "image":
                    fileType = /(\.|\/)(gif|jpe?g|png)$/i;
                    temp = "image";
                    break;
                case "video":
                    fileType = /(\.|\/)(m1v|m2v|avi|gl|mjpg|moov|mov|movie|mp2|mpa|mpe|mpeg|mpg|mv)$/i;
                    temp = "video";
                    break;
                case "audio":
                    fileType = /(\.|\/)(au|m2a|m3u|mid|midi|mod|mp3|voc|wav)$/i;
                    temp = "audio";
                    break;
                case "document":
                default:
                    if (fileType == null || fileType == "") {
                        fileType =
                            /(\.|\/)(mp4|m1v|m2v|avi|gl|mjpg|moov|mov|movie|mp2|mpa|mpe|mpeg|mpg|mv|gif|jpe?g|png|au|m2a|m3u|mid|midi|mod|mp3|voc|wav|xl|xla|xls|xlsx|doc|docx|ppt|pptx|txt|pdf)$/i;
                    } else {
                        if (fileType == "video") {
                            fileType = /(\.|\/)(m1v|m2v|avi|gl|mjpg|moov|mov|movie|mp4|mp2|mpa|mpe|mpeg|mpg|mv)$/i;
                        }
                    }
                    temp = "document";
                    break;
                    //default:
                    //    fileType = /(\.|\/)(m1v|m2v|avi|gl|mjpg|moov|mov|movie|mp2|mpa|mpe|mpeg|mpg|mv|gif|jpe?g|png|au|m2a|m3u|mid|midi|mod|mp3|voc|wav|xl|xla|xls|xlsx|doc|docx|ppt|pptx|txt|pdf)$/i;
                    //    temp = "template";
                    //    break;
            }

 

            $(form).fileupload({ 
                disableImageResize: false,
                fileInput: $(input),
                autoUpload: auto,
                maxNumberOfFiles: maxNumberOfFiles,
                url: url,
                filesContainer: result,
                uploadTemplateId: temp + "-upload",
                downloadTemplateId: temp + "-download",
                disableImageResize: /Android(?!.*Chrome)|Opera/.test(window.navigator.userAgent),
                acceptFileTypes: fileType,
                maxFileSize: 1500000000,
                send: function (e, data) { 

                    var abc = data.context.find('input[name="abcd"]').val();
                    data.files[0].nameFile = abc;
                },
                finished: function (e, data) {
                    var nameFile = data.files[0].nameFile; 
                    data.context.find('input[name="abcd"]').val(nameFile);
                    if (data != null) {
                        var idInput = $(input).attr("data-id");
                        var listFile = $("#" + idInput).val();
                        var lstSetName = $("#AttachmentName").val();
                        var lstFileSize = $("#AttachmentSize").val();
                        $.each(data.result.files, function (index, file) {
                            if (listFile != "") {
                                listFile += ",";
                                lstSetName += "|";
                                lstFileSize += "|";
                            }
                            listFile += file.url;
                            lstSetName += file.abcd;
                            lstFileSize += file.size;
                        });
                        $("#" + idInput).val(listFile);
                        $("#AttachmentName").val(lstSetName);
                        $("#AttachmentSize").val(lstFileSize);
                        // an validate
                        $(".help-block-vb").hide();
                        $("#nutchucnang").prop("disabled", false); 
                        if (imageHoSo) { 
                            var src = $('#table-edit-AnhDaiDien tr:last-child input[name=linkFileImage]').val();
                            $('#ThongTinChung .Photo .wImage img').attr('src', src);
                            $('#AnhDaiDien').val(src);
                            if ($('#table-edit-AnhDaiDien tr').length > 1) {
                                $('#table-edit-AnhDaiDien tr:nth-child(1) .removeImgVz').click();
                                //$('#table-edit-AnhDaiDien tr:nth-child(1)').remove();
                            }
                        }
                    }
                },
                destroyed: function (e, data) {
                    //debugger;
                    var idInput = $(input).attr("data-id");//Attchment

                    var idInputDelete = $(input).attr("data-delete");
                    var listFile = $("#" + idInput).val();
                    var listFileDelete = $("#" + idInputDelete).val();
                    var dataDelete = $(data.context.context).attr("data-delete");
                    if (listFileDelete != "") {
                        listFileDelete += ","
                    }

                    listFileDelete += dataDelete;
                    $("#" + idInputDelete).val(listFileDelete);
                    var listFileNew = "";
                    var listNameFileNew = "";
                    var listSizeNew = "";

                    var arr = listFile.split(',');
                    $.each(arr, function (index, file) {
                        if (file != dataDelete) {
                            if (listFileNew != "") {
                                listFileNew += ","
                            }
                            listFileNew += file;
                        }
                    });
                    $("#" + idInput).val(listFileNew);
                }
            });
        }
    };

}();
function removeFileVz(elem) {
    elem.parents('tr').remove();
    var data_url = elem.attr("data-url");
    $.ajax({
        url: data_url,
        type: "GET",
        success: function (data) {
            elem.parent().remove();
        }
    })
}