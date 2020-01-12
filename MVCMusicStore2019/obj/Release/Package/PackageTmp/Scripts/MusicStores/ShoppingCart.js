
//$(document).ready
//(
//    function PreLoading() {
//        URlGte();
//    }
//);

//function URlGte() {
//    var id = $('#item_id').val();
//    var hrefString = '/MusicIndex/Detail/';
//    var imgString ='';
//    $.ajax(
//        {
//            type: 'POST',
//            url: "ShoppingCart/Gteimg/" + id,
//            dataType: 'json',
//            success: function (evt) {
//                alert(456);
//                imgString += "<a herf='" + hrefString + evt.id + "'>";
//                imgString += "<img src='/Pics/" + evt.UrlString + "' class='poster' alt=" + evt.Name + "/>";
//                imgString += "</a>";
//                alert(imgString);
//                $('#urlimg').html(imgString);
//            }
//        });
//}


$(document).ready(function () {
    $('#EmpryCart').bind("click", function () {
        //alert('点击');
        var id = $('#Id').val();
        //alert(id);
        $.ajax({
            type: 'POST',
            url: "/ShoppingCart/EmpryCart",
            dataTpye: 'json',
            success: function (evt) {
                window.alert(evt);
                location.reload(true);//使用回调函数刷新页面
            }
        });
    });
});