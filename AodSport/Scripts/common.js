var modules = function () { 
    return {
        init: function (initData) {
            if (initData.pageIndex == undefined || initData.pageIndex == null) {
                this.pageIndex = 1;
            } else
                this.pageIndex = initData.pageIndex;

            if (initData.pageSize == undefined || initData.pageSize == null) {
                this.pageSize = 20;
            } else
                this.pageSize = initData.pageSize;

            this.module = window.location.protocol + "//" + window.location.host + "/" + initData.module;
            this.host = window.location.protocol + "//" + window.location.host;
             
            if (initData.tableList == undefined || initData.tableList == null) {
                this.tableList = "#gridData";
            } else
                this.tableList = initData.tableList;

            if (initData.loading == undefined || initData.loading == null) {
                this.loading = "#loading";
            } else
                this.loading = initData.loading;

            if (initData.paginationholder == undefined || initData.paginationholder == null) {
                this.paginationholder = "#paginationholder";
            } else
                this.paginationholder = initData.paginationholder;
            
            if (initData.pagination == undefined || initData.pagination == null) {
                this.pagination = ".pagination";
            } else
                this.pagination = initData.pagination;


            if (initData.formsearch == undefined || initData.formsearch == null) {
                this.formsearch = "#searchForm";
            } else
                this.formsearch = initData.formsearch;


            if (initData.classNameModal == undefined || initData.classNameModal == null) {
                this.classNameModal = "modal-md";
            } else
                this.classNameModal = initData.classNameModal;

            if (initData.IdModal == undefined || initData.IdModal == null) {
                this.IdModal = "#responsive";
            } else
                this.IdModal = initData.IdModal;

            if (initData.fieldSearch == undefined || initData.fieldSearch == null)
                this.fieldSearch = "";
            else this.fieldSearch = initData.fieldSearch;

            if (initData.fieldSort == undefined || initData.fieldSort == null)
                this.fieldSort = "";
            else this.fieldSort = initData.fieldSort;
             
        },
        loadData: function (pageIndex) {
            modules.blockUI();
            var data = $(modules.formsearch).serializeArray();
            if (pageIndex != undefined) {
                modules.pageIndex = pageIndex;
            } else
                modules.pageIndex = 1; 
            var obj = [
                {
                    name: "page",
                    value: modules.pageIndex
                },
                {
                    name: "pageSize",
                    value: modules.pageSize
                },
                {
                    name: "fieldSort",
                    value: modules.fieldSort
                }
            ];
            data = data.concat(obj);

            $.ajax({
                url: modules.module + "/ListData",
                type: "POST",
                data: data,
                success: function(result) {
                    $(modules.tableList).html(result);
                    //modules.changePaging();
                    modules.unblockUI();
                    showHideButtonPemission();
                },
                error: function() {
                    toastr.error("Lỗi tải trang");
                    modules.unblockUI();
                }
            });
        },
        loadfrmAddSussess: function() {
            $(modules.IdModal).modal({
                show: true,
                backdrop: 'static'
            });
            modules.unblockUI();
        },
        loadfrmEditSussess: function(res) {
            if (res.responseJSON != undefined && !res.responseJSON.status) {
                toastr.error(res.responseJSON.message);
            } else {
                $(modules.IdModal).modal({
                    show: true,
                    backdrop: 'static'
                });
            }
            modules.unblockUI();
        },
        loadfrmViewLSSussess: function (res) {
        	if (res.responseJSON != undefined && !res.responseJSON.status) {
        		toastr.error(res.responseJSON.message);
        	} else {
        		$('#responsive2').modal({
        			show: true,
        			backdrop: 'static'
        		});
        	}
        	modules.unblockUI();
        },
        showPaging: function (totalPages) { 
            if (totalPages > 0) {
                $(modules.paginationholder).append('<ul class="pagination pagination-sm pull-right"></ul>');
            }
            if (totalPages > 1) {
                $(modules.paginationholder + " " +modules.pagination).twbsPagination({
                    startPage: modules.pageIndex,
                    totalPages: totalPages,
                    visiblePages: 5,
                    first: '<i class="fa fa-fast-backward" aria-hidden="true"></i>',
                    prev: '<i class="fa fa-step-backward" aria-hidden="true"></i>',
                    next: '<i class="fa fa-step-forward" aria-hidden="true"></i>',
                    last: '<i class="fa fa-fast-forward" aria-hidden="true"></i>',
                    onPageClick: function (event, page) {
                        modules.pageIndex = page;
                        modules.loadData(modules.pageIndex);
                    }
                });
            }
        },
        deleteSussess: function(res) {
            if (res.responseJSON != undefined) {
                if (res.responseJSON.status) {
                    if (res.responseJSON.message != undefined) {
                        toastr.success(res.responseJSON.message);
                        modules.loadData();
                    }
                } else {
                    if (res.responseJSON.message != undefined) {
                        toastr.error(res.responseJSON.message);
                    }
                }
            }
            modules.unblockUI();
        },
        statusSussess: function (res) {
            if (res.responseJSON != undefined) {
                if (res.responseJSON.status) {
                    if (res.responseJSON.message != undefined) {
                        toastr.success(res.responseJSON.message);
                        modules.loadData();
                    }
                } else {
                    if (res.responseJSON.message != undefined) {
                        toastr.error(res.responseJSON.message);
                    }
                }
            }
            modules.unblockUI();
        },
        //HieuLucSussess: function (res) {
        //    if (res.responseJSON != undefined) {
        //        if (res.responseJSON.HieuLuc) {
        //            if (res.responseJSON.message != undefined) {
        //                toastr.success(res.responseJSON.message);
        //                modules.loadData();
        //            }
        //        } else {
        //            if (res.responseJSON.message != undefined) {
        //                toastr.error(res.responseJSON.message);
        //            }
        //        }
        //    }
        //    modules.unblockUI();
        //},
        setIcon: function (id, icon) {
            $("." + id).prepend("<i class='" + icon +  "'></i>");
        },
        onAddSuccess: function (res) { 
            if (res.status) {
                if (res.message != undefined) {
                    toastr.success(res.message);
                    modules.loadData(modules.pageIndex = 1);
                    $(modules.IdModal).modal("hide");
                }
            } else {
                if (res.message != undefined) {
                    toastr.error(res.message);
                }
            }
            modules.unblockUI();
        },
        onEditSuccess: function (res) { 
            if (res.status) {
                if (res.message != undefined) {
                    toastr.success(res.message);
                    modules.loadData(modules.pageIndex = 1);
                    $(modules.IdModal).modal("hide");
                }
            } else {
                if (res.message != undefined) {
                    toastr.error(res.message);
                }
            }
            modules.unblockUI();
        },
        InitClickCheckAllInTable : function (btnCheckAll, fn) {
            var arrValue = [];
            $(modules.tableList + " table tbody").find("input[type=checkbox]").click(function () {
                arrValue = [];
                if ($(modules.tableList + " table tbody").find("input[type=checkbox]").length ==
                    $(modules.tableList + " table tbody").find("input[type=checkbox]:checked").length) {
                    $("#" + btnCheckAll).prop("checked", true);
                } else {
                    $("#" + btnCheckAll).prop("checked", false);
                }
                $(modules.tableList + " table tbody").find("input[type=checkbox]:checked").each(function () {
                    arrValue.push($(this).val());
                });
                fn(arrValue);
            });
            $("#" + btnCheckAll).click(function() {
                arrValue = [];
                if ($(this).is(':checked')) {
                    $(modules.tableList + " table tbody").find("input[type=checkbox]").each(function () {
                        $(this).prop("checked", true);
                        arrValue.push($(this).val());
                    });
                } else {
                    $(modules.tableList + " table tbody").find("input[type=checkbox]").each(function () {
                        $(this).prop("checked", false);
                    });
                }
                fn(arrValue);
            });
        },
        initCreate: function () {
            $('#basicForm').parsley();
            $(".select2").select2("destroy");
            $(".select2").select2({
                width: "100%"
            });

        },
        initEdit: function () {
            $('#basicForm').parsley();
            $(".select2").select2("destroy");
            $(".select2").select2({
                width: "100%"
            });

        },
        initListData: function () {
            $(".select-all").on("click", function () { this.checked ? $(this).parents("table").find(".checkbox-tick").each(function () { this.checked = !0 }) : $(this).parents("table").find(".checkbox-tick").each(function () { this.checked = !1 }) }), $(".checkbox-tick").on("click", function () { $(this).parents("table").find(".checkbox-tick:checked").length == $(this).parents("table").find(".checkbox-tick").length ? $(this).parents("table").find(".select-all").prop("checked", !0) : $(this).parents("table").find(".select-all").prop("checked", !1) });
            modules.InitClickCheckAllInTable("chkall", function (res) {
                $("#hdfID").val(res);
            });
            $(".keyEnter").keypress(function (e) {
                if (e.which == 13)
                {
                    modules.loadData(1);
                    return false;
                }
            });

            $("table tr th[class='sapxep'] ").click(function () {
                var tempField = this.id;
                if (modules.fieldSort == tempField) {
                    modules.fieldSort = tempField + "_des";
                } else {
                    modules.fieldSort = tempField;
                }
                modules.loadData(1);
            });
            modules.resetIconOrder();
        },
        selectPageSize: function (pageSize) {
            $("#pageSize").val(pageSize);
        },
        changePageSize: function () {
            modules.pageSize = $("#pageSize").val();
            modules.loadData();
        },
        resetIconOrder: function () {
            if (modules.fieldSort == "" || modules.fieldSort == undefined)
                return;

            $("table tr th[class='sapxep'] > i").removeClass("fa-sort-down");
            $("table tr th[class='sapxep'] > i").removeClass("fa-sort-up");

            if (modules.fieldSort.indexOf("_des") > 0) {
                var id = modules.fieldSort.replace("_des", "");
                $("#" + id + " > i").addClass("fa-sort-down");
            } else {
                $("#" + modules.fieldSort + " > i").addClass("fa-sort-up");
            }
        },
        onDelete: function(id) {
            swal({
                title: "Bạn có chắc chắn không?",
                text: "",
                type: "warning",
                showCancelButton: true,
                confirmButtonClass: "btn-danger",
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Có",
                cancelButtonText: "Không",
                closeOnConfirm: true
            },
            function () { 
                modules.blockUI();
                $.ajax({
                    url: modules.module + "/Delete",
                    data: { "id": id },
                    success: function (res) {
                        if (res.status) {
                            if (res.message != undefined) {
                                toastr.success(res.message);
                                modules.loadData();
                            }
                        } else {
                            if (res.message != undefined) {
                                toastr.error(res.message);
                            }
                        }
                        modules.unblockUI();
                    },
                    error: function (res) {
                        if (res.message != undefined) {
                            toastr.error(res.message);
                        }
                        modules.unblockUI();
                    }
                });
            });
        },
        onMultiDelete : function() {
            if ($("table tbody").find("input[type=checkbox]:checked").length == 0) {
                toastr.error("Bạn cần chọn ít nhất một bản ghi cần xóa");
            } else {
                swal({
                    title: "Bạn có chắc chắn không?",
                    text: "",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonClass: "btn-danger",
                    confirmButtonColor: "#DD6B55",
                    confirmButtonText: "Có",
                    cancelButtonText: "Không",
                    closeOnConfirm: true
                },
                    function () {
                        modules.blockUI();
                        $.ajax({
                            url: modules.module + "/DeleteAll",
                            data: { "lstid": $("#hdfID").val() },
                            success: function (res) {
                                if (res.status) {
                                    if (res.message != undefined) {
                                        toastr.success(res.message);
                                        modules.loadData();
                                    }
                                } else {
                                    if (res.message != undefined) {
                                        toastr.error(res.message);
                                    }
                                }
                                modules.unblockUI();
                            },
                            error: function (res) {
                                if (res.message != undefined) {
                                    toastr.error(res.message);
                                }
                                modules.unblockUI();
                            }
                        });
                    });
            }
        },
        onUpdatePosittion: function () { 
            modules.blockUI();
            var arrId = "";
            var arrOrder = "";
            $("table tbody tr").each(function() {
                var id = $(this).find(".item_ID").val();
                var ordering = $(this).find("input[type=number].ordering").val();
                if (ordering == "") ordering = 0;

                arrId = arrId + id + ",";
                arrOrder = arrOrder + ordering + ",";
            });
            $.ajax({
                url: modules.module + "/UpdatePosition",
                type: "POST",
                data: { arrId: arrId, arrOrder: arrOrder},
                success: function (res) { 
                    if (res.status) {
                        if (res.message != undefined) {
                            toastr.success(res.message);
                            modules.loadData();
                        }
                    } else {
                        if (res.message != undefined) {
                            toastr.error(res.message);
                        }
                    }
                    modules.unblockUI();
                },
                error: function (res) {
                    if (res.message != undefined) {
                        toastr.error(res.message);
                    }
                    modules.unblockUI();
                }
            });
        },
        //getUrlVars: function(url) {
        //    var vars = [], hash;
        //    if (url != null) {
        //        var hashes = url.slice(url.indexOf("?") + 1).split("&");
        //        for (var i = 0; i < hashes.length; i++) {
        //            hash = hashes[i].split("=");
        //            vars.push(hash[0]);
        //            vars[hash[0]] = hash[1];
        //        }
        //    }
        //    return vars;
        //},
        //changePaging: function () {
        //    $(modules.pagination + " a").on("click", function (event) { 
        //        if (!$(this).parent().hasClass("active")) {
        //            event.preventDefault();
        //            var url = $(this).attr("href");
        //            var getUrl = modules.getUrlVars(url);
        //            var page = getUrl["page"];
        //            modules.loadData(page);
        //        } 
        //    }); 
        //},
        blockUI: function (options) {
            options = $.extend(true, {}, options);
            var html = '';
            if (options.animate) {
                html = '<div class="loading-message ' + (options.boxed ? 'loading-message-boxed' : '') + '">' + '<div class="block-spinner-bar"><div></div></div>' + '</div>';
            } else if (options.iconOnly) {
                html = '<div class="loading-message ' + (options.boxed ? 'loading-message-boxed' : '') + '"><img src="/Images/loading/loading-spinner-grey.gif" align=""></div>';
            } else if (options.textOnly) {
                html = '<div class="loading-message ' + (options.boxed ? 'loading-message-boxed' : '') + '"><span>&nbsp;&nbsp;' + (options.message ? options.message : 'Đang tải dữ liệu...') + '</span></div>';
            } else {
                html = '<div class="loading-message ' + (options.boxed ? 'loading-message-boxed' : '') + '"><img src="/Images/loading/loading-spinner-grey.gif" align=""><span>&nbsp;&nbsp;' + (options.message ? options.message : 'Đang tải dữ liệu...') + '</span></div>';
            }

            if (options.target) { 
                var el = $(options.target);
                if (el.height() <= ($(window).height())) {
                    options.cenrerY = true;
                }
                el.block({
                    message: html,
                    baseZ: options.zIndex ? options.zIndex : 1000,
                    centerY: options.cenrerY !== undefined ? options.cenrerY : false,
                    css: {
                        top: '10%',
                        border: '0',
                        padding: '0',
                        backgroundColor: 'none'
                    },
                    overlayCSS: {
                        backgroundColor: options.overlayColor ? options.overlayColor : '#555',
                        opacity: options.boxed ? 0.05 : 0.1,
                        cursor: 'wait'
                    }
                });
            } else { // page blocking
                $.blockUI({
                    message: html,
                    baseZ: options.zIndex ? options.zIndex : 1000,
                    css: {
                        border: '0',
                        padding: '0',
                        backgroundColor: 'none'
                    },
                    overlayCSS: {
                        backgroundColor: options.overlayColor ? options.overlayColor : '#555',
                        opacity: options.boxed ? 0.05 : 0.1,
                        cursor: 'wait'
                    }
                });
            }
        },
        unblockUI: function (target) {
            if (target) {
                $(target).unblock({
                    onUnblock: function () {
                        $(target).css('position', '');
                        $(target).css('zoom', '');
                    }
                });
            } else {
                $.unblockUI();
            }
        }
    };
}();
var modal = {};
modal.show = function (url) {
	$.get(url, function (result) {
		$("#mymodal").html(result);
		$('#mymodal').modal('show');
	});
}
modal.hide = function () {
	$('#mymodal').modal('hide');
	$("#mymodal").html('');
}
modal.Render = function (url, title, classSize) {
	debugger;
	if (classSize == null || classSize == undefined) {
		classSize = "";
	}
	$.get(url, function (result) {
		var strHtml = "";

		strHtml += "<div class='modal-dialog modal-lg' role='document'>" +
            "<div class='modal-content'>" +
            "<div class=modal-header>" +
            "<h3 class='title' id='largeModalLabel'> " + title + "</h3> " +
			"<button type='button' class='close' data-dismiss='modal'>×</button> " +
            "</div> " +
            "<div class='modal-body'> " +
            result +
            "</div>" +
            "</div>" +
            "</div>";
		$("#mymodal").html(strHtml);
		$("#loading").hide();
		$('#mymodal').modal({
			backdrop: 'static',
			keyboard: false
		});
	});
}
//Phục hồi pop up modal
$(document).on('hidden.bs.modal', '.modal', function () {
	$(this).data('bs.modal', null);
});

//Thiết lập thời gian đăng xuất khi người dùng không thao tác trên hệ thống
(function () { 
	var lastMove = Date.now();
	document.onmousemove = function () {
		lastMove = Date.now();
	}
	setInterval(function () { 
		var diff = Date.now() - lastMove;
		if (diff > 3600000) {
			window.location.href = "/Account/Logout";
		}
	}, 1000);
}());