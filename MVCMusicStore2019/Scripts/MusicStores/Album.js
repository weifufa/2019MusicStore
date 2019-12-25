$(document).ready(
    function Preloading() {
        //print();
        loadGenre();
        loadArtist();
        loadAlbumType();
        singleFileSelected();
        upFileImg();
    });

function loadGenre() {
    $.ajax({
        type: 'POST',
        async: true,
        url: '/Album/GetGenreList',//调用目标控制器方法
        dataType: 'json',
        success: function (data) {
            selectedId = $('#CurrentGenreSelectedId').val();
            var contenString = '';
            var object = data;
            $.each(
                object,
                function (item) {
                    if (object[item].Id == selectedId) {
                        contenString += "<option value='" + object[item].Id + "' selected>" + object[item].Name + "</option>";
                        //alert(GenreID);
                        //alert(contenString);
                    }
                    else {
                        contenString += "<option value='" + object[item].Id + "'>" + object[item].Name + "</option>";
                    }
                });
            contenString = "<select id='GenreId' name='GenreId'class='form-control'>" + contenString + "</select>";
            $('#GenreSelectList').html(contenString);
            $('#GenreSelectList').val($('#CurrentGenreSelectedId').val());//被选项
        }
    })
}

function loadArtist() {
    $.ajax({
        type: 'POST',
        async: true,
        url: '/Album/GetArtistList',//调用目标控制器方法
        dataType: 'json',
        success: function (data) {
            selectedId = $('#CurrentArtistSelectedId').val();
            var contenString = '';
            var object = data;
            $.each(
                object,
                function (item) {
                    if (object[item].Id ==selectedId) {
                        contenString += "<option value='" + object[item].Id + "' selected>" + object[item].Name + "</option>";
                        //alert(GenreID);
                        //alert(contenString);
                    }
                    else {
                        contenString += "<option value='" + object[item].Id + "'>" + object[item].Name + "</option>";
                    }
                });
            contenString = "<select id='ArtistId' name='ArtistId'class='form-control'>" + contenString + "</select>";
            $('#ArtistSelectList').html(contenString);
            $('#ArtistSelectList').val($('#CurrentArtistSelectedId').val());//被选项
        }
    })
}
function loadAlbumType() {
    $.ajax({
        type: 'POST',
        async: true,
        url: '/Album/GetAlbumTypeList',//调用目标控制器方法
        dataType: 'json',
        success: function (data) {
            selectedId =$('#CurrentAlbumTypeSelectedId').val();
            var contenString = '';
            var object = data;
            $.each(
                object,
                function (item) {
                    if (object[item].Id == selectedId) {
                        contenString += "<option value='" + object[item].Id + "' selected>" + object[item].Name + "</option>";
                        //alert(GenreID);
                        //alert(contenString);
                    }
                    else {
                        contenString += "<option value='" + object[item].Id + "'>" + object[item].Name + "</option>";
                    }
                });
            contenString = "<select id='AlbumTypeId' name='AlbumTypeId'class='form-control'>" + contenString + "</select>";
            $('#AlbumTypeSelectList').html(contenString);
            $('#AlbumTypeSelectList').val($('#CurrentAlbumTypeSelectedId').val());//被选项
        }
    })
}


//图片上传实现
function upFileImg() {
    var files = $('#UploadedFile').prop('files');//需要检查前端input标签的id名，检查input类型是否为flie
    var data = new FormData();
    data.append('imgFile',files[0]);
  $.ajax({
        type: 'POST',
        url: "/Album/UploadImgFile", //跳转控制器方法，在控制器UploadImgFile方法打断点
        data: data,
        dataType: 'json',//注意：不要写成josn
        cache: false,
        processData: false,
        contentType: false,
        success: function (result) { //result:控制器回传的JSON数据
            alert("图片上传成功!");//是否获取控制器生成的图片文件名
            $("#UrlString").val(result.imgUrlString);
        }
    });
}



//图片预览实现
function singleFileSelected(evt) {

    var selectedFile = ($("#UploadedFile"))[0].files[0];
    if (selectedFile) {
        var FileSize = 0;
        var imageType = /image.*/;

        if (selectedFile.size > 1048576) {
            FileSize = Math.round(selectedFile.size * 100 / 1048576) / 10 + "MB";

        }

        else if (selectedFile.size > 1024) {
            FileSize = Math.round(selectedFile.size * 100 / 1048576) / 10 + "KB";

        }
        else {
            FileSize = selectedFile.size + "Bytes";

        }

        $("#FileName").text("文件名:" + selectedFile.name);
        $("#FileSize").text("大小:" + FileSize);
        $("#FileType").text("类型:" + selectedFile.type);
    }
    if (selectedFile.type.match(imageType)) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $("#Imagecontainer").empty();
            var dataURL = reader.result;
            var img = new Image()
            img.src = dataURL;
            img.className = "thumb";
            $("#Imagecontainer").append(img);
        };
        reader.readAsDataURL(selectedFile);
    }
}

//function print() {
//    GenreID = document.getElementById("CurrentGenreSelectedId").value;
//    ArtistID = document.getElementById("CurrentArtistSelectedId").value;
//    AlbumTypeID = document.getElementById("CurrentAlbumTypeSelectedId").value;


//}
//var GenreID;
//var ArtistID;
//var AlbumTypeID;