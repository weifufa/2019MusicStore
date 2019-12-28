# Ajax、jQuery小结

# jQuery选择器

```javascript
//基础选择器，通过类名选择
$('类名')
 //后代元素选择
 $('类名 后代名称(标签、类名)')
  //标签选择、属性选择
 $('标签名')
 $('标签名[htmlAtrribute]')
  //Id选择
 $('#Id名称')
   //同辈、平辈选择
  $('div:nth-last-child')
```

## 侦测滚动条元素

```javascript
$(document.scroll(function(){//侦测滚动条事件(文档)
    //事件实现
})
  $(window).scroll(function(){//侦测滚动条事件(ViewPort)
    //事件实现
})
  $(window).body(function(){//侦测滚动条事件(html的主体body)
    //事件实现
})
```

## jQuery文档处理

### append、appendTo

```javascript
$('<div>').appendTo($('#targetName')); //将创建的div元素追加到#targetName元素之后
$('#Id名').append(contentString); //在一个人元素中（ID名识别）添加conrentString内容
```

### prepend、prependTo

```javascript
$('<div>').prependTo($('#targetName')); //将创建的div元素，并将其内容添加#targetName元素之后
$('#Id名').prepend(contentString); //在conrentString内容最后，添加创建的元素（ID名标识）
```

### replacewith、replaceAll

```javascript
$("<标签名1>").replaceAll($('标签2'));//将创建的标签1内容替换标签2内容
$("<标签名2>").replaceWith($('标签1'));//将创建的标签1内容替换标签2内容
```

### empty、remove

```javascript
$('div').empty();  //移除div所有后代元素



$('div').click(function(){
    alert('进来了');
});
var obj=$('div').remove(); //将div的元素、绑定数据、事件全部从document删除



$('div').click(function(){
    alert('进来了');
});
var obj=$('div').detach(); //将div的元素删除，但绑定数据、事件全部保留
```



### 事件处理

#### 页面载入

```javascript
window.onload=function{
    //侦测页面资源加载完毕，....
}
$(document).ready(function(){
    //等待页面结构加载完毕，....
})
$(function(){
    //和window.onload等效
})
```

### 事件处理

```JavaScript
$('#Id名').on('click',function(){
    //当对应元素被单击时，......
})
$('#Id名').on('dbclick',function(){
    //当对应元素被双击时，......
})

$('#Id名').on('mousehover',function(){
    //当对应元素鼠标悬停事件时，......
})
$('#Id名').on('mouseover',function(){
    //当对应元素鼠离开时，......
})

$('#Id名').hover(function(){
     //当对应元素鼠标悬停、移入时，......
},function(){
     //当对应元素鼠标移出时，......
})


$('div').animate({left:200},500,'easing',function(){
    //动画从左边以500的速度执行，执行完毕后，....
})
```



# Ajax函数

```javascript
$.ajax() //ajax最底层函数

$.ajax({
    type:'POST',
    url:"TargetName",
    data:"Id=5,name=dd",
    success:function(evt){
        //成功后，....
    }
})
```

## $.get()、$.Post()、$.getJSON()、$getScript()

```javascript
$.getJSON("Json目标文件名",function(json){
    //JSON数据获取成功后,执行....
})
```

## Ajax全局处理函数

ajaxComplete：Ajax请求完成时执行

ajaxError：Ajax请求出错时执行

ajaxSuccess：Ajax请求成功时执行

ajaxSend：Ajax开始发送时执行

ajaxStart：Ajax开始执行时执行

ajaxStop：Ajax请求结束时执行

```javascript
$(document).ajaxStart(function(){
    $('div').html('页面....')
})
```

