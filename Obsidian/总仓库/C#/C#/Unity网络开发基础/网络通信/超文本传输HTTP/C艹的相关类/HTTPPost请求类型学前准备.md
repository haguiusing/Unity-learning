![[Lesson26.cs]]

```embed
title: "Fetching"
image: "data:image/svg+xml;base64,PHN2ZyBjbGFzcz0ibGRzLW1pY3Jvc29mdCIgd2lkdGg9IjgwcHgiICBoZWlnaHQ9IjgwcHgiICB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCAxMDAgMTAwIiBwcmVzZXJ2ZUFzcGVjdFJhdGlvPSJ4TWlkWU1pZCI+PGcgdHJhbnNmb3JtPSJyb3RhdGUoMCkiPjxjaXJjbGUgY3g9IjgxLjczNDEzMzYxMTY0OTQxIiBjeT0iNzQuMzUwNDU3MTYwMzQ4ODIiIGZpbGw9IiNlMTViNjQiIHI9IjUiIHRyYW5zZm9ybT0icm90YXRlKDM0MC4wMDEgNDkuOTk5OSA1MCkiPgogIDxhbmltYXRlVHJhbnNmb3JtIGF0dHJpYnV0ZU5hbWU9InRyYW5zZm9ybSIgdHlwZT0icm90YXRlIiBjYWxjTW9kZT0ic3BsaW5lIiB2YWx1ZXM9IjAgNTAgNTA7MzYwIDUwIDUwIiB0aW1lcz0iMDsxIiBrZXlTcGxpbmVzPSIwLjUgMCAwLjUgMSIgcmVwZWF0Q291bnQ9ImluZGVmaW5pdGUiIGR1cj0iMS41cyIgYmVnaW49IjBzIj48L2FuaW1hdGVUcmFuc2Zvcm0+CjwvY2lyY2xlPjxjaXJjbGUgY3g9Ijc0LjM1MDQ1NzE2MDM0ODgyIiBjeT0iODEuNzM0MTMzNjExNjQ5NDEiIGZpbGw9IiNmNDdlNjAiIHI9IjUiIHRyYW5zZm9ybT0icm90YXRlKDM0OC4zNTIgNTAuMDAwMSA1MC4wMDAxKSI+CiAgPGFuaW1hdGVUcmFuc2Zvcm0gYXR0cmlidXRlTmFtZT0idHJhbnNmb3JtIiB0eXBlPSJyb3RhdGUiIGNhbGNNb2RlPSJzcGxpbmUiIHZhbHVlcz0iMCA1MCA1MDszNjAgNTAgNTAiIHRpbWVzPSIwOzEiIGtleVNwbGluZXM9IjAuNSAwIDAuNSAxIiByZXBlYXRDb3VudD0iaW5kZWZpbml0ZSIgZHVyPSIxLjVzIiBiZWdpbj0iLTAuMDYyNXMiPjwvYW5pbWF0ZVRyYW5zZm9ybT4KPC9jaXJjbGU+PGNpcmNsZSBjeD0iNjUuMzA3MzM3Mjk0NjAzNiIgY3k9Ijg2Ljk1NTE4MTMwMDQ1MTQ3IiBmaWxsPSIjZjhiMjZhIiByPSI1IiB0cmFuc2Zvcm09InJvdGF0ZSgzNTQuMjM2IDUwIDUwKSI+CiAgPGFuaW1hdGVUcmFuc2Zvcm0gYXR0cmlidXRlTmFtZT0idHJhbnNmb3JtIiB0eXBlPSJyb3RhdGUiIGNhbGNNb2RlPSJzcGxpbmUiIHZhbHVlcz0iMCA1MCA1MDszNjAgNTAgNTAiIHRpbWVzPSIwOzEiIGtleVNwbGluZXM9IjAuNSAwIDAuNSAxIiByZXBlYXRDb3VudD0iaW5kZWZpbml0ZSIgZHVyPSIxLjVzIiBiZWdpbj0iLTAuMTI1cyI+PC9hbmltYXRlVHJhbnNmb3JtPgo8L2NpcmNsZT48Y2lyY2xlIGN4PSI1NS4yMjEwNDc2ODg4MDIwNyIgY3k9Ijg5LjY1Nzc5NDQ1NDk1MjQxIiBmaWxsPSIjYWJiZDgxIiByPSI1IiB0cmFuc2Zvcm09InJvdGF0ZSgzNTcuOTU4IDUwLjAwMDIgNTAuMDAwMikiPgogIDxhbmltYXRlVHJhbnNmb3JtIGF0dHJpYnV0ZU5hbWU9InRyYW5zZm9ybSIgdHlwZT0icm90YXRlIiBjYWxjTW9kZT0ic3BsaW5lIiB2YWx1ZXM9IjAgNTAgNTA7MzYwIDUwIDUwIiB0aW1lcz0iMDsxIiBrZXlTcGxpbmVzPSIwLjUgMCAwLjUgMSIgcmVwZWF0Q291bnQ9ImluZGVmaW5pdGUiIGR1cj0iMS41cyIgYmVnaW49Ii0wLjE4NzVzIj48L2FuaW1hdGVUcmFuc2Zvcm0+CjwvY2lyY2xlPjxjaXJjbGUgY3g9IjQ0Ljc3ODk1MjMxMTE5NzkzIiBjeT0iODkuNjU3Nzk0NDU0OTUyNDEiIGZpbGw9IiM4NDliODciIHI9IjUiIHRyYW5zZm9ybT0icm90YXRlKDM1OS43NiA1MC4wMDY0IDUwLjAwNjQpIj4KICA8YW5pbWF0ZVRyYW5zZm9ybSBhdHRyaWJ1dGVOYW1lPSJ0cmFuc2Zvcm0iIHR5cGU9InJvdGF0ZSIgY2FsY01vZGU9InNwbGluZSIgdmFsdWVzPSIwIDUwIDUwOzM2MCA1MCA1MCIgdGltZXM9IjA7MSIga2V5U3BsaW5lcz0iMC41IDAgMC41IDEiIHJlcGVhdENvdW50PSJpbmRlZmluaXRlIiBkdXI9IjEuNXMiIGJlZ2luPSItMC4yNXMiPjwvYW5pbWF0ZVRyYW5zZm9ybT4KPC9jaXJjbGU+PGNpcmNsZSBjeD0iMzQuNjkyNjYyNzA1Mzk2NDE1IiBjeT0iODYuOTU1MTgxMzAwNDUxNDciIGZpbGw9IiNlMTViNjQiIHI9IjUiIHRyYW5zZm9ybT0icm90YXRlKDAuMTgzNTUyIDUwIDUwKSI+CiAgPGFuaW1hdGVUcmFuc2Zvcm0gYXR0cmlidXRlTmFtZT0idHJhbnNmb3JtIiB0eXBlPSJyb3RhdGUiIGNhbGNNb2RlPSJzcGxpbmUiIHZhbHVlcz0iMCA1MCA1MDszNjAgNTAgNTAiIHRpbWVzPSIwOzEiIGtleVNwbGluZXM9IjAuNSAwIDAuNSAxIiByZXBlYXRDb3VudD0iaW5kZWZpbml0ZSIgZHVyPSIxLjVzIiBiZWdpbj0iLTAuMzEyNXMiPjwvYW5pbWF0ZVRyYW5zZm9ybT4KPC9jaXJjbGU+PGNpcmNsZSBjeD0iMjUuNjQ5NTQyODM5NjUxMTc2IiBjeT0iODEuNzM0MTMzNjExNjQ5NDEiIGZpbGw9IiNmNDdlNjAiIHI9IjUiIHRyYW5zZm9ybT0icm90YXRlKDEuODY0NTcgNTAgNTApIj4KICA8YW5pbWF0ZVRyYW5zZm9ybSBhdHRyaWJ1dGVOYW1lPSJ0cmFuc2Zvcm0iIHR5cGU9InJvdGF0ZSIgY2FsY01vZGU9InNwbGluZSIgdmFsdWVzPSIwIDUwIDUwOzM2MCA1MCA1MCIgdGltZXM9IjA7MSIga2V5U3BsaW5lcz0iMC41IDAgMC41IDEiIHJlcGVhdENvdW50PSJpbmRlZmluaXRlIiBkdXI9IjEuNXMiIGJlZ2luPSItMC4zNzVzIj48L2FuaW1hdGVUcmFuc2Zvcm0+CjwvY2lyY2xlPjxjaXJjbGUgY3g9IjE4LjI2NTg2NjM4ODM1MDYiIGN5PSI3NC4zNTA0NTcxNjAzNDg4NCIgZmlsbD0iI2Y4YjI2YSIgcj0iNSIgdHJhbnNmb3JtPSJyb3RhdGUoNS40NTEyNiA1MCA1MCkiPgogIDxhbmltYXRlVHJhbnNmb3JtIGF0dHJpYnV0ZU5hbWU9InRyYW5zZm9ybSIgdHlwZT0icm90YXRlIiBjYWxjTW9kZT0ic3BsaW5lIiB2YWx1ZXM9IjAgNTAgNTA7MzYwIDUwIDUwIiB0aW1lcz0iMDsxIiBrZXlTcGxpbmVzPSIwLjUgMCAwLjUgMSIgcmVwZWF0Q291bnQ9ImluZGVmaW5pdGUiIGR1cj0iMS41cyIgYmVnaW49Ii0wLjQzNzVzIj48L2FuaW1hdGVUcmFuc2Zvcm0+CjwvY2lyY2xlPjxhbmltYXRlVHJhbnNmb3JtIGF0dHJpYnV0ZU5hbWU9InRyYW5zZm9ybSIgdHlwZT0icm90YXRlIiBjYWxjTW9kZT0ic3BsaW5lIiB2YWx1ZXM9IjAgNTAgNTA7MCA1MCA1MCIgdGltZXM9IjA7MSIga2V5U3BsaW5lcz0iMC41IDAgMC41IDEiIHJlcGVhdENvdW50PSJpbmRlZmluaXRlIiBkdXI9IjEuNXMiPjwvYW5pbWF0ZVRyYW5zZm9ybT48L2c+PC9zdmc+"
description: "Fetching http://192.168.3.242/HTTPRoot/"
url: "http://192.168.3.242/HTTPRoot/"
favicon: ""
```

### Get 和 Post 的区别
#### 主要用途
- **Get**：一般用于从指定的资源请求数据，主要用于获取数据。
- **Post**：一般用于向指定的资源提交想要被处理的数据，主要用于上传数据。
#### 相同点
- Get 和 Post 都可以传递一些额外的参数数据给服务端。
#### 不同点
- 在传递参数时，Post 相对于 Get 更加安全，因为 Post 看不到参数。Get 传递的参数都包含在连接中（URL资源定位地址），是暴露式的，而 Post 传递的参数放在请求数据中，不会出现在 URL 中，是隐藏式的。
- Get 在传递数据时有大小的限制，因为它主要是在连接中拼接参数，而 URL 的长度是有限制的（最大长度一般为 2048 个字符），而 Post 在传递数据时没有限制。
- 在浏览器中，Get 请求能被缓存，而 Post 不能缓存。
- 传输次数可能不同：Get 建立连接——>请求行、请求头、请求数据一次传输——>获取响应——>断开连接，而 Post 建立连接——>传输可能分两次——>请求行，请求头第一次传输——>请求数据第二次传输——>获取响应——>断开。
对于前端来说，其实 Get 和 Post 都能够获取和传递数据，后端只要处理对应逻辑返回响应信息即可。但是由于它们的这些特点，我们在实际使用时建议 Get 用于获取，Post 用于上传。如果想要传递一些不想暴露在外部的参数信息，建议使用 Post，它更加安全。

### Post 如何携带额外参数
关键点：将 Content-Type 设置为 `application/x-www-form-urlencoded` 键值对类型。
```cs
// 创建一个 HTTP 请求对象，指定目标 URL 地址
HttpWebRequest httpWebRequest = HttpWebRequest.Create("http://192.168.1.101:8000/HTTPRoot/") as HttpWebRequest;

// 设置 HTTP 请求方法为 POST
httpWebRequest.Method = WebRequestMethods.Http.Post;

// 设置请求的超时时间为 2 秒
httpWebRequest.Timeout = 2000;

// 设置请求的内容类型为 "application/x-www-form-urlencoded"，表示要发送键值对类型的数据
httpWebRequest.ContentType = "application/x-www-form-urlencoded";

// 准备要上传的数据，这里是一个包含键值对的字符串
string str = "Name=MrTao&ID=2";

// 将字符串编码成字节数组，通常使用 UTF-8 编码
byte[] bytes = Encoding.UTF8.GetBytes(str);

// 设置请求的内容长度为字节数组的长度，以告知服务器请求体的大小
httpWebRequest.ContentLength = bytes.Length;

// 获取用于写入请求数据的流
Stream requestStream = httpWebRequest.GetRequestStream();

// 将字节数组写入请求流
requestStream.Write(bytes, 0, bytes.Length);

// 关闭请求流
requestStream.Close();

// 发送 HTTP 请求并获取响应结果
HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;

// 打印 HTTP 响应的状态码
print(httpWebResponse.StatusCode);
```

成功上传（由于默认为资源服务器，暂时没有后端程序处理响应）
![[Pasted image 20250607205208.png]]
### ContentType 的常用类型
#### ContentType 的构成：
- 内容类型；charset=编码格式；boundary=边界字符串
#### 例如
- `text/html;charset=utf-8;boundary=自定义字符串`
#### 其中内容类型有：
- 文本类型 text：
    - `text/plain` 纯文本文件，没有特定子类型就是它
    - `text/html` HTML 文档，用于网页内容
    - `text/css` CSS 样式表文件，用于网页样式
    - `text/javascript` JavaScript 文件，用于网页脚本
- 图片类型 image：
    - `image/gif`   GIF 图像文件，支持动画
    - `image/png` PNG 图像文件，支持透明度
    - `image/jpeg` JPEG 图像文件，适合照片
    - `image/bm` BMP 图像文件，未压缩的位图
    - `image/webp` WebP 图像文件，现代格式，支持有损和无损压缩
    - `image/x-icon`  图标文件，通常用于网站的 favicon
    - `image/vnd.microsoft.icon` 微软图标文件，与 `image/x-icon` 类似
- 音频类型 audio：
    - `audio/midi` MIDI 音频文件，用于音乐合成
    - `audio/mpeg` MP3 音频文件，广泛使用的音频格式
    - `audio/webm` WebM 音频文件，现代格式，支持多种编解码器
    - `audio/ogg` OGG 音频文件，开源格式
    - `audio/wav` WAV 音频文件，未压缩的音频格式
- 视频类型 video:
    - `video/webm` WebM 视频文件，现代格式，支持多种编解码器
    - `video/ogg` OGG 视频文件，开源格式
- 二进制类型 application:
    - `application/octet-requestStream` 通用二进制数据，表示未知的二进制文件没有特定子类型就是它
    - `application/x-www-form-urlencoded` 表单数据，用于 POST 请求，格式为 `key=value`传递参数时使用键值对形式
    - `application/pkcs12` PKCS#12 文件，用于证书和私钥
    - `application/xhtml+xml`  XHTML 文档，XML 格式的 HTML
    - `application/xml` XML 文件，用于数据交换
    - `application/pdf` PDF 文件，用于文档
    - `application/vnd.mspowerpoint` PowerPoint 文件，用于演示文稿
- 复合内容 multipart:
    - `multipart/form-data` 复合内容，有多种内容组合。用于表单数据，支持文件上传。每个部分都有自己的 `Content-Disposition` 和 `Content-Type`。
    - `multipart/byteranges` 特殊的复合文件。用于分块传输，通常与 HTTP 状态码 `206 Partial Content` 一起使用。

关于 ContentType 更多内容可以前往 [https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Headers/Content-Type](https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Headers/Content-Type)，关于媒体类型可以前往 [https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Basics_of_HTTP/MIME_types](https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Basics_of_HTTP/MIME_types)。

### ContentType 中对于我们来说重要的类型
1. 通用二进制类型：`application/octet-requestStream`
2. 通用文本类型：`text/plain`
3. 键值对参数：`application/x-www-form-urlencoded`
4. 复合类型（传递的信息有多种类型组成，比如有键值对参数，有文件信息等等，上传资源服务器时需要用该类型）：`multipart/form-data`

### 总结
这节课的重点知识点是：
1. Get 和 Post 的区别
2. ContentType 的重要类型

注意：在 HTTP 通讯中，客户端发送给服务端的 Get 和 Post 请求都需要服务端和客户端约定一些规则进行处理，比如传递的参数的含义，数据如何处理等等，都是需要前后端程序制定对应规则来进行处理的。只是我们目前没有后端开发的 HTTP 服务器，所以我们传递过去的参数和数据没有得到对应处理，我们目前只针对 HTTP 资源服务器上传下载数据进行学习，他们的通讯原理是一致的，都是通过 HTTP 通讯交换数据。

### 请简述Get和Post两种请求类型的区别
- Get和Post的区别：
    - 在传递参数时，Post相对Get更加的安全，因为Post看不到参数
    - Get传递的参数都包含在连接中（URL资源定位地址），是暴露式的
    - Post传递的参数放在请求数据中，不会出现在URL中，是隐藏式的
    - Get在传递数据时有大小的限制，因为它主要是在连接中拼接参数，而URL的长度是有限制的（最大长度一般为2048个字符）
    - Post在传递数据时没有限制
    - 在浏览器中Get请求能被缓存，Post不能缓存
    - 传输次数可能不同
        - Get: 建立连接——>请求行、请求头、请求数据一次传输——>获取响应——>断开连接
        - Post: 建立连接——>传输可能分两次——>请求行，请求头第一次传输——>请求数据第二次传输——>获取响应——>断开

### 请说出application/octet-stream，text/plain，application/x-www-form-urlencoded，multipart/form-data，四种内容类型，是用于发送哪种数据的？

- application/octet-stream：通用2进制数据
- text/plain：通用文本数据
- application/x-www-form-urlencoded：键值对参数数据
- multipart/form-data：复合类型数据，多种数据的组合
