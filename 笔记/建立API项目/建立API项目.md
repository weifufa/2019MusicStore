# 建立API项目

## 需要修正的地方

### Nuget程序包

统一System.Web.MVC的版本

统一Owin的版本

### API项目OWIN配置指向

```C#
 //修改Web.config配置文件的OWIN启动项
<appSettings>
    <!--==============定义OWIN的应用程序启动模型================-->
    <add key="owin:AppStartup" value="MVCMusicStore2019.IdentityConfig"/>
  </appSettings>
```



### API数据上下文配置

```C#
  //修改Web.config配置文件中添加音乐专辑数据上下文
<add name="MusicDB" providerName="System.Data.SqlClient" connectionString="Server=.;Initial Catalog=MusicDBDemo1;uid=sa;pwd=123456;MultipleActiveResultSets=true"/>
```

### 处理无法是被Home/Index方法

```C# 
 //在APP_Start/RounteConfig.cs中默认启动路由配置名字空间规约（namespace）
public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"WebAPI.Controllers"}
            );
        }
```



### 访问API资源错误处理

<Error>
<Message>出现错误。</Message>
<ExceptionMessage>
“ObjectContent`1”类型未能序列化内容类型“application/xml; charset=utf-8”的响应正文。
</ExceptionMessage>
<ExceptionType>System.InvalidOperationException</ExceptionType>
<StackTrace/>
<InnerException>
<Message>出现错误。</Message>
<ExceptionMessage>
数据协定名称为“Album_CC389166B6BF4A143FE6367D0EF69540A05B198FF08904D23FEA6D3DB300E362:http://schemas.datacontract.org/2004/07/System.Data.Entity.DynamicProxies”的类型“System.Data.Entity.DynamicProxies.Album_CC389166B6BF4A143FE6367D0EF69540A05B198FF08904D23FEA6D3DB300E362”不是所需的类型。请考虑使用 DataContractResolver（如果你正在使用 DataContractSerializer），或将任何未知类型以静态方式添加到已知类型的列表。例如，可以使用 KnownTypeAttribute 属性，或者将未知类型添加到传递给序列化程序的已知类型列表。
</ExceptionMessage>
<ExceptionType>
System.Runtime.Serialization.SerializationException
</ExceptionType>
<StackTrace>
在 System.Runtime.Serialization.XmlObjectSerializerWriteContext.SerializeAndVerifyType(DataContract dataContract, XmlWriterDelegator xmlWriter, Object obj, Boolean verifyKnownType, RuntimeTypeHandle declaredTypeHandle, Type declaredType) 在 System.Runtime.Serialization.XmlObjectSerializerWriteContext.SerializeWithXsiType(XmlWriterDelegator xmlWriter, Object obj, RuntimeTypeHandle objectTypeHandle, Type objectType, Int32 declaredTypeID, RuntimeTypeHandle declaredTypeHandle, Type declaredType) 在 System.Runtime.Serialization.XmlObjectSerializerWriteContext.InternalSerialize(XmlWriterDelegator xmlWriter, Object obj, Boolean isDeclaredType, Boolean writeXsiType, Int32 declaredTypeID, RuntimeTypeHandle declaredTypeHandle) 在 WriteArrayOfAlbumToXml(XmlWriterDelegator , Object , XmlObjectSerializerWriteContext , CollectionDataContract ) 在 System.Runtime.Serialization.CollectionDataContract.WriteXmlValue(XmlWriterDelegator xmlWriter, Object obj, XmlObjectSerializerWriteContext context) 在 System.Runtime.Serialization.XmlObjectSerializerWriteContext.WriteDataContractValue(DataContract dataContract, XmlWriterDelegator xmlWriter, Object obj, RuntimeTypeHandle declaredTypeHandle) 在 System.Runtime.Serialization.XmlObjectSerializerWriteContext.SerializeAndVerifyType(DataContract dataContract, XmlWriterDelegator xmlWriter, Object obj, Boolean verifyKnownType, RuntimeTypeHandle declaredTypeHandle, Type declaredType) 在 System.Runtime.Serialization.XmlObjectSerializerWriteContext.SerializeWithXsiTypeAtTopLevel(DataContract dataContract, XmlWriterDelegator xmlWriter, Object obj, RuntimeTypeHandle originalDeclaredTypeHandle, Type graphType) 在 System.Runtime.Serialization.DataContractSerializer.InternalWriteObjectContent(XmlWriterDelegator writer, Object graph, DataContractResolver dataContractResolver) 在 System.Runtime.Serialization.DataContractSerializer.InternalWriteObject(XmlWriterDelegator writer, Object graph, DataContractResolver dataContractResolver) 在 System.Runtime.Serialization.XmlObjectSerializer.WriteObjectHandleExceptions(XmlWriterDelegator writer, Object graph, DataContractResolver dataContractResolver) 在 System.Runtime.Serialization.DataContractSerializer.WriteObject(XmlWriter writer, Object graph) 在 System.Net.Http.Formatting.XmlMediaTypeFormatter.WriteToStream(Type type, Object value, Stream writeStream, HttpContent content) 在 System.Net.Http.Formatting.XmlMediaTypeFormatter.WriteToStreamAsync(Type type, Object value, Stream writeStream, HttpContent content, TransportContext transportContext, CancellationToken cancellationToken) --- 引发异常的上一位置中堆栈跟踪的末尾 --- 在 System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task) 在 System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task) 在 System.Web.Http.WebHost.HttpControllerHandler.<WriteBufferedResponseContentAsync>d__1b.MoveNext()
</StackTrace>
</InnerException>
</Error>

### 解决方案

```C#
  ///修改App_Statr
public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();//将xmlformat序列化进行清除
           
```

