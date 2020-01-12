//$(document).ready(
//    function Preloading() {
//        getPicUrlString();//加载动态轮播图方法
//        getAlbums();
//        $('#SearchBTN').bind("click", function () {
//            var str=$('#searchString').val();
//            alert(str);//测试有否获得用户输入
//            $.ajax({
//                type: 'POST',
//                url: '/MusicIndex/Index?keyword=' + str,
//                datatype: 'json',
//                success: function (evt) {
//                    var obj = window.open("about:blank");
//                    obj.document.write(evt);
//                }
//            })
//        })
//    });
$(document).ready(
    function Preloading() {
        getsales();
        Getsales();
        getPicUrlString();//加载动态轮播图方法
        getAlbums();
        $(':input').bind("keyup", function (event) {
            if(event.keyCode==13)
            {
                SearchString();
            }
        })
        $('#SearchBTN').bind("click", function () {
            SearchString();
        })
    });


function SearchString() {
    var str = $('#searchString').val();
    $.ajax({
        type: 'POST',
        url: '/MusicIndex/Index?keyword=' + str,
        datatype: 'json',
        success: function (evt) {
            var obj = window.open("about:blank");
            obj.document.write(evt);
        }
    })
}

//轮播图片读库实现
function getPicUrlString() {
    $.ajax({
        type: 'POST',
        async: true,//异步
        url: '/MusicIndex/GetPics',
        datatype: 'json',
        success: function (data) {
            var divContent = '';
            $.each(
                data,
                function (item) {
                    //alert(item);
                    //alert(data[item]);
                    if (item == 0) {
                        divContent += "<div class='item active'>";
                        divContent += " <img src='/Pics/" + data[item] + "'/>"
                        divContent += "</div>";
                    }
                    else {
                        divContent += "<div class='item'>";
                        divContent += " <img src='/Pics/" + data[item] + "'/>"
                        divContent += "</div>";
                    }
                });
            divContent = "   <div id='carouse1'class='carousel-inner' role='listbox'>" + divContent + "</div>";
            $("#carousel").html(divContent);
            //alert(divContent);
        }
    })
}


//轮播列表实现
function getAlbums() {
    //alert("进入轮播列表");
    $.ajax({
        type: 'POST',
        async: true,
        url: "/MusicIndex/GetMusicAlbums",
        datatype: 'json',
        success: function (data) {
            var divContent = ''; //回传HTML字符组装
            var divContent1 = '';//第一列表HTML字符组装
            var divContent2 = ''; //第二列表HTML字符组装
            var hrefString = '/MusicIndex/Detail/';
            var count=0;
            divContent+="<div class='carousel-inner' role='listbox'>";

            divContent1+="<div class='item active'>";
            divContent1+="<div class='row'>";

            divContent2+="<div class='item'>";
            divContent2+="<div class='row'>";
            $.each(
                data,
                function (item) {
                    //alert(item);
                    //alert(data[item].UrlString);
                    if(count<5){
                        divContent1+="<div class='col-md-2'>";
                        divContent1 += "<div class='thumbnail'>";
                        divContent1 += "<a href='" + hrefString + data[item].Id + "'>"
                        divContent1+="<img src='/Pics/"+data[item].UrlString+"'class='img-responsive' />";
                        divContent1 += "</a>";
                        divContent1 += "</div></div>";
                        count+=1;
                    }else{
                        divContent2+="<div class='col-md-2'>";
                        divContent2 += "<div class='thumbnail'>";
                       divContent2 += "<a href='" + hrefString + data[item].Id + "'>"
           
                        divContent2 += "<img src='/Pics/" + data[item].UrlString + "'class='img-responsive' />";
                        divContent2 += "</a>";
                        divContent2+="</div></div>";
                    }
                });
            divContent1 += "</div></div>";
            divContent2 += "</div></div>"; 


            divContent += divContent1 + divContent2 + "</div>";
            //alert(divContent);
            //alert(divContent1);
            //alert(divContent2);

            $('#carousel-list').html(divContent);
        }

})
}


//$('table tbody').on('click', 'tr', function () {
//    alert("点赞成功！谢谢您的支持！");
//    var Id = $('#item_Id').val();
//    $.ajax({
//        type: 'post',
//        async: true,
//        dataType: 'text',
//        data: { "id": Id },//URL方法调用的参数传值，引号内容是方法形参名，后面跟传输值
//        url: "/MusicIndex/AddCTR",
//        datatype: 'json'
//    });
//})

function AddCTR() {
    window.alert("点赞成功！");
}


//销量专辑排行榜
function getsales() {

    $.ajax
    (
      {
          type: 'POST',
          async: true,
          url: "/Home/SalesRankList",
          datatype: 'json',
          success: function (data) {
              var herfString = '/MusicIndex/Detail/';
              var divContent = '';

              $.each(
                  data,
              function (item) {

                  if (item == 0) {

                      divContent += "<li>";
                      divContent += "<a href='" + herfString + "" + data[item].Id + "'>" + data[item].Name + "<a/>";
                      divContent += "</li>";

                  }
                  else {
                      divContent += "<li>";
                      divContent += "<a href='" + herfString + "" + data[item].Id + "'>" + data[item].Name + "<a/>";
                      divContent += "</li>";
                  }
              });
              //divContent = "<ol >" + divContent + "</ol>";
              $("#xiaoliang").html(divContent);
          }
      }
    )
}


//最新专辑
function Getsales() {

    $.ajax
    (
      {
          type: 'POST',
          async: true,
          url: "/Home/GetAlbumList",
          datatype: 'json',
          success: function (data) {
              var herfString = '/MusicIndex/Detail/';
              var divContent = '';

              $.each(
                  data,
              function (item) {

                  if (item == 0) {

                      divContent += "<li class='honeycomb-cell'>";
                      divContent += "<a href='" + herfString + "" + data[item].Id + "'>";
                      divContent += "<img src='/Pics/" + data[item].UrlString + "'class='honeycomb-cell__image' />";
                      
                      divContent += "<div class='honeycomb-cell__title'>最新专辑";
                     
                      divContent += "</div>";
                      divContent += "</a>";
                      divContent += "</li>";

                  }
                  else {
                      divContent += "<li class='honeycomb-cell'>";
                      divContent += "<a href='" + herfString + "" + data[item].Id + "'>";
                      divContent += "<img src='/Pics/" + data[item].UrlString + "'class='honeycomb-cell__image' />";
                    
                      divContent += "<div class='honeycomb-cell__title'>最新专辑";
                
                      divContent += "</div>";
                      divContent += "</a>";
                      divContent += "</li>";
                  }
              }
              );
              divContent = "<div class='row'><ul class='honeycomb' lang='es'>" + divContent + "</ul></div>";
              $("#newAlbum").html(divContent);
          }
      }
    )
}