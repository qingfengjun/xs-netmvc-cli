$("#btn_comment_submit").click(function () {
    $("#comment_message").hide();
    var comment = removeHTMLTag($.trim($("#area_comment").val()));

    var id = $("#hidId").val();
    if (comment.length == 0) {
        $("#comment_message").text("请输入评论的内容.");
        $("#comment_message").show();
        return;
    }

    $("#comment_message").text("评论提交中...");
    $("#comment_message").show();
    $.post("/Home/AddComment",
    {
        id: id,
        comment: comment
    },
    function (data, status) {
        $("#comment_message").hide();
        $("#area_comment").val("");
        $('#comments').load('/Home/Comment/' + id);
    });
});

function replay(txt) {
    $("#area_comment").val('#' + txt + '  ');
    $("#area_comment").focus();
}

function removeHTMLTag(str) {
    str = str.replace(/<\/?[^>]*>/g, ''); //去除HTML tag
    str = str.replace(/[ | ]*\n/g, '\n'); //去除行尾空白
    //str = str.replace(/\n[\s| | ]*\r/g,'\n'); //去除多余空行
    str = str.replace(/&nbsp;/ig, '');//去掉&nbsp;
    return str;
}

setTimeout('LoadComment()', 500) //1秒=1000，延迟加载，提高访问速度

function LoadComment() {
    var id = $("#hidId").val();
    $('#comments').load('/Home/Comment/' + id);
}