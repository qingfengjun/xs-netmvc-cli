# xiaoshuaiWeb

http://www.cnblogs.com/xiaoshuai1992/p/mymvcweb.html\

Asp.net MVC4 +EF6开发的个人网站源码和介绍（仅供新手学习）


db中有数据库文件，可以直接还原到自己本地的sql server 中

本项目是我去年利用业余时间开发的，采用的是asp.net mvc 4 +EF6+三层架构，适合新手进行学习，高手就没有什么价值了，可以直接跳过。

源码和数据库下载（已上传到git）：https://github.com/qingfengjun/xiaoshuaiWeb

本项目实现的功能点如下

维护文章分类
发布文章，包括上传图片、附件、多媒体
前台分类显示，文章显示
文章评论，分享功能
http://images2015.cnblogs.com/blog/532350/201601/532350-20160121224056547-1861160921.png
http://images2015.cnblogs.com/blog/532350/201601/532350-20160121224116359-45455456.png

采用的插件和UI

后台管理系统是模仿的博客园管理系统的Ui
前台的Ui是本人自己设计的
富文本编辑框采用的是百度uedit
弹出层采用的是layer
http://images2015.cnblogs.com/blog/532350/201601/532350-20160121224132687-678282359.png

系统存在的一些问题

没有登录和权限管理
菜单显示和逻辑不太动态
主键使用时间戳，过长也不好看
代码有点混乱，毕竟只是开发玩玩
mvcpager还没有使用起来
EFhelper封装不完整，暂时不支持事物
此项目开发之后的一些体会

部分视图结合强模型是个好东西
模型绑定和mvc自带验证很强大，但是封装性太强
特性比较重要
model和viewmode区分，大型项目要使用viewmode,小型的2者可以结合
