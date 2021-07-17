$(document).ready(function() {
    changeSizeHeader();

    //Scrollbar cho cột trái và cột phải
    //$('.scrollJs').mCustomScrollbar({ axis: "xy", });
    //$('#FormInput').mCustomScrollbar({ axis: "y" });

    //Ghim các tab khi đóng lại
    
    $('html').on('click', '.pintab', function (e) {
        var id = $(this).attr("data-id");
        $('#' + id).fadeToggle();
        var text = $(this).attr("data-text");
        if (!$(this).hasClass('expend')) {
            $('#pintab ul').append('<li><a href="javascript://" title="' + text + '" data-id="' + id + '" class="pintab expend">' + text + ' <i class="fa fa-arrows-alt" aria-hidden="true"></i></a></li> ');
        }
        $(this).parent('li').remove();
    });
    
    //Phục vụ tắt + bật multiple modal
    $(document).on('show.bs.modal', '.modal', function () { 
        var zIndex = 1040 + (10 * $('.modal:visible').length);
        $(this).css('z-index', zIndex);
        setTimeout(function () {
            $('.modal-backdrop').not('.modal-stack').css('z-index', zIndex - 1).addClass('modal-stack');
        }, 0);
    });
    $(document).on('hidden.bs.modal', '.modal', function () {
        $(this).data('bs.modal', null);
    });

    //$("#colRightHoSo").on("resizestop", function (event, ui) { alert(123); });

    /*==================================================================*/
    //Thay đổi select -> thay đổi giá trị trường dữ liệu

    $('html').on("change",
        ".changeValueName",
        function () { 
            var name = $(this).attr("data-name");
            var text = $(this).find("option:selected").text();
            if ($(this).parents(".modal").length > 0)
                $('.modal #' + name).val(text.trim().replace(/-/g, ""));
            else $('#' + name).val(text.trim().replace(/-/g, ""));
        });

    showHideButtonPemission();
});
 


$(window).resize(function () {
    changeSizeHeader();
}); 

 function changeSizeHeader() { 
     var totalVal = $(window).innerHeight() - $('#header').innerHeight() - $('#menuMain').innerHeight();
     $('#flexBody').innerHeight(totalVal); 
     $('#FormInput').innerHeight(totalVal - 20);  
 }

function breakTextarea(id) {
    var span = $('<span>').css('display', 'inline-block').css('word-break', 'break-all').appendTo('#' + id).css('visibility', 'hidden').hide();
    function initSpan(textarea) {
        span.text(textarea.text()).width(textarea.width()).css('font', textarea.css('font'));
    }

    $('#' + id + ' table textarea').each(function () {
        initSpan($(this));
        var text = $(this).val();
        span.text(text);
        $(this).innerHeight(text ? span.innerHeight() : '25px');
    });


    $('#' + id + ' table textarea').attr("cols", "1");
    $('#' + id + ' table textarea').on({
        input: function () {
            var text = $(this).val();
            span.text(text);
            $(this).innerHeight(text ? span.innerHeight() : '25px');
        },
        focus: function () {
            initSpan($(this));
        },
        keypress: function (e) {
            if (e.which == 13) e.preventDefault();
        }
    });
} 

function showHideButtonPemission() {
    var hideIsRoot = $("#hideIsRoot").text();
    var hideRoles = $("#hideRoles").text();
    if (hideIsRoot.toLowerCase() == "false") {
        var hideRolesClass = "." + hideRoles.replace(/\./g, "_").replace(/\,/g, ",.");
        $(".permCodeVz").hide();
        $(hideRolesClass).show();
    }
}
 $(function () {
        //$("img").lazy({
        //    effect: "fadeIn",
        //    effectTime: 1000, 
        //    placeholder: "../css/icon/logo.png"
        //});

        //$('.noidung img').attr("data-lightbox", "roadtrip");

        //var countimg = 0;
        //var tenmienwebsite = $('#TenMienWebSite').val();
        //$('.noidung img').each(function () {
        //    var src = $(this).attr("src");
        //    if (!src.includes("http")) {
        //        src =tenmienwebsite + "/" + $(this).attr("src");
        //    }
        //    $(this).attr("src", src);
        //    if (!$(this).parent().is("a")) {
        //        $('<a class="example-image-link countimg' +
        //            countimg +
        //            '" href="' +
        //            src +
        //            '" data-lightbox="example-1"></a>').insertBefore($(this));
        //        $('.countimg' + countimg).append($(this));
        //    } else {
        //        var href = $(this).parent("a").attr("href");
        //        if (href === src)
        //            $(this).parent("a").attr({
        //                "class": "example-image-link countimg" + countimg,
        //                "data-lightbox": "example-1"
        //            });
        //    }
        //    countimg++;
        //});

        //lightbox.option({
        //    'resizeDuration': 200,
        //    'wrapAround': true
        //}); 
    });
	//Tăng giảm cỡ chữ
var size = parseInt($(".noidung").css("font-size"));
var lineheight = parseInt($(".noidung").css("line-height"));
if (!size)
    size = 14;
if (!lineheight)
    lineheight = 22;
function Increasenoidung() {
    size++;
    lineheight += 2; 
    $(".noidung")
        .css('cssText','font-size:' +size + 'px !important; line-height:' + lineheight + 'px !important');
    $(".noidung").find("*").css('cssText','font-size:' +size +'px !important; line-height:' +lineheight +'px !important');
}
function Decreasenoidung() {
    size--;
    lineheight -= 2;

    $(".noidung")
        .css('cssText',
            'font-size:' +
            size +
            'px !important; line-height:' +
            lineheight +
            'px !important');
    $(".noidung")
        .find("*")
        .css('cssText',
            'font-size:' +
            size +
            'px !important; line-height:' +
            lineheight +
            'px !important');
}
function Resetnoidung() {
    size = 14;
    lineheight = 22;

    $(".noidung")
        .css('cssText',
            'font-size:' +
            size +
            'px !important; line-height:' +
            lineheight +
            'px !important');
    $(".noidung")
        .find("*")
        .css('cssText',
            'font-size:' +
            size +
            'px !important; line-height:' +
            lineheight +
            'px !important');
}
 


function alertToastr(type, text) {
    toastr.options.closeButton = true;
    toastr.options.positionClass = 'toast-top-right';
    toastr.options.showDuration = 1000;
    toastr[type](text);
}
$("#export").on("click", function () {
    debugger;
    var diadanh = $("#DiaDanh").val();
    var isTXB = $("#TXB").prop("checked");
    var TongBienTapDuyet = $("#TongBienTapDuyet").val();
    var PhoTruongBan = $("#PhoTruongBan").val();
    var fromDate = $("#FromDate").val();
    var toDate = $("#ToDate").val();
    if (diadanh == "" || diadanh == undefined) {
        alertToastr('error', 'Nhập địa danh');
        return false;
    }
    if (TongBienTapDuyet == "" || TongBienTapDuyet == undefined) {
        alertToastr('error', 'Nhập tổng biên tập duyệt');
        return false;
    }
    if (PhoTruongBan == "" || PhoTruongBan == undefined) {
        alertToastr('error', 'Nhập phó trưởng ban');
        return false;
    }
    $.ajax({
        url: '/BaoCao/CreateDocx',
        type: "POST",
        data: { diadanh: diadanh, TongBienTapDuyet: TongBienTapDuyet, PhoTruongBan: PhoTruongBan, fromDate: fromDate, toDate: toDate, isTXB: isTXB },
        success: function (data) {
            if (data == "false") {
                alertToastr('error', 'Ngày xuất bản không hợp lệ! Vui lòng kiểm tra lại.');
            } else {
                alertToastr('success', 'Success');
                window.location.href = '/Content/Export/' + data;
            }
        },
        error: function () {

        }
    });
})
$("#exportExcel").on("click", function () {
    var fromDate = $("#FromDate").val();
    var toDate = $("#ToDate").val();
    linkUrl = '/BaoCao/CreateExcel';
    linkUrl += "?fromDate=" + fromDate + "&toDate=" + toDate;
    window.location.href = linkUrl;
})

var scrollbar = $('#fixed-scrollbar');
scrollbar.hide().css({
    overflowX: 'auto',
    position: 'fixed',
    width: '100%',
    bottom: 0
});
var fakecontent = scrollbar.find('div');
scrollbar.scroll(scroll);

function topSc(e) {
    return e.offset().top;
}

function bottom(e) {
    return e.offset().top + e.height();
}

var active = $([]);
function find_active(ele) {
    scrollbar.show();
    var active = $([]);
    ele.each(function () {
        if (topSc($(this)) < topSc(scrollbar) && bottom($(this)) > bottom(scrollbar)) {
            fakecontent.width($(this).get(0).scrollWidth);
            fakecontent.height(1);
            active = $(this);
        }
    });
    fit(active);
    return active;
}

function fit(active) {
    if (!active.length) return scrollbar.hide();
    scrollbar.css({ left: active.offset().left, width: active.width() });
    fakecontent.width($(this).get(0).scrollWidth);
    fakecontent.height(1);
    delete lastScroll;
}

function onscroll(ele) {
    var oldactive = active;
    active = find_active(ele);
    if (oldactive.not(active).length) {
        oldactive.unbind('scroll', update);
    }
    if (active.not(oldactive).length) {
        active.scroll(update);
    } 
    
    var topEle = ele.offset().top + ele.innerHeight();
    var topfixScr = scrollbar.offset().top;
    if (topfixScr > topEle) {
        scrollbar.hide(); 
    }
    else scrollbar.show();
    update();
}

var lastScroll;
function scroll() {
    if (!active.length) return;
    if (scrollbar.scrollLeft() === lastScroll) return;
    lastScroll = scrollbar.scrollLeft();
    active.scrollLeft(lastScroll);
}
function update() {
    if (!active.length) return;
    if (active.scrollLeft() === lastScroll) return;
    lastScroll = active.scrollLeft();
    scrollbar.scrollLeft(lastScroll);
}

//AutoSize textarea

//autosize Textarea
!function (e, t) { if ("function" == typeof define && define.amd) define(["module", "exports"], t); else if ("undefined" != typeof exports) t(module, exports); else { var n = { exports: {} }; t(n, n.exports), e.autosize = n.exports } }(this, function (e, t) { "use strict"; var n, o, p = "function" == typeof Map ? new Map : (n = [], o = [], { has: function (e) { return -1 < n.indexOf(e) }, get: function (e) { return o[n.indexOf(e)] }, set: function (e, t) { -1 === n.indexOf(e) && (n.push(e), o.push(t)) }, delete: function (e) { var t = n.indexOf(e); -1 < t && (n.splice(t, 1), o.splice(t, 1)) } }), c = function (e) { return new Event(e, { bubbles: !0 }) }; try { new Event("test") } catch (e) { c = function (e) { var t = document.createEvent("Event"); return t.initEvent(e, !0, !1), t } } function r(r) { if (r && r.nodeName && "TEXTAREA" === r.nodeName && !p.has(r)) { var e, n = null, o = null, i = null, d = function () { r.clientWidth !== o && a() }, l = function (t) { window.removeEventListener("resize", d, !1), r.removeEventListener("input", a, !1), r.removeEventListener("keyup", a, !1), r.removeEventListener("autosize:destroy", l, !1), r.removeEventListener("autosize:update", a, !1), Object.keys(t).forEach(function (e) { r.style[e] = t[e] }), p.delete(r) }.bind(r, { height: r.style.height, resize: r.style.resize, overflowY: r.style.overflowY, overflowX: r.style.overflowX, wordWrap: r.style.wordWrap }); r.addEventListener("autosize:destroy", l, !1), "onpropertychange" in r && "oninput" in r && r.addEventListener("keyup", a, !1), window.addEventListener("resize", d, !1), r.addEventListener("input", a, !1), r.addEventListener("autosize:update", a, !1), r.style.overflowX = "hidden", r.style.wordWrap = "break-word", p.set(r, { destroy: l, update: a }), "vertical" === (e = window.getComputedStyle(r, null)).resize ? r.style.resize = "none" : "both" === e.resize && (r.style.resize = "horizontal"), n = "content-box" === e.boxSizing ? -(parseFloat(e.paddingTop) + parseFloat(e.paddingBottom)) : parseFloat(e.borderTopWidth) + parseFloat(e.borderBottomWidth), isNaN(n) && (n = 0), a() } function s(e) { var t = r.style.width; r.style.width = "0px", r.offsetWidth, r.style.width = t, r.style.overflowY = e } function u() { if (0 !== r.scrollHeight) { var e = function (e) { for (var t = []; e && e.parentNode && e.parentNode instanceof Element;) e.parentNode.scrollTop && t.push({ node: e.parentNode, scrollTop: e.parentNode.scrollTop }), e = e.parentNode; return t }(r), t = document.documentElement && document.documentElement.scrollTop; r.style.height = "", r.style.height = r.scrollHeight + n + "px", o = r.clientWidth, e.forEach(function (e) { e.node.scrollTop = e.scrollTop }), t && (document.documentElement.scrollTop = t) } } function a() { u(); var e = Math.round(parseFloat(r.style.height)), t = window.getComputedStyle(r, null), n = "content-box" === t.boxSizing ? Math.round(parseFloat(t.height)) : r.offsetHeight; if (n < e ? "hidden" === t.overflowY && (s("scroll"), u(), n = "content-box" === t.boxSizing ? Math.round(parseFloat(window.getComputedStyle(r, null).height)) : r.offsetHeight) : "hidden" !== t.overflowY && (s("hidden"), u(), n = "content-box" === t.boxSizing ? Math.round(parseFloat(window.getComputedStyle(r, null).height)) : r.offsetHeight), i !== n) { i = n; var o = c("autosize:resized"); try { r.dispatchEvent(o) } catch (e) { } } } } function i(e) { var t = p.get(e); t && t.destroy() } function d(e) { var t = p.get(e); t && t.update() } var l = null; "undefined" == typeof window || "function" != typeof window.getComputedStyle ? ((l = function (e) { return e }).destroy = function (e) { return e }, l.update = function (e) { return e }) : ((l = function (e, t) { return e && Array.prototype.forEach.call(e.length ? e : [e], function (e) { return r(e) }), e }).destroy = function (e) { return e && Array.prototype.forEach.call(e.length ? e : [e], i), e }, l.update = function (e) { return e && Array.prototype.forEach.call(e.length ? e : [e], d), e }), t.default = l, e.exports = t.default });

$(document).ready(function () {
    autosize($('textarea'));
})